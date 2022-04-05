using System;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Reflection.Generic
{

    public class AcessoDBConfig
    {
        // Fields
        private TransacaoBD _transacaoBD;
        private int numeroTransacoes = 0;

        // Methods
        public void DesfazerTransacao()
        {
            if (this.TransacaoBD.TransacaoAtiva())
            {
                this.TransacaoBD.DesfazTransacao();
            }
            this.numeroTransacoes = 0;
        }

        public void FecharTransacao()
        {
            if ((this.numeroTransacoes == 1) && this.TransacaoBD.TransacaoAtiva())
            {
                this.TransacaoBD.FechaTransacao();
            }
            this.numeroTransacoes--;
        }

        public void IniciarTransacao()
        {
            if (!this.TransacaoBD.TransacaoAtiva())
            {
                this.TransacaoBD.IniciaTransacao();
            }
            this.numeroTransacoes++;
        }

        // Properties
        public bool TransacaoAtiva
        {
            get
            {
                return this.TransacaoBD.TransacaoAtiva();
            }
        }

        public TransacaoBD TransacaoBD
        {
            get
            {
                if (this._transacaoBD == null)
                {
                    this._transacaoBD = new TransacaoBD();
                }
                return this._transacaoBD;
            }
        }
    }
}
