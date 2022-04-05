using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Cliente : ClassGenericAvaliacao
    {
        // Fields
        private int _IdCliente;
        private int _IdPessoa;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdCliente
        {
            get
            {
                return this._IdCliente;
            }
            set
            {
                this._IdCliente = value;
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
