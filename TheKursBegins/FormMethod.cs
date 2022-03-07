using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheKursBegins
{
    public partial class FormMethod : Form
    {
        //По умолчанию результатом будет сообщение об ошибке
       private string _result = "Метод не выбран!";
        //Список делегатов
        List<Func<string>> _delegates;
        //Метод для получение результата
        //Все методы возвращают строку, так что и форма вернёт строку.
        //Было бы сложнее - возвращали бы object
        public string GetResult()
        {
            return _result;
        }

        public FormMethod()
        {
            InitializeComponent();
        }

        //Тут будет нужен конструктор с параметрами
        //Чтобы не дублировать код, через список инициализации он вызовет обычный конструктор
        public FormMethod(List<Func<string>> lst):this()
        {
            //Делегаты сохраняются во внутреннем списке
            _delegates = lst;
            //Имена методов заносятся в комбобокс
            foreach(var i in _delegates)
            {
                comboBox1.Items.Add(i.Method.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index != -1)
            {
                //Если выбран метод, то выполняется связанный с ним делегат и результат сохраняется
                    _result = _delegates[index]();
            }
            //Форма закрывается
            Close();
        }
    }
}
