// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace minecraft.Game.Platform;

public interface ICanHandle<out T>
{
    T Handle { get; }
}
