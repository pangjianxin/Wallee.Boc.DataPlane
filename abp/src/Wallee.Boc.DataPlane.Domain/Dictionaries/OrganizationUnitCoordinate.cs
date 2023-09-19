using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Dictionaries
{
    /// <summary>
    /// 机构坐标
    /// </summary>
    public class OrganizationUnitCoordinate : AggregateRoot<Guid>
    {
        /// <summary>
        /// 机构名
        /// </summary>
        public string OrgName { get; set; } = default!;
        /// <summary>
        /// 机构号
        /// </summary>
        public string OrgNo { get; private set; } = default!;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; private set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; private set; }
        /// <summary>
        /// 地区区划
        /// </summary>
        public string RegionCode { get; private set; } = default!;

        protected OrganizationUnitCoordinate()
        {
        }

        public OrganizationUnitCoordinate(
            Guid id,
            string orgName,
            string orgNo,
            double latitude,
            double longitude,
            string regionCode
        ) : base(id)
        {
            OrgName = orgName;
            OrgNo = orgNo;
            Latitude = latitude;
            Longitude = longitude;
            RegionCode = regionCode;
        }
    }
}
