using System;
using System.Data.SqlClient;

using MassTransit;

using PetaPoco;

namespace SampleSOA.PatientOrderService
{
    public abstract class TransactionalMessageHandler<TMessage> : Consumes<TMessage>.All
        where TMessage : class
    {
        protected virtual bool RetryOnCheckConstraintFailure
        {
            get
            {
                return false;
            }
        }

        public void Consume(TMessage message)
        {
            Database database = null;
            try
            {
                database = new Database(string.Empty);
                database.BeginTransaction();

                Consume(message, database);

                database.CompleteTransaction();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException)
                {
                    if (!HandleSqlException(ex))
                    {
                        throw;
                    }
                }
                else
                {
                    if (database != null)
                    {
                        database.AbortTransaction();
                    }
                    throw;
                }
            }
            finally
            {
                if (database != null)
                {
                    database.Dispose();
                }
            }
        }

        private bool HandleSqlException(Exception ex)
        {
            int errorCode = ((SqlException)ex.InnerException).Number;

            switch (errorCode)
            {
                case 1205: // DB Deadlock
                case 8650: // DB Deadlock
                case -2: // Database Timeout
                    
                    this.MessageContext().RetryLater();
                    break;

                case 547:

                    // Check Constraint Conflict
                    if (RetryOnCheckConstraintFailure)
                    {
                        this.MessageContext().RetryLater();
                    }
                    else
                    {
                        return false;
                    }
                    break;

                default:
                    return false;
            }

            return true;
        }

        protected abstract void Consume(TMessage message, 
            Database database);
    }
}