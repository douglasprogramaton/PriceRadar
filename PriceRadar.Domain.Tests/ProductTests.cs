
using PriceRadar.Domain.Entities;

namespace PriceRadar.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void DeveCriarProdutoComDadosValidos()
    {
        // Arrange - Preparar os dados
        string name = "Smart TV Samsung";
        string brand = "Samsung";
        string model = "UN50";

        // Act - Executar a operação
        var product = new Product(name, brand, model);

        // Assert - Verificar os resultados
        Assert.NotEqual(Guid.Empty, product.Id);
        Assert.Equal(name, product.Name);
        Assert.Equal(brand, product.Brand);
        Assert.Equal(model, product.Model);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void NaoDeveCriarProdutoComNomeInvalido(string name)
    {
        var exception = Assert.Throws<ArgumentException>(() => new Product(name, "Samsung", "UN50"));
        Assert.Equal("name", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void NaoDeveCriarProdutoComMarcaInvalida(string brand)
    {
        var exception = Assert.Throws<ArgumentException>(() => new Product("Smart TV Samsung", brand, "UN50"));
        Assert.Equal("brand", exception.ParamName);
    }
}
