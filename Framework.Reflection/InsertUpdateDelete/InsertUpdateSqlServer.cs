using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.RastrearExcecao;
using System.Data.SqlClient;

namespace Framework.Reflection.InsertUpdateDelete
{
    public class InsertUpdateSqlServer
    {
        // Fields
        private string sqlAuditoria = "";
        private string sqlCommand = "";
        private string sqlMaiorIDTabela = "";

        // Methods
        private List<ItensPersistenciaSqlServer> buscaPropriedadesAtributoBD(object objetoClasse)
        {
            object[] customAttributes;
            AtributoBancoDados dados;
            bool flag = this.possuiAncestralTabelaPropria(objetoClasse);
            PropertyInfo property = null;
            PropertyInfo[] properties = objetoClasse.GetType().GetProperties();
            List<ItensPersistenciaSqlServer> list = new List<ItensPersistenciaSqlServer>();
            foreach (PropertyInfo info2 in properties)
            {
                property = objetoClasse.GetType().GetProperty(info2.Name);
                if (!flag || ((!(property.Name.ToUpper() != "IdUltimoUsuario".ToUpper()) || !(property.Name.ToUpper() != "UltimaAtualizacao".ToUpper())) || (property.DeclaringType == objetoClasse.GetType())))
                {
                    customAttributes = objetoClasse.GetType().GetProperty(info2.Name).GetCustomAttributes(typeof(AtributoBancoDados), true);
                    if (customAttributes.Length != 0)
                    {
                        dados = (AtributoBancoDados) customAttributes.GetValue(0);
                        if (dados.AtributoBD)
                        {
                            list.Add(new ItensPersistenciaSqlServer(info2.Name, property.GetValue(objetoClasse, null)));
                        }
                    }
                }
            }
            FieldInfo[] fields = objetoClasse.GetType().GetFields(BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info3 in fields)
            {
                if (!flag || (((info3.Name.ToUpper() == "IdUltimoUsuario".ToUpper()) || (info3.Name.ToUpper() == "UltimaAtualizacao".ToUpper())) || (info3.DeclaringType == objetoClasse.GetType())))
                {
                    customAttributes = info3.GetCustomAttributes(typeof(AtributoBancoDados), true);
                    if (customAttributes.Length != 0)
                    {
                        dados = (AtributoBancoDados) customAttributes.GetValue(0);
                        if (dados.AtributoBD)
                        {
                            list.Add(new ItensPersistenciaSqlServer(info3.Name, info3.GetValue(objetoClasse)));
                        }
                    }
                }
            }
            return list;
        }

        private bool campoChavePrimaria(string _nomeCampo, string _nomeTabela)
        {
            return ((_nomeCampo.ToUpper() == ("ID" + _nomeTabela).ToUpper()) || (_nomeCampo.ToUpper() == ("ID" + _nomeTabela.Trim().Substring(4, _nomeTabela.Trim().Length - 4).ToUpper())));
        }

        private void gerarComandosSQL(object objetoClasse, int idRegistro, string nomeTelaOrigem)
        {
            List<ItensPersistenciaSqlServer> itens = this.buscaPropriedadesAtributoBD(objetoClasse);
            string str = "";
            if (objetoClasse.GetType().Name.ToString().Trim().Substring(0, 3).Trim().ToLower() == "cls")
            {
                str = objetoClasse.GetType().Name.ToString().Trim().Substring(3, objetoClasse.GetType().Name.ToString().Trim().Length - 3);
            }
            else
            {
                str = objetoClasse.GetType().Name.ToString();
            }
            string nomesCampos = this.montaNomesCamposTabela(str, itens);
            string valoresCampos = this.montaValoresCamposTabela(str, itens);
            this.sqlCommand = this.montaComandoSQL(idRegistro, str, nomesCampos, valoresCampos, itens);
            this.sqlAuditoria = this.montaComandoSQLAuditoria(idRegistro, str, itens, nomeTelaOrigem);
            this.sqlMaiorIDTabela = this.montaComandoSQLMaiorIDTabela(str);
        }

        public int InsertUpdateRegistro(object objetoClasse, int id, SqlConnection con)
        {
            return this.InsertUpdateRegistro(objetoClasse, id, con, "");
        }

        public int InsertUpdateRegistro(object objetoClasse, int id, SqlConnection con, string nomeTela)
        {
            int num2;
            try
            {
                int num = id;
                this.gerarComandosSQL(objetoClasse, id, nomeTela);
                if (!string.IsNullOrEmpty(this.sqlCommand))
                {
                    ConexaoBDSqlServer.ExecutarComandoSql(this.sqlCommand, con);
                    if (num == 0)
                    {
                        num = Convert.ToInt32(ConexaoBDSqlServer.ExecutarComandoSqlEscalar(this.sqlMaiorIDTabela, con));
                    }
                    try
                    {
                        ConexaoBDSqlServer.ExecutarComandoSql(this.sqlAuditoria, con);
                    }
                    catch
                    {
                    }
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return num2;
        }

        public int InsertUpdateRegistroSemLog(object objetoClasse, int id, SqlConnection con)
        {
            int num2;
            try
            {
                int num = id;
                this.gerarComandosSQL(objetoClasse, id, "");
                if (!string.IsNullOrEmpty(this.sqlCommand))
                {
                    ConexaoBDSqlServer.ExecutarComandoSql(this.sqlCommand, con);
                    if (num == 0)
                    {
                        num = Convert.ToInt32(ConexaoBDSqlServer.ExecutarComandoSqlEscalar(this.sqlMaiorIDTabela, con));
                    }
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return num2;
        }

        public int InsertUpdateRegistroTransacao(object objetoClasse, int id, SqlTransaction con)
        {
            return this.InsertUpdateRegistroTransacao(objetoClasse, id, con, "");
        }

        public int InsertUpdateRegistroTransacao(object objetoClasse, int id, SqlTransaction objSqlTransaction, string nomeTela)
        {
            int num2;
            try
            {
                int num = id;
                this.gerarComandosSQL(objetoClasse, id, nomeTela);
                if (!string.IsNullOrEmpty(this.sqlCommand))
                {
                    ConexaoBDSqlServer.ExecutarComandoSqlTransacao(this.sqlCommand, objSqlTransaction);
                    if (num == 0)
                    {
                        num = Convert.ToInt32(ConexaoBDSqlServer.ExecutarComandoSqlEscalarTransacao(this.sqlMaiorIDTabela, objSqlTransaction));
                    }
                    ConexaoBDSqlServer.ExecutarComandoSqlTransacao(this.sqlAuditoria, objSqlTransaction);
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return num2;
        }

        public int InsertUpdateRegistroTransacaoSemLog(object objetoClasse, int id, SqlTransaction objSqlTransaction)
        {
            int num2;
            try
            {
                int num = id;
                this.gerarComandosSQL(objetoClasse, id, "");
                if (!string.IsNullOrEmpty(this.sqlCommand))
                {
                    ConexaoBDSqlServer.ExecutarComandoSqlTransacao(this.sqlCommand, objSqlTransaction);
                    if (num == 0)
                    {
                        num = Convert.ToInt32(ConexaoBDSqlServer.ExecutarComandoSqlEscalarTransacao(this.sqlMaiorIDTabela, objSqlTransaction));
                    }
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                ToTrackException.ToTrack(exception);
                throw new Exception("Atenção! Problemas ao processar o registro. Comunique ao Administrador do sistema.");
            }
            return num2;
        }

        private string montaComandoSQL(int _idRegistro, string _nomeTabela, string nomesCampos, string valoresCampos, List<ItensPersistenciaSqlServer> itens)
        {
            string str = "";
            if (_idRegistro > 0)
            {
                object obj2;
                str = "UPDATE " + _nomeTabela + " SET ";
                foreach (ItensPersistenciaSqlServer server in itens)
                {
                    if (!this.campoChavePrimaria(server.Nome, _nomeTabela))
                    {
                        str = str + server.GetColumnValueExpression();
                        str = str + ", ";
                    }
                }
                str = str.Substring(0, str.Length - 2);
                if (((((_nomeTabela.ToString().Trim().Substring(0, 3).Trim().ToLower() == "cls") || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Cons".ToLower())) || ((_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Ecom".ToLower()) || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Sdsk".ToLower()))) || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "sige".ToLower())) || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Vist".ToLower()))
                {
                    obj2 = str;
                    return string.Concat(new object[] { obj2, " WHERE Id", _nomeTabela.Trim().Substring(4, _nomeTabela.Trim().Length - 4), " = ", _idRegistro });
                }
                obj2 = str;
                return string.Concat(new object[] { obj2, " WHERE Id", _nomeTabela, " = ", _idRegistro });
            }
            return (((("INSERT INTO " + _nomeTabela + " ") + "(" + nomesCampos + ")") + " VALUES ") + "(" + valoresCampos + ")");
        }

        private string montaComandoSQLAuditoria(int _idRegistro, string _nomeTabela, List<ItensPersistenciaSqlServer> itens, string nomeTelaOrigem)
        {
            if (HttpContext.Current == null)
            {
                return "";
            }
            if (HttpContext.Current.Session["IdUsuario"] == null)
            {
                return "";
            }
            string str = (_idRegistro > 0) ? "ALTERAÇÃO" : "INCLUSÃO";
            string str2 = "INSERT INTO LogAuditoria (Origem, NomeTabela, IdUsuario, Acao, Registro, NomeTela, DataLog) ";
            string str4 = str2;
            str2 = str4 + "VALUES ('SISTEMA','" + _nomeTabela + "'," + HttpContext.Current.Session["IdUsuario"].ToString() + ", '" + str + "','";
            foreach (ItensPersistenciaSqlServer server in itens)
            {
                str2 = str2 + server.GetColumnValueExpression().Replace("'", "");
                str2 = str2 + ", ";
            }
            return (str2.Substring(0, str2.Length - 2) + "','" + nomeTelaOrigem + "',GETDATE())");
        }

        private string montaComandoSQLMaiorIDTabela(string _nomeTabela)
        {
            if (((((_nomeTabela.ToString().Trim().Substring(0, 3).Trim().ToLower() == "cls") || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Cons".ToLower())) || ((_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Ecom".ToLower()) || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Sdsk".ToLower()))) || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "sige".ToLower())) || (_nomeTabela.ToString().Trim().Substring(0, 4).Trim().ToLower() == "Vist".ToLower()))
            {
                return ("SELECT MAX(Id" + _nomeTabela.Trim().Substring(4, _nomeTabela.Trim().Length - 4) + ") FROM " + _nomeTabela);
            }
            return ("SELECT MAX(Id" + _nomeTabela.Trim() + ") FROM " + _nomeTabela);
        }

        private string montaNomesCamposTabela(string _nomeTabela, List<ItensPersistenciaSqlServer> itens)
        {
            string str = "";
            foreach (ItensPersistenciaSqlServer server in itens)
            {
                if (!this.campoChavePrimaria(server.Nome, _nomeTabela))
                {
                    str = str + server.Nome + " ,";
                }
            }
            return str.Substring(0, str.Length - 2);
        }

        private string montaValoresCamposTabela(string _nomeTabela, List<ItensPersistenciaSqlServer> itens)
        {
            string str = "";
            foreach (ItensPersistenciaSqlServer server in itens)
            {
                if (!this.campoChavePrimaria(server.Nome, _nomeTabela))
                {
                    str = str + server.FormatValueForSqlSyntax() + ", ";
                }
            }
            return str.Substring(0, str.Length - 2);
        }

        private bool possuiAncestralTabelaPropria(object objetoClasse)
        {
            bool flag = false;
            object[] customAttributes = objetoClasse.GetType().GetCustomAttributes(typeof(AtributoAncestralTabelaPropria), true);
            if (customAttributes.Length > 0)
            {
                AtributoAncestralTabelaPropria propria = (AtributoAncestralTabelaPropria) customAttributes.GetValue(0);
                if (propria.TabelaPropria)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
} 

 
