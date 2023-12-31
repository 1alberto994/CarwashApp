public class Client
{
    private Company company;

    public Client(Company cmp)
    {
        company = cmp; // Inizializza l'oggetto Company
    }

    public void Run()
    {
        int choice;

        do
        {
            Console.WriteLine("Company Menu\n");
            Console.WriteLine("1. View Implants");
            Console.WriteLine("2. Insert New Implant");
            Console.WriteLine("3. Search Most Broken Implant");
            Console.WriteLine("4. Search Most Used Auto Implant");
            Console.WriteLine("5. Search Implant by ID");
            Console.WriteLine("6. Search Implants in Maintenance");
            Console.WriteLine("7. Change Current state");
            Console.WriteLine("8. Exit");

            Console.Write("\nEnter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case 1:
                            ViewImplants();
                            Console.WriteLine();
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
                            ChangeImplantState();
                            break;
                        case 8:
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

        } while (choice != 8);
    }

    private void ViewImplants()
    {
        try
        {
            ICollection<Implant> implants = company.ViewImplant();

            foreach (var implant in implants)
            {
                if (implant is SelfImplant)
                {
                    var selfImplant = (SelfImplant)implant;
                    Console.WriteLine($"Type: SelfImplant");
                    Console.WriteLine(selfImplant.ToString() + "\n");
                }
                else if (implant is AutoImplant)
                {
                    var autoImplant = (AutoImplant)implant;
                    Console.WriteLine($"Type: AutoImplant\t");
                    Console.WriteLine(autoImplant.ToString() + "\n");
                }
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
            Console.WriteLine("Choose the type of implant:");
            Console.WriteLine("1. SelfImplant");
            Console.WriteLine("2. AutoImplant");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Enter Cost for Single Wash: ");
                    double cost = Convert.ToDouble(Console.ReadLine());


                    SelfImplant newSelfImplant = new SelfImplant(id, cost);

                    if (company.InsertNewImplant(newSelfImplant))
                    {
                        Console.WriteLine("\nNew SelfImplant added successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add the SelfImplant. An implant with the same ID already exists.");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Enter Cost for Single Wash: ");
                    double cost = Convert.ToDouble(Console.ReadLine());

                    AutoImplant newAutoImplant = new AutoImplant(id, cost);


                    if (company.InsertNewImplant(newAutoImplant))
                    {
                        Console.WriteLine("\nNew AutoImplant added successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nFailed to add the AutoImplant. An implant with the same ID already exists.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while inserting a new implant: {ex.Message}");
        }
    }
    private void SearchMostBrokenImplant()
    {
        try
        {
            Implant mostBroken = company.SearchMostBrokenImplant();
            Console.WriteLine($"Most Broken Implant: {mostBroken} Broken Time: {mostBroken.HowManyTimeBroken}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for the most broken implant: {ex.Message}\n");
        }
    }

    private void SearchMostUsedAutoImplant()
    {
        try
        {
            AutoImplant mostUsedAutoImplant = company.SearchMostUsedAutoImplant();
            Console.WriteLine($"Most Used Auto Implant: {mostUsedAutoImplant}, Wash Count: {mostUsedAutoImplant.CountWash}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for the most used auto implant: {ex.Message}\n");
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
                Console.WriteLine($"\nFound Implant: {foundImplant}\n");
            }
            else
            {
                Console.WriteLine($"\nNo implant found with ID: {id}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while searching for an implant by ID: {ex.Message}\n");
        }
    }

    private void SearchImplantsInMaintenance()
    {
        try
        {
            ICollection<Implant> maintenanceImplants = company.SearchStatusMaintenance();
            if (maintenanceImplants.Count == 0) { 
                Console.WriteLine("There are no implants in Maintenance State\n");
                return;
            }
            Console.WriteLine("Implants in Maintenance:");
            foreach (var implant in maintenanceImplants)
            {
                Console.WriteLine($"{implant}");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for implants in maintenance: {ex.Message}\n");
        }
    }
    private void ChangeImplantState()
    {
        ViewImplants();
        Console.Write("Enter the ID of the implant you want to change state for: ");
        string id = Console.ReadLine();

        try
        {
            Implant implant = company.ViewImplantByID(id);

            Console.WriteLine("Current State: " + implant.CurrentState + "\n");
            Console.WriteLine("Available States: O (Operational), M (Maintenance), B (Broken)");
            Console.Write("Enter the new state: ");
            string newState = Console.ReadLine();

            if (Enum.TryParse(newState, out Implant.States newStateEnum))
            {
                if (implant.ChangeState(newStateEnum, DateOnly.FromDateTime(DateTime.Now)))
                {
                    Console.WriteLine("\nState changed successfully.");
                    Console.WriteLine("Updated State: " + implant.CurrentState + "\n");
                }
                else
                {
                    Console.WriteLine("State change failed. The new state is the same as the current state.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid state. Please enter O, M, or B.\n");
            }
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Invalid Key Inserted\n");
        }
    }
}