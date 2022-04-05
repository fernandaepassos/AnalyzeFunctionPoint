using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Prospect
    {
        // Methods
        public DataSet ListaProspect(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select  Prospect.IdProspect                , Pessoa.Nome                , Prospect.CodProspect                , Prospect.DescVeiculoInteresseCliente                , Pessoa.IdFilial                , Prospect.FlagInativo                , Midia.DescMidia                , Tipo.DescTipo as DescTipoMotivoContato                , Prospect.PlacaProspect                , Pessoa.CnpjCpf                , Pessoa.Telefone                , Pessoa.Email                , Municipio.DescMunicipio                , convert(Varchar,Prospect.UltimaAtualizacao,103) +' '+ convert(Varchar,Prospect.UltimaAtualizacao,108) as UltimaAtualizacao                , Usuario.Login as DescUltimoUsuario                from Prospect                left join Usuario on Usuario.IdUsuario = Prospect.IdUltimoUsuario                left join Pessoa on Pessoa.IdPessoa = Prospect.IdPessoa                left join Midia on Midia.IdMidia = Prospect.IdMidia                left join Tipo on tipo.IdTipo = Prospect.IdTipoMotivoContato                left join Municipio on Municipio.IdMunicipio = Pessoa.IdMunicipio                where Pessoa.IdFilial = " + intIdFilial + " ");
                set2 = set;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return set2;
        }
    }
}
