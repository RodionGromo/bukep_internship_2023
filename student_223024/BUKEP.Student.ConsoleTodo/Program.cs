using BUKEP.Student.Todo;
using Task = BUKEP.Student.Todo.Task;

namespace ConsoleTodo
{
    internal class Program
    {
        static ITaskManager taskMan = new TaskManager();
        static readonly List<string> taskMenu_actions = new() { 
            "Просмотреть список задач", "Добавить задачу", "Выйти из программы"
        };

        /// <summary>
        /// Возвращает целое число из ввода пользователя, если ввод не число то пользователь переспрашивается
        /// </summary>
        /// <param name="message">Сообщение которое будет отображено на экране. Параметр опциональный</param>
        /// <param name="addNewline">Нужно ли добавлять переход строки (newline) после сообщения, сам по себе ничего не делает</param>
        static int GetUserInt(string? message=null, bool addNewline=true)
        {
            bool succesful = false;
            int userout = -1;
            do
            {
                // в эту функцию можно добавить вывод сообщения, параметр addNewline указывает, нужен ли переход строки, или нет
                if (message != null)
                {
                    if(addNewline)
                    {
                        Console.WriteLine(message);
                    } else
                    {
                        Console.Write(message);
                    }
                }
                string? userin = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userin))
                {
                    succesful = int.TryParse(userin, out userout);
                }
            } while (!succesful);
            return userout;
        }

        /// <summary>
        /// Возвращает строку из ввода пользователя, не может быть пустой, иначе пользователь переспрашивается
        /// </summary>
        /// <param name="message">Сообщение которое будет отображено на экране. Параметр опциональный</param>
        /// <param name="addNewline">Нужно ли добавлять переход строки (newline) после сообщения, сам по себе ничего не делает</param>
        /// <param name="canBeEmpty">Допускать пустую строку в вводе, если потребуется</param>
        static string GetUserString(string? message = null, bool addNewline = true, bool canBeEmpty=false)
        {
            while (true)
            {
                if (message != null)
                {
                    if (addNewline)
                    {
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.Write(message);
                    }
                }
                string? userin = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userin) || (canBeEmpty && userin is not null))
                {
                    return userin;
                }
            }
        }

        /// <summary>
        /// Добавляет в список tasks новый Task, сразу спрашивая название и описание
        /// </summary>
        static void AddTask()
        {
            taskMan.AddTask(
                GetUserString("Введите название задачи:\n> ", addNewline: false),
                GetUserString("Введите описание задачи, или нажмите Enter, чтобы пропустить:\n> ", addNewline: false, canBeEmpty: true)
            );
            // оставляем пустую строчку ради ясности вывода
            Console.WriteLine();
        }

        /// <summary>
        /// Показывает задачи и форматирует вывод, учитывая есть ли задачи в списке и есть ли описание в них
        /// </summary>
        static void ShowTasks()
        {
            List<Task> tasks = taskMan.GetTasks().ToList();
            if (tasks.Count() == 0)
            {
                Console.WriteLine("Нет добавленных дел\n");
                return;
            }
            Console.WriteLine("Список текущих задач:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{tasks.IndexOf(task)}. {task.Name}:");
                if (!string.IsNullOrWhiteSpace(task.Description))
                {
                    Console.WriteLine($">\t{task.Description}");
                } 
                else 
                {
                    Console.WriteLine(">\t * нет описания *");
                }
                
                // Оставляем пустое место, ради красоты вывода
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Функция завершающая работу приложения, требует чтоб пользователь
        /// ввел номер действия выхода из программы, который должен быть всегда последним в списке действий
        /// </summary>
        static void RequestQuit()
        {
            Console.WriteLine("Вы действительно хотите выйти из приложения?\nВведите номер этого действия для выхода:");
            int userout = GetUserInt("> ", addNewline: false);
            if (userout == taskMenu_actions.Count) 
            {
                Environment.Exit(0);
            } 
            else
            {
                Console.WriteLine("Неверно! Возвращаю в меню..\n");
            }
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в список задач! Введите номер действия и нажмите Enter:");
                for(int i = 0; i < taskMenu_actions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {taskMenu_actions[i]}");
                }
                switch (GetUserInt("> ", addNewline: false))
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