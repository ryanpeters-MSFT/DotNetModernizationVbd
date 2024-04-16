# .NET SDK CLI and Tooling

.NET Core includes a completely new set of tooling for building, running, managing, and publishing apps. It is cross-platform and is included as part of the .NET SDK. 

## Major Features

The .NET CLI (Command-Line Interface) and MSBuild are both powerful tools in the .NET ecosystem, each with its strengths and capabilities. Here are some major features that the .NET CLI offers that are not directly available in MSBuild:

- **Cross-Platform Support** - The .NET CLI is designed to be cross-platform, meaning you can use it on Windows, macOS, and Linux environments seamlessly. This makes it ideal for developers working on different operating systems.

- **Unified Command-Line Interface** - The .NET CLI provides a unified interface for various tasks such as project creation (`dotnet new`), building (`dotnet build`), running (`dotnet run`), testing (`dotnet test`), publishing (`dotnet publish`), package management (`dotnet add package`), and more. This unified experience simplifies development workflows.

- **Project File Simplification** - With the introduction of SDK-style projects, the .NET CLI uses simplified project files (e.g., `.csproj` for SDK-style projects) compared to the XML-based project files used in MSBuild. This simplification reduces the complexity of project configurations.

- **Built-in Testing and Publishing** - The .NET CLI includes built-in commands for testing (`dotnet test`) and publishing (`dotnet publish`) projects. This makes it convenient to run tests and package applications for deployment without additional setup.

- **Global Tools** - The .NET CLI supports global tools, which are .NET Core/.NET 5+ console applications that can be installed and run from the command line. This feature allows developers to extend the CLI's functionality with custom tools and utilities.

- **.NET Core/.NET 5+ Projects** - The .NET CLI is primarily designed for .NET Core and .NET 5+ projects, which are modular, cross-platform, and optimized for modern development scenarios. It provides features specific to these project types, such as cross-platform building and publishing.

- **Package Management** - While MSBuild also support package management, the .NET CLI has a more streamlined approach with commands like `dotnet add package` for adding NuGet packages to projects. It integrates seamlessly with NuGet, the package manager for .NET.

- **Container Support** The .NET CLI has built-in support for containerization, allowing developers to create Docker containers for .NET applications using commands like `dotnet publish -c Release -o out --self-contained -r linux-x64` to publish a self-contained application for Linux.

## Sample Commands

List all commands available using the `-h` flag. There are MANY commands and optional flags available, so only a handful of common commands are demonstrated here.

*Note: be sure to use the `-h` flag on all subcommands*

```powershell
dotnet [subcommand] -h
```

### [Creating](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

`dotnet new [subcommand]`

There are many native templates, which are available using the `dotnet new list` command. By default, if `dotnet new <project-type>` is used, it will be created in either the current directory (e.g., *console* applications) or in a sub-directory (e.g., *webapi*, *mvc*), unless the `-n` (name) and/or `-o` (output directory) flags are included.

To view a list of the installed work templates, the `dotnet new list` command can be invoked. The *Short Name* value listed is used to create a new project.

```powershell
# create a new console application called MyConsoleApp and place it in directory ThisIsMyProjectFolder
dotnet new console -n MyConsoleApp -o ThisIsMyProjectFolder
```

### [Building](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build)

```powershell
# build a project within a folder
dotnet build

# build for a Release configration and target linux
dotnet build .\project.csproj -c Release --os linux
```

### [Running](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-run)

```powershell
# run (and build) a project within a folder
dotnet run

# optionally, with command line arguments
dotnet run "MyVariable=hello"
```
### [Publishing](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish)

```shell
# create a web API project
dotnet new webapi -n TestApi

# publish to a folder (a build also occurs)
dotnet publish .\TestApi\TestApi.csproj -o .\output -c Release
```

### [Tool Installation](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install)

You can use the `dotnet tool install` command to install various tools, either globally or locally, as nuget packages.

```shell
# install the upgrade assistant globally (use -g)
dotnet tool install -g upgrade-assistant

# list the tools installed globally
dotnet tool list -g
```

Tools can be installed locally as well, but requires additional setup:

```shell
# list the tools currently installed locally
dotnet tool list

# install the manifest configuration file to track the installed tool(s)
dotnet new tool-manifest

# install the tool
dotnet tool install upgrade-assistant

# run the local tool (note the dotnet command prefix)
dotnet tool run upgrade-assistant
```