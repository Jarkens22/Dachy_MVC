using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dachy.Models.ViewModels
{
    public class RoleManagmentViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }

    }
}
