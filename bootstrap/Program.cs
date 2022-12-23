// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using morshucraft.Engine;
using morshucraft.Modules.SampleModule;

using var host = Host.GetSuitableHost();
host.LoadModuleFromAssembly(typeof(SampleModule).Assembly);

host.Run();
