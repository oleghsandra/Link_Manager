using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LinkManager.DAL.Abstraction.Repository;
using LinkManager.DAL.Concrete.SQL;

namespace LinkManager.DAL.Concrete.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly SqlCommandWrapper _sqlWrapper;

        public GenericRepository(string connection)
        {
            _sqlWrapper = new SqlCommandWrapper(connection);
        }

        public SqlCommandWrapper SqlWrapper
        {
            get { return _sqlWrapper; }
        }

        public IEnumerable<TEntity> ExecuteReader(
            string spName,
            Func<SqlDataReader, TEntity> callback,
            SqlParameter[] parameters = null)
        {
            return (IEnumerable<TEntity>)SqlWrapper.ExecuteReader(spName, parameters, callback);
        }

        /// <summary>
        /// Method for getting all TEntity models 
        /// </summary>
        /// <returns>List of TEntity</returns>
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}