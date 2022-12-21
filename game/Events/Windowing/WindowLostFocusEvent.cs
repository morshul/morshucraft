// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace minecraft.Game.Events.Windowing;

public sealed class WindowLostFocusEvent : EventBase
{
    public override string Name => nameof(WindowLostFocusEvent);

    public override EventType Type => EventType.WindowClose;
    public override EventCategory Category => EventCategory.Application | EventCategory.Window;

    public override string ToString()
        => $"{Name}";
}
