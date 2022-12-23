// Copyright (c) Israel Calebe <morshu0@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace morshucraft.API.Hosting.Modules;

/// <summary>
/// Marks the entry point of a module.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ModuleEntryPointAttribute : Attribute
{
}
