# Bet.Extensions.Templating Projects

[![GitHub license](https://img.shields.io/badge/license-Apache-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Templating/master/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/14436be6chnyk9dh/branch/master?svg=true)](https://ci.appveyor.com/project/kdcllc/bet-extensions-templating/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Bet.Extension.Template.Console.DI.CSharp.svg)](https://www.nuget.org/packages?q=Bet.Extension.Template.Console.DI.CSharp)
![Nuget](https://img.shields.io/nuget/dt/Bet.Extension.Template.Console.DI.CSharp)


> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

`Bet.Extensions.Templating Projects` provides with DotNetCore Dependency Injection for Console Applications and include:

- One Logging provider for startup and runnable application
- New C# 9.0 `Program.cs` syntax
- Dependency Injection with Configurations

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```bash
    dotnet new --install Bet.Extension.Template.Console.DI.CSharp::1.0.0
```

Installing from nuget package

```bash
    # build 
    dotnet build -c Release
    dotnet pack -c Release -o packages
    dotnet new -i packages\Bet.Extension.Template.Console.DI.CSharp.1.0.0-preview1.nupkg --debug:reinit
    
    # uninstall    
    dotnet new -u Bet.Extension.Template.Console.DI.CSharp
```

## Resources for building DotNetCore Templating projects

- https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates
- https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/
- https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-template-pack
- https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template
- https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new#options

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
