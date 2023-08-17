using System;
using System.Collections.Generic;
using System.Text;
using Wallee.Boc.DataPlane.Localization;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane;

/* Inherit your application services from this class.
 */
public abstract class DataPlaneAppService : ApplicationService
{
    protected DataPlaneAppService()
    {
        LocalizationResource = typeof(DataPlaneResource);
    }
}
