using HrManagement.Security.ManagementRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class PrivacyModel : PageModel
    {
        public PrivacyModel()
        {
        }

        public void OnGet()
        {
        }
    }
}