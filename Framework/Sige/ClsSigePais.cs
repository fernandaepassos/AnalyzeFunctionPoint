using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Database;

namespace Framework.Sige
{
    public class ClsSigePais
    {
        // Methods
        public DataSet GetPais(string strIdEmpresa, string strIdSistema)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa) || string.IsNullOrEmpty(strIdSistema))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(((" SELECT IdPais, Nome,IdEmpresa,IdSistema FROM SigePais " + " WHERE IdEmpresa = " + strIdEmpresa + " ") + " AND IdSistema = " + strIdSistema + " ") + " ORDER BY Nome ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdPais", typeof(int));
                    table.Columns.Add("Nome", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdPais"].ToString().Trim()), set.Tables[0].Rows[i]["Nome"].ToString().Trim() });
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

        public DataSet GetPaisAtivosPraVenda(string strIdEmpresa, string strIdSistema)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa) || string.IsNullOrEmpty(strIdSistema))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(((" SELECT IdPais, Nome,IdEmpresa,IdSistema FROM SigePais " + " WHERE IdEmpresa = " + strIdEmpresa + " ") + " AND IdSistema = " + strIdSistema + " ") + " AND ativopravenda = 1 " + " ORDER BY Nome ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdPais", typeof(int));
                    table.Columns.Add("Nome", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdPais"].ToString().Trim()), set.Tables[0].Rows[i]["Nome"].ToString().Trim() });
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
