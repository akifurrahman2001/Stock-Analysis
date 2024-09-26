// Import required namespaces
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Define the namespace for the current project
namespace StockAnalyzerProject2
{
    // Define the Form1 class that inherits from the Form class
    public partial class Form1 : Form
    {
        // Constructor for the Form1 class
        public Form1()
        {
            // Initialize form components and populate the combobox with filenames
            InitializeComponent();
            String[] filename = Directory.GetFiles(@"Stock Data");
            foreach (string file in filename)
            {
                comboBox1.Items.Add(file);
            }
        }

        // Method to get candlestick data from a CSV file
        private List<CandleStickData> GetCandleStickData(string companyName)
        {
            List<CandleStickData> data;

            using (var reader = new StreamReader(companyName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                data = csv.GetRecords<CandleStickData>().ToList();
            }

            return data;
        }




        // Method to get the period of the selected CSV file
        //used to represent the period for "Day", "Week", and "Month" in the GetPeriod() method of your Form1.cs class.
        //These values are then passed as the period parameter in the DisplayCandlestickChart() method of your Form2.cs class.
        private int GetPeriod()
        {
            string selectedText = comboBox1.SelectedItem.ToString().Trim();

            if (selectedText.Contains("Day"))
                return 1;
            else if (selectedText.Contains("Week"))
                return 4;
            else if (selectedText.Contains("Month"))
                return 16;
            else
                return 4;
        }





        // Method to get the period name of the selected CSV file
        private string GetPeriodName()
        {
            string selectedText = comboBox1.SelectedItem.ToString().Trim();

            if (selectedText.Contains("Day"))
                return "Daily";
            else if (selectedText.Contains("Week"))
                return "Weekly";
            else if (selectedText.Contains("Month"))
                return "Monthly";
            else
                return "";
        }

        // Event handler for the button1 click event
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a file is selected in the combobox
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the dropdown list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            // Get the company name from the selected item in the combobox
            string companyName = comboBox1.SelectedItem.ToString();

            // Get the candlestick data
            List<CandleStickData> data = GetCandleStickData(companyName);
            DateTime startDateUser = dateTimePicker1.Value.Date;
            DateTime endDateUser = dateTimePicker2.Value.Date;
            int startDateIndex = 0;
            int endDateIndex = data.Count - 1;



            if (startDateUser > endDateUser || startDateUser < data.First().Date || endDateUser > data.Last().Date)
            {
                MessageBox.Show(" No data available for the specified date. Please enter a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Find the start and end date indices in the data
            for (int i = 0; i <= data.Count - 1; i++)
            {
                if (data[i].Date.Date >= startDateUser)
                {
                    startDateIndex = i;
                    break;
                }
            }

            for (int i = 0; i <= data.Count - 1; i++)
            {
                if (data[i].Date.Date > endDateUser)
                {
                    endDateIndex = i;
                    break;
                }
            }


            // Create a new instance of the CandlestickChartForm and display the chart
            Form2 chartForm = new Form2();
            chartForm.DisplayCandlestickChart(data.GetRange(startDateIndex, endDateIndex - startDateIndex), GetPeriod(), GetPeriodName());
            Console.WriteLine(comboBox1.SelectedItem.ToString());
            Console.WriteLine(comboBox1.SelectedItem.ToString().Contains("Day"));

            chartForm.Show();
        }
    }
}
