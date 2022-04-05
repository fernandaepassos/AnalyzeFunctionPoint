using Framework.Reflection.AcessoBancoDados;

using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Seguranca
{

    public class ClsPERMISSAO
    {
        // Fields
        private int _IdFilial;
        private int _IdFuncionalidade;
        private int _IdPermissao;
        private int _IdUltimoUsuario;
        private int _IdUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public bool GetPermissao(string strIdUsuario, string strIdFuncionalidade, string strIdFilial)
        {
            try
            {
                if ((strIdUsuario != null) && (strIdUsuario.Trim() != ""))
                {
                    if ((strIdFuncionalidade == null) || (strIdFuncionalidade.Trim() == ""))
                    {
                        return false;
                    }
                    object obj2 = AcessoBD.ExecutarComandoSqlEscalar("select FlagAdministradoGeral from Usuario where IdUsuario = " + strIdUsuario);
                    if ((obj2 != null) && (obj2.ToString().Trim() == "1"))
                    {
                        return true;
                    }
                    object obj3 = AcessoBD.ExecutarComandoSqlEscalar("select Usuario.FlagAcessoTotalNaFilial from Usuario Left Join Pessoa on Pessoa.IdPessoa = Usuario.IdPessoa where IdUsuario = " + strIdUsuario + " and Pessoa.IdFilial = " + strIdFilial);
                    if ((obj3 != null) && (obj3.ToString().Trim() == "1"))
                    {
                        return true;
                    }
                    object obj4 = AcessoBD.ExecutarComandoSqlEscalar("Select (case when COUNT(*) > 0 then 'S' else 'N' end) as Liberado  From Permissao Where Permissao.IdUsuario = " + strIdUsuario + " and Permissao.IdFuncionalidade = " + strIdFuncionalidade + " and IdFilial = " + strIdFilial + " ");
                    if (obj4 != null)
                    {
                        return (obj4.ToString().Trim().ToLower() == "s");
                    }
                }
                return false;
            }
            catch
            {
                return true;
            }
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdFilial
        {
            get
            {
                return this._IdFilial;
            }
            set
            {
                this._IdFilial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdFuncionalidade
        {
            get
            {
                return this._IdFuncionalidade;
            }
            set
            {
                this._IdFuncionalidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPermissao
        {
            get
            {
                return this._IdPermissao;
            }
            set
            {
                this._IdPermissao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=false)]
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

        [AtributoBancoDados(AtributoBD=false)]
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

        [AtributoBancoDados(AtributoBD=false)]
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
 
