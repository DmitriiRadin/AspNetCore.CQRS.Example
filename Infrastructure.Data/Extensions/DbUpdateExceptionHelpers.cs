using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Extensions
{
    public static class DbUpdateExceptionHelpers
    {
        private const int DuplicateNumber = 2601;
        private const int RequiredFiled = 515;

        public static bool IsConflict(this DbUpdateException exception) => exception.IsError(DuplicateNumber);

        public static bool IsInsertingNullInRequiredField(this DbUpdateException exception) => exception.IsError(RequiredFiled);

        private static bool IsError(this Exception exception, int errorNumber)
        {
            return exception.InnerException is SqlException sqlException && sqlException.Number == errorNumber;
        }
    }
}