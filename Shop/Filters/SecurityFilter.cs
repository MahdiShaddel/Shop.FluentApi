using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Shop.Host.ApplicationServices.IServices;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Security;
using System.Linq;
using System.Net;

namespace Shop.Host.Filters
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly string Role;

        public SecurityFilter(string role)
        {
            Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool Result = false;
            context.HttpContext.Request.Headers
                .TryGetValue("Authorization", out StringValues authorizationHeader);
            string auth = authorizationHeader.ToString();
            if (string.IsNullOrEmpty(auth))
            {
                //TODO Message Move to Enum Description
                UnAuthorize(context);
            }
            else
            {
                //CheckTokenType
                if (auth.Contains("Bearer"))
                {
                    string token = auth.Replace("Bearer ", "");
                    //TokenValidation
                    var princpal = TokenValidator.Validate(token);
                    if (princpal != null)
                    {
                        string userId = princpal.Claims.Where(x => x.Type == "UserId")
                             .FirstOrDefault().Value;
                        if (!string.IsNullOrEmpty(userId))
                        {
                            var userContext = (IUserContext)context.HttpContext.RequestServices
                        .GetService(typeof(IUserContext));

                            userContext.UserId = userId;


                            var _applicationUserRepository = (IApplicationUserRepository)context.HttpContext.RequestServices
                        .GetService(typeof(IApplicationUserRepository));

                            var user = _applicationUserRepository.GetUserWithRolesByUserId(userId);

                            bool IsAccess = user.UserRoles.Any(x => x.Role.Name == Role);
                            if (IsAccess)
                            {
                                Result = IsAccess;
                            }
                        }
                    }

                }
                if (Result == false)
                {
                    UnAuthorize(context);
                }
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }

        private void UnAuthorize(ActionExecutingContext context)
        {
            context.Result = new JsonResult(new { HttpStatusCode = HttpStatusCode.Unauthorized, Message = "The security information entered is incorrect" });
        }
    }
}
