using System;
using Npgsql;
using System.Security.Cryptography;
using System.Text;

namespace english
{
    public static class DatabaseManager
    {
        private static string connectionString = "Host=localhost;Username=postgres;Password=123;Database=english";

        public static bool AuthenticateUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword); 

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;
                        }
                    }
                }
            }

            return false;
        }

        public static bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @userId";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
        }

        public static bool RegisterUser(string username, string password, string email)
        {
            string hashedPassword = HashPassword(password);

            string query = $"INSERT INTO Users (Username, Password, Email) VALUES (@username, @password, @email)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword); // Сохраняем хэшированный пароль
                    cmd.Parameters.AddWithValue("@email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Method to validate email address
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public static bool SaveQuizResult(int userId, int correctAnswers, int incorrectAnswers, int totalQuestions, decimal percentage, string level)
        {
            string query = @"INSERT INTO QuizResults (UserID, CorrectAnswers, IncorrectAnswers, TotalQuestions, Percentage, Level) 
                 VALUES (@userId, @correctAnswers, @incorrectAnswers, @totalQuestions, @percentage, @level)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@correctAnswers", correctAnswers);
                    cmd.Parameters.AddWithValue("@incorrectAnswers", incorrectAnswers);
                    cmd.Parameters.AddWithValue("@totalQuestions", totalQuestions);
                    cmd.Parameters.AddWithValue("@percentage", percentage);
                    cmd.Parameters.AddWithValue("@level", level);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public static void SaveMainQuizResult(int percentage)
        {
            string sqlQuery = "INSERT INTO MainQuizResults (UserID, Results) VALUES (@userId, @Results)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", 1);
                    cmd.Parameters.AddWithValue("@Results", percentage);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static int GetCurrentUserId(string username)
        {
            if (username == null)
            {
                // Если имя пользователя равно null, вернуть значение по умолчанию (например, -1)
                return 1;
            }

            string query = "SELECT UserID FROM Users WHERE Username = @username"; // Используем параметр @username здесь

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    // Выполнение запроса и получение результата
                    object result = cmd.ExecuteScalar();

                    // Проверка на null и преобразование к типу int
                    if (result != null && int.TryParse(result.ToString(), out int userId))
                    {
                        return userId;
                    }
                }
            }

            // Если не удалось получить ID пользователя, вернуть значение по умолчанию (например, -1)
            return -1;
        }


        public static bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Check if the old password is correct
            if (AuthenticateUser(username, oldPassword))
            {
                string query = "UPDATE Users SET Password = @newPassword WHERE Username = @username";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        // If the password was updated successfully
                        if (rowsAffected > 0)
                        {
                            // Get the user ID
                            int userId = GetCurrentUserId(username);

                            // Insert the changed password into ChangedPasswords table
                            string insertQuery = "INSERT INTO ChangedPasswords (UserID, NewPassword) VALUES (@userId, @newPassword)";
                            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@userId", userId);
                                insertCmd.Parameters.AddWithValue("@newPassword", newPassword);
                                insertCmd.ExecuteNonQuery();
                            }

                            return true;
                        }
                    }
                }
            }
            // If old password is incorrect
            return false;
        }
        public static List<PhrasalVerb> GetPhrasalVerbsStartingWithFromDatabase(string startWith)
        {
            List<PhrasalVerb> phrasalVerbs = new List<PhrasalVerb>();

            // Запрос к базе данных для извлечения фразовых глаголов, начинающихся на указанную строку
            string query = "SELECT PhrasalVerbID,verb, meaning, example FROM PhrasalVerbs WHERE verb LIKE @startWith";

            // Создание объекта подключения к базе данных
            using (var conn = new NpgsqlConnection(connectionString))
            {
                // Открытие подключения
                conn.Open();

                // Создание объекта команды для выполнения запроса
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Добавление параметра startWith к запросу
                    cmd.Parameters.AddWithValue("@startWith", $"{startWith}%");

                    // Выполнение запроса и получение результата
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Обработка результатов запроса
                        while (reader.Read())
                        {
                            // Создание объекта PhrasalVerb на основе данных из результата запроса
                            PhrasalVerb phrasalVerb = new PhrasalVerb
                            {
                                PhrasalVerbID = reader.GetInt32(0), // Получение PhrasalVerbID
                                Verb = reader.GetString(1), // Получение Verb
                                Meaning = reader.GetString(2), // Получение Meaning
                                Example = reader.GetString(3) // Получение Example
                            };

                            // Добавление объекта PhrasalVerb в список phrasalVerbs
                            phrasalVerbs.Add(phrasalVerb);
                        }
                    }
                }
            }

            return phrasalVerbs;
        }
        public static void SaveUserPhrasalVerbProgress(int userId, int PhrasalVerbID)
        {
            // Здесь вы можете выполнить сохранение прогресса изучения фразового глагола в базе данных
            // Например, с помощью SQL-запроса к вашей базе данных
            string query = "INSERT INTO UserPhrasalVerbProgress (UserID, PhrasalVerbID, CompletionStatus) VALUES (@userId, @PhrasalVerbID, false)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@PhrasalVerbID", PhrasalVerbID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<PhrasalVerb> GetPhrasalVerbsWithTranslations()
        {
            List<PhrasalVerb> phrasalVerbs = new List<PhrasalVerb>();

            string queryString = "SELECT PhrasalVerbID,Verb, Translate FROM PhrasalVerbs;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(queryString, connection))
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        PhrasalVerb phrasalVerb = new PhrasalVerb();
                        phrasalVerb.PhrasalVerbID = reader.GetInt32(0);// Получение PhrasalVerbID
                        phrasalVerb.Verb = reader.GetString(1); // Первый столбец - фразовый глагол
                        phrasalVerb.Translate = reader.GetString(2); // Второй столбец - перевод
                        phrasalVerbs.Add(phrasalVerb);
                    }

                    reader.Close();
                }
            }

            return phrasalVerbs;
        }

        public static List<PhrasalVerb> GetIncompletePhrasalVerbsForUser(int userId)
        {
            List<PhrasalVerb> incompletePhrasalVerbs = new List<PhrasalVerb>();

            string query = @"
        SELECT pv.PhrasalVerbID, pv.Verb, pv.Meaning, pv.Example
        FROM PhrasalVerbs pv
        INNER JOIN UserPhrasalVerbProgress upvp ON pv.PhrasalVerbID = upvp.PhrasalVerbID
        WHERE upvp.UserID = @userId AND upvp.CompletionStatus = FALSE;
    ";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhrasalVerb phrasalVerb = new PhrasalVerb
                                {
                                    PhrasalVerbID = reader.GetInt32(0),
                                    Verb = reader.GetString(1),
                                    Meaning = reader.GetString(2),
                                    Example = reader.GetString(3)
                                };

                                incompletePhrasalVerbs.Add(phrasalVerb);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Обработка исключения чтения данных из базы данных
                        Console.WriteLine("Error reading data from the database: " + ex.Message);
                    }
                }
            }

            return incompletePhrasalVerbs;
        }
        public static bool IsPhrasalVerbProgressExists(int userId, int PhrasalVerbID)
        {
            bool exists = false;

            // Запрос к базе данных для проверки наличия записи
            string query = "SELECT COUNT(*) FROM UserPhrasalVerbProgress WHERE UserId = @userId AND PhrasalVerbID = @PhrasalVerbID";

            // Создание объекта подключения к базе данных
            using (var conn = new NpgsqlConnection(connectionString))
            {
                // Открытие подключения
                conn.Open();

                // Создание объекта команды для выполнения запроса
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Добавление параметров к запросу
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@PhrasalVerbID", PhrasalVerbID);

                    // Выполнение запроса и получение результата
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Если количество записей больше нуля, значит запись существует
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }

        public static void DeletePhrasalVerbProgress(int userId, int PhrasalVerbID)
        {
            // Запрос к базе данных для удаления записи
            string query = "DELETE FROM UserPhrasalVerbProgress WHERE UserId = @userId AND PhrasalVerbID = @PhrasalVerbID";

            // Создание объекта подключения к базе данных
            using (var conn = new NpgsqlConnection(connectionString))
            {
                // Открытие подключения
                conn.Open();

                // Создание объекта команды для выполнения запроса
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Добавление параметров к запросу
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@PhrasalVerbID", PhrasalVerbID);

                    // Выполнение запроса
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static List<MainQuizResult> GetPreviousAttemptsByUserID(int userId)
        {
            List<MainQuizResult> previousAttempts = new List<MainQuizResult>();

            string query = "SELECT Results, Timedate FROM MainQuizResults WHERE UserID = @userId";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MainQuizResult attempt = new MainQuizResult
                            {
                                Results = reader.GetInt32(reader.GetOrdinal("Results")),
                                Timedate = DateTime.Parse(reader["Timedate"].ToString())
                            };

                            previousAttempts.Add(attempt);
                        }
                    }
                }
            }

            return previousAttempts;
        }
    }
}






