using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;


/// <summary>
/// 折效客户明细
/// </summary>
public interface IConvertedCusAppService :
    IReadOnlyAppService<
        ConvertedCusDto,
        ConvertedCusKey,
        ConvertedCusGetListInput>
{
    Task CreateByFileAsync(CreateUpdateConvertedCusByFileDto input);
}