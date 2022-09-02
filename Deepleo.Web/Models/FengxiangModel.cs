using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static log4net.Appender.RollingFileAppender;

namespace Deepleo.Web.Models
{
    public class FengxiangModel
    {

        public string ID { set; get; }
        public string ShuqianID { set; get; }
        public string FengxianMa { set; get; }
        public string openId { set; get; }
        public DateTime ChuangjianShijian { set; get; }
        public int liulanCishu { set; get; }



        //    ID INTEGER  PRIMARY KEY AUTOINCREMENT,
        //ShuqianID INTEGER  REFERENCES Shuqian(ID),
        //FengxianMa STRING   DEFAULT(substr(CAST (random() AS STRING), 2, 4) ),
        //openId INTEGER  REFERENCES User(ID),
        //charuShijian DATETIME DEFAULT(datetime('now', 'localtime') ),
        //liulanCishu INTEGER

    }
}