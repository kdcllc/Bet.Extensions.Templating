# Bet.Extensions.Templating Projects

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

Bet.Extensions.Templating Projects


## Development

```bash
    dotnet new -i .\

    dotnet new -u C:\Dev\Github\kdcllc\Bet.Extensions.Templating\src\console.di\src

    dotnet new -i PATH_TO_NUPKG_FILE

    

```

- Installing from nuget package
```bash
    # build 
    dotnet build -c Release
    dotnet pack -c Release -o packages
    dotnet new -i packages\Bet.Extension.Template.Console.DI.CSharp.1.0.0.nupkg
    
    # uninstall    
    dotnet new -u Bet.Extension.Template.Console.DI.CSharp
```
## Resources for building DotNetCore Templating projects

- https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/
- 
Directory.Packages.props

```xaml
<Project>
    <!-- https://github.com/microsoft/MSBuildSdks/blob/master/src/CentralPackageVersions/README.md-->
    <ItemGroup>
        <PackageVersion Include="Microsoft.NET.Test.Sdk" Version="16.7.1" />
        <PackageVersion Include="xunit" Version="2.4.1" />
        <PackageVersion Include="xunit.runner.visualstudio" Version="2.4.3" />
        <PackageVersion Include="coverlet.collector" Version="1.3.0" />
    </ItemGroup>
</Project>
```

Directory.Build.props

```xml
   <PropertyGroup>
     <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>
```
