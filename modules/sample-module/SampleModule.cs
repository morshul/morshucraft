// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using morshucraft.API.Hosting.Modules;

namespace morshucraft.Modules.SampleModule;

[ModuleEntryPoint]
public sealed class SampleModule : ModuleHost
{
    protected override void OnActivated()
    {
        Logger.Information("SampleModule has been activated! Is host active? {@IsActive}", Host?.IsActive);

        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        Logger.Information("SampleModule has been deactivated! Is host active? {@IsActive}", Host?.IsActive);

        base.OnDeactivated();
    }
}
