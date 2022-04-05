using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Framework.Reflection.RastrearExcecao;

namespace Framework.Reflection.InsertUpdateDelete
{
    public static class ConexaoBDSqlServer
    {
        // Methods
        public static void ExecutarComandoSql(string sqlComand, SqlConnection con)
        {
            if (!string.IsNullOrEmpty(sqlComand))
            {
                Exception exception;
                if (sqlComand.IndexOf("DELETE", 0) > 0)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlComand, con);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        ToTrackException.ToTrack(exception);
                        throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
                    }
                }
                else
                {
                    try
                    {
                        new SqlCommand(sqlComand, con).ExecuteNonQuery();
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        throw new Exception(exception.Message);
                    }
                }
            }
        }

        public static object ExecutarComandoSqlEscalar(string sqlComand, SqlConnection con)
        {
            object obj3;
            try
            {
                if (string.IsNullOrEmpty(sqlComand))
                {
                    return new object();
                }
                obj3 = new SqlCommand(sqlComand, con).ExecuteScalar();
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return obj3;
        }

        public static object ExecutarComandoSqlEscalarTransacao(string sqlComand, SqlTransaction con)
        {
            object obj3;
            try
            {
                if (string.IsNullOrEmpty(sqlComand))
                {
                    return new object();
                }
                SqlCommand command = con.Connection.CreateCommand();
                command.Transaction = con;
                command.CommandText = sqlComand;
                obj3 = command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return obj3;
        }

        public static void ExecutarComandoSqlTransacao(string sqlComand, SqlTransaction con)
        {
            if (!string.IsNullOrEmpty(sqlComand))
            {
                SqlCommand command;
                Exception exception;
                if (sqlComand.IndexOf("DELETE", 0) > 0)
                {
                    try
                    {
                        command = con.Connection.CreateCommand();
                        command.Transaction = con;
                        command.CommandText = sqlComand;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        ToTrackException.ToTrack(exception);
                        throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
                    }
                }
                else
                {
                    try
                    {
                        command = con.Connection.CreateCommand();
                        command.Transaction = con;
                        command.CommandText = sqlComand;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        throw new Exception(exception.Message);
                    }
                }
            }
        }

        public static DataSet ObterDataset(string sqlComand, SqlConnection con)
        {
            DataSet set2;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlComand, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                set2 = dataSet;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return set2;
        }

        public static DataSet ObterDatasetTransacao(string sqlComand, SqlTransaction con)
        {
            DataSet set2;
            try
            {
                DataSet dataSet = new DataSet();
                if (string.IsNullOrEmpty(sqlComand))
                {
                    return dataSet;
                }
                SqlCommand selectCommand = con.Connection.CreateCommand();
                selectCommand.Transaction = con;
                selectCommand.CommandText = sqlComand;
                new SqlDataAdapter(selectCommand).Fill(dataSet);
                set2 = dataSet;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return set2;
        }
    }
}
