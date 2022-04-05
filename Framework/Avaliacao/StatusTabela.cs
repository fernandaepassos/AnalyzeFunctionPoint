
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
  
    public class StatusTabela : ClassGenericAvaliacao
    {
        // Methods
        public DataSet ListaStatusPorTabelaCampo(string strTabela, string strCampo)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strTabela == null)
                {
                    return null;
                }
                if (strTabela.Trim() == "")
                {
                    return null;
                }
                if (strCampo == null)
                {
                    return null;
                }
                if (strCampo.Trim() == "")
                {
                    return null;
                }
                string str2 = (" select Status.IdStatus " + " , Status.DescStatus ") + " from statustabela  " + " Left Join Status on Status.IdStatus = statustabela.IdStatus  ";
                set = AcessoBD.ObterDataSet(str2 + " where tabela = '" + strTabela + "' and campo = '" + strCampo + "' ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdStatus", typeof(int));
                    table.Columns.Add("DescStatus", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdStatus"].ToString().Trim()), set.Tables[0].Rows[i]["DescStatus"].ToString().Trim() });
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
            return set3;
        }
    }
}
 
