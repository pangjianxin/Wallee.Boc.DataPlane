using Volo.Abp.Content;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits.Dtos
{
    public class CreateUpdateConvertedCusOrgUnitByFileDto
    {
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
