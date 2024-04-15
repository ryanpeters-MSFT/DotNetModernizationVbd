# Cookie Authentication

Cookie Authentication in .NET Core is a mechanism that serializes user details in the form of claims into an encrypted cookie. This cookie is then sent back to the server on subsequent requests, which gets validated to recreate the user object from claims and sets this user object in the HttpContext. This process is valid only for that request. 

To add cookie authentication, the Authentication Middleware services are added with the `AddAuthentication` and `AddCookie` methods. The `UseAuthentication` and `UseAuthorization` methods are then called to set the `HttpContext.User` property and run the Authorization Middleware for requests. These methods must be called before `Map` methods such as `MapRazorPages` and `MapDefaultControllerRoute`.

## Comparison to Forms Authentication in .NET Framework
Forms Authentication in .NET Framework is a ticket-based system. When a user logs in, they receive a basic user information ticket. Forms authentication maintains an authentication ticket in a cookie or the URL so that an authenticated user does not need to supply credentials with each request. To implement forms-based authentication, the authentication mode is changed to Forms in the `Web.config` file. The `<Forms>` tag is inserted and the appropriate attributes are filled. Access is denied to the anonymous user in the `<authorization>` section.

While both Cookie Authentication and Forms Authentication use cookies to maintain user sessions, they differ in their implementation and usage. Cookie Authentication in .NET Core is more flexible and can be used without ASP.NET Core Identity. On the other hand, Forms Authentication in .NET Framework is typically used with a database to store user details.

## Middleware in .NET Core
In .NET Core, the middleware is where the authentication process takes place. The Cookie Authentication Middleware sets up some default options and returns an `AuthenticationHandler` from the overloaded method `CreateHandler()`. This handler is where the authentication process occurs. The middleware sets the `AuthenticationScheme` to `CookieAuthenticationDefaults.AuthenticationScheme`, providing a value of "Cookies" for the scheme. The authentication cookie's `IsEssential` property is set to true by default.

## Example
The example application demonstrates the basic configuration needed to use cookie-based authentication. This example does not use any Identity components, but rather a simple `IAuthenticationService` service instance to get the information for the user from some other backend store. 