using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;
using CsvHelper.Configuration;

namespace CKTimeKeeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data timeData = new Data();
        public MainWindow()
        {
            
            InitializeComponent();
            abmelden.IsEnabled = false;
        }

        private void anmelde_Click(object sender, RoutedEventArgs e)
        {
            writetoCSV();
            abmelden.IsEnabled = true;
           
            
        }


        private void writetoCSV()
        {
            
            CsvConfiguration configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
               

                Delimiter = ","
            };
            
            if (!abmelden.IsEnabled)
            {
                timeData.date = DateOnly.FromDateTime(DateTime.Now);
               timeData.startTime = TimeOnly.FromDateTime(DateTime.Now); 
                
            }
            else
            {
               timeData.endTime  = TimeOnly.FromDateTime(DateTime.Now);
                timeData.workedOn = textinp.Text;
               
                TimeSpan ts = timeData.endTime - timeData.startTime;
                timeData.WTinMin = ts.TotalMinutes.ToString();
                StreamWriter writer = new StreamWriter("TimeKept.csv");
                CsvWriter csvWriter = new CsvWriter(writer, configPersons);
                List<Data> data = new List<Data>();
                data.Add(timeData);
                csvWriter.WriteRecords(data);
                abmelden.IsEnabled = false;
                writer.Close();
                
                
            }
            

        }

        private void abmelden_Click(object sender, RoutedEventArgs e)
        {
            writetoCSV();
        }
    }
}