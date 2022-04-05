using System.Data;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;

namespace Framework.Sige
{
    public class ClsSigeFaq : ClassGenericSige
    {
        // Fields
        private string _Chave;
        private int _IdEmpresa;
        private int _IdFaq;
        private int _IdFaqSup;
        private int _IdUltimoUsuario;
        private string _Texto;
        private string _Tipo;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet GetFaq(string strIdEmpresa)
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

                string strSql = " select IdFaq, ";
                strSql += " (case when lower(Tipo) = 'g' then 'Grupo' else case when LOWER(tipo) = 'p' then 'Pergunta' else case when LOWER(tipo) = 'r' then 'Resposta' end end end) as DescTipo ";
                strSql += " , Tipo , Texto , IdFaqSup, Chave, SigeFaq.IdUltimoUsuario, SigeUsuario.Login as DescUltimoUsuario, ";
                strSql += " (CONVERT(varchar,SigeFaq.UltimaAtualizacao,103) +' '+ CONVERT(varchar,SigeFaq.UltimaAtualizacao,108)) as UltimaAtualizacao ";
                strSql += " , (select SubString(texto, 0, 50) from SigeFaq as SigeFaq1 where SigeFaq1.IdFaqSup = SigeFaq.IdFaq and LOWER(tipo) = 'r') as Resposta ";
                strSql += " from SigeFaq ";
                strSql += " Left Join SigeUsuario on SigeUsuario.IdUsuario = SigeFaq.IdUltimoUsuario ";
                strSql += " where SigeFaq.IdEmpresa = " + strIdEmpresa + " and lower(tipo) = 'p'  ";
                
                set = AcessoBD.ObterDataSet(strSql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

       

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string Chave
        {
            get
            {
                return this._Chave;
            }
            set
            {
                this._Chave = value;
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
        public int IdFaq
        {
            get
            {
                return this._IdFaq;
            }
            set
            {
                this._IdFaq = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdFaqSup
        {
            get
            {
                return this._IdFaqSup;
            }
            set
            {
                this._IdFaqSup = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public string Texto
        {
            get
            {
                return this._Texto;
            }
            set
            {
                this._Texto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Tipo
        {
            get
            {
                return this._Tipo;
            }
            set
            {
                this._Tipo = value;
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

 
