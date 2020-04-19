![.NET Core](https://github.com/ankitvijay/DeveloperExceptionJsonResponse/workflows/.NET%20Core/badge.svg?branch=master)

# Developer Exception Json Response Middleware
Returns exceptions in form of JSON response for ASP.NET Core Web API.

**Usage**

To use the middleware in development environment, update your `Configure` method of `Startup` `class` as below:

````
if (env.IsDevelopment())
{
  app.UseDeveloperExceptionJsonResponse();
}
````