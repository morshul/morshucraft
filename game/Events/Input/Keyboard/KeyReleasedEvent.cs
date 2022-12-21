// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using minecraft.Game.Input;

namespace minecraft.Game.Events.Input.Keyboard;

public sealed class KeyReleasedEvent : KeyEventBase
{
    public override string Name => nameof(KeyReleasedEvent);

    public override EventType Type => EventType.KeyReleased;


    public KeyReleasedEvent(InputKey key)
        : base(key)
    {
    }

    public override string ToString()
        => $"{Name}::{Key}";
}
