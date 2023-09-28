using System;
using Volo.Abp.Content;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

[Serializable]
public class CreateUpdateCusOrgAdjusmentByFileDto
{
    public IRemoteStreamContent File { get; set; } = default!;
}