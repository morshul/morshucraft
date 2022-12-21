// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Drawing;

namespace minecraft.Game.Events.Windowing;

public sealed class WindowMoveEvent : EventBase
{
    public override string Name => nameof(WindowMoveEvent);

    public override EventType Type => EventType.WindowMove;
    public override EventCategory Category => EventCategory.Application | EventCategory.Window;

    public readonly Point Position;

    public WindowMoveEvent(Point position)
    {
        Position = position;
    }

    public override string ToString()
        => $"{Name}::[{Position.X}, {Position.Y}]";
}
