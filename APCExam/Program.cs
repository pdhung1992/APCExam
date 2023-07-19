
using APCExam;

ProductManagement productManagement = new ProductManagement();
Console.WriteLine("=== Product Management ===");

do
{
    Console.WriteLine("1. Add product record");
    Console.WriteLine("2. Display all product");
    Console.WriteLine("3. Delete product by ID");
    Console.WriteLine("4.Exit");
    Console.Write("Please choose an option: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            productManagement.AddProduct();
            break;
        case 2:
            productManagement.DisplayAllProduct();
            break;
        case 3:
            productManagement.DeleteProductById();
            break;
        case 4:
            Console.WriteLine("Program ended!");
            return;
    }
} while (true);