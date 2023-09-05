namespace Wallee.Boc.DataPlane.Permissions;

public static class DataPlanePermissions
{
    public const string GroupName = "DataPlane";

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
    /// <summary>
    /// 对公客户基础信息
    /// </summary>
    public class CcicBasic
    {
        public const string Default = GroupName + ".CcicBasic";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class CcicAddress
    {
        public const string Default = GroupName + ".CcicAddress";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public class TDcmpWorkFlow
    {
        public const string Default = GroupName + ".TDcmpWorkFlow";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
