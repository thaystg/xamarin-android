using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.ProjectTools;

namespace Xamarin.Android.Build.Tests
{
	static class InlineData
	{
		const string Resx = @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
	<resheader name=""resmimetype"">
		<value>text/microsoft-resx</value>
	</resheader>
	<resheader name=""version"">
		<value>2.0</value>
	</resheader>
	<resheader name=""reader"">
		<value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
	</resheader>
	<resheader name=""writer"">
		<value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
	</resheader>
	<!--contents-->
</root>";

		public static string ResxWithContents (string contents)
		{
			return Resx.Replace ("<!--contents-->", contents);
		}

		public static void AddCultureResourcesToProject (IShortFormProject proj, string filename, string dataName, CultureTypes types = CultureTypes.AllCultures)
		{
			foreach (var culture in CultureInfo.GetCultures (types)) {
				proj.OtherBuildItems.Add (new BuildItem ("EmbeddedResource", $"{filename}.{culture.Name}.resx") {
					TextContent = () => InlineData.ResxWithContents ($"<data name=\"{dataName}\"><value>{culture.Name}</value></data>")
				});
			}
		}
	}
}
