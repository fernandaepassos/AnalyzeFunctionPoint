using System;
using Framework.Reflection.InsertUpdateDelete;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Framework.Reflection.RastrearExcecao;
using System.Data.OracleClient;
using Framework.Seguranca;

namespace Framework.Reflection.AcessoBancoDados
{

    public static class AcessoBD
    {
        // Methods
        public static OracleConnection AbreConexaoOracle()
        {
            OracleConnection connection2;
            try
            {
                OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["Oracle"].ConnectionString);
                connection.Open();
                connection2 = connection;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção ! Não  foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            return connection2;
        }

        public static SqlConnection AbreConexaoSqlServer()
        {
            SqlConnection connection2;
            try
            {
                //string strConnectionStrings = ClsCRIPTOGRAFIA.Descriptografa(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString.Trim());
                string strConnectionStrings = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString.Trim();
                SqlConnection connection = new SqlConnection(strConnectionStrings);
                connection.Open();
                connection2 = connection;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção ! Não  foi possível  conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            return connection2;
        }

        public static string DefiniTipoBancoDados()
        {
            string str;
            try
            {
                if ((ConfigurationManager.ConnectionStrings[1].Name.ToUpper() == "SQLSERVER") || (ConfigurationManager.ConnectionStrings[2].Name.ToUpper() == "SQLSERVER"))
                {
                    return "SQLSERVER";
                }
                if ((ConfigurationManager.ConnectionStrings[0].Name.ToUpper() != "ORACLE") && !(ConfigurationManager.ConnectionStrings[1].Name.ToUpper() == "ORACLE"))
                {
                    throw new Exception("Atenção ! Não  foi possível definir o tipo de Banco de Dados para conexão.");
                }
                str = "ORACLE";
            }
            catch
            {
                throw new Exception("Atenção ! Não  foi possível definir o tipo de Banco de Dados para conexão.");
            }
            return str;
        }

        public static void DeleteRegistro(object objetoClasse, int id)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                DeleteSqlServer server = new DeleteSqlServer();
                SqlConnection con = null;
                try
                {
                    con = AbreConexaoSqlServer();
                    server.DeleteRegistro(objetoClasse, id, con);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                if (!(DefiniTipoBancoDados() == "ORACLE"))
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                DeleteOracle oracle = new DeleteOracle();
                try
                {
                    oracle.DeleteRegistro(objetoClasse, id);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void DeleteRegistro(object objetoClasse, int id, string nomeTela)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                DeleteSqlServer server = new DeleteSqlServer();
                SqlConnection con = null;
                try
                {
                    con = AbreConexaoSqlServer();
                    server.DeleteRegistro(objetoClasse, id, con, nomeTela);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                if (!(DefiniTipoBancoDados() == "ORACLE"))
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                DeleteOracle oracle = new DeleteOracle();
                try
                {
                    oracle.DeleteRegistro(objetoClasse, id, nomeTela);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void DeleteRegistroTransacao(object objetoClasse, int id, TransacaoBD con)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                DeleteSqlServer server = new DeleteSqlServer();
                try
                {
                    server.DeleteRegistroTransacao(objetoClasse, id, con.TransacaoSqlServer);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                if (!(DefiniTipoBancoDados() == "ORACLE"))
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                DeleteOracle oracle = new DeleteOracle();
                try
                {
                    oracle.DeleteRegistro(objetoClasse, id);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void DeleteRegistroTransacao(object objetoClasse, int id, TransacaoBD con, string nomeTela)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                DeleteSqlServer server = new DeleteSqlServer();
                try
                {
                    server.DeleteRegistroTransacao(objetoClasse, id, con.TransacaoSqlServer, nomeTela);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                if (!(DefiniTipoBancoDados() == "ORACLE"))
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                DeleteOracle oracle = new DeleteOracle();
                try
                {
                    oracle.DeleteRegistro(objetoClasse, id, nomeTela);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static void ExecutarComandoSql(string SqlComand)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                SqlConnection con = null;
                try
                {
                    con = AbreConexaoSqlServer();
                    ConexaoBDSqlServer.ExecutarComandoSql(SqlComand, con);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                if (!(DefiniTipoBancoDados() == "ORACLE"))
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                try
                {
                    ConexaoBDOracle.ExecutarComandoSql(SqlComand);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static object ExecutarComandoSqlEscalar(string SqlComand)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                SqlConnection con = null;
                try
                {
                    con = AbreConexaoSqlServer();
                    return ConexaoBDSqlServer.ExecutarComandoSqlEscalar(SqlComand, con);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
            }
            if (DefiniTipoBancoDados() == "ORACLE")
            {
                try
                {
                    return ConexaoBDOracle.ExecutarComandoSqlEscalar(SqlComand);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
            throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
        }

        public static object ExecutarComandoSqlEscalarTransacao(string SqlComand, TransacaoBD con)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                try
                {
                    return ConexaoBDSqlServer.ExecutarComandoSqlEscalarTransacao(SqlComand, con.TransacaoSqlServer);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
            }
            if (DefiniTipoBancoDados() == "ORACLE")
            {
                try
                {
                    return ConexaoBDOracle.ExecutarComandoSqlEscalar(SqlComand);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
            throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
        }

        public static void ExecutarComandoSqlTransacao(string SqlComand, TransacaoBD con)
        {
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                try
                {
                    ConexaoBDSqlServer.ExecutarComandoSqlTransacao(SqlComand, con.TransacaoSqlServer);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                if (!(DefiniTipoBancoDados() == "ORACLE"))
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                try
                {
                    ConexaoBDOracle.ExecutarComandoSql(SqlComand);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static int InsertUpdateRegistro(object objetoClasse, int id)
        {
            Exception exception;
            int num = 0;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                InsertUpdateSqlServer server = new InsertUpdateSqlServer();
                SqlConnection con = null;
                try
                {
                    try
                    {
                        con = AbreConexaoSqlServer();
                        num = server.InsertUpdateRegistro(objetoClasse, id, con);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        throw new Exception(exception.Message);
                    }
                    return num;
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                return num;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            InsertUpdateOracle oracle = new InsertUpdateOracle();
            try
            {
                num = oracle.InsertUpdateRegistro(objetoClasse, id);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public static int InsertUpdateRegistro(object objetoClasse, int id, string nomeTela)
        {
            Exception exception;
            int num = 0;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                InsertUpdateSqlServer server = new InsertUpdateSqlServer();
                SqlConnection con = null;
                try
                {
                    try
                    {
                        con = AbreConexaoSqlServer();
                        num = server.InsertUpdateRegistro(objetoClasse, id, con, nomeTela);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        throw new Exception(exception.Message);
                    }
                    return num;
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                return num;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            InsertUpdateOracle oracle = new InsertUpdateOracle();
            try
            {
                num = oracle.InsertUpdateRegistro(objetoClasse, id, nomeTela);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public static int InsertUpdateRegistroSemLog(object objetoClasse, int id)
        {
            Exception exception;
            int num = 0;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                InsertUpdateSqlServer server = new InsertUpdateSqlServer();
                SqlConnection con = null;
                try
                {
                    try
                    {
                        con = AbreConexaoSqlServer();
                        num = server.InsertUpdateRegistroSemLog(objetoClasse, id, con);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        throw new Exception(exception.Message);
                    }
                    return num;
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                return num;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            InsertUpdateOracle oracle = new InsertUpdateOracle();
            try
            {
                num = oracle.InsertUpdateRegistroSemLog(objetoClasse, id);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public static int InsertUpdateRegistroTransacao(object objetoClasse, int id, TransacaoBD con)
        {
            Exception exception;
            int num = 0;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                InsertUpdateSqlServer server = new InsertUpdateSqlServer();
                try
                {
                    num = server.InsertUpdateRegistroTransacao(objetoClasse, id, con.TransacaoSqlServer);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                return num;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            InsertUpdateOracle oracle = new InsertUpdateOracle();
            try
            {
                num = oracle.InsertUpdateRegistro(objetoClasse, id);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public static int InsertUpdateRegistroTransacao(object objetoClasse, int id, TransacaoBD con, string nomeTela)
        {
            Exception exception;
            int num = 0;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                InsertUpdateSqlServer server = new InsertUpdateSqlServer();
                try
                {
                    num = server.InsertUpdateRegistroTransacao(objetoClasse, id, con.TransacaoSqlServer, nomeTela);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                return num;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            InsertUpdateOracle oracle = new InsertUpdateOracle();
            try
            {
                num = oracle.InsertUpdateRegistro(objetoClasse, id, nomeTela);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public static int InsertUpdateRegistroTransacaoSemLog(object objetoClasse, int id, TransacaoBD con)
        {
            Exception exception;
            int num = 0;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                InsertUpdateSqlServer server = new InsertUpdateSqlServer();
                try
                {
                    num = server.InsertUpdateRegistroTransacaoSemLog(objetoClasse, id, con.TransacaoSqlServer);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                return num;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            InsertUpdateOracle oracle = new InsertUpdateOracle();
            try
            {
                num = oracle.InsertUpdateRegistroSemLog(objetoClasse, id);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public static DataSet ObterDataSet(string SqlComand)
        {
            DataSet set = null;
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                SqlConnection con = null;
                try
                {
                    try
                    {
                        con = AbreConexaoSqlServer();
                        set = ConexaoBDSqlServer.ObterDataset(SqlComand, con);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        throw new Exception(exception.Message);
                    }
                    return set;
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                return set;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            try
            {
                set = ConexaoBDOracle.ObterDataset(SqlComand);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return set;
        }

        public static DataSet ObterDataSetTransacao(string SqlComand, TransacaoBD con)
        {
            DataSet set = null;
            Exception exception;
            if (DefiniTipoBancoDados() == "SQLSERVER")
            {
                try
                {
                    set = ConexaoBDSqlServer.ObterDatasetTransacao(SqlComand, con.TransacaoSqlServer);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    throw new Exception(exception.Message);
                }
                return set;
            }
            if (!(DefiniTipoBancoDados() == "ORACLE"))
            {
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            try
            {
                set = ConexaoBDOracle.ObterDataset(SqlComand);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception(exception.Message);
            }
            return set;
        }
    }
}