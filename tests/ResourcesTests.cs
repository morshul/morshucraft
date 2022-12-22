// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using morshucraft.Resources;
using NUnit.Framework;

namespace morshucraft.Tests;

public class ResourcesTests
{
    [Test]
    public void ResourceAssembly_ShouldReturnAssembly()
    {
        var assembly = ResourcesExtensions.ResourceAssembly;
        Assert.IsNotNull(assembly);
    }
}
