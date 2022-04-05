using System;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Framework.Reflection.RastrearExcecao;


namespace Framework.Reflection.InsertUpdateDelete
{
    public static class ConexaoBDOracle
    {
        // Methods
        public static OracleConnection AbreConexao()
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
                throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
            }
            return connection2;
        }

        public static void ExecutarComandoSql(string sqlComand)
        {
            Exception exception;
            OracleConnection connection = AbreConexao();
            if (sqlComand.IndexOf("DELETE", 0) > 0)
            {
                try
                {
                    OracleCommand command = new OracleCommand(sqlComand, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    ToTrackException.ToTrack(exception);
                    throw new Exception("Atenção! O sistema encontrou problemas durante o processamento dos registros. Comunique ao Administrador do sistema.");
                }
            }
            else
            {
                try
                {
                    new OracleCommand(sqlComand, connection).ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    throw new Exception(exception.Message);
                }
            }
        }

        public static object ExecutarComandoSqlEscalar(string sqlComand)
        {
            object obj3;
            OracleConnection connection = AbreConexao();
            try
            {
                object obj2 = new OracleCommand(sqlComand, connection).ExecuteScalar();
                connection.Close();
                obj3 = obj2;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas durante o processamento dos registros. Comunique ao Administrador do sistema.");
            }
            return obj3;
        }

        public static DataSet ObterDataset(string sqlComand)
        {
            DataSet set2;
            OracleConnection selectConnection = AbreConexao();
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(sqlComand, selectConnection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                selectConnection.Close();
                set2 = dataSet;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas durante o processamento dos registros. Comunique ao Administrador do sistema.");
            }
            return set2;
        }
    }
}
