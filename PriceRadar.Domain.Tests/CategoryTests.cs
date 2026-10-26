using PriceRadar.Domain.Entities;
using Xunit;

namespace PriceRadar.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void DeveCriarCategoriaComDadosValidos()
        {
            string name = "Eletrônicos";
            string? description = "Celulares, televisores e computadores";

            var category = new Category(name, description);

            Assert.NotEqual(Guid.Empty, category.Id);
            Assert.Equal(name, category.Name);
            Assert.Equal(description, category.Description);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void NaoDeveCriarCategoriaComNomeInvalido(string? name)
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new Category(name!));

            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void DeveRemoverEspacosDoNomeDaCategoria()
        {
            string name = "  Eletrônicos  ";
            var category = new Category(name);
            Assert.Equal("Eletrônicos", category.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void DeveCriarCategoriaSemDescricaoQuandoValorForVazioOuNulo(string? description)
        {
            var category = new Category("Eletrônicos", description);
            Assert.Null(category.Description);
        }

        [Fact]
        public void DeveRemoverEspacosDaDescricaoDaCategoria()
        {
            string description = "  Celulares, televisores e computadores  ";
            var category = new Category("Eletrônicos", description);
            Assert.Equal("Celulares, televisores e computadores", category.Description);
        }
    }
}