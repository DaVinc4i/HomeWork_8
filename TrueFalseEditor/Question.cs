using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueFalseEditor
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Ответ (да/нет)
        /// </summary>
        public bool TrueFalse { get; set; }

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

        public Question() { }

    }
}
