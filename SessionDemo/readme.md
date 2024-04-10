# Session Demo

TBD

## Note on `BinaryFormatter`

Some examples may use `BinaryFormatter` for serialization and deserialization, but it is **[now considered obsolete and should not be used](https://aka.ms/binaryformatter)** due to several vulnerabilities related to deserialization. The recommended approach is to use:

- [`XmlSerializer`](https://learn.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer)
- [`DataContractSerializer`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer)
- [`BinaryReader`](https://learn.microsoft.com/en-us/dotnet/api/system.io.binaryreader) or [`BinaryWriter`](https://learn.microsoft.com/en-us/dotnet/api/system.io.binarywriter)
- [`System.Text.Json`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json)