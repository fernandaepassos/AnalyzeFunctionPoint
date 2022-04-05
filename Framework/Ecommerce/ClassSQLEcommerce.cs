using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;
using Framework.Reflection.Generic;


namespace Framework.Ecommerce
{
    public class ClassSQLEcommerce : ClassSQLGeneric
    {
        // Methods
        public DataSet GetFornecedor(string strIdEmpresa)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = "select IdFornecedor, Nome from EcomFornecedor where idempresa = " + strIdEmpresa;
                set3 = base.ObterDataSet(comandoSQL);
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
                if (table != null)
                {
                    table.Dispose();
                }
            }
            return set3;
        }

        public DataSet GetMarca(string strIdEmpresa)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select IdMarca, Marca from EcomMarca where IdEmpresa = " + strIdEmpresa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdMarca", typeof(int));
                    table.Columns.Add("Marca", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdMarca"].ToString().Trim()), set.Tables[0].Rows[i]["Marca"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
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
                if (table != null)
                {
                    table.Dispose();
                }
            }
            return set3;
        }

        public DataSet GetProduto(string strIdEmpresa, string strSqlWhere = "")
        {
            DataSet set;
            try
            {
                string comandoSQL = (" select " + base.Tools.MaxLinhaInicial() + " IdProduto ") + " , (select Arquivo from SigeArquivo where IdArquivo in (select top 1 IdArquivo from SigeArquivoVinculo where NomeArquivo = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto)) as Imagem                , NumReferencia                 , EcomProduto.Nome                , QtdCliques                 , Preco                , PrecoPor                , PrecoAVista                , Marca                , EcomProduto.IdCategoria                , FlagDisponivel                , Preco as PrecoNormal                , IdTipoPreco                , QtdNoEstoque                , Marca                , (CASE WHEN FlagLancamento = 0 THEN 'Não' ELSE CASE WHEN FlagLancamento = 1 THEN 'Sim' ELSE 'Não' END END) as Lancamento                , (CASE WHEN FlagDestaque = 0 THEN 'Não' ELSE CASE WHEN FlagDestaque = 1 THEN 'Sim' ELSE 'Não' END END) as Destaque                , (select top 1 precopromocao from EcomProdutoPromocao where FlagAtivo = 1 and IdProduto = EcomProduto.IdProduto) as Promocao                , (CASE WHEN FlagDisponivel = 0 THEN 'Não' ELSE CASE WHEN FlagDisponivel = 1 THEN 'Sim' ELSE 'Não' END END) as Disponivel                , (CASE WHEN FlagFreteGratis = 0 THEN 'Não' ELSE CASE WHEN FlagFreteGratis = 1 THEN 'Sim' ELSE 'Não' END END) as FlagFreteGratis                , FlagFreteGratis as IdFlagFreteGratis                , FlagDisponivel as IdFlagDisponivel                , (SELECT SUM(Nota) FROM SigeAvaliacao WHERE IdEmpresa = EcomProduto.IdEmpresa AND IdSistema = EcomProduto.IdSistema AND NomeTabela = 'EcomProduto' AND IdRegistroTabela = EcomProduto.IdProduto) AS Nota                , (select Valor from SigeParametroValor where IdParametro = 17 and IdEmpresa = EcomProduto.IdEmpresa )  as QtdEstoqueMinimo                , (select COUNT(1) from SigeArquivoVinculo where NomeTabela = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto) as QtdImagem                , (case when AlturaCm = 0 and LarguraCm = 0 and ComprimentoCm = 0 and PesoGrama = 0 then 'Não' else 'Sim' end) As TemCubagem                 , CASE WHEN (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdTipo = 37 AND IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomProduto.IdProduto  AND NomeTabela = 'EcomProduto') ) IS NULL THEN 'http://www.sisclick.com.br/ecommerce/Files/Anexos/FotoIndisponivel.png' ELSE (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdTipo = 37 AND IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomProduto.IdProduto  AND NomeTabela = 'EcomProduto') ) END AS Foto                , (case when IdProduto in (select IdRegistroTabela from SigeArquivoVinculo where NomeTabela = 'EcomProduto') then 1 else 0 end) TemImagem                , (CASE WHEN ECOMCATEGORIA.IdCategoriaSup IS NULL THEN ECOMCATEGORIA.Nome ELSE EcomCategoriaSup.Nome + ' >> '+ ECOMCATEGORIA.Nome END)as NomeCategoria                from EcomProduto                Left Join EcomCategoria on EcomCategoria.IdCategoria = EcomProduto.IdCategoria                Left Join EcomCategoria as EcomCategoriaSup on EcomCategoriaSup.IdCategoria = EcomCategoria.IdCategoriaSup                where EcomProduto.IdEmpresa = " + strIdEmpresa + " ";
                if (!string.IsNullOrEmpty(strSqlWhere))
                {
                    comandoSQL = comandoSQL + strSqlWhere;
                }
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaAtributo(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " select IdAtributo                , EcomAtributo.Nome                , EcomAtributo.idultimousuario                , SigeUsuario.Login                , CONVERT(varchar, EcomAtributo.ultimaatualizacao,103)+' '+ CONVERT(varchar,EcomAtributo.ultimaatualizacao,108) as UltimaAtualizacao                from EcomAtributo                Left Join SigeUsuario on SigeUsuario.IdUsuario = EcomAtributo.IdUltimousuario                where EcomAtributo.IdEmpresa = " + strIdEmpresa + " ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaCategoria(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " select ecomcategoria.IdCategoria                , ecomcategoria.IdCategoriaSup                , (case when ecomcategoria.IdCategoriaSup is not null then EcomCategoriaSup.Nome +' >> '+ EcomCategoria.Nome else EcomCategoria.Nome end) as Nome                , ecomcategoria.AtivoInativo                , ecomcategoria.Chave                , EcomCategoria.Ordem                , convert(varchar,ecomcategoria.UltimaAtualizacao,103)+' '+ convert(varchar,ecomcategoria.UltimaAtualizacao,108) as UltimaAtualizacao                , SigePessoa.NomePessoa                from ecomcategoria                 Left Join EcomCategoria as EcomCategoriaSup on EcomCategoriaSup.IdCategoria = EcomCategoria.IdCategoriaSup                Left Join SigeUsuario on SigeUsuario.IdUsuario = ecomcategoria.IdUltimoUsuario                Left Join SigePessoa on SigePessoa.IdPessoa = SigeUsuario.IdPessoa                 where ecomcategoria.idempresa = " + strIdEmpresa + " order by ecomcategoria.Chave ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaCliente(string strIdEmpresa, string strSqlWhere = "")
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " select SigePessoa.IdPessoa ,SigePessoa.IdEmpresa                ,NomePessoa                ,SigePessoa.IdTipo                , SigeTipo.NomeTipo as TipoCliente                ,TipoPfPj                ,SigePessoa.IdUltimoUsuario                , SigeUsuario.Login as DescUltimoUsuario                ,SigePessoa.IdInclusorUsuario                , SigeUsuarioInclusor.Login as DescInclusorUsuario                ,convert(varchar,SigePessoa.UltimaAtualizacao, 103)+ ' '+ CONVERT(varchar,SigePessoa.UltimaAtualizacao,108) as UltimaAtualizacao                ,convert(varchar,SigePessoa.DataInclusao,103)+' '+convert(varchar,SigePessoa.DataInclusao,108) as DataInclusao                ,CnpjCpf                ,Identidade                ,IdentidadeUF                ,RazaoSocial                ,InscEstadual                ,InscMunicipal                ,Cep                ,Endereco                ,Numero                ,Bairro                ,SigePessoa.IdPais                , SigePais.Nome as Pais                , SigePessoa.IdCidade                , SigeCidade.DescMunicipio                ,Complemento                ,Admissao                ,Demissao                , CONVERT(varchar,Nascimento,103)+' '+ CONVERT(varchar,Nascimento,108) as Nascimento                ,Mae                ,Pai                ,QtdDependentes                ,Telefone                ,Celular                ,Email                ,NomeFantasia                ,NomeDoResponsalvel                ,ReceberNewsLatter                ,SiglaUf                ,Sexo                ,IdTipoContato                from SigePessoa                Left Join SigeCliente on SigeCliente.IdPessoa = SigePessoa.IdPessoa                Left Join SigeTipo on SigeTipo.IdTipo = SigePessoa.IdTipo                Left Join SigePais on SigePais.IdPais = SigePessoa.IdPais                Left Join SigeCidade on SigeCidade.IdCidade = SigePessoa.IdCidade                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigePessoa.IdUltimoUsuario                Left Join SigeUsuario as SigeUsuarioInclusor on SigeUsuarioInclusor.IdUsuario = SigePessoa.IdInclusorUsuario                where SigePessoa.IdEmpresa = " + strIdEmpresa + " and SigeCliente.IdPessoa = SigePessoa.IdPessoa ";
                if ((strSqlWhere != null) && (strSqlWhere.Trim() != ""))
                {
                    comandoSQL = comandoSQL + strSqlWhere;
                }
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaClienteContratadosPelaEmpresa(string strIdEmpresa, string strSqlWhere = "")
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = (" select SigePessoa.IdPessoa ,SigePessoa.IdEmpresa                ,NomePessoa                ,SigePessoa.IdTipo                , SigeTipo.NomeTipo as TipoCliente                ,TipoPfPj                ,SigePessoa.IdUltimoUsuario                , SigeUsuario.Login as DescUltimoUsuario                ,SigePessoa.IdInclusorUsuario                , SigeUsuarioInclusor.Login as DescInclusorUsuario                ,convert(varchar,SigePessoa.UltimaAtualizacao, 103)+ ' '+ CONVERT(varchar,SigePessoa.UltimaAtualizacao,108) as UltimaAtualizacao                ,convert(varchar,SigePessoa.DataInclusao,103)+' '+convert(varchar,SigePessoa.DataInclusao,108) as DataInclusao                ,CnpjCpf                ,Identidade                ,IdentidadeUF                ,SigePessoa.RazaoSocial                ,InscEstadual                ,SigePessoa.InscMunicipal                ,Cep                ,Endereco                ,Numero                ,Bairro                ,SigePessoa.IdPais                , SigePais.Nome as Pais                , SigePessoa.IdCidade                , SigeCidade.DescMunicipio                ,Complemento                ,Admissao                ,Demissao                , CONVERT(varchar,Nascimento,103)+' '+ CONVERT(varchar,Nascimento,108) as Nascimento                ,Mae                ,Pai                ,QtdDependentes                ,Telefone                ,Celular                ,Email                ,NomeFantasia                ,NomeDoResponsalvel                ,ReceberNewsLatter                ,SiglaUf                ,Sexo                ,IdTipoContato                from SigePessoa                Left Join SigeCliente on SigeCliente.IdPessoa = SigePessoa.IdPessoa                Left Join SigeTipo on SigeTipo.IdTipo = SigePessoa.IdTipo                Left Join SigePais on SigePais.IdPais = SigePessoa.IdPais                Left Join SigeCidade on SigeCidade.IdCidade = SigePessoa.IdCidade                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigePessoa.IdUltimoUsuario                Left Join SigeUsuario as SigeUsuarioInclusor on SigeUsuarioInclusor.IdUsuario = SigePessoa.IdInclusorUsuario                Left Join SigeEmpresa on SigeEmpresa.idpessoa = SigePessoa.IdPessoa and SigeEmpresa.IdEmpresaContratante = " + strIdEmpresa + " ") + " where SigeCliente.IdPessoa = SigePessoa.IdPessoa  ";
                if ((strSqlWhere != null) && (strSqlWhere.Trim() != ""))
                {
                    comandoSQL = comandoSQL + strSqlWhere;
                }
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaEcomTabelaFrete(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " select IdTabelaFrete                ,EcomTabelaFrete.IdEmpresa                ,Nome                ,IdTipoVeiculo                , SigeTipo.NomeTipo as DescTipoVeiculo                ,ValorEntrega                ,ValorDescarga                ,KmFinal                ,PesoCubadoInicial                ,PesoCubadoFinal                ,FlagAtivoInativo                ,EcomTabelaFrete.IdUltimoUsuario                , SigeUsuario.Login as DescUltimoUsuario                ,(CONVERT(varchar,EcomTabelaFrete.UltimaAtualizacao,103)+ ' '+CONVERT(varchar,EcomTabelaFrete.UltimaAtualizacao,108)) as UltimaAtualizacao                from EcomTabelaFrete                 Left Join SigeUsuario on SigeUsuario.IdUsuario = EcomTabelaFrete.IdUltimoUsuario                Left Join SigeTipo on SigeTipo.IdTipo = EcomTabelaFrete.IdTipoVeiculo                where EcomTabelaFrete.IdEmpresa = " + strIdEmpresa + "  ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaMarca(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " Select IdMarca                , Marca                , EcomMarca.IdEmpresa                , CONVERT(varchar,EcomMarca.UltimaAtualizacao,103) +' '+ CONVERT(varchar,EcomMarca.UltimaAtualizacao,108) as UltimaAtualizacao                , SigePessoa.NomePessoa as DescUltimoUsuario                , CASE WHEN (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomMarca.IdMarca AND NomeTabela = 'EcomMarca') ) IS NULL THEN 'http://www.sisclick.com.br/ecommerce/Files/Anexos/FotoIndisponivel.png' ELSE (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomMarca.IdMarca  AND NomeTabela = 'EcomMarca') ) END AS Foto                from EcomMarca                Left Join SigeUsuario on SigeUsuario.idusuario = EcomMarca.IdUltimoUsuario                Left Join SigePessoa on SigePessoa.IdPessoa = SigeUsuario.IdPessoa                where EcomMarca.IdEmpresa = " + strIdEmpresa + " ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListaProspect(string strIdEmpresa, string strSqlWhere = "")
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " select SigePessoa.IdPessoa ,SigePessoa.IdEmpresa, NomePessoa                , SigePessoa.IdTipo                , TipoPfPj                , SigePessoa.IdUltimoUsuario                , SigeUsuario.Login as DescUltimoUsuario                , SigePessoa.IdInclusorUsuario                , SigeUsuarioInclusor.Login as DescInclusorUsuario                , convert(varchar,SigePessoa.UltimaAtualizacao, 103)+ ' '+ CONVERT(varchar,SigePessoa.UltimaAtualizacao,108) as UltimaAtualizacao                , convert(varchar,SigePessoa.DataInclusao,103)+' '+convert(varchar,SigePessoa.DataInclusao,108) as DataInclusao                , CnpjCpf                , Identidade                , IdentidadeUF                , SigePessoa.RazaoSocial                , InscEstadual                , SigePessoa.InscMunicipal                , Cep                , Endereco                , Numero                , Bairro                , SigePessoa.IdPais                , SigePais.Nome as Pais                , SigePessoa.IdCidade                , SigeCidade.DescMunicipio                , Complemento                , Admissao                , Demissao                , CONVERT(varchar,Nascimento,103)+' '+ CONVERT(varchar,Nascimento,108) as Nascimento                , Mae                , Pai                , QtdDependentes                , Telefone                , Celular                , Email                , NomeFantasia                , NomeDoResponsalvel                , ReceberNewsLatter                , SiglaUf                , Sexo                , IdTipoContato                , SigeStatus.NomeStatus                from SigePessoa                Left Join SigeProspect on SigeProspect.IdPessoa = SigePessoa.IdPessoa                Left Join SigePais on SigePais.IdPais = SigePessoa.IdPais                Left Join SigeCidade on SigeCidade.IdCidade = SigePessoa.IdCidade                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigePessoa.IdUltimoUsuario                Left Join SigeUsuario as SigeUsuarioInclusor on SigeUsuarioInclusor.IdUsuario = SigePessoa.IdInclusorUsuario                Left Join SigeStatus on SigeStatus.IdStatus = SigeProspect.IdStatusProspect                Left Join SigeEmpresa on SigeEmpresa.idpessoa = SigePessoa.IdPessoa and SigeEmpresa.IdEmpresaContratante = " + strIdEmpresa + " where SigeProspect.IdPessoa = SigePessoa.IdPessoa  ";
                if ((strSqlWhere != null) && (strSqlWhere.Trim() != ""))
                {
                    comandoSQL = comandoSQL + strSqlWhere;
                }
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet ListLogAuditoria(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                string comandoSQL = " select IdLogAuditoria                ,NomeTabela                ,LogAuditoria.IdUsuario                ,SigeUsuario.Login as LoginUsuario                ,Acao                ,Registro                ,(CONVERT(varchar,DataLog,103)+' '+ CONVERT(varchar,DataLog,108)) as DataLog                ,Origem                ,NomeTela                from LogAuditoria                 Left Join SigeUsuario on SigeUsuario.IdUsuario = LogAuditoria.IdUsuario                where LogAuditoria.IdUsuario in (select IdUsuario from SigeUsuario where IdEmpresa = " + strIdEmpresa + ") ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }
    }
}
 
