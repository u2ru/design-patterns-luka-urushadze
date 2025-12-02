// See https://aka.ms/new-console-template for more information

using task3;

IBook book = new BookProxy(1, "Dive into patterns");
        
var admin = new User { Name = "admin", IsRegistered = true, HasAccess = true };
var user = new User { Name = "user", IsRegistered = true, HasAccess = false };
var guest = new User { Name = "guest", IsRegistered = false, HasAccess = false };

// test1
Console.WriteLine("\n1. Guest trying to read the book:");
Console.WriteLine(book.Read(guest));

// test2
Console.WriteLine("\n2. User with no access tries to read the book:");
Console.WriteLine(book.Read(user));

Console.WriteLine("\n3. admin with access #1");
Console.WriteLine(book.Read(admin));

Console.WriteLine("\n4. Admin with access #2");
Console.WriteLine(book.Read(admin));