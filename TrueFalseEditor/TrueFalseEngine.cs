using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TrueFalseEditor
{
    public class TrueFalseEngine
    {
        /* а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок(не создана база данных, обращение к несуществующему вопросу, 
         * открытие слишком большого файла и т.д.).
         * б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
         * в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
         * г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).*/

        // решение предоставил Юрченко Н.А.

        #region Private Fields

        private string fileName;
        private List<Question> list;

        #endregion

        #region Constructors

        public TrueFalseEngine(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        #endregion

        #region Public Properties

        public int Count
        {
            get { return list.Count; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        #endregion

        #region Public Methods

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count && list != null)
            {
                list.RemoveAt(index);
            }
        }

        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, list);
            fileStream.Close();
        }

        public void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlSerializer.Serialize(fileStream, list);
                fileStream.Close();
            }
        }

        #endregion

    }
}
