using System;
using System.Data;
using System.Data.SqlClient;

namespace DataSetExample
{
    internal class Program
    {
        public static readonly string connString =
     // "Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost";
     //"Persist Security Info=False;User ID =myUserLogin;Password=myPass;Initial Catalog=Student;Server=localhost;Encrypt=False";

     "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
//"Persist Security Info=False;Integrated Security=SSPI;  
//    database=Student;server=(local)"  
//"Persist Security Info=False;Trusted_Connection=True;  
//    database=Student;server=(local)"
        static void Main(string[] args)
        {
            string query = "SELECT * FROM StudentClass; SELECT * FROM StudentInfo;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                //Now 2 tables are populated in the data set, the default names are "Table" and "Table1"
                adapter.Fill(dataSet);
                //Name the tables
                dataSet.Tables[0].TableName = "StudentClass";
                //dataSet.Tables[1].TableName = "StudentInfo";
                //First Table
                Console.WriteLine("Table 1 Data");
                foreach (DataRow row in dataSet.Tables["StudentClass"].Rows)
                {
                    Console.WriteLine(row["ClassId"] + ",  " + row["ClassName"]);
                }
                Console.WriteLine();

                // Second Table
                Console.WriteLine("Table 2 Data");
                foreach (DataRow row in dataSet.Tables["Table1"].Rows)
                {
                    Console.WriteLine(row["StuId"] + ",  " + row["StuName"] );
                }
            }

        }
        }
    }

