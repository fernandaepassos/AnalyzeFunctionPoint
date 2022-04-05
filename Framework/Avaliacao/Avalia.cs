using System.Data;
using System.Web;
using System;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System.Text;
using Framework.Sige;
using Framework.Util;

namespace Framework.Avaliacao
{
    public class Avalia : ClassGenericAvaliacao
    {
        // Fields
        private string _Alienadora;
        private string _Ano;
        private string _AnoModelo;
        private double _AvalEfetivo;
        private double _AvalSugerido;
        private string _ClassificacaoAvaria;
        private string _Combustivel;
        private string _ComunicacaoVenda;
        private string _Cor;
        private string _DataCadastro;
        private string _DescAcabamento;
        private string _DescFinalidade;
        private string _DescLatariaPintura;
        private string _DescMecanica;
        private string _Documento;
        private string _FlagAlienado;
        private string _FlagRepasse;
        private double _GastosAcabamento;
        private double _GastosLatariaPintura;
        private double _GastosMecanica;
        private int _IdAvalia;
        private int _IdEstadoVeiculo;
        private int _IdFilial;
        private int _IdMarca;
        private int _IdPessoaCliente;
        private int _IdPessoaVendedor;
        private int _IdStatusAvaliacao;
        private int _IdStatusMotivoNaoEntrou;
        private int _IdTipoFase;
        private int _IdUltimoUsuario;
        private int _IdUsuarioInclusor;
        private double _IndexadorMediaComercial;
        private string _IndexadorObservacao;
        private string _Km;
        private string _Km_Ano;
        private string _Modelo;
        private string _MultaInterEstadual;
        private string _NumeroChassi;
        private string _NumMotor;
        private string _Observacao;
        private string _ObservacaoPrecista;
        private string _OcorrenciaFurto;
        private string _PetenciaMotor;
        private string _Placa;
        private string _Potencia;
        private double _PrecoTotalOrcamento;
        private int _QtdPortas;
        private string _Renavam;
        private string _Restricao1;
        private string _Restricao2;
        private string _Restricao3;
        private string _Restricao4;
        private string _RestricaoJudicial;
        private string _SituacaoCadastral;
        private string _UltimaAtualizacao;
        private double _ValorMedio;

        // Methods
        public void DefineFaseDaAvaliacao(bool bolSalvouComSucesso, Avalia objAvalia, string strFaseClicada)
        {
            try
            {
                if (bolSalvouComSucesso)
                {
                    if ((objAvalia.IdTipoFase == 6) && (strFaseClicada.Trim().ToLower() == "vendedor".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 7 where IdAvalia = " + objAvalia.IdAvalia);
                        this.NotificaAndamentoAvaliacao(objAvalia, "avaliadores");
                    }
                    else if (((objAvalia.IdTipoFase == 8) || (objAvalia.IdTipoFase == 7)) && (strFaseClicada.Trim().ToLower() == "avaliador".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 9 where IdAvalia = " + objAvalia.IdAvalia);
                        this.NotificaAndamentoAvaliacao(objAvalia, "precistas");
                    }
                    else if (((objAvalia.IdTipoFase == 10) || (objAvalia.IdTipoFase == 9)) && (strFaseClicada.Trim().ToLower() == "precista".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 11 where IdAvalia = " + objAvalia.IdAvalia);
                        AcessoBD.ExecutarComandoSql("update Avalia set IdStatusAvaliacao = 6 where IdAvalia = " + objAvalia.IdAvalia);
                        this.NotificaAndamentoAvaliacao(objAvalia, "vendedor,gerenteloja,admgeral");
                    }
                }
                else
                {
                    if ((objAvalia.IdTipoFase == 7) && (strFaseClicada.Trim().ToLower() == "avaliador".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 8 where IdAvalia = " + objAvalia.IdAvalia);
                    }
                    if ((objAvalia.IdTipoFase == 9) && (strFaseClicada.Trim().ToLower() == "precista".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 10 where IdAvalia = " + objAvalia.IdAvalia);
                    }
                    else if ((objAvalia.IdTipoFase == 7) && (strFaseClicada.Trim().ToLower() == "avaliador".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 8 where IdAvalia = " + objAvalia.IdAvalia);
                    }
                    else if ((objAvalia.IdTipoFase == 9) && (strFaseClicada.Trim().ToLower() == "precista".ToLower()))
                    {
                        AcessoBD.ExecutarComandoSql("update Avalia set IdTipoFase = 10 where IdAvalia = " + objAvalia.IdAvalia);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void EnviarEmail(StringBuilder strMensagem, Avalia objAvalia, string strEmailDestino, string strEmailDoRemetente, string strTelefoneDaLoja, string strNomeLoja)
        {
            try
            {
                ClsEmail email = new ClsEmail ();
                email = new ClsEmail {
                    Assunto = "Veículo de placa: " + objAvalia.Placa.ToUpper().Trim() + " - " + ClsSigeTipo.GetNomeTipo(objAvalia.IdTipoFase.ToString().Trim()) + "  ",
                    EmailRemetente = "sistemaautodna@gmail.com",
                    EmailDestinatario = strEmailDestino,
                    EmailAutenticacaoSenha = "srv$#@prod",
                    EmailAutenticacao = "sistemaautodna@gmail.com",
                    EmailDoInternauta = strEmailDoRemetente,
                    Mensagem = strMensagem.ToString().Trim(),
                    Nome = "Loja:" + strNomeLoja + " - Andamento de avaliação",
                    NomeDoSistema = "AUTODNA",
                    UrlLogoSistema = "http://www.autodna.com.br/autodna/images/logo.png",
                    Telefone = strTelefoneDaLoja + " Telefone da Loja",
                    MensagemEmHtml = email.GetMsgHtml(ClsEmail.SistemaOrigem.SckAvaliacao)
                };
                string strMensagemRetorno = "";
                email.EnviarEmail(out strMensagemRetorno);
            }
            catch
            {
            }
        }

        public bool ExisteResultaDenatran(string strIdAvalia)
        {
            try
            {
                object obj2 = AcessoBD.ExecutarComandoSqlEscalar(" SELECT COUNT(*) AS VALOR FROM Avalia WHERE (SituacaoCadastral IS NOT NULL OR SituacaoCadastral <> '' OR                MultaInterEstadual IS NOT NULL OR MultaInterEstadual <> '' OR                 RestricaoJudicial  IS NOT NULL OR  RestricaoJudicial  <> '' OR                 ComunicacaoVenda IS NOT NULL OR  ComunicacaoVenda <> '' OR                OcorrenciaFurto IS NOT NULL OR  OcorrenciaFurto <> '' OR                Restricao4 IS NOT NULL OR  Restricao4 <> '' OR                Restricao3 IS NOT NULL OR  Restricao3 <> '' OR                Restricao2 IS NOT NULL OR  Restricao2 <> '' OR                Restricao1 IS NOT NULL OR Restricao1 <> '' )                AND IdAvalia = " + strIdAvalia + " ");
                return ((obj2 != null) && (Convert.ToInt32(obj2) > 0));
            }
            catch
            {
                return false;
            }
        }

        public DataSet ListaAvaliacao(int intIdFilial)
        {
            DataSet set;
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select IdAvalia , Avalia.IdFilial , Avalia.IdStatusAvaliacao                , Filial.RazaoSocial as Loja                , Pessoa.Nome as Vendedor                , IdPessoaVendedor                , Placa                , Modelo                , CONVERT(varchar, Avalia.UltimaAtualizacao, 103)+' '+ CONVERT(varchar,Avalia.UltimaAtualizacao,108) as UltimaAtualizacao                , Usuario.Login as DescUltimoUsuario                ,  CONVERT(varchar, Avalia.DataCadastro, 103) as DataCadastro                , Marca.DescMarca                , Renavam                , Documento                , PessoaCliente.Nome as Cliente                , Status.DescStatus                , IdTipoFase                from Avalia                 left join Filial on Filial.IdFilial = Avalia.IdFilial                left join Status on Status.IdStatus = Avalia.IdStatusAvaliacao                left join Pessoa on Pessoa.IdPessoa = Avalia.IdPessoaVendedor                left join Usuario on Usuario.IdUsuario = Avalia.IdUltimoUsuario                left join Marca on Marca.IdMarca = Avalia.idmarca                left join Pessoa as PessoaCliente on PessoaCliente.IdPessoa = Avalia.IdPessoaCliente                where 1 = 1 and Avalia.IdFilial = " + intIdFilial + "  ");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        private bool NotificaAndamentoAvaliacao(Avalia objAvalia, string strParaGrupoDe)
        {
            bool flag;
            Pessoa pessoa = new Pessoa();
            Filial filial = new Filial();
            try
            {
                if (objAvalia == null)
                {
                    return false;
                }
                if (strParaGrupoDe == null)
                {
                    return false;
                }
                if (strParaGrupoDe.Trim() == "")
                {
                    return false;
                }
                string strEmailDestino = "";
                StringBuilder strMensagem = new StringBuilder();
                strMensagem.Append(" Em " + Convert.ToDateTime(objAvalia.UltimaAtualizacao).ToString("dd/MM/yyyy") + " o veículo foi " + ClsSigeTipo.GetNomeTipo(objAvalia.IdTipoFase.ToString().Trim()) + " .");
                strMensagem.Append("");
                strMensagem.Append(" == Dados do veículo ==");
                strMensagem.Append("");
                strMensagem.Append(" Placa: " + objAvalia.Placa.ToUpper().Trim());
                strMensagem.Append("");
                strMensagem.Append(" Data de cadastro: " + Convert.ToDateTime(objAvalia.DataCadastro).ToString("dd/MM/yyyy"));
                strMensagem.Append("");
                strMensagem.Append(" Vendedor: " + pessoa.GetPessoaNomePorIdPessoa(objAvalia.IdPessoaVendedor));
                strMensagem.Append("");
                if (strParaGrupoDe.Trim().Split(new char[] { ',' }).Length <= 0)
                {
                    if (strParaGrupoDe.Trim().ToLower() == "precistas".ToLower())
                    {
                        strEmailDestino = pessoa.GetEmailFuncionarioPorFuncao("precistas", objAvalia.IdFilial.ToString().Trim());
                        if (strEmailDestino.Trim() != "")
                        {
                            this.EnviarEmail(strMensagem, objAvalia, strEmailDestino, "sistemaautodna@gmail.com", filial.GetDadoCampoFilial(objAvalia.IdFilial, "Telefone"), filial.GetDadoCampoFilial(objAvalia.IdFilial, "RazaoSocial"));
                        }
                    }
                    if (strParaGrupoDe.Trim().ToLower() == "avaliadores".ToLower())
                    {
                        strEmailDestino = pessoa.GetEmailFuncionarioPorFuncao("avaliadores", objAvalia.IdFilial.ToString().Trim());
                        if (strEmailDestino.Trim() != "")
                        {
                            this.EnviarEmail(strMensagem, objAvalia, strEmailDestino, "sistemaautodna@gmail.com", filial.GetDadoCampoFilial(objAvalia.IdFilial, "Telefone"), filial.GetDadoCampoFilial(objAvalia.IdFilial, "RazaoSocial"));
                        }
                    }
                    goto Label_054E;
                }
                if (strParaGrupoDe.Trim().Split(new char[] { ',' }).Length <= 0)
                {
                    goto Label_054E;
                }
                int index = 0;
                goto Label_0523;
            Label_0307:;
                if (strParaGrupoDe.Trim().Split(new char[] { ',' })[index].Trim().ToLower() == "vendedor".ToLower())
                {
                    strEmailDestino = pessoa.GetEmailFuncionarioPorFuncao("vendedor", objAvalia.IdFilial.ToString().Trim());
                    if (strEmailDestino.Trim() != "")
                    {
                        this.EnviarEmail(strMensagem, objAvalia, strEmailDestino, "sistemaautodna@gmail.com", filial.GetDadoCampoFilial(objAvalia.IdFilial, "Telefone"), filial.GetDadoCampoFilial(objAvalia.IdFilial, "RazaoSocial"));
                    }
                }
                else if (strParaGrupoDe.Trim().Split(new char[] { ',' })[index].Trim().ToLower() == "gerenteloja".ToLower())
                {
                    strEmailDestino = pessoa.GetEmailFuncionarioPorFuncao("gerenteloja", objAvalia.IdFilial.ToString().Trim());
                    if (strEmailDestino.Trim() != "")
                    {
                        this.EnviarEmail(strMensagem, objAvalia, strEmailDestino, "sistemaautodna@gmail.com", filial.GetDadoCampoFilial(objAvalia.IdFilial, "Telefone"), filial.GetDadoCampoFilial(objAvalia.IdFilial, "RazaoSocial"));
                    }
                }
                else if (strParaGrupoDe.Trim().Split(new char[] { ',' })[index].Trim().ToLower() == "admgeral".ToLower())
                {
                    strEmailDestino = pessoa.GetEmailFuncionarioPorFuncao("admgeral", objAvalia.IdFilial.ToString().Trim());
                    if (strEmailDestino.Trim() != "")
                    {
                        this.EnviarEmail(strMensagem, objAvalia, strEmailDestino, "sistemaautodna@gmail.com", filial.GetDadoCampoFilial(objAvalia.IdFilial, "Telefone"), filial.GetDadoCampoFilial(objAvalia.IdFilial, "RazaoSocial"));
                    }
                }
                index++;
            Label_0523:;
                if (index < strParaGrupoDe.Trim().Split(new char[] { ',' }).Length)
                {
                    goto Label_0307;
                }
            Label_054E:
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool PreExclusaoDefinitiva(int intIdAvalia)
        {
            bool flag;
            try
            {
                if (intIdAvalia <= 0)
                {
                    return false;
                }
                try
                {
                    AcessoBD.ExecutarComandoSql("delete AvaliaAcessorio where IdAvalia = " + intIdAvalia);
                    AcessoBD.ExecutarComandoSql("delete AvaliaClassificaItem where IdAvalia = " + intIdAvalia);
                    AcessoBD.ExecutarComandoSql("delete AvaliaIndexador where IdAvalia = " + intIdAvalia);
                    AcessoBD.ExecutarComandoSql("delete RealizadasConsultas where IdAvalia = " + intIdAvalia);
                }
                catch
                {
                    return false;
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string Alienadora
        {
            get
            {
                return this._Alienadora;
            }
            set
            {
                this._Alienadora = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Ano
        {
            get
            {
                return this._Ano;
            }
            set
            {
                this._Ano = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string AnoModelo
        {
            get
            {
                return this._AnoModelo;
            }
            set
            {
                this._AnoModelo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double AvalEfetivo
        {
            get
            {
                return this._AvalEfetivo;
            }
            set
            {
                this._AvalEfetivo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double AvalSugerido
        {
            get
            {
                return this._AvalSugerido;
            }
            set
            {
                this._AvalSugerido = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string ClassificacaoAvaria
        {
            get
            {
                return this._ClassificacaoAvaria;
            }
            set
            {
                this._ClassificacaoAvaria = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Combustivel
        {
            get
            {
                return this._Combustivel;
            }
            set
            {
                this._Combustivel = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string ComunicacaoVenda
        {
            get
            {
                return this._ComunicacaoVenda;
            }
            set
            {
                this._ComunicacaoVenda = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Cor
        {
            get
            {
                return this._Cor;
            }
            set
            {
                this._Cor = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DataCadastro
        {
            get
            {
                return this._DataCadastro;
            }
            set
            {
                this._DataCadastro = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescAcabamento
        {
            get
            {
                return this._DescAcabamento;
            }
            set
            {
                this._DescAcabamento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescFinalidade
        {
            get
            {
                return this._DescFinalidade;
            }
            set
            {
                this._DescFinalidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescLatariaPintura
        {
            get
            {
                return this._DescLatariaPintura;
            }
            set
            {
                this._DescLatariaPintura = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescMecanica
        {
            get
            {
                return this._DescMecanica;
            }
            set
            {
                this._DescMecanica = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Documento
        {
            get
            {
                return this._Documento;
            }
            set
            {
                this._Documento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagAlienado
        {
            get
            {
                return this._FlagAlienado;
            }
            set
            {
                this._FlagAlienado = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagRepasse
        {
            get
            {
                return this._FlagRepasse;
            }
            set
            {
                this._FlagRepasse = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double GastosAcabamento
        {
            get
            {
                return this._GastosAcabamento;
            }
            set
            {
                this._GastosAcabamento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double GastosLatariaPintura
        {
            get
            {
                return this._GastosLatariaPintura;
            }
            set
            {
                this._GastosLatariaPintura = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double GastosMecanica
        {
            get
            {
                return this._GastosMecanica;
            }
            set
            {
                this._GastosMecanica = value;
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
        public int IdEstadoVeiculo
        {
            get
            {
                return this._IdEstadoVeiculo;
            }
            set
            {
                this._IdEstadoVeiculo = value;
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
        public int IdPessoaCliente
        {
            get
            {
                return this._IdPessoaCliente;
            }
            set
            {
                this._IdPessoaCliente = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPessoaVendedor
        {
            get
            {
                return this._IdPessoaVendedor;
            }
            set
            {
                this._IdPessoaVendedor = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdStatusAvaliacao
        {
            get
            {
                return this._IdStatusAvaliacao;
            }
            set
            {
                this._IdStatusAvaliacao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdStatusMotivoNaoEntrou
        {
            get
            {
                return this._IdStatusMotivoNaoEntrou;
            }
            set
            {
                this._IdStatusMotivoNaoEntrou = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoFase
        {
            get
            {
                return this._IdTipoFase;
            }
            set
            {
                this._IdTipoFase = value;
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
        public double IndexadorMediaComercial
        {
            get
            {
                return this._IndexadorMediaComercial;
            }
            set
            {
                this._IndexadorMediaComercial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string IndexadorObservacao
        {
            get
            {
                return this._IndexadorObservacao;
            }
            set
            {
                this._IndexadorObservacao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Km
        {
            get
            {
                return this._Km;
            }
            set
            {
                this._Km = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Km_Ano
        {
            get
            {
                return this._Km_Ano;
            }
            set
            {
                this._Km_Ano = value;
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
        public string MultaInterEstadual
        {
            get
            {
                return this._MultaInterEstadual;
            }
            set
            {
                this._MultaInterEstadual = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string NumeroChassi
        {
            get
            {
                return this._NumeroChassi;
            }
            set
            {
                this._NumeroChassi = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string NumMotor
        {
            get
            {
                return this._NumMotor;
            }
            set
            {
                this._NumMotor = value;
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
        public string ObservacaoPrecista
        {
            get
            {
                return this._ObservacaoPrecista;
            }
            set
            {
                this._ObservacaoPrecista = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string OcorrenciaFurto
        {
            get
            {
                return this._OcorrenciaFurto;
            }
            set
            {
                this._OcorrenciaFurto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string PetenciaMotor
        {
            get
            {
                return this._PetenciaMotor;
            }
            set
            {
                this._PetenciaMotor = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Placa
        {
            get
            {
                return this._Placa;
            }
            set
            {
                this._Placa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Potencia
        {
            get
            {
                return this._Potencia;
            }
            set
            {
                this._Potencia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double PrecoTotalOrcamento
        {
            get
            {
                return this._PrecoTotalOrcamento;
            }
            set
            {
                this._PrecoTotalOrcamento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int QtdPortas
        {
            get
            {
                return this._QtdPortas;
            }
            set
            {
                this._QtdPortas = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Renavam
        {
            get
            {
                return this._Renavam;
            }
            set
            {
                this._Renavam = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Restricao1
        {
            get
            {
                return this._Restricao1;
            }
            set
            {
                this._Restricao1 = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Restricao2
        {
            get
            {
                return this._Restricao2;
            }
            set
            {
                this._Restricao2 = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Restricao3
        {
            get
            {
                return this._Restricao3;
            }
            set
            {
                this._Restricao3 = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Restricao4
        {
            get
            {
                return this._Restricao4;
            }
            set
            {
                this._Restricao4 = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string RestricaoJudicial
        {
            get
            {
                return this._RestricaoJudicial;
            }
            set
            {
                this._RestricaoJudicial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string SituacaoCadastral
        {
            get
            {
                return this._SituacaoCadastral;
            }
            set
            {
                this._SituacaoCadastral = value;
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
        public double ValorMedio
        {
            get
            {
                return this._ValorMedio;
            }
            set
            {
                this._ValorMedio = value;
            }
        }
    }
}
