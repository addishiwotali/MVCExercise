using System.Data;
using MVCExercise.Models;
using Dapper;

namespace MVCExercise.Data;

public class ProductRepository: IProductRepository
{ 
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products");
    }

    public Product GetProductById(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
    }

    public void CreateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new {name = product.Name, price = product.Price, id = product.ProductID });
    }
    
        public void UpdateProduct(Product product)
           {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new {name = product.Name, price = product.Price, id = product.ProductID });
           }
        public void InsertProduct(Product productToInsert)
           {
                _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                    new {name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
           }
        public IEnumerable<Category> GetCategories()
        
          {
                return _connection.Query<Category>("SELECT * FROM categories;");
          }
        public Product AssignCategory()
           {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
          }
}