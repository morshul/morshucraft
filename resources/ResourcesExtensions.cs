// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Reflection;

namespace morshucraft.Resources;

public static class ResourcesExtensions
{
    /// <summary>
    /// Gets the resource assembly. It's the assembly that contains the resources.
    /// </summary>
    public static Assembly ResourceAssembly => typeof(ResourcesExtensions).Assembly;
}
