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
    public class FangwenShuqianManager
    {
        public static DataSet Create(FangwenShuqianModel p)
        {

            string sqlFmt =
                @"


SELECT case when '{1}'==''
            then '书签ID必须输入'  
            else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------

INSERT INTO FangwenShuqian (

                               openId,
                               shuqianID

                           )
                           VALUES (
                               '{0}',
                               '{1}'

                           );


SELECT *
  FROM FangwenShuqian
  where FangwenShuqianID =last_insert_rowid()
 ;

";
            var sql = string.Format(sqlFmt,p.openId, p.shuqianID);

            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
            return ds;


        }

        private static List<SQLiteParameter> getPara(ShuqianModel p)
        {
            List<SQLiteParameter> ls = new List<SQLiteParameter>();

            var ID = new SQLiteParameter("@ID", DbType.String);
            ID.Value = p.ID;
            ls.Add(ID);
            
            var Biaoti = new SQLiteParameter("@Biaoti", DbType.String);
            Biaoti.Value = p.Biaoti;
            ls.Add(Biaoti);

            var Miaoshu = new SQLiteParameter("@Miaoshu", DbType.String);
            Miaoshu.Value = p.Miaoshu;
            ls.Add(Miaoshu);


            var Lianjie = new SQLiteParameter("@Lianjie", DbType.String);
            Lianjie.Value = p.Lianjie;
            ls.Add(Lianjie);


            var Suoluetu = new SQLiteParameter("@Suoluetu", DbType.String);
            Suoluetu.Value = p.Suoluetu;
            ls.Add(Suoluetu);


            var GengxinCishu = new SQLiteParameter("@GengxinCishu", DbType.String);
            GengxinCishu.Value = p.GengxinCishu;
            ls.Add(GengxinCishu);
            return ls;
        }

        public static DataSet UpdateShuqian(ShuqianModel p)
        {

            string sqlFmt =
                @"


SELECT case when @Biaoti==''
            then '标题必须输入'  
            else '验证通过' end AS result;

---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------


UPDATE Shuqian
   SET 
       Biaoti = @Biaoti,
       Miaoshu = @Miaoshu,
       Lianjie = @Lianjie,
       Suoluetu = @Suoluetu
 WHERE ID = @ID ;

                  
SELECT *
  FROM Shuqian
  where id =@ID
 ;

";

            List<SQLiteParameter> ls = getPara(p);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sqlFmt,ls.ToArray());
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