using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Volo.Abp;

namespace Wallee.Boc.DataPlane.Identity
{
    public static class AbpClaimOrganizationUnitsExtensions
    {
        public static Guid[] FindOrganizationUnits([NotNull] this ClaimsPrincipal principal)
        {
            Check.NotNull(principal, nameof(principal));

            var userOusOrNull = principal.Claims?.Where(c => c.Type == AbpOrganizationUnitClaimTypes.OrganizationUnitCode);
            if (userOusOrNull == null || !userOusOrNull.Any())
            {
                return new Guid[0];
            }

            var userOus = new List<Guid>();

            foreach (var userOusClaim in userOusOrNull)
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
