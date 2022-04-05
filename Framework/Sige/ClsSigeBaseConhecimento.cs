using System.Web;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{
    public class ClsSigeBaseConhecimento : ClassGenericSige
    {
        // Fields
        private string _Conhecimento;
        private string _DataInclusao;
        private int _IdBaseConhecimento;
        private int _IdEmpresa;
        private int _IdSistema;
        private int _IdUltimoUsuario;
        private int _IdUsuarioInclusao;
        private string _Titulo;
        private string _UltimaAtualizacao;

        // Methods
        public void Excluir(ClsSigeBaseConhecimento objClasse, int id)
        {
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objClasse, id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataSet ListaBaseConhecimento(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (strIdEmpresa.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select IdBaseConhecimento                ,SigeBaseConhecimento.IdSistema                ,Titulo                ,Conhecimento                ,(CONVERT(varchar, SigeBaseConhecimento.DataInclusao, 103)+' '+ CONVERT(varchar,SigeBaseConhecimento.DataInclusao, 108)) as DataInclusao                ,IdUsuarioInclusao                , SigeUsuarioUsuarioInclusao.Login as  DescUsuarioInclusao                ,SigeUsuarioUltimoUsuario.Login as DescUltimoUsuario                , (CONVERT(varchar,SigeBaseConhecimento.UltimaAtualizacao,103)+' '+CONVERT(varchar,SigeBaseConhecimento.UltimaAtualizacao,108)) as UltimaAtualizacao                ,SigeBaseConhecimento.IdEmpresa                , SigeSistema.NomeSistema                from SigeBaseConhecimento                Left Join SigeUsuario as SigeUsuarioUltimoUsuario on SigeUsuarioUltimoUsuario.IdUsuario = SigeBaseConhecimento.IdUltimoUsuario                Left Join SigeUsuario as SigeUsuarioUsuarioInclusao on SigeUsuarioUsuarioInclusao.IdUsuario = SigeBaseConhecimento.IdUsuarioInclusao                Left Join SigeSistema on SigeSistema.IdSistema = SigeBaseConhecimento.IdSistema                where SigeBaseConhecimento.idempresa = " + strIdEmpresa + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public int Salvar(ClsSigeBaseConhecimento objSigeBaseConhecimento, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigeBaseConhecimento, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public string Conhecimento
        {
            get
            {
                return this._Conhecimento;
            }
            set
            {
                this._Conhecimento = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public int IdBaseConhecimento
        {
            get
            {
                return this._IdBaseConhecimento;
            }
            set
            {
                this._IdBaseConhecimento = value;
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
        public int IdSistema
        {
            get
            {
                return this._IdSistema;
            }
            set
            {
                this._IdSistema = value;
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
        public int IdUsuarioInclusao
        {
            get
            {
                return this._IdUsuarioInclusao;
            }
            set
            {
                this._IdUsuarioInclusao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string Titulo
        {
            get
            {
                return this._Titulo;
            }
            set
            {
                this._Titulo = value;
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
 
