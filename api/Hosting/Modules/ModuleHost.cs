// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Serilog;

namespace morshucraft.API.Hosting.Modules;

public abstract class ModuleHost : IDisposable
{
    protected internal IGameHost? Host { get; internal set; }

    protected internal ILogger Logger { get; internal set; } = null!;

    protected internal virtual void OnActivated() { }

    protected internal virtual void OnDeactivated() { }

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
