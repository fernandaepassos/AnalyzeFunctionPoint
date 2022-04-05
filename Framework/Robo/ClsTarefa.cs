using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;
using Framework.Reflection.Generic;


namespace Framework.Robo
{
    public class ClsTarefa : ClassGenericRobo
    {
        // Fields
        private int _IdTarefa;
        private string _Nome;
        private string _Descricao;
        private string _UltimaAtualizacao;
        private int _IdUltimoUsuario;

        // Methods

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdTarefa
        {
            get
            {
                return this._IdTarefa;
            }
            set
            {
                this._IdTarefa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Nome
        {
            get
            {
                return this._Nome;
            }
            set
            {
                this._Nome = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Descricao
        {
            get
            {
                return this._Descricao;
            }
            set
            {
                this._Descricao = value;
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

       
    }
}
 
