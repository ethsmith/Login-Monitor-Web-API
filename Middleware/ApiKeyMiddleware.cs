namespace LoginMonitorAPI.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _adminKey;
    private readonly string _userKey;
    
    public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _adminKey = config["ApiKeys:AdminKey"];
        _userKey = config["ApiKeys:UserKey"];
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("An API key is required to interact with this API.");
            return;
        }

        if (apiKey == _adminKey)
        {
            context.Items["Role"] = "Admin";
        } else if (apiKey == _userKey)
        {
            context.Items["Role"] = "User";
        } else
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Your provided API key is invalid.");
            return;
        }
        
        await _next(context);
    }
}