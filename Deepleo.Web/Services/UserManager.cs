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
    public class UserManager
    {
        public static DataSet CreateUser(UserModel p)
        {

            string sqlFmt =
                @"


SELECT case when '{0}'==''
           then '微信号必须输入'  
            when '{1}'==''
           then '必须通过微信公众号完成绑定'  
           when EXISTS (
               SELECT *
                 FROM user
                WHERE openId = '{1}'
           )
           then '微信已经绑定过了，不要重复绑定'  
           when EXISTS (
               SELECT *
                 FROM user
                WHERE wechatNum = '{0}'
           )
           then '请确认是否是自己的微信号' 
           else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------



INSERT INTO User (
                      wechatNum,
                      openId,
                      mima,
                      email

                  )
                  VALUES (
                      '{0}',
                      '{1}',
                      '{2}',
                      '{3}'
                  );
                  
SELECT *
  FROM User
  where id =last_insert_rowid()
 ;

";
          
            string sql = string.Format(sqlFmt, p.wechatNum, p.openId,p.mima,p.email);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
                return ds;


        }
        
        public static DataSet UpdateUser(UserModel p)
        {

            string sqlFmt =
                @"


SELECT case when '{0}'==''
           then '微信号必须输入'  
            when '{1}'==''
           then '必须通过微信公众号完成绑定'  
           else '验证通过' end AS result;
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------


update User
set 
    mima='{2}',
    email='{3}'
    where openId='{1}';
                  
SELECT *
  FROM User
  where id =last_insert_rowid()
 ;

";
          
            string sql = string.Format(sqlFmt, p.wechatNum, p.openId,p.mima,p.email);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
                return ds;


        }

        internal static DataSet UserVisit(string openId)
        {
            string sqlFmt =
                @"

SELECT case when '{0}'==''
           then '必须通过微信公众号完成访问'           
           else '验证通过' end AS result;
           
---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------



INSERT INTO Visit (
                      openId

                  )
                  VALUES (                      
                      '{0}'
                  );
                  
SELECT *
  FROM User
  where openId='{0}'
 ;



 ;

";

            string sql = string.Format(sqlFmt, openId);
            DataSet ds = SQLiteHelper.ExecuteQueryVerify(sql);
            return ds;

        }
    }
}