using System;

class Program
{
    static void Main()
    {
        Company myCompany = new();
        Client client = new Client(myCompany);
        FileManager myfileManager= new("..\\implants\\jsonImplants.json", "..\\implants\\SaveImplants.json", myCompany);
        myfileManager.pushAll();
        client.Run();
        myfileManager.Dispose();
    }
}
