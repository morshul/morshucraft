// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using OpenTK;

namespace minecraft.Game.Platform.Windowing;

public interface IGraphicsContext : ICanHandle<nint>, IBindingsContext
{
    bool IsCurrent { get; }

    void MakeCurrent();

    void ReleaseCurrent();

    void SwapBuffers();

    void PollEvents();
}
