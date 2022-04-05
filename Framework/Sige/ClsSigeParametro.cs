using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{
    public class ClsSigeParametro
    {
        // Methods
        public string GetParametro(string strIdEmpresa, string strIdParametro)
        {
            string str;
            try
            {
                if ((strIdEmpresa == null) || (strIdParametro == null))
                {
                    return "";
                }
                if ((strIdEmpresa.Trim() == "") || (strIdParametro.Trim() == ""))
                {
                    return "";
                }
                object obj2 = AcessoBD.ExecutarComandoSqlEscalar("Select Valor From SigeParametroValor where IdEmpresa = " + strIdEmpresa + " and IdParametro = " + strIdParametro);
                if ((obj2 != null) && (obj2.ToString().Trim() != ""))
                {
                    return obj2.ToString().Trim();
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public DataSet GetParametros()
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string sqlComand = " select IdParametro, NomeParametro  from SigeParametro order by IdParametro ";
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdParametro", typeof(int));
                    table.Columns.Add("NomeParametro", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdParametro"].ToString().Trim()), set.Tables[0].Rows[i]["NomeParametro"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
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
            }
            return set3;
        }
    }
}
