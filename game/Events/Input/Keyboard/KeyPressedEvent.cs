// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using minecraft.Game.Input;

namespace minecraft.Game.Events.Input.Keyboard;

public sealed class KeyPressedEvent : KeyEventBase
{

    public override string Name => nameof(KeyPressedEvent);

    public override EventType Type => EventType.KeyPressed;

    public readonly int Count;

    public KeyPressedEvent(InputKey key, int count)
        : base(key)
    {
        Count = count;
    }

    public override string ToString()
        => $"{Name}::{Key.ToString()}{(Count >= 1 ? $" (repeated {Count} times)" : "")}";
}
