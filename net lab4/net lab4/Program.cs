using System;
using System.Collections.Generic;

interface IDocument
{
    string GetInfo();
    int Number { get; set; }
    DateTime Date { get; set; }
    string Info { get; set; }
}
abstract class Document : IDocument
{
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public string Info { get; set; }

    public abstract string GetInfo();
}
class Letter : Document
{
    public string Correspondent { get; set; }

    public override string GetInfo()
    {
        return $"Letter: Number = {Number}, Date = {Date}, Info = {Info}, Correspondent = {Correspondent}";
    }
}
class Order : Document
{
    public string Department { get; set; }
    public DateTime Deadline { get; set; }
    public string Responsible { get; set; }

    public override string GetInfo()
    {
        return $"Order: Number = {Number}, Date = {Date}, Info = {Info}, Department = {Department}, Deadline = {Deadline}, Responsible = {Responsible}";
    }
}
class Directive : Document
{
    public string Department { get; set; }
    public DateTime Deadline { get; set; }

    public override string GetInfo()
    {
        return $"Directive: Number = {Number}, Date = {Date}, Info = {Info}, Department = {Department}, Deadline = {Deadline}";
    }
}
class ResourceRequest : Document
{
    public string Employee { get; set; }
    public List<string> Resources { get; set; }

    public override string GetInfo()
    {
        return $"ResourceRequest: Number = {Number}, Date = {Date}, Info = {Info}, Employee = {Employee}, Resources = {string.Join(", ", Resources)}";
    }
}
abstract class DocumentFactory
{
    public abstract IDocument CreateDocument(string type);
}
class ConcreteDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument(string type)
    {
        switch (type)
        {
            case "Letter":
                return new Letter();
            case "Order":
                return new Order();
            case "Directive":
                return new Directive();
            case "ResourceRequest":
                return new ResourceRequest();
            default:
                throw new ArgumentException("Invalid document type");
        }
    }
}

class DocumentManager
{
    private DocumentFactory factory;

    public DocumentManager(DocumentFactory factory)
    {
        this.factory = factory;
    }

    public void CreateAndShowDocument(string type)
    {
        IDocument document = factory.CreateDocument(type);
        document.Number = new Random().Next(1, 1000);
        document.Date = DateTime.Now;
        document.Info = "This is a test document.";

        Console.WriteLine(document.GetInfo());
    }

    public void CreateDocumentWithInput(string type)
    {
        IDocument document = factory.CreateDocument(type);

        Console.WriteLine("Enter document number:");
        document.Number = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter document date (yyyy-mm-dd):");
        document.Date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter document info:");
        document.Info = Console.ReadLine();

        switch (type)
        {
            case "Letter":
                var letter = document as Letter;
                Console.WriteLine("Enter correspondent:");
                letter.Correspondent = Console.ReadLine();
                break;
            case "Order":
                var order = document as Order;
                Console.WriteLine("Enter department:");
                order.Department = Console.ReadLine();
                Console.WriteLine("Enter deadline (yyyy-mm-dd):");
                order.Deadline = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter responsible person:");
                order.Responsible = Console.ReadLine();
                break;
            case "Directive":
                var directive = document as Directive;
                Console.WriteLine("Enter department:");
                directive.Department = Console.ReadLine();
                Console.WriteLine("Enter deadline (yyyy-mm-dd):");
                directive.Deadline = DateTime.Parse(Console.ReadLine());
                break;
            case "ResourceRequest":
                var resourceRequest = document as ResourceRequest;
                Console.WriteLine("Enter employee name:");
                resourceRequest.Employee = Console.ReadLine();
                resourceRequest.Resources = new List<string>();
                Console.WriteLine("Enter resources (comma separated):");
                var resources = Console.ReadLine().Split(',');
                foreach (var resource in resources)
                {
                    resourceRequest.Resources.Add(resource.Trim());
                }
                break;
            default:
                throw new ArgumentException("Invalid document type");
        }

        Console.WriteLine(document.GetInfo());
    }
}

class Program
{
    static void Main()
    {
        DocumentFactory factory = new ConcreteDocumentFactory();
        DocumentManager manager = new DocumentManager(factory);

        while (true)
        {
            Console.WriteLine("Enter document type (Letter, Order, Directive, ResourceRequest) or 'exit' to quit:");
            string type = Console.ReadLine();

            if (type.ToLower() == "exit")
            {
                break;
            }

            try
            {
                manager.CreateDocumentWithInput(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

