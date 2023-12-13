namespace BUKEP.Student.Todo
{
	/// <summary>
	/// Класс TaskItem, содержит в себе название задачи Name и её описание Description
	/// </summary>
	public class Task
	{
		/// <summary>
		/// Название задачи
		/// </summary>
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
		public string Name { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
		/// <summary>
		/// Описание задачи
		/// </summary>
		public string? Description { get; set; }
	}
}
