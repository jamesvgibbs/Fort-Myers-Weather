using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FMWeatherAPI.Interfaces
{
    interface ISqlDataContext
    {
        IDataReader ExecuteReader(string storedProcedureName, ICollection<SqlParameter> parameters);
    }
}
