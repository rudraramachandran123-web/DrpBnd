using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DrpBnd.Models
{
    public class SDBind
    {
        string constring = ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString;
        SqlConnection con;
        public SDBind()
        {
            con = new SqlConnection(constring);
        }

        public List<stclass> Selectstates()
        {
            var getdata = new List<stclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var ob = new stclass
                    {
                        sId = Convert.ToInt32(sdr["StId"]),
                        sName = sdr["StName"].ToString()
                    };
                    getdata.Add(ob);
                }
                con.Close();
                return getdata;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }

        }

        public List<Dclass> SelectDis(int stateId)
        {
            var getdata = new List<Dclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[sp_District]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stid", stateId);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var obj = new Dclass
                    {
                        DId = Convert.ToInt32(sdr["DisId"]),//same as table
                        DName = sdr["DisName"].ToString()//same as table
                    };
                    getdata.Add(obj);

                }
                con.Close();
                return getdata;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }


        }
    }
}
