using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LinkManager.DAL.Abstraction.Repository
{
    /// <summary>
    /// Declares methods for GenericRepository class
    /// </summary>
    /// <typeparam name="TEntity">Type of the model</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Executes database query
        /// </summary>
        /// <param name="spName">Name of the SP</param>
        /// <param name="callbackParser">Function for parsing results</param>
        /// <param name="parameters">Parameters for executing queury</param>
        /// <returns>List of TEntity</returns>
        IEnumerable<TEntity> ExecuteReader(string spName, Func<SqlDataReader, TEntity> callbackParser,
           SqlParameter[] parameters = null);
    }
}