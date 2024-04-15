# Authentication

When migrating from .NET Framework to .NET Core, authentication and authorization mechanisms have undergone significant changes. These changes are aimed at providing a more modern and flexible approach to security while aligning with the principles of .NET Core's cross-platform and modular architecture.

## Changes in Authentication and Authorization

### Unified Identity Framework

- In .NET Core, Microsoft introduced a unified identity framework called ASP.NET Core Identity, which provides a robust set of features for managing user authentication, authorization, and identity-related tasks.
- ASP.NET Core Identity replaces the previous membership system used in ASP.NET Framework, providing a more modern and customizable solution.

### Decoupling from System.Web
- .NET Core removes dependencies on System.Web, which was heavily used for authentication and authorization in .NET Framework.
- Instead, .NET Core utilizes middleware components and modular libraries for implementing authentication and authorization, resulting in a lighter and more flexible approach.

### Middleware-based Approach
- Authentication and authorization in .NET Core are implemented using middleware components, allowing for greater control and customization in the request pipeline.
- Middleware components like `UseAuthentication()` and `UseAuthorization()` are used to enable authentication and authorization respectively in the ASP.NET Core application pipeline.

## Modes of Authentication and Authorization in .NET Core

### Cookie Authentication
- This mode relies on encrypted cookies to authenticate users. It's commonly used for web applications where users log in with a username and password.
- ASP.NET Core provides built-in support for cookie authentication through middleware components.
- Is the replacement for Forms Authentication in .NET Framework

### JWT (JSON Web Tokens) Authentication
- JWT authentication is popular for securing Web APIs. It involves generating a token containing user claims, which is then sent with each request for authentication.
- .NET Core supports JWT authentication through middleware components or third-party libraries like Microsoft.AspNetCore.Authentication.JwtBearer.

### OAuth and OpenID Connect
- .NET Core supports OAuth 2.0 and OpenID Connect protocols for authentication with external identity providers like Google, Facebook, or Azure Active Directory.
- Libraries like IdentityServer4 provide a comprehensive implementation of OAuth and OpenID Connect for building custom authentication and authorization servers.

### Authorization Policies
- .NET Core introduces a flexible policy-based authorization system where you define authorization rules using policy requirements and handlers.
- Policies can be applied at the controller, action, or method level, allowing fine-grained control over access to resources.

### Role-based and Claims-based Authorization
- .NET Core supports both role-based and claims-based authorization. Role-based authorization assigns users to predefined roles, while claims-based authorization evaluates user claims to determine access rights.
- ASP.NET Core Identity integrates seamlessly with role-based authorization, providing a straightforward way to manage user roles and permissions.

## Examples

- **[MVC Cookie Authentication](./Cookie/)** - Basic example of using cookie authentication against a static credential
- **[Web API with JWT](./JWT/)** - Uses a JWT tokent to authenticate against a web API