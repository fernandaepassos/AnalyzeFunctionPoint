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
    public class ClsEcomFacilidade : ClassGenericEcommerce
    {
        // Fields
        private string _Frase;
        private int _IdArquivo;
        private int _IdEmpresa;
        private int _IdFacilidade;

        // Methods
        public DataSet ListaFacilidades(string strIdEmpresa)
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
                set = AcessoBD.ObterDataSet("select IdFacilidade                , Frase                , 'http://www.sisclick.com.br/ecommerce/Files/Anexos/'+ substring(SigeArquivo.Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo)) as Arquivo                , SigeUsuario.Login as DescUltimoUsuario                , convert(varchar,EcomFacilidade.UltimaAtualizacao,103) +' '+ CONVERT(varchar,EcomFacilidade.UltimaAtualizacao,108) as UltimaAtualizacao                from EcomFacilidade                 Left Join SigeUsuario on SigeUsuario.IdUsuario = EcomFacilidade.IdUltimoUsuario                Left Join SigeArquivo on SigeArquivo.IdArquivo in (select IdArquivo From SigeArquivoVinculo Where NomeTabela = 'EcomFacilidade' and IdRegistroTabela = EcomFacilidade.IdFacilidade )                 where EcomFacilidade.idempresa = " + strIdEmpresa + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public string Frase
        {
            get
            {
                return this._Frase;
            }
            set
            {
                this._Frase = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdArquivo
        {
            get
            {
                return this._IdArquivo;
            }
            set
            {
                this._IdArquivo = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public int IdFacilidade
        {
            get
            {
                return this._IdFacilidade;
            }
            set
            {
                this._IdFacilidade = value;
            }
        }
    }

}
 
