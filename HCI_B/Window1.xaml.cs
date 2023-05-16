using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI_B
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            /*     OpenFileDialog ofd = new OpenFileDialog();
                 ofd.ShowDialog();
                 ofd.FileName = "@Score.txt";
            */
            string myfile = @"score.txt";
            Igrac i = new Igrac();
            String[] Podaci;

            DataTable dt = new DataTable();
            dt.Columns.Add("Player name",typeof(String));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Level", typeof(int));
            dt.Columns.Add("Score", typeof(int));


            using (StreamReader sr= new StreamReader(myfile))
            {
                while (!sr.EndOfStream)
                {
                    Podaci = sr.ReadLine().Split(",");
                    i.Name = Podaci[0];
                    i.date = Convert.ToDateTime(Podaci[1]);
                   // i.nivo = Convert.ToInt32(Podaci[2]);
                    i.score = Convert.ToInt32(Podaci[3]);

                    dt.Rows.Add(Podaci);

                }

                DataView dv = new DataView(dt);
                grid.ItemsSource = dv;



            }




        }
    }
}
