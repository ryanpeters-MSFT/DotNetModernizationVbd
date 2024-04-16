# Session in .NET Core

Changes to session management in .NET Core were necessary primarily due to the evolving landscape of cloud adoption and the increasing prevalence of distributed applications. Here's a summary of why these changes were needed:

1. **Cloud Adoption** - With more applications moving to cloud environments, traditional in-memory session management became less feasible. Cloud-based deployments often involve scaling out to multiple servers or containers, requiring session data to be shared and synchronized across instances.

2. **Distributed Applications** - Modern applications are often distributed across multiple servers, data centers, or even regions. In such scenarios, centralized session management is essential for maintaining user sessions and ensuring a seamless experience regardless of the server handling the request.

3. **Scalability and High Availability** - Distributed session stores, such as Redis or SQL Server, offer scalability and high availability benefits. They allow session data to be stored externally, making it accessible from any server in the application's infrastructure. This is crucial for scaling applications horizontally and ensuring fault tolerance.

4. **Flexibility and Extensibility** - .NET Core's revamped session management system provides greater flexibility and extensibility compared to the monolithic session handling in .NET Framework. Developers can easily integrate different session stores or even create custom providers to suit their specific needs.

## Comparison of Session between Framework and Core


| Aspect                      | .NET Core                                    | .NET Framework                                |
|-----------------------------|----------------------------------------------|-----------------------------------------------|
| Session Management          | Uses the `ISession` interface for session management. Sessions are stored in memory by default but can be configured to use different storage providers like cookies, distributed caches, or custom providers. | Relies on the `HttpSessionState` object for session management. Sessions are typically stored in-process by default, but can also use out-of-process or SQL Server storage modes. |
| Serialization Requirement   | Session data needs to be serializable because .NET Core supports distributed session stores, where session data is stored externally (e.g., in a distributed cache or a database). | Session data should also be serializable in .NET Framework for scenarios where out-of-process or SQL Server session state modes are used. However, this requirement is more critical in .NET Core for distributed session stores. |
| Importance of Serialization | Serialization ensures that session data can be serialized and deserialized efficiently, allowing it to be stored and retrieved from distributed session stores without losing data integrity or causing compatibility issues. | Serialization is essential in distributed environments to ensure that session data can be shared across multiple instances of an application without losing state information or encountering serialization errors. |
| Compatibility with Stores    | Supports various storage providers for sessions, such as in-memory, cookies, distributed caches (e.g., Redis, SQL Server), or custom providers. | Offers multiple session state modes, including in-process, out-of-process (using a state server or SQL Server), or custom providers. However, out-of-process modes may require additional configuration for serialization and compatibility with distributed session stores. |

In summary, both .NET Core and .NET Framework require session data to be serializable, especially for scenarios involving distributed session stores. However, .NET Core places a greater emphasis on serialization due to its native support for distributed session stores and the need for efficient serialization/deserialization processes to maintain session state across multiple instances of an application.

## Serialization

In .NET Core, there are several ways to serialize and deserialize data for session management:

1. **JSON Serialization** - JSON serialization (using libraries like `System.Text.Json` or `Newtonsoft.Json`) converts session objects into JSON format, which is human-readable and widely supported. This method is efficient for storing complex data structures and is commonly used in web applications.

2. **Binary Serialization** - Binary serialization (using `BinaryFormatter` *(see below)* or `Protobuf`) converts session objects into binary format, which is more compact and efficient but not human-readable. Binary serialization is suitable for performance-critical scenarios and when data size needs to be minimized.

3. **XML Serialization** - XML serialization (using `XmlSerializer`) converts session objects into XML format, which is structured and self-descriptive but can be more verbose compared to JSON or binary. XML serialization is useful when interoperability with other systems or legacy applications is required.

4. **Custom Serialization** - Developers can implement custom serialization logic by implementing the `ISerializable` interface or using custom serialization/deserialization methods. This approach provides flexibility in handling specific data formats or incorporating encryption/compression techniques into the serialization process.

5. **Session State Providers** - .NET Core also provides built-in session state providers, such as `DistributedMemoryCache`, `DistributedSqlServerCache`, and `DistributedRedisCache`, which handle serialization and deserialization of session data automatically based on the configured provider. These providers abstract away the serialization details and offer distributed storage capabilities for session management in distributed environments.

Each serialization method has its advantages and considerations based on factors like data complexity, performance requirements, interoperability needs, and storage efficiency. Developers can choose the appropriate serialization approach based on the specific requirements of their application and the underlying session storage mechanism.

## Note on `BinaryFormatter`

Some examples may use `BinaryFormatter` for serialization and deserialization, but it is **[now considered obsolete and should not be used](https://aka.ms/binaryformatter)** due to several vulnerabilities related to deserialization. The recommended approach is to use:

- [`XmlSerializer`](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer)
- [`DataContractSerializer`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer)
- [`BinaryReader`](https://learn.microsoft.com/en-us/dotnet/api/system.io.binaryreader) or [`BinaryWriter`](https://learn.microsoft.com/en-us/dotnet/api/system.io.binarywriter)
- [`System.Text.Json`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json)