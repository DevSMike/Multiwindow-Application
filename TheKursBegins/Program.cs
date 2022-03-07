using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TheKursBegins
{

    public interface ICollectable
    {
        public string UseAThing();
        public string Admire();
    }
    public interface ICourseWork
    {
        List<Func<string>> GenerateDelegateList();
        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }
    }
    [Serializable]
    public abstract class CollectorItem 
    {

        private static readonly string _type = "Example";
        protected string _name;
        protected double _price;
        protected int _yearofdrop;
        protected string _nameofcollector;
        protected string _place;

        protected CollectorItem()
        {
            _name = "CollctorItem";
            _price = 0.1;
            _yearofdrop = 0;
            _nameofcollector = "Programmer";
            _place = "Don't have";
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public double Price
        {
            get => _price;
            set => _price = value;
        }
        public int YearOfDrop
        {
            get => _yearofdrop;
            set => _yearofdrop = value;
        }
        public string NameOfTheCollector
        {
            get => _nameofcollector;
            set => _nameofcollector = value;
        }
        public string Place
        {
            get => _place;
            set => _place = value;
        }
        public static string GetCollectionType()
        {
            return ("Тип коллекционной вещи:" + _type);
        }

        protected bool WannaChangeThePosition()
        {
            bool decision;
            Console.WriteLine("Вы хотите переставить вещь на другую полку?");
            Console.WriteLine("1. Да.");
            Console.WriteLine("2. Нет.");
            int choice = -1;
            bool quit = false;
            while (!quit)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    quit = true;
                }
                catch
                {
                    Console.WriteLine(" Введены данные некорректного типа! ");
                }
            }

            if (choice == 1)
                decision = true;
            else
                decision = false;

            return decision;
        }

        public virtual void ChangeThePosition()
        {
            if (WannaChangeThePosition())
            {
                Console.WriteLine(" Введите новое местоположение для коллекционной вещи '{0}'", _type);
                _place = Console.ReadLine();
                Console.WriteLine(" Вы успешно переставили свою коллекционную вещь в {0}", _place);

            }
            else
            {
                Console.WriteLine(" Вы решили не менять местоположение вашей коллекционной вещи.");
                Console.WriteLine(" Её текущее местоположение - {0} ", _place);
            }
        }
        public override string ToString()
        {
            return String.Format("Это {0}, ей владеет {1}. Коллекционнная вещь находится в {2}!", _name, _nameofcollector, _place);
        }
        static public bool IsItYesOrNo(string answer)
        {
            bool isItYesOrNo = false;
            if (answer == "Да")
                isItYesOrNo = true;
            else if (answer == "Нет")
                isItYesOrNo = false;
            else isItYesOrNo = true;

            return isItYesOrNo;
        }
    }

    [Serializable]
    public class Stamp : CollectorItem, ICollectable, ICourseWork
    {
        private static readonly string _type = "Марка";
        protected int _postindex;
        public Stamp()
        {
            _name = "Stamp";
            _price = 15;
            _yearofdrop = 1990;
            _nameofcollector = "Имя";
            _place = "Альбом";
        }
        public Stamp (string name, int postindex, string place)
        {
            _name = "Stamp";
            _place = place;
            _nameofcollector = name;
            _postindex = postindex;
        }
        public int PostIndex
        {
            get => _postindex;
            set => _postindex = value;
        }
        public static new string GetCollectionType()
        {
            return ("Тип коллекционной вещи: " + _type);
        }
        public override void ChangeThePosition()
        {
            if (WannaChangeThePosition())
            {
                Console.WriteLine(" Введите новое местоположение для марки '{0}'", _type);
                _place = Console.ReadLine();
                Console.WriteLine(" Вы успешно переставили свою марку в {0}", _place);
            }
            else
            {
                Console.WriteLine(" Вы решили не менять местоположение вашей марки.");
                Console.WriteLine(" Её текущее местоположение - {0} ", _place);
            }
        }
        public string GetThePostIndex()
        {
            string country;
            if (_postindex > 1000)
                country = "Russia";
            else
                country = "Not-Detected";
            return (" Страна-производитель вашей марки -" + country + "!");
        }
        public override string ToString()
        {
            return String.Format("Это {0}, ей владеет {1}. Почтовый индекс этой марки: {2}!", _name, _nameofcollector, _postindex);
        }
        public string UseAThing()
        {
            return "Вы сейчас держите в руках свою марку!";
        }
        public string Admire()
        {
            return "Вы сейчас любуютесь своей маркой!";
        }

        public List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { UseAThing, Admire, GetCollectionType, GetThePostIndex };
        }
    }

    [Serializable]
    public class Calendar : CollectorItem, ICollectable, ICourseWork
    {
        private static readonly string _type = "Календарик";
        protected int _currentyear;
        public Calendar()
        {
            _name = "Calendar";
            _price = 23;
            _yearofdrop = 2022;
            _nameofcollector = "Имя";
            _place = "Стол";
        }
        public Calendar (string name,  int year, string place)
        {
            _name = "Calendar";
            _nameofcollector = name;
            _currentyear = year;
            _place = place;
        }
        public int CurrentYear
        {
            get => _currentyear;
            set => _currentyear = value;
        }
        public override void ChangeThePosition()
        {
            if (WannaChangeThePosition())
            {
                Console.WriteLine(" Введите новое местоположение для календарика '{0}'", _type);
                _place = Console.ReadLine();
                Console.WriteLine(" Вы успешно переставили свой календарик в {0}", _place);
            }
            else
            {
                Console.WriteLine(" Вы решили не менять местоположение вашего календарика.");
                Console.WriteLine(" Его текущее местоположение - {0} ", _place);
            }
        }
        public static new string GetCollectionType()
        {
            return ("Тип коллекционной вещи: " + _type);
        }
        public string GetCurrentCentury()
        {
            return ("Век берется по текущему году, который сейчас указывает ваш календарь. Текущий век: " + (_currentyear / 100 + 1 )+ "! ");
        }
        public override string ToString()
        {
            return String.Format("Это {0}, ей владеет {1}. Сейчас год: {2}!", _name, _nameofcollector, _currentyear);
        }
        public string UseAThing()
        {
            return "Вы сейчас держите в руках свой календарик";
        }
        public string Admire()
        {
            return "Вы сейчас любуютесь своим календариком ))";
        }
        public List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { UseAThing, Admire, GetCollectionType, GetCurrentCentury };
        }
    }
    [Serializable]
    public class McDonaldsToy : CollectorItem, ICollectable, ICourseWork
    {
        private static readonly string _type = "Игрушка из Мака";
        protected bool _isfromhappymeal;
        public McDonaldsToy()
        {
            _name = "Toy";
            _price = 229;
            _yearofdrop = 2021;
            _nameofcollector = "Имя";
            _place = "Шкаф";
        }
        public McDonaldsToy(string name, string isfromhappy, string place)
        {
            _name = "Toy";
            _nameofcollector = name;
            _isfromhappymeal = IsItYesOrNo(isfromhappy);
        }
        public bool IsFromHappyMeal
        {
            get => _isfromhappymeal;
            set => _isfromhappymeal = value;
        }
        public override void ChangeThePosition()
        {
            if (WannaChangeThePosition())
            {
                Console.WriteLine(" Введите новое местоположение для игрушки из Макдональдса '{0}'", _type);
                _place = Console.ReadLine();
                Console.WriteLine(" Вы успешно переставили свою игрушку в {0}", _place);
            }
            else
            {
                Console.WriteLine(" Вы решили не менять местоположение вашей игрушки.");
                Console.WriteLine(" Её текущее местоположение - {0} ", _place);
            }
        }
        public static new string GetCollectionType()
        {
            return ("Тип коллекционной вещи: " + _type);
        }

        public string MakesYouHappy()
        {
            if (_isfromhappymeal == true)
                return (" Теперь вы счастливы!");
            else
                return (" =( ");
        }
        public override string ToString()
        {
            string temp;
            if (_isfromhappymeal == true)
                temp = "Счастилвый";
            else
                temp = "Несчастный";
            return String.Format("Это {0}, ей владеет {1}. Cейчас Вы {2}", _name, _nameofcollector, temp);
        }
        public string UseAThing()
        {
            return "Вы сейчас держите в руках свою игрушку из МакДака!!";
        }
        public string Admire()
        {
            return "Вы сейчас любуютесь своей игрушкой из МакДака!!)";
        }
        public List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { UseAThing, Admire, GetCollectionType, MakesYouHappy };
        }
    }
    [Serializable]

    public class Book : CollectorItem, ICollectable, ICourseWork
    {
        private static readonly string _type = "Книга";
        protected bool _isRead;

        public Book()
        {
            _name = "Book";
            _price = 250;
            _yearofdrop = 2021;
            _nameofcollector = "Имя";
            _place = "Книжная Полка";
        }
        public Book( string name, string isRead, string place)
        {
            _name = "Book";
            _place = place;
            _nameofcollector = name;
            _isRead = IsItYesOrNo(isRead);
        }
        public bool IsRead
        {
            get => _isRead;
            set => _isRead = value;
        }
        public override void ChangeThePosition()
        {
            if (WannaChangeThePosition())
            {
                Console.WriteLine(" Введите новое местоположение для книги '{0}'", _type);
                _place = Console.ReadLine();
                Console.WriteLine(" Вы успешно переставили свою книгу в {0}", _place);
            }
            else
            {
                Console.WriteLine(" Вы решили не менять местоположение вашей книги.");
                Console.WriteLine(" Её текущее местоположение - {0} ", _place);
            }
        }
        public static new string GetCollectionType()
        {
            return ("Тип коллекционной вещи: " + _type);
        }

        public string MakesYouSmart()
        {
            return " Вы начинаете читать книгу!";
        }
        public override string ToString()
        {
            return String.Format("Это {0}, ей владеет {1}.\n Книга находится на/в {2}", _name, _nameofcollector, _place);
        }
        public string UseAThing()
        {
            return "Вы сейчас держите в руках свою книку!!";
        }
        public string Admire()
        {
            return "Вы сейчас любуютесь своей книгой!!)";
        }
        public List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { UseAThing, Admire, GetCollectionType, MakesYouSmart };
        }
    }
    
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
    }
}
