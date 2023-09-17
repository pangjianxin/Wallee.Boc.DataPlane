using Volo.Abp.Content;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos
{
    public class CreateUpdateConvertedCusOrgUnitByFileDto
    {
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
