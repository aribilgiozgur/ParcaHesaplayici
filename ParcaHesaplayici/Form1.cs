using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ParcaHesaplayici
{
    public partial class CompPriceCalc : Form
    {
        double overallRealPrice;
        double overallRealLiraPrice; 
        public CompPriceCalc()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int moboPrice = 0;
            int cpuPrice = 0;
            int memoryPrice = 0;
            int gpuPrice = 0;
            int hddPrice = 0;
            int cdRPrice = 0;
            int powSupPrice = 0;
            int casePrice = 0;
            int monitorPrice = 0;

            double dollarCurrency = 0.0;
            double vat = 0.18;

            try
            {
                moboPrice = int.Parse(txtMobo.Text);
                cpuPrice = int.Parse(txtCpu.Text);
                memoryPrice = int.Parse(txtMemory.Text);
                gpuPrice = int.Parse(txtMemory.Text);
                hddPrice = int.Parse(txtHdd.Text);
                cdRPrice = int.Parse(txtCdrom.Text);
                powSupPrice = int.Parse(txtPowSup.Text);
                casePrice = int.Parse(txtCase.Text);
                monitorPrice = int.Parse(txtMonitor.Text);

                dollarCurrency = double.Parse(txtDollar.Text.Replace(",", "."));
                //vat = double.Parse(txtVat.Text.Replace(",", "."));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen sayı alanlarına harf girmeyiniz!");
                return;
            }

            int overallPrice = moboPrice + cpuPrice + memoryPrice + gpuPrice + hddPrice;
            overallPrice += cdRPrice + powSupPrice + casePrice + monitorPrice;

            overallRealPrice = overallPrice + (overallPrice * vat);
            overallRealLiraPrice = overallRealPrice * dollarCurrency;

            lblSumDolar.Text = overallRealPrice.ToString();
            lblSumTurkish.Text = overallRealLiraPrice.ToString();
            txtExport.Enabled = true;




        }

        private void CompPriceCalc_Load(object sender, EventArgs e)
        {
            
            txtExport.Enabled = false;
        }

        private void txtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sve = new SaveFileDialog();
            sve.Filter = "txt File|*.txt";
            sve.Title = "Yer seçiniz";
            sve.ShowDialog();
            if (sve.FileName != "")
            {
               // System.IO.FileStream fs = (System.IO.FileStream)sve.OpenFile();
                using (StreamWriter sw = new StreamWriter(sve.FileName))
                {
                    string firstLine = string.Concat("\n", "Anakart: " + txtMoboName.Text + " - (" + txtMobo.Text + ") " + (int.Parse(txtMobo.Text) + (int.Parse(txtMobo.Text)*0.18)));
                    string secLine = string.Concat("\n", "İşlemci: " + txtCpuName.Text + " -  (" + txtCpu.Text + ") " + (int.Parse(txtCpu.Text) + (int.Parse(txtCpu.Text) * 0.18)));
                    string thirLine = string.Concat("\n", "Bellek: " + txtMemoryName.Text + " - (" + txtMemory.Text + ") " + (int.Parse(txtMemory.Text) + (int.Parse(txtMemory.Text) * 0.18)));
                    string forLine = string.Concat("\n", "Ekran Kartı: " + txtGpuName.Text + " -  (" + txtGpu.Text + ") " + (int.Parse(txtGpu.Text) + (int.Parse(txtGpu.Text) * 0.18))); ;
                    string fifLine = string.Concat("\n", "Sabit Disk: " + txtHddName.Text + " -  (" + txtHdd.Text + ") " + (int.Parse(txtHdd.Text) + (int.Parse(txtHdd.Text) * 0.18)));
                    string sixtLine = string.Concat("\n", "Dvd-Rom: " + txtCdromName.Text + " -  (" + txtCdrom.Text + ") " + (int.Parse(txtCdrom.Text) + (int.Parse(txtCdrom.Text) * 0.18)));
                    string sevenLine = string.Concat("\n", "Güç Kaynağı: " + txtPowSupName.Text + " -  (" + txtPowSup.Text + ") " + (int.Parse(txtPowSup.Text) + (int.Parse(txtPowSup.Text) * 0.18)));
                    string eightLine = string.Concat("\n", "Kasa: " + txtCaseName.Text + " -  (" + txtCase.Text + ") " + (int.Parse(txtCase.Text) + (int.Parse(txtCase.Text) * 0.18)));
                    string nintLine = string.Concat("\n", "Monitor: " + txtMonitorName.Text + " -  (" + txtMonitor.Text + ") " + (int.Parse(txtMonitor.Text) + (int.Parse(txtMonitor.Text) * 0.18)));

                    string sumDollar = string.Concat("\n", "Dolar Toplamı: " + overallRealPrice.ToString());
                    string sumLira = string.Concat("\n", "Lira Toplamı: " + overallRealLiraPrice.ToString());

                    sw.WriteLine(firstLine);
                    sw.WriteLine(secLine);
                    sw.WriteLine(thirLine);
                    sw.WriteLine(forLine);
                    sw.WriteLine(fifLine);
                    sw.WriteLine(sixtLine);
                    sw.WriteLine(sevenLine);
                    sw.WriteLine(eightLine);
                    sw.WriteLine(nintLine);
                    sw.WriteLine("==============================================");
                    sw.WriteLine(sumDollar);
                    sw.WriteLine(sumLira);
                    

                    sw.Flush();
                    sw.Close();

                }
            }
        }
    }
}
