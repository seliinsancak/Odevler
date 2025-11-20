using System;
namespace AlanCevreHesaplayici
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hesaplama için: 1");
                Console.WriteLine("Çıkış için: 0");
                Console.Write("Lütfen seçim yapınız: ");

                string secim = Console.ReadLine() ?? "";

                if (secim == "0")
                {
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                }
                else if (secim != "1")
                {
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin. \n");
                    continue;
                }

                Console.WriteLine("\nAlan hesaplama için: 1");
                Console.WriteLine("Çevre hesaplama için: 2");
                Console.Write("Lütfen seçim yapınız: ");

                int islem = ReadIntInRange(1, 2);

                Console.WriteLine("\nŞekil seçiniz: ");
                Console.WriteLine("1 - Üçgen");
                Console.WriteLine("2 - Kare");
                Console.WriteLine("3 - Dikdörtgen");
                Console.WriteLine("4 - Daire");
                Console.Write("Seçiminiz: ");

                int sekil = ReadIntInRange(1, 4);

                switch (sekil)
                {
                    case 1:
                        HesaplaUcgen(islem);
                        break;
                    case 2:
                        HesaplaKare(islem);
                        break;
                    case 3:
                        HesaplaDikdortgen(islem);
                        break;
                    case 4:
                        HesaplaDaire(islem);
                        break;
                }

                Console.WriteLine();
            }
        }

        // Input fonksiyonları
        static double ReadDouble()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double value))
                    return value;

                Console.Write("Lütfen bir sayı giriniz: ");
            }
        }

        static int ReadIntInRange(int min, int max)
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                    return value;

                Console.Write($"Lütfen {min}-{max} arası bir değer giriniz: ");
            }
        }

        // Üçgen
        static void HesaplaUcgen(int islem)
        {
            Console.WriteLine("\nÜçgen tipi seçiniz: ");
            Console.WriteLine("1 - Eşkenar");
            Console.WriteLine("2 - İkizkenar");
            Console.WriteLine("3 - Çeşitkenar");
            Console.Write("Seçiminiz: ");

            int tip = ReadIntInRange(1, 3);

            if (islem == 1)
            {
                // Alan
                if (tip == 1)
                {
                    Console.Write("Kenar uzunluğu: ");
                    double kenar = ReadDouble();
                    double alan = (Math.Sqrt(3) / 4) * kenar * kenar;
                    Console.WriteLine("Alan = " + alan);
                }
                else
                {
                    Console.Write("Taban uzunluğu: ");
                    double taban = ReadDouble();
                    Console.Write("Yükseklik: ");
                    double h = ReadDouble();
                    double alan = (taban * h) / 2;
                    Console.WriteLine("Alan = " + alan);
                }
            }
            else
            {
                // Çevre
                if (tip == 1)
                {
                    Console.Write("Kenar uzunluğu: ");
                    double kenar = ReadDouble();
                    Console.WriteLine("Çevre = " + (3 * kenar));
                }
                else if (tip == 2)
                {
                    Console.Write("İki eş kenar: ");
                    double a = ReadDouble();
                    Console.Write("Taban: ");
                    double b = ReadDouble();
                    Console.WriteLine("Çevre = " + (2 * a + b));
                }
                else
                {
                    Console.Write("1. kenar: ");
                    double a = ReadDouble();
                    Console.Write("2. kenar: ");
                    double b = ReadDouble();
                    Console.Write("3. kenar: ");
                    double c = ReadDouble();
                    Console.WriteLine("Çevre = " + (a + b + c));
                }
            }
        }

        // Kare
        static void HesaplaKare(int islem)
        {
            Console.Write("\nKenar uzunluğu: ");
            double kenar = ReadDouble();

            if (islem == 1)
                Console.WriteLine("Alan = " + (kenar * kenar));
            else
                Console.WriteLine("Çevre = " + (4 * kenar));
        }

        // Dikdörtgen
        static void HesaplaDikdortgen(int islem)
        {
            Console.Write("\nKısa kenar: ");
            double kisa = ReadDouble();
            Console.Write("Uzun kenar: ");
            double uzun = ReadDouble();

            if (islem == 1)
                Console.WriteLine("Alan = " + (kisa * uzun));
            else
                Console.WriteLine("Çevre = " + (2 * (kisa + uzun)));
        }

        // Daire
        static void HesaplaDaire(int islem)
        {
            Console.Write("\nYarıçap: ");
            double r = ReadDouble();

            if (islem == 1)
                Console.WriteLine("Alan = " + (Math.PI * r * r));
            else
                Console.WriteLine("Çevre = " + (2 * Math.PI * r));
        }
    }
}

