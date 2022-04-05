using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{
    public class ClsSigeAvaliacao
    {
        // Fields
        private string _DataAlteracao;
        private int _IdAvaliacao;
        private int _IdEmpresa;
        private int _IdRegistroTabela;
        private int _IdSistema;
        private int _IdUsuarioAlteracao;
        private string _NomeTabela;
        private int _Nota;

        // Methods
        private int GetNotaAtual(string strTabela, int intRegistro)
        {
            int num;
            try
            {
                object obj2 = AcessoBD.ExecutarComandoSqlEscalar(string.Concat(new object[] { "SELECT sum(Nota) as Nota From SigeAvaliacao where nometabela = '", strTabela, "' and IdRegistroTabela = ", intRegistro, " " }));
                if ((obj2 != null) && (obj2.ToString().Trim() != ""))
                {
                    return Convert.ToInt32(obj2);
                }
                num = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public int Salvar(ClsSigeAvaliacao ojbSigeAvaliacao, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(ojbSigeAvaliacao, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DataAlteracao
        {
            get
            {
                return this._DataAlteracao;
            }
            set
            {
                this._DataAlteracao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdAvaliacao
        {
            get
            {
                return this._IdAvaliacao;
            }
            set
            {
                this._IdAvaliacao = value;
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

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
        public int IdUsuarioAlteracao
        {
            get
            {
                return this._IdUsuarioAlteracao;
            }
            set
            {
                this._IdUsuarioAlteracao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
        public int Nota
        {
            get
            {
                return this._Nota;
            }
            set
            {
                this._Nota = value;
            }
        }
    }

}
