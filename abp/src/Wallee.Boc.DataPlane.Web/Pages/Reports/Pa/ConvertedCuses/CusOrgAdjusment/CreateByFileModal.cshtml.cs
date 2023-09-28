using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.CusOrgAdjusment.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.CusOrgAdjusment
{
    public class CreateByFileModalModel : DataPlanePageModel
    {
        private readonly ICusOrgAdjusmentAppService _cusOrgAdjusmentAppService;

        [BindProperty]
        public CreateEditCusOrgAdjusmentByFileViewModel ViewModel { get; set; } = default!;

        public CreateByFileModalModel(ICusOrgAdjusmentAppService cusOrgAdjusmentAppService)
        {
            _cusOrgAdjusmentAppService = cusOrgAdjusmentAppService;
        }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            var dto = new CreateUpdateCusOrgAdjusmentByFileDto { File = ViewModel.File };
            await _cusOrgAdjusmentAppService.CreateByFileAsync(dto);
        }

    }
}
