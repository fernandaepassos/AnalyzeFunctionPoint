using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Framework.Reflection.RastrearExcecao;
using System.Data.SqlClient;

namespace Framework.Reflection.InsertUpdateDelete
{
    public class DeleteSqlServer
    {
        // Methods
        public void DeleteRegistro(object objetoClasse, int id, SqlConnection con)
        {
            int num = id;
            string strNomeTabela = objetoClasse.GetType().Name.ToString();
            try
            {
                List<ItensPersistenciaSqlServer> list = new List<ItensPersistenciaSqlServer>();
                DataSet set = ConexaoBDSqlServer.ObterDataset("SELECT * FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; set.Tables[0].Columns.Count > i; i++)
                    {
                        list.Add(new ItensPersistenciaSqlServer(set.Tables[0].Columns[i].ColumnName.ToString(), set.Tables[0].Rows[0].ItemArray[i]));
                    }
                }
                ConexaoBDSqlServer.ExecutarComandoSql("DELETE FROM " + this.GetNomeTabela(strNomeTabela.Trim()) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela.Trim()) + " = " + num.ToString(), con);
            }
            catch (Exception exception)
            {
                if ((exception.Message.ToString().IndexOf("integri", 0) > 0) || (exception.Message.ToString().IndexOf("REFERENCE", 0) > 0))
                {
                    throw new Exception("Não é possível excluir este registro pois esta sendo utilizado em outro local do sistema.");
                }
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao excluir o registro. Comunique ao Administrador do sistema.");
            }
        }

        public void DeleteRegistro(object objetoClasse, int id, SqlConnection con, string nomeTela)
        {
            int num = id;
            string strNomeTabela = objetoClasse.GetType().Name.ToString();
            string str3 = "";
            try
            {
                List<ItensPersistenciaSqlServer> list = new List<ItensPersistenciaSqlServer>();
                DataSet set = ConexaoBDSqlServer.ObterDataset("SELECT * FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; set.Tables[0].Columns.Count > i; i++)
                    {
                        list.Add(new ItensPersistenciaSqlServer(set.Tables[0].Columns[i].ColumnName.ToString(), set.Tables[0].Rows[0].ItemArray[i]));
                    }
                }
                ConexaoBDSqlServer.ExecutarComandoSql("DELETE FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                //str3 = "INSERT INTO LogAuditoria (Origem, NomeTabela, IdUsuario, Acao, Registro, NomeTela, DataLog) ";
                //string str4 = str3;
                //str3 = str4 + "VALUES ('SISTEMA', '" + this.GetNomeTabela(strNomeTabela) + "'," + HttpContext.Current.Session["IdUsuario"].ToString() + ",'EXCLUSÃO','";
                //foreach (ItensPersistenciaSqlServer server in list)
                //{
                //    str3 = str3 + server.GetColumnValueExpression().Replace("'", "");
                //    str3 = str3 + ", ";
                //}
                //str4 = str3.Substring(0, str3.Length - 2);

                //ConexaoBDSqlServer.ExecutarComandoSql(str4 + "','" + nomeTela + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')", con);
            }
            catch (Exception exception)
            {
                if ((exception.Message.ToString().IndexOf("integri", 0) > 0) || (exception.Message.ToString().IndexOf("REFERENCE", 0) > 0))
                {
                    throw new Exception("Não é possível excluir este registro pois esta sendo utilizado em outro local do sistema.");
                }
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao excluir o registro. Comunique ao Administrador do sistema.");
            }
        }

        public void DeleteRegistroTransacao(object objetoClasse, int id, SqlTransaction con)
        {
            int num = id;
            string strNomeTabela = objetoClasse.GetType().Name.ToString();
            //string str3 = "";
            try
            {
                List<ItensPersistenciaSqlServer> list = new List<ItensPersistenciaSqlServer>();
                DataSet set = ConexaoBDSqlServer.ObterDatasetTransacao("SELECT * FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; set.Tables[0].Columns.Count > i; i++)
                    {
                        list.Add(new ItensPersistenciaSqlServer(set.Tables[0].Columns[i].ColumnName.ToString(), set.Tables[0].Rows[0].ItemArray[i]));
                    }
                }
                ConexaoBDSqlServer.ExecutarComandoSqlTransacao("DELETE FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                //str3 = "INSERT INTO LogAuditoria (Origem, NomeTabela, IdUsuario, Acao, Registro, DataLog) ";
                //string str4 = str3;
                //str3 = str4 + "VALUES ('SISTEMA', '" + this.GetNomeTabela(strNomeTabela) + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'EXCLUSÃO','";
                //foreach (ItensPersistenciaSqlServer server in list)
                //{
                //    str3 = str3 + server.GetColumnValueExpression().Replace("'", "");
                //    str3 = str3 + ", ";
                //}
                //ConexaoBDSqlServer.ExecutarComandoSqlTransacao(str3.Substring(0, str3.Length - 2) + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')", con);
            }
            catch (Exception exception)
            {
                if ((exception.Message.ToString().IndexOf("integri", 0) > 0) || (exception.Message.ToString().IndexOf("REFERENCE", 0) > 0))
                {
                    throw new Exception("Não é possível excluir este registro pois esta sendo utilizado em outro local do sistema.");
                }
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao excluir o registro. Comunique ao Administrador do sistema.");
            }
        }

        public void DeleteRegistroTransacao(object objetoClasse, int id, SqlTransaction con, string nomeTela)
        {
            int num = id;
            string strNomeTabela = objetoClasse.GetType().Name.ToString();
            string str3 = "";
            try
            {
                List<ItensPersistenciaSqlServer> list = new List<ItensPersistenciaSqlServer>();
                DataSet set = ConexaoBDSqlServer.ObterDatasetTransacao("SELECT * FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; set.Tables[0].Columns.Count > i; i++)
                    {
                        list.Add(new ItensPersistenciaSqlServer(set.Tables[0].Columns[i].ColumnName.ToString(), set.Tables[0].Rows[0].ItemArray[i]));
                    }
                }
                ConexaoBDSqlServer.ExecutarComandoSqlTransacao("DELETE FROM " + this.GetNomeTabela(strNomeTabela) + " WHERE  " + this.GetNomeDoCampoId(strNomeTabela) + " = " + num.ToString(), con);
                //str3 = "INSERT INTO LogAuditoria (Origem, NomeTabela, IdUsuario, Acao, Registro, NomeTela, DataLog) ";
                //string str4 = str3;
                //str3 = str4 + "VALUES ('SISTEMA', '" + this.GetNomeTabela(strNomeTabela) + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'EXCLUSÃO','";
                //foreach (ItensPersistenciaSqlServer eserver in list)
                //{
                //    str3 = str3 + server.GetColumnValueExpression().Replace("'", "");
                //    str3 = str3 + ", ";
                //}
                //str4 = str3.Substring(0, str3.Length - 2);
                //ConexaoBDSqlServer.ExecutarComandoSqlTransacao(str4 + "','" + nomeTela + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')", con);
            }
            catch (Exception exception)
            {
                if ((exception.Message.ToString().IndexOf("integri", 0) > 0) || (exception.Message.ToString().IndexOf("REFERENCE", 0) > 0))
                {
                    throw new Exception("Não é possível excluir este registro pois esta sendo utilizado em outro local do sistema.");
                }
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao excluir o registro. Comunique ao Administrador do sistema.");
            }
        }

        private string GetNomeDoCampoId(string strNomeTabela)
        {
            if (strNomeTabela.Trim().Substring(0, 3).ToLower().Trim().ToLower() == "cls")
            {
                return ("Id" + strNomeTabela.Trim().Substring(3, strNomeTabela.Trim().Length - 3));
            }
            return ("Id" + strNomeTabela);
        }

        private string GetNomeTabela(string strNomeTabela)
        {
            if (strNomeTabela.Trim().Substring(0, 3).Trim().ToLower() == "cls")
            {
                return strNomeTabela.Trim().Substring(3, strNomeTabela.Trim().Length - 3);
            }
            return strNomeTabela;
        }
    }
}
 
