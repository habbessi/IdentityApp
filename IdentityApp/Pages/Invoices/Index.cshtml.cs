using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Authorization;

namespace IdentityApp.Pages.Invoices
{
   
    public class IndexModel : DI_BasePageModel
    {

        public IndexModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager) :
            base(context, authorizationService, userManager)
        {

        }

        public IList<Invoice> Invoice { get;set; }

        public async Task OnGetAsync()
        {

            var invoices = from i in Context.Invoice select i;

            var currentUser = UserManager.GetUserId(User);

            var isManager = User.IsInRole(Constants.InvoiceManagersRole);
            var isAdmin = User.IsInRole(Constants.InvoiceAdminsRole);

            if (isManager == false && isAdmin == false)
            {
                invoices = invoices.Where(i => i.CreatorId == currentUser);
            }

            Invoice = await invoices.ToListAsync();

            //Invoice = await Context.Invoice
            //.Where(m => m.CreatorId == currentUser)
            //.ToListAsync();
        }
    }
}
