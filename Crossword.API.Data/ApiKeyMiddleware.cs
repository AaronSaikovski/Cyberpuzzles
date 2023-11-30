//Ref: https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/

using CyberPuzzles.Shared.Constants;

public class ApiKeyMiddleware {
    private readonly RequestDelegate _next;
    // private
    //     const string APIKEY = "XApiKey";
    public ApiKeyMiddleware(RequestDelegate next) {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context) {
        if (!context.Request.Headers.TryGetValue(CWSettings.APIKeyName, out
                var extractedApiKey)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided ");
            return;
        }
        var appSettings = context.RequestServices.GetRequiredService < IConfiguration > ();
        var apiKey = appSettings.GetValue < string > (CWSettings.APIKeyName);
        if (apiKey != null && !apiKey.Equals(extractedApiKey)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized API Request.");
            return;
        }
        await _next(context);
    }
}