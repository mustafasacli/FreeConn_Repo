using System.Data;
using System.Data.Common;

namespace System.Turco
{
    public sealed class NsConnection : DbConnection
    {

        #region [ Private Fields ]

        private DbConnection dbConn = null;
        private NsConnectionTypes _connType = NsConnectionTypes.SqlServer;
        private DbProviderFactory _fact = null;

        #endregion


        #region [ NsConnection Ctors ]

        public NsConnection()
            : this(NsConnectionTypes.SqlServer, string.Empty)
        { }


        public NsConnection(string connectionString)
            : this(NsConnectionTypes.SqlServer, connectionString)
        { }

        public NsConnection(NsConnectionTypes connType)
            : this(connType, string.Empty)
        { }

        public NsConnection(NsConnectionTypes connType, string connectionString)
        {
            try
            {
                _connType = connType;

                _fact = GetFactory(_connType);

                dbConn = GetConn();

                if (string.Empty.Equals(connectionString) == false)
                    dbConn.ConnectionString = connectionString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        /* --------------------------------------- */

        #region [ Open method ]

        /// <summary>
        /// Opens Database Connection.
        /// </summary>
        public override void Open()
        {
            try
            {
                dbConn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ Close method ]

        /// <summary>
        /// Closes Connection with database.
        /// </summary>
        public override void Close()
        {
            try
            {
                dbConn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ BeginDbTransaction method ]

        /// <summary>
        /// Starts a database database transaction with specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">Specifies the isolation level for transaction.</param>
        /// <returns></returns>
        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            try
            {
                return dbConn.BeginTransaction(isolationLevel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ ChangeDatabase method ]

        /// <summary>
        /// Changes Database Name of NsConnection.
        /// </summary>
        /// <param name="databaseName">Database Name</param>
        public override void ChangeDatabase(string databaseName)
        {
            try
            {
                dbConn.ChangeDatabase(databaseName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ CreateDbCommand method ]

        /// <summary>
        /// Creates DbCommand object.
        /// </summary>
        /// <returns>Returns DbCommand object instance.</returns>
        protected override DbCommand CreateDbCommand()
        {
            try
            {
                return dbConn.CreateCommand();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetFactory method ]

        private DbProviderFactory GetFactory(NsConnectionTypes connType)
        {
            try
            {
                DbProviderFactory fact = DbProviderFactories.GetFactory(GetProviderName(connType));
                return fact;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetProviderName method ]

        private string GetProviderName(NsConnectionTypes connType)
        {
            try
            {
                string providerName = string.Empty;
                switch (connType)
                {
                    case NsConnectionTypes.SqlExpress:
                    case NsConnectionTypes.SqlServer:
                        providerName = "System.Data.SqlClient";
                        break;
                    case NsConnectionTypes.PostgreSql:
                        break;
                    case NsConnectionTypes.Oracle:
                        providerName = "System.Data.OracleClient";
                        break;
                    case NsConnectionTypes.MySQL:
                        break;
                    default:
                        break;
                }
                return providerName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetConn method ]

        private DbConnection GetConn()
        {
            try
            {
                return _fact.CreateConnection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion



        #region [ GetDataAdapter method ]

        /// <summary>
        /// Creates DbDataAdapter Object with specified NsConnectionType.
        /// </summary>
        /// <returns>DbDataAdapter object Instance.</returns>
        public DbDataAdapter GetDataAdapter()
        {
            try
            {
                return _fact.CreateDataAdapter();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        /* --------------------------------------- */

        #region [ ConnectionString Prpoerty ]

        /// <summary>
        /// Gets, Sets Connection String Of NsConnection.
        /// </summary>
        public override string ConnectionString
        {
            get
            {
                return dbConn.ConnectionString;
            }
            set
            {
                dbConn.ConnectionString = value;
            }
        }

        #endregion


        #region [ DataSource Property ]

        /// <summary>
        /// Gets DataSource Name Of NsConnection.
        /// </summary>
        public override string DataSource
        {
            get
            {
                try
                {
                    return dbConn.DataSource;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion


        #region [ Database Property ]
        /// <summary>
        /// Gets Database Name Of NsConnection.
        /// </summary>
        public override string Database
        {
            get
            {
                try
                {
                    return dbConn.Database;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion


        #region [ ServerVersion Property ]

        /// <summary>
        /// Gets Version Of Database Server.
        /// </summary>
        public override string ServerVersion
        {
            get
            {
                try
                {
                    return dbConn.ServerVersion;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion


        #region [ State Property ]

        /// <summary>
        /// Gets Connection State Of Database Connection.
        /// </summary>
        public override Data.ConnectionState State
        {
            get
            {
                try
                {
                    return dbConn.State;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion


        #region [ ConnectionType Property ]

        /// <summary>
        /// Gets ConnectionType Of NsConnection.
        /// </summary>
        public NsConnectionTypes ConnectionType
        {
            get
            { return _connType; }
        }

        #endregion

    }
}
