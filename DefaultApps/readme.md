# Default App Demos

This directory contains a couple, commonly-used application templates - MVC, Web API, and Console - each created with default configuration. In each (and effectively, all) .NET Core applications, there are some application-level changes that differ greatly from Framework, such as the new SDK-style project types that greatly simplify your project files to make them more readable to changes in how NuGet packages are simplified by using transitive references instead of having to explicitly define each (nested) dependency for a particular package.

## SDK Style Project Files

SDK-style projects are a new project format in .NET that simplifies the project file structure and makes it easier to work with. They are called "SDK-style" because they use the `Microsoft.NET.Sdk` in the project file. This format is more compact, human-readable, and has less clutter compared to the old `.csproj` or `.vbproj` formats. It also enables new features such as package reference and .NET Core support. SDK-style projects are the default for .NET Core and .NET 5 and later, but can also be used with .NET Framework.

**Sample .csproj file:**

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyProject\MyProject1.csproj" />
    <ProjectReference Include="..\MyProject.Services\MyProject.Services.csproj" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.4" />
  </ItemGroup>

</Project>
```

### Types of SDKs

In an SDK-style project, different SDKs are used to compile, pack, and publish code for different types of .NET applications. Here are some of the available SDKs:

- **Microsoft.NET.Sdk** - This is the base SDK for .NET. All other SDKs reference this, and projects associated with other SDKs have all the .NET SDK properties available to them.
- **Microsoft.NET.Sdk.Web** - This SDK is used for building web applications. It depends on both the .NET SDK and the Razor SDK.
- **Microsoft.NET.Sdk.BlazorWebAssembly** - This SDK is used for building Blazor WebAssembly applications.
- **Microsoft.NET.Sdk.Razor** - This SDK is used for building applications that use Razor.
- **Microsoft.NET.Sdk.Worker** - This SDK is used for building Worker Service applications.
- **Microsoft.NET.Sdk.WindowsDesktop** - This SDK, which includes Windows Forms (WinForms) and Windows Presentation Foundation (WPF), was used for building desktop applications. However, starting in .NET 5, Windows Forms and WPF projects should specify the .NET SDK (`Microsoft.NET.Sdk`) instead.

## NuGet Packages

In .NET Core, NuGet package references are handled using the `PackageReference` format in the project file for SDK-style projects. This is a newer, more streamlined method of managing package dependencies directly within the project file. 

It allows for transitive package restore, meaning that if Package A depends on Package B, and your project depends on Package A, you don't need to explicitly reference Package B. This is the default for .NET Core, .NET Standard, and UWP projects.

On the other hand, .NET Framework traditionally used a `packages.config` file to manage NuGet package references. This method requires explicit listing of all packages used in the project, including transitive dependencies. However, .NET Framework projects also now support `PackageReference`, but they currently default to `packages.config` if the SDK is not defined in the project file.

The shift to `PackageReference` in .NET Core represents a move towards more efficient and manageable dependency handling. It's worth noting that the `PackageReference` format can also be used in .NET Framework applications.
