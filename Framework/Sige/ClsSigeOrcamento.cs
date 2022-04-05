using System.Data;
using System;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{

    public class ClsSigeOrcamento : ClassGenericSige
    {
        // Fields
        private double _Acrescimento;
        private string _DataInclusao;
        private string _DataValidade;
        private double _Desconto;
        private int _IdEmpresa;
        private int _IdOrcamento;
        private int _IdPessoa;
        private int _IdStatus;
        private int _IdTipoCondicaoPagamento;
        private int _IdTipoFormaPagamento;
        private int _IdUsuarioInclusor;
        private string _MotivoAcrescimento;
        private string _MotivoDesconto;
        private string _Observacao;
        private double _ValorOrcamento;

        // Methods
        public DataSet GetOrcamento(string strIdEmpresa)
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
                set = AcessoBD.ObterDataSet("select                IdOrcamento                ,SigeOrcamento.IdEmpresa                ,SigePessoaEmpresa.NomePessoa as NomeEmpresa                ,convert(varchar,SigeOrcamento.DataInclusao,103)+' '+ CONVERT(varchar,SigeOrcamento.DataInclusao,108) as DataInclusao                ,SigeOrcamento.IdPessoa as IdPessoaCliente                , Cliente.NomePessoa as Cliente                ,SigeOrcamento.IdStatus                , SigeStatus.NomeStatus                ,IdTipoCondicaoPagamento                , SigeTipo.NomeTipo as DescTipoCondicaoPagamento                ,Acrescimento                ,MotivoAcrescimento                ,Desconto                ,MotivoDesconto                ,ValorOrcamento                ,IdTipoFormaPagamento                , SigeTipoFormaPagamento.NomeTipo as DescTipoFormaPagamento                ,convert(varchar,SigeOrcamento.DataValidade,103)+' '+ CONVERT(varchar,SigeOrcamento.DataValidade,108) as DataValidade                ,SigeOrcamento.Observacao                ,IdUsuarioInclusor                from SigeOrcamento                Left Join SigeEmpresa  on SigeEmpresa.IdEmpresa = SigeOrcamento.IdEmpresa                Left Join SigePessoa as SigePessoaEmpresa on SigePessoaEmpresa.IdPessoa = SigeEmpresa.IdPessoa                Left Join SigePessoa as Cliente on Cliente.IdPessoa = SigeOrcamento.IdPessoa                Left Join SigeStatus on SigeStatus.IdStatus = SigeOrcamento.IdStatus                Left Join SigeTipo on SigeTipo.IdTipo = SigeOrcamento.IdTipoCondicaoPagamento                Left Join SigeTipo as SigeTipoFormaPagamento on SigeTipoFormaPagamento.IdTipo = SigeOrcamento.IdTipoFormaPagamento                where SigeOrcamento.idempresa = " + strIdEmpresa + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public double Acrescimento
        {
            get
            {
                return this._Acrescimento;
            }
            set
            {
                this._Acrescimento = value;
            }
        }

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
        public string DataValidade
        {
            get
            {
                return this._DataValidade;
            }
            set
            {
                this._DataValidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double Desconto
        {
            get
            {
                return this._Desconto;
            }
            set
            {
                this._Desconto = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public int IdStatus
        {
            get
            {
                return this._IdStatus;
            }
            set
            {
                this._IdStatus = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoCondicaoPagamento
        {
            get
            {
                return this._IdTipoCondicaoPagamento;
            }
            set
            {
                this._IdTipoCondicaoPagamento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoFormaPagamento
        {
            get
            {
                return this._IdTipoFormaPagamento;
            }
            set
            {
                this._IdTipoFormaPagamento = value;
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
        public string MotivoAcrescimento
        {
            get
            {
                return this._MotivoAcrescimento;
            }
            set
            {
                this._MotivoAcrescimento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string MotivoDesconto
        {
            get
            {
                return this._MotivoDesconto;
            }
            set
            {
                this._MotivoDesconto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Observacao
        {
            get
            {
                return this._Observacao;
            }
            set
            {
                this._Observacao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorOrcamento
        {
            get
            {
                return this._ValorOrcamento;
            }
            set
            {
                this._ValorOrcamento = value;
            }
        }
    }
}
