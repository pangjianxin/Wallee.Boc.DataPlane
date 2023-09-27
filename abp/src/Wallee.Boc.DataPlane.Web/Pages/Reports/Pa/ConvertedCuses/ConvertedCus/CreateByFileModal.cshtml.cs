using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;
using Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus.ViewModels;

namespace Wallee.Boc.DataPlane.Web.Pages.Reports.Pa.ConvertedCuses.ConvertedCus
{
    public class CreateByFileModalModel : DataPlanePageModel
    {
        private readonly IConvertedCusAppService _convertedCusAppService;

        [BindProperty]
        public CreateConvertedCusByFileViewModel ViewModel { get; set; } = default!;
        public CreateByFileModalModel(IConvertedCusAppService convertedCusAppService)
        {
            _convertedCusAppService = convertedCusAppService;
        }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            CreateUpdateConvertedCusByFileDto dto = new() { File = ViewModel.File };

            await _convertedCusAppService.CreateByFileAsync(dto);
        }
    }
}
