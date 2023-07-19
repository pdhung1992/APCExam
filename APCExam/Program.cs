
using APCExam;
using APCExam.Exceptions;

ProductManagement productManagement = new ProductManagement();
Console.WriteLine("=== Product Management ===");

do
{
    Console.WriteLine("1. Add product record");
    Console.WriteLine("2. Display all product");
    Console.WriteLine("3. Delete product by ID");
    Console.WriteLine("4.Exit");
    Console.Write("Please choose an option: ");
    string sChoice = Console.ReadLine();

    int choice = 0;

    try
    {
        choice = CheckChoice(sChoice);
    }
    catch (InputException e)
    {
        Console.WriteLine(e.Message);
    }

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

static int CheckChoice(string sChoice)
{
    int choice = 0;
    if (sChoice.Equals(""))
    {
        throw new InputException("Choice can not be empty");
    }
    try
    {
        if (!int.TryParse(sChoice, out choice))
        {
            throw new InputException("Choice must be a number");
        }
        if (choice < 1 | choice > 4)
        {
            throw new InputException("Choice must be from 1 to 4");
        }
    }
    catch (InputException e)
    {
        Console.WriteLine(e.Message);
    }
    return choice;
}
