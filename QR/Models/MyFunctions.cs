using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using Oracle.DataAccess.Client;


    public class MyFunctions
    {
        private string cs = "";
        private string cs_SQL = "";
        private DataSet ds = new DataSet();
        private OleDbConnection cn = new OleDbConnection();
        private SqlConnection cn_Sql = new SqlConnection();
        private OleDbDataAdapter ad = new OleDbDataAdapter();
        private SqlDataAdapter ad_SQL = new SqlDataAdapter();
        private OleDbCommand cmd = new OleDbCommand();
        private SqlCommand cmd_SQL = new SqlCommand();
        private DataTable dt;

        public string Encrypt(string str)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        public string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        public SqlConnection fireConnectionSQl()
        {
            cn_Sql = new SqlConnection(cs_SQL);
            return cn_Sql;
        }
        public OleDbConnection fireConnectionAccess()
         {
        cn = new OleDbConnection(cs);
        return cn;
    }
    public DataTable fireDataTableSQl(string Access, string _cn_Sql)
    {
        dt = new DataTable();
        cs_SQL = _cn_Sql;
            fireConnectionSQl();
            if (cn_Sql.State == ConnectionState.Closed)
                cn_Sql.Open();
           
            cmd_SQL.Connection = cn_Sql;
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.CommandText = Access;
            cmd_SQL.CommandTimeout = 0;
            ad_SQL.SelectCommand = cmd_SQL;
            cn_Sql.Close();
            ad_SQL.Fill(dt);
            return dt;
        }
    public DataTable fireDataTable(string qure, string cn,int dbtype)
    {

        dt = new DataTable();
        if (dbtype == 3)
        {


            cs_SQL = cn;
            fireConnectionSQl();
            if (cn_Sql.State == ConnectionState.Closed)
                cn_Sql.Open();

            cmd_SQL.Connection = cn_Sql;
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.CommandText = qure;
            cmd_SQL.CommandTimeout = 0;
            ad_SQL.SelectCommand = cmd_SQL;
            cn_Sql.Close();
            ad_SQL.Fill(dt);
        }
        else if (dbtype == 2)
        {

            //Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(cn);
            //conn.Open();
            //OracleCommand cmd = new OracleCommand();

            //cmd.Connection = conn;
            //cmd.CommandText = qure;
            //cmd.CommandType = CommandType.Text;
            //// Dim dr As OracleDataReader = cmd.ExecuteReader()
            //OracleDataAdapter ad_Or = new OracleDataAdapter();
            //ad_Or.SelectCommand = cmd;
            //conn.Close();
            //dt = new DataTable();
            //ad_Or.Fill(dt);
        }

        else if (dbtype == 4)
        {

            dt = new DataTable();
            OleDbConnection con = new OleDbConnection(cn);
            OleDbCommand cmd = con.CreateCommand();

            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.CommandText = qure;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            ad.SelectCommand = cmd;
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        return dt;
       
    }

    public string fireDB(string qure, string cn, int dbtype)
    {
        if (dbtype == 3)
        {
            cs_SQL = cn;
            fireConnectionSQl();
            if (cn_Sql.State == ConnectionState.Closed)
                cn_Sql.Open();
            OleDbDataReader[] dr;
            cmd_SQL.Connection = cn_Sql;
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.CommandText = qure;
            cmd_SQL.CommandTimeout = 0;

            if (cmd_SQL.ExecuteScalar() != null)
                return cmd_SQL.ExecuteScalar().ToString();
            else
            {
                return "";
                cn_Sql.Close();
            }
            cn_Sql.Close();
        }
        else if (dbtype == 2)
        {
            //Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(cn);
            //conn.Open();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = qure;
            //cmd.CommandType = CommandType.Text;
            //cmd.ExecuteNonQuery();
            //conn.Close();

        }
        else if (dbtype == 4)
        {

            OleDbConnection con = new OleDbConnection(cn);

            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = cn;
            //OleDbCommand cmd = new OleDbCommand(qure);
            //cmd.Connection = conn;


            OleDbConnection AccessconCon = new OleDbConnection(cn);
            OleDbCommand cmd = AccessconCon.CreateCommand();
            AccessconCon.Open();
            cmd.CommandText = qure;
            cmd.ExecuteNonQuery();
            AccessconCon.Close();




        //    OleDbCommand cmd = con.CreateCommand();
        //    con.Open();
        //    cmd.CommandText = qure;
        //    cmd.Connection = con;
        //    cmd.ExecuteNonQuery();
        //    if (cmd.ExecuteScalar() != null)
        //        return cmd.ExecuteScalar().ToString();
        //    else
        //        return "";
        }

 
            return "";
    }
    public DataTable fireDataTableOracle(string qure, string cn_Oracle)
    {
        //Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(cn_Oracle);
        //conn.Open();
        //OracleCommand cmd = new OracleCommand();

        //cmd.Connection = conn;
        //cmd.CommandText = qure;
        //cmd.CommandType = CommandType.Text;
        //// Dim dr As OracleDataReader = cmd.ExecuteReader()
        //OracleDataAdapter ad_Or = new OracleDataAdapter();
        //ad_Or.SelectCommand = cmd;
        //conn.Close();
        //dt = new DataTable();
        //ad_Or.Fill(dt);
        return dt;

    }
    public string fireOracle(string qure, string cn_Oracle)
    {
        //Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(cn_Oracle);
        //conn.Open();
        //OracleCommand cmd = new OracleCommand();
        
        //cmd.Connection = conn;
        //cmd.CommandText = qure;
        //cmd.CommandType = CommandType.Text;
        //cmd.ExecuteNonQuery();
        ////OracleDataReader dr = cmd.ExecuteReader(); 
        ////OracleDataAdapter ad_Or = new OracleDataAdapter();
        ////ad_Or.SelectCommand = cmd;
        //conn.Close();

        //if (cmd.ExecuteScalar() != null)
        //    return cmd.ExecuteScalar().ToString();
        //else
        //{
            return "";

            //Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(cn_Oracle);
            //conn.Open();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = qure;
            //cmd.CommandType = CommandType.Text;
            //// Dim dr As OracleDataReader = cmd.ExecuteReader()
            //OracleDataAdapter ad_Or = new OracleDataAdapter();
            //ad_Or.SelectCommand = cmd;
            //conn.Close();
            //if (cmd.ExecuteScalar() != null)
            //    return cmd.ExecuteScalar().ToString();
            //else
            //{
            //    return "";

            //}

    }
    public string fireSQL(string Access, string _cn_Sql)
        {
            cs_SQL = _cn_Sql;
            fireConnectionSQl();
            if (cn_Sql.State == ConnectionState.Closed)
                cn_Sql.Open();
            OleDbDataReader[] dr;
            cmd_SQL.Connection = cn_Sql;
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.CommandText = Access;
            cmd_SQL.CommandTimeout = 0;

            if (cmd_SQL.ExecuteScalar() != null)
                return cmd_SQL.ExecuteScalar().ToString();
            else
            {
                return "";
                cn_Sql.Close();
            }
        }

        public OleDbConnection fireConnection()
        {
            cn = new OleDbConnection(cs);
            return cn;
        }

        public MyFunctions()
        {
            cn = fireConnection();
        }

        public string fireAccess(string Access, string cs)
    {
        
           OleDbConnection con = new OleDbConnection(cs);
        OleDbCommand cmd = con.CreateCommand();
        con.Open();
        cmd.CommandText = Access;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
       if (cmd.ExecuteScalar() != null)
                return cmd.ExecuteScalar().ToString();
            else
                return "";
        }

        public DataTable fireDataTableAccess(string Access,string cs)
    {
        dt = new DataTable();
        OleDbConnection con = new OleDbConnection(cs);
        OleDbCommand cmd = con.CreateCommand();

        if (con.State == ConnectionState.Closed)
            con.Open();
            cmd.CommandText = Access;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
       
        ad.SelectCommand = cmd;
        ad.Fill(dt);
        con.Close();
        return dt;


        }

        public DataRow fireDataRowAccess(string Access)
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            dt = new DataTable();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Access;
            cmd.CommandTimeout = cn.ConnectionTimeout;
            ad.SelectCommand = cmd;
            ad.Fill(dt);
            return dt.Rows[0];
        }

        public DataSet fireDataSetAccess(string Access)
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            ds = new DataSet();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Access;
            cmd.CommandTimeout = cn.ConnectionTimeout;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds;
        }
    }

