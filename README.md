# Bet.Extensions.Templating Projects

[![GitHub license](https://img.shields.io/badge/license-Apache-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.Extensions.Templating/master/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/14436be6chnyk9dh/branch/master?svg=true)](https://ci.appveyor.com/project/kdcllc/bet-extensions-templating/branch/master)
[![NuGet](https://img.shields.io/nuget/v/console.di.svg)](https://www.nuget.org/packages?q=console.di)
![Nuget](https://img.shields.io/nuget/dt/console.di)

> The second letter in the Hebrew alphabet is the ב bet/beit. Its meaning is "house". In the ancient pictographic Hebrew it was a symbol resembling a tent on a landscape.

`Bet.Extensions.Templating Projects` provides with DotNetCore Dependency Injection for Console Applications and include:

- One Logging provider for startup and runnable application
- New C# 10.0 `Program.cs` syntax
- Dependency Injection with Configurations

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```bash
    dotnet new --install console.di::2.0.1
```

## Developing the package

Installing from nuget package on local machine:

```bash
    # build
    dotnet build -c Release -p:Version=2.0.1-preview1
    dotnet pack -c Release -o packages -p:Version=2.0.1-preview1
    dotnet new -i packages\console.di.2.0.1-preview1.nupkg

    # uninstall
    dotnet new -u console.di
```

## Resources for building DotNetCore Templating projects

- https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates
- https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/
- https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-template-pack
- https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template
- https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new#options
- https://github.com/dotnet/dotnet-template-samples
