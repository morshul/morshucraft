// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using minecraft.Game.Platform.Windowing;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace minecraft.Game.Platform.Impl.Linux;

public sealed unsafe class LinuxGraphicsContext : IGraphicsContext
{
    private Window* window;

    public nint Handle => (nint)window;

    public bool IsCurrent { get; private set; }

    public LinuxGraphicsContext(Window* window)
    {
        this.window = window;

        IsCurrent = false;
    }

    public nint GetProcAddress(string procName)
        => GLFW.GetProcAddress(procName);


    public void MakeCurrent()
    {
        if (IsCurrent) return;

        GLFW.MakeContextCurrent(window);
        IsCurrent = true;
    }

    public void ReleaseCurrent()
    {
        if (!IsCurrent) return;

        GLFW.MakeContextCurrent(null);
        IsCurrent = false;
    }

    public void SwapBuffers()
        => GLFW.SwapBuffers(window);

    public void PollEvents()
        => GLFW.PollEvents();
}
