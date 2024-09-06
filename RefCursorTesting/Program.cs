using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace OracleProcedureCall;

class Program
{
    static void Main(string[] args)
    {
        // Define your connection string here
        string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.234.2.38)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=PDB_WINORG_DEV.test.winorgvcn.oraclevcn.com)));User Id=winorg;Password=Et_naturlig_utvalg;";

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected to Oracle Database!");

                using (OracleCommand command = new OracleCommand("Token_pakke.Opprett_Token_Aktor", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add("p_aktorid", OracleDbType.Varchar2).Value = "117812";
                    command.Parameters.Add("p_ktkode", OracleDbType.Varchar2).Value = "ANB";
                    command.Parameters.Add("p_kilde", OracleDbType.Varchar2).Value = "333";

                    // Define output parameter for the cursor
                    OracleParameter curDataParam = new OracleParameter("cur_data", OracleDbType.RefCursor);
                    curDataParam.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(curDataParam);

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Fetch the cursor
                    using (OracleDataReader reader = ((OracleRefCursor)curDataParam.Value).GetDataReader())
                    {
                        while (reader.Read())
                        {
                            // Access your cursor data here, example:
                            Console.WriteLine(reader.GetString(0)); // Assuming the first column is a string
                        }
                    }

                    Console.WriteLine("Procedure executed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
