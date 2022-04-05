using System;
using System.Data;
using Framework.Reflection.AcessoBancoDados;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Sige
{
    public class ClsSigeTipo
    {
        // Methods
        public static string GetNomeTipo(string strIdTipo)
        {
            try
            {
                if (strIdTipo == null)
                {
                    return "";
                }
                if (strIdTipo.Trim() == "")
                {
                    return "";
                }
                return AcessoBD.ExecutarComandoSqlEscalar("select desctipo from Tipo where IdTipo = " + strIdTipo + " ").ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public static DataSet GetTipo(string strNomeTabela)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT IdTipo, NomeTipo FROM SigeTipo ";
                sQL = (sQL + "WHERE IdTipo IN (SELECT IdTipo ") + "FROM SigeTipoTabela WHERE NomeTabela = '" + strNomeTabela.Trim() + "')";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public static DataSet GetTipo_(string strNomeTabela)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet((" SELECT IdTipo, NomeTipo FROM SigeTipo " + "WHERE IdTipo IN (SELECT IdTipo ") + "FROM SigeTipoTabela WHERE NomeTabela = '" + strNomeTabela.Trim() + "')");
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public static DataSet GetTipoDeCliente()
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = "SELECT IdTipo, NomeTipo FROM SIGETIPO WHERE IDTIPO IN (SELECT IDTIPO FROM SIGETIPOTABELA WHERE NOMETABELA = 'SigeEmpresa' and IdTipo <> 18 ) order by IdTipo";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public DataSet GetTipoGenerico(string NomeTabela, string Campo)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string sqlComand = " select SigeTipo.IdTipo, SigeTipo.NomeTipo ";
                sqlComand = (sqlComand + " from SigeTipo  ") + " left join SigeTipoTabela on SigeTipoTabela.IdTipo = SigeTipo.IdTipo  " + " where 1=1 ";
                if (!string.IsNullOrEmpty(NomeTabela))
                {
                    sqlComand = sqlComand + " and SigeTipoTabela.NomeTabela = '" + NomeTabela + "' ";
                }
                if (!string.IsNullOrEmpty(Campo))
                {
                    sqlComand = sqlComand + "and SigeTipoTabela.Campo = '" + Campo + "'  ";
                }
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdTipo", typeof(int));
                    table.Columns.Add("NomeTipo", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdTipo"].ToString().Trim()), set.Tables[0].Rows[i]["NomeTipo"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
                if (table != null)
                {
                    table.Dispose();
                }
                if (set2 != null)
                {
                    set2.Dispose();
                }
            }
            return set3;
        }
    }
}
