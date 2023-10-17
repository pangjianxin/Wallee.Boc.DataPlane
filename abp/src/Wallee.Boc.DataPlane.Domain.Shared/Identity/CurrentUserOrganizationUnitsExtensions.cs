using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Users;

namespace Wallee.Boc.DataPlane.Identity
{

    public static class CurrentUserOrganizationUnitsExtensions
    {
        public static Guid[] FindOrganizationUnits([NotNull] this ICurrentUser currentUser)
        {
            var organizationUnits = currentUser.FindClaims(AbpOrganizationUnitClaimTypes.OrganizationUnitCode);
            if (organizationUnits.IsNullOrEmpty())
            {
                return new Guid[0];
            }

            var userOus = new List<Guid>();

            foreach (var userOusClaim in organizationUnits)
            {
                if (Guid.TryParse(userOusClaim.Value, out var guid))
                {
                    userOus.Add(guid);
                }
            }

            return userOus.ToArray();
        }
    }
}
