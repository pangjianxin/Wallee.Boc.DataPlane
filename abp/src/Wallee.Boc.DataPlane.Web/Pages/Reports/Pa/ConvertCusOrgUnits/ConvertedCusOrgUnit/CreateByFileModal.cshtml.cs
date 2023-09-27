using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertCusOrgUnits.ConvertedCusOrgUnit.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertCusOrgUnits.ConvertedCusOrgUnit
{
    public class CreateByFileModalModel : DataPlanePageModel
    {
        private readonly IConvertedCusOrgUnitAppService _convertedCusOrgUnitAppService;

        [BindProperty]
        public CreateConvertedCusOrgUnitByFileViewModel ViewModel { get; set; } = default!;
        public CreateByFileModalModel(IConvertedCusOrgUnitAppService convertedCusOrgUnitAppService)
        {
            _convertedCusOrgUnitAppService = convertedCusOrgUnitAppService;
        }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            CreateUpdateConvertedCusOrgUnitByFileDto dto = new() { File = ViewModel.File };

            await _convertedCusOrgUnitAppService.CreateByFileAsync(dto);
        }
    }
}
