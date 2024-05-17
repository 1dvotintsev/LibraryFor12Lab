using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLibrary
{
    public class SmileEmoji : Emoji
    {
        Random random = new Random();

        string[] reasons = { "Хорошее настроение", "Успех в делах", "Хорошая погода", "Встреча с друзьями", "Подарок" };

        protected string reason;
        protected int grade;
        public string Reason
        {
            get { return reason; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))  // возвращает true, если строка состоит только из пробелов или null
                {
                    throw new ArgumentException("Причина не заполнена");
                }
                reason = value;
            }
        }

        public int Grade
        {
            get { return grade; }
            set
            {
                if (value < 0)
                {
                    grade = 0;
                }
                else
                    if (value <= 10)
                {
                    grade = value;
                }
                else grade = 10;
            }
        }

        public SmileEmoji() : base()
        {
            Reason = "undefined";
            Grade = 0;
        }
        public SmileEmoji(string name, string tag, int ident, string reason, int grade) : base(name, tag, ident)
        {
            Reason = reason;
            Grade = grade;
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Reason: {this.Reason}");
            Console.WriteLine($"Grade: {this.Grade}");
        }

        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Reason: {this.Reason}");
            Console.WriteLine($"Grade: {this.Grade}");
        }

        public override void Init()
        {
            base.Init();

            Console.WriteLine("Введите причину улыбки:");
            string reason = Console.ReadLine();
            if (reason != null)
            {
                Reason = reason;
            }
            else
                Reason = "undefined";

            int grade = 0;
            Console.WriteLine("Введите степень улыбки от 0 до 10");
            bool check = int.TryParse(Console.ReadLine(), out grade);
            if (check)
            {
                Grade = grade;
            }
            else
                Grade = 0;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Reason = reasons[random.Next(0, reasons.Length - 1)];
            Grade = random.Next(0, 10);
        }

        public override bool Equals(object obj)
        {
            SmileEmoji emoji = obj as SmileEmoji;
            if (emoji is SmileEmoji e)
            {
                return emoji.Name == e.Name && emoji.Tag == e.Tag && emoji.Reason == e.Reason && emoji.Grade == e.Grade;
            }
            else
                return false;
        }

        public new object Clone()
        {
            SmileEmoji clone = new SmileEmoji(this.Name, this.Tag, this.id.number, this.Reason, this.Grade);
            return clone;
        }

        public new object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return ($"\nName: {this.Name}\nTag: {this.Tag}\nReason: {this.Reason}\nGrade: {this.Grade}");
        }
    }
}
