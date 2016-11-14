using System;
using System.Data;

namespace LinkManager.DAL.Concrete.SQL
{
    public static class DataRecordExtensions
    {
        /// <summary>
        /// Get value of specific column from data record
        /// </summary>
        /// <typeparam name="T">Type of column</typeparam>
        /// <param name="record">Data record</param>
        /// <param name="columnName">Column name</param>
        /// <returns>
        /// Returns value of column. 
        /// If value is null - returns default value for specific type.
        /// </returns>
        public static T Get<T>(this IDataRecord record, string columnName)
        {
            if (HasColumn(record, columnName))
            {
                var result = record[columnName] is DBNull
                ? default(T)
                : (T)(record[columnName]);

                return result;
            }
            return default(T);
        }

        /// <summary>
        /// The method checks for columns in DB record
        /// </summary>
        /// <param name="record">Record object to search for value </param>
        /// <param name="columnName"></param>
        /// <returns>Returns true if column is existed in record, otherwise - false</returns>
        private static bool HasColumn(IDataRecord record, string columnName)
        {
            for (var i = 0; i < record.FieldCount; i++)
            {
                if (string.Equals(record.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}