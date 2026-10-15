 using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var ekipmanlar = new List<Ekipman>
        {
            new Ekipman("LAB-001", "Kamera"),
            new Ekipman("LAB-002", "Mikrofon")
        };

        var ogrenciler = new List<Ogrenci>
        {
            new Ogrenci("1001", "Ali Yılmaz"),
            new Ogrenci("1002", "Ayşe Demir")
        };

        string? secim = "";
        while (secim != "0")
        {
            Console.WriteLine();
            Console.WriteLine("1 Listele  2 Ödünç ver  3 İade al  0 Çıkış");
            Console.Write("Seçim: ");
            secim = Console.ReadLine();
            if (secim == null)
                break;

            switch (secim)
            {
                case "1":
                    Listele(ekipmanlar);
                    break;
                case "2":
                    OduncVerIslemi(ekipmanlar, ogrenciler);
                    break;
                case "3":
                    IadeAlIslemi(ekipmanlar);
                    break;
                case "0":
                    Console.WriteLine("Çıkış");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim");
                    break;
            }
        }
    }

    static string Oku(string soru)
    {
        Console.Write(soru);
        string? giris = Console.ReadLine();
        if (giris == null)
            return "";
        return giris;
    }

    static void Listele(List<Ekipman> liste)
    {
        foreach (Ekipman e in liste)
        {
            string durum = e.Oduncte
                ? "Ödünçte (" + e.OduncAlanNo + ")" : "Müsait";
            Console.WriteLine($"{e.DemirbasNo} {e.Ad}: {durum}");
        }
    }

    static void OduncVerIslemi(
        List<Ekipman> ekipmanlar, List<Ogrenci> ogrenciler)
    {
        string no = Oku("Demirbaş no: ").Trim().ToUpperInvariant();
        Ekipman? ekipman = EkipmanBul(ekipmanlar, no);
        if (ekipman == null)
        {
            Console.WriteLine("Ekipman bulunamadı.");
            return;
        }

        string ogrNo = Oku("Öğrenci no: ").Trim();
        Ogrenci? ogrenci = OgrenciBul(ogrenciler, ogrNo);
        if (ogrenci == null)
        {
            Console.WriteLine("Öğrenci bulunamadı.");
            return;
        }

        bool sonuc = ekipman.OduncVer(ogrenci.Numara);
        Console.WriteLine(sonuc
            ? "Ödünç verildi." : "İşlem reddedildi.");
    }

    static void IadeAlIslemi(List<Ekipman> ekipmanlar)
    {
        string no = Oku("Demirbaş no: ").Trim().ToUpperInvariant();
        Ekipman? ekipman = EkipmanBul(ekipmanlar, no);
        if (ekipman == null)
        {
            Console.WriteLine("Ekipman bulunamadı.");
            return;
        }

        bool sonuc = ekipman.IadeAl();
        Console.WriteLine(sonuc
            ? "İade alındı." : "İşlem reddedildi.");
    }

    static Ekipman? EkipmanBul(List<Ekipman> liste, string no)
    {
        foreach (Ekipman e in liste)
            if (e.DemirbasNo == no) return e;
        return null;
    }

    static Ogrenci? OgrenciBul(List<Ogrenci> liste, string no)
    {
        foreach (Ogrenci o in liste)
            if (o.Numara == no) return o;
        return null;
    }
}