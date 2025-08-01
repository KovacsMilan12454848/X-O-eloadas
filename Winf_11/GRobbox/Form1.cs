using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winf_XO;

namespace GRobbox
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.Label[,] labels_3x3_E;
        public System.Windows.Forms.Label[,] labels_5x5;
        public System.Windows.Forms.Label[,] labels_5x5_E;
        string P1 = "";
        string P2 = "";
        /* public void Adatment(string nyertes)
         {


             DateTime date = DateTime.Now;
             Adat std = new Adat(P1, P2, nyertes, date);
             sqliranyitas.AddData(std);

         }*/

        // ELTÜNTETI A SZEGÉLYT
        protected override void OnPaint(PaintEventArgs e)
        {
            // A GroupBox szegélyének eltüntetése
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is GroupBox)
                {
                    GroupBox groupBox = (GroupBox)ctrl;
                    groupBox.Paint += (s, pe) =>
                    {
                        // Töröljük a szegély rajzolását és a háttérszínt állítjuk be
                        pe.Graphics.Clear(groupBox.BackColor);
                        TextRenderer.DrawText(pe.Graphics, groupBox.Text, groupBox.Font, new Point(10, 0), groupBox.ForeColor);
                    };
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            labels_3x3_E = new System.Windows.Forms.Label[,]
            {
                { label1, label2, label3 },
                { label4, label5, label6 },
                { label7, label8, label9 }
            };

            labels_5x5_E = new System.Windows.Forms.Label[,]
            {
                    { label10, label11, label12, label13, label14 },
                    { label15, label16, label17, label18, label19 },
                    { label20, label21, label22, label23, label24 },
                    { label25, label26, label27, label28, label29 },
                    { label30, label31, label32, label33, label34 }
            };
        }

        Random rnd = new Random();
        string[,] board_3x3 = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        string[,] board_5x5 = { { "1", "2", "3","4", "5" },
                                { "6", "7", "8","9", "10"},
                                { "11", "12", "13","14", "15" },
                                { "16", "17", "18","19", "20" },
                                { "21", "22", "23","24", "25" }
                              };

        int num = 0;
        bool vanNyertes = false;

        public void visible()
        {
            kezolap.Visible = true;
            EmbxEmb_3x3.Visible = false;
            EmbxEmb_5x5.Visible = false;
        }

        //          CHECK
        //---------------------------------------------------------------------------------------------------------------------------------------

        // Ember x Ember 
        public string Check()
        {
            if (num % 2 == 0)
            {
                num++;

                return "X";
            }
            else
            {
                num++;

                return "O";
            }
            // megnez van e nyertes     
        }

        public void Check_Gep_3x5()
        {
            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                _3x3_gep _3X3_Gep = new _3x3_gep();
                _3X3_Gep.Gep_3x3(board_3x3, labels_3x3_E);
                num++;
            }

            //*---------------------------------------------------------------------------------------

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                _5x5_gep _5X5_Gep = new _5x5_gep();
                _5X5_Gep.Gep_5x5(board_5x5, labels_5x5_E);
                num++;
            }

        }

        //          RESTART
        //---------------------------------------------------------------------------------------------------------------------------------------
        public void resetgame(bool helyzet)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true ||
                harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                foreach (System.Windows.Forms.Label i in labels_3x3_E)
                {
                    i.Text = "";
                }
                num = 0;
                vanNyertes = false;

                board_3x3 = new string[,]
                {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
                };
                restartb1.Visible = false;
                menub1.Visible = false;
                gyozteslab1.Visible = false;


                _3x3_gep _3X3_Gep = new _3x3_gep();
                _3X3_Gep.reset();

                if (gepkezd.Checked && helyzet)
                {
                    Check_Gep_3x5();
                }

            }

        }

        public void menu()
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true ||
                harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                gyozteslab1.Visible = true;
                restartb1.Visible = true;
                menub1.Visible = true;
            }


        }
        //                           5x5
        //===============================================================

        public void resetgame2(bool helyzet)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true
                || ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                foreach (System.Windows.Forms.Label i in labels_5x5_E)
                {
                    i.Text = "";
                }
                num = 0;
                vanNyertes = false;


                board_5x5 = new string[,]{
                            { "1", "2", "3","4", "5" },
                            { "6", "7", "8","9", "10" },
                            { "11", "12", "13","14", "15" },
                            { "16", "17", "18","19", "20" },
                            { "21", "22", "23","24", "25" }
                };
                restartb2.Visible = false;
                menub2.Visible = false;
                gyozteslab2.Visible = false;

                _5x5_gep _5X5_Gep = new _5x5_gep();
                _5X5_Gep.reset();
                if (gepkezd.Checked && helyzet)
                {
                    Check_Gep_3x5();
                }
            }

        }

        public void menu2()
        {
            if (ot_x_ot.Checked == true)
            {
                gyozteslab2.Visible = true;
                restartb2.Visible = true;
                menub2.Visible = true;
            }
        }

        //                    FUTÁSI VIZGÁLAT 3X3
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public void vizsgalat_gep(System.Windows.Forms.Label labels, int etr1, int ert2)
        {
            if (labels.Text == "")
            {
                board_3x3[etr1, ert2] = "O";
                labels.Text = "O";
                num++;
                VanNyertes_3x3();
                if (!vanNyertes)
                {
                    Check_Gep_3x5();
                    VanNyertes_3x3();
                }
            }
        }

        public void vizsgalat_Emb(System.Windows.Forms.Label labels, int etr1, int ert2)
        {
            if (labels.Text == "" && vanNyertes != true)
            {
                labels.Text = Check();
                board_3x3[etr1, ert2] = labels.Text;
                VanNyertes_3x3();
            }
        }

        //                    FUTÁSI VIZGÁLAT 5X5
        //------------------------------------------------------------------------------------------------------------------------------------------------


        public void vizsgalat_5x5_Gep(System.Windows.Forms.Label labels, int etr1, int ert2)
        {
            if (labels.Text == "")
            {
                board_5x5[etr1, ert2] = "O";
                labels.Text = "O";
                num++;
                VanNyertes_5x5();

                if (!vanNyertes)
                {
                    Check_Gep_3x5();
                    VanNyertes_5x5();
                }
            }
        }

        public void vizsgalat_5x5_Emb(System.Windows.Forms.Label labels, int etr1, int ert2)
        {
            if (labels.Text == "" && vanNyertes != true)
            {
                labels.Text = Check();
                board_5x5[etr1, ert2] = labels.Text;
                VanNyertes_5x5();
            }
        }


        // EMBER x EMBER 3x3  / EMBER x GÉP  3x3
        public void VanNyertes_3x3()
        {
            if (num > 3)
            {
                // ---
                for (int i = 0; i <= 2; i++)
                {
                    if ((board_3x3[i, 0] == board_3x3[i, 1] && board_3x3[i, 1] == board_3x3[i, 2]) && (board_3x3[i, 1] == "X" || board_3x3[i, 1] == "O"))
                    {
                        gyozteslab1.Text = $"A Győztes: {board_3x3[i, 0]}";
                        menu();
                        vanNyertes = true;
                        // Adatment(board_3x3[i, 0]);

                    }
                }
                // |
                for (int i = 0; i <= 2; i++)
                {
                    if ((board_3x3[0, i] == board_3x3[1, i] && board_3x3[2, i] == board_3x3[1, i]) && (board_3x3[1, i] == "X" || board_3x3[1, i] == "O"))
                    {
                        gyozteslab1.Text = $"A Győztes: {board_3x3[0, i]}";
                        menu();
                        vanNyertes = true;
                        // Adatment(board_3x3[0, i]);
                    }
                }
                // \, /
                if ((board_3x3[0, 0] == board_3x3[1, 1] && board_3x3[2, 2] == board_3x3[1, 1]) && (board_3x3[1, 1] == "X" || board_3x3[1, 1] == "O"))
                {

                    gyozteslab1.Text = $"A Győztes: {board_3x3[0, 0]}";
                    menu();
                    vanNyertes = true;
                    //Adatment(board_3x3[0, 0]);
                }

                if ((board_3x3[0, 2] == board_3x3[1, 1] && board_3x3[2, 0] == board_3x3[1, 1]) && (board_3x3[1, 1] == "X" || board_3x3[1, 1] == "O"))
                {
                    gyozteslab1.Text = $"A Győztes: {board_3x3[0, 2]}";
                    menu();
                    vanNyertes = true;
                    // Adatment(board_3x3[0, 2]);
                }
                if (num == 9 && !vanNyertes)
                {
                    gyozteslab1.Text = "Döntetlen";

                    //Adatment("Döntetlen");
                    MessageBox.Show("Döntetlen ");
                    vanNyertes = true;
                    menu();
                }

            }

        }

        // EMBER x EMBER 5x5  / EMBER x GÉP  5x5
        public void VanNyertes_5x5()
        {


            if (num > 5)
            {


                // ---
                for (int i = 0; i < 5; i++)
                {
                    if (board_5x5[i, 0] == board_5x5[i, 1] && board_5x5[i, 1] == board_5x5[i, 2] && board_5x5[i, 2] == board_5x5[i, 3] && board_5x5[i, 3] == board_5x5[i, 4])
                    {
                        gyozteslab2.Text = $"A Győztes: {board_5x5[i, 0]}";
                        menu2();
                        vanNyertes = true;
                        //   Adatment(board_5x5[i, 0]);

                    }

                }
                // |
                for (int i = 0; i < 5; i++)
                {
                    if (board_5x5[0, i] == board_5x5[1, i] && board_5x5[1, i] == board_5x5[2, i] && board_5x5[2, i] == board_5x5[3, i] && board_5x5[3, i] == board_5x5[4, i])
                    {
                        gyozteslab2.Text = $"A Győztes: {board_5x5[0, i]}";
                        menu2();
                        vanNyertes = true;
                        //Adatment(board_5x5[0, i]);
                    }

                }
                // \, /
                if (board_5x5[0, 0] == board_5x5[1, 1] && board_5x5[1, 1] == board_5x5[2, 2] && board_5x5[2, 2] == board_5x5[3, 3] && board_5x5[3, 3] == board_5x5[4, 4])
                {
                    gyozteslab2.Text = $"A Győztes: {board_5x5[0, 0]}";
                    menu2();
                    vanNyertes = true;
                    // Adatment(board_5x5[0, 0]);
                }

                if (board_5x5[0, 4] == board_5x5[1, 3] && board_5x5[1, 3] == board_5x5[2, 2] && board_5x5[2, 2] == board_5x5[3, 1] && board_5x5[3, 1] == board_5x5[4, 0])
                {
                    gyozteslab2.Text = $"A Győztes: {board_5x5[0, 4]}";
                    menu2();
                    vanNyertes = true;
                    // Adatment(board_5x5[0, 4]);
                }

                if (num == 25 && vanNyertes == false)
                {
                    gyozteslab2.Text = "Döntetlen";
                    menu2();
                    //Adatment("Döntetlen");

                }

            }

        }
        private void Form1_Load(object sender, EventArgs e) {visible();}
       
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("jelenleg nem működik");    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //STEAR GOMB
            if (textBox1.Text != "" && textBox2.Text != "" && harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                //  EMBER x EMBER /3x3    ------------     EMBER x GÉP /3x3
                kezolap.Visible = false;
                EmbxEmb_3x3.Visible = true;
                Player1_3x3_E.Text = textBox1.Text;
                Player2_3x3_E.Text = textBox2.Text;
                P1 = textBox1.Text;
                P2 = textBox2.Text;


            }
            if (textBox1.Text != "" && textBox2.Text != "" && ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                //  EMBER x EMBER /5x5
                kezolap.Visible = false;
                EmbxEmb_5x5.Visible = true;
                Player1_5x5_E.Text = textBox1.Text;
                Player2_5x5_E.Text = textBox2.Text;
                P1 = textBox1.Text;
                P2 = textBox2.Text;

            }

            if (textBox1.Text != "" && harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                //      EMBER x GÉP /3x3
                Player2_3x3_E.Visible = false;
                O_p1.Visible = false;
                P1 = textBox1.Text;
                P2 = "Gép";
                kezolap.Visible = false;
                EmbxEmb_3x3.Visible = true;
                Player1_3x3_E.Text = textBox1.Text;
                if (textBox2.Text != "") textBox2.Text = "";

                if (gepkezd.Checked == true)
                {
                    Check_Gep_3x5();
                }

            }

            if (textBox1.Text != "" && ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                //      EMBER x GÉP /5x5
                Player2_5x5_E.Visible = false;
                O_P2.Visible = false;
                P1 = textBox1.Text;
                P2 = "Gép";
                kezolap.Visible = false;
                EmbxEmb_5x5.Visible = true;
                Player1_5x5_E.Text = textBox1.Text;
                if (textBox2.Text != "") textBox2.Text = "";
                if (gepkezd.Checked == true)
                {
                    Check_Gep_3x5();
                }

            }

        }



        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //  EMBER
            textBox2.Visible = true;
            O.Visible = true;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // GÉP
            textBox2.Visible = false;
            O.Visible = false;
        }
        private void restartb_Click(object sender, EventArgs e)
        {
            resetgame(true);
        }

        //                     LABEL KEZELŐ RÉSZ
        //---------------------------------------------------------------------------------------------------------------------------------------


        //                  EMB_x_EMB 3x3  ------------   EMBER x GÉP 3x3
        //-------------------------------------------------------------------------------------------------------------------------------------------


        private void menub1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            kezolap.Visible = true;
            EmbxEmb_3x3.Visible = false;
            resetgame(false);

        }




        
        private void label1_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label1, 0, 0);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label1, 0, 0);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label2, 0, 1);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label2, 0, 1);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label3, 0, 2);

            }
            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label3, 0, 2);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label4, 1, 0);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label4, 1, 0);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label5, 1, 1);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label5, 1, 1);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label6, 1, 2);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label6, 1, 2);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label7, 2, 0);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label7, 2, 0);
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label8, 2, 1);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label8, 2, 1);
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (harom_x_harom.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_Emb(label9, 2, 2);
            }

            if (harom_x_harom.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_gep(label9, 2, 2);
            }

        }
       
       
        //                          EMB_x_EMB 5x5
        //-------------------------------------------------------------------------------------------------------------------------------------------

        private void label10_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label10, 0, 0);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label10, 0, 0);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label11, 0, 1);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label11, 0, 1);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label12, 0, 2);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label12, 0, 2);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label13, 0, 3);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label13, 0, 3);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label14, 0, 4);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label14, 0, 4);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label15, 1, 0);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label15, 1, 0);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label16, 1, 1);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label16, 1, 1);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label17, 1, 2);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label17, 1, 2);
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label18, 1, 3);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label18, 1, 3);
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label19, 1, 4);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label19, 1, 4);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label20, 2, 0);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label20, 2, 0);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label21, 2, 1);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label21, 2, 1);
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label22, 2, 2);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label22, 2, 2);
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label23, 2, 3);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label23, 2, 3);
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label24, 2, 4);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label24, 2, 4);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label25, 3, 0);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label25, 3, 0);
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label26, 3, 1);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label26, 3, 1);
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label27, 3, 2);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label27, 3, 2);
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label28, 3, 3);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label28, 3, 3);
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label29, 3, 4);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label29, 3, 4);
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label30, 4, 0);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label30, 4, 0);
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label31, 4, 1);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label31, 4, 1);
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label32, 4, 2);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label32, 4, 2);
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label33, 4, 3);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label33, 4, 3);
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {
            if (ot_x_ot.Checked == true && ember_jat.Checked == true)
            {
                vizsgalat_5x5_Emb(label34, 4, 4);
            }

            if (ot_x_ot.Checked == true && gep_jat.Checked == true)
            {
                vizsgalat_5x5_Gep(label34, 4, 4);
            }
        }
    












        private void restartb2_Click(object sender, EventArgs e)
        {
            resetgame2(true);
        }

        private void menub2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            kezolap.Visible = true;
            EmbxEmb_5x5.Visible = false;
            resetgame2(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kezolap.Visible = true;
            hist.Visible = false;
           
        }

      
    }
}
