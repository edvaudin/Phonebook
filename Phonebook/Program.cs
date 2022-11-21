using Phonebook.DataAccess;
using Phonebook.Models;

internal class Program
{
    static void Main(string[] args)
    {
        using var db = new ContactContext();
        Console.WriteLine($"Path: {db.Database}");

        Console.WriteLine("Inserting a new contact");
        db.Add(new Contact { Name = "Joe Bloggs", PhoneNumber = "01632960107" });
        db.SaveChanges();

        Console.WriteLine("Querying for a contact");
        var contact = db.Contacts.OrderBy(c => c.Id).FirstOrDefault();
        Console.WriteLine("Here is what we found: ");
        Console.WriteLine($"{contact.Name} - {contact.PhoneNumber}");

        Console.WriteLine("Updating the contact");
        contact.Name = "John Doe";
        db.SaveChanges();

        Console.WriteLine("Querying again for a contact");
        contact = db.Contacts.OrderBy(c => c.Id).FirstOrDefault();
        Console.WriteLine("Here is what we found: ");
        Console.WriteLine($"{contact.Name} - {contact.PhoneNumber}");

        Console.WriteLine("Deleting this contact");
        db.Remove(contact);
        db.SaveChanges();
    }
}