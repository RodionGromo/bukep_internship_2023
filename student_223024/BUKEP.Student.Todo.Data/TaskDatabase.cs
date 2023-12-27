using Microsoft.Data.SqlClient;

namespace BUKEP.Student.Todo.Data
{
	public class TaskDatabase : ITaskManager
	{
		// соединение с БД
		private readonly SqlConnection _dbCon;

		// индекс для id задач
		private int _taskIndex = 0;

		/// <summary>
		/// Функция, возвращающая список задач из базы данных
		/// </summary>
		/// <returns>Список задач</returns>
		private List<Task> GetTaskList()
		{
			SqlCommand cmd = new("SELECT * FROM TaskTable", _dbCon);
			SqlDataReader dataReader = cmd.ExecuteReader();
			List<Task> tasks = new();
			if (dataReader.HasRows)
			{
				while (dataReader.Read())
				{
					Task newTask = new()
					{
						Id = (int)dataReader.GetValue(0),
						Name = (string)dataReader.GetValue(1),
						Description = (string?)dataReader.GetValue(2)
					};
					tasks.Add(newTask);
				}
			}
			dataReader.Close();
			return tasks;
		}

		/// <summary>
		/// Функция, исполняющая команду command на базе данных и не возвращает никакого результата
		/// </summary>
		/// <param name="command">Команда, которую нужно выполнить</param>
		private void SendSQLCommandIgnoreResults(string command)
		{
			SqlCommand cmd = new(command, _dbCon);
			cmd.ExecuteNonQuery();
		}

		/// <inheritdoc/>
		public void AddTask(string Name, string? Description)
		{
			SendSQLCommandIgnoreResults($"INSERT INTO TaskTable (Id, Name, Description) VALUES ({_taskIndex}, '{Name}', '{Description}')");
			_taskIndex++;
		}

		/// <inheritdoc/>
		public void RemoveTask(Task task)
		{
			SendSQLCommandIgnoreResults($"DELETE FROM TaskTable WHERE Id = {task.Id}");
		}

		/// <inheritdoc/>
		public Task GetTaskById(int id)
		{
			SqlCommand sql = new($"SELECT * FROM TaskTable WHERE id = {id}", _dbCon);
			SqlDataReader dataReader = sql.ExecuteReader();
			Task existingTask = new();
			if(dataReader.HasRows)
			{
				dataReader.Read();
				existingTask.Id = (int)dataReader.GetValue(0);
				existingTask.Name = (string)dataReader.GetValue(1);
				existingTask.Description = (string?)dataReader.GetValue(2);
			}
			dataReader.Close();
			return existingTask;
		}

		/// <inheritdoc/>
		public IEnumerable<Task> GetTasks()
		{
			foreach(Task task in GetTaskList())
			{
				yield return task;
			}
		}

		/// <inheritdoc/>
		public void EditTask(int id, string? Name, string? Description)
		{
			SendSQLCommandIgnoreResults($"UPDATE TaskTable SET Name = '{Name}', Description = '{Description}' WHERE Id = {id}");
		}

		public TaskDatabase(string connectionString)
		{
			_dbCon = new(connectionString);
			_dbCon.Open();
		}
	}
}
