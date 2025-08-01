using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRobbox
{
    internal class _3x3_gep
    {
        public static HashSet<string> CSAK_X = new HashSet<string>();
        public static HashSet<string> CSAK_O = new HashSet<string>();

        // a szótárat megtudtam volna oldani sima ciklusokkal de igy átláthatóbb volt

        public static Dictionary<string, int> adat = new Dictionary<string, int>()
                {
                    {"00",10},
                    {"01",10},
                    {"02",10},

                    {"10",10},
                    {"11",10},
                    {"12",10},

                    {"20",10},
                    {"21",10},
                    {"22",10}
        };
        
        public static List<string> kulcsok = new List<string>(adat.Keys);
        public static List<int> X_vizsgalat = new List<int>();
        public static List<int> O_vizsgalat = new List<int>();
        public static List<string> vizsgalandok = new List<string>();

        public void gepnyer_vizsgalat(List<string> vizs, Dictionary<string, int> szotar)
        {                
            // kiválasztja az X/O a pontozáshoz
            foreach (string s in vizs)
            {
                if (CSAK_X.Contains(s)) X_vizsgalat.Add(10);

                if (CSAK_O.Contains(s)) O_vizsgalat.Add(10);
            }
        }
        public void GEPNyertes3x3()
        {
            // a nyerési lehetőségekben elemzese

            // --
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    var forma = i.ToString() + j.ToString();
                    vizsgalandok.Add(forma);
                }
                gepnyer_vizsgalat(vizsgalandok, adat);
                pontozas();
            }

            // |
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    var forma = j.ToString() + i.ToString();
                    vizsgalandok.Add(forma);
                }
                gepnyer_vizsgalat(vizsgalandok, adat);
                pontozas();
            }

            List<List<string>> lepesvizsgalat = new List<List<string>> {
                new List<string> { "00", "11", "22" },
                new List<string> { "02", "11", "20" }
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
            // a lista értékei alapján pontozás

            var ossz = X_vizsgalat.Sum();
            var osszO = O_vizsgalat.Sum();

            if (ossz == 0 && osszO == 0)
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 5;
                }
            }
            else if (ossz == 10 || osszO == 10)
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 10;
                    
                }
            }
            else if ((ossz == 20 && osszO == 0) || (osszO == 20 && ossz == 0))
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 30;
                    
                }
            }
             if (ossz == 20 )
            {
                foreach (string v in vizsgalandok)
                {
                    adat[v] += 10;
                   
                }
            }

            X_vizsgalat.Clear();
            O_vizsgalat.Clear();
            vizsgalandok.Clear();

        }

        public void Gep_3x3(string[,] board_3x3, System.Windows.Forms.Label[,] labels_3x3_E)
        {
            //  kiosza az alap pontokat és kiválasztja az X/O kat
                foreach (var i in kulcsok)
                {
                    int i1 = int.Parse(i[0].ToString());
                    int i2 = int.Parse(i[1].ToString());
                    if (board_3x3[i1, i2] == "O")
                    {
                        adat[i] = -200;
                        CSAK_O.Add(i);
                    }
                    if (board_3x3[i1, i2] == "X")
                    {
                        adat[i] = -200;
                        CSAK_X.Add(i);
                    }

                }

                // magvizsgáljuk a gép nyerési lehetőségeit
                GEPNyertes3x3();

            // kiiratás
                    var ad = "";
                    foreach (var k in adat)
                    {
                        ad += k.Key + "; " + (k.Value.ToString()) + "\n";
                    }
                    MessageBox.Show(ad);

            // a legopcionálisabb lépés kiválasztása

                var max = adat.Values.Max();

                foreach (var k in adat)
                {
                    if (k.Value == max)
                    {
                        var sor = int.Parse(k.Key[0].ToString());
                        var oszlop = int.Parse(k.Key[1].ToString());
                        
                        board_3x3[sor, oszlop] = "X";
                        labels_3x3_E[sor, oszlop].Text = "X";
                      
                        break;
                    }
                }


            //  a pontok alaphelyzetbe álitása. 
            // azért hogy a pontkulombség ne zavarjon be az ujravizsgálatkor
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
