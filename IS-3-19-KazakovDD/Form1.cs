using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_3_19_KazakovDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        abstract class Complektation<T>
        {
            T Article;
            int Price;
            int DateCreate;
            public Complektation(int _Price, int _DateCreate, T _Article)
            {
                Price = _Price;
                DateCreate = _DateCreate;
                Article = _Article;
            }
            public string Display()
            {
                return $"Цена: {Price}, Год производства: {DateCreate}, Артикль: {Article}";
            }
        }
        class CP<T> : Complektation<T>
        {
            private int Chastota { set; get; }
            private int NumberCores { set; get; }
            private int NumberPotoks { set; get; }
            public CP(T _Article, int _Price, int _DateCreate, int _Chastota, int _NumberCores, int _NumberPotoks)
                : base(_Price, _DateCreate, _Article)
            {
                Chastota = _Chastota;
                NumberCores = _NumberCores;
                NumberPotoks = _NumberPotoks;
            }
            public new string Display()
            {
                return base.Display() +
               $" Частота процессора: {Chastota}, Количество ядер: {NumberCores}, Количество потоков: {NumberPotoks}";
            }
        }
        class VideoCard<T> : Complektation<T>
        {
            private int TickRateGPU { set; get; }
            private string Creator { set; get; }
            private int MemorySize { set; get; }
            public VideoCard(T _Article, int _Price, int _DataCreate, int _TickRateGPU, string _Creator, int _MemorySize)
                : base(_Price, _DataCreate, _Article)
            {
                TickRateGPU = _TickRateGPU;
                Creator = _Creator;
                MemorySize = _MemorySize;
            }
            public new string Display()
            {
                return base.Display() +
                $" Частота GPU: {TickRateGPU}, Производитель: {Creator}, Объем памяти: {MemorySize}";
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && textBox4.TextLength != 0 && textBox5.TextLength != 0 && textBox9.TextLength != 0)
            {
                try
                {
                    CP<int> cp = new CP<int>(Convert.ToInt32(textBox9.Text),
                        Convert.ToInt32(textBox1.Text),
                        Convert.ToInt32(textBox2.Text),
                        Convert.ToInt32(textBox3.Text),
                        Convert.ToInt32(textBox4.Text),
                        Convert.ToInt32(textBox5.Text));
                    listBox1.Items.Add(cp.Display());
                }
                catch (Exception ex) { MessageBox.Show($"{ex}"); }
            }
            else
            {
                MessageBox.Show("Заполните поля: Цена, Год выпуска, Артикль,\nПроцессор(Hz), Кол-во ядер, Кол-во потоков.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox6.TextLength != 0 && textBox7.TextLength != 0 && textBox8.TextLength != 0 && textBox9.TextLength != 0)
            {
                try
                {
                    VideoCard<string> videocard = new VideoCard<string>(textBox9.Text,
                    Convert.ToInt32(textBox1.Text),
                    Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox6.Text),
                    textBox7.Text,
                    Convert.ToInt32(textBox8.Text));
                    listBox1.Items.Add(videocard.Display());
                }
                catch (Exception ex) { MessageBox.Show($"{ex}"); }
            }
            else
            {
                MessageBox.Show("Заполните поля: Цена, Год выпуска, Артикль,\nЧастота GPU, Производитель, Объем памяти.");
            }
        }
    }
}
