void RenderToDoMenu()
{
    
    Console.WriteLine("______________________________");
    Console.WriteLine("[===== To do list App =====]");
    Console.WriteLine("[S] -  See all To Do's");
    Console.WriteLine("[A] -  Add a To Do");
    Console.WriteLine("[R] -  Remove a To Do");
    Console.WriteLine("[E] -  Exit");
    Console.WriteLine("______________________________");
}

void AddToDo(List<string> list, out List<string> newList)
{
    
    Console.WriteLine($"**** Write the activity to insert ****");
       string toDo = Console.ReadLine();

    if (toDo == "")
    {
        Console.WriteLine($"The activity to add must not be empty.\n");
        newList = list;
        return;
    }

    if (list.Contains(toDo))
    {
        Console.WriteLine($"The activity: {toDo} has been yet added.");
    }

    list.Add(toDo);
    Console.WriteLine($"The activity: {toDo} was successfully added.\n");

    newList = list;
    System.Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
}

void ListAllToDos(List<string> list, bool delete)
{
    if (list.Count == 0)
    {
        Console.WriteLine("The To Do list is empty.");
        return;
    }

    Console.WriteLine(delete? "**** All To Do's ****":"**** Select an element to remove. ****");
    for (int i = 0; i < list.Count; i++)
    {

        Console.WriteLine($"{i + 1}. {list[i]}");
    }
    
    if (!delete){
    Console.WriteLine("Press any key to continue.\n");
    Console.ReadKey();
    }
}

void RemoveTodo(List<string> list, out List<string> newList)
{
    int listSize = list.Count;

    if(list.Count == 0)
    {
        Console.WriteLine("The To Do list is empty.");
        newList = list;
        return;
    }
    ListAllToDos(list, true);
    
    Console.WriteLine("\nType a number of the list to delete it.");

    var input = Console.ReadLine();
    bool parseMade = int.TryParse(input, out int number);

    if (number > listSize)
    {
        Console.WriteLine("The found index was not found in the list.");
        newList = list;
        return;
    }

    if (parseMade && number <= listSize)
    {
        list.RemoveAt(number - 1);
        Console.WriteLine($"The activity was successfully deleted.\n");
    }
    ;

    newList = list;
    System.Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
}

List<string> toDoList = new List<string>();

do
{

    RenderToDoMenu();

    Console.WriteLine("Insert an option: ");
    var input = Console.ReadLine();
    char selectedOption;

    bool parseMade = char.TryParse(input, out selectedOption);

    if (!parseMade)
    {
        Console.WriteLine("Error could not parse inserted Value. Press any key to continue.");
        Console.ReadKey();
    }

    selectedOption = char.ToUpper(selectedOption);

    switch (selectedOption)
    {
        case 'S': ListAllToDos(toDoList, false); break;
        case 'A': AddToDo(toDoList, out toDoList); break;
        case 'R': RemoveTodo(toDoList, out toDoList); break;
        case 'E': return 0;
        default: Console.WriteLine("Invalid input"); break;
    }
} while (true);