using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Line
{
    class Sqlcalss
    {
        static SqlDataAdapter sqla ;
        static SqlConnection sqlcon = new SqlConnection("Data Source=203.71.75.120,14333;User ID=yu;Password=043126");
        public static DataTable ToDatatable(string str_comment)
        {
            object o= new object();
            lock (o)
            {
                DataTable dt = new DataTable();
                while (sqlcon.State == ConnectionState.Open)
                {
                    Thread.Sleep(10);
                }
                sqlcon.Open();
                sqla = new SqlDataAdapter(str_comment, sqlcon);
                sqla.Fill(dt);
                sqlcon.Close();
                return dt;
            }
        //    DataTable dt = new DataTable();
        //Again:
        //    try
        //    {
        //        while (sqlcon.State == ConnectionState.Open)
        //        {
        //            Thread.Sleep(10);
        //        }
        //        sqlcon.Open();
        //    }
        //    catch
        //    {
        //        goto Again;
        //    }
        //    sqla = new SqlDataAdapter(str_comment, sqlcon);
        //    sqla.Fill(dt);
        //    sqlcon.Close();
        //    return dt;
        }
        public static DataTable Search_Friend(string User_ID)
        {
            object o = new object();
            lock (o)
            {
                DataTable dt = new DataTable();
                string Comment = "SELECT dbo.[User].User_Name,dbo.[User].ID FROM dbo.[Group] INNER JOIN  dbo.[Group] AS Group_1 ON dbo.[Group].Group_Id = Group_1.Group_Id INNER JOIN  dbo.[User] ON Group_1.User_Id = dbo.[User].ID WHERE (dbo.[Group].User_Id = N'" + User_ID + "') AND(Group_1.User_Id<>N'" + User_ID + "') AND Group_1.Personal = 'True'";
                while (sqlcon.State == ConnectionState.Open)
                {
                    Thread.Sleep(10);
                }
                sqlcon.Open();
                sqla = new SqlDataAdapter(Comment, sqlcon);
                sqla.Fill(dt);
                sqlcon.Close();
                return dt;
            }

            //DataTable dt = new DataTable();
            // //string Comment = "SELECT dbo.[User].User_Name FROM dbo.[Group] INNER JOIN  dbo.[Group] AS Group_1 ON dbo.[Group].Group_Id = Group_1.Group_Id INNER JOIN  dbo.[User] ON Group_1.User_Id = dbo.[User].ID WHERE (dbo.[Group].User_Id = (SELECT ID FROM dbo.[User] AS User_2 WHERE User_Name = '"+User_Name+"'))) AND(Group_1.User_Id<> (SELECT ID FROM dbo.[User] AS User_1 WHERE (User_Name = '"+User_Name+"')))";
            // string Comment = "SELECT dbo.[User].User_Name,dbo.[User].ID FROM dbo.[Group] INNER JOIN  dbo.[Group] AS Group_1 ON dbo.[Group].Group_Id = Group_1.Group_Id INNER JOIN  dbo.[User] ON Group_1.User_Id = dbo.[User].ID WHERE (dbo.[Group].User_Id = N'" + User_ID + "') AND(Group_1.User_Id<>N'" + User_ID + "') AND Group_1.Personal = 'True'";
            //Again:
            //try
            //{
            //    while (sqlcon.State == ConnectionState.Open)
            //    {
            //        Thread.Sleep(10);
            //    }
            //    sqlcon.Open();
            //}
            //catch
            //{
            //    goto Again;
            //}
            //sqla = new SqlDataAdapter(Comment, sqlcon);
            //sqla.Fill(dt);
            //sqlcon.Close();
            //return dt;
        }
        public static DataTable Search_Group(string User_ID)
        {
            object o = new object();
            lock (o)
            {
                string Comment = "SELECT  Group_1.Group_Name FROM dbo.[Group] INNER JOIN  dbo.[Group] AS Group_1 ON dbo.[Group].Group_Id = Group_1.Group_Id INNER JOIN  dbo.[User] ON Group_1.User_Id = dbo.[User].ID WHERE (dbo.[Group].User_Id = N'" + User_ID + "') AND (Group_1.Personal = 'False') GROUP BY   Group_1.Group_Name";
                DataTable dt = new DataTable();
                while (sqlcon.State == ConnectionState.Open)
                {
                    Thread.Sleep(10);
                }
                sqlcon.Open();
                sqla = new SqlDataAdapter(Comment, sqlcon);
                sqla.Fill(dt);
                sqlcon.Close();
                return dt;

            }
           
            ////string Comment = "SELECT dbo.[User].User_Name FROM dbo.[Group] INNER JOIN  dbo.[Group] AS Group_1 ON dbo.[Group].Group_Id = Group_1.Group_Id INNER JOIN  dbo.[User] ON Group_1.User_Id = dbo.[User].ID WHERE (dbo.[Group].User_Id = (SELECT ID FROM dbo.[User] AS User_2 WHERE User_Name = '"+User_Name+"'))) AND(Group_1.User_Id<> (SELECT ID FROM dbo.[User] AS User_1 WHERE (User_Name = '"+User_Name+"')))";
            //string Comment = "SELECT  Group_1.Group_Name FROM dbo.[Group] INNER JOIN  dbo.[Group] AS Group_1 ON dbo.[Group].Group_Id = Group_1.Group_Id INNER JOIN  dbo.[User] ON Group_1.User_Id = dbo.[User].ID WHERE (dbo.[Group].User_Id = N'" + User_ID + "') AND (Group_1.Personal = 'False') GROUP BY   Group_1.Group_Name";
            //DataTable dt = new DataTable();
            //Again:
            //try
            //{
            //    while (sqlcon.State == ConnectionState.Open)
            //    {
            //        Thread.Sleep(10);
            //    }
            //    sqlcon.Open();
            //}
            //catch
            //{
            //    goto Again;
            //}
            //sqla = new SqlDataAdapter(Comment, sqlcon);
            //sqla.Fill(dt);
            //sqlcon.Close();
            //return dt;
        }
    }
}
