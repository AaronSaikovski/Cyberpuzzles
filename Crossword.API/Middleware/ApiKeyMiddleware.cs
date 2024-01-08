//Ref: https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/

using Crossword.Shared.Constants;

namespace Crossword.API;

public class ApiKeyMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context) {
        if (!context.Request.Headers.TryGetValue(ApiConstants.ApiKeyName, out
                var extractedApiKey)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided ");
            return;
        }
        var appSettings = context.RequestServices.GetRequiredService < IConfiguration > ();
        var apiKey = appSettings.GetValue < string > (ApiConstants.ApiKeyName);
        if (apiKey is not null && !apiKey.Equals(extractedApiKey)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized API Request.");
            return;
        }
        await next(context);
    }
}



// using Crossword.Shared.Constants;
//
// namespace Crossword.API;
//
// public class ApiKeyMiddleware {
//     private readonly RequestDelegate _next;
//     public ApiKeyMiddleware(RequestDelegate next) {
//         _next = next;
//     }
//     public async Task InvokeAsync(HttpContext context) {
//         if (!context.Request.Headers.TryGetValue(APIConstants.ApiKeyName, out
//                 var extractedApiKey)) {
//             context.Response.StatusCode = 401;
//             await context.Response.WriteAsync("Api Key was not provided ");
//             return;
//         }
//         var appSettings = context.RequestServices.GetRequiredService < IConfiguration > ();
//         var apiKey = appSettings.GetValue < string > (APIConstants.ApiKeyName);
//         if (apiKey is not null && !apiKey.Equals(extractedApiKey)) {
//             context.Response.StatusCode = 401;
//             await context.Response.WriteAsync("Unauthorized API Request.");
//             return;
//         }
//         await _next(context);
//     }
// }