// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using morshucraft.Engine.Platform.Hosting;

namespace morshucraft.Engine.Platform.Linux;

public sealed class LinuxGameHost : GameHost
{
    protected override void OnActivated()
    {
        Console.WriteLine($"[LinuxGameHost] Hello, world!");

        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        Console.WriteLine($"[LinuxGameHost] Goodbye, world!");

        base.OnDeactivated();
    }
}
