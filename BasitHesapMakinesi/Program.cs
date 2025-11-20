using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== BASİT HESAP MAKİNESİ ===");
            Console.WriteLine("Toplama için: 1");
            Console.WriteLine("Çıkarma için: 2");
            Console.WriteLine("Çarpma için: 3");
            Console.WriteLine("Bölme için: 4");
            Console.WriteLine("Mod alma için: 5");
            Console.WriteLine("Çıkış için: 0");
            Console.Write("Seçiminiz: ");

            if (!int.TryParse(Console.ReadLine(), out int secim) || secim < 0 || secim > 5)
            {
                Console.WriteLine("Hatalı giriş! Lütfen 0-5 arasında bir değer girin.\n");
                continue;
            }

            if (secim == 0)
            {
                Console.WriteLine("Programdan çıkılıyor...");
                break;
            }

            if (secim >= 1 && secim <= 4)
            {
                double sayi1 = GetDouble("1. sayıyı giriniz: ");
                double sayi2 = GetDouble("2. sayıyı giriniz: ");

                if (secim == 4 && sayi2 == 0)
                {
                    Console.WriteLine("Hata! Bir sayı 0'a bölünemez.\n");
                    continue;
                }

                double sonuc = secim switch
                {
                    1 => sayi1 + sayi2,
                    2 => sayi1 - sayi2,
                    3 => sayi1 * sayi2,
                    4 => sayi1 / sayi2,
                    _ => 0
                };

                Console.WriteLine($"Sonuç: {sonuc}\n");
            }
            else if (secim == 5)
            {
                int s1 = GetInt("1. sayıyı giriniz (int): ");
                int s2 = GetInt("2. sayıyı giriniz (int): ");

                if (s2 == 0)
                {
                    Console.WriteLine("Hata! Bir sayı 0'a mod alınamaz.\n");
                    continue;
                }

                Console.WriteLine($"Sonuç: {s1 % s2}\n");
            }
        }
    }

    static double GetDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value)) return value;
            Console.WriteLine("Hatalı giriş! Lütfen sayı girin.\n");
        }
    }

    static int GetInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value)) return value;
            Console.WriteLine("Hatalı giriş! Lütfen tam sayı girin.\n");
        }
    }
}
