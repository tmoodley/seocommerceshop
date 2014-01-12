using System; 
using System.Data;
using System.Data.Common;
using System.Configuration; 
using System.Collections;
using System.ComponentModel; 
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;

namespace seoWebApplication
{
    public class OrdersAccess
    {
        public OrdersAccess()
            {
            //
            // TODO: Add constructor logic here
            //
            }

        // Retrieve the recent orders
        public static DataTable GetByRecent(int count)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "OrdersGetByRecent";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Count";
            param.Value = count;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // return the result table
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            return table;
        }

        // Retrieve orders that have been placed in a specified period of time
        public static DataTable GetByDate(string startDate, string endDate)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "OrdersGetByDate";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@StartDate";
        param.Value = startDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@EndDate";
        param.Value = endDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);
        // return the result table
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
        }

        // Retrieve orders that need to be verified or canceled
        public static DataTable GetUnverifiedUncanceled()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "OrdersGetUnverifiedUncanceled";
            // return the result table
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            return table;
        }

        // Retrieve orders that need to be shipped/completed
        public static DataTable GetVerifiedUncompleted()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "OrdersGetVerifiedUncompleted";
            // return the result table
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            return table;
        }
 
    }

   
}
