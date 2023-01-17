using DataAccess.Managers;
using DataAccess.Models;
using System;
using System.Reflection;

var customerManager = new CustomerManager();
var productManager = new ProductManager();

//var andreas = new Customer("Andreas", "k");
//var knatte = new Customer("Knatte", "123");
//var fnatte = new Customer("Fnatte", "321");
//var tjatte = new Customer("Tjatte", "213");

//var apple = new Product("äpple", 5, 99, 1);
//var beverage = new Product("Pepsi Max", 15, 99, 2);
//var sausage = new Product("korv", 30, 99, 3);

Customer? loggedInCustomer = null;

//customerManager.Add(andreas);
//customerManager.Add(knatte);
//customerManager.Add(fnatte);
//customerManager.Add(tjatte);

//productManager.Add(apple);
//productManager.Add(beverage);
//productManager.Add(sausage);


var allCustomers = customerManager.GetAll();
var allProducts = productManager.GetAll();

Start();

void Start()
{

    Console.WriteLine("Hej och välkommen till TruckStore!\n" +
                      "[1]: Tryck 1 för att logga in?\n" +
                      "[2]: Tryck 2 för att skapa en ny kund.\n" +
                      "[3]: Lägga till varor i sortimentet.");

    var input = Console.ReadKey();


    if(input.KeyChar == '1')
    {
        LogIn();
    }
    else if (input.KeyChar == '2')
    {
       
        customerManager.Add(AddCustomer());
        LogIn();
    }
    else if(input.KeyChar == '3')

    {
        productManager.Add(AddProduct());
        Start();
    }
    else
    {
        Environment.Exit(0);
    }

}
Customer AddCustomer()

{
    Console.Clear();
    Console.Write("Skapa ditt nya konto här\n" +
                  "Ange ditt namn:"); string tempName = Console.ReadLine();
    Console.Write("Ange ett lösenord:"); string tempPass = Console.ReadLine();

    var customer = new Customer(tempName, tempPass);

    return customer;
}

Product AddProduct()
{
    Console.Clear();
    Console.Write("Vad vill du lägga till? "); string tempName = Console.ReadLine();
    Console.Write("Hur mycket ska en kosta? "); int tempPrice = Int32.Parse(Console.ReadLine());
    Console.Write("Och hur många vill du lägga till? "); int tempAmount = Int32.Parse(Console.ReadLine());

    var product = new Product(tempName, tempPrice, tempAmount);

    return product;
}

void LogIn()
{
    Console.Clear();
    Console.Write("Ange ditt namn:");
    var inputUsername = Console.ReadLine();
    Console.Write("Ange ditt lösenord:");
    var inputPassword = Console.ReadLine();

    foreach (var customer in customerManager.GetAll())
    {
        if (inputUsername == customer.Name)
        {
            if (customer.VerifyPassword(inputPassword))
            {
                Console.Clear();
                Console.WriteLine("Välkommen!");
                loggedInCustomer = customer;
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Du skrev fel lösenord {inputUsername}!\n" +
                                  $"Var vänligen och försök igen.");
                Console.ReadKey();
                LogIn();
            }

        }
    }

    foreach (var customer in customerManager.GetAll())

        if (inputPassword != customer.Name)
        {
            Console.WriteLine($"{inputUsername} existerar inte! Vill du skapa en ny?\n" +
                              $"[1]: Tryck 1 för ja.\n" +
                              $"[2]: Tryck 2 för nej.");
            var input = Console.ReadKey();
            if (input.KeyChar == '1')
            {
                customerManager.Add(AddCustomer());
                LogIn();
            }
            else if (input.KeyChar == '2')
            {
                Console.WriteLine("Det var tråkigt....");
                Console.ReadKey();
                Start();
            }
        }
}




void MainMenu()
{
    while (true)
    {

        Console.Clear();
        Console.WriteLine("Välkommen till min butik!");
        Console.WriteLine("\n Var god och välj i menyn.\n" +
                          "[A] Vad finns det för varor?\n" +
                          "[S] Lägg till varor.\n" +
                          "[D] Kolla i din kundvagn.\n" +
                          "[F] Totala kostnad för dina köp.\n" +
                          "[G] Betala dina varor.\n" +
                          "[T] Vilka kunder finns i butiken?\n" +
                          "[Q] Logga ut\n" +
                          "                      \n" +
                          "       _______________\n" +
                          "    _ / _ |[][][][][] | - -\n" +
                          "   (      FoodStore   | - -\n" +
                          "   = --OO------ - OO-- = dwb\n ");

        ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
        switch (inputFromUser.Key)
        {

            case ConsoleKey.A:
                {
                    ShowProducts();
                    break;
                }
            case ConsoleKey.S:
                {
                    //AddCart();
                    break;
                }
            case ConsoleKey.D:
                {
                    //CheckCart(loggedInCustomer.Cart);
                    break;
                }
            case ConsoleKey.F:
                {
                    //CalcCart(loggedInCustomer.Cart);
                    break;
                }
            case ConsoleKey.G:
                {
                    //CashOut();
                    break;
                }
            case ConsoleKey.T:
                {
                    //ShowList(kunder);
                    break;
                }

            case ConsoleKey.Q:
                {
                    LogOut();
                    return;
                }

        }

    }
}

void ShowProducts()
{
    Console.Clear();
    Console.WriteLine("********  I vårt laget ********");
    foreach (var item in productManager.GetAll())
    {
        Console.WriteLine($"{item.Name} antal {item.Amount} :Pris {item.Price} styck");
    }
    Console.WriteLine("Här är våra varor.");
    Console.ReadKey();
}

//void AddCart()
//{
//    Console.Clear();

//    var checkAmount = 0;
//    var amount = 0;

//    Console.Write($"Ange det numret som repesenterar produkten\n" +
//                  $"\n" +
//                  $"[1]: Äpplen\n" +
//                  $"[2]: Pepsi Max\n" +
//                  $"[3]: Korv\n" +
//                  $"\n" +
//                  $"Vad vill du köpa {loggedInCustomer.Name}?:");

//    var input = Console.ReadLine();

//    if (input == "1")
//    {
//        checkAmount++;
//        Console.Clear();
//        Console.Write($"Ett äpple kostar {apple.Price} kr.\n" +
//                          $"Hur många äpplen vill du lägga till?:");
//        amount = int.Parse(Console.ReadLine());
//        for (int i = 0; i < amount; i++)
//        {
//            loggedInCustomer.Cart.Add(apple);
//            apple.Amount++;

//        }

//        if (apple.Amount == 1)
//        {
//            Console.WriteLine($"Det finns {apple.Amount} {apple.Name} i din kundvagn.");
//            amount = 0;
//            Console.ReadKey();
//        }
//        else if (apple.Amount > 1)
//        {
//            Console.WriteLine($"Det finns {apple.Amount} äpplen i din kundvagn.");
//            amount = 0;
//            Console.ReadKey();
//        }

//    }
//    else if (input == "2")
//    {
//        checkAmount++;
//        Console.Clear();
//        Console.Write($"En Pepsi max kostar {beverage.Price} kr.\n" +
//                          $"Hur många Pepsi Max vill du lägga till?:");

//        amount = int.Parse(Console.ReadLine());
//        for (int i = 0; i < amount; i++)
//        {
//            loggedInCustomer.Cart.Add(beverage);
//            beverage.Amount++;
//        }

//        if (beverage.Amount == 1)
//        {
//            Console.WriteLine($"Lägger till {beverage.Amount} burk {beverage.Name} i din kundvagn.");
//            amount = 0;
//            Console.ReadKey();
//        }
//        else if (beverage.Amount > 1)
//        {
//            Console.WriteLine($"Lägger till {beverage.Amount} burkar {beverage.Name} i din kundvagn.");
//            amount = 0;
//            Console.ReadKey();
//        }
//    }
//    else if (input == "3")
//    {
//        checkAmount++;
//        Console.Clear();
//        Console.Write($"En korv kostar {sausage.Price} kr.\n" +
//                          $"Hur många korvar vill du lägga till?:");
//        amount = int.Parse(Console.ReadLine());
//        for (int i = 0; i < amount; i++)
//        {
//            loggedInCustomer.Cart.Add(sausage);
//            sausage.Amount++;

//        }

//        if (sausage.Amount == 1)
//        {
//            Console.WriteLine($"Lägger till {sausage.Amount} {sausage.Name} i din kundvagn.");
//            amount = 0;
//            Console.ReadKey();
//        }
//        else if (sausage.Amount > 1)
//        {
//            Console.WriteLine($"Lägger till {sausage.Amount} korvar i din kundvagn.");
//            amount = 0;
//            Console.ReadKey();
//        }
//    }


//    if (checkAmount == 0)
//    {
//        Console.WriteLine($"{loggedInCustomer.Name}, du la ingenting i din kundvang.\n" +
//                          $"Återgår till menyn.");
//        Console.ReadKey();
//        MainMenu();
//    }
//    else
//    {
//        checkAmount = 0;
//        Console.Clear();
//        Console.WriteLine($"Har lagt till varor i din kundvagn {loggedInCustomer.Name}\n" +
//                          $"Vill du handla något mer?\n" +
//                          $"[1] Tryck 1 för Ja\n" +
//                          $"[2] Tryck 2 för nej");
//        var input2 = Console.ReadLine();
//        if (input2 == "1")
//        {
//            AddCart();
//        }
//        else if (input2 == "2")
//        {
//            MainMenu();
//        }
//    }
//}

//void CheckCart(List<Products> cart)
//{

//    apple.Amount = 0;
//    beverage.Amount = 0;
//    sausage.Amount = 0;

//    var totalProducts = 0;


//    foreach (var products in cart)
//    {
//        products.Amount++;
//        totalProducts++;
//    }


//    Console.WriteLine($"{loggedInCustomer.Name}s Kundvagn\n");

//    Console.WriteLine($"{apple.Name}: {apple.Amount} st.\n" +
//                      $"{beverage.Name}: {beverage.Amount} st.\n" +
//                      $"{sausage.Name}: {sausage.Amount} st.\n");
//    Console.ReadKey();

//    if (totalProducts == 0)
//    {
//        Console.WriteLine("Din kundvagn är tom.");
//        Console.ReadKey();
//    }

//}

//void CalcCart(List<Products> cart)
//{
//    int sum = 0;

//    foreach (var products in cart)
//    {
//        sum += products.Price;
//    }
//    Console.WriteLine($"Din totala kostnad för alla produkter är: {sum}\n" +
//                        $"{apple.Name}: {apple.Amount} st.\n" +
//                        $"{sausage.Name}: {sausage.Amount} st.\n" +
//                        $"{beverage.Name}: {beverage.Amount} st.\n");
//    Console.ReadKey();
//}

//void CashOut()
//{
//    Console.WriteLine(loggedInCustomer);
//    Console.ReadKey();

//    Console.WriteLine($"Vill du köpa dina varor?\n" +
//                      "[1]: Tryck 1 för ja\n" +
//                      "[2]: Tryck 2 för nej");
//    var input = Console.ReadLine();

//    if (input == "1")
//    {
//        Console.Clear();
//        Console.Write($"Scannar dina varor...");
//        Thread.Sleep(1000);
//        Console.Clear();
//        Console.WriteLine($"Ditt kör har gått igenom! Tack för att du handlade här på FoodStore\n" +
//                          $"Välkommen åter {loggedInCustomer.Name}\n" +
//                          $"Önskar dig en fin dag.");

//        loggedInCustomer.Cart.Clear();
//        loggedInCustomer = null;
//        Console.ReadKey();
//        Start();
//    }
//    else if (input == "2")
//    {
//        Console.WriteLine($"Återgår till menyn");
//        Thread.Sleep(1000);
//        MainMenu();
//    }
//}

void LogOut()
{
    Console.Clear();
    Console.WriteLine($"{loggedInCustomer.Name} loggas ut\n" +
        $"Välkommen åter!");
    Console.ReadKey();
    Start();
}

//void ShowList(List<Customer> kunder)
//{

//    foreach (var a in kunder)
//    {
//        Console.WriteLine($"Name: {a.Name}");
//    }
//    Console.ReadKey();
//}

