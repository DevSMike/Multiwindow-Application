using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheKursBegins
{
    public partial class FormCreate : Form
    {
        //Метод для получения введённых данных
        //Для простоты возвращает список обектов, так как типы разные
        //Список лучше чем массив:)
        public List<object> GetData()
        {
            List<object> res = new();

            //Проходим по всем контролям в форме
            //Нас интересуют текстовые поля и CheckBox
            //Если бы ещё что интересовало - был бы смысл использовать switch
            foreach(var c in Controls)
            {
                if (c is TextBox)
                    //Если текстовое поле - забираем текст
                    res.Add((c as TextBox).Text);
                else if (c is CheckBox)
                    //Если CheckBox - состояние
                    res.Add((c as CheckBox).Checked);
            }
            //Возвращаем полученный список
            return res;
        }
        public FormCreate()
        {
            InitializeComponent();
        }

        //Метод для смены подписи к текстовому полю
        public void SetLabel1Name(string s)
        {
            label1.Text = s;
        }
        public void SetMenuLabelName (string s)
        {
            menuLableForMethod.Text = s;
        }
        public void SetPlaceName (string s)
        {
            labelForPlace.Text = s;
        }
        
        //Просто кнопки ОК и отмена
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
