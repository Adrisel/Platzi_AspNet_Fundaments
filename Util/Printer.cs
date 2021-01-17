namespace Stage1.Util
{
    public static class Printer
    {
        public static void PrintLine(int length = 10)
        {
            System.Console.WriteLine("".PadLeft(length, '='));
        }

        public static void PrintTitle(string title)
        {
            int length = title.Length + 4;
            PrintLine(length);
            System.Console.WriteLine($"| {title} |");
            PrintLine(length);
        }

        public static void Beep(int frequency = 1000, int time = 500, int count = 1)
        {
            while(count -- > 0)
            {
                System.Console.Beep(frequency, time);
            }
        }
    }
}