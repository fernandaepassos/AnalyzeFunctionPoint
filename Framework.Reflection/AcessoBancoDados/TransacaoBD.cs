using System;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using Framework.Seguranca;

namespace Framework.Reflection.AcessoBancoDados
{
    public class TransacaoBD
    {
        // Fields
        private OracleConnection _conexaoOracle;
        private SqlConnection _conexaoSqlServer;
        private OracleTransaction _transacaoOracle;
        private SqlTransaction _transacaoSqlServer;

        // Methods
        private byte DefiniTipoTransacao()
        {
            if ((ConfigurationManager.ConnectionStrings[0].Name.ToUpper() == "SQLSERVER") || (ConfigurationManager.ConnectionStrings[1].Name.ToUpper() == "SQLSERVER"))
            {
                return 1;
            }
            if ((ConfigurationManager.ConnectionStrings[0].Name.ToUpper() == "ORACLE") || (ConfigurationManager.ConnectionStrings[1].Name.ToUpper() == "ORACLE"))
            {
                return 2;
            }
            return 0;
        }

        public void DesfazTransacao()
        {
            try
            {
                switch (this.DefiniTipoTransacao())
                {
                    case 1:
                        if (this._transacaoSqlServer.Connection.State == ConnectionState.Open)
                        {
                            this._transacaoSqlServer.Rollback();
                        }
                        if (this._conexaoSqlServer.State == ConnectionState.Open)
                        {
                            this._conexaoSqlServer.Close();
                        }
                        break;

                    case 2:
                        if (this._transacaoOracle.Connection.State == ConnectionState.Open)
                        {
                            this._transacaoOracle.Rollback();
                        }
                        if (this._conexaoOracle.State == ConnectionState.Open)
                        {
                            this._conexaoOracle = AcessoBD.AbreConexaoOracle();
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void FechaTransacao()
        {
            try
            {
                switch (this.DefiniTipoTransacao())
                {
                    case 1:
                        if (this._transacaoSqlServer.Connection.State == ConnectionState.Open)
                        {
                            this._transacaoSqlServer.Commit();
                        }
                        if (this._conexaoSqlServer.State == ConnectionState.Open)
                        {
                            this._conexaoSqlServer.Close();
                        }
                        break;

                    case 2:
                        if (this._transacaoOracle.Connection.State == ConnectionState.Open)
                        {
                            this._transacaoOracle = this._conexaoOracle.BeginTransaction();
                        }
                        if (this._conexaoOracle.State == ConnectionState.Open)
                        {
                            this._conexaoOracle = AcessoBD.AbreConexaoOracle();
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void IniciaTransacao()
        {
            try
            {
                switch (this.DefiniTipoTransacao())
                {
                    case 1:
                        this._conexaoSqlServer = AcessoBD.AbreConexaoSqlServer();
                        this._transacaoSqlServer = this._conexaoSqlServer.BeginTransaction(IsolationLevel.ReadCommitted);
                        break;

                    case 2:
                        this._conexaoOracle = AcessoBD.AbreConexaoOracle();
                        this._transacaoOracle = this._conexaoOracle.BeginTransaction(IsolationLevel.ReadCommitted);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool TransacaoAtiva()
        {
            bool flag2;
            try
            {
                bool flag = false;
                switch (this.DefiniTipoTransacao())
                {
                    case 1:
                        if (this._transacaoSqlServer == null)
                        {
                            return false;
                        }
                        if (this._transacaoSqlServer.Connection == null)
                        {
                            return false;
                        }
                        flag = this._transacaoSqlServer.Connection.State == ConnectionState.Open;
                        break;

                    case 2:
                        if (this._transacaoOracle == null)
                        {
                            return false;
                        }
                        if (this._transacaoOracle.Connection == null)
                        {
                            return false;
                        }
                        flag = this._transacaoOracle.Connection.State == ConnectionState.Open;
                        break;
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag2;
        }

        // Properties
        public OracleConnection ConexaoOracle
        {
            get
            {
                return this._conexaoOracle;
            }
            set
            {
                this._conexaoOracle = value;
            }
        }

        public SqlConnection ConexaoSqlServer
        {
            get
            {
                return this._conexaoSqlServer;
            }
            set
            {
                this._conexaoSqlServer = value;
            }
        }

        public OracleTransaction TransacaoOracle
        {
            get
            {
                return this._transacaoOracle;
            }
            set
            {
                this._transacaoOracle = value;
            }
        }

        public SqlTransaction TransacaoSqlServer
        {
            get
            {
                return this._transacaoSqlServer;
            }
            set
            {
                this._transacaoSqlServer = value;
            }
        }
    }
} 
