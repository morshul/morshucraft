// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using minecraft.Game.Input;

namespace minecraft.Game.Events.Input.Keyboard;

public abstract class KeyEventBase : EventBase
{
    public abstract override string Name { get; }

    public abstract override EventType Type { get; }

    public override EventCategory Category => EventCategory.Input | EventCategory.Keyboard;

    public readonly InputKey Key;

    public KeyEventBase(InputKey key)
    {
        Key = key;
    }

    public override string ToString()
        => $"{Name}::{Key.ToString()}";
}
