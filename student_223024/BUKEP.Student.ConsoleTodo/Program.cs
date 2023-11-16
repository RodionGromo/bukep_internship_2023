namespace ConsoleTodo
{
    internal class Program
    {
        // создаем структуру Task, в которой удобным образом будут храниться данные о задаче
        struct Task
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        static List<Task> tasks = new();
        static readonly List<string> taskMenu_actions = new() { 
            "Просмотреть список задач", "Добавить задачу"
        };

        static int GetUserInt(string? message=null, bool addnewline=true)
        {
            // функция для получения целого числа от пользователя, ошибки ввода вылавливаются с функцией int.TryParse
            // если есть ошибка, пользователь переспрашивается
            bool succesful = false;
            int userout = -1;
            do
            {
                // в эту функцию можно добавить вывод сообщения, параметр addnewline указывает, нужен ли переход строки, или нет
                if (message != null)
                {
                    if(addnewline)
                    {
                        Console.WriteLine(message);
                    } else
                    {
                        Console.Write(message);
                    }
                }
                string? userin = Console.ReadLine();
                if (!string.IsNullOrEmpty(userin))
                {
                    succesful = int.TryParse(userin, out userout);
                }
            } while (!succesful);
            return userout;
        }

        static string GetUserString(string? message = null, bool addnewline = true, bool canbeempty=false)
        {
            // еще одна функция для получения информации от пользователя,
            // на этот раз полагаюсь на string.IsNullOrEmpty, чтобы получить хороший результат
            while (true)
            {
                if (message != null)
                {
                    if (addnewline)
                    {
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.Write(message);
                    }
                }
                string? userin = Console.ReadLine();
                if (!string.IsNullOrEmpty(userin))
                {
                    return userin;
                }
                if(canbeempty && userin is not null)
                {
                    return userin;
                }
            }
        }

        static void AddTask()
        {
            tasks.Add(new() {
                Name = GetUserString("Введите название задачи:\n> ", addnewline: false),
                Description = GetUserString("Введите описание задачи, или нажмите Enter, чтобы пропустить:\n> ", addnewline: false, canbeempty: true),
            });
            // оставляем пустую строчку ради ясности вывода
            Console.WriteLine();
        }

        static void ShowTasks()
        {
            if(tasks.Count == 0)
            {
                Console.WriteLine("Нет добавленных дел\n");
            }
            Console.WriteLine("Список текущих задач:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Name}:");
                if (!string.IsNullOrEmpty(tasks[i].Description))
                {
                    Console.WriteLine($">\t{tasks[i].Description}");
                } else {
                    Console.WriteLine(">\t * нет описания *");
                }
                
                // Оставляем пустое место, ради красоты вывода
                Console.WriteLine();
            }
        }

        static void RequestQuit()
        {
            Console.WriteLine("Вы действительно хотите выйти из приложения?\nВведите номер этого действия для выхода:");
            int userout = GetUserInt("> ", addnewline: false);
            if (userout == taskMenu_actions.Count) {
                Environment.Exit(0);
            } else
            {
                Console.WriteLine("Неверно! Возвращаю в меню..\n");
            }
        }

        static void Main()
        {
            taskMenu_actions.Add("Выйти из программы");
            while (true)
            {
                Console.WriteLine("Добро пожаловать в список задач! Введите номер действия и нажмите Enter:");
                for(int i = 0; i < taskMenu_actions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {taskMenu_actions[i]}");
                }
                switch (GetUserInt("> ", addnewline: false))
                {
                    case 1:
                        ShowTasks(); break;
                    case 2:
                        AddTask(); break;
                    case 3:
                        RequestQuit(); break;
                    default: 
                        Console.WriteLine("Такого действия нет!"); break;
                }
            }
        }
    }
}