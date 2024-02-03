using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
string? str;

Console.WriteLine("Введите название файла:");

string path = Path.Combine(Directory.GetCurrentDirectory(), (Console.ReadLine()));
var text = File.ReadAllText(path);   
string[] arrstr = text.Split(' ');

while (true)
{

    Console.WriteLine("Выберите действие: \n Найти слова, содержащие максимальное количество цифр: введите 1" +
        "\n Найти самое длинное слово и определить, сколько раз оно встретилось в тексте: введите 2 " +
       "\n Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять»: введите 3" +
       "\n Вывести на экран сначала вопросительные, а затем восклицательные предложения: введите 4" +
       "\n Вывести на экран только предложения, не содержащие запятых: введите 5" +
       "\n Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву: введите 6");
    int a = Convert.ToInt32(Console.ReadLine());
    int count = 0;
    
    //Найти слова, содержащие максимальное количество цифр
    if (a == 1)
    {
        var result = new KeyValuePair<string, int>();
        foreach (string s in arrstr )
        {
            if (s.ToArray().Any(x => char.IsDigit(x)))
            {
                count = s.ToArray().Count(x => char.IsDigit(x));
                if (result.Value < count)
                    result = new KeyValuePair<string, int>(s, count);
            }
        }
        Console.WriteLine("Слова, содержащие максимальное количество цифр: " + result.ToString());
    }

    // Найти самое длинное слово и определить, сколько раз оно встретилось в тексте
    if (a == 2)
    {
        str = null;
        int max_len = 0;
        foreach (string s in arrstr )
        {
            if (max_len < s.Length)
            {
                str = s;
                max_len = s.Length;
            }
        }
        for (int i = 0; arrstr .Length > i; i++)
        {
            if (arrstr [i].Length == max_len)
            {
                count++;
                Console.WriteLine("Найдено по условию поиска длины строки: " + arrstr [i]);
            }
        }
        Console.WriteLine("слово: [" + str + "] содержит максимальное количество символов: " + max_len + "\nНайдено слов с максимальной длиной: " + count);
    }

    //Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять»
    if (a == 3)
    {
        text = text.Replace("1", "один");
        text = text.Replace("2", "два");
        text = text.Replace("3", "три");
        text = text.Replace("4", "четыре");
        text = text.Replace("5", "пять");
        text = text.Replace("6", "шесть");
        text = text.Replace("7", "семь");
        text = text.Replace("8", "восемь");
        text = text.Replace("9", "девять");
        text = text.Replace("0", "ноль");

        Console.WriteLine(text);
    }

    //Вывести на экран сначала вопросительные, а затем восклицательные предложения
    if (a == 4)
    {
        var l = text.Length;
        int p = 0;
        int i = 0;
        var list = new List<string>();
        while (i <= l)
        {
            var c = i == l ? '.' : text[i];
            if (c == '.' || c == '?' || c == '!')
            {
                var s = text.Substring(p, i - p + (i == l ? 0 : 1));
                if (c == '!')
                    list.Add(s);
                if (c == '?')
                    Console.WriteLine(s);
                p = i + 1;

            }
            i++;

        }
        foreach (var s in list)
            Console.WriteLine(s);
    }

    // Вывести на экран только предложения, не содержащие запятых
    if (a == 5)
    {
        var l = text.Length;
        int p = 0;
        int i = 0;
        bool comma = false;
        var notcomma = new List<string>();
        while (i <= l)
        {
            var c = i == l ? '.' : text[i];
            if (c == '.' || c == '?' || c == '!')
            {
                var s = text.Substring(p, i - p + (i == l ? 0 : 1));
                if (comma == false)
                    notcomma.Add(s);
                comma = false;
                p = i + 1;
            }
            comma |= c == ',';
            i++;
        }
        foreach (var s in notcomma)
            Console.WriteLine(s);
    }

    //Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
    if (a == 6)
    {
        for (int i = 0; i < arrstr .Length; i++)
        {
            if (arrstr [i][0] == arrstr [i][arrstr [i].Length - 1])
            {
                Console.WriteLine(arrstr [i]);
            }
        }
    }



    Console.WriteLine("Введите e, чтобы покинуть программу");
    string t = Console.ReadLine();
    switch (t)
    {
        case "e":
            Console.WriteLine("Выход");
            return;

        default:
            Console.WriteLine("Продолжаем");
            break;
    }
}
