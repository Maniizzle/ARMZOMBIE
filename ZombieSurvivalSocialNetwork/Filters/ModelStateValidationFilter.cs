using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Wrappers;

namespace ZombieSurvivalSocialNetwork.Filters
{
    public class ModelStateValidationFilter:ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    var modelStateErrors = context.ModelState.Values.SelectMany(a => a.Errors).Select(e => e.ErrorMessage);
                    modelStateErrors = modelStateErrors.Where(error => !string.IsNullOrEmpty(error));
                    var response = new Response<IEnumerable<string>> { Data= null, Errors= modelStateErrors.ToList(), Message= modelStateErrors.FirstOrDefault(), Succeeded=false };
                    context.Result = new BadRequestObjectResult(response);
                }
            }
    }
}
