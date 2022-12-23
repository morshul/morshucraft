// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Runtime.InteropServices;
using morshucraft.Engine.Platform.Hosting;
using morshucraft.Engine.Platform.Linux;

namespace morshucraft.Engine;

public static class Host
{
    public static GameHost GetSuitableHost()
    {
        if (OperatingSystem.IsLinux())
            return new LinuxGameHost();

        throw new PlatformNotSupportedException("The current platform is not supported.");
    }
}
