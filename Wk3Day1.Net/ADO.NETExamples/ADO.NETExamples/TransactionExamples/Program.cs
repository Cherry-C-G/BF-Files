using System.Data.SqlClient;

namespace TransactionExamples
{
    internal class Program
    {
        public static readonly string connString =
          // "Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost";
          "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                //open connection
                connection.Open();

                //start a local transaction
                SqlTransaction sqlTran = connection.BeginTransaction();

                //enlist a command in the current transaction
                SqlCommand command= connection.CreateCommand(); // returns a SqlCommand 
                command.Transaction = sqlTran;

                try
                {
                    //execute two separate commands.
                    command.CommandText = "INSERT INTO StudentClass(ClassName) VALUES('SQL BATCH')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO StudentClass(StudentInfo) VALUES('DEC Batch')";
                    command.ExecuteNonQuery();

                    //commit the transaction
                    sqlTran.Commit();
                    Console.WriteLine("Both records were written to database");
                }
                catch (Exception ex)
                {
                    // if the transaction fails to commit
                    Console.WriteLine(ex.Message);
                    try
                    {
                        //attempt to roll back the transaction
                        sqlTran.Rollback();
                    }
                    catch(Exception exRollBack)
                    {
                        // throw exception if the connection is closed or the transaction has already
                        // been rolled back on server 
                        Console.WriteLine(exRollBack.Message);
                    }

                }
            }
        }
    }
}