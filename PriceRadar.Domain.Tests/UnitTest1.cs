
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

    [Fact]
    public void NaoDeveCriarProdutoSemNome()
    {
        Assert.Throws<ArgumentException>(() => new Product("", "Samsung", "UN50"));
    }
}
