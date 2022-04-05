using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;


namespace Framework.Ecommerce
{
    public class ClsSigeUsuario
    {
        // Fields
        private string _DataInclusao;
        private string _FlagPadraoSistema;
        private int _IdEmpresa;
        private int _IdInclusorUsuario;
        private int _IdPerfl;
        private int _IdPessoa;
        private int _IdUltimoUsuario;
        private int _IdUsuario;
        private string _Login;
        private string _Senha;
        private string _StatusAtivoInativo;
        private string _UltimaAtualizacao;

        // Methods
        public bool Entrar(ClsSigeUsuario objSigeUsuario, out int intIdUsuario)
        {
            bool flag;
            intIdUsuario = 0;
            DataSet set = new DataSet();
            try
            {
                string str = " select IdPessoa, IdUsuario, IdPerfl, IdEmpresa, Login, Senha  ";
                object obj2 = str;
                set = AcessoBD.ObterDataSet(string.Concat(new object[] { obj2, " from SigeUsuario where IdEmpresa = ", objSigeUsuario.IdEmpresa, " and Login = '", objSigeUsuario.Login, "' and Senha = '", objSigeUsuario.Senha.Trim(), "' " }));
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    intIdUsuario = Convert.ToInt32(set.Tables[0].Rows[0]["IdPessoa"].ToString().Trim());
                    return true;
                }
                flag = false;
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
            }
            return flag;
        }

        public void Excluir(ClsSigeUsuario objSigeUsuario, int id)
        {
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objSigeUsuario, id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetIdUsuario(int intIdPessoa)
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("select IdUsuario from SigeUsuario where IdPessoa = " + intIdPessoa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return Convert.ToInt32(set.Tables[0].Rows[0][0].ToString().Trim());
                }
                num = 0;
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
            }
            return num;
        }

        public bool LoginJaExisteNaEmpresa(string strIdEmpresa, string strLogin)
        {
            bool flag;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa) || string.IsNullOrEmpty(strLogin))
                {
                    return false;
                }
                set = AcessoBD.ObterDataSet("select COUNT(*) as Qtd from SigeUsuario where Login = '" + strLogin + "' and IdEmpresa  = " + strIdEmpresa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    if (set.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        return false;
                    }
                    return true;
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return flag;
        }

        public int Salvar(ClsSigeUsuario objSigeUsuario, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigeUsuario, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DataInclusao
        {
            get
            {
                return this._DataInclusao;
            }
            set
            {
                this._DataInclusao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagPadraoSistema
        {
            get
            {
                return this._FlagPadraoSistema;
            }
            set
            {
                this._FlagPadraoSistema = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdEmpresa
        {
            get
            {
                return this._IdEmpresa;
            }
            set
            {
                this._IdEmpresa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdInclusorUsuario
        {
            get
            {
                return this._IdInclusorUsuario;
            }
            set
            {
                this._IdInclusorUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPerfl
        {
            get
            {
                return this._IdPerfl;
            }
            set
            {
                this._IdPerfl = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPessoa
        {
            get
            {
                return this._IdPessoa;
            }
            set
            {
                this._IdPessoa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdUltimoUsuario
        {
            get
            {
                return this._IdUltimoUsuario;
            }
            set
            {
                this._IdUltimoUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdUsuario
        {
            get
            {
                return this._IdUsuario;
            }
            set
            {
                this._IdUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Login
        {
            get
            {
                return this._Login;
            }
            set
            {
                this._Login = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Senha
        {
            get
            {
                return this._Senha;
            }
            set
            {
                this._Senha = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string StatusAtivoInativo
        {
            get
            {
                return this._StatusAtivoInativo;
            }
            set
            {
                this._StatusAtivoInativo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string UltimaAtualizacao
        {
            get
            {
                return this._UltimaAtualizacao;
            }
            set
            {
                this._UltimaAtualizacao = value;
            }
        }
    }

}
