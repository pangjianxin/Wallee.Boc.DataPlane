namespace Wallee.Boc.DataPlane.Web.Menus;

public class DataPlaneMenus
{
    private const string Prefix = "DataPlane";
    public const string Home = Prefix + ".Home";
    public const string BackgroundJobs = Prefix + ".BackgroundJobs";
    public const string BackgroundJobs_Index = BackgroundJobs + ".Index";
    public const string BackgroundJobs_Operation = BackgroundJobs + ".Operation";
    public const string OrganizationUnit = Prefix + ".OrganizationUnit";

    //Add your menu items here...
    public const string TDcmp = Prefix + ".TDcmp";
    public const string TDcmp_CcicBasic = TDcmp + ".CcicBasic";
    public const string TDcmp_CcicAddress = TDcmp + ".CcicAddress";
    public const string CcicAntiMoneyLaundering = TDcmp + ".CcicAntiMoneyLaundering";
    public const string CcicCustomerTypeOrg = TDcmp + ".CcicCustomerTypeOrg";
    public const string CcicGeneralOrg = TDcmp + ".CcicGeneralOrg";
    public const string CcicId = TDcmp + ".CcicId";
    public const string CcicName = TDcmp + ".CcicName";
    public const string CcicPersonalRelation = TDcmp + ".CcicPersonalRelation";
    public const string CcicPhone = TDcmp + ".CcicPhone";
    public const string CcicPractice = TDcmp + ".CcicPractice";
    public const string CcicRegister = TDcmp + ".CcicRegister";
    public const string CcicSignOrg = TDcmp + ".CcicSignOrg";
    public const string CcicCustomerType = TDcmp + ".CcicCustomerType";

    public const string WorkFlows = Prefix + ".WorkFlows";
    public const string WorkFlows_CcicCusInfos = WorkFlows + ".CcicCusInfos";

    public const string Dictionaries = Prefix + ".Dictionaries";
    public const string OrganizationUnitCoordinate = Dictionaries + ".OrganizationUnitCoordinate";
    public const string Dashboard = Prefix + ".Dashboard";

    public const string Reports = Prefix + ".Reports";
    public const string Reports_ConvertedCusOrgUnit = Reports + ".ConvertedCusOrgUnit";
    public const string Reports_ConvertedCus = Reports + ".ConvertedCus";
}
