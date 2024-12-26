using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace Cultura_New.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IRepositoryWrapper wrapper, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var accountId = jwtUtils.ValidateJwtToken(token);
            if (accountId != null)
            {
                //attach account to context on succesful jwt validation
                context.Items["Employee"] = (await wrapper.Employee.GetByIdWithToken(accountId.Value));
            }
            await _next(context);
        }
    }
}
