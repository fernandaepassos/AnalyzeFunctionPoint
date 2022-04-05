using System;
using System.Web;
using System.Data;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Sige
{
    public class ClsSigeFuncionario
    {
        // Methods
        public bool Excluir(string strIdPessoa, string strIdSistema)
        {
            bool flag;
            try
            {
                if (strIdPessoa == null)
                {
                    return false;
                }
                if (strIdPessoa.Trim() == "")
                {
                    return false;
                }
                if (strIdSistema == null)
                {
                    return false;
                }
                if (strIdSistema.Trim() == "")
                {
                    return false;
                }
                ClsSigeUsuario usuario = new ClsSigeUsuario();
                ClsSigePessoa pessoa = new ClsSigePessoa();
                string idUsuario = usuario.GetIdUsuario(Convert.ToInt32(strIdPessoa));
                if (this.ValidaExclusao(strIdPessoa))
                {
                    if (idUsuario.Trim() != "")
                    {
                        if (usuario.ValidaExclusao(idUsuario))
                        {
                            AcessoBD.ExecutarComandoSql(" delete SigeUsuarioHrAcesso where IdUsuario in (select IdUsuario from SigeUsuario where IdPessoa = " + strIdPessoa + ") ");
                            AcessoBD.ExecutarComandoSql(" delete SigeUsuarioSistema where IdSistema = " + strIdSistema + " and IdUsuario in (select IdUsuario from SigeUsuario where IdPessoa = " + strIdPessoa + ") ");
                            AcessoBD.ExecutarComandoSql(" delete SigeUsuario where IdPessoa = " + strIdPessoa + " ");
                            AcessoBD.ExecutarComandoSql(" delete sigefuncionario where idpessoa = " + strIdPessoa + " ");
                            AcessoBD.ExecutarComandoSql(" delete SigePessoa where IdPessoa = " + strIdPessoa + " ");
                            return true;
                        }
                        return false;
                    }
                    AcessoBD.ExecutarComandoSql(" delete SigeUsuarioHrAcesso where IdUsuario in (select IdUsuario from SigeUsuario where IdPessoa = " + strIdPessoa + ") ");
                    AcessoBD.ExecutarComandoSql(" delete SigeUsuarioSistema where IdSistema = " + strIdSistema + " and IdUsuario in (select IdUsuario from SigeUsuario where IdPessoa = " + strIdPessoa + ") ");
                    AcessoBD.ExecutarComandoSql(" delete SigeUsuario where IdPessoa = " + strIdPessoa + " ");
                    AcessoBD.ExecutarComandoSql(" delete sigefuncionario where idpessoa = " + strIdPessoa + " ");
                    AcessoBD.ExecutarComandoSql(" delete SigePessoa where IdPessoa = " + strIdPessoa + " ");
                    return true;
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool ValidaExclusao(string strIdPessoa)
        {
            bool flag;
            DataSet set = new DataSet();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdPessoa == null)
                {
                    return false;
                }
                if (strIdPessoa.Trim() == "")
                {
                    return false;
                }
                set = AcessoBD.ObterDataSet((((((" select 'select count(*) from '+ sysobjects.name +' where '+ syscolumns.name +' = " + strIdPessoa + "' ") + " From sysobjects, syscolumns ") + " where sysobjects.id = syscolumns.id  " + " and sysobjects.xtype = 'u'  ") + " and syscolumns.name like '%IdPessoa%'  " + " and sysobjects.name <> 'sigefuncionario'  ") + " and sysobjects.name <> 'SigePessoa'  " + " and sysobjects.name <> 'SigeUsuario'  ") + " and sysobjects.name <> 'SigeUsuarioSistema'  " + " and sysobjects.name <> 'SigeUsuarioHrAcesso'  ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        set2 = AcessoBD.ObterDataSet(set.Tables[0].Rows[i][0].ToString().Trim());
                        if ((((set2 != null) && (set2.Tables.Count > 0)) && (set2.Tables[0].Rows.Count > 0)) && (set2.Tables[0].Rows[0][0].ToString().Trim() != "0"))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                flag = true;
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
                if (set2 != null)
                {
                    set2.Dispose();
                }
            }
            return flag;
        }
    }
}
