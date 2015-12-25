using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;

namespace IvoryPacket.Filters
{
    public class ValidateModel: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false) {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
