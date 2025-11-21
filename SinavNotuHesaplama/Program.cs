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
            }


        }
    }
    
}