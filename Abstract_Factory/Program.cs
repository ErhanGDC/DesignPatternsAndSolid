using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            SoyutArabaFabrikasi fabrika1 = new MercedesFabrikasi();
            FabrikaOtomasyon fo1 = new FabrikaOtomasyon(fabrika1);
            fo1.LastikTak();
            fo1.KasaTak();

            SoyutArabaFabrikasi fabrika2 = new FordFabrikasi();
            FabrikaOtomasyon fo2 = new FabrikaOtomasyon(fabrika2);
            fo2.LastikTak();
            fo2.KasaTak();

            Console.ReadLine();
        }
    }
    abstract class SoyutArabaFabrikasi
    {
        abstract public SoyutArabaKasasi KasaUret();
        abstract public SoyutArabaLastigi LastikUret();
    }

    class MercedesFabrikasi : SoyutArabaFabrikasi
    {
        public override SoyutArabaKasasi KasaUret()
        {
            return new MercedesE200();
        }

        public override SoyutArabaLastigi LastikUret()
        {
            return new MercedesLastik();
        }
    }

    class FordFabrikasi : SoyutArabaFabrikasi
    {
        public override SoyutArabaKasasi KasaUret()
        {
            return new FordFocus();
        }

        public override SoyutArabaLastigi LastikUret()
        {
            return new FordLastik();
        }
    }

    abstract class SoyutArabaKasasi
    {
        abstract public void LastikTak(SoyutArabaLastigi a);
        abstract public void KasaTak(SoyutArabaKasasi b);
    }

    abstract class SoyutArabaLastigi
    {
    }

    class MercedesE200 : SoyutArabaKasasi
    {
        public override void LastikTak(SoyutArabaLastigi lastik)
        {
            Console.WriteLine(lastik + " lastikli MercedesE200");
        }
        public override void KasaTak(SoyutArabaKasasi b)
        {
            Console.WriteLine(b + " Kasali Mercedes");
        }
    }


    class FordFocus : SoyutArabaKasasi
    {
        public override void LastikTak(SoyutArabaLastigi lastik)
        {
            Console.WriteLine(lastik + " lastikli FordFocus");
        }
        public override void KasaTak(SoyutArabaKasasi b)
        {
            Console.WriteLine(b + " Kasali FordFocus");
        }

    }


    class MercedesLastik : SoyutArabaLastigi
    {

    }

    class FordLastik : SoyutArabaLastigi
    {

    }

    class FabrikaOtomasyon
    {
        private SoyutArabaKasasi ArabaKasasi;
        private SoyutArabaLastigi ArabaLastigi;

        public FabrikaOtomasyon(SoyutArabaFabrikasi fabrika)
        {
            ArabaKasasi = fabrika.KasaUret();
            ArabaLastigi = fabrika.LastikUret();
        }

        public void LastikTak()
        {
            ArabaKasasi.LastikTak(ArabaLastigi);
        }
        public void KasaTak()
        {
            ArabaKasasi.KasaTak(ArabaKasasi);
        }
    }
}
