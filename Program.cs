using System.Text;

namespace _2025_09_16_hf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> rendszam = new List<string>();
            List<string> tipus = new List<string>();
            List<string> szin = new List<string>();
            List<int> ev = new List<int>();
            List<double> ar = new List<double>();
            List<string> tulaj = new List<string>();

            FileStream fs = new FileStream("Autok.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string sor = "";

            string[] darabok;
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                darabok = sor.Split("\t");
                rendszam.Add(darabok[0]);
                tipus.Add(darabok[1]);
                szin.Add(darabok[2]);
                ev.Add(Convert.ToInt32(darabok[3]));
                ar.Add(Convert.ToDouble(darabok[4]));
                tulaj.Add(darabok[5]);

            }
            sr.Close();
            fs.Close();


            int adatokszama = rendszam.Count();
            Console.WriteLine("Ennyi autó adatát tartalmazza a fájl: "+adatokszama);

            //3. nem tudtam



            double maxAr = ar.Max();
            int index = ar.IndexOf(maxAr);

            Console.WriteLine("\nA legdrágább autó adatai:");
            Console.WriteLine($"Rendszám: {rendszam[index]}");
            Console.WriteLine($"Típus: {tipus[index]}");
            Console.WriteLine($"Szín: {szin[index]}");
            Console.WriteLine($"Évjárat: {ev[index]}");
            Console.WriteLine($"Ár: {ar[index]:N0} Ft");
            Console.WriteLine($"Tulajdonos: {tulaj[index]}");

            using (StreamWriter sw = new StreamWriter("AutokKivonat.txt"))
            {
                for (int i = 0; i < tipus.Count; i++)
                {
                    sw.WriteLine($"{tipus[i]}\t{szin[i]}\t{tulaj[i]}");
                }
            }

        }
    }
}
