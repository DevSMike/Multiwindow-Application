using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TheKursBegins
{
    public partial class MainForm : Form
    {
        //Список всех объектов. Использует новый служебный интерфейс чтобы не делать список из object
        List<ICourseWork> _elements;
        //проверка состояния сохранения документа 
        private bool isDocumentIsSaved = false;
        public MainForm()
        {
            InitializeComponent();
            //В конструкторе надо не забыть создать новый список
            _elements = new();

        }
        //Магический метод для десериализации
        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        //Метод для создания списка делегатов для объекта
        //Можно и без него, но так расширяемее
        List<Func<string>> _getDelegateList(ICourseWork obj)
        {
            return obj.GenerateDelegateList();
        }

        //Функция для для запуска методов, которые имеет интефейс ICollectable 
        //благодаря этой функции, мы ипользуем наши коллекционные штучки 
       private void CollectInit(ICollectable item) 
        {
            textBox1.AppendText(item.Admire() + Environment.NewLine);
            textBox1.AppendText(item.UseAThing() + Environment.NewLine);
            
        } 
        //Добавление элементов
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Смотрит по индексу выбранного элемента в комбобоксе
            switch (comboBox1.SelectedIndex)
            {
                //0 - Марка
                case 0:
                    {
                        //У него конструктор с параметрами - надо использовать дополнительную форму
                        var form = new FormCreate();
                        //Надо настроить её - добавить поле чтобы отметить наличие ножа
                        //Создаём поле
                        form.SetLabel1Name("Введите имя владеньца");
                        form.SetMenuLabelName("Введите почтовый индекс");
                        form.SetPlaceName("Введите место нахождения");
                        //Теперь запускаем форму и если выбрано добавить...
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            //Берём данные из формы
                            var lst = form.GetData();
                            //Создаём марку
                            var tmpstamp = new Stamp(lst[2].ToString(), Convert.ToInt32(lst[1]), lst[0].ToString());
                            //Добавляем его в список объектов
                            _elements.Add(tmpstamp);
                            //А информацию о нём в ListBox
                            listBox1.Items.Add(tmpstamp);
                        }
                    }
                    break;
                //1 - Календарик
                case 1:
                    {
                        //Примерно по той же схеме
                        var form = new FormCreate();
                        //Тут не надо добавлять новый элементы на форму, но надо переименовать старый
                        form.SetLabel1Name("Введите имя владеньца");
                        form.SetMenuLabelName("Введите текущий \nкалендарный год");
                        form.SetPlaceName("Введите место нахождения");
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            //Нумерация lst идет с конца (имя первое вводим, но в списке самое последнее будет)
                            var lst = form.GetData();
                            var tmpcalendar = new Calendar(lst[2].ToString(), Convert.ToInt32(lst[1]), lst[0].ToString()) ;
                            _elements.Add(tmpcalendar);
                            listBox1.Items.Add(tmpcalendar);
                        }
                    }
                    break;
                //2 - Игрушка из Мака
                case 2:
                    {
                       
                        var form = new FormCreate();
                        form.SetLabel1Name("Введите имя владеньца");
                        form.SetMenuLabelName("Игрушка из Хэппи Мила? \n(Ввести Да/Нет)");
                        form.SetPlaceName("Введите место нахождения");
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var lst = form.GetData();
                            var tmpMcDonaldToy = new McDonaldsToy(lst[2].ToString(), lst[1].ToString(), lst[0].ToString());
                            _elements.Add(tmpMcDonaldToy);
                            listBox1.Items.Add(tmpMcDonaldToy);
                        }
                    }
                    break;
                //3 - Книга
                case 3:
                    {
                        var form = new FormCreate();
                        form.SetLabel1Name("Введите имя владеньца");
                        form.SetMenuLabelName("Читали ли Вы эту книгу?\n(Ввести Да/Нет)");
                        form.SetPlaceName("Введите место нахождения");
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var lst = form.GetData();
                            var tmpBook = new Book(lst[2].ToString(), lst[1].ToString(), lst[0].ToString());
                            _elements.Add(tmpBook);
                            listBox1.Items.Add(tmpBook);
                        }
                    }
                    break;
                
            }
        }

        //Удаление
        private void buttonDel_Click(object sender, EventArgs e)
        {
            //Тут всё просто - смотрим что выбрано в списке и удаляем
            int index = listBox1.SelectedIndex;
            //Если ничего не выбрано - индекс будет -1
            if (index != -1)
            {
                _elements.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
            }
        }

        //Запуск методов
        private void buttonMethod_Click(object sender, EventArgs e)
        {
            //Смотрим какой элемент выбран
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                //Генерация списка делегатов
                var lst = _getDelegateList(_elements[index]);
                //Создание формы и передача в неё делегатов
                FormMethod form = new(lst);
                form.ShowDialog();
                //Вывод результата в "консоль"
                textBox1.AppendText(form.GetResult() + Environment.NewLine);
                //Обновление элемента в ListBox - вдруг у него свойства изменились
                listBox1.Items[index] = _elements[index].ToString();
            }
        }

        //Запуск коллекционных вещей
        private void buttonStart_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                //Если выбрана вещь
                if (_elements[index] is ICollectable)
                {
                    //Выполнение метода и обновление информации в ListBox
                    CollectInit((ICollectable)_elements[index]);
                    listBox1.Items[index] = _elements[index].ToString();
                }
                else
                    //Иначе - вывод на "консоль" что пошло не так
                    textBox1.AppendText("Это не коллекционная вещь" + Environment.NewLine);
            }
        }

        //Сериализация
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Почти как в примере по формам - открываем диалог для сохранения
            using (SaveFileDialog FileDialog = new())
            {
                FileDialog.Filter = "dat (*.dat)|*.dat";
                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Теперь у нас есть путь!
                    string filePath = FileDialog.FileName;
                    //Создаём файл
                    using (BinaryWriter sr = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                    {
                        //Сначала запишем заранее придуманный идентификатор формата
                        //Да, есть и другие способы узнать формат, но это самый простой
                        string Ident = "MAGIDATA0451";
                        sr.Write(Ident);
                        foreach (var obj in _elements)
                        {
                            //Для каждого элемента сериализуем в массив байт
                            var b = obj.GetByteArray();
                            //Записываем длину массива в файл
                            sr.Write(b.Length);
                            //Записываем сам массив
                            sr.Write(b);
                        }
                    }
                }
            }
            isDocumentIsSaved = true;
        }
        //Десериализация
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog FileDialog = new())
            {
                FileDialog.Filter = "dat (*.dat)|*.dat";
                if (FileDialog.ShowDialog() == DialogResult.OK)
                {                
                    string filePath = FileDialog.FileName;
                    using (BinaryReader sr = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        //Для надёжности проверим формат файла - есть ли в начале волшебная строчка
                        var Ident = sr.ReadString();
                        if (Ident == "MAGIDATA0451")
                        {
                            //Если есть - для начала очищаем списки
                            _elements.Clear();
                            listBox1.Items.Clear();
                            //Проверяем что файл ещё не закончился. Для этого смотрим позицию в файле
                            while (sr.BaseStream.Position != sr.BaseStream.Length)
                            {
                                //Считываем размер массива
                                var arsize = sr.ReadInt32();
                                //Считываем сам массив
                                var byteArray = sr.ReadBytes(arsize);
                                //Десериализуем из массива байт
                                var res = ByteArrayToObject(byteArray);
                                //Добавления элемента с его преобразованием
                                _elements.Add(res as ICourseWork);
                                listBox1.Items.Add(res.ToString());
                            }
                        }
                        else
                            textBox1.AppendText("Неверный формат файла" + Environment.NewLine);
                    }
                }
            }
        }
        // Перехват закрытия формы, предложение сохранить файл
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDocumentIsSaved && listBox1.Text != "")
            {
                if (MessageBox.Show("Вы хотите сохранить изменения?", "Мой документ",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = true;
                    //Выполняем сохранение элемента
                    buttonSave_Click(sender, e);
                    MessageBox.Show("Файл успешно сохранён!");
                }
            }
        }
    }
}
