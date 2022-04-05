using System.Data;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System;

namespace Framework.Sige
{
    public class ClsSigePessoaHistoricoContato : ClassGenericSige
    {
        // Fields
        private string _ContatoCom;
        private string _DescricaoDoContato;
        private int _IdEmpresa;
        private int _IdPessoa;
        private int _IdPessoaHistoricoContato;
        private int _IdUltimoUsuario;
        private string _MeioDeContato;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet GetHistoricoContato(string strIdPessoa)
        {
            DataSet set;
            try
            {
                if (strIdPessoa == null)
                {
                    return null;
                }
                if (strIdPessoa.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select IdPessoaHistoricoContato                , SigePessoaHistoricoContato.IdPessoa                , ContatoCom                , MeioDeContato                , DescricaoDoContato                , SigeUsuario.Login as DescUltimoUsuario                , (CONVERT(varchar,SigePessoaHistoricoContato.UltimaAtualizacao,103)+' '+ CONVERT(varchar,SigePessoaHistoricoContato.UltimaAtualizacao,108)) as UltimaAtualizacao                , SigePessoaHistoricoContato.IdEmpresa                from SigePessoaHistoricoContato                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigePessoaHistoricoContato.IdUltimoUsuario                where SigePessoaHistoricoContato.IdPessoa = " + strIdPessoa + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public string ContatoCom
        {
            get
            {
                return this._ContatoCom;
            }
            set
            {
                this._ContatoCom = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string DescricaoDoContato
        {
            get
            {
                return this._DescricaoDoContato;
            }
            set
            {
                this._DescricaoDoContato = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPessoaHistoricoContato
        {
            get
            {
                return this._IdPessoaHistoricoContato;
            }
            set
            {
                this._IdPessoaHistoricoContato = value;
            }
        }

        [AtributoBancoDados(AtributoBD = false)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public string MeioDeContato
        {
            get
            {
                return this._MeioDeContato;
            }
            set
            {
                this._MeioDeContato = value;
            }
        }

        [AtributoBancoDados(AtributoBD = false)]
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