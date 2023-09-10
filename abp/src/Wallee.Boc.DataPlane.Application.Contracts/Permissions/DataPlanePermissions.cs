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
    /// <summary>
    /// 对公反洗钱信息    a02
    /// </summary>
    public class CcicAntiMoneyLaundering
    {
        public const string Default = GroupName + ".CcicAntiMoneyLaundering";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公客户类别信息-组织    a09
    /// </summary>
    public class CcicCustomerTypeOrg
    {
        public const string Default = GroupName + ".CcicCustomerTypeOrg";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公概况-组织    a18
    /// </summary>
    public class CcicGeneralOrg
    {
        public const string Default = GroupName + ".CcicGeneralOrg";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公证件信息    a20
    /// </summary>
    public class CcicId
    {
        public const string Default = GroupName + ".CcicId";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公隔离清单信息    a82
    /// </summary>
    public class CcicLsolationList
    {
        public const string Default = GroupName + ".CcicLsolationList";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公名称信息    a22
    /// </summary>
    public class CcicName
    {
        public const string Default = GroupName + ".CcicName";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公人员关系    a24
    /// </summary>
    public class CcicPersonalRelation
    {
        public const string Default = GroupName + ".CcicPersonalRelation";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公名称信息    a22
    /// </summary>
    public class CcicPhone
    {
        public const string Default = GroupName + ".CcicPhone";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公运营信息    a26
    /// </summary>
    public class CcicPractice
    {
        public const string Default = GroupName + ".CcicPractice";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公注册信息    a28
    /// </summary>
    public class CcicRegister
    {
        public const string Default = GroupName + ".CcicRegister";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公重要标志信息-组织    a35
    /// </summary>
    public class CcicSignOrg
    {
        public const string Default = GroupName + ".CcicSignOrg";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 对公客户类别信息    a08
    /// </summary>
    public class CcicCustomerType
    {
        public const string Default = GroupName + ".CcicCustomerType";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
