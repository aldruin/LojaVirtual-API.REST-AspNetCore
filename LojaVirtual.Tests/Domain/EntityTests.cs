using LojaVirtual.Domain.Entities;
using Xunit;

namespace LojaVirtual.Tests.Domain
{
    public class EntityTests
    {
        [Fact]
        public void User_ShouldCreateInstanceWithProperties()
        {
            // Arrange
            string username = "testuser";
            string email = "test@example.com";

            // Act
            var user = new User(username, email);

            // Assert
            Assert.Equal(username, user.UserName);
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public void Product_ShouldCreateInstanceWithProperties()
        {
            // Arrange
            string name = "Test Product";
            decimal price = 10.99m;
            int stock = 5;
            string description = "Product of test tam M stock 10";

            // Act
            var product = new Product(name, price, stock, description);

            // Assert
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(stock, product.Stock);
            Assert.Equal(description, product.Description);
        }

        [Fact]
        public void Cart_ShouldCreateInstanceWithProperties()
        {
            // Arrange
            Guid userId = Guid.NewGuid();

            // Act
            var cart = new Cart(userId);

            // Assert
            Assert.Equal(userId, cart.UserId);
            Assert.Empty(cart.Products); // Cart is initially empty
        }

        [Fact]
        public void CartProduct_ShouldCreateInstanceWithProperties()
        {
            // Arrange
            Guid cartId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();
            int quantity = 2;

            // Act
            var cartProduct = new CartProduct(cartId, productId, quantity);

            // Assert
            Assert.Equal(cartId, cartProduct.CartId);
            Assert.Equal(productId, cartProduct.ProductId);
            Assert.Equal(quantity, cartProduct.Quantity);
        }
    }
}
