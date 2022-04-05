
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Util
{
    public class LogAuditoria : ClassGenericUtil
    {
        // Fields
        private string _Acao;
        private string _DataLog;
        private int _IdLogAuditoria;
        private int _IdUsuario;
        private string _NomeTabela;
        private string _NomeTela;
        private string _Origem;
        private string _Registro;

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public string Acao
        {
            get
            {
                return this._Acao;
            }
            set
            {
                this._Acao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string DataLog
        {
            get
            {
                return this._DataLog;
            }
            set
            {
                this._DataLog = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdLogAuditoria
        {
            get
            {
                return this._IdLogAuditoria;
            }
            set
            {
                this._IdLogAuditoria = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public string NomeTabela
        {
            get
            {
                return this._NomeTabela;
            }
            set
            {
                this._NomeTabela = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string NomeTela
        {
            get
            {
                return this._NomeTela;
            }
            set
            {
                this._NomeTela = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string Origem
        {
            get
            {
                return this._Origem;
            }
            set
            {
                this._Origem = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string Registro
        {
            get
            {
                return this._Registro;
            }
            set
            {
                this._Registro = value;
            }
        }
    }
}

 

 
