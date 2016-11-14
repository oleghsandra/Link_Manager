using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LinkManager.DAL.Concrete.SQL
{
    /// <summary>
    /// Wrapper for performing actions with database
    /// </summary>
    public class SqlCommandWrapper
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCommandWrapper"/> class.
        /// </summary>
        /// <param name="connectionString">String fot connecting to DB</param>
        public SqlCommandWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Executes database query
        /// </summary>
        /// <typeparam name="T">Type of returning value</typeparam>
        /// <param name="commandText">In this case - the name of the SP</param>
        /// <param name="parameters">Parameters for executing queury</param>
        /// <param name="callbackParser">Function for parsing results</param>
        /// <returns>Obgect as result of executing</returns>
        public object ExecuteReader<T>(
            string commandText,
            SqlParameter[] parameters,
            Func<SqlDataReader, T> callbackParser = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(commandText, connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    command.CommandTimeout = 0;

                    var reader = command.ExecuteReader();
                    object result;

                    using (reader)
                    {
                        var list = new List<T>();
                        while (reader.Read())
                        {
                            if (callbackParser != null)
                            {
                                var item = callbackParser(reader);
                                if (!Equals(item, default(T)))
                                {
                                    list.Add(item);
                                }
                            }
                        }
                        result = list;
                    }
                    return result;
                }
            }
        }
    }
}