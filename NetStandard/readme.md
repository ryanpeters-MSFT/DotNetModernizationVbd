# .NET Standard Specification

During the "growing pains" of migrating applications from .NET Framework to "Core", and because the APIs were both similar, yet different (in terms of location and namespace in most cases), a specfication called **.NET Standard** was created to ease migration by allowing code interopability between Framework and Core for a subset of available APIs. 

In short, .NET Standard is not a version of runtime or SDK, but rather a specification, relying on special "links" between assemblies used by the runtime to 