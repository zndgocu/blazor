using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ramfree.EntityHelper
{
    public class EntityConverter
    {
        public static List<T> GetEntites<T>(DataTable dt) where T : class, new()
        {
            List<T> entities = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T entity = GetEntity<T>(row);
                if(entity != null)
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }
        public static T GetEntity<T>(DataRow dr) where T : class, new()
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                        {
                            if(dr[column.ColumnName].GetType() != typeof(DBNull))
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                            break;
                        }
                        else
                            continue;
                    }
                }
                return obj;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
