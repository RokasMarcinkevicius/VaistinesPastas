using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;
using VaistinesPastas.Repository.Models;

namespace VaistinesPastas.Repository.Data
{
    public class LogSQLQueriesInterceptor : DbCommandInterceptor
    {
        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            // disable LogQueryDetails before initial generation of the database
            /**/
            LogQueryDetails(command, eventData.Duration.TotalMilliseconds);
            /**/
            return base.ReaderExecuted(command, eventData, result);
        }

        private void LogQueryDetails(DbCommand command, double totalMiliseconds)
        {
            
            if(!command.CommandText.Contains(nameof(QueryLog)))
            {
                var queryLog = new QueryLog()
                {
                    Date = DateTime.Now,
                    User = "Test",
                    DurationInMilliseconds = totalMiliseconds,
                    QueryText = command.CommandText,
                    QueryParameters = command.Parameters.ToString(), // TODO
                    TableChanged = command.CommandText, // TODO
                    QueryType = command.CommandText, // TODO
                };

                var context = new PastoIndeksaiContext();
                context.QueryLog.Add(queryLog);
                context.SaveChanges();
            }
        }
    }
}
