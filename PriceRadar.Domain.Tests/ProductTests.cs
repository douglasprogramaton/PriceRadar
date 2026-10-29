
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
        var category = new Category("Eletrônicos");
        // Act - Executar a operação
        var product = new Product(name, brand, category, model);

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
        var category = new Category("Eletrônicos");
        var exception = Assert.Throws<ArgumentException>(() => new Product(name, "Samsung", category, "UN50"));
        Assert.Equal("name", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void NaoDeveCriarProdutoComMarcaInvalida(string brand)
    {
        var category = new Category("Eletrônicos");
        var exception = Assert.Throws<ArgumentException>(() => new Product("Smart TV Samsung", brand, category, "UN50"));
        Assert.Equal("brand", exception.ParamName);
    }

    [Fact]
    public void DeveAtualizarNomeDoProdutoComNomeValido()
    {
        var category = new Category("Eletrônicos");
        var product = new Product("Galaxy S24", "Samsung", category, "UN50");
        product.UpdateName("  Galaxy S25  ");
        Assert.Equal("Galaxy S25", product.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void NaoDeveAtualizarNomeDoProdutoComNomeInvalido(string name)
    {
        var category = new Category("Celulares");
        var product = new Product("Galaxy S24", "Samsung", category, "UN50");

        var exception = Assert.Throws<ArgumentException>(() => product.UpdateName(name));

        Assert.Equal("Galaxy S24", product.Name);
    }

    [Fact]
    public void DeveAtualizarMarcaDoProdutoComMarcaValida()
    {
        var category = new Category("Eletrônicos");
        var product = new Product("Galaxy S24", "Samsung", category , "UN50");
        product.UpdateBrand("  Apple  ");
        Assert.Equal("Apple", product.Brand);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void NaoDeveAtualizarMarcaDoProdutoComMarcaInvalida(string brand)
    {
        var category = new Category("Eletrônicos");
        var product = new Product("Galaxy S24", "Samsung", category, "UN50");
        var exception = Assert.Throws<ArgumentException>(() => product.UpdateBrand(brand));
        Assert.Equal("Samsung", product.Brand);
    }

    [Fact]
    public void DeveAtualizarModeloDoProdutoComModeloValido()
    {
        var category = new Category("Eletrônicos");
        var product = new Product("Smart TV", "Samsung", category, "UN50");

        product.UpdateModel("  UN55  ");

        Assert.Equal("UN55", product.Model);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void DeveRemoverModeloDoProdutoQuandoReceberValorVazioOuNulo(string? model)
    {
        var category = new Category("Eletrônicos");
        var product = new Product("Smart TV", "Samsung", category, "UN50");

        product.UpdateModel(model);

        Assert.Null(product.Model);
    }

    [Fact]
    public void DeveAssociarCategoriaAoProduto()
    {

        var category = new Category("Eletrônicos");
        var product = new Product("Smart TV", "Samsung", category, "UN50");
        Assert.Equal(category.Id, product.CategoryId);
        Assert.Same(category, product.Category);
    }

    [Fact]
    public void NaoDeveCriarProdutoComCategoriaNula()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            () => new Product("Smart TV", "Samsung", null!, "UN50"));

        Assert.Equal("category", exception.ParamName);
    }
}
