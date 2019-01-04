using System.Text;
using System.Net;
using System.Net.Mail;
using System;

namespace LojaEsportes.Dominio.Entidades
{
    public class EmailConfiguracao
    {
        public string EmailDestino = "";
        public string EmailOrigem = "macoratti@yahoo.com";
        public bool UsarSsl = true;
        public string Usuario = "macoratti";
        public string Senha = "numsey";
        public string Servidor = "ftp.seuservidor.smtp";
        public int ServidorPorta = 287;
        public bool EscreverComoArquivo = true;
        public string Arquivo = @"d:\DZHosts\LocalUser\macoratti\";
    }

    public class EnviarEmailPedido : IProcessarPedido
    {
        private EmailConfiguracao emailConfiguracao;

        public EnviarEmailPedido()
        {
            emailConfiguracao = new EmailConfiguracao();
        }

        public void ProcessarPedido(Carrinho carrinho, Despacho despacho)
        {
             using (var smtpClient = new SmtpClient())
             {
                smtpClient.EnableSsl = emailConfiguracao.UsarSsl;
                smtpClient.Host = emailConfiguracao.Servidor;
                smtpClient.Port = emailConfiguracao.ServidorPorta;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(emailConfiguracao.Usuario, emailConfiguracao.Senha);
                emailConfiguracao.EmailDestino = despacho.Email;

                if (emailConfiguracao.EscreverComoArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailConfiguracao.Arquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Um novo pedido foi enviado")
                    .AppendLine("---")
                    .AppendLine("Itens : ");

                foreach (var item in carrinho.Items)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} x {1} (sub-total: {2:c}", item.Quantidade, item.Produto.Nome,subtotal);
                }

                body.AppendFormat("Valor Total do Pedido : {0:c}", carrinho.CalcularValorTotal())
                    .AppendLine("---")
                    .AppendLine("Enviar Para:")
                    .AppendLine(despacho.Nome)
                    .AppendLine(despacho.Endereco)
                    .AppendLine(despacho.Complemento ?? "")
                    .AppendLine(despacho.Cep)
                    .AppendLine(despacho.Cidade ?? "")
                    .AppendLine(despacho.Estado)
                    .AppendLine(despacho.Email)
                    .AppendLine("---")
                    .AppendFormat("Pacote Presente : {0}",despacho.PacotePresente ? "Sim" : "Nao");

                    MailMessage mailMessage = new MailMessage( 
                                                 emailConfiguracao.EmailOrigem,   //De
                                                 emailConfiguracao.EmailDestino,  //Para
                                                 "Novo Pedido Enviado!",          //Assunto
                                                 body.ToString());                //Texto

                    if (emailConfiguracao.EscreverComoArquivo)
                    {
                        mailMessage.BodyEncoding = Encoding.ASCII;
                    }
                    else
                    {
                        try
                        {
                            smtpClient.Send(mailMessage);
                        }
                        catch (Exception ex)
                        {
                            throw ex.InnerException;
                        }
                    }
           }//fim using
        }
    }
}
