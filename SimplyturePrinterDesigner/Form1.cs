using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using StarMicronics.StarIO;

namespace SimplyturePrinterDesigner
{
    public partial class Form1 : Form
    {
        private bool monitoring = false;
        //  Use this to identify if the printer is online or not
        private Boolean onlineStatus = false;
        //  This is what we will be using to communicate with the printer through StarIO
        private IPort sPort;
        //  Status can be retrived with this variable, goto 
        private StarPrinterStatus sPrinterStatus;
        public List<string> PrinterCommands;
        public List<string> ReceiptData;
        public string PrinterPortname = ConfigurationManager.AppSettings["StartIOPrinterPortIP"];
        public string Printersetting = ConfigurationManager.AppSettings["StartIOPrinterPortSetting"];
        public Form1()
        {
            InitializeComponent();
            PrinterCommands = new List<string>();
            ReceiptData = new List<string>();




            try
            {

                //LogTextBox.Text += "try to start";
                // listBox1.Items.Add("Trying to start Monitoring Status");
                this.sPort = Factory.I.GetPort(PrinterPortname, Printersetting, 10000);
                this.sPrinterStatus = this.sPort.GetParsedStatus();
                onlineStatus = true;
                
            }
            catch (PortException ex)
            {
                //If we could not open the port, lets show the error.
                MessageBox.Show("Error Opening Port: " + ex.Message, "PORT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Factory.I.ReleasePort(this.sPort);
                onlineStatus = false;
                this.sPrinterStatus = null;
                //LogTextBox.Text += "port error";
                //listBox1.Items.Add("Port Error");
                //return;
            }



        }
        public void GetPrinterStatus()
        {
            try
            {
                //this.sPrinterStatus = this.sPort.GetParsedStatus();
                //Status = NULL
                if (onlineStatus == false)
                {
                    Factory.I.ReleasePort(this.sPort);
                    this.monitoring = false;
                    return;
                }
                else
                {
                    this.sPrinterStatus = this.sPort.GetParsedStatus();
                    if (this.sPrinterStatus.ReceiptPaperEmpty == true) //offline == true
                    {
                        tbStatus.BackColor = Color.Red;

                        return;
                    }
                    else if (this.sPrinterStatus.ReceiptPaperNearEmptyInner == true)
                    {

                        tbStatus.BackColor = Color.Yellow;
                        LogMessage("Printer is almost empty");
                        return;
                    }
                    else
                    {
                        tbStatus.BackColor = Color.Green;
                        LogMessage("Printer is online");
                        return;
                    }


                }



            }
            //If there was a problem getting status, lets catch the port error
            catch (PortException err)
            {
            }

            //If during monitoring the printer port goes null, lets reconnect to the printer.
            if (this.sPort == null)
            {
                try
                {
                    this.sPort = Factory.I.GetPort(PrinterPortname, Printersetting, 10000);
                }
                catch
                {
                    
                    this.sPort = null;
                }
            }
            else
            {
                return;
            }
            

        }
        public void PrintFromStarIO(string prnData)
        {
            //Set the status to offline because this is a new attempt to print
            onlineStatus = false;

            //TRY -> Use the textboxes to check if the port info given will connect to the printer.
            try
            {
                //Very important to only try opening the port in a Try, Catch incase the port is not working
                this.sPort = Factory.I.GetPort(PrinterPortname, Printersetting, 10000);

                //GetOnlineStatus() will return a boolean to let us know if the printer was reachable.
                this.onlineStatus = sPort.GetOnlineStatus();
            }

            //CATCH -> If the port information is bad, catch the failure.
            catch (PortException err)
            {
                //label1.Text = "Error Message: " + err.Message + "\n\n\nStacktrace: " + err.StackTrace;
                onlineStatus = false;
                if (this.sPort != null)
                {
                    Factory.I.ReleasePort(this.sPort);


                    //label1.Text = "Port Error";
                    tbStatus.BackColor = Color.Red;
                    return; //exit this entire function
                }
            }

            //If it is offline, dont setup receipt or try to write to the port.
            if (onlineStatus == false)
            {
                //label1.Text = "offline";
                tbStatus.BackColor = Color.Red;
                Factory.I.ReleasePort(sPort);
            }
            //Else statement means it is ONLINE, lets start the printjob
            else
            {
                //label1.Text = "online";
                tbStatus.BackColor = Color.Green;

                Encoding targetCodePage; // (1)
                byte[] encodedBytes; // (2)
                int codePage = 865; // (4)
                targetCodePage = Encoding.GetEncoding(codePage); // (5)
                string cmd = "\x1b\x1d\x74\x09"; // (7)
                //encodedBytes = targetCodePage.GetBytes(cmd + this.txtCodePage.Text.ToString() + "\x0a"); // (6)

                byte[] dataByteArray = targetCodePage.GetBytes(cmd + prnData + "\x0a");
                //Write bytes to printer
                uint amountWritten = 0;
                uint amountWrittenKeep;
                while (dataByteArray.Length > amountWritten)
                {
                    //This while loop is very important because in here is where the bytes are being sent out through StarIO to the printer
                    amountWrittenKeep = amountWritten;
                    try
                    {
                        amountWritten += sPort.WritePort(dataByteArray, amountWritten, (uint)dataByteArray.Length - amountWritten);
                    }
                    catch (PortException)
                    {
                        // error happen while sending data
                        //this.lblPrinterStatus.Text = "Port Error";
                        //this.lblPrinterStatus.ForeColor = Color.Red;
                        Factory.I.ReleasePort(sPort);
                        return;
                    }

                    if (amountWrittenKeep == amountWritten) // no data is sent
                    {
                        Factory.I.ReleasePort(sPort);
                        //lblPrinterStatus.Text = "Can't send data";
                        //this.lblPrinterStatus.ForeColor = Color.Red;
                        return; //exit this entire function
                    }
                }

                //Release the port 
                //THIS IS VERY IMPORTANT, IF YOU OPEN THE PORT AND DO NOT CLOSE IT, YOU WILL HAVE PROBLEMS
                Factory.I.ReleasePort(sPort);
                //////////////////////////

                //Send the data to the log, you can take this out of the code in your application
                //appendLog(dataByteArray);
            }
        }

        public void PrintToPrinter(string msg)
        {
            

                string day = DateTime.Now.Day.ToString();
                string month = DateTime.Now.Month.ToString();
                string year = DateTime.Now.Year.ToString();
                double momsnr;
                string moms;
                int receiptPrice = 10;
                string TransactionID = "XX";
                string checkInTime = DateTime.Now.ToShortTimeString();
                try
                {

                    momsnr = Convert.ToDouble(receiptPrice) * 0.20;
                    moms = momsnr.ToString();
                }
                catch (Exception ex)
                {
                    moms = "0";
                }



                var carpark_name = "XX";
                var carpark_address = "YY";
                var carpark_city = "ZZ";
                var carpark_postal = "DD";
                var carpark_cvr = "EE";
                var carpark_phone = "FF";
                var carpark_website = "CC";


                //string moms = momsnr.ToString();
                string receipt =
                    "\x1B\x1C\x70\x1\x0" +
                    "\n\x1b\x1d\x61\x1" +                                // Center Alignment
                    "\n" + carpark_name + "\n" + carpark_address + "\n" + carpark_postal + " " + carpark_city + "\nCvr. nr. " + carpark_cvr + "\nTlf. " + carpark_phone + "\n" + carpark_website + "\n" +
                    "\x1b\x1d\x61\x0" +                                                 // Left Alignment
                    "\x1b\x44\x2\x10\x22\x0" +                                          // Setting Horizontal Tab 
                    "Date: " + DateTime.Now.ToString() + " \r\n" +
                    "------------------------------------------\r\n\r\n" +
                    "\x1b\x45" +                                                        // bold
                    "Parkering\n" +
                    "\x1b\x46" +                                                        // bold off
                    "#ID: " + TransactionID + "\x9" + " " + "\x9" + "  Info\r\n" +
                    "Indkørsel " + "\x9" + "  " + "\x9 " + checkInTime + "\r\n" +
                    "Aktuel tid" + "\x9" + " " + "\x9 " + DateTime.Now.ToShortTimeString() + "  \r\n\r\n" +
                    //"P-tid  " + "\x9" + " " + "\x9" + "  0\r\n\r\n" +

                    //"Subtotal " + "\x9" + " " + "\x9" + receiptPrice +"\r\n" +
                    "Subtotal " + "\x9\x9" + receiptPrice + " DKK\r\n" +
                    "Moms " + "\x9\x9" + moms + " DKK\r\n" +
                    "Kortgebyr " + "\x9\x9" + "0" + " DKK\r\n" +
                    "------------------------------------------\r\n" +
                    "Total " + "\x9" + " " + "\x9" + receiptPrice + " DKK\r\n" +
                    //"Total" + "\x6" + "" + "\x9" + "\x1b\x69\x1\x1" + " " + receiptPrice + "                  DKK\r\n" + // Character Expansion
                    "\x1b\x69\x0\x0" +                                                                  // Cancel Expansion 
                    "------------------------------------------\r\n" + msg +       // Specify/Cancel Underline Printing - Pg. 3-15 in the linemode_cm_en.pdf
                    "\x0A" +
                    "\x1b\x61" +
                    "\x5" +
                    "\x1b\x64\x00" +                                                                    // Cut
                    "\x7";


                try
                {
                    PrintFromStarIO(receipt);

                }
                catch (Exception ex){
                    //throw new Exception("Exception Occured While Printing", ex);
                }
            
        }


        public void BuildReceiptAndPrint(List<string> PrinterCommands)
        {
            string PrinterInformation = "";
            for (int i = 0; i < PrinterCommands.Count; i++)
            {
                PrinterInformation += PrinterCommands[i].ToString();
            }
            PrintFromStarIO(PrinterInformation);
        }
        
        public void LogMessage(string msg)
        {
            tb_log.Text += msg + "\r\n";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetPrinterStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintToPrinter("test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_log.Text = "";
        }

        private void testprint2_Click(object sender, EventArgs e)
        {
            //PrintToPrinter2("test");
            BuildReceiptAndPrint(PrinterCommands);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string addLogo1 = "\x1B\x1C\x70\x1\x0";
            PrinterCommands.Add(addLogo1);
            LogMessage("added logo 1");
            ReceiptData.Add("Logo 1");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ReceiptData.Count <= 0)
            {
                LogMessage("Receipt is empty");
            }
            else {
                for (int i = 0; i < ReceiptData.Count; i++)
                {
                    LogMessage(ReceiptData[i].ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string addCancelExpansion = "\x1b\x69\x0\x0";
            string addfullcut = "\x1b\x64\x0";
            PrinterCommands.Add(addCancelExpansion);
            PrinterCommands.Add(addfullcut);
            LogMessage("added full cut And cancel expansion");
            ReceiptData.Add("Full cut & cancel expansion");
            testprint2.Enabled = true;
        }

        private void AddStringtoReceipt_Click(object sender, EventArgs e)
        {
            PrinterCommands.Add(TB_addstring.Text);
            LogMessage("Added: " +TB_addstring.Text + " to receipt");
            ReceiptData.Add(TB_addstring.Text);
            TB_addstring.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string AddnewLine = "\r\n";
            PrinterCommands.Add(AddnewLine);
            LogMessage("added newline");
            ReceiptData.Add("Newline");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrinterCommands.Clear();
            ReceiptData.Clear();
            LogMessage("Receipt builder was cleared!");
        }

        private void AddLinefeed_Click(object sender, EventArgs e)
        {                 
            string AddLineFeed = "\x1b\x61\x6";
            PrinterCommands.Add(AddLineFeed);
            LogMessage("added AddLineFeed (6)");
            ReceiptData.Add("AddLineFeed (6)");
        }

        private void Linesplitter_Click(object sender, EventArgs e)
        {

            string AddLinesplitter = "_________________________________________";
            PrinterCommands.Add(AddLinesplitter);
            LogMessage("added Linesplitter");
            ReceiptData.Add(AddLinesplitter);
        }

        private void LoadLogo2_Click(object sender, EventArgs e)
        {
            string addLogo2 = "\x1B\x1C\x70\x2\x0";
            PrinterCommands.Add(addLogo2);
            LogMessage("added logo 2");
            ReceiptData.Add("Logo 2");
        }

        private void AddTab_Click(object sender, EventArgs e)
        {
            string addtab = "\x9";
            PrinterCommands.Add(addtab);
            LogMessage("added tab");
            ReceiptData.Add("tab");
        }

        private void BoldON_Click(object sender, EventArgs e)
        {
            string BoldOn = "\x1b\x45";
            PrinterCommands.Add(BoldOn);
            LogMessage("Bold is on");
            ReceiptData.Add("Bold on");
        }

        private void BoldOff_Click(object sender, EventArgs e)
        {
            string BoldOff = "\x1b\x46";
            PrinterCommands.Add(BoldOff);
            LogMessage("Bold is off");
            ReceiptData.Add("Bold off");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string SethorizontalTab = "\x1b\x44\x2\x10\x22\x0";
            PrinterCommands.Add(SethorizontalTab);
            LogMessage("Set horizontal tab");
            ReceiptData.Add("horizontal tab on");
        }

        private void StartBWInversion_Click(object sender, EventArgs e)
        {
            string StartBWInversion = "\x1b\x34";
            PrinterCommands.Add(StartBWInversion);
            LogMessage("StartBWInversion");
            ReceiptData.Add("black and white inversion is on");
        }

        private void CancelBWInversion_Click(object sender, EventArgs e)
        {
            string CancelBWInversion = "\x1b\x35";
            PrinterCommands.Add(CancelBWInversion);
            LogMessage("CancelBWInversion");
            ReceiptData.Add("black and white inversion is off");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string rightAlignment = "\n\x1b\x1d\x61\x2";
            PrinterCommands.Add(rightAlignment);
            LogMessage("rightAlignment");
            ReceiptData.Add("rightAlignment on");
        }

        private void SetLeftAlignment_Click(object sender, EventArgs e)
        {
            string leftAlignment = "\n\x1b\x1d\x61\x0";
            PrinterCommands.Add(leftAlignment);
            LogMessage("leftAlignment");
            ReceiptData.Add("leftAlignment on");
        }

        private void SetCenterAlignment_Click(object sender, EventArgs e)
        {
            string centerAlignment = "\n\x1b\x1d\x61\x1";
            PrinterCommands.Add(centerAlignment);
            LogMessage("centerAlignment");
            ReceiptData.Add("centerAlignment on");
        }
    }
}
