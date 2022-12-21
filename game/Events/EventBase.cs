// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace minecraft.Game.Events;

public abstract class EventBase
{
    public abstract string Name { get; }

    public abstract EventType Type { get; }

    public abstract EventCategory Category { get; }

    public override string ToString()
        => $"{Name}";
}
