// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Drawing;

namespace minecraft.Game.Events.Windowing;

public sealed class WindowResizeEvent : EventBase
{
    public override string Name => nameof(WindowResizeEvent);

    public override EventType Type => EventType.WindowResize;
    public override EventCategory Category => EventCategory.Application | EventCategory.Window;

    public readonly Size Size;

    public WindowResizeEvent(Size size)
    {
        Size = size;
    }

    public override string ToString()
        => $"{Name}::[{Size.Width}, {Size.Height}]";
}
