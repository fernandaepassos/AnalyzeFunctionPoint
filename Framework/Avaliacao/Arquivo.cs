using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;
using System;

namespace Framework.Avaliacao
{
    public class Arquivo : ClassGenericAvaliacao
    {
        // Fields
        private string _ArquivoURL;
        private string _DescArquivo;
        private int _IdArquivo;
        private int _IdRegistroTabela;
        private int _IdUltimoUsuario;
        private string _Tabela;
        private string _Tamanho;
        private string _Tipo;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet GetArquivo(string strIdRegistroTabela, string strTabela)
        {
            try
            {
                if (strIdRegistroTabela == null)
                {
                    return null;
                }
                if (strIdRegistroTabela.Trim() == "")
                {
                    return null;
                }
                if (strTabela == null)
                {
                    return null;
                }
                if (strTabela.Trim() == "")
                {
                    return null;
                }
                string str = " select IdArquivo ";
                return AcessoBD.ObterDataSet((((((str + " , DescArquivo " + " , substring(ArquivoURL,CHARINDEX('anexos',ArquivoURL)+7,len(ArquivoURL)) as ArquivoURL ") + " , (CONVERT(varchar, Arquivo.UltimaAtualizacao, 103)+' '+ CONVERT(varchar,Arquivo.UltimaAtualizacao,108)) as UltimaAtualizacao  " + " , Pessoa.Nome as DescUltimoUsuario ") + " , ArquivoURL as PathFull " + " from Arquivo  ") + " left join Usuario on Usuario.IdUsuario = Arquivo.IdUltimoUsuario " + " left join Pessoa on Pessoa.IdPessoa = Usuario.IdPessoa ") + " where Tabela = '" + strTabela + "'  ") + " and IdRegistroTabela = " + strIdRegistroTabela + " ");
            }
            catch
            {
                return null;
            }
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string ArquivoURL
        {
            get
            {
                return this._ArquivoURL;
            }
            set
            {
                this._ArquivoURL = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescArquivo
        {
            get
            {
                return this._DescArquivo;
            }
            set
            {
                this._DescArquivo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdArquivo
        {
            get
            {
                return this._IdArquivo;
            }
            set
            {
                this._IdArquivo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdRegistroTabela
        {
            get
            {
                return this._IdRegistroTabela;
            }
            set
            {
                this._IdRegistroTabela = value;
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
        public string Tabela
        {
            get
            {
                return this._Tabela;
            }
            set
            {
                this._Tabela = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Tamanho
        {
            get
            {
                return this._Tamanho;
            }
            set
            {
                this._Tamanho = value;
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

 
