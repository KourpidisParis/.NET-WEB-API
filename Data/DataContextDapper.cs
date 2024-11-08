using System.Data;
using System.Reflection.Metadata.Ecma335;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DotnetAPI.Data
{
    class DataContextDapper{
        private readonly IConfiguration _config;  

        public DataContextDapper(IConfiguration config){
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql){
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql);
        }
        public T LoadDataSingle<T>(string sql){
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql);
        }
    }
}