using Microsoft.Data.SqlClient;

namespace BUKEP.Student.Todo.Data
{
    /// <summary>
    /// Класс для доступа к списку задач используя базу данных
    /// </summary>
    public class DatabaseTaskManager : ITaskManager
    {
        // строка соединения для БД
        private readonly string _connectionString;

        public DatabaseTaskManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Функция, выполняющая анонимную функцию вместе с соединением
        /// </summary>
        /// <param name="funcToExecute">функция которую нужно выполнить с соединением БД</param>
        private void DoWithConnection(Func<SqlConnection, int> funcToExecute)
        {
            SqlConnection dbCon = new(_connectionString);
            dbCon.Open();
            funcToExecute(dbCon);
            dbCon.Close();
        }

        /// <summary>
        /// Функция, возвращающая список задач из базы данных
        /// </summary>
        /// <returns>Список задач</returns>
        private List<Task> GetTaskList()
        {
            List<Task> tasks = new();
            DoWithConnection((dbCon) =>
            {
                SqlCommand cmd = new("SELECT * FROM TaskTable", dbCon);
                SqlDataReader dataReader = cmd.ExecuteReader();
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
                return 0;
            });
            return tasks;
        }

        /// <inheritdoc/>
        public void AddTask(string Name, string? Description)
        {
            DoWithConnection((dbCon) =>
            {
                SqlCommand cmd = new("INSERT INTO TaskTable (Name, Description) VALUES (@Name, @Description)", dbCon);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.ExecuteNonQuery();
                return 0;
            });
        }

        /// <inheritdoc/>
        public void RemoveTask(Task task)
        {
            DoWithConnection((dbCon) =>
            {
                SqlCommand cmd = new("DELETE FROM TaskTable WHERE Id = @id", dbCon);
                cmd.Parameters.AddWithValue("@id", task.Id);
                cmd.ExecuteNonQuery();
                return 0;
            });
        }

        /// <inheritdoc/>
        public Task GetTaskById(int id)
        {
            Task existingTask = new();
            DoWithConnection((dbCon) =>
            {
                SqlCommand cmd = new($"SELECT * FROM TaskTable WHERE id = @id", dbCon);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    existingTask.Id = (int)dataReader.GetValue(0);
                    existingTask.Name = (string)dataReader.GetValue(1);
                    existingTask.Description = (string?)dataReader.GetValue(2);
                }
                dataReader.Close();
                return 0;
            });

            return existingTask;
        }

        /// <inheritdoc/>
        public IEnumerable<Task> GetTasks()
        {
            foreach (Task task in GetTaskList())
            {
                yield return task;
            }
        }

        /// <inheritdoc/>
        public void EditTask(int id, string? Name, string? Description)
        {
            DoWithConnection((dbCon) =>
            {
                SqlCommand cmd = new("UPDATE TaskTable SET Name = @name, Description = @descr WHERE Id = @id", dbCon);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@descr", Description);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return 0;
            });
        }
    }
}
