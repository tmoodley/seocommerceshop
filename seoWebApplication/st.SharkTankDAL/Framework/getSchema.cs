using System;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Globalization;
 

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    public class getSchema
    {
        public DataTable GetSchema(string connectionString, string tableName)
        { 
            SqlConnection connection;

            string query;

            SqlCommand command;

            SqlDataReader reader;

            DataTable schema;



            using (connection = new SqlConnection(connectionString))
            {



                connection.Open();

                query = String.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tableName);



                using (command = new SqlCommand(query, connection))
                {



                    using (reader = command.ExecuteReader())
                    {

                        schema = reader.GetSchemaTable();

                    }



                }



                connection.Close();



            }
            return schema;

        }
    }
}