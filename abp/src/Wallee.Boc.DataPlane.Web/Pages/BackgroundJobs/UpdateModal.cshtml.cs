using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Web.Pages.BackgroundJobs
{
    public class UpdateModalModel : DataPlanePageModel
    {
        private readonly IBackgroundJobAppService _backgroundJobAppService;

        [BindProperty(SupportsGet = true)]
        [HiddenInput]
        public Guid Id { get; set; }

        [BindProperty]
        public UpdateBackgroundJobViewModel ViewModel { get; set; } = default!;

        public UpdateModalModel(IBackgroundJobAppService backgroundJobAppService)
        {
            _backgroundJobAppService = backgroundJobAppService;
        }

        public void OnGet()
        {
            ViewModel = new UpdateBackgroundJobViewModel
            {
                NextTryTime = Clock.Now,
            };
        }

        public async Task OnPostAsync()
        {
            var dto = new BackgroundJobUpdateDto { NextTryTime = ViewModel.NextTryTime };
            await _backgroundJobAppService.UpdateAsync(Id, dto);
        }
    }

    public class UpdateBackgroundJobViewModel
    {
        [Required]
        [Display(Name = "下次重试时间")]
        public DateTime NextTryTime { get; set; }
    }
}
