using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Framework.Reflection.RastrearExcecao;

namespace Framework.Reflection.InsertUpdateDelete
{
    public class DeleteOracle
    {
        // Methods
        public void DeleteRegistro(object objetoClasse, int id)
        {
            int num = id;
            string str = objetoClasse.GetType().Name.ToString();
            string str3 = "";
            try
            {
                List<ItensPersistenciaOracle> list = new List<ItensPersistenciaOracle>();
                DataSet set = ConexaoBDOracle.ObterDataset("SELECT * FROM " + str + " WHERE  Id" + str + " = " + num.ToString());
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; set.Tables[0].Columns.Count > i; i++)
                    {
                        list.Add(new ItensPersistenciaOracle(set.Tables[0].Columns[i].ColumnName.ToString(), set.Tables[0].Rows[0].ItemArray[i]));
                    }
                }
                ConexaoBDOracle.ExecutarComandoSql("DELETE FROM " + str + " WHERE  Id" + str + " = " + num.ToString());
                str3 = "INSERT INTO LogAuditoria (IdLogAuditoria, Origem, NomeTabela, IdUsuario, Acao, Registro, DataLog) ";
                string str4 = str3;
                str3 = str4 + "VALUES (IdLogAuditoria.Nextval,'SISTEMA', '" + str + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'EXCLUSÃO','";
                foreach (ItensPersistenciaOracle oracle in list)
                {
                    str3 = str3 + oracle.GetColumnValueExpression().Replace("'", "");
                    str3 = str3 + ", ";
                }
                ConexaoBDOracle.ExecutarComandoSql(str3.Substring(0, str3.Length - 2) + "',to_date('" + Convert.ToString(DateTime.Now) + "','DD/MM/YYYY HH24:MI:SS'))");
            }
            catch (Exception exception)
            {
                if (exception.Message.ToString().IndexOf("integri", 0) > 0)
                {
                    throw new Exception("Não é possível excluir este registro pois esta sendo utilizado em outro local do sistema. ID = " + id.ToString());
                }
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas ao excluir o registro. Comunique ao Administrador do sistema.");
            }
        }

        public void DeleteRegistro(object objetoClasse, int id, string nomeTela)
        {
            int num = id;
            string str = objetoClasse.GetType().Name.ToString();
            string str3 = "";
            try
            {
                List<ItensPersistenciaOracle> list = new List<ItensPersistenciaOracle>();
                DataSet set = ConexaoBDOracle.ObterDataset("SELECT * FROM " + str + " WHERE  Id" + str + " = " + num.ToString());
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; set.Tables[0].Columns.Count > i; i++)
                    {
                        list.Add(new ItensPersistenciaOracle(set.Tables[0].Columns[i].ColumnName.ToString(), set.Tables[0].Rows[0].ItemArray[i]));
                    }
                }
                ConexaoBDOracle.ExecutarComandoSql("DELETE FROM " + str + " WHERE  Id" + str + " = " + num.ToString());
                str3 = "INSERT INTO LogAuditoria (IdLogAuditoria, Origem, NomeTabela, IdUsuario, Acao, Registro, NomeTela, DataLog) ";
                string str4 = str3;
                str3 = str4 + "VALUES (IdLogAuditoria.Nextval,'SISTEMA', '" + str + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'EXCLUSÃO','";
                foreach (ItensPersistenciaOracle oracle in list)
                {
                    str3 = str3 + oracle.GetColumnValueExpression().Replace("'", "");
                    str3 = str3 + ", ";
                }
                str4 = str3.Substring(0, str3.Length - 2);
                ConexaoBDOracle.ExecutarComandoSql(str4 + "','" + nomeTela + "',to_date('" + Convert.ToString(DateTime.Now) + "','DD/MM/YYYY HH24:MI:SS'))");
            }
            catch (Exception exception)
            {
                if (exception.Message.ToString().IndexOf("integri", 0) > 0)
                {
                    throw new Exception("Não é possível excluir este registro pois esta sendo utilizado em outro local do sistema. ID = " + id.ToString());
                }
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas ao excluir o registro. Comunique ao Administrador do sistema.");
            }
        }
    }
}
