namespace BUKEP.Student.Todo
{
    /// <summary>
    /// Класс TaskItem, содержит в себе название задачи Name и её описание Description
    /// </summary>
    public class Task
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string? Description { get; set; }
    }
}
