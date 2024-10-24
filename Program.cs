string thingsToDoFilePath = "./thingsToDo.txt";
string thingsDoneFilePath = "./thingsDone.txt";

var thingsToDo = File.ReadAllText(thingsToDoFilePath);
var thingsDone = File.ReadAllText(thingsDoneFilePath);

var toDoList = new List<string>();
var thingsDoneList = new List<string>();

string infoMsg = "Type a to-do to add,\nType 'done' to finish,\nType 'show' to show todo list,\n";

Console.WriteLine();
Console.WriteLine("Welcome to your personal To-Do-List program");
Console.WriteLine();
Console.WriteLine(infoMsg);

while (true)
{
    Console.Write("Enter a thing you want to add to the list: ");
    string newToDo = Console.ReadLine()!.Trim().ToLower();

    if (newToDo.Equals("done", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    if (newToDo.Equals("show", StringComparison.OrdinalIgnoreCase))
    {
        showToDos(toDoList);
        continue;
    }
    if(!newToDo.All(char.IsLetter))
    {
        Console.WriteLine("Please enter a thing to do.\n");;
        continue;
    }
    if (newToDo.Equals("delete", StringComparison.OrdinalIgnoreCase))
    {
        while (true)
        {
            Console.Write("Type the name of the todo you want to delete: ");
            string deletedTodo = Console.ReadLine()!.Trim()!.ToLower();
            if(!deletedTodo.All(char.IsLetter))
                {
                    Console.WriteLine("Please enter a thing to do.\n");;
                    continue;
                }
            for(int i = 0; i < toDoList.Count; i++)
            {
                if (toDoList[i] == deletedTodo)
                {
                    toDoList.Remove(toDoList[i]);
                }
            }   
            Console.WriteLine($"{deletedTodo} was removed from the list.");
            break;
        }
        continue;
    }
    toDoList.Add(newToDo);
}

static void showToDos(List<string> toDoList)
{
    foreach (string todo in toDoList)
    {
        Console.WriteLine(todo);
    }
}