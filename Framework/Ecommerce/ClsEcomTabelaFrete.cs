using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Framework.Reflection.Rotinas;

using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Ecommerce
{
    public class ClsEcomTabelaFrete : ClassGenericEcommerce
    {
        // Fields
        private int _DiasPrazoEntrega;
        private string _FlagAtivoInativo;
        private int _IdEmpresa;
        private int _IdTabelaFrete;
        private int _IdTipoVeiculo;
        private int _IdUltimoUsuario;
        private double _KmFinal;
        private string _Nome;
        private double _PesoCubadoFinal;
        private double _PesoCubadoInicial;
        private string _UltimaAtualizacao;
        private double _ValorDescarga;
        private double _ValorEntrega;

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int DiasPrazoEntrega
        {
            get
            {
                return this._DiasPrazoEntrega;
            }
            set
            {
                this._DiasPrazoEntrega = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagAtivoInativo
        {
            get
            {
                return this._FlagAtivoInativo;
            }
            set
            {
                this._FlagAtivoInativo = value;
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
        public int IdTabelaFrete
        {
            get
            {
                return this._IdTabelaFrete;
            }
            set
            {
                this._IdTabelaFrete = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoVeiculo
        {
            get
            {
                return this._IdTipoVeiculo;
            }
            set
            {
                this._IdTipoVeiculo = value;
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
        public double KmFinal
        {
            get
            {
                return this._KmFinal;
            }
            set
            {
                this._KmFinal = value;
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
        public double PesoCubadoFinal
        {
            get
            {
                return this._PesoCubadoFinal;
            }
            set
            {
                this._PesoCubadoFinal = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double PesoCubadoInicial
        {
            get
            {
                return this._PesoCubadoInicial;
            }
            set
            {
                this._PesoCubadoInicial = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorDescarga
        {
            get
            {
                return this._ValorDescarga;
            }
            set
            {
                this._ValorDescarga = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorEntrega
        {
            get
            {
                return this._ValorEntrega;
            }
            set
            {
                this._ValorEntrega = value;
            }
        }
    }
}