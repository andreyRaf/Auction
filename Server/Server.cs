using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Server
{
    public class ServerConnect
    {
        private static string dataSource = "SQL5002.Smarterasp.net";
        private static string initialCatalog = "DB_9C0D5F_auctions";
        private static string Password = "auctions";
        private static string userID = "DB_9C0D5F_auctions_admin";

        private static SqlConnection cnn = null;

        private static bool OpenConnection()
        {
            try
            {
                return OpenConnection(3, true);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static bool OpenConnection(int timeOut, bool isPooling)
        {
            string connetionString = null;
            connetionString = "Data Source=" + dataSource + ";Initial Catalog=" + initialCatalog + ";Password=" + Password + ";Persist Security Info=True;" +
                "User ID=" + userID + ";"+
                (isPooling ? "Pooling=true;" : "Pooling=false;") +
                "Connect Timeout=" + timeOut + ";";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                return true;
            }
            catch (Exception)
            {
                if (cnn.State != ConnectionState.Closed) cnn.Close();
                if (OpenConnection(10, false))
                    return true;
                return false;
            }
        }

        public string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        //Close cnn
        private static bool CloseConnection()
        {
            cnn.Close();
            return false;
        }

        public static void Insert(string sqlText)
        {
            string query = sqlText;

            //open cnn
            if (OpenConnection() == true)
            {
                //create command and assign the query and cnn from the constructor
                SqlCommand cmd = new SqlCommand(query, cnn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close cnn
                CloseConnection();
            }
        }

        //Update statement
        public static void Update(string sqlText)
        {
            string query = sqlText;

            //Open cnn
            if (OpenConnection() == true)
            {
                //create mysql command
                SqlCommand cmd = new SqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the cnn using cnn
                cmd.Connection = cnn;

                //Execute query
                cmd.ExecuteNonQuery();

                //close cnn
                CloseConnection();
            }
        }

        //Delete statement
        public static void Delete(string sqlText)
        {
            string query = sqlText;

            if (OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        //Select statement
        public static DataTable Select(string sqlText)
        {
            string query = sqlText;

            DataTable dt = new DataTable();

            //Open cnn
            if (OpenConnection() == true)
            {
                //Create Command
                SqlCommand cmd = new SqlCommand(query, cnn);
                //Create a data reader and Execute the command
                SqlDataReader dataReader = cmd.ExecuteReader();

                dt.Load(dataReader);
                
                //close Data Reader
                dataReader.Close();

                //close cnn
                CloseConnection();

                //return list to be displayed
                return dt;
            }
            else
            {
                return dt;
            }
        }

        //Count statement
        public static int Count(string sqlText)
        {
            string query = sqlText;
            int Count = -1;

            //Open cnn
            if (OpenConnection() == true)
            {
                //Create Mysql Command
                SqlCommand cmd = new SqlCommand(query, cnn);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close cnn
                CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\SqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    userID, Password, dataSource, initialCatalog);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                //"Error , unable to backup!"
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\SqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mssql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    userID, Password, dataSource, initialCatalog);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                //"Error , unable to Restore!"
            }
        }
    }
}
