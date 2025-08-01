using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRobbox
{
    internal class _5x5_gep
    {  
        public static HashSet<string> CSAK_X = new HashSet<string>();
        public static HashSet<string> CSAK_O = new HashSet<string>();

        public static Dictionary<string, int> adat = new Dictionary<string, int>()
                {
                    {"00",10},
                    {"01",10},
                    {"02",10},
                    {"03",10},
                    {"04",10},

                    {"10",10},
                    {"11",10},
                    {"12",10},
                    {"13",10},
                    {"14",10},

                    {"20",10},
                    {"21",10},
                    {"22",20},
                    {"23",10},
                    {"24",10},

                    {"30",10},
                    {"31",10},
                    {"32",10},
                    {"33",10},
                    {"34",10},

                    {"40",10},
                    {"41",10},
                    {"42",10},
                    {"43",10},
                    {"44",10},

        };

        public static List<string> kulcsok = new List<string>(adat.Keys);
        public static List<int> X_vizsgalat = new List<int>();
        public static List<int> O_vizsgalat = new List<int>();
        public static List<string> vizsgalandok = new List<string>();

        public void gepnyer_vizsgalat(List<string> vizs, Dictionary<string, int> szotar)
        {
            foreach (string s in vizs)
            {
                if (CSAK_X.Contains(s)) X_vizsgalat.Add(10);

                if (CSAK_O.Contains(s)) O_vizsgalat.Add(10);
            }
        }
        public void GEPNyertes5x5()
        {
            // --
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    var forma = i.ToString() + j.ToString();
                    vizsgalandok.Add(forma);
                }
                gepnyer_vizsgalat(vizsgalandok, adat);
                pontozas();
            }

            // |
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    var forma = j.ToString() + i.ToString();
                    vizsgalandok.Add(forma);
                }
                gepnyer_vizsgalat(vizsgalandok, adat);
                pontozas();
            }
          
            List<List<string>> lepesvizsgalat = new List<List<string>> {
                new List<string> { "00", "11", "22", "33", "44" },
                new List<string> { "04", "13", "22", "31", "40" }
            };

            //   / \
            foreach (var lepes in lepesvizsgalat)
            {
                foreach (var lep in lepes)
                {

                    vizsgalandok.Add(lep);
                }
                gepnyer_vizsgalat(vizsgalandok, adat);
                pontozas();
            }
        }

        public void pontozas()
        {
            var ossz = X_vizsgalat.Sum();
            var osszO = O_vizsgalat.Sum();

            if (ossz == 0 && osszO == 0)
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 5;
                }
            }
            else if ((ossz == 10 || ossz == 20) || (osszO == 10 || osszO == 20))
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 10;
                }
            }
            else if ((ossz >= 20 && (osszO == 10 || osszO == 0)) ||
                     (osszO >= 20 && (ossz == 10 || ossz == 0)))
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 30;
                }
            }

            X_vizsgalat.Clear();
            O_vizsgalat.Clear();
            vizsgalandok.Clear();

        }

        public void Gep_5x5(string[,] board_5x5, System.Windows.Forms.Label[,] labels_5x5_E)
        {

            foreach (var i in kulcsok)
            {
                int i1 = int.Parse(i[0].ToString());
                int i2 = int.Parse(i[1].ToString());
                if (board_5x5[i1, i2] == "O")
                {
                    adat[i] = -200;
                    CSAK_O.Add(i);
                }
                if (board_5x5[i1, i2] == "X")
                {
                    adat[i] = -200;
                    CSAK_X.Add(i);
                }

            }
            GEPNyertes5x5();

                    var ad = "";
                    foreach (var k in adat)
                    {
                        ad += k.Key + "; " + (k.Value.ToString()) + "\n";
                    }
                    MessageBox.Show(ad);

            var max = adat.Values.Max();
            foreach (var k in adat)
            {
                if (k.Value == max)
                {
                    var sor = int.Parse(k.Key[0].ToString());
                    var oszlop = int.Parse(k.Key[1].ToString());

                    board_5x5[sor, oszlop] = "X";
                    labels_5x5_E[sor, oszlop].Text = "X";

                    break;
                }
            }

            foreach (var i in kulcsok)
            {
                adat[i] = 10;
            }
            reset();
        }
        public void reset()
        {
            CSAK_X.Clear();
            CSAK_O.Clear();
            foreach (var i in kulcsok)
            {
                adat[i] = 10;
            }
        }
    }
}
