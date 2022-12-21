// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace minecraft.Game.Events;

public enum EventType
{
    None = 0,

    WindowResize,
    WindowMove,
    WindowFocus,
    WindowLostFocus,
    WindowClose,

    KeyPressed,
    KeyReleased,
}
