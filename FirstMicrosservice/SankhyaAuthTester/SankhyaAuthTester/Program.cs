// See https://aka.ms/new-console-template for more information
using SankhyaAuthTester.AuthRoute;

Console.WriteLine("Hello, World!");

AuthorizeRoute teste = new AuthorizeRoute();
Console.WriteLine(teste.GetToken());
Console.ReadLine();
