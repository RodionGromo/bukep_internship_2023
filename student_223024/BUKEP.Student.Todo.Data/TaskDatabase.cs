using Microsoft.Data.SqlClient;

namespace BUKEP.Student.Todo.Data
{
	public class TaskDatabase : ITaskManager
	{
		private SqlConnection _dbCon;
		// TODO: удалить заготовленную запись и вернуть индекс к 0
		private int _taskIndex = 1;

		private List<Task> GetTaskList()
		{
			SqlCommand cmd = new("SELECT * FROM TaskTable", _dbCon);
			SqlDataReader data = cmd.ExecuteReader();
			List<Task> tasks = new();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Task newTask = new()
					{
						Id = (int)data.GetValue(0),
						Name = (string)data.GetValue(1),
						Description = (string?)data.GetValue(2)
					};
					tasks.Add(newTask);
				}
			}
			data.Close();
			return tasks;
		}

		private void SendSQLCommandIgnoreResults(string command)
		{
			SqlCommand cmd = new(command, _dbCon);
			cmd.ExecuteNonQuery();
		}

		public void AddTask(string Name, string? Description)
		{
			SendSQLCommandIgnoreResults($"INSERT INTO TaskTable (Id, Name, Description) VALUES ({_taskIndex}, '{Name}', '{Description}')");
		}

		public void RemoveTask(Task task)
		{
			SendSQLCommandIgnoreResults($"DELETE FROM TaskTable WHERE Id = {task.Id}");
		}

		public Task GetTaskById(int id)
		{
			SqlCommand sql = new($"SELECT * FROM TaskTable WHERE id = {id}", _dbCon);
			SqlDataReader data = sql.ExecuteReader();
			Task existingTask = new();
			if(data.HasRows)
			{
				while (data.Read())
				{
					existingTask.Id = (int)data.GetValue(0);
					existingTask.Name = (string)data.GetValue(1);
					existingTask.Description = (string?)data.GetValue(2);
				}
			}
			data.Close();
			return existingTask;
		}

		public IEnumerable<Task> GetTasks()
		{
			foreach(Task task in GetTaskList())
			{
				yield return task;
			}
		}

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
