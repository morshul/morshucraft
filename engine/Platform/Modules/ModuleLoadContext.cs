// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Reflection;
using System.Runtime.Loader;

namespace morshucraft.Engine.Platform.Modules;

public sealed class ModuleLoadContext : AssemblyLoadContext
{
    private const string module_folder = "modules";

    private readonly AssemblyDependencyResolver resolver;

    public ModuleLoadContext(string moduleFolder = module_folder)
    {
        resolver = new AssemblyDependencyResolver(moduleFolder);
    }

    protected override Assembly? Load(AssemblyName name)
    {
        var path = resolver.ResolveAssemblyToPath(name);

        return path is not null ? LoadFromAssemblyPath(path) : null;
    }

    protected override nint LoadUnmanagedDll(string name)
    {
        var path = resolver.ResolveUnmanagedDllToPath(name);

        return path is not null ? LoadUnmanagedDllFromPath(path) : nint.Zero;
    }
}
