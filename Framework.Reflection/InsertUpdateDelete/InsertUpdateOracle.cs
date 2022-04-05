using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using Framework.Reflection.RastrearExcecao;


namespace Framework.Reflection.InsertUpdateDelete
{

    public class InsertUpdateOracle
    {
        // Methods
        public int InsertUpdateRegistro(object objetoClasse, int id)
        {
            PropertyInfo property = null;
            PropertyInfo[] properties = objetoClasse.GetType().GetProperties();
            List<ItensPersistenciaOracle> list = new List<ItensPersistenciaOracle>();
            foreach (PropertyInfo info2 in properties)
            {
                property = objetoClasse.GetType().GetProperty(info2.Name);
                AtributoBancoDados dados = (AtributoBancoDados) objetoClasse.GetType().GetProperty(info2.Name).GetCustomAttributes(typeof(AtributoBancoDados), true).GetValue(0);
                if (dados.AtributoBD)
                {
                    list.Add(new ItensPersistenciaOracle(info2.Name, property.GetValue(objetoClasse, null)));
                }
            }
            int num = id;
            string str = objetoClasse.GetType().Name.ToString();
            string str2 = "";
            foreach (ItensPersistenciaOracle oracle in list)
            {
                str2 = str2 + oracle.Nome + " ,";
            }
            str2 = str2.Substring(0, str2.Length - 2);
            string str3 = "";
            bool flag = false;
            foreach (ItensPersistenciaOracle oracle in list)
            {
                if (!flag)
                {
                    str3 = str3 + "Id" + str + ".Nextval, ";
                    flag = true;
                }
                else
                {
                    str3 = str3 + oracle.FormatValueForSqlSyntax() + ", ";
                }
            }
            str3 = str3.Substring(0, str3.Length - 2);
            string str4 = "";
            string str5 = "";
            try
            {
                string str6;
                if (num > 0)
                {
                    bool flag2 = false;
                    str4 = "UPDATE " + str + " SET ";
                    foreach (ItensPersistenciaOracle oracle in list)
                    {
                        if (!flag2)
                        {
                            flag2 = true;
                        }
                        else
                        {
                            str4 = str4 + oracle.GetColumnValueExpression();
                            str4 = str4 + ", ";
                        }
                    }
                    object obj2 = str4.Substring(0, str4.Length - 2);
                    ConexaoBDOracle.ExecutarComandoSql(string.Concat(new object[] { obj2, " WHERE Id", str, " = ", num }));
                    str5 = "INSERT INTO LogAuditoria (IdLogAuditoria, Origem, NomeTabela, IdUsuario, Acao, Registro, DataLog) ";
                    str6 = str5;
                    str5 = str6 + "VALUES (IdLogAuditoria.Nextval,'SISTEMA', '" + str + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'ALTERAÇÃO','";
                    foreach (ItensPersistenciaOracle oracle in list)
                    {
                        str5 = str5 + oracle.GetColumnValueExpression().Replace("'", "");
                        str5 = str5 + ", ";
                    }
                    ConexaoBDOracle.ExecutarComandoSql(str5.Substring(0, str5.Length - 2) + "',to_date('" + Convert.ToString(DateTime.Now) + "','DD/MM/YYYY HH24:MI:SS'))");
                    return num;
                }
                ConexaoBDOracle.ExecutarComandoSqlEscalar(((("INSERT INTO " + str + " ") + "(" + str2 + ")") + " VALUES ") + "(" + str3 + ")");
                num = Convert.ToInt32(ConexaoBDOracle.ExecutarComandoSqlEscalar("SELECT Id" + str + ".currval from dual"));
                str5 = "INSERT INTO LogAuditoria (IdLogAuditoria, Origem, NomeTabela, IdUsuario, Acao, Registro, DataLog) ";
                str6 = str5;
                str5 = str6 + "VALUES (IdLogAuditoria.Nextval,'SISTEMA','" + str + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'INCLUSÃO','";
                foreach (ItensPersistenciaOracle oracle in list)
                {
                    str5 = str5 + oracle.GetColumnValueExpression().Replace("'", "");
                    str5 = str5 + ", ";
                }
                ConexaoBDOracle.ExecutarComandoSql(str5.Substring(0, str5.Length - 2) + "',to_date('" + Convert.ToString(DateTime.Now) + "','DD/MM/YYYY HH24:MI:SS'))");
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas ao atualizar o registro.Comunique ao Administrador do sistema.");
            }
            return num;
        }

        public int InsertUpdateRegistro(object objetoClasse, int id, string nomeTela)
        {
            PropertyInfo property = null;
            PropertyInfo[] properties = objetoClasse.GetType().GetProperties();
            List<ItensPersistenciaOracle> list = new List<ItensPersistenciaOracle>();
            foreach (PropertyInfo info2 in properties)
            {
                property = objetoClasse.GetType().GetProperty(info2.Name);
                AtributoBancoDados dados = (AtributoBancoDados) objetoClasse.GetType().GetProperty(info2.Name).GetCustomAttributes(typeof(AtributoBancoDados), true).GetValue(0);
                if (dados.AtributoBD)
                {
                    list.Add(new ItensPersistenciaOracle(info2.Name, property.GetValue(objetoClasse, null)));
                }
            }
            int num = id;
            string str = objetoClasse.GetType().Name.ToString();
            string str2 = "";
            foreach (ItensPersistenciaOracle oracle in list)
            {
                str2 = str2 + oracle.Nome + " ,";
            }
            str2 = str2.Substring(0, str2.Length - 2);
            string str3 = "";
            bool flag = false;
            foreach (ItensPersistenciaOracle oracle in list)
            {
                if (!flag)
                {
                    str3 = str3 + "Id" + str + ".Nextval, ";
                    flag = true;
                }
                else
                {
                    str3 = str3 + oracle.FormatValueForSqlSyntax() + ", ";
                }
            }
            str3 = str3.Substring(0, str3.Length - 2);
            string str4 = "";
            string str5 = "";
            try
            {
                string str6;
                if (num > 0)
                {
                    bool flag2 = false;
                    str4 = "UPDATE " + str + " SET ";
                    foreach (ItensPersistenciaOracle oracle in list)
                    {
                        if (!flag2)
                        {
                            flag2 = true;
                        }
                        else
                        {
                            str4 = str4 + oracle.GetColumnValueExpression();
                            str4 = str4 + ", ";
                        }
                    }
                    object obj2 = str4.Substring(0, str4.Length - 2);
                    ConexaoBDOracle.ExecutarComandoSql(string.Concat(new object[] { obj2, " WHERE Id", str, " = ", num }));
                    str5 = "INSERT INTO LogAuditoria (IdLogAuditoria, Origem, NomeTabela, IdUsuario, Acao, Registro, NomeTela, DataLog) ";
                    str6 = str5;
                    str5 = str6 + "VALUES (IdLogAuditoria.Nextval,'SISTEMA', '" + str + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'ALTERAÇÃO','";
                    foreach (ItensPersistenciaOracle oracle in list)
                    {
                        str5 = str5 + oracle.GetColumnValueExpression().Replace("'", "");
                        str5 = str5 + ", ";
                    }
                    str6 = str5.Substring(0, str5.Length - 2);
                    ConexaoBDOracle.ExecutarComandoSql(str6 + "','" + nomeTela + "',to_date('" + Convert.ToString(DateTime.Now) + "','DD/MM/YYYY HH24:MI:SS'))");
                    return num;
                }
                ConexaoBDOracle.ExecutarComandoSqlEscalar(((("INSERT INTO " + str + " ") + "(" + str2 + ")") + " VALUES ") + "(" + str3 + ")");
                num = Convert.ToInt32(ConexaoBDOracle.ExecutarComandoSqlEscalar("SELECT Id" + str + ".currval from dual"));
                str5 = "INSERT INTO LogAuditoria (IdLogAuditoria, Origem, NomeTabela, IdUsuario, Acao, Registro, NomeTela, DataLog) ";
                str6 = str5;
                str5 = str6 + "VALUES (IdLogAuditoria.Nextval,'SISTEMA','" + str + "'," + HttpContext.Current.Session["idUsuarioLog"].ToString() + ",'INCLUSÃO','";
                foreach (ItensPersistenciaOracle oracle in list)
                {
                    str5 = str5 + oracle.GetColumnValueExpression().Replace("'", "");
                    str5 = str5 + ", ";
                }
                str6 = str5.Substring(0, str5.Length - 2);
                ConexaoBDOracle.ExecutarComandoSql(str6 + "','" + nomeTela + "',to_date('" + Convert.ToString(DateTime.Now) + "','DD/MM/YYYY HH24:MI:SS'))");
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas ao atualizar o registro.Comunique ao Administrador do sistema.");
            }
            return num;
        }

        public int InsertUpdateRegistroSemLog(object objetoClasse, int id)
        {
            PropertyInfo property = null;
            PropertyInfo[] properties = objetoClasse.GetType().GetProperties();
            List<ItensPersistenciaOracle> list = new List<ItensPersistenciaOracle>();
            foreach (PropertyInfo info2 in properties)
            {
                property = objetoClasse.GetType().GetProperty(info2.Name);
                AtributoBancoDados dados = (AtributoBancoDados) objetoClasse.GetType().GetProperty(info2.Name).GetCustomAttributes(typeof(AtributoBancoDados), true).GetValue(0);
                if (dados.AtributoBD)
                {
                    list.Add(new ItensPersistenciaOracle(info2.Name, property.GetValue(objetoClasse, null)));
                }
            }
            int num = id;
            string str = objetoClasse.GetType().Name.ToString();
            string str2 = "";
            foreach (ItensPersistenciaOracle oracle in list)
            {
                str2 = str2 + oracle.Nome + " ,";
            }
            str2 = str2.Substring(0, str2.Length - 2);
            string str3 = "";
            bool flag = false;
            foreach (ItensPersistenciaOracle oracle in list)
            {
                if (!flag)
                {
                    str3 = str3 + "Id" + str + ".Nextval, ";
                    flag = true;
                }
                else
                {
                    str3 = str3 + oracle.FormatValueForSqlSyntax() + ", ";
                }
            }
            str3 = str3.Substring(0, str3.Length - 2);
            string str4 = "";
            try
            {
                if (num > 0)
                {
                    bool flag2 = false;
                    str4 = "UPDATE " + str + " SET ";
                    foreach (ItensPersistenciaOracle oracle in list)
                    {
                        if (!flag2)
                        {
                            flag2 = true;
                        }
                        else
                        {
                            str4 = str4 + oracle.GetColumnValueExpression();
                            str4 = str4 + ", ";
                        }
                    }
                    object obj2 = str4.Substring(0, str4.Length - 2);
                    ConexaoBDOracle.ExecutarComandoSql(string.Concat(new object[] { obj2, " WHERE Id", str, " = ", num }));
                    return num;
                }
                ConexaoBDOracle.ExecutarComandoSqlEscalar(((("INSERT INTO " + str + " ") + "(" + str2 + ")") + " VALUES ") + "(" + str3 + ")");
                num = Convert.ToInt32(ConexaoBDOracle.ExecutarComandoSqlEscalar("SELECT Id" + str + ".currval from dual"));
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! O sistema encontrou problemas ao atualizar o registro.Comunique ao Administrador do sistema.");
            }
            return num;
        }
    }
}
 