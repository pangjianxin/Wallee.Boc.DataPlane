using Volo.Abp.Content;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos
{
    public class CreateUpdateConvertedCusByFileDto
    {
        public IRemoteStreamContent File { get; set; } = default!;
    }
}
