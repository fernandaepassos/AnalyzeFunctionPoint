using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
public class Acessorio : ClassGenericAvaliacao
{
    // Fields
    private string _DescAcessorio;
    private int _IdAcessorio;
    private int _IdFilial;
    private int _IdTipoCategoria;
    private int _IdUltimoUsuario;
    private string _UltimaAtualizacao;

    // Methods
    public DataSet ListaAcessorio(int intIdFilial, int intIdTipoCategoria = 0)
    {
        DataSet set2;
        DataSet set = new DataSet();
        try
        {
            if (intIdFilial <= 0)
            {
                return null;
            }
            string str = " SELECT  IdAcessorio                , LTRIM(RTRIM(DescAcessorio)) DescAcessorio                , LTRIM(RTRIM(Tipo.DescTipo)) DescTipo                , ACESSORIO.IdFilial                , Acessorio.IdTipoCategoria                , CONVERT(VARCHAR,Acessorio.UltimaAtualizacao,103) +' '+ CONVERT(VARCHAR, Acessorio.UltimaAtualizacao, 108) AS UltimaAtualizacao                , Usuario.Login                , Filial.RazaoSocial as Filial                FROM  Acessorio                LEFT JOIN Usuario ON Usuario.IdUsuario = Acessorio.IdUltimoUsuario                LEFT JOIN Tipo ON Tipo.IdTipo = Acessorio.IdTipoCategoria                LEFT JOIN Filial ON Filial.IdFilial = Acessorio.IdFilial                WHERE Acessorio.IdFilial = " + intIdFilial + " ";
            if (intIdTipoCategoria > 0)
            {
                object obj2 = str;
                str = string.Concat(new object[] { obj2, " AND IdTipoCategoria = ", intIdTipoCategoria, " " });
            }
            set = AcessoBD.ObterDataSet(str + " ORDER BY DescTipo ASC, DescAcessorio ASC ");
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

    // Properties
    [AtributoBancoDados(AtributoBD=true)]
    public string DescAcessorio
    {
        get
        {
            return this._DescAcessorio;
        }
        set
        {
            this._DescAcessorio = value;
        }
    }

    [AtributoBancoDados(AtributoBD=true)]
    public int IdAcessorio
    {
        get
        {
            return this._IdAcessorio;
        }
        set
        {
            this._IdAcessorio = value;
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
    public int IdTipoCategoria
    {
        get
        {
            return this._IdTipoCategoria;
        }
        set
        {
            this._IdTipoCategoria = value;
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
