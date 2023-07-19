using APCExam.Contexts;
using APCExam.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APCExam;

public class ProductManagement
{
    private ProductDBContext productDbContext;
    public ProductManagement()
    {
        var productOptions = new DbContextOptionsBuilder<ProductDBContext>()
            .UseSqlServer("Data Source=localhost;Initial Catalog=APC;Persist Security Info=True;User ID=sa;Password=Pdhung92@;Encrypt=False")
            .Options;
        this.productDbContext = new ProductDBContext(productOptions);
    }
    public void AddProduct()
    {
        Console.Write("Enter Product name: ");
        string sName = Console.ReadLine();
        string name = null;
        try
        {
            name = CheckName(sName);
        }
        catch (InputException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.Write("Enter Price: ");
        string sPrice = Console.ReadLine();
        decimal price = 0;
        try
        {
            price = CheckPrice(sPrice);
        }
        catch (InputException e)
        {
            Console.WriteLine(e.Message);
        }

        if (name != null && price != 0)
        {
            var newProduct = new Product
            {
                Name = name,
                Price = price
            };
            try
            {
                productDbContext.Products.Add(newProduct);
                productDbContext.SaveChanges();
                Console.WriteLine("Product added!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Product can not add!");
        }
    }

    public void DisplayAllProduct()
    {
        var products = productDbContext.Products.ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}$");
        }
    }

    public void DeleteProductById()
    {
        int findId = 0;
        Console.Write("Enter product ID to remove: ");
        string sId = Console.ReadLine();

        try
        {
            findId = CheckId(sId);
        }
        catch (InputException e)
        {
            Console.WriteLine(e.Message);
        }

        if (findId != 0)
        {
            var deleteProduct = productDbContext.Products.FirstOrDefault(p => p.Id == findId);
            if (deleteProduct != null)
            {
                Console.WriteLine("Product found: {0}", deleteProduct.Name);

                productDbContext.Products.Remove(deleteProduct);
                productDbContext.SaveChanges();
                Console.WriteLine("Product Deleted!");
            }
            else
            {
                Console.WriteLine("Can not find the product has ID = {0}", findId);
            }
        }
        else
        {
            Console.WriteLine("Invalid ID!");
        }
    }

    public string CheckName(string sName)
    {
        string name = null;
        if (sName.Equals(""))
        {
            throw new InputException("Product name can not be empty!");
        }
        else
        {
            name = sName;
        }
        return name;
    }

    public decimal CheckPrice(string sPrice)
    {
        decimal price = 0;
        if (sPrice.Equals(""))
        {
            throw new InputException("Price can not be empty!");
        }

        if (!decimal.TryParse(sPrice, out price))
        {
            throw new InputException("Price must be a number!");
        }
        return price;
    }

    public int CheckId(string sId)
    {
        int id = 0;
        if (sId.Equals(""))
        {
            throw new InputException("ID can not be empty");
        }
        else
        {
            try
            {
            
            }
            catch (InputException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        return id;
    }
}


