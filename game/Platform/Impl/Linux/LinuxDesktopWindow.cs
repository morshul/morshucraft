// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Drawing;
using minecraft.Game.Events;
using minecraft.Game.Events.Input.Keyboard;
using minecraft.Game.Events.Windowing;
using minecraft.Game.Input;
using minecraft.Game.Platform.Windowing;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace minecraft.Game.Platform.Impl.Linux;

public sealed unsafe class LinuxDesktopWindow : IDesktopWindow
{
    private Window* window;
    private bool glfwInitialized;

    private string title;
    private Size size;
    private Point position;

    public nint Handle { get; }

    public IGraphicsContext? Context { get; private set; }

    public string Title
    {
        get => title;
        set
        {
            if (title == value) return;
            title = value;

            if (window != null)
                GLFW.SetWindowTitle(window, title);
        }
    }

    public Size Size
    {
        get => size;
        set
        {
            if (size == value) return;
            size = value;

            if (window != null)
                GLFW.SetWindowSize(window, size.Width, size.Height);
        }
    }

    public Point Position
    {
        get => position;
        set
        {
            if (position == value) return;
            position = value;

            if (window != null)
                GLFW.SetWindowPos(window, position.X, position.Y);
        }
    }

    public bool Exists
    {
        get
        {
            if (window == null)
                return false;

            return !GLFW.WindowShouldClose(window);
        }
    }

    public event Action<IDesktopWindow, EventBase>? OnEvent;
    public event Action<IDesktopWindow, WindowResizeEvent>? OnResize;
    public event Action<IDesktopWindow, WindowMoveEvent>? OnMove;
    public event Action<IDesktopWindow, WindowFocusEvent>? OnFocus;
    public event Action<IDesktopWindow, WindowLostFocusEvent>? OnLostFocus;
    public event Action<IDesktopWindow, WindowCloseEvent>? OnClose;
    public event Action<IDesktopWindow, KeyPressedEvent>? OnKeyPressed;
    public event Action<IDesktopWindow, KeyReleasedEvent>? OnKeyReleased;

    public LinuxDesktopWindow()
    {
        title ??= "Minecraft";

        if (size.IsEmpty)
            size = new Size(800, 600);

        GLFW.SetErrorCallback((error, description) =>
            throw new GLFWException(description, error));

        glfwInitialized = GLFW.Init();
    }

    public void CreateCapabilities()
    {
        GLFW.WindowHint(WindowHintInt.ContextVersionMajor, 3);
        GLFW.WindowHint(WindowHintInt.ContextVersionMinor, 3);
        GLFW.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, OpenGlProfile.Core);

        window = GLFW.CreateWindow(size.Width, size.Height, title, null, null);

        if (window == null)
            throw new GLFWException("There was an error creating the window.");

        Context = new LinuxGraphicsContext(window);
        Context.MakeCurrent();

        if (!position.IsEmpty)
            GLFW.SetWindowPos(window, position.X, position.Y);

        GLFW.SetWindowPosCallback(window, (_, x, y) =>
        {
            if (position.X == x && position.Y == y) return;
            position = new Point(x, y);

            var e = new WindowMoveEvent(position);

            OnEvent?.Invoke(this, e);
            OnMove?.Invoke(this, e);
        });

        GLFW.SetWindowSizeCallback(window, (_, width, height) =>
        {
            if (size.Width == width && size.Height == height) return;
            size = new Size(width, height);

            var e = new WindowResizeEvent(size);

            OnEvent?.Invoke(this, e);
            OnResize?.Invoke(this, e);
        });

        GLFW.SetWindowFocusCallback(window, (_, focused) =>
        {
            switch (focused)
            {
                case true:
                {
                    var e = new WindowFocusEvent();

                    OnEvent?.Invoke(this, e);
                    OnFocus?.Invoke(this, e);
                    break;
                }
                case false:
                {
                    var e = new WindowLostFocusEvent();

                    OnEvent?.Invoke(this, e);
                    OnLostFocus?.Invoke(this, e);
                    break;
                }
            }
        });

        GLFW.SetWindowCloseCallback(window, _ =>
        {
            var e = new WindowCloseEvent();

            OnEvent?.Invoke(this, e);
            OnClose?.Invoke(this, e);
        });

        GLFW.SetKeyCallback(window, (_, key, code, action, mods) =>
        {
            switch (action)
            {
                case InputAction.Press:
                {
                    var e = new KeyPressedEvent((InputKey)key, 0);

                    OnEvent?.Invoke(this, e);
                    OnKeyPressed?.Invoke(this, e);
                    break;
                }
                case InputAction.Repeat:
                {
                    var e = new KeyPressedEvent((InputKey)key, 1);

                    OnEvent?.Invoke(this, e);
                    OnKeyPressed?.Invoke(this, e);
                    break;
                }
                case InputAction.Release:
                {
                    var e = new KeyReleasedEvent((InputKey)key);

                    OnEvent?.Invoke(this, e);
                    OnKeyReleased?.Invoke(this, e);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        });
    }

    private void releaseUnmanagedResources()
    {
        if (!glfwInitialized) return;

        GLFW.Terminate();
    }

    public void Dispose()
    {
        releaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~LinuxDesktopWindow()
    {
        releaseUnmanagedResources();
    }
}
