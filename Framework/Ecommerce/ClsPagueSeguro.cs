using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using System.Configuration;
using Uol.PagSeguro.Resources;
using System.Data;

namespace Framework.Ecommerce
{
    public class ClsPagueSeguro
    {
        // Methods
        public Uri GetUrlPagamento(string PagSeguroCredencialEmail, string PagSeguroCredencialToken, string strUrlDirecionarAposPagar, string strIdPessoa, out string strMensagem)
        {
            Uri uri2;
            strMensagem = "";
            AccountCredentials credentials = new AccountCredentials(PagSeguroCredencialEmail, PagSeguroCredencialToken);
            Address address = new Address();
            PaymentRequest request = new PaymentRequest();
            Shipping shipping = new Shipping();
            DataSet pessoaComprador = new DataSet();
            ClsEcomProduto produto = new ClsEcomProduto();
            try
            {
                string str = ClsEcomPedido.Instancia.GravarPedido(ClsEcomCarrinho.Instancia);
                request.Reference = str;
                foreach (int num in ClsEcomCarrinho.Instancia.CodigosDosItens)
                {
                    pessoaComprador = produto.BuscarProduto(num);
                    int quantity = ClsEcomCarrinho.Instancia.ObterQuantidadeDoItem(num);
                    Item item = new Item(num.ToString(), string.Format("{0} - {1}", pessoaComprador.Tables[0].Rows[0]["NumReferencia"].ToString().Trim(), pessoaComprador.Tables[0].Rows[0]["Nome"].ToString().Trim()), quantity, Convert.ToDecimal((pessoaComprador.Tables[0].Rows[0]["IdTipoPreco"].ToString().Trim() == "38") ? pessoaComprador.Tables[0].Rows[0]["PrecoAVista"].ToString().Trim() : pessoaComprador.Tables[0].Rows[0]["PrecoPor"].ToString().Trim()), 0L, 0);
                    request.Items.Add(item);
                }
                pessoaComprador = new ClsSigePessoa().GetPessoaComprador(strIdPessoa);
                address.Country = pessoaComprador.Tables[0].Rows[0]["Pais"].ToString().Trim();
                address.State = pessoaComprador.Tables[0].Rows[0]["Estado"].ToString().Trim();
                address.City = pessoaComprador.Tables[0].Rows[0]["Cidade"].ToString().Trim();
                address.District = pessoaComprador.Tables[0].Rows[0]["Bairro"].ToString().Trim();
                address.PostalCode = pessoaComprador.Tables[0].Rows[0]["Cep"].ToString().Trim();
                address.Street = pessoaComprador.Tables[0].Rows[0]["Endereco"].ToString().Trim();
                address.Number = pessoaComprador.Tables[0].Rows[0]["Numero"].ToString().Trim();
                address.Complement = pessoaComprador.Tables[0].Rows[0]["Complemento"].ToString().Trim();
                shipping.ShippingType = 3;
                shipping.Cost = new decimal?(Convert.ToDecimal(0));
                shipping.Address = address;
                request.Shipping = shipping;
                request.Sender = new Sender(pessoaComprador.Tables[0].Rows[0]["Nome"].ToString().Trim(), pessoaComprador.Tables[0].Rows[0]["Email"].ToString().Trim(), new Phone(pessoaComprador.Tables[0].Rows[0]["DDD"].ToString().Trim(), pessoaComprador.Tables[0].Rows[0]["Telefone"].ToString().Trim()));
                request.Currency = "BRL";
                if (pessoaComprador.Tables[0].Rows[0]["TipoDocumento"].ToString().Trim() == "CPF")
                {
                    SenderDocument document = new SenderDocument(Documents.GetDocumentByType(pessoaComprador.Tables[0].Rows[0]["TipoDocumento"].ToString().Trim()), pessoaComprador.Tables[0].Rows[0]["Documento"].ToString().Trim());
                    request.Sender.Documents.Add(document);
                }
                request.RedirectUri = new Uri(strUrlDirecionarAposPagar);
                uri2 = request.Register(credentials);
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "");
                foreach (ServiceError error in exception.Errors)
                {
                    if (strMensagem.Trim() == "")
                    {
                        strMensagem = error.ToString().Trim();
                    }
                    else
                    {
                        strMensagem = strMensagem + " / " + error.ToString().Trim();
                    }
                }
                Console.ReadKey();
                uri2 = null;
            }
            finally
            {
                request = null;
                address = null;
                credentials = null;
                produto = null;
                if (pessoaComprador != null)
                {
                    pessoaComprador.Dispose();
                }
            }
            return uri2;
        }
    }
}
