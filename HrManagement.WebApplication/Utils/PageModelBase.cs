using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Utils
{
    public class ModalPageModel : PageModel
    {
        [BindProperty]
        public bool SucessResult { get; set; } = false;
    }
}
