using System;
using System.Data;
using System.Data.SqlClient;

namespace DataTableExamples
{
    internal class Program
    {
        public static readonly string connString =
          // "Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost";
          "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
        static void Main(string[] args)
        {
            #region Create a Data Table Example
            DataTable studentTable = new DataTable("Student");
            DataColumn stuId = new DataColumn();
            stuId.ColumnName = "StuID";
            stuId.DataType = typeof(int);
            studentTable.Columns.Add(stuId);

            studentTable.Columns.Add("StuName", typeof(string));
            studentTable.Columns[1].AllowDBNull = false; // student name cannot be null

            //Set primary key
            studentTable.PrimaryKey = new DataColumn[] { stuId }; // can also use index: studentTable.Columns[0]
            //Set unique constraints
            studentTable.Constraints.Add(new UniqueConstraint(studentTable.Columns[1]));
            #endregion

            #region Data Row State
            DataTable myTable = new DataTable("MyTable");
            DataColumn nameColumn = new DataColumn("Name");
            myTable.Columns.Add(nameColumn);
            DataRow myRow;

            // Create a new DataRow.
            myRow = myTable.NewRow();
            // Detached row.
            Console.WriteLine("Create a new row => " + myRow.RowState);

            //Add this row to a table
            myTable.Rows.Add(myRow);
            // Added state.
            Console.WriteLine("Add the row to a table =>" + myRow.RowState);

            myTable.AcceptChanges(); // commit the changes to DataTable and the state changes after

            // Unchanged row.
            Console.WriteLine("Added the Row to the Table, but the value of the row hasn't been changed => " + myRow.RowState);

            myRow[0] = "Alex";
            // Modified row.
            Console.WriteLine("Modified the value of the row => " + myRow.RowState);

            myRow.Delete();
            // Deleted row.
            Console.WriteLine("Deleted() => " + myRow.RowState);

            myTable.AcceptChanges();
            Console.WriteLine("After AcceptChanges() =>" + myRow.RowState);
            try
            {
                Console.WriteLine("All the data in MyTable: ");
                foreach (DataRow row in myTable.Rows)
                {
                    Console.WriteLine(row[0]);
                }
                Console.WriteLine("----end----");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
                throw ex;
            }

            #endregion

            #region 
            //#region DataTableExample
            //string query = "SELECT * FROM StudentClass";
            //using (SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            //    DataTable studentClassTable = new DataTable();
            //    // database data => in-memory data 
            //    adapter.Fill(studentClassTable);

            //    foreach (DataRow row in studentClassTable.Rows)
            //    {
            //        Console.WriteLine(row["ClassId"] + ", " + row["ClassName"]);
            //    }

            //    // If I want to make some changes to the table
            //    foreach (DataRow row in studentClassTable.Rows)
            //    {
            //        if (Convert.ToInt32(row[0]) == 4)
            //        {
            //            row.Delete();  // This doesn't remove the row, but sets its RowState to Deleted
            //            Console.WriteLine(row.RowState);
            //            Console.WriteLine("Row in Deleted state");
            //        }
            //    }
            //    adapter.Update(studentClassTable);
            //    //Commit the changes to datatable
            //    studentClassTable.AcceptChanges();
            //    Console.WriteLine("Changes reflect to the datatable");
            //    foreach (DataRow row in studentClassTable.Rows)
            //    {
            //        Console.WriteLine(row["ClassId"] + ", " + row["ClassName"]);
            //    }
            //    studentClassTable.Rows[3]["ClassName"] = "Python Batch";
            //    //Use SqlCommandBuilder to auto generate insert, update or delete command for us
            //    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            //    //Update the changes to database
            //    //adapter.Update(studentClassTable);
            //    Console.WriteLine("Changes update to the database via SqlDataAdapter");

            //}
            //#endregion
            #endregion
        }
    }
}
