class Program
{
    static void Main()
    {
        while(true)
        {
            Console.WriteLine("Çıkış için E");
            Console.WriteLine("Not hesaplamak için H");
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz >>");

            string secim = Console.ReadLine().Trim().ToUpper();
            if (secim ! = E && secim = ! H)
            {
                Console.WriteLine("Geçersiz işlem \n");
                continue;
            } 
            if (secim == E)
            {
                Console.WriteLine("Programdan çıkılıyor.. \n <<Exit>>");
                break;
            }
            Console.WriteLine("Lütfen dersin adını giriniz >> ");
            string dersinAdi = Console.ReadLine();
            int adet = GetInt("Lütfen girmek istediğiniz not adedini giriniz >> ",min1);
            double totalPercentage = 0;
            double weightedSum = 0;
            for (int i =1; i<= adet; i++)
            {
                double notDegeri= GetDoubleLimited($"{i}.notunuzun yüzdesini giriniz >>",0,100);

                double yuzde;
                while(true)
                {
                    yuzde = GetDoubleLimited($"{i}.notunuzun yüzdesini giriniz >>",0,100);

                    if (totalPercentage + yuzde > 100)
                    {
                        Console.WriteLine($"Yuzdeler toplamı 100'ü geçemez! Kalan yüzde hakkınızı {100-totalPercentage}'dir.");
                        continue;
                    } 
                    break;

                }
                totalPercentage += yuzde;
                weightedSum += (notDegeri * yuzde / 100.0);
            }

            if (totalPercentage != 100)
            {
                Console.WriteLine($"Yüzdeler toplamı 100 olmalıdır! Şu anda {totalPercentage}. İşlem iptal edildi. \n");
                continue;
            }

            string harf = HesaplaHarfNotu(weightedSum);
            string durum = (harf == "FF") ? "KALDI" :"GEÇTİ";

            Console.WriteLine($"Sonuç: {dersAdi} ders not ortalamanız{weightedSum:F1} Harf notunuz {harf} Durumunuz {durum}\n");

        }
        static int GetInt(string msg,int min = int.MinValue,int max = int.MaxValue)
        {
            int value;
            while(true)
            {
                Console.Write(msg);
                if (!int.TryParsel(Console.ReadLine(),out value))
                {
                    Console.WriteLine("Lütfen sayı değerini giriniz: ");
                    continue;
                }
                return value;
            }
        }
        static double GetDoubleLimited(string msg,double min,double max)
        {
            double value;
            while(true)
            {
                Console.Write(msg);
                if (!double.TryParse(Console.ReadLine(),out value))
                {
                    Console.WriteLine("Lütfen sayı değeri giriniz!");
                    continue;
                }
                if (value <min || value >max )
                {
                    Console.WriteLine($"Girilen değer {min} ile {max} arasında olmalıdır!");
                    continue;
                }
                return value;
            }

        }
        static string HesaplaHarfNotu(double not)
        {
            if (not >= 90) return "AA";
            if (not >= 85) return "BA";
            if (not >= 80) return "BB";
            if (not >= 75) return "CB";
            if (not >= 65) return "CC";
            if (not >= 55) return "DC";
            if (not >= 50) return "DD";
            return "FF";
        }
    }
    
}