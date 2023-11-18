using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Typing
{
    internal class Program
    {
        static string text = "Чикибамбони Чики-Чертила Чикибамболейло\r\nЧики-Бом-Бом Чикибамжитель Чикибамблин\r\nЧикибамкрипер Чикибамхайп Чикибамбог\r\nЧики-Хот-Дог Чикибанбони Чикибамбрики";

        static void Speed()
        {
            name.SymbolPerMinute = i;
            name.SymbolPerSecond = i / 60;
        }
        private static void Time()
        {
            Thread t = new Thread(_ =>
            {
                var dateTime = DateTime.Now;
                DateTime dt = dateTime.AddMinutes(-1);

                while (dateTime >= dt && isOn)
                {
                    Console.SetCursorPosition(0, 10);
                    if (i == text.Length)
                    {
                        isOn = false;
                    }
                    Console.SetCursorPosition(0, 10);
                    var ticks = (dateTime - dt).Ticks;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(new DateTime(ticks).ToString("mm:HH:ss"));
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, 10);
                    dt = dt.AddSeconds(1);
                    Console.SetCursorPosition(0, 10);
                }
                Console.Clear();

                Console.WriteLine("стоп");
                Speed();
                EndTime();

            });

            t.Start();

        }

        static Table table = new Table();
        static int i = 0;
        static Record name = new Record();
        static bool isOn = true;
        static ConsoleKeyInfo key = Console.ReadKey();
        static void Main()
        {
            do
            {
                Console.WriteLine("имя: ");
                name.Name = Console.ReadLine();
                WriteText();
                Console.SetCursorPosition(0, 0);
                key = Console.ReadKey();


            } while (key.Key != ConsoleKey.F1);


        }
        static void EndTime()
        {

            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("имя: " + name.Name);
                        Console.WriteLine("скорость в минуту: " + name.SymbolPerMinute);
                        Console.WriteLine("скорость в секунду: " + name.SymbolPerSecond);

                        Console.WriteLine("---------------------------------------------------------");

                        table.WriteReccord();

                        table.AddItem(name.Name, name.SymbolPerMinute, name.SymbolPerSecond);
                        Console.ForegroundColor = ConsoleColor.White;


                        Console.WriteLine("вернуться в меню - Escape");
                        Console.WriteLine("закончить - F3");
                        break;
                    case ConsoleKey.Escape:
                        Main();
                        break;
                    case ConsoleKey.F3:
                        Environment.Exit(0);
                        break;
                }
            }


        }

        static void WriteBlueText(int dlina)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < dlina; i++)
            {
                Console.Write(text[i]);
            }
            Console.SetCursorPosition(0, 0);
        }
        static void WriteText()
        {

            Console.Clear();

            Console.WriteLine("начать - F2");
            ConsoleKeyInfo key = Console.ReadKey();
            Time();


            while (isOn == true)
            {
                if (key.Key == ConsoleKey.F2)
                {

                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(text);
                    Console.SetCursorPosition(0, 0);

                    while (i < text.Length)
                    {

                        char c = Console.ReadKey(true).KeyChar;
                        if (c == text[i])
                        {
                            i++;
                            WriteBlueText(i);

                        }
                    }


                }
                key = Console.ReadKey();
            }

        }

    }
}