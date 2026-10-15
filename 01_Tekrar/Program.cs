 using System;

class Program
{
    static void Main()
    {
        bool oduncte = false;

        Console.Write("Kaç gün? ");
        string? giris = Console.ReadLine();

        if (!int.TryParse(giris, out int gun)
            || gun < 1 || gun > 7)
        {
            Console.WriteLine("1-7 arası sayı girin.");
            return;
        }

        if (OduncUygunMu(oduncte, gun))
        {
            Console.WriteLine("Ödünç verilebilir.");
        }
        else
        {
            Console.WriteLine("Talep uygun değil.");
        }
    }

    static bool OduncUygunMu(bool oduncte, int gun)
    {
        return !oduncte
            && gun >= 1 && gun <= 7;
    }
}