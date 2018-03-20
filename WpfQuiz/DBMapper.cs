﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfQuiz
{
    /// <summary>
    /// DBMapper wird benutzt um Daten aus der Datenbank zu bekommen
    /// </summary>

    class DBMapper
    {
        private string connectionString = "";
        private SqlConnection connection;

        /// <summary>
        /// Konstruktor der die Verbindung mit der Datenbank aufbaut
        /// </summary>
        public DBMapper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["WpfQuiz.Properties.Settings.WpfQuizConnectionString"].ConnectionString;
            GetUserByID(0);
        }

        /// <summary>
        /// Bekommt einen User zurück dessen übergebene ID übereinstimmt
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public User GetUserByID(int userid)
        {
            string selectText = "SELECT * FROM Benutzer WHERE id=" + userid;
            User loadUser = new User();

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = selectText;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    loadUser.Id = Convert.ToInt32(reader[0].ToString());
                    loadUser.Name = reader[1].ToString();
                    loadUser.Password = reader[2].ToString();
                    loadUser.Highscore = Convert.ToInt32(reader[3].ToString());
                    loadUser.questionHistoryString = reader[4].ToString();
                    return loadUser;
                }
                return new User() { Id = 666, Name = "Error" }; // <-- Falls kein User gefunden werden sollte, einfach einen "User" zurück geben der Error als namen hat (Vorerst!!!)
            }
        }
        /// <summary>
        /// Bekommt eine Frage zurück dessen übergebene ID übereinstimmt
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Question GetQuestionByID(int questionID)
        {
            string selectText = "SELECT * FROM Frage WHERE id=" + questionID;
            Question loadQuestion = new Question();

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = selectText;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    loadQuestion.Id = Convert.ToInt32(reader[0].ToString());
                    loadQuestion.sprachID = Convert.ToInt32(reader[1].ToString());
                    loadQuestion.themenID = Convert.ToInt32(reader[2].ToString());
                    loadQuestion.fragenText = reader[3].ToString();
                    loadQuestion.antworten = reader[4].ToString().Split(',').ToList();
                    loadQuestion.richtigeAntwort = reader[5].ToString();
                    return loadQuestion;
                }
                return new Question() { Id = 666, fragenText = "Error" }; // <-- Falls keine Frage gefunden werden sollte, einfach eine "Question" zurück geben der Error als namen hat (Vorerst!!!)
            }
        }
    }
}
