using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuiz
{
    /// <summary>
    /// Beinhaltet einen User aus der Datenbank
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Highscore { get; set; }
        public string questionHistoryString { get; set; }
        public List<string> questionHistory { get; set; }
    }
}
