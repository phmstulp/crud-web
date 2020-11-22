using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Business.Produto;
using ApiProduct.Models;

namespace ApiProductTest
{
    class TestProduto
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(15.8)]
        [TestCase(null)]
        public void verifica_valor_nulo(double valor)
        {
            Assert.IsNotNull(valor);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Produto Teste 1")]
        public void verifica_descricao_nula_e_vazia(String descricao)
        {
            Assert.IsNotNull(descricao);
            Assert.IsNotEmpty(descricao);
        }

        [TestCase(null)]
        [TestCase(1)]
        public void verifica_produto_marca(int marca)
        {
            Assert.IsNotNull(marca);
        }

        [TestCase(1, 1, true)]
        [TestCase(15, 16, false)]
        public void verifica_imagem(int cd_produto, int cd_imagem, bool resultado)
        {
            //Verifica se existe a imagem com o codigo informado
            Business.Produto.Produto produto = new Business.Produto.Produto();
            bool found = produto.findData("Select 1 from imagemproduto where cd_produto = " + cd_produto + " and cd_imagem = " + cd_imagem);
            Assert.AreEqual(found, resultado);
        }

        [TestCase(1, true)]
        [TestCase(15, false)]
        public void verifica_marca(int cd_marca, bool resultado)
        {
            //Verifica se existe uma marca com o codigo informado
            Business.Produto.Produto produto = new Business.Produto.Produto();
            bool found = produto.findData("Select 1 from marca where cd_marca = " + cd_marca);
            Assert.AreEqual(found, resultado);
        }

        [TestCase(1, true)]
        [TestCase(15, false)]
        public void verifica_produto(int cd_produto, bool resultado)
        {
            //Verifica se existe um produto com o codigo informado
            Business.Produto.Produto produto = new Business.Produto.Produto();
            bool found = produto.findData("Select 1 from produto where cd_produto = " + cd_produto);
            Assert.AreEqual(found, resultado);
        }

        [TestCase(1, true)]
        [TestCase(15, false)]
        public void verifica_ligacao_marca_x_produto(int cd_marca, bool resultado)
        {
            //Verifica se a marca informada possui algum produto ligado a ela
            Business.Produto.Produto produto = new Business.Produto.Produto();
            bool referenced = produto.findData("Select cd_produto from produto where cd_marca = " + cd_marca);
            Assert.AreEqual(referenced, resultado);
        }

        [TestCase(1, true)]
        [TestCase(15, false)]
        public void verifica_ligacao_imagem_x_produto(int cd_produto, bool resultado)
        {
            //Verifica se o produto informado possui uma imagem ligada a ele
            Business.Produto.Produto produto = new Business.Produto.Produto();
            bool referenced = produto.findData("Select cd_imagem from imagemproduto where cd_produto = " + cd_produto);
            Assert.AreEqual(referenced, resultado);
        }

    }
}
