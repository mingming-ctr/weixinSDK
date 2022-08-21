using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Deepleo.Weixin.SDK.Helpers;

using System.Runtime.InteropServices;
using System.IO;
using System.Text;  


namespace Deepleo.Web
{
    public class WeixinConfig
    {
        public static string Token { private set; get; }
        public static string EncodingAESKey { private set; get; }
        public static string AppID { private set; get; }
        public static string AppSecret { private set; get; }
        public static string PartnerKey { private set; get; }
        public static string mch_id { private set; get; }
        public static string device_info { private set; get; }
        public static string spbill_create_ip { private set; get; }
        public static void Register()
        {
            Token = Readconfigini("Token");
            EncodingAESKey = Readconfigini("EncodingAESKey");
            AppID = Readconfigini("AppID");
            AppSecret = Readconfigini("AppSecret");
            PartnerKey = Readconfigini("PartnerKey");
            mch_id = Readconfigini("mch_id");
            device_info = Readconfigini("device_info");
            spbill_create_ip = Readconfigini("spbill_create_ip");
        }

        public static string Readconfigini(string key)
        {
            //如果存在config.ini文件，直接读取里面的配置，（config.ini这个文件不用提交）
            //string file = System.Environment.CurrentDirectory + @"\config.ini";
            string file = System.AppDomain.CurrentDomain.BaseDirectory + @"\config.ini";
            if (File.Exists(file))//读取过config.ini文件就不用读取web.config
            {
                string configValue = IniHelper.GetValue("gongzonghao", key, "", file);
                return configValue;
            }
            else
            {
                string webValue = System.Configuration.ConfigurationManager.AppSettings["key"];
                return webValue;

            }

        }
    }

    
    public class IniHelper
    {
        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="Section">名称</param>
        /// <param name="Key">关键字</param>
        /// <param name="defaultText">默认值</param>
        /// <param name="iniFilePath">ini文件地址</param>
        /// <returns></returns>
        public static string GetValue(string Section, string Key, string defaultText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, defaultText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return defaultText;
            }
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="Section">名称</param>
        /// <param name="Key">关键字</param>
        /// <param name="defaultText">默认值</param>
        /// <param name="iniFilePath">ini文件地址</param>
        /// <returns></returns>
        public static bool SetValue(string Section, string Key, string Value, string iniFilePath)
        {
            var pat = Path.GetDirectoryName(iniFilePath);
            if (Directory.Exists(pat) == false)
            {
                Directory.CreateDirectory(pat);
            }
            if (File.Exists(iniFilePath) == false)
            {
                File.Create(iniFilePath).Close();
            }
            long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
            if (OpStation == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}