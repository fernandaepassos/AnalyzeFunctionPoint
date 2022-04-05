using System.Data;
using System;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Sige
{

    public class ClsSigeOrcamentoItem : ClassGenericSige
    {
        // Fields
        private string _DataInclusao;
        private string _DescricaoDoItem;
        private int _IdOrcamento;
        private int _IdOrcamentoItem;
        private int _IdSistema;
        private int _IdSistemaLicenca;
        private int _IdSistemaPadraoHora;
        private int _IdTipoUnidade;
        private int _IdUsuarioInclusor;
        private int _Quantidade;
        private double _ValorTotal;
        private double _ValorUnitario;

        // Methods
        public DataSet GetOrcamentoItem(string strIdOrcamento)
        {
            DataSet set;
            try
            {
                if (strIdOrcamento == null)
                {
                    return null;
                }
                if (strIdOrcamento.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select                 IdOrcamentoItem                ,IdOrcamento                ,DescricaoDoItem                ,SigeOrcamentoItem.IdTipoUnidade                , SigeTipo.NomeTipo                ,Quantidade                ,ValorUnitario                ,ValorTotal                ,(CONVERT(varchar,SigeTipo.DataInclusao,103)) as DataInclusao                ,IdUsuarioInclusor                , SigeUsuario.Login as DescUsuarioInclusor                , SigeOrcamentoItem.IdSistema                , SigeOrcamentoItem.IdSistemaPadraoHora                , SigeOrcamentoItem.IdSistemaLicenca                , SigeSistema.NomeSistema                , (Case When SigeOrcamentoItem.IdSistemaPadraoHora Is Not Null Then 'Hora Trab.: '+ SigeTipoHP.NomeTipo else case when  SigeOrcamentoItem.IdSistemaLicenca is not null then 'Licença: '+ SigeSistemaLicenca.Nome end end ) as Categoria                from SigeOrcamentoItem                Left Join SigeTipo on SigeTipo.IdTipo = SigeOrcamentoItem.IdTipoUnidade                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigeOrcamentoItem.IdUsuarioInclusor                Left Join SigeSistema on SigeSistema.IdSistema = SigeOrcamentoItem.IdSistema                Left Join SigeSistemaPadraoHora on SigeSistemaPadraoHora.IdSistemaPadraoHora = SigeOrcamentoItem.IdSistemaPadraoHora                Left Join SigeTipo as SigeTipoHP  on SigeTipoHP.IdTipo = SigeSistemaPadraoHora.IdTipoPadraoHora                Left Join SigeSistemaLicenca on SigeSistemaLicenca.IdSistemaLicenca = SigeOrcamentoItem.IdSistemaLicenca                where SigeOrcamentoItem.idorcamento = " + strIdOrcamento);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
        public string DescricaoDoItem
        {
            get
            {
                return this._DescricaoDoItem;
            }
            set
            {
                this._DescricaoDoItem = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdOrcamento
        {
            get
            {
                return this._IdOrcamento;
            }
            set
            {
                this._IdOrcamento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdOrcamentoItem
        {
            get
            {
                return this._IdOrcamentoItem;
            }
            set
            {
                this._IdOrcamentoItem = value;
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
        public int IdSistemaLicenca
        {
            get
            {
                return this._IdSistemaLicenca;
            }
            set
            {
                this._IdSistemaLicenca = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdSistemaPadraoHora
        {
            get
            {
                return this._IdSistemaPadraoHora;
            }
            set
            {
                this._IdSistemaPadraoHora = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoUnidade
        {
            get
            {
                return this._IdTipoUnidade;
            }
            set
            {
                this._IdTipoUnidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdUsuarioInclusor
        {
            get
            {
                return this._IdUsuarioInclusor;
            }
            set
            {
                this._IdUsuarioInclusor = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int Quantidade
        {
            get
            {
                return this._Quantidade;
            }
            set
            {
                this._Quantidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorTotal
        {
            get
            {
                return this._ValorTotal;
            }
            set
            {
                this._ValorTotal = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorUnitario
        {
            get
            {
                return this._ValorUnitario;
            }
            set
            {
                this._ValorUnitario = value;
            }
        }
    }
}
