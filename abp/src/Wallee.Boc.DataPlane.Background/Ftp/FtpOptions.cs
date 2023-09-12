namespace Wallee.Boc.DataPlane.Background.Ftp
{
    public class FtpOptions
    {
        /// <summary>
        /// ftp地址
        /// </summary>
        public string Address { get; set; } = default!;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = default!;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = default!;
        /// <summary>
        /// ftp的文件存储基础路径
        /// </summary>
        public string FtpBasePath { get; set; } = default!;
        public string Encoding { get; set; } = default!;
        /// <summary>
        /// 对公客户基础信息文件名
        /// </summary>
        public string CcicBasicFileName { get; set; } = default!;
        /// <summary>
        /// 对公客户地址信息文件名称
        /// </summary>
        public string CcicAddressFileName { get; set; } = default!;
        /// <summary>
        /// 对公反洗钱文件名称
        /// </summary>
        public string CcicAntiMoneyLaunderingFileName { get; set; } = default!;
        /// <summary>
        /// 对公客户类别文件名称
        /// </summary>
        public string CcicCustomerTypeFileName { get; set; } = default!;
        /// <summary>
        /// 对公客户类别-组织文件名称
        /// </summary>
        public string CcicCustomerTypeOrgFileName { get; set; } = default!;
        /// <summary>
        /// 对公概况组织文件名称
        /// </summary>
        public string CcicGeneralOrgFileName { get; set; } = default!;
        /// <summary>
        /// 对公证件文件名称
        /// </summary>
        public string CcicIdFileName { get; set; } = default!;
        /// <summary>
        /// 对公客户名称文件名称
        /// </summary>
        public string CcicNameFileName { get; set; } = default!;
        /// <summary>
        /// 对公人员关系文件名称
        /// </summary>
        public string CcicPersonalRelationFileName { get; set; } = default!;
        /// <summary>
        /// 对公电话文件名称
        /// </summary>
        public string CcicPhoneFileName { get; set; } = default!;
        /// <summary>
        /// 对公运营文件名称
        /// </summary>
        public string CcicPracticeFileName { get; set; } = default!;
        /// <summary>
        /// 对公注册信息文件名称
        /// </summary>
        public string CcicRegisterFileName { get; set; } = default!;
        /// <summary>
        /// 对公重要标志信息文件名称
        /// </summary>
        public string CcicSignOrgFileName { get; set; } = default!;
        public string TDcmpJobExecutionCronExpression { get; set; } = default!;

    }
}
