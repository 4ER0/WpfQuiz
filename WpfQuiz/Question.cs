using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQuiz
{

    /// <summary>
    /// Hält eine Frage, diese Klasse kann in eine List<Question> gepackt werden, um somit mehrere Fragen zwischen zu speichern
    /// </summary>
    class Question
    {
        public int Id { get; set; }
        public int sprachID { get; set; }
        public int themenID { get; set; }
        public string fragenText { get; set; }
        public List<string> antworten { get; set; }
        public string richtigeAntwort { get; set; }
    }
}
