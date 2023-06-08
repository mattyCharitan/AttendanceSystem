using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Repositories.Modules;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace API.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AttendanceContext context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> option, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, AttendanceContext dBContext) : base(option, logger, encoder, clock)
        {
            context = dBContext;
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No header found");

            var _haedervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_haedervalue.Parameter != null ? _haedervalue.Parameter : string.Empty);
            string credentials = Encoding.UTF8.GetString(bytes);
            if (!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string username = array[0];
                string password = array[1];
                var user = await this.context.UserAccounts.FirstOrDefaultAsync(item => item.Name == username && item.Password == password);
                if (user == null)
                    return AuthenticateResult.Fail("UnAuthorized");
                int id = user.UserId;
                UserRole role = await this.context.UserRoles.FirstOrDefaultAsync(role => role.UserId == id);
                
                var claim = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                if (role != null && role.Role == 1)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                if (Request.RouteValues.TryGetValue("userId", out var userIdRouteValue))
                {
                    int requestedUserId = Convert.ToInt32(userIdRouteValue);

                    // Check if the authenticated user is the same as the requested user
                    if (id != requestedUserId &&role.Role == 0)
                        return AuthenticateResult.Fail("Unauthorized");
                }


                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("UnAuthorized");

            }
        }
    }
}

