using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Framework.Reflection.Rotinas;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Ecommerce;

namespace Framework.Ecommerce
{
public class ClsEcomProduto : ClassGenericEcommerce
{
    // Fields
    private double _AlturaCm;
    private double _ComprimentoCm;
    private string _DescricaoLonga;
    private string _DescUltimoUsuario;
    private string _Especificacao;
    private string _EspecificacaoTecnica;
    private string _Fabricante;
    private string _FlagDestaque;
    private string _FlagDisponivel;
    private string _FlagFreteGratis;
    private string _FlagLancamento;
    private string _Garantia;
    private string _GarantiaDetalhe;
    private int _IdCategoria;
    private int _IdEmpresa;
    private int _IdFornecedor;
    private int _IdMarca;
    private int _IdProduto;
    private int _IdSistema;
    private int _IdTipo;
    private int _IdTipoPreco;
    private int _IdUltimoUsuario;
    private double _LarguraCm;
    private string _Marca;
    private string _Modelo;
    private string _Nome;
    private int _NumReferencia;
    private string _Peso;
    private double _PesoGrama;
    private double _Preco;
    private double _PrecoAVista;
    private double _PrecoPor;
    private int _QtdCliques;
    private int _QtdNoEstoque;
    private string _UltimaAtualizacao;
    private string _UrlApoio;

    // Methods
    public DataSet BuscarProduto(int id)
    {
        DataSet set2;
        try
        {
            string strSQl = " select IdProduto ";                 
            strSQl += " , Nome ";                
            strSQl += " , Especificacao ";                
            strSQl += " , DescricaoLonga ";                
            strSQl += " , EspecificacaoTecnica ";                
            strSQl += " , Preco ";                
            strSQl += " , PrecoPor  ";               
            strSQl += " , PrecoAVista ";                
            strSQl += " , IdCategoria  ";               
            strSQl += " , IdTipo ";                
            strSQl += " , IdTipoPreco  ";               
            strSQl += " , EcomMarca.Marca ";                
            strSQl += " , EcomProduto.IdEmpresa ";                
            strSQl += " , IdSistema  ";               
            strSQl += " , NumReferencia  ";               
            strSQl += " , Modelo ";                
            strSQl += " , Fabricante ";                
            strSQl += " , FlagFreteGratis  ";               
            strSQl += " , FlagDisponivel ";                
            strSQl += " , FlagLancamento ";                
            strSQl += " , FlagDestaque ";                
            strSQl += " , UrlApoio ";                
            strSQl += " , Peso   ";              
            strSQl += " , PesoGrama   ";              
            strSQl += " , ComprimentoCm  ";               
            strSQl += " , LarguraCm  ";               
            strSQl += " , AlturaCm ";                
            strSQl += " , QtdNoEstoque ";                
            strSQl += " , Garantia ";                
            strSQl += " , GarantiaDetalhe ";                
            strSQl += " , QtdCliques  ";               
            strSQl += " ,  EcomProduto.IdUltimoUsuario  ";               
            strSQl += " ,  SigeUsuario.Login AS  DescUltimoUsuario ";                
            strSQl += " ,  CONVERT(VARCHAR, EcomProduto.UltimaAtualizacao, 103) AS UltimaAtualizacao ";                
            strSQl += " , (SELECT case when sum(Nota) is null then 0 else sum(Nota) end  as Nota From SigeAvaliacao where nometabela = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto) as Nota ";                
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 3) as UsarCorreios ";                
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 7) as ConfigurouPesqCep ";                
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 8) as ExibirAvaliaProduto ";                
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 17) as QtdEstoqueMinimo  ";               
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 20) as ExibirQtdVisualizacaoInProdDaLoja  ";               
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 21) as MsgEmCasoDeEstoqueIndisponivel ";                
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 22) as HabilitarVenda   ";
            strSQl += " , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 42) as ExibirMsgQuandoEstoqueDisponivel ";
            strSQl += " from EcomProduto  ";               
            strSQl += " LEFT OUTER JOIN SigeUsuario ON EcomProduto.IdUltimoUsuario = SigeUsuario.IdUsuario ";                
            strSQl += " Left Join EcomMarca on EcomMarca.IdMarca = EcomProduto.IdMarca ";
            strSQl += " where EcomProduto.IdProduto = " + id + "  ";

            set2 = AcessoBD.ObterDataSet(strSQl);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return set2;
    }

    public ClsEcomProduto BuscarProduto(ClsEcomProduto objClasse, int id)
    {
        ClsEcomProduto produto;
        try
        {
            DataSet set = AcessoBD.ObterDataSet("                 select                 IdProduto                , Nome                , Especificacao                , DescricaoLonga                , EspecificacaoTecnica                , Preco                , PrecoPor                , PrecoAVista                , IdCategoria                , IdTipo                , IdTipoPreco                , Marca                , EcomProduto.IdEmpresa                , IdSistema                , NumReferencia                , Modelo                , Fabricante                , FlagFreteGratis                , FlagDisponivel                , FlagLancamento                , FlagDestaque                , UrlApoio                , Peso                , QtdNoEstoque                , Garantia                , GarantiaDetalhe                , QtdCliques                ,  EcomProduto.IdUltimoUsuario                ,  SigeUsuario.Login AS  DescUltimoUsuario                ,  CONVERT(VARCHAR, EcomProduto.UltimaAtualizacao, 103) AS UltimaAtualizacao                , AlturaCm                , LarguraCm                , ComprimentoCm                , PesoGrama                , (select Valor from SigeParametroValor where IdParametro = 17 and IdEmpresa = EcomProduto.IdEmpresa )  as QtdEstoqueMinimo                , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 22) as HabilitarVenda                from EcomProduto                LEFT OUTER JOIN SigeUsuario ON EcomProduto.IdUltimoUsuario = SigeUsuario.IdUsuario                where EcomProduto.IdProduto = " + id.ToString().Trim() + " ");
            if (set.Tables[0].Rows.Count > 0)
            {
                DataRow row = set.Tables[0].Rows[0];
                objClasse.IdProduto = (row["IdProduto"].ToString().Trim() != "") ? Convert.ToInt32(row["IdProduto"].ToString()) : 0;
                objClasse.Nome = row["Nome"].ToString();
                objClasse.IdCategoria = ((row["IdCategoria"] != null) && (row["IdCategoria"].ToString() != "")) ? Convert.ToInt32(row["IdCategoria"].ToString()) : 0;
                objClasse.Preco = !string.IsNullOrEmpty(row["Preco"].ToString().Trim()) ? Convert.ToDouble(row["Preco"]) : 0.0;
                objClasse.PrecoAVista = !string.IsNullOrEmpty(row["PrecoAVista"].ToString().Trim()) ? Convert.ToDouble(row["PrecoAVista"]) : 0.0;
                objClasse.PrecoPor = !string.IsNullOrEmpty(row["PrecoPor"].ToString().Trim()) ? Convert.ToDouble(row["PrecoPor"]) : 0.0;
                objClasse.IdTipo = !string.IsNullOrEmpty(row["IdTipo"].ToString()) ? Convert.ToInt32(row["IdTipo"].ToString()) : 0;
                objClasse.Marca = row["Marca"].ToString().Trim();
                objClasse.IdEmpresa = (row["IdEmpresa"].ToString().Trim() != "") ? Convert.ToInt32(row["IdEmpresa"].ToString()) : 0;
                objClasse.IdSistema = (row["IdSistema"].ToString().Trim() != "") ? Convert.ToInt32(row["IdSistema"].ToString()) : 0;
                objClasse.NumReferencia = (row["NumReferencia"].ToString().Trim() != "") ? Convert.ToInt32(row["NumReferencia"].ToString().Trim()) : 0;
                objClasse.Modelo = row["Modelo"].ToString().Trim();
                objClasse.Fabricante = row["Fabricante"].ToString().Trim();
                objClasse.FlagFreteGratis = row["FlagFreteGratis"].ToString().Trim();
                objClasse.FlagDisponivel = row["FlagDisponivel"].ToString().Trim();
                objClasse.FlagLancamento = row["FlagLancamento"].ToString().Trim();
                objClasse.FlagDestaque = row["FlagDestaque"].ToString().Trim();
                objClasse.DescricaoLonga = row["DescricaoLonga"].ToString().Trim();
                objClasse.IdUltimoUsuario = (row["IdUltimoUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdUltimoUsuario"].ToString()) : 0;
                objClasse.DescUltimoUsuario = row["DescUltimoUsuario"].ToString().Trim();
                objClasse.UltimaAtualizacao = row["UltimaAtualizacao"].ToString().Trim();
                objClasse.Especificacao = row["Especificacao"].ToString().Trim();
                objClasse.EspecificacaoTecnica = row["EspecificacaoTecnica"].ToString().Trim();
                objClasse.UrlApoio = row["UrlApoio"].ToString().Trim();
                objClasse.Peso = row["Peso"].ToString().Trim();
                objClasse.QtdNoEstoque = (row["QtdNoEstoque"].ToString().Trim() != "") ? Convert.ToInt32(row["QtdNoEstoque"].ToString()) : 0;
                objClasse.Garantia = row["Garantia"].ToString().Trim();
                objClasse.GarantiaDetalhe = row["GarantiaDetalhe"].ToString().Trim();
                objClasse.QtdCliques = (row["QtdCliques"].ToString().Trim() != "") ? Convert.ToInt32(row["QtdCliques"].ToString()) : 0;
                objClasse.IdTipoPreco = (row["IdTipoPreco"].ToString().Trim() != "") ? Convert.ToInt32(row["IdTipoPreco"].ToString()) : 0;
                objClasse.AlturaCm = ((row["AlturaCm"].ToString().Trim() != "") || (row["AlturaCm"].ToString().Trim() == "0")) ? Convert.ToDouble(row["AlturaCm"].ToString()) : 0.0;
                objClasse.LarguraCm = ((row["LarguraCm"].ToString().Trim() != "") || (row["LarguraCm"].ToString().Trim() == "0")) ? Convert.ToDouble(row["LarguraCm"].ToString()) : 0.0;
                objClasse.ComprimentoCm = ((row["ComprimentoCm"].ToString().Trim() != "") || (row["ComprimentoCm"].ToString().Trim() == "0")) ? Convert.ToDouble(row["ComprimentoCm"].ToString()) : 0.0;
                objClasse.PesoGrama = ((row["PesoGrama"].ToString().Trim() != "") || (row["PesoGrama"].ToString().Trim() == "0")) ? Convert.ToDouble(row["PesoGrama"].ToString()) : 0.0;
                set.Dispose();
            }
            produto = objClasse;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return produto;
    }

    public void ExcluirProduto(ClsEcomProduto objClasse, int id)
    {
        try
        {
            if (id > 0)
            {
                AcessoBD.DeleteRegistro(objClasse, id);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public string GetDadosProdutos(string strIdProduto, bool ExibirNomeProduto)
    {
        string str2;
        try
        {
            string sqlComand = "select * from EcomProduto where IdProduto = " + strIdProduto + " ";
            DataSet set = new DataSet();
            set = AcessoBD.ObterDataSet(sqlComand);
            if ((((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0)) && ExibirNomeProduto)
            {
                return set.Tables[0].Rows[0]["Nome"].ToString().Trim();
            }
            str2 = "";
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return str2;
    }

    public DataSet GetFormaPagamento()
    {
        DataSet set;
        try
        {
            string sqlComand = "select IdFormaPagamento, NomeFormaPagamento from EcomFormaPagamento ";
            set = AcessoBD.ObterDataSet(sqlComand);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return set;
    }

    public DataSet GetImagens(string strIdProduto)
    {
        DataSet set;
        try
        {
            if (string.IsNullOrEmpty(strIdProduto.Trim()))
            {
                return null;
            }
            set = AcessoBD.ObterDataSet(((((((("SELECT SigeArquivo.IdArquivo " + " ,'http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo)) AS Imagem ") + " , SigeTipo.NomeTipo " + " , SigeArquivo.IdTipo ") + " , SigeArquivo.NomeArquivo" + " FROM SigeArquivo ") + " LEFT OUTER JOIN SigeTipo ON SigeTipo.IdTipo = SigeArquivo.IdTipo " + " WHERE IdArquivo IN  ") + "(" + "     SELECT IdArquivo  ") + "     FROM SigeArquivoVinculo  " + "     WHERE NomeTabela = 'EcomProduto'  ") + "     AND IdRegistroTabela = " + strIdProduto + " ") + " ) " + " ORDER BY SigeArquivo.IdTipo DESC ");
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return set;
    }

    public DataSet ListaProduto(string strIdEmpresa, string strSqlWhere = "")
    {
        DataSet set2;
        try
        {
            if ((strIdEmpresa == null) || (strIdEmpresa.Trim() == ""))
            {
                return null;
            }
            string sqlComand = " select  IdProduto ";
            sqlComand = sqlComand + " , (select Arquivo from SigeArquivo where IdArquivo in (select top 1 IdArquivo from SigeArquivoVinculo where NomeArquivo = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto)) as Imagem                , NumReferencia                 , Nome                , QtdCliques                 , Preco                , PrecoPor                , PrecoAVista                , Marca                , IdCategoria                , FlagDisponivel                , Preco as PrecoNormal                , IdTipoPreco                , QtdNoEstoque                , (CASE WHEN FlagLancamento = 0 THEN 'Não' ELSE CASE WHEN FlagLancamento = 1 THEN 'Sim' ELSE 'Não' END END) as Lancamento                , (CASE WHEN FlagDestaque = 0 THEN 'Não' ELSE CASE WHEN FlagDestaque = 1 THEN 'Sim' ELSE 'Não' END END) as Destaque                , (select top 1 precopromocao from EcomProdutoPromocao where FlagAtivo = 1 and IdProduto = EcomProduto.IdProduto) as Promocao                , (CASE WHEN FlagDisponivel = 0 THEN 'Não' ELSE CASE WHEN FlagDisponivel = 1 THEN 'Sim' ELSE 'Não' END END) as Disponivel                , (CASE WHEN FlagFreteGratis = 0 THEN 'Não' ELSE CASE WHEN FlagFreteGratis = 1 THEN 'Sim' ELSE 'Não' END END) as FlagFreteGratis                , (SELECT SUM(Nota) FROM SigeAvaliacao WHERE IdEmpresa = EcomProduto.IdEmpresa AND IdSistema = EcomProduto.IdSistema AND NomeTabela = 'EcomProduto' AND IdRegistroTabela = EcomProduto.IdProduto) AS Nota                , (select Valor from SigeParametroValor where IdParametro = 17 and IdEmpresa = EcomProduto.IdEmpresa )  as QtdEstoqueMinimo                , (select COUNT(1) from SigeArquivoVinculo where NomeTabela = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto) as QtdImagem                , (case when AlturaCm = 0 and LarguraCm = 0 and ComprimentoCm = 0 and PesoGrama = 0 then 'Não' else 'Sim' end) As TemCubagem                 from EcomProduto                where IdEmpresa = " + strIdEmpresa + " ";
            if (!string.IsNullOrEmpty(strSqlWhere))
            {
                sqlComand = sqlComand + strSqlWhere;
            }
            set2 = AcessoBD.ObterDataSet(sqlComand);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return set2;
    }

    public DataSet ListaProduto(string strIdEmpresa, string strSqlWhere = "", string strTotal = "")
    {
        DataSet set2;
        try
        {
            if ((strIdEmpresa == null) || (strIdEmpresa.Trim() == ""))
            {
                return null;
            }
            string sqlComand = " select  IdProduto ";
            sqlComand = sqlComand + " , (select Arquivo from SigeArquivo where IdArquivo in (select top 1 IdArquivo from SigeArquivoVinculo where NomeArquivo = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto)) as Imagem                , NumReferencia                 , Nome                , QtdCliques                 , Preco                , PrecoPor                , PrecoAVista                , Marca                , IdCategoria                , FlagDisponivel                , Preco as PrecoNormal                , IdTipoPreco                , QtdNoEstoque                , (CASE WHEN FlagLancamento = 0 THEN 'Não' ELSE CASE WHEN FlagLancamento = 1 THEN 'Sim' ELSE 'Não' END END) as Lancamento                , (CASE WHEN FlagDestaque = 0 THEN 'Não' ELSE CASE WHEN FlagDestaque = 1 THEN 'Sim' ELSE 'Não' END END) as Destaque                , (select top 1 precopromocao from EcomProdutoPromocao where FlagAtivo = 1 and IdProduto = EcomProduto.IdProduto) as Promocao                , (CASE WHEN FlagDisponivel = 0 THEN 'Não' ELSE CASE WHEN FlagDisponivel = 1 THEN 'Sim' ELSE 'Não' END END) as Disponivel                , (CASE WHEN FlagFreteGratis = 0 THEN 'Não' ELSE CASE WHEN FlagFreteGratis = 1 THEN 'Sim' ELSE 'Não' END END) as FlagFreteGratis                , (SELECT SUM(Nota) FROM SigeAvaliacao WHERE IdEmpresa = EcomProduto.IdEmpresa AND IdSistema = EcomProduto.IdSistema AND NomeTabela = 'EcomProduto' AND IdRegistroTabela = EcomProduto.IdProduto) AS Nota                , (select Valor from SigeParametroValor where IdParametro = 17 and IdEmpresa = EcomProduto.IdEmpresa )  as QtdEstoqueMinimo                , (select COUNT(1) from SigeArquivoVinculo where NomeTabela = 'EcomProduto' and IdRegistroTabela = EcomProduto.IdProduto) as QtdImagem                , (case when AlturaCm = 0 and LarguraCm = 0 and ComprimentoCm = 0 and PesoGrama = 0 then 'Não' else 'Sim' end) As TemCubagem                 from EcomProduto                where IdEmpresa = " + strIdEmpresa + " ";
            if (!string.IsNullOrEmpty(strSqlWhere))
            {
                sqlComand = sqlComand + strSqlWhere;
            }
            set2 = AcessoBD.ObterDataSet(sqlComand);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return set2;
    }

    public DataSet ListaProdutoCarrinho(string strIdEmpresa, string strIdSistema)
    {
        DataSet set2;
        try
        {
            if ((strIdEmpresa == null) && (strIdEmpresa.Trim() == ""))
            {
                return null;
            }
            if ((ClsEcomCarrinho.Instancia.CodigoDosItensString == null) || (ClsEcomCarrinho.Instancia.CodigoDosItensString.Trim() == ""))
            {
                return null;
            }
            set2 = AcessoBD.ObterDataSet(" SELECT IdProduto                , Nome                , Especificacao                , DescricaoLonga                , EspecificacaoTecnica                , Preco                , PrecoPor                , PrecoAVista                , IdTipo                , IdTipoPreco                , Marca                , EcomProduto.IdEmpresa                , IdSistema                , NumReferencia                , Modelo                , Fabricante                , FlagFreteGratis                , Peso                , QtdNoEstoque                , CASE WHEN (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdTipo = 37 AND IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomProduto.IdProduto  AND NomeTabela = 'EcomProduto') ) IS NULL THEN 'http://www.sisclick.com.br/ecommerce/Files/Anexos/FotoIndisponivel.png' ELSE (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdTipo = 37 AND IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomProduto.IdProduto  AND NomeTabela = 'EcomProduto') ) END AS Foto                , (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 17) as QtdEstoqueMinimo                FROM EcomProduto                LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomProduto.IdUltimoUsuario                WHERE EcomProduto.IdEmpresa = " + strIdEmpresa + " AND IdSistema = " + strIdSistema + " and IdProduto in (" + ClsEcomCarrinho.Instancia.CodigoDosItensString + ") ");
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return set2;
    }

    public DataSet ListaProdutoLoja(string strIdEmpresa, string strIdSistema)
    {
        DataSet set2;
        try
        {
            if ((strIdEmpresa == null) && (strIdEmpresa.Trim() == ""))
            {
                return null;
            }

            string strSql = "";

             strSql = " SELECT IdProduto ";                
             strSql  += " , Nome ";                
             strSql  += ", Especificacao ";                
             strSql  += ", DescricaoLonga  ";               
             strSql  += ", EspecificacaoTecnica ";                
             strSql  += ", Preco  ";               
             strSql  += ", PrecoPor ";                
             strSql  += ", PrecoAVista ";                
             strSql  += ", IdCategoria   ";              
             strSql  += ", IdTipo ";                
             strSql  += ", IdTipoPreco    ";             
             strSql  += ", EcomMarca.Marca  ";               
             strSql  += ", EcomProduto.IdEmpresa   ";              
             strSql  += ", IdSistema ";                
             strSql  += ", NumReferencia   ";              
             strSql  += ", Modelo  ";               
             strSql  += ", Fabricante  ";               
             strSql  += ", FlagFreteGratis  ";               
             strSql  += ", FlagDisponivel   ";              
             strSql  += ", FlagLancamento  ";               
             strSql  += ", FlagDestaque  ";               
             strSql  += ", UrlApoio  ";               
             strSql  += ", Peso   ";              
             strSql  += ", QtdNoEstoque ";                
             strSql  += ", Garantia   ";              
             strSql  += ", GarantiaDetalhe    ";             
             strSql  += ", CASE WHEN QtdCliques IS NULL THEN 0 ELSE QtdCliques END AS QtdCliques  ";               
             strSql  += ", EcomProduto.IdUltimoUsuario   ";              
             strSql  += ", SigeUsuario.Login AS DescUltimoUsuario  ";               
             strSql  += ", CONVERT(VARCHAR,EcomProduto.UltimaAtualizacao,103)+' '+CONVERT(VARCHAR,EcomProduto.UltimaAtualizacao,108) UltimaAtualizacao   ";              
             strSql  += ", CASE WHEN (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdTipo = 37 AND IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomProduto.IdProduto  AND NomeTabela = 'EcomProduto') ) IS NULL THEN 'http://www.sisclick.com.br/ecommerce/Files/Anexos/FotoIndisponivel.png' ELSE (SELECT top 1 ('http://www.sisclick.com.br/ecommerce/Files/Anexos/'+substring(Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo))) FROM SigeArquivo WHERE IdTipo = 37 AND IdArquivo in (SELECT IdArquivo FROM SigeArquivoVinculo WHERE IdRegistroTabela = EcomProduto.IdProduto  AND NomeTabela = 'EcomProduto') ) END AS Foto  ";
             strSql  += ", (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 17) as QtdEstoqueMinimo  ";               
             strSql  += ", (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 21) as MsgEmCasoDeEstoqueIndisponivel   ";              
             strSql  += ", (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 22) as HabilitarVenda  ";
             strSql  += ", (SELECT valor FROM SigeParametroValor where idempresa = EcomProduto.IdEmpresa and idparametro = 42) as ExibirMsgQuandoEstoqueDisponivel ";
             strSql  += ", EcomMarca.IdMarca ";
             strSql  += "FROM EcomProduto  ";               
             strSql  += "LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomProduto.IdUltimoUsuario   ";              
             strSql  += "Left Join EcomMarca on EcomMarca.IdMarca = EcomProduto.IdMarca ";
             strSql  += "WHERE EcomProduto.IdEmpresa = "+ strIdEmpresa +"  ";
             strSql  += "AND IdSistema = "+ strIdSistema +"   ";
             strSql  += "AND FlagDisponivel = 1   ";

             set2 = AcessoBD.ObterDataSet(strSql);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return set2;
    }

    public int SalvarProduto(ClsEcomProduto objEcomProduto, int id)
    {
        int num2;
        try
        {
            num2 = AcessoBD.InsertUpdateRegistro(objEcomProduto, id);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return num2;
    }

    public string strGetNexNumReferencia(string strIdEmpresa, string strIdSistema)
    {
        string str2;
        DataSet set = new DataSet();
        try
        {
            if (string.IsNullOrEmpty(strIdEmpresa.Trim()) || string.IsNullOrEmpty(strIdSistema))
            {
                return "";
            }
            set = AcessoBD.ObterDataSet(("select (case when max(NumReferencia) is null  then 1 else max(NumReferencia) + 1 end) as NumReferencia                  from EcomProduto where IdEmpresa = " + strIdEmpresa + " and IdSistema = " + strIdSistema.Trim()).Trim());
            if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
            {
                return set.Tables[0].Rows[0]["NumReferencia"].ToString().Trim();
            }
            str2 = "";
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            if (set != null)
            {
                set.Dispose();
            }
        }
        return str2;
    }

    public void UpdateQtdCliques(string strIdProduto)
    {
        try
        {
            if (!string.IsNullOrEmpty(strIdProduto))
            {
                AcessoBD.ExecutarComandoSql((" UPDATE EcomProduto " + " SET  QtdCliques =  (CASE WHEN QtdCliques IS NULL THEN 1 ELSE  QtdCliques + 1 END) ") + " FROM EcomProduto WHERE IdProduto = " + strIdProduto);
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public bool ValidaExclusao(string strIdNorma, out string strMensagem)
    {
        bool flag;
        strMensagem = "";
        try
        {
            flag = true;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        return flag;
    }

    // Properties
    [AtributoBancoDados(AtributoBD=true)]
    public double AlturaCm
    {
        get
        {
            return this._AlturaCm;
        }
        set
        {
            this._AlturaCm = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public double ComprimentoCm
    {
        get
        {
            return this._ComprimentoCm;
        }
        set
        {
            this._ComprimentoCm = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string DescricaoLonga
    {
        get
        {
            return this._DescricaoLonga;
        }
        set
        {
            this._DescricaoLonga = value;
        }
    }

    [AtributoBancoDados(AtributoBD=false)]
    public string DescUltimoUsuario
    {
        get
        {
            return this._DescUltimoUsuario;
        }
        set
        {
            this._DescUltimoUsuario = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string Especificacao
    {
        get
        {
            return this._Especificacao;
        }
        set
        {
            this._Especificacao = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string EspecificacaoTecnica
    {
        get
        {
            return this._EspecificacaoTecnica;
        }
        set
        {
            this._EspecificacaoTecnica = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string Fabricante
    {
        get
        {
            return this._Fabricante;
        }
        set
        {
            this._Fabricante = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string FlagDestaque
    {
        get
        {
            return this._FlagDestaque;
        }
        set
        {
            this._FlagDestaque = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string FlagDisponivel
    {
        get
        {
            return this._FlagDisponivel;
        }
        set
        {
            this._FlagDisponivel = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string FlagFreteGratis
    {
        get
        {
            return this._FlagFreteGratis;
        }
        set
        {
            this._FlagFreteGratis = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string FlagLancamento
    {
        get
        {
            return this._FlagLancamento;
        }
        set
        {
            this._FlagLancamento = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string Garantia
    {
        get
        {
            return this._Garantia;
        }
        set
        {
            this._Garantia = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string GarantiaDetalhe
    {
        get
        {
            return this._GarantiaDetalhe;
        }
        set
        {
            this._GarantiaDetalhe = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int IdCategoria
    {
        get
        {
            return this._IdCategoria;
        }
        set
        {
            this._IdCategoria = value;
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
    public int IdFornecedor
    {
        get
        {
            return this._IdFornecedor;
        }
        set
        {
            this._IdFornecedor = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int IdMarca
    {
        get
        {
            return this._IdMarca;
        }
        set
        {
            this._IdMarca = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int IdProduto
    {
        get
        {
            return this._IdProduto;
        }
        set
        {
            this._IdProduto = value;
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
    public int IdTipo
    {
        get
        {
            return this._IdTipo;
        }
        set
        {
            this._IdTipo = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int IdTipoPreco
    {
        get
        {
            return this._IdTipoPreco;
        }
        set
        {
            this._IdTipoPreco = value;
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
    public double LarguraCm
    {
        get
        {
            return this._LarguraCm;
        }
        set
        {
            this._LarguraCm = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string Marca
    {
        get
        {
            return this._Marca;
        }
        set
        {
            this._Marca = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string Modelo
    {
        get
        {
            return this._Modelo;
        }
        set
        {
            this._Modelo = value;
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
    public int NumReferencia
    {
        get
        {
            return this._NumReferencia;
        }
        set
        {
            this._NumReferencia = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public string Peso
    {
        get
        {
            return this._Peso;
        }
        set
        {
            this._Peso = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public double PesoGrama
    {
        get
        {
            return this._PesoGrama;
        }
        set
        {
            this._PesoGrama = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public double Preco
    {
        get
        {
            return this._Preco;
        }
        set
        {
            this._Preco = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public double PrecoAVista
    {
        get
        {
            return this._PrecoAVista;
        }
        set
        {
            this._PrecoAVista = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public double PrecoPor
    {
        get
        {
            return this._PrecoPor;
        }
        set
        {
            this._PrecoPor = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int QtdCliques
    {
        get
        {
            return this._QtdCliques;
        }
        set
        {
            this._QtdCliques = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int QtdNoEstoque
    {
        get
        {
            return this._QtdNoEstoque;
        }
        set
        {
            this._QtdNoEstoque = value;
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
    public string UrlApoio
    {
        get
        {
            return this._UrlApoio;
        }
        set
        {
            this._UrlApoio = value;
        }
    }
}

}
