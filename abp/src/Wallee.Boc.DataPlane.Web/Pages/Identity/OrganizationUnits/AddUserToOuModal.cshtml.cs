using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.OrganizationUnits;
using Wallee.Boc.DataPlane.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane.Web.Pages.Identity.OrganizationUnits
{
    public class AddUserToOuModalModel : DataPlanePageModel
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        [BindProperty(SupportsGet = true)]
        public Guid OrganizationUnitId { get; set; }
        [BindProperty]
        public OrganizationUnitDto? OrganizationUnit { get; set; }
        public AddUserToOuModalModel(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }
        public async Task OnGetAsync()
        {
            OrganizationUnit = await _organizationUnitAppService.GetAsync(OrganizationUnitId);
        }
    }
}
