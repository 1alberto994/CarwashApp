using System;

class Program
{
    static void Main()
    {
        Company myCompany = new();
        Client client = new Client(myCompany);
        FileManager myfileManager= new("..\\implants\\jsonImplants.json", "..\\implants\\SaveImplants.json", myCompany);
        client.Run();
        myfileManager.Dispose();
    }
}
