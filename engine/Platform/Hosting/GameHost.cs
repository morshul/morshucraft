// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Reflection;
using morshucraft.API.Hosting;
using morshucraft.API.Hosting.Modules;
using morshucraft.Engine.Platform.Modules;

namespace morshucraft.Engine.Platform.Hosting;

public abstract class GameHost : IGameHost
{
    private readonly List<ModuleHost> modules = new();

    public event Action? Activated;
    public event Action? Deactivated;

    public bool IsActive { get; private set; }

    protected GameHost()
    {
    }

    protected virtual void OnActivated()
    {
        if (IsActive) return;

        Activated?.Invoke();

        IsActive = true;
        foreach (var module in modules)
            module.OnActivated();
    }

    protected virtual void OnDeactivated()
    {
        if (!IsActive) return;

        IsActive = false;
        foreach (var module in modules)
            module.OnDeactivated();

        Deactivated?.Invoke();
    }

    public virtual void LoadModuleFromAssembly(Assembly assembly)
    {
        var moduleEntryPoint = assembly
            .GetTypes()
            .Where(t =>
            {
                var isClassAndNotAbstract = t is { IsClass: true, IsAbstract: false };
                var isEntryPoint = t
                    .GetCustomAttributes()
                    .Any(attr => attr.GetType() == typeof(ModuleEntryPointAttribute));

                return isClassAndNotAbstract && isEntryPoint;
            })
            .FirstOrDefault();

        if (moduleEntryPoint is null)
            throw new NullReferenceException("There is no module entry point in the assembly.");

        if (Activator.CreateInstance(moduleEntryPoint) is not ModuleHost module)
            throw new NullReferenceException($"The module entry point is not a {nameof(ModuleHost)}.");

        module.Host = this;

        modules.Add(module);
    }

    public virtual void Run()
    {
        OnActivated();
    }

    public virtual void Exit()
    {
        OnDeactivated();
    }

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        OnDeactivated();
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
