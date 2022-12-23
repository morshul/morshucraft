// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace morshucraft.API.Hosting;

public interface IGameHost : IDisposable
{
    bool IsActive { get; }
}
