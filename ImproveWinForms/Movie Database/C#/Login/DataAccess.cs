using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Login
{
    internal class DataAccess
    {

        internal static bool Login(string userType, string userName, string password)
        {
            try
            {
                cn.Open();

                string s = "SELECT * FROM tbl_login WHERE name='" + userName + "' AND password='" + password + "' AND user_type='" + userType + "'";
                var cmd = new SqlCommand(s, cn);
                return (cmd.ExecuteScalar() != null);

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }


        private static byte[] imagetoByte(Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ByteToImage(byte[] byt)
        {
            var ms = new MemoryStream(byt);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private static SqlConnection cn = new SqlConnection(Common.ConnectionString);
        public static int addEditImage(string name, int year, string actor, string actress, string category, string quality, string sound, string language, string myopinion, string director, Image image, string link)
        {
            byte[] img = imagetoByte(image);
            var cmd = new SqlCommand("addEditImage", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@actor", actor);
            cmd.Parameters.AddWithValue("@actress", actress);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@quality", quality);
            cmd.Parameters.AddWithValue("@sound", sound);
            cmd.Parameters.AddWithValue("@language", language);
            cmd.Parameters.AddWithValue("@myopinion", myopinion);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@image", img);
            cmd.Parameters.AddWithValue("@link", link);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            int x = cmd.ExecuteNonQuery();
            cn.Close();
            return x;
        }

        public static int updateTableMovie(string name, int year, string actor, string actress, string category, string quality, string sound, string language, string myopinion, string director, Image image, string link, string updateName, int updateYear)
        {
            byte[] img = imagetoByte(image);
            var cmd = new SqlCommand("updateTableMovie", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@actor", actor);
            cmd.Parameters.AddWithValue("@actress", actress);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@quality", quality);
            cmd.Parameters.AddWithValue("@sound", sound);
            cmd.Parameters.AddWithValue("@language", language);
            cmd.Parameters.AddWithValue("@myopinion", myopinion);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@image", img);
            cmd.Parameters.AddWithValue("@updateName", updateName);
            cmd.Parameters.AddWithValue("@updateYear", updateYear);
            cmd.Parameters.AddWithValue("@link", link);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            int x = cmd.ExecuteNonQuery();
            cn.Close();
            return x;
        }

        public static DataTable getAllImages()
        {
            var DA = new SqlDataAdapter("getAllImages", cn);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            var DT = new DataTable();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            DA.Fill(DT);
            cn.Close();
            return DT;
        }

        public static DataTable getImage(string name, int year)
        {
            var DA = new SqlDataAdapter("getImage", cn);
            DA.SelectCommand.Parameters.AddWithValue("@name", name);
            DA.SelectCommand.Parameters.AddWithValue("@year", year);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            var DT = new DataTable();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            DA.Fill(DT);
            cn.Close();
            return DT;
        }
        public static DataTable getImage1(int year)
        {
            var DA = new SqlDataAdapter("getImage1", cn);
            DA.SelectCommand.Parameters.AddWithValue("@year", year);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            var DT = new DataTable();
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            DA.Fill(DT);
            cn.Close();
            return DT;
        }
    }
}
