
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

    [Fact]
    public void DeveAtualizarNomeDoProdutoComNomeValido()
    {
        var product = new Product("Galaxy S24", "Samsung", "UN50");
        product.UpdateName("  Galaxy S25  ");
        Assert.Equal("Galaxy S25", product.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void NaoDeveAtualizarNomeDoProdutoComNomeInvalido(string name)
    {
        var product = new Product("Galaxy S24", "Samsung", "UN50");

        var exception = Assert.Throws<ArgumentException>(() => product.UpdateName(name));

        Assert.Equal("Galaxy S24", product.Name);
    }
}
