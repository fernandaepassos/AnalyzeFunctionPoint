using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Funcionalidade
    {
        // Methods
        public DataSet GetFuncionalidade()
        {
            DataSet set;
            try
            {
                set = AcessoBD.ObterDataSet(((" Select Funcionalidade.IdFuncionalidade " + " , (case when Funcionalidade.IdFuncionalidadeSup is null then Funcionalidade.Nome else FuncionalidadeSup.Nome +'>>'+ Funcionalidade.Nome end) as Funcionalidade  ") + " , Funcionalidade.chave  " + " From Funcionalidade  ") + " Left Join Funcionalidade as FuncionalidadeSup on FuncionalidadeSup.IdFuncionalidade = Funcionalidade.IdFuncionalidadeSup  " + " order by Funcionalidade.chave asc  ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }
    }
}
 
