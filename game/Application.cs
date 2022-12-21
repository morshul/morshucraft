// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Drawing;
using minecraft.Game.Input;
using minecraft.Game.Platform.Impl.Linux;
using minecraft.Game.Platform.Windowing;

namespace minecraft.Game;

public class Application : IDisposable
{
    private IDesktopWindow window;

    public Application()
    {
        window = new LinuxDesktopWindow();
        window.Size = new Size(1366, 768);

        window.CreateCapabilities();
    }

    public void Run()
    {
        while (window.Exists)
        {
            window.Context?.PollEvents();
            window.Context?.SwapBuffers();
        }
    }

    private void releaseUnmanagedResources()
    {
        window.Dispose();
    }

    public void Dispose()
    {
        releaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~Application()
    {
        releaseUnmanagedResources();
    }
}
