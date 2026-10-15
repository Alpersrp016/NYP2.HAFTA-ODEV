 using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numaralar = new List<string>
        { "LAB-001", "LAB-002", "LAB-003" };

        Console.WriteLine(NumaraVarMi(numaralar, "LAB-001")); // ilk eleman
        Console.WriteLine(NumaraVarMi(numaralar, "LAB-003")); // son eleman
        Console.WriteLine(NumaraVarMi(numaralar, "LAB-999")); // olmayan numara

        var bos = new List<string>();
        Console.WriteLine(NumaraVarMi(bos, "LAB-001"));       // boş liste
    }

    static bool NumaraVarMi(
        List<string> liste, string aranan)
    {
        foreach (string numara in liste)
        {
            if (numara == aranan)
                return true;
        }
        return false;
    }
}