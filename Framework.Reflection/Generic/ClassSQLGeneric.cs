using System;
using System.Data;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.Generic;

namespace Framework.Reflection.Generic
{
    public class ClassSQLGeneric : Framework.Reflection.Generic.Generic
    {
        // Methods
        protected DataSet ObterDataSet(string comandoSQL)
        {
            if (!base._AcessoDBConfig.TransacaoAtiva)
            {
                return AcessoBD.ObterDataSet(comandoSQL);
            }
            return AcessoBD.ObterDataSetTransacao(comandoSQL, base._AcessoDBConfig.TransacaoBD);
        }
    }
}
 

 
