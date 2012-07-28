using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
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

        private void setChange(TextBox txt1, TextBox txt2)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt1.Enabled = !txt1.Enabled;
            txt2.Enabled = !txt2.Enabled;
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
                if (chkMobo.Checked)
                {
                    moboPrice = int.Parse(txtMobo.Text);
                }
                if (chkCpu.Checked)
                {
                    cpuPrice = int.Parse(txtCpu.Text);
                }
                if (chkMemory.Checked)
                {
                    memoryPrice = int.Parse(txtMemory.Text);
                }
                if (chkGpu.Checked)
                {
                    gpuPrice = int.Parse(txtGpu.Text);
                }
                if (chkHdd.Checked)
                {
                    hddPrice = int.Parse(txtHdd.Text);
                }
                if (chkCdrom.Checked)
                {
                    cdRPrice = int.Parse(txtCdrom.Text);
                }
                if (chkPowSup.Checked)
                {
                    powSupPrice = int.Parse(txtPowSup.Text);
                }
                if (chkCase.Checked)
                {
                    casePrice = int.Parse(txtCase.Text);
                }
                if (chkMonitor.Checked)
                {
                    monitorPrice = int.Parse(txtMonitor.Text);
                }

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
                    if(chkMobo.Checked){
                    string firstLine = string.Concat("\n", "Anakart: " + txtMoboName.Text + " - (" + txtMobo.Text + ") " + (int.Parse(txtMobo.Text) + (int.Parse(txtMobo.Text)*0.18)));
                    sw.WriteLine(firstLine);
                    }
                    if(chkCpu.Checked){
                    string secLine = string.Concat("\n", "İşlemci: " + txtCpuName.Text + " -  (" + txtCpu.Text + ") " + (int.Parse(txtCpu.Text) + (int.Parse(txtCpu.Text) * 0.18)));
                    sw.WriteLine(secLine);
                    }
                    if(chkMemory.Checked){
                    string thirLine = string.Concat("\n", "Bellek: " + txtMemoryName.Text + " - (" + txtMemory.Text + ") " + (int.Parse(txtMemory.Text) + (int.Parse(txtMemory.Text) * 0.18)));
                    sw.WriteLine(thirLine);
                    }
                    if(chkGpu.Checked){
                    string forLine = string.Concat("\n", "Ekran Kartı: " + txtGpuName.Text + " -  (" + txtGpu.Text + ") " + (int.Parse(txtGpu.Text) + (int.Parse(txtGpu.Text) * 0.18))); ;
                    sw.WriteLine(forLine);
                    }
                    if(chkHdd.Checked){
                    string fifLine = string.Concat("\n", "Sabit Disk: " + txtHddName.Text + " -  (" + txtHdd.Text + ") " + (int.Parse(txtHdd.Text) + (int.Parse(txtHdd.Text) * 0.18)));
                    sw.WriteLine(fifLine);
                    }
                    if(chkCdrom.Checked){
                    string sixtLine = string.Concat("\n", "Dvd-Rom: " + txtCdromName.Text + " -  (" + txtCdrom.Text + ") " + (int.Parse(txtCdrom.Text) + (int.Parse(txtCdrom.Text) * 0.18)));
                    sw.WriteLine(sixtLine);
                    }
                    if(chkPowSup.Checked){
                    string sevenLine = string.Concat("\n", "Güç Kaynağı: " + txtPowSupName.Text + " -  (" + txtPowSup.Text + ") " + (int.Parse(txtPowSup.Text) + (int.Parse(txtPowSup.Text) * 0.18)));
                    sw.WriteLine(sevenLine);
                    }
                    if(chkCase.Checked){
                        string eightLine = string.Concat("\n", "Kasa: " + txtCaseName.Text + " -  (" + txtCase.Text + ") " + (int.Parse(txtCase.Text) + (int.Parse(txtCase.Text) * 0.18)));
                    sw.WriteLine(eightLine);
                    }
                    if(chkMonitor.Checked){
                    string nintLine = string.Concat("\n", "Monitor: " + txtMonitorName.Text + " -  (" + txtMonitor.Text + ") " + (int.Parse(txtMonitor.Text) + (int.Parse(txtMonitor.Text) * 0.18)));
                    sw.WriteLine(nintLine);
                    }
                    string sumDollar = string.Concat("\n", "Dolar Toplamı: " + overallRealPrice.ToString());
                    string sumLira = string.Concat("\n", "Lira Toplamı: " + overallRealLiraPrice.ToString());

                    
                    
                    
                    
                    
                    
                    
                    sw.WriteLine("==============================================");
                    sw.WriteLine(sumDollar);
                    sw.WriteLine(sumLira);
                    

                    sw.Flush();
                    sw.Close();

                }
            }
        }

        private void chkMobo_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtMobo, txtMoboName);
        }

        private void chkCpu_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtCpu, txtCpuName);
        }

        private void chkMemory_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtMemory, txtMemoryName);
        }

        private void chkGpu_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtGpu, txtGpuName);
        }

        private void chkHdd_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtHdd, txtHddName);
        }

        private void chkCdrom_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtCdrom, txtCdromName);
        }

        private void chkPowSup_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtPowSup, txtPowSupName);
        }

        private void chkCase_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtCase, txtCaseName);
        }

        private void chkMonitor_CheckedChanged(object sender, EventArgs e)
        {
            setChange(txtMonitor, txtMonitorName);
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm(); // assume Form2 is the second form.
            dlg.ShowDialog();
        }
    }
}
