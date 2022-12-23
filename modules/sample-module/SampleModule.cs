// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using morshucraft.API.Hosting.Modules;

namespace morshucraft.Modules.SampleModule;

[ModuleEntryPoint]
public sealed class SampleModule : ModuleHost
{
    protected override void OnActivated()
    {
        Console.WriteLine($"[SampleModule] Hello, world! Is game host active? {Host?.IsActive}");

        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        Console.WriteLine($"[SampleModule] Goodbye, world! Is game host active? {Host?.IsActive}");

        base.OnDeactivated();
    }
}
