namespace LearnMVC.Web.Models;

public class ProductRepository
{
    private static List<Product> _products = new List<Product>();

    public List<Product> Products()
    {
        return _products;
    }

    public void AddProduct(Product product)
    {

        if (_products is not null)
        {
            _products.Add(product);
        }
    }

    public void RemoveProduct(int productId)
    {
        var hasProduct = _products.FirstOrDefault(x => x.Id == productId);
        if (hasProduct is not null)
        {
            _products.Remove(hasProduct);
        }
    }

    public void UpdateProduct(Product product)
    {
        var hasProduct = _products.FirstOrDefault(x => x.Id == product.Id);
        if (hasProduct is not null)
        {
            hasProduct.Name = product.Name;
            hasProduct.Price = product.Price;

            var index = _products.FindIndex(x => x.Id == product.Id);

            _products[index] = hasProduct;
        }

    }

}