using HrManagement.Domain.Services.ThirdPartyServices.Medical;
using HrManagement.Domain.ViewModels.ThirdPartyServices.Medical;
using HrManagement.Security.ManagementRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace HrManagement.WebApplication.Pages.Company.MedicalClinic
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class HomeModel : PageModel
    {
        private readonly IMedicalClinicService _medicalClinicService;

        public HomeModel(IMedicalClinicService medicalClinicService)
        {
            _medicalClinicService = medicalClinicService;
        }

        private const int PAGE_SIZE = 7;
        private const int FIRST_PAGE = 1;

        [BindProperty]
        public IPagedList<MedicalClinicModel> MedicalClinics { get; set; }

        public void OnGet(int? pageNumber, string searchString)
        {
            var users = _medicalClinicService.GetAll().OrderBy(u => u.Name).ToList();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(x => x.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            MedicalClinics = users.ToPagedList(pageNumber ?? FIRST_PAGE, PAGE_SIZE);
        }
    }
}
