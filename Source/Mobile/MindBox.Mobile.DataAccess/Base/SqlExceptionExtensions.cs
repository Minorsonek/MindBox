﻿using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;

namespace MindBox.Mobile.DataAccess
{
    /// <summary>
    /// Base class for basic SQL-related error handling
    /// </summary>
    public static class SqlExceptionExtensions
    {
        public static bool ForeginKeyViolation(this SqlException ex)
        {
            return ex.Errors.OfType<SqlError>()
                .Any(sq => sq.Number == 574);
        }

        public static bool ForeginKeyViolation(this DbUpdateException ex)
        {
            var uEx = ex.InnerException as DbUpdateException;
            if(uEx != null)
            {
                var sqlEx = uEx.InnerException as SqlException;
                return sqlEx != null && sqlEx.ForeginKeyViolation();
            }

            return false;
        }
    }
}
