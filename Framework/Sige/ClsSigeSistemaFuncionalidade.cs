using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Data;

namespace Framework.Sige
{
    public class ClsSigeSistemaFuncionalidade
    {
        // Methods
        public static DataSet GetFuncionalidadesPorSistema(string strIdEmpresa, string strIdSistema)
        {
            DataSet set;
            try
            {
                string sQL = "select IdFuncionalidade, Nome from SigeSistemaFuncionalidade where IdSistema = " + strIdSistema.Trim() + " and IdEmpresa = " + strIdEmpresa.Trim();
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }
    }
}
