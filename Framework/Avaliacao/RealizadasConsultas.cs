using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class RealizadasConsultas : ClassGenericAvaliacao
    {
        // Fields
        private string _DataHora;
        private string _FlagRetornouDados;
        private int _IdAvalia;
        private int _IdEmpresa;
        private int _IdFilial;
        private int _IdRealizadasConsultas;
        private int _IdUltimoUsuario;
        private int _IdUsuarioConsultou;
        private int _IdWebService;
        private string _UltimaAtualizacao;

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DataHora
        {
            get
            {
                return this._DataHora;
            }
            set
            {
                this._DataHora = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagRetornouDados
        {
            get
            {
                return this._FlagRetornouDados;
            }
            set
            {
                this._FlagRetornouDados = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdAvalia
        {
            get
            {
                return this._IdAvalia;
            }
            set
            {
                this._IdAvalia = value;
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
        public int IdRealizadasConsultas
        {
            get
            {
                return this._IdRealizadasConsultas;
            }
            set
            {
                this._IdRealizadasConsultas = value;
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
        public int IdUsuarioConsultou
        {
            get
            {
                return this._IdUsuarioConsultou;
            }
            set
            {
                this._IdUsuarioConsultou = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdWebService
        {
            get
            {
                return this._IdWebService;
            }
            set
            {
                this._IdWebService = value;
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
 
