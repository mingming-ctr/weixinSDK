using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.IO;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Text;

namespace Deepleo.Web.Services
{
    /// <summary>
    /// Class to write logging data through Log4Net.
    /// </summary>
    public class SQLiteHelper
    {
        //public static String ConnectionString = "Data Source=H:/SQLite/DB/minWeiGanBu.db;Pooling=true;FailIfMissing=false";
        //public static String ConnectionString = "Data Source=H:/SQLite/DB/aid/minWeiGanBu.db;Pooling=true;FailIfMissing=false";
        //static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString.ToString().Replace("|path|", Tools.binPath + @"\DB");
        static string ConnectionString = "Data Source=MyDatabase.db;Version=3;";
        //m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;");//没有数据库则自动创建

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params SQLiteParameter[] p)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (p != null)
            {
                foreach (object parm in p)
                    //cmd.Parameters.AddWithValue(string.Empty, parm);
                    cmd.Parameters.Add(parm);
            }
        }
        public static DataSet ExecuteQueryVerify(string cmdText, params SQLiteParameter[] p)
        {
            LogWriter.Default.WriteInfo("ExecuteQueryVerify");
            LogWriter.Default.WriteInfo("ExecuteQueryVerify");
            LogWriter.Default.WriteInfo(cmdText);
            string[] sep=new string[1];
            sep[0] = "---------ExecuteQueryVerify----ds.Tables[0].Rows[0][0].ToString()----------";
            string sqlVerify = cmdText.Split(sep, StringSplitOptions.RemoveEmptyEntries)[0];
            DataSet ds =ExecuteQuery(sqlVerify,p);
            if ("验证通过" == ds.Tables[0].Rows[0][0].ToString())
            {
                ds = ExecuteQuery(cmdText,p);
            }
            return ds;
        }
        public static DataSet ExecuteQuery(string cmdText, params SQLiteParameter[] p)
            {
                try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand())
                    {
                        DataSet ds = new DataSet();
                        PrepareCommand(command, conn, cmdText, p);
                        SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                        da.Fill(ds);
                        return ds;
                    }
                }

            }
            catch (Exception ex)
            {
                StringBuilder b = new StringBuilder();
                b.AppendLine(ex.Message);
                b.AppendLine("SQL-->>:       ");
                b.AppendLine( cmdText);

                throw new Exception(b.ToString()) ;
            }
        }
        public static int ExecuteNonQuery(string cmdText, params SQLiteParameter[] p)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, conn, cmdText, p);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static SQLiteDataReader ExecuteReader(string cmdText, params SQLiteParameter[] p)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            //{
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            using (SQLiteCommand command = new SQLiteCommand())
            {
                PrepareCommand(command, conn, cmdText, p);
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            //}         
        }

        public static object ExecuteScalar(string cmdText, params SQLiteParameter[] p)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, conn, cmdText, p);
                    return command.ExecuteScalar();
                }
            }
        }
    }
}