namespace CustomLibrary
{
    public class IdNumber
    {
        public int number;
        public IdNumber(int n)
        {
            this.number = n;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is IdNumber em)
                return this.number == em.number;
            return false;
        }
    }

    public class Emoji : IInit, IComparable, ICloneable, IComparable<Emoji>
    {
        string[] names = {
    "Улыбашка", "Смайлик", "Смешинка", "Весельчак", "Радость",
    "Смайл", "Улыбка", "Смехотун", "Сияние", "Веселушка",
    "Лучезарный", "Смех", "Веселость", "Смеющийся", "Хохотун",
    "Радостный", "Улыбчивый", "Веселый", "Веселина", "Радуга",
    "Веселый", "Радостный", "Сияющий", "Смехопанорама", "Сияющий",
    "Радость", "Смешной", "Веселушка", "Улыбка", "Смайл",
    "Радуга", "Хохот", "Веселье", "Улыбка", "Смех",
    "Радостный", "Улыбчивый", "Сияющий", "Смешной", "Веселый",
    "Веселина", "Радуга", "Веселушка", "Смех", "Улыбчивый",
    "Веселый", "Веселость", "Смешной", "Сияющий", "Хохот",
    "Радость", "Улыбка", "Смайлик", "Смех", "Радостный",
    "Улыбчивый", "Смешной", "Веселый", "Веселина", "Сияющий",
    "Смайл", "Смех", "Веселость", "Радость", "Сияющий",
    "Радуга", "Веселый", "Смешной", "Смех", "Улыбка",
    "Радуга", "Хохот", "Веселость", "Смейся", "Смешной",
    "Веселина", "Радость", "Сияющий", "Смейся", "Веселый",
    "Смех", "Смайл", "Улыбчивый", "Веселушка", "Смешной",
    "Радость", "Сияющий", "Улыбка", "Веселый", "Веселость",
    "Радуга", "Смех", "Веселина", "Смешной", "Радость"};
        string[] tags = {
    "smile", "sad", "clown", "depressed", "cry",
    "animal", "monkey", "happy", "laugh", "funny",
    "joy", "cheerful", "laughter", "happiness", "emotions",
    "mood", "positive", "joke", "humor", "smiley",
    "laughter", "joyful", "hilarious", "uplifting", "gleeful",
    "chuckle", "giggle", "beam", "grin", "joyous",
    "delighted", "content", "merry", "joyful", "hilarious",
    "lighthearted", "silly", "playful", "jolly", "amusing",
    "chirpy", "festive", "glad", "joyful", "blithe",
    "exuberant", "sunny", "buoyant", "peppy", "mirthful",
    "vivacious", "convivial", "elated", "smile", "gaiety",
    "smiling", "beaming", "glee", "comical", "facetious",
    "jocular", "witty", "comedy", "hilarity", "amusement",
    "chortle", "cackle", "snicker", "grin", "smirk",
    "pleasure", "hilarious", "fun", "merry", "joking",
    "chuckle", "laughing", "joyous", "mirth", "giggling",
    "laughable", "jester", "whimsical", "jollity", "humorous",
    "funny", "ludicrous", "jovial", "rofl", "laughter"
};

        Random random = new Random();

        protected string name;
        protected string tag;
        protected static int count = 0;

        public IdNumber id;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))  // возвращает true, если строка состоит только из пробелов или null
                {
                    throw new ArgumentException("Имя не заполнено");
                }
                name = value;
            }
        }

        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))  // возвращает true, если строка состоит только из пробелов или null
                {
                    throw new ArgumentException("Тэг не заполнен");
                }
                tag = value;
            }
        }

        public Emoji()
        {
            count++; ;
            Name = $"name{count}";
            Tag = $"tag{count}";
            id = new IdNumber(1);
        }

        public Emoji(string name, string tag, int ident)
        {
            count++;
            Name = name;
            Tag = tag;
            id = new IdNumber(ident);

        }

        public void Show()
        {
            Console.WriteLine($"\nName: {this.Name}\nTag: {this.Tag}");
        }

        public virtual void ShowVirtual()
        {
            Console.WriteLine($"\nID: {this.id}\nName: {this.Name}\nTag: {this.Tag}");
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите ID:");
            id.number = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите имя Эмоджи:");
            string name = Console.ReadLine();
            if (name != null)
            {
                Name = name;
            }
            else
                Name = "No name";

            Console.WriteLine("Введите тэг:");
            string tag = Console.ReadLine();
            if (tag != null)
            {
                Tag = tag;
            }
            else
                Tag = "No tag";

        }

        public virtual void RandomInit()
        {
            Name = names[random.Next(0, names.Length - 1)];
            Tag = tags[random.Next(0, tags.Length - 1)];
            id.number = random.Next(0, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Emoji emoji = obj as Emoji;
            if (emoji != null)
            {
                return emoji.Name == this.Name && emoji.Tag == this.Tag;
            }
            else
                return false;
        }

        //поиск самого сильного эмоджи
        public static string FindBestGrade(Emoji[] array)
        {
            int count = 0;
            SmileEmoji emoji = new SmileEmoji();

            foreach (Emoji e in array)
            {
                if (e is SmileEmoji smile)
                {
                    count++;

                    if (smile.Grade >= emoji.Grade)
                        emoji = smile;
                }
            }

            if (count != 0)
            {
                return $"\nСамае сильная степень улыбки эмоджи: {emoji.Grade}";
            }
            else
                return "\nВ массиве нет эмоджи, обладающих силой";
        }

        //причины улыбающихся с силой не меньше
        public static string FindReasonsFrom(Emoji[] array, int minGrade)
        {
            string result = $"\nПричины всех улыбающихся эмоджи силой больше {minGrade}: ";
            int count = 0;

            foreach (Emoji e in array)
            {
                if (e is SmileEmoji smile && smile.Grade >= minGrade)
                {
                    count++;
                    result += smile.Reason + ", ";
                }
            }
            if (count > 0)
            {
                return result;
            }
            else
                return "\nВ массиве нет улыбающихся эмоджи.";
        }

        //тэги всех эмоджи-животных
        public static string FindAnimalsTags(Emoji[] array)
        {
            int count = 0;
            string result = "\nТэги всех животных-эмоджи в массиве: ";

            foreach (Emoji e in array)
            {
                if (e is AnimalEmoji animal)
                {
                    count++;
                    result += animal.Tag + ", ";
                }
            }

            if (count != 0)
            {
                return result;
            }
            else
                return "\nВ массиве нет животных-эмоджи";
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Emoji) return -1;
            Emoji emoji = obj as Emoji;
            return string.Compare(this.Name, emoji.Name);
        }

        public int CompareTo(Emoji other)
        {
            return string.Compare(this.Name, other.Name);
        }

        public object Clone()
        {
            return new Emoji(Name, Tag, id.number);
        }

        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return ($"Name: {this.Name}  Tag: {this.Tag}");
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Tag.GetHashCode();
        }
    }
}
