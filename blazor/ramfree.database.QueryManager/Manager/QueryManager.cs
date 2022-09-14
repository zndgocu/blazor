using Microsoft.Extensions.Configuration;
using Npgsql;
using ramfree.database.QueryManager.Interface;
using ramfree.database.QueryManager.Result;
using ramfree.EntityHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ramfree.database.QueryManager.Manager
{
    public class QueryManager : IQueryManager
    {

        protected IConfiguration Config;
        public QueryManager(IConfiguration config)
        {
            Config = config;
        }

        public string GetConnectionString()
        {
            string useDbPropName = Config.GetConnectionString("UseDb");
            string connectionString = Config.GetConnectionString(useDbPropName);
            return connectionString;
        }


        public int GetTimeOut()
        {
            return Convert.ToInt32(Config.GetSection("DataBaseProperties").GetSection("TimeOut").Value);
        }

        public QueryManagerResult<T> ExcuteQuery<T>(string qry) where T : class, new()
        {
            QueryManagerResult<T> result = new QueryManagerResult<T>();
            try
            {
                DataTable dt = new DataTable();
                string connectionString = GetConnectionString();

                using (NpgsqlConnection cn = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(qry, cn))
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        cmd.CommandText = qry;
                        cmd.CommandTimeout = GetTimeOut();
                        DbDataReader dr;
                        dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                }
                result.SetOk(EntityConverter.GetEntites<T>(dt));
            }
            catch (Exception exAll)
            {
                result.SetFail(exAll.Message);
            }
            return result;
        }

    }
}
