using Loja.Dominio.Entidades;
using Loja.Dominio.Entidades.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestesMs
{
    [TestClass]
    public class UnitTest1
    {
    
 

        [TestMethod]
        public void AdicionarItemAoPedido()
        {
            Client cliente = new Client("Marcelo", "MarceloSilva23099@gmail.com");
            Pedido Pedido = new Pedido(cliente, 0, null);
            Pedido.AdicionarItemAoPedido(new Produto("coca", 4, true), 3);
            Assert.IsTrue(Pedido.Items.Count > 0);   
        }   
        
        [TestMethod]
        public void PagarPedido()
        {
            Client cliente = new Client("Marcelo", "MarceloSilva23099@gmail.com");
            Pedido Pedido = new Pedido(cliente, 0, null);
            Pedido.AdicionarItemAoPedido(new Produto("coca", 4, true), 3);
            var resultado = Pedido.Pagar(400);
            Assert.IsTrue(resultado && Pedido.Status == EPedidoStatus.AguardandoEntrega);
        }

        [TestMethod]
        public void StatusPedidoAguardandoPagamentoAoCriado()
        {
            Client cliente = new Client("Marcelo", "MarceloSilva23099@gmail.com");
            Pedido Pedido = new Pedido(cliente, 0, null);
            Assert.AreEqual(EPedidoStatus.AguardandoPagamento, Pedido.Status);
            
        }

        [TestMethod]
        public void CancelarPedido()
        {
            Client cliente = new Client("Marcelo", "MarceloSilva23099@gmail.com");
            Pedido Pedido = new Pedido(cliente, 0, null);
            Pedido.Cancelar();
            Assert.AreEqual(EPedidoStatus.Cancelado, Pedido.Status);

        }

        [TestMethod]
        public void PagandoPedidoComUmValorMenorDoQueTotalDoPedido()
        {
            Client cliente = new Client("Marcelo", "MarceloSilva23099@gmail.com");
            var dataExpiracao = DateTime.Now.AddDays(4);
            Pedido Pedido = new Pedido(cliente, 0, new Desconto(3,dataExpiracao));
            Pedido.AdicionarItemAoPedido(new Produto("coca", 4, true), 3);
            Pedido.Total();

            Assert.IsFalse(Pedido.Pagar(3));

        }


        [TestMethod]
        public void DataExpirada()
        {
            Client cliente = new Client("Marcelo", "MarceloSilva23099@gmail.com");
            var dataExpiracao = DateTime.Now.AddDays(-3);
            var desconto = new Desconto(3, dataExpiracao);
            Pedido Pedido = new Pedido(cliente, 0, desconto);
            Pedido.AdicionarItemAoPedido(new Produto("coca", 4, true), 3);
            Pedido.Total();

            Assert.IsFalse(desconto.DescontoValida());

        }
    }
}
