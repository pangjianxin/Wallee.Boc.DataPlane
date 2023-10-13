namespace Wallee.Boc.DataPlane.Permissions;

public static class DataPlanePermissions
{
    public const string GroupName = "DataPlane";

    public static class Settings
    {
        public const string Default = GroupName + ".Settings";
    }

    public static class BackgroundJobs
    {
        public const string Default = GroupName + ".BackgroundJobs";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Operation = Default + ".Operation";
    }
    public class OrganizationUnits
    {
        public const string Default = GroupName + ".OrganizationUnit";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
        public const string ManageRoles = Default + ".ManageRoles";
        public const string ManageUsers = Default + ".ManageUsers";
    }

    public class TDcmpReports
    {
        public const string Default = GroupName + ".TDcmpReports";
        public const string CcicBasic = Default + ".CcicBasic";
        public const string CcicAddress = Default + ".CcicAddress";
        public const string CcicAntiMoneyLaundering = Default + ".CcicAntiMoneyLaundering";
        public const string CcicCustomerTypeOrg = Default + ".CcicCustomerTypeOrg";
        public const string CcicGeneralOrg = Default + ".CcicGeneralOrg";
        public const string CcicId = Default + ".CcicId";
        public const string CcicName = Default + ".CcicName";
        public const string CcicPersonalRelation = Default + ".CcicPersonalRelation";
        public const string CcicPhone = Default + ".CcicPhone";
        public const string CcicPractice = Default + ".CcicPractice";
        public const string CcicRegister = Default + ".CcicRegister";
        public const string CcicSignOrg = Default + ".CcicSignOrg";
        public const string CcicCustomerType = Default + ".CcicCustomerType";
    }

    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public class WorkFlows
    {
        public const string Default = GroupName + ".WorkFlows";
        public const string CcicCusInfo = Default + ".CcicCusInfo";
    }

    public class Dictionaries
    {
        public const string Default = GroupName + ".Dictionaries";
        public const string OrganizationUnitCoordinate = Default + ".OrganizationUnitCoordinate";
        public const string OrgUnitHierarchy = Default + ".OrgUnitHierarchy";

    }
    public class Reports
    {
        public const string Defaults = GroupName + ".Reports";
        public const string ConvertedCusOrgUnit = Defaults + ".ConvertedCusOrgUnit";
        public const string ConvertedCus = Defaults + ".ConvertedCus";
        public const string CusOrgAdjusment = Defaults + ".CusOrgAdjusment";
    }

    public class Dashboard
    {
        public const string Default = GroupName + ".Dashborad";
        public const string ConvertedCusOrgUnit = Default + ".ConvertedCusOrg";
    }

}
