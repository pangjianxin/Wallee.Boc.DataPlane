using System;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Wallee.Boc.DataPlane.Identity
{
    public static class OrganizationUnitExtaPropertiesExtensions
    {
        public static string GetOrgNo(this OrganizationUnit ou)
        {
            if (ou == null)
            {
                throw new ArgumentException(null, nameof(ou));
            }
            return ou.GetProperty<string>("OrgNo");
        }
    }
}
