using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IdentityApp.Authorization
{
    public class InvoiceCreatorAuthorizationHandler:
        AuthorizationHandler<OperationAuthorizationRequirement,Invoice>
    {
        UserManager<ApplicationUser> _UserManager;
        public InvoiceCreatorAuthorizationHandler(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, Invoice invoice)
        {
            if(context.User == null || invoice == null)

                return Task.CompletedTask;

            if(requirement.Name != Constants.CreateOperationName && requirement.Name != Constants.ReadOperationName
                && requirement.Name != Constants.UpdateOperationName && requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            if (invoice.CreatorId == _UserManager.GetUserId(context.User))
                context.Succeed(requirement);

            return Task.CompletedTask;

        }
    }
}
