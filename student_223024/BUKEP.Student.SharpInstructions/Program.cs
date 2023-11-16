namespace SharpInstructions
{
    internal class Program
    {
        static readonly Dictionary<int, string> instructions = new()
        {
            {1, "if else"}, {2, "while"}, {3, "do while"}, {4, "for"}, {5, "foreach"}, {6, "switch"}
        };
        static readonly string ReturnToListText = "Для повтора нажмите Enter, для возврата к списку нажмите Esc:\n";
        static readonly List<string> actions = new() {
            "-", "+", "/", "*", "%"
        };


        static int? GetUserInt(string message="", bool newline=true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (newline)
                {
                    Console.WriteLine(message);
                } else { 
                    Console.Write(message); 
                }
            }
            bool successfulParse = int.TryParse(Console.ReadLine(), out int userout);
            return successfulParse ? userout : null;
        }

        static int GetUserIntRetrying(string message="", bool newline=true, bool onlyPositives=false, bool includeZero=true)
        {
            bool isSuccesful = false;
            int? userout;
            do
            {
                userout = GetUserInt(message, newline);
                if(userout is not null)
                {
                    isSuccesful |= onlyPositives && includeZero && userout > -1;
                    isSuccesful |= onlyPositives && !includeZero && userout > 0;
                    isSuccesful |= !onlyPositives && !includeZero && userout != 0;
                    isSuccesful |= !onlyPositives && includeZero;
                }
            } while (!isSuccesful);
            return (int)userout;
        }

        static bool GetUserKeyCompared(ConsoleKey key, string message="") {
            if (!string.IsNullOrEmpty(message)) {
                Console.WriteLine(message);
            }
            return Console.ReadKey().Key == key;
        }

        static void Main()
        {
        start_main:
            SubprogramSelector();
            int userout = GetUserIntRetrying();
            switch (userout)
            {
                case 1:
                    SubP_ifelse();
                    break;
                case 2:
                    SubP_while();
                    break;
                case 3:
                    SubP_dowhile();
                    break;
                case 4:
                    SubP_for();
                    break;
                case 5:
                    SubP_foreach();
                    break;
                case 6:
                    SubP_switch();
                    break;
                case -1:
                    goto exit_program;
                default: Console.WriteLine("Такой программы нет!"); break;
            }
            goto start_main;
        exit_program:
            if (GetUserKeyCompared(ConsoleKey.Escape, "Вы уверены что хотите завершить исполнение программы? Нажмите Esc для подтверждения..."))
            {
                Console.WriteLine("Завершение программы..");
                return;
            }
            else
            {
                goto start_main;
            }
        }

        private static void SubP_switch()
        {
        start_switch:
            // тут действительно не важно какие числа будут, если оба нуля то конечно проблема, а так без разницы
            Console.WriteLine("Подпрограмма switch - выполняет выбранное действие над числами");
            int n1 = GetUserIntRetrying("Введите число 1: ", newline: false);
            int n2 = GetUserIntRetrying("Введите число 2: ", newline: false);
            for (int i = 0; i < actions.Count; i++) { Console.WriteLine($"{i + 1}. {actions[i]}"); };
            int n3 = GetUserIntRetrying("Введите число, соотвествующее номеру действия: ", newline: false);
            if (n3 < 1 || n3 > actions.Count)
            {
                Console.WriteLine("Такого действия нет, отмена...");
                goto restart_switch;
            }
            if (n1 == 0 && n2 == 0)
            {
                Console.WriteLine("Числа равны нулю, отмена...");
                goto restart_switch;
            }
            int res = 0;
            switch (actions[n3-1])
            {
                case "-":
                    res = n1 - n2; break;
                case "+":
                    res = n1 + n2; break;
                case "/":
                    if (n2 == 0)
                    {
                        Console.WriteLine("Делить на 0 нельзя, отмена...");
                        goto restart_switch;
                    }
                    res = n1 / n2; break;
                case "*":
                    res = n1 * n2; break;
                case "%":
                    if (n2 == 0)
                    {
                        Console.WriteLine("Делить на 0 нельзя, отмена...");
                        goto restart_switch;
                    }
                    res = n1 % n2; break;
            }
            Console.WriteLine($"Результат: {res}");
        restart_switch:
            if (GetUserKeyCompared(ConsoleKey.Enter, ReturnToListText))
            {
                goto start_switch;
            }
        }

        private static void SubP_foreach()
        {
        start_foreach:
            // я думаю тут можно оставить отрицательные числа, ничего страшного не случится если отнять, а не прибавить
            Console.WriteLine("Подпрограмма foreach - подпрограмма добавляет число 1 к каждому символу введенной строки");
            Console.Write("Введите текст: ");
            string? str = Console.ReadLine();
            int userin = GetUserIntRetrying("Введите число: ",newline: false);
            string newstr = "";
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Входная строка пустая, отмена...");
                goto restart_foreach;
            }
            if (userin == 0)
            {
                Console.WriteLine("Число равно 0 или не введено, отмена...");
                goto restart_foreach;
            }
            foreach(char chr in str)
            {
                newstr += (char)(chr + userin);
            }
            Console.WriteLine(newstr);
        restart_foreach:
            if(GetUserKeyCompared(ConsoleKey.Enter, ReturnToListText))
            {
                goto start_foreach;
            }
        }

        private static void SubP_for()
        {
        start_for:
            // вот тут проблема, три числа должны быть одинакового знака, иначе можно застрять в бесконечном цикле
            // плюс третье не должно быть нулем
            Console.WriteLine("Подпрограмма for - подпрограмма будет перебирать числа от числа 1 до числа 2 с шагом числа 3");
            int n1 = GetUserIntRetrying("Введите число 1: ", false);
            int n2 = GetUserIntRetrying("Введите число 2: ", false);
            int n3 = GetUserIntRetrying("Введите число 3: ", false, includeZero: false);
            if (n3 > 0)
            {
                if (n1 >= n2)
                {
                    Console.WriteLine("Циклу нечего перебирать, отмена...");
                    goto restart_for;
                }
            }
            else if (n3 < 0)
            {
                if (n1 <= n2)
                {
                    Console.WriteLine("Циклу нечего перебирать, отмена...");
                    goto restart_for;
                }
            }

            if (n1 >= n2)
            {
                for (int i = n1; i > n2; i += n3)
                {
                    Console.WriteLine(i.ToString());
                }
            } 
            else {
                for (int i = n1; i < n2; i += n3)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            
        restart_for:
            if (GetUserKeyCompared(ConsoleKey.Enter, ReturnToListText))
            {
                goto start_for;
            }
        }

        private static void SubP_dowhile()
        {
        start_dowhile:
            // очередная очевидная проблема: второе число не может быть отрицательным и нулем - включаем параметр onlyPositives и выключаем includeZero
            Console.WriteLine("Подпрограмма do while - подпрограмма будет добавлять одно число к другому, пока оно не будет больше ста");
            int n1 = GetUserIntRetrying("Введите число 1: ", newline: false);
            int n2 = GetUserIntRetrying("Введите число 2: ", newline: false, onlyPositives: true, includeZero: false);
            if (n1 > 100)
            {
                Console.WriteLine("Число уже больше 100, отмена...");
                goto restart_dowhile;
            }
            do
            {
                n1 += n2;
                Console.WriteLine(n1);
            } while (n1 < 100);
            Console.WriteLine($"Результат: {n1}");
        restart_dowhile:
            if(GetUserKeyCompared(ConsoleKey.Enter, ReturnToListText))
            {
                goto start_dowhile;
            }
        }

        private static void SubP_while()
        {
        start_while:
            // отрицательные числа это плохая комбинация тут, запрещаем их
            Console.WriteLine("Подпрограмма while - подпрограмма будет вычитать одно число из другого пока последнее не будет меньше отнимаемого");
            int n1 = GetUserIntRetrying("Введите число от которого программа будет отнимать: ", newline: false, onlyPositives: true, includeZero: false);
            int n2 = GetUserIntRetrying("Введите число которое будет отниматься у первого числа: ", newline: false, onlyPositives: true, includeZero: false);
            if (n1 < n2)
            {
                Console.WriteLine("Число вычитаемое больше начального, отмена...");
                goto restart_while;
            }
            while (n1 > n2)
            {
                n1 -= n2;
                Console.WriteLine(n1);
            }
            Console.WriteLine($"Программа заверешена, число стало {n1}");
        restart_while:
            if (GetUserKeyCompared(ConsoleKey.Enter, ReturnToListText))
            {
                goto start_while;
            }
        }

        static void SubP_ifelse()
        {
        start_ifelse:
            int userin = GetUserIntRetrying("Подпрограмма if else - введите случайное число: ", newline: false);
            // очевидная проблема: если ввести 50, то выведет меньше, что не есть правильно
            // поставить >= не получится, и else if не использовать - программа то if else
            if (userin > 50)
            {
                Console.WriteLine("Число больше 50");
            } else
            {
                Console.WriteLine("Число меньше 50");
            }
            if (GetUserKeyCompared(ConsoleKey.Enter, ReturnToListText))
            {
                goto start_ifelse;
            }
        }

        static void SubprogramSelector()
        {
            Console.WriteLine("Введите номер подпрограммы для её вызова или -1 для выхода:");
            foreach (var instruction in instructions)
            {
                Console.WriteLine($"{instruction.Key}: {instruction.Value}");
            }
            Console.Write("> ");
        }
    }
}