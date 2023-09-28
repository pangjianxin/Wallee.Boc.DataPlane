using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses
{
    /// <summary>
    /// 客户机构调整
    /// </summary>
    public class CusOrgAdjusment : AggregateRoot
    {
        public CusOrgAdjusment(string cusidt, string orgidt)
        {
            Cusidt = cusidt;
            Orgidt = orgidt;
        }
        protected CusOrgAdjusment() { }
        public string Cusidt { get; private set; } = default!;
        public string Orgidt { get; private set; } = default!;
        public override object[] GetKeys()
        {
            return new object[]
            {
                Cusidt
            };
        }
    }
}
