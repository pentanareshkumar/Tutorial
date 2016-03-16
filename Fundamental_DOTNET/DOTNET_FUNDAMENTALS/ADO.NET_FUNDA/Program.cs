using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ADO.NET_FUNDA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read data from database using Data Reader. 
            //UsingDataReader();

            // Read data from database using Data Adapter.
            //UsingDataAdapter();

            //Insert a record in Employee Table using StoreProcedure
            //AddEmployee();

            // Single-Database Transaction
            //SingleDatabaseTransaction();

            Console.ReadLine();
        }

        private static void SingleDatabaseTransaction()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlTransaction objTrans = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                objTrans = conn.BeginTransaction();

                SqlCommand objCmd1 = new SqlCommand("insert into Customer values(1)", conn);
                SqlCommand objCmd2 = new SqlCommand("insert into Customer values(2)", conn);

                try
                {
                    objCmd1.ExecuteNonQuery();
                    objCmd2.ExecuteNonQuery();
                    objTrans.Commit();
                }
                catch (Exception)
                {
                    objTrans.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private static void AddEmployee()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmdObj = new SqlCommand("spAddEmployee", conn);
                cmdObj.CommandType = CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmdObj.Parameters.AddWithValue("@Name", "Kumar");
                cmdObj.Parameters.AddWithValue("@Gender", "Male");
                cmdObj.Parameters.AddWithValue("@Salary", 9000);

                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@EmployeID";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmdObj.Parameters.Add(outPutParameter);

                //Open the connection and execute the query
                conn.Open();
                cmdObj.ExecuteNonQuery();

                //Retrieve the value of the output parameter
                string EmployeId = outPutParameter.Value.ToString();
                Console.WriteLine("EmployeID: {0}", EmployeId);
            }

        }

        /*
         Basic Methods of DataAdapter
         *  Fill: - Executes the Select Command to fill the Dataset object with data from the data source. 
                    It can also be used to update (refresh) an existing table in a Dataset with changes made to the data in the 
                    original data source if there is a primary key in the table in the Dataset.
         *  Fill Schema: - Extracts just the schema for a table from the data source, 
                    and creates an empty table in the DataSet object with all the correspondingconstraints.
         *  Update: - Updates the original datasource with the changes made to the content of the DataSet.
         */

        /*
         What are Dataset objects?

            Dataset is an in memory object with data tables, rows and columns.  You can visualize it as in-memory RDBMS. Dataset has the following features:-
            The in memory RDBMS works in a disconnected manner. In other words even if the connection is closed the dataset is still there in memory.
            You can do modification in the in-memory database object and send the final changes to the database.

         */
        private static void UsingDataAdapter()
        {
            //Step 1 - ConnectionState 
            SqlConnection objConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=PingYourPackage;Integrated Security=True;");
            objConnection.Open();

            //Step 2 - Command (SQL)
            SqlCommand objCommand = new SqlCommand("SELECT * FROM Customer", objConnection);

            //Step 3 - Data Adapter - Data Set
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            DataSet objDS = new DataSet();
            objAdapter.Fill(objDS);

            foreach (DataRow row in objDS.Tables[0].Rows)
            {
                Console.WriteLine(row["CustomerId"] + " " + row["CustomerName"]);
            }

            objConnection.Close();
        }

        /*
         What is the use of command objects?

            Command object helps to execute SQL statements. Following are the methods provided by command object: -
            ExecuteNonQuery: - Executes insert, update and delete SQL commands. Returns an Integer indicating the number of rows affected by the query.
            ExecuteReader: - Executes select SQL statements which can either be in your .NET code or in a stored procedure. Returns a "Datareader" object.
            ExecuteScalar: - Executes SQL command and returns only a single value like count, sum, first record etc.
         
         */
        static void UsingDataReader()
        {
            //Step 1 - Connection
            SqlConnection connObj = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=PingYourPackage;Integrated Security=True;");
            connObj.Open();

            //Step 2 - Command (SQL)
            SqlCommand commandObj = new SqlCommand("SELECT * FROM Customer", connObj);

            //Step 3 - Data Reader
            SqlDataReader dataReaderObj = commandObj.ExecuteReader();

            while (dataReaderObj.Read())
            {
                //Display Records
                Console.WriteLine(dataReaderObj["CustomerId"] + " " + dataReaderObj["CustomerName"]);
            }
            connObj.Close();
        }
    }
}


/*
 * How can we force the connection object to close after my data reader is closed?

        Command method Execute reader takes a parameter called as Command Behavior wherein 
        we can specify saying close connection automatically after the Data reader is close.
        PobjDataReader = pobjCommand.ExecuteReader (CommandBehavior.CloseConnection)
 
 * I want to force the data reader to return only schema of the data store rather than data.

        PobjDataReader = pobjCommand.ExecuteReader (CommandBehavior.SchemaOnly)
 
 * How can we fine-tune the command object when we are expecting a single row?

        Again, CommandBehaviour enumeration provides two values Single Result and Single Row. 
        If you are expecting a single value then pass “CommandBehaviour.SingleResult” and the query is optimized accordingly, 
        if you are expecting single row then pass “CommandBehaviour.SingleRow” and query is optimized according to single row.
 
 * What is difference between Dataset.Clone and Dataset.Copy?

        Clone: - It only copies structure, does not copy data.
        Copy: - Copies both structure and data.
 */