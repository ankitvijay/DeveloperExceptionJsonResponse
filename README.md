![.NET Core](https://github.com/ankitvijay/HttpMiddlewareExtensions/workflows/.NET%20Core/badge.svg?branch=master)

# DeveloperExceptionMiddlewareExtensions
Developer Exception Middleware Extensions for ASP.NET Core applications to return JSON response to the Htto Client.


**Usage**

Add following line to your `Configure` method to add the middleware in your `Development` environment.

````
if (env.IsDevelopment())
{
  app.UseDeveloperExceptionResponse();
}
````
