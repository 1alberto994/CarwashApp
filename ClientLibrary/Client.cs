 public class Client
{
    private Company company;

    public Client()


    {
        company = new Company(); // Inizializza l'oggetto Company
    }

    public void Run()
{
    int choice;

    do
    {
        Console.WriteLine("Company Menu");
        Console.WriteLine("1. View Implants");
        Console.WriteLine("2. Insert New Implant");
        Console.WriteLine("3. Search Most Broken Implant");
        Console.WriteLine("4. Search Most Used Auto Implant");
        Console.WriteLine("5. Search Implant by ID");
        Console.WriteLine("6. Search Implants in Maintenance");
        Console.WriteLine("7. Exit");

        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            try
            {
                switch (choice)
                {
                    case 1:
                        ViewImplants();
                        break;
                    case 2:
                        InsertNewImplant();
                        break;
                    case 3:
                        SearchMostBrokenImplant();
                        break;
                    case 4:
                        SearchMostUsedAutoImplant();
                        break;
                    case 5:
                        SearchImplantByID();
                        break;
                    case 6:
                        SearchImplantsInMaintenance();
                        break;
                    case 7:
                        Console.WriteLine("Exiting the menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }

    } while (choice != 7);
}

private void ViewImplants()
{
    try
    {
        // Richiama il metodo ViewImplant dalla classe Company
        ICollection<Implant> implants = company.ViewImplant();
        // Visualizza i risultati
        foreach (var implant in implants)
        {
            Console.WriteLine($"ID: {implant.ID}, Current State: {implant.CurrentState}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while viewing implants: {ex.Message}");
    }
}

private void InsertNewImplant()
{
    try
    {
        // Chiedi all'utente di inserire i dettagli per il nuovo impianto
        Console.Write("Enter ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter Cost for Single Wash: ");
        double cost = Convert.ToDouble(Console.ReadLine());

        // Crea e inserisci il nuovo impianto
        Implant newImplant = new Implant(id, cost);
        if (company.InsertNewImplant(newImplant))
        {
            Console.WriteLine("New implant added successfully.");
        }
        else
        {
            Console.WriteLine("Failed to add the implant. An implant with the same ID already exists.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while inserting a new implant: {ex.Message}");
    }
}

private void SearchMostBrokenImplant()
{
    try
    {
        Implant mostBroken = company.SearchMostBrokenImplant();
        Console.WriteLine($"Most Broken Implant - ID: {mostBroken.ID}, Times Broken: {mostBroken.HowManyTimeBroken}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while searching for the most broken implant: {ex.Message}");
    }
}

private void SearchMostUsedAutoImplant()
{
    try
    {
        AutoImplant mostUsedAutoImplant = company.SearchMostUsedAutoImplant();
        Console.WriteLine($"Most Used Auto Implant - ID: {mostUsedAutoImplant.ID}, Wash Count: {mostUsedAutoImplant.CountWash}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while searching for the most used auto implant: {ex.Message}");
    }
}

private void SearchImplantByID()
{
    try
    {
        Console.Write("Enter ID: ");
        string id = Console.ReadLine();

        Implant foundImplant = company.ViewImplantByID(id);
        if (foundImplant != null)
        {
            Console.WriteLine($"Found Implant - ID: {foundImplant.ID}, Current State: {foundImplant.CurrentState}");
        }
        else
        {
            Console.WriteLine($"No implant found with ID: {id}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while searching for an implant by ID: {ex.Message}");
    }
}

private void SearchImplantsInMaintenance()
{
    try
    {
        ICollection<Implant> maintenanceImplants = company.SearchStatusMaintenance();
        Console.WriteLine("Implants in Maintenance:");
        foreach (var implant in maintenanceImplants)
        {
            Console.WriteLine($"ID: {implant.ID}, Current State: {implant.CurrentState}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while searching for implants in maintenance: {ex.Message}");
    }
}
}