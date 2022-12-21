// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using minecraft.Game.Events;

namespace minecraft.Game.Extensions.EventExtensions;

public static class EventExtensions
{
    public static bool IsInCategory(this EventBase e, EventCategory category)
        => (e.Category & category) == category;
}
