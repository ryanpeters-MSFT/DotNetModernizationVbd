# Configuration and `IOptions<T>` Demo

This short demo outlines:

- Basic project structure for `dotnet new console`
- Adding configuration providers (in-memory, JSON, and INI files)
- Binding of settings to a typed `IOptions<T>` instance from multiple configuration provider sources, where `T` is a type that represents your configuration settings

## Configuration

In .NET Framework and .NET Core, configuration is handled differently due to the architectural and design differences between the two frameworks:

### .NET Framework Configuration:

- In .NET Framework, configuration settings are typically stored in XML-based configuration files, such as `web.config` for web applications or `app.config` for non-web applications.
- Configuration settings include application settings, connection strings, custom settings, and configuration sections for various components like ASP.NET, WCF, and more.
- Configuration settings can be accessed using the `ConfigurationManager` class and related APIs (`Configuration`, `ConfigurationSection`, `ConnectionStringSettings`, etc.).
- Configuration files can be modified manually or through tools like Visual Studio's project settings editor.
    
### .NET Core Configuration:
  
- In .NET Core, configuration is more flexible and can be stored in various formats, including JSON, XML, INI, environment variables, command-line arguments, and Azure Key Vault.
- The most common format for configuration in .NET Core is JSON, using files like `appsettings.json` or environment-specific files like `appsettings.Production.json`.
- Configuration settings are accessed using the `IConfiguration` interface, which is part of the Microsoft.Extensions.Configuration namespace.
- Configuration settings are typically loaded and managed through the `ConfigurationBuilder` class, which reads configuration sources and builds the configuration object.
- .NET Core provides a hierarchy for configuration sources, allowing settings to be overridden or merged from multiple sources based on precedence rules.

Overall, .NET Core's approach to configuration is more modern, modular, and adaptable to different deployment environments, compared to the more rigid XML-based configuration system of .NET Framework.

Despite the differences, there is still optional support for legacy configuration management via the **System.Configuration.ConfigurationManager** nuget package, which allows for configuration using the `web.config` or `app.config` files.

## Order of Precedence

In .NET Core, the configuration sources are read in the following order:

1. **appsettings.json**: These are the default settings for the application.
2. **appsettings.{Environment}.json**: These are environment specific settings. The `{Environment}` placeholder is replaced by the current hosting environment name. For example, if the environment is `Development`, it will look for `appsettings.Development.json`. These settings override the ones in `appsettings.json`.
3. **Secret Manager** (only in development): This stores sensitive data during the development process. It overrides the previous settings.
4. **Environment variables**: These are system-wide environment variables. They override the previous settings.
5. **Command-line arguments**: These are passed when the application is started and they override all previous configuration sources.

This order ensures that the configuration is layered, allowing certain sources to override others. For example, environment variables can be used to override settings for a production deployment without changing the code or the `appsettings.json` files. Similarly, command-line arguments can be used for one-time changes without affecting the overall configuration. 

The last configuration source specified "wins" if there are duplicate settings. For example, if both `appsettings.json` and an environment variable provide a setting for the same key, the value from the environment variable is used. 