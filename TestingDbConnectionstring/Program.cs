using System;
using Oracle.ManagedDataAccess.Client;

string host = "";
string port = "";
string serviceName = "";
string userId = "";
string pw = "";

var connectionString = $@"
                           Data Source=
                                (DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)
                                (HOST={host})
                                (PORT={port}))
                                (CONNECT_DATA=(SERVICE_NAME={serviceName})));
                           User Id={userId};
                           Password={pw};
                       ";
// Create a SqlConnection object
using (var connection = new OracleConnection(connectionString))
{
    try
    {
        // Open the connection
        connection.Open();
        Console.WriteLine("Connection successful!");

        // Query to get the first ten tables
        string query = @"
                    SELECT table_name 
                    FROM (
                            SELECT table_name, ROWNUM as rnum 
                            FROM all_tables 
                            where owner = 'WINORG'
                        ) 
                    WHERE rnum <= 100";

        // Create an OracleCommand object
        using (OracleCommand command = new OracleCommand(query, connection))
        {
            // Execute the command and read the data
            using (OracleDataReader reader = command.ExecuteReader())
            {
                int tableCount = 0;
                while (reader.Read() && tableCount < 100)
                {
                    Console.WriteLine(reader.GetString(0));
                    tableCount++;
                }
            }
        }

    }
    catch (OracleException ex)
    {
        // Handle any SQL exceptions that occur
        Console.WriteLine($"Connection failed. Error: {ex.Message}");
    }
    finally
    {
        // Ensure the connection is closed
        if (connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Connection closed.");
            Console.ReadKey();
        }
    }
}
