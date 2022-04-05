using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class ProjetoComplexidade : ClassGenericPontoFuncao
    {
        private int _IdProjetoComplexidade;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdProjetoComplexidade
        {
            get
            {
                return this._IdProjetoComplexidade;
            }
            set
            {
                this._IdProjetoComplexidade = value;
            }
        }

        private int _IdProjeto;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdProjeto
        {
            get
            {
                return this._IdProjeto;
            }
            set
            {
                this._IdProjeto = value;
            }
        }

        private int _AIE_ALTO;

        [AtributoBancoDados(AtributoBD = true)]
        public int AIE_ALTO
        {
            get
            {
                return this._AIE_ALTO;
            }
            set
            {
                this._AIE_ALTO = value;
            }
        }

        private int _AIE_MEDIO;

        [AtributoBancoDados(AtributoBD = true)]
        public int AIE_MEDIO
        {
            get
            {
                return this._AIE_MEDIO;
            }
            set
            {
                this._AIE_MEDIO = value;
            }
        }

        private int _AIE_BAIXO;

        [AtributoBancoDados(AtributoBD = true)]
        public int AIE_BAIXO
        {
            get
            {
                return this._AIE_BAIXO;
            }
            set
            {
                this._AIE_BAIXO = value;
            }
        }

        private int _ALI_ALTO;

        [AtributoBancoDados(AtributoBD = true)]
        public int ALI_ALTO
        {
            get
            {
                return this._ALI_ALTO;
            }
            set
            {
                this._ALI_ALTO = value;
            }
        }

        private int _ALI_MEDIO;

        [AtributoBancoDados(AtributoBD = true)]
        public int ALI_MEDIO
        {
            get
            {
                return this._ALI_MEDIO;
            }
            set
            {
                this._ALI_MEDIO = value;
            }
        }

        private int _ALI_BAIXO;
        

        [AtributoBancoDados(AtributoBD = true)]
        public int ALI_BAIXO
        {
            get
            {
                return this._ALI_BAIXO;
            }
            set
            {
                this._ALI_BAIXO = value;
            }
        }

        private int _EE_ALTO;

        [AtributoBancoDados(AtributoBD = true)]
        public int EE_ALTO
        {
            get
            {
                return this._EE_ALTO;
            }
            set
            {
                this._EE_ALTO = value;
            }
        }

        private int _EE_MEDIO;

        [AtributoBancoDados(AtributoBD = true)]
        public int EE_MEDIO
        {
            get
            {
                return this._EE_MEDIO;
            }
            set
            {
                this._EE_MEDIO = value;
            }
        }

        private int _EE_BAIXO;

        [AtributoBancoDados(AtributoBD = true)]
        public int EE_BAIXO
        {
            get
            {
                return this._EE_BAIXO;
            }
            set
            {
                this._EE_BAIXO = value;
            }
        }

        private int _CE_ALTA;

        [AtributoBancoDados(AtributoBD = true)]
        public int CE_ALTA
        {
            get
            {
                return this._CE_ALTA;
            }
            set
            {
                this._CE_ALTA = value;
            }
        }

        private int _CE_MEDIA;

        [AtributoBancoDados(AtributoBD = true)]
        public int CE_MEDIA
        {
            get
            {
                return this._CE_MEDIA;
            }
            set
            {
                this._CE_MEDIA = value;
            }
        }

        private int _CE_BAIXA;

        [AtributoBancoDados(AtributoBD = true)]
        public int CE_BAIXA
        {
            get
            {
                return this._CE_BAIXA;
            }
            set
            {
                this._CE_BAIXA = value;
            }
        }

        private int _SE_ALTA;

        [AtributoBancoDados(AtributoBD = true)]
        public int SE_ALTA
        {
            get
            {
                return this._SE_ALTA;
            }
            set
            {
                this._SE_ALTA = value;
            }
        }

        private int _SE_MEDIA;

        [AtributoBancoDados(AtributoBD = true)]
        public int SE_MEDIA
        {
            get
            {
                return this._SE_MEDIA;
            }
            set
            {
                this._SE_MEDIA = value;
            }
        }

        private int _SE_BAIXA;

        [AtributoBancoDados(AtributoBD = true)]
        public int SE_BAIXA
        {
            get
            {
                return this._SE_BAIXA;
            }
            set
            {
                this._SE_BAIXA = value;
            }
        }

    }
}
