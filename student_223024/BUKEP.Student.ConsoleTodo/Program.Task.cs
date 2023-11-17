namespace ConsoleTodo
{
    internal partial class Program
    {
        // создаем структуру Task, в которой удобным образом будут храниться данные о задаче
        struct Task
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}