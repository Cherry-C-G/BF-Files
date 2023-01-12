using SqlConnectionExamples;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlCommandExamples
{
    internal class Program
    {
        public static readonly string connString =
          // "Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost";
          "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
        static void Main(string[] args)
        {
            string query = "SELECT ClassName FROM StudentClass WHERE ClassId = 1";
            query = "SELECT COUNT(*) FROM StudentClass";
            string query2 = "INSERT INTO StudentClass VALUES('.Net Batch')";
            string query3 = "SELECT * FROM StudentClass";
            #region Without Parameters
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Establish Connection
                conn.Open();
                #region ExecuteScalar Example
                ////Create the SqlCommand
                //SqlCommand cmd = new SqlCommand(query, conn);
                ////Execute Command
                //object returnedData = cmd.ExecuteScalar();
                ////Present the result
                //Console.WriteLine(returnedData.ToString());
                #endregion

                #region ExecuteNonQuery
                //Create the SqlCommand
                //SqlCommand cmd2 = new SqlCommand(query2, conn);
                ////Execute Command
                //int returnedData2 = cmd2.ExecuteNonQuery();
                ////Present the result
                //Console.WriteLine(returnedData2 + " row(s) affected.");
                #endregion

                #region ExecuteReader
                //Create the SqlCommand
                SqlCommand cmd3 = new SqlCommand(query3, conn);
                //Execute the command
                using (SqlDataReader reader = cmd3.ExecuteReader()) // here returns all the data in the StudentClass table in database
                {
                    //We can present the data use a while loop or hold all the data in a collection for future use
                    //while (reader.Read())
                    //{
                    //   Console.WriteLine(reader["ClassId"] + ", " + reader["ClassName"]);
                    //}

                    //Store the result in a List
                    List<StudentClass> studentClasses = new List<StudentClass>();
                    while (reader.Read())
                    {
                        studentClasses.Add(
                            new StudentClass()
                            {
                                ClassId = Convert.ToInt32(reader[0]),
                                ClassName = reader[1].ToString()
                            });
                    };
                    //Present the List
                    foreach (var classInfo in studentClasses)
                    {
                        Console.WriteLine("Class Id: " + classInfo.ClassId + "  Class Name: " + classInfo.ClassName);
                    };

                }
                #endregion
            }
            #endregion


            string parameterizedQuery = "SELECT * FROM StudentClass WHERE ClassId = @Id";
            #region With Parameters
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Establish Connection
                conn.Open();
                //Create the SqlCommand and set its properties
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = parameterizedQuery;
                //cmd.CommandType = CommandType.Text; // the default CommandType is Text, so this line is optional;

                //get the parameter
                int resultClassId = 1;

                //Add the input parameter and set its properties
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = resultClassId;
                //Add the parameter to the Parameters collection
                cmd.Parameters.Add(parameter);

                //Execute the command
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows) //check if the reader is empty or not
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}; {1}", reader[0], reader[1]);
                        }
                    }
                }
            }
            #endregion
        }
    }
}
