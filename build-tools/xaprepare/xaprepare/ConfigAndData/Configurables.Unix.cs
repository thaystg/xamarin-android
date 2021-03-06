using System;
using System.IO;

namespace Xamarin.Android.Prepare
{
	partial class Configurables
	{
		const string MicrosoftOpenJDKFileExtension   = "tar.gz";
		const string AdoptOpenJDKArchiveExtension = "tar.gz";

		partial class Defaults
		{
			public const string DefaultCompiler = "cc";
		}

		partial class Paths
		{
			static string ArchiveOSType                 => Context.Instance.OS.Type;

			public static string HostRuntimeDir         => GetCachedPath (ref hostRuntimeDir, ()   => Path.Combine (XAInstallPrefix, "xbuild", "Xamarin", "Android", "lib", $"host-{ctx.OS.Type}"));

			public static readonly string MonoRuntimeHostMingwNativeLibraryPrefix = Path.Combine ("..", "bin");

			static string? hostRuntimeDir;
		}

		partial class Urls
		{
			public static readonly Uri DotNetInstallScript = new Uri ("https://dot.net/v1/dotnet-install.sh");
		}
	}
}
