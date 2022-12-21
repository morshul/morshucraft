// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace minecraft.Game.Events;

[Flags]
public enum EventCategory
{
    None = 0,

    Window,
    Application,

    Input,
    Keyboard
}
