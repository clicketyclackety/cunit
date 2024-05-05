using generator.files;
using generator.units;

namespace generator;

public class CsProj : IGenerateableFile
{
    public List<string> Generate()
    {
        return GenerateCsProj().ToList();
    }

    private IEnumerable<string> GenerateCsProj()
    {
        yield return "<Project Sdk=\"Microsoft.NET.Sdk\">";
        yield return string.Empty;
        yield return "\t<PropertyGroup>";
        yield return "\t\t<TargetFrameworks>netstandard2.0;net6.0</TargetFrameworks>";
        yield return "\t\t<ImplicitUsings>enable</ImplicitUsings>";
        yield return "\t\t<Nullable>enable</Nullable>";
        yield return "\t\t<LangVersion>11</LangVersion>";
        yield return "\t\t<GeneratePackageOnBuild>true</GeneratePackageOnBuild>";
        yield return "\t\t<Version>0.9.0</Version>";
        yield return "\t\t<Title>cunit</Title>";
        yield return "\t\t<Authors>Callum Sykes</Authors>";
        yield return "\t\t<Description>cunit is a general units library for C# with a focus on elegance and efficiency.</Description>";
        yield return "\t\t<Copyright>Callum Sykes</Copyright>";
        yield return "\t\t<PackageProjectUrl>https://github.com/clicketyclackety/cunit</PackageProjectUrl>";
        yield return "\t\t<PackageLicenseUrl>https://github.com/clicketyclackety/cunit/LICENSE.md</PackageLicenseUrl>";
        yield return "\t\t<RepositoryUrl>https://github.com/clicketyclackety/cunit</RepositoryUrl>";
        yield return "\t\t<RepositoryType>git</RepositoryType>";
        yield return "\t\t<PackageTags>cunit, unit, library</PackageTags>";
        yield return "\t\t<AssemblyVersion>$(Version)</AssemblyVersion>";
        yield return "\t\t<FileVersion>$(Version)</FileVersion>";
        yield return "\t</PropertyGroup>";
        yield return string.Empty;
        yield return "\t<ItemGroup>";
        yield return "\t\t<PackageReference Include=\"System.Text.Json\" Version=\"7.0.3\" />";
        yield return "\t\t<PackageReference Include=\"Microsoft.CSharp\" Version=\"4.7.0\" Condition=\"'$(TargetFramework)' == 'netstandard2.0'\"/>";
        yield return "\t</ItemGroup>";
        yield return string.Empty;
        yield return "</Project>";
        yield return string.Empty;
    }

    public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "cunit.csproj");
        
}
