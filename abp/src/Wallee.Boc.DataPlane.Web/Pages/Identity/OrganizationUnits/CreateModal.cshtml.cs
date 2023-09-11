using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits;
using Wallee.Boc.DataPlane.Identity.OrganizationUnits.Dtos;

namespace Wallee.Boc.DataPlane.Web.Pages.Identity.OrganizationUnits
{
    public class CreateModalModel : DataPlanePageModel
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        [BindProperty]
        public OrganizationUnitCreateViewModel ViewModel { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public Guid? ParentId { get; set; }

        public CreateModalModel(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }
        public void OnGet()
        {
            ViewModel = new OrganizationUnitCreateViewModel
            {
                ParentId = ParentId
            };
        }

        public async Task OnPostAsync()
        {
            var dto = ObjectMapper.Map<OrganizationUnitCreateViewModel, OrganizationUnitCreateDto>(ViewModel);
            await _organizationUnitAppService.CreateAsync(dto);
        }
    }

    public class OrganizationUnitCreateViewModel: ExtensibleObject
    {
        [Required]
        [Display(Name = "机构名称")]
        [DynamicStringLength(typeof(OrganizationUnitConsts), nameof(OrganizationUnitConsts.MaxDisplayNameLength))]
        public string DisplayName { get; set; } = default!;

        [HiddenInput]
        public Guid? ParentId { get; set; }
    }
}
