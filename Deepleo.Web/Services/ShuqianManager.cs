using Deepleo.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Deepleo.Web.Services
{
    public class ShuqianManager
    {
        public static DataSet CreateShuqian(ShuqianModel p)
        {

            string sqlFmt =
                @"


SELECT case when @Title==''
            then '标签名称必须输入'  
            else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------


INSERT INTO Shuqian (
                        Title,
                        [Desc],
                        LinkSrc,
                        Suoluetu,
                        GengxinCishu
                    )
                    VALUES (
                        @Title,
                        @Desc,
                        @LinkSrc,
                        @Suoluetu,
                        @GengxinCishu
                    );

SELECT *
  FROM Shuqian
  where id =last_insert_rowid()
 ;

";

            List< SQLiteParameter> ls = new List< SQLiteParameter>();

            var Title = new SQLiteParameter("@Title", DbType.String);
            Title.Value = p.Title;
            ls.Add(Title);

            var Desc = new SQLiteParameter("@Desc", DbType.String);
            Desc.Value = p.Desc;
            ls.Add(Desc);
            

            var LinkSrc = new SQLiteParameter("@LinkSrc", DbType.String);
            LinkSrc.Value = p.LinkSrc;
            ls.Add(LinkSrc);
            

            var Suoluetu = new SQLiteParameter("@Suoluetu", DbType.String);
            Suoluetu.Value = p.Suoluetu;
            ls.Add(Suoluetu);
            

            var GengxinCishu = new SQLiteParameter("@GengxinCishu", DbType.String);
            GengxinCishu.Value = p.GengxinCishu;
            ls.Add(GengxinCishu);
            
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sqlFmt,ls.ToArray());
                return ds;


        }
        
        public static DataSet UpdateShuqian(ShuqianModel p)
        {

            string sqlFmt =
                @"


SELECT case when '{0}'==''
           then '微信号必须输入'  
            when '{1}'==''
           then '必须通过微信公众号完成绑定'  
           else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------


update Shuqian
set 
    mima='{2}',
    email='{3}'
    where openId='{1}';
                  
SELECT *
  FROM Shuqian
  where id =last_insert_rowid()
 ;

";
          

            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sqlFmt);
                return ds;


        }

        internal static DataSet GetShuqian(string ID="")
        {
            string sqlFmt =
                @"

select * from Shuqian

";
            if (ID != "")
                sqlFmt += @"
where ID='{0}'
";

            string sql = string.Format(sqlFmt, ID);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
            return ds;

        }
    }
}