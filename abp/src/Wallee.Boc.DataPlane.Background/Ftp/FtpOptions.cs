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

    }
}
