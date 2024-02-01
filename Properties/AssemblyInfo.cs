using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(HelsperimentalMod.BuildInfo.Description)]
[assembly: AssemblyDescription(HelsperimentalMod.BuildInfo.Description)]
[assembly: AssemblyCompany(HelsperimentalMod.BuildInfo.Company)]
[assembly: AssemblyProduct(HelsperimentalMod.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + HelsperimentalMod.BuildInfo.Author)]
[assembly: AssemblyTrademark(HelsperimentalMod.BuildInfo.Company)]
[assembly: AssemblyVersion(HelsperimentalMod.BuildInfo.Version)]
[assembly: AssemblyFileVersion(HelsperimentalMod.BuildInfo.Version)]
[assembly: MelonInfo(typeof(HelsperimentalMod.FrosHelsperimentalMod), HelsperimentalMod.BuildInfo.Name, HelsperimentalMod.BuildInfo.Version, HelsperimentalMod.BuildInfo.Author, HelsperimentalMod.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]