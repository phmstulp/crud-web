using ApiProduct.Models;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace ApiProductTest
{
    class TestProduto
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void verifica_valor_nulo(Produto produto)
        {
            Assert.IsNotNull(produto.NrValor);
        }

        [Test]
        public void verifica_descricao_nula_e_vazia(Produto produto)
        {
            Assert.IsNotNull(produto.DsProduto);
            Assert.IsNotEmpty(produto.DsProduto);
        }

        [Test]
        public void verifica_produto_marca(Produto produto)
        {
            Assert.IsNotNull(produto.CdMarca);
        }


    }
}
