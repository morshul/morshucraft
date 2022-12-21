// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Drawing;
using minecraft.Game.Events;
using minecraft.Game.Events.Input.Keyboard;
using minecraft.Game.Events.Windowing;

namespace minecraft.Game.Platform.Windowing;

public interface IDesktopWindow : ICanHandle<nint>, IDisposable
{
    IGraphicsContext? Context { get; }

    string Title { get; set; }

    Size Size { get; set; }

    Point Position { get; set; }

    bool Exists { get; }

    void CreateCapabilities();

    event Action<IDesktopWindow, EventBase> OnEvent;

    event Action<IDesktopWindow, WindowResizeEvent> OnResize;

    event Action<IDesktopWindow, WindowMoveEvent> OnMove;

    event Action<IDesktopWindow, WindowFocusEvent> OnFocus;

    event Action<IDesktopWindow, WindowLostFocusEvent> OnLostFocus;

    event Action<IDesktopWindow, WindowCloseEvent> OnClose;

    event Action<IDesktopWindow, KeyPressedEvent> OnKeyPressed;

    event Action<IDesktopWindow, KeyReleasedEvent> OnKeyReleased;
}
