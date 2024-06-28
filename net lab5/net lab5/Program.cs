using System;
using System.Collections.Generic;

interface IMenuItem
{
    decimal GetPrice();
    void Display();
}

// Клас MenuItem (Leaf)
class MenuItem : IMenuItem
{
    private string name;
    private decimal price;

    public MenuItem(string name, decimal price)
    {
        this.name = name;
        this.price = price;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public void Display()
    {
        Console.WriteLine($"{name}: {price:C}");
    }

    public string GetName()
    {
        return name;
    }
}

// Клас Menu (Composite)
class Menu : IMenuItem
{
    private List<IMenuItem> menuItems = new List<IMenuItem>();
    private string name;

    public Menu(string name)
    {
        this.name = name;
    }

    public void Add(IMenuItem menuItem)
    {
        menuItems.Add(menuItem);
    }

    public void Remove(IMenuItem menuItem)
    {
        menuItems.Remove(menuItem);
    }

    public decimal GetPrice()
    {
        decimal total = 0;
        foreach (var item in menuItems)
        {
            total += item.GetPrice();
        }
        return total;
    }

    public void Display()
    {
        Console.WriteLine($"{name}:");
        foreach (var item in menuItems)
        {
            item.Display();
        }
    }

    public List<IMenuItem> GetMenuItems()
    {
        return menuItems;
    }
}

class Order
{
    private List<(IMenuItem item, int quantity)> orderItems = new List<(IMenuItem item, int quantity)>();

    public void AddItem(IMenuItem menuItem, int quantity)
    {
        orderItems.Add((menuItem, quantity));
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var orderItem in orderItems)
        {
            total += orderItem.item.GetPrice() * orderItem.quantity;
        }
        return total;
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Order Details:");
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine($"{orderItem.quantity} x");
            orderItem.item.Display();
        }
        Console.WriteLine($"Total Price: {GetTotalPrice():C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        MenuItem pizza = new MenuItem("Pizza", 8.99m);
        MenuItem burger = new MenuItem("Burger", 5.49m);
        MenuItem soda = new MenuItem("Soda", 1.99m);

        Menu mainMenu = new Menu("Main Menu");
        mainMenu.Add(pizza);
        mainMenu.Add(burger);
        mainMenu.Add(soda);

        mainMenu.Display();

        Order order = new Order();

        bool ordering = true;
        while (ordering)
        {
            Console.WriteLine("Enter the item name to add to your order (or type 'done' to finish): ");
            string itemName = Console.ReadLine();

            if (itemName.ToLower() == "done")
            {
                ordering = false;
                continue;
            }

            IMenuItem selectedItem = mainMenu.GetMenuItems().Find(item => item is MenuItem menuItem && menuItem.GetName().ToLower() == itemName.ToLower());

            if (selectedItem != null)
            {
                Console.WriteLine("Enter the quantity: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    order.AddItem(selectedItem, quantity);
                    Console.WriteLine($"{quantity} x {itemName} added to your order.");
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Item not found in menu. Please try again.");
            }
        }

        order.DisplayOrder();
    }
}
