using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistResposta
    {
        #region [   GetIRespostaItem ]
        /// <summary>
        /// [   GetIRespostaItem ]
        /// </summary>
        /// <param name="strIdEmpresa">Código da empresa</param>
        public static System.Data.DataSet GetIRespostaItem(string strIdEmpresa)
        {
            string strSql = "";
            try
            {
                strSql = "SELECT IdRespostaItem, NomeItem FROM VISTRESPOSTAITEM WHERE IDEMPRESA = " + strIdEmpresa + "";

                string strSql2 = " SELECT IDRESPOSTA, DESCAPELIDO , IdRespostaItem ";
                strSql2 += " , (SELECT NOMESTATUS FROM SIGESTATUS WHERE IDSTATUS = VISTRESPOSTA.Status) AS Resposta ";
                strSql2 += " FROM VISTRESPOSTA  WHERE IDEMPRESA = " + strIdEmpresa + " AND IdRespostaItem IN (SELECT IdRespostaItem FROM VISTRESPOSTAITEM WHERE IDEMPRESA = " + strIdEmpresa + ")";

                using (Conexao cn = new Conexao())
                {
                    return cn.ExecSQL(strSql + ";" + strSql2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region [   GetIRespostaItem ]
        /// <summary>
        /// [   GetIRespostaItem ]
        /// </summary>
        /// <param name="strIdEmpresa">Código da empresa</param>
        public static System.Data.DataSet GetIResposta(string strIdEmpresa, string strIdRespostaItem)
        {
            string strSql = "";
            try
            {

                //strSql = " SELECT IDRESPOSTA, DESCAPELIDO , ";
                //strSql += " (SELECT NOMESTATUS FROM SIGESTATUS WHERE IDSTATUS = VISTRESPOSTA.Status) AS Resposta ";
                //strSql += " FROM VISTRESPOSTA ";
                //strSql += " WHERE IdRespostaItem  = "+ strIdRespostaItem +" ";
                //strSql += " AND IDEMPRESA = "+  strIdEmpresa +" "; 

                strSql = " SELECT IDRESPOSTA, DESCAPELIDO , ";
                strSql += " (SELECT NOMESTATUS FROM SIGESTATUS WHERE IDSTATUS = VISTRESPOSTA.Status) AS Resposta ";
                strSql += " FROM VISTRESPOSTA  WHERE IDEMPRESA = " + strIdEmpresa + " ";

                using (Conexao cn = new Conexao())
                {
                    return cn.ExecSQL(strSql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
