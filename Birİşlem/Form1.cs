using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birİşlem
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();

        }

        private void btnRastgele_Click(object sender, EventArgs e)
        {
            txtİslemler.Text = "";
            txtSonuc.Text = "";
            txtPuan.Text = "";

            RandomUret();
        }
        public void RandomUret()
        {

            int[] RandomSayilar = new int[7];

            for (int i = 0; i < 6; i++)
            {
                RandomSayilar[i] = rand.Next(1, 10);
            }
            txt1.Text = RandomSayilar[0].ToString();
            txt2.Text = RandomSayilar[1].ToString();
            txt3.Text = RandomSayilar[2].ToString();
            txt4.Text = RandomSayilar[3].ToString();
            txt5.Text = RandomSayilar[4].ToString();
            int random = rand.Next(10, 100);
            RandomSayilar[5] = (random - random % 10);
            txtİkiBas.Text = RandomSayilar[5].ToString();
            RandomSayilar[6] = rand.Next(100, 999);
            txtHedef.Text = RandomSayilar[6].ToString();
            
        }
        public class Islem
        {

            public String output { get; set; }
            public Boolean success { get; set; }
            public int target { get; set; }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txtİkiBas.Text = "";
            txtHedef.Text = "";

            txt1.Enabled = true;
            txt2.Enabled = true;
            txt3.Enabled = true;
            txt4.Enabled = true;
            txt5.Enabled = true;
            txtİkiBas.Enabled = true;
            txtHedef.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txt1.Enabled = false;
            txt2.Enabled = false;
            txt3.Enabled = false;
            txt4.Enabled = false;
            txt5.Enabled = false;
            txtİkiBas.Enabled = false;
            txtHedef.Enabled = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txtİkiBas.Text = "";
            txtHedef.Text = "";
            txtİslemler.Text = "";
            txtSonuc.Text = "";
            txtPuan.Text = "";
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sayi1 = Convert.ToInt32(txt1.Text.ToString());
            int sayi2 = Convert.ToInt32(txt2.Text.ToString());
            int sayi3 = Convert.ToInt32(txt3.Text.ToString());
            int sayi4 = Convert.ToInt32(txt4.Text.ToString());
            int sayi5 = Convert.ToInt32(txt5.Text.ToString());
            int ikiBas = Convert.ToInt32(txtİkiBas.Text.ToString());
            int hedef = Convert.ToInt32(txtHedef.Text.ToString());

            int[] sayilar = new int[] { sayi1, sayi2, sayi3, sayi4, sayi5, ikiBas, hedef };

            if (Convert.ToInt32(txtİkiBas.Text) % 10 == 0)
            {

            }
            else
            {
                MessageBox.Show("Lütfen 10 veya 10'un katı bir sayi giriniz!!");
            }
            for (int i = 0; i < 5; i++)
            {
                if (Convert.ToInt32(sayilar[i]) >= 10)
                {
                    MessageBox.Show("İlk bes rakam 10'dan küçük olmalıdır !!");
                }
            }
            List<int> list = new List<int>(new[] { sayi1, sayi2, sayi3, sayi4, sayi5, ikiBas });

            foreach (int item in sayilar)
            {
                List<int> runList = new List<int>(list);
                runList.Remove(item);

                Islem islemler = getOperations(runList, item, hedef);

                int skor = hedef - islemler.target;

                if (islemler.success)
                {
                    txtİslemler.Text = item + islemler.output.ToString();
                    txtSonuc.Text = islemler.target.ToString();

                    if (skor == 0)
                    {
                        txtPuan.Text = "10 point";
                    }
                    else if (skor == 1)
                    {
                        txtPuan.Text = "9 point";
                    }
                    else if (skor == 2)
                    {
                        txtPuan.Text = "8 point";
                    }
                    else if (skor == 3)
                    {
                        txtPuan.Text = "7 point";
                    }
                    else if (skor == 4)
                    {
                        txtPuan.Text = "6 point";
                    }
                    else if (skor == 5)
                    {
                        txtPuan.Text = "5 point";
                    }
                    else if (skor == 6)
                    {
                        txtPuan.Text = "4 point";
                    }
                    else if (skor == 7)
                    {
                        txtPuan.Text = "3 point";
                    }
                    else if (skor == 8)
                    {
                        txtPuan.Text = "2 point";
                    }
                    else if (skor == 9)
                    {
                        txtPuan.Text = "1 point";
                    }
                    return;

                }
            }
            Islem getOperations(List<int> numbers, int midNumber, int target)
            {
                Islem midResult = new Islem();

                if (midNumber == target)
                {
                    midResult.success = true;
                    midResult.output = "";
                    midResult.target += midNumber;
                    return midResult;
                }
                foreach (var number in numbers)
                {
                    List<int> newList = new List<int>(numbers);

                    newList.Remove(number);

                    if (newList.Count == 0)
                    {
                        if (midNumber - number == target)
                        {
                            midResult.success = true;
                            midResult.output = "-" + number;
                            midResult.target += (midNumber - number);
                            return midResult;
                        }
                        if (midNumber + number == target)
                        {
                            midResult.success = true;
                            midResult.output = "+" + number;
                            midResult.target += (midNumber + number);
                            return midResult;
                        }
                        if (midNumber * number == target)
                        {
                            midResult.success = true;
                            midResult.output = "*" + number;
                            midResult.target += (midNumber * number);
                            return midResult;
                        }
                        if (midNumber / number == target)
                        {
                            midResult.success = true;
                            midResult.output = "/" + number;
                            midResult.target += (midNumber / number);
                            return midResult;
                        }
                        midResult.success = false;
                        midResult.output = "f" + number;
                        return midResult;
                    }
                    else
                    {
                        midResult = getOperations(newList, midNumber - number, target);
                        if (midResult.success)
                        {
                            midResult.output = "-" + number + midResult.output;
                            return midResult;
                        }
                        midResult = getOperations(newList, midNumber + number, target);
                        if (midResult.success)
                        {
                            midResult.output = "+" + number + midResult.output;
                            return midResult;
                        }
                        midResult = getOperations(newList, midNumber * number, target);
                        if (midResult.success)
                        {
                            midResult.output = "*" + number + midResult.output;
                            return midResult;
                        }
                        midResult = getOperations(newList, midNumber / number, target);
                        if (midResult.success)
                        {
                            midResult.output = "/" + number + midResult.output;
                            return midResult;
                        }
                    }

                }
                return midResult;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt1.Enabled = false;
            txt2.Enabled = false;
            txt3.Enabled = false;
            txt4.Enabled = false;
            txt5.Enabled = false;
            txtİkiBas.Enabled = false;
            txtHedef.Enabled = false;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txtİkiBas.Text = "";
            txtHedef.Text = "";

            txt1.Enabled = true;
            txt2.Enabled = true;
            txt3.Enabled = true;
            txt4.Enabled = true;
            txt5.Enabled = true;
            txtİkiBas.Enabled = true;
            txtHedef.Enabled = true;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            txt1.Enabled = false;
            txt2.Enabled = false;
            txt3.Enabled = false;
            txt4.Enabled = false;
            txt5.Enabled = false;
            txtİkiBas.Enabled = false;
            txtHedef.Enabled = false;
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txtİkiBas.Text = "";
            txtHedef.Text = "";
            txtİslemler.Text = "";
            txtSonuc.Text = "";
            txtPuan.Text = "";
        }
    }
}
