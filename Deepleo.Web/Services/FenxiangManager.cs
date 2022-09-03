using Deepleo.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Deepleo.Web.Services
{
    public class FenxiangManager
    {
        public static DataSet CreateFenxiang(FenxiangModel p)
        {

            string sqlFmt =
                @"


SELECT case  
            when '{1}'==''
           then '必须通过微信公众号完成绑定'  
           else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------

INSERT INTO Fenxiang (
                          ShuqianID,
                          openId
                      )
                      VALUES (
                          '{0}', --@ShuqianID,
                          '{1}'  --@UserID
                      );



SELECT *
  FROM Fenxiang
  where FenxiangID =last_insert_rowid()
 ;

";
          
            string sql = string.Format(sqlFmt, p.ShuqianID, p.openId);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
                return ds;


        }
        
        public static DataSet UpdateFenxiang(FenxiangModel p)
        {

            string sqlFmt =
                @"


SELECT case when '{0}'==''
           then '微信号必须输入'  
            when '{1}'==''
           then '必须通过微信公众号完成绑定'  
           else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------


update Fenxiang
set 
    mima='{2}',
    email='{3}'
    where openId='{1}';
                  
SELECT *
  FROM Fenxiang
  where id =last_insert_rowid()
 ;

";
          
            string sql = string.Format(sqlFmt);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
                return ds;


        }

        internal static DataSet FenxiangFangwen(string openId)
        {
            string sqlFmt =
                @"

SELECT case when '{0}'==''
           then '必须通过微信公众号完成访问'           
           else '验证通过' end AS result;
           
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------



INSERT INTO Fangwen (
                      openId

                  )
                  VALUES (                      
                      '{0}'
                  );
                  
SELECT *
  FROM Fenxiang
  where openId='{0}'
 ;


select * from FangwenShuqian f
left join Shuqian s on f.shuqianID = s.ID
where
f.openId='{0}'
and f.id in
(
select MAX(id) as ID from FangwenShuqian f
where openId='{0}'
group by shuqianID

)

order by charuShijian desc






;

select '{0}' as openId,* from Shuqian


";

            string sql = string.Format(sqlFmt, openId);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
            return ds;

        }
    }
}