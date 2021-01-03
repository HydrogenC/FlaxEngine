// Copyright (c) 2012-2021 Wojciech Figat. All rights reserved.

using System;
using System.IO;
using Flax.Build;
using Flax.Build.NativeCpp;

/// <summary>
/// https://www.freetype.org/
/// </summary>
public class freetype : DepsModule
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        LicenseType = LicenseTypes.Custom;
        LicenseFilePath = "LICENSE.TXT";
    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        var depsRoot = options.DepsFolder;
        switch (options.Platform.Target)
        {
        case TargetPlatform.Windows:
        case TargetPlatform.UWP:
        case TargetPlatform.XboxOne:
        case TargetPlatform.XboxScarlett:
            options.OutputFiles.Add(Path.Combine(depsRoot, "freetype.lib"));
            options.OptionalDependencyFiles.Add(Path.Combine(depsRoot, "freetype.pdb"));
            break;
        case TargetPlatform.Linux:
        case TargetPlatform.PS4:
        case TargetPlatform.Android:
            options.OutputFiles.Add(Path.Combine(depsRoot, "libfreetype.a"));
            break;
        default: throw new InvalidPlatformException(options.Platform.Target);
        }

        options.PublicIncludePaths.Add(Path.Combine(Globals.EngineRoot, @"Source\ThirdParty\freetype"));
    }
}
