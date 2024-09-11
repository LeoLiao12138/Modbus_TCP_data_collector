using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using Modbus.Device; // NModbus4  
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Modbus.Extensions.Enron;

namespace Modbus_TCP_data_collector
{
    public partial class Form1 : Form
    {
        private ModbusIpMaster master;
        private TcpClient tcpClient;
        private Thread readThread;
        private bool isReading = false;
        private List<int> dataBuffer = new List<int>();
        private List<float> dataBuffer1 = new List<float>();
        private List<float> dataBuffer2 = new List<float>();
        private List<int> dataBuffer3 = new List<int>();
        private static string folderPath = Directory.GetCurrentDirectory()+"/data";  // 请替换为您的实际文件夹路径
        string filePath;
        string newFileName;
        string newFilePath;
        ushort address = 0;


        public Form1()
        {

            InitializeComponent();
            InitializePlot();
            buttonDisconnect.Enabled = false;
            buttonReadData.Enabled = false;
            buttonStopRead.Enabled = false;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            // 判断文件是否存在，不存在则创建
            if ((Directory.GetFiles(folderPath)).Length==0)
            {
                using (StreamWriter sw = File.CreateText(Path.Combine(folderPath, "1.csv")))
                {
                    // 写入表头（可选）
                    sw.WriteLine("Date,Time,vRMS(mm/s),aRMS(g),aPeak(g),Temperature(℃)");
                }
            }
            string[] files = Directory.GetFiles(folderPath, "*.csv");
            int maxNumberoffiles = GetMaxNumoffiles(files);

            filePath = Path.Combine(folderPath, (maxNumberoffiles + ".csv"));

            int maxfile_rows = GetCurrentRows(filePath);

            if (maxfile_rows<6000)
            {
                newFileName = maxNumberoffiles + ".csv";
                newFilePath = Path.Combine(folderPath, newFileName);
            }
            else
            {
                newFileName = (maxNumberoffiles + 1) + ".csv";
                newFilePath = Path.Combine(folderPath, newFileName);
                File.Create(newFilePath);
            }
        }

        static int GetMaxNumoffiles(string[] files)
        {
            int maxNumber = files.Select(file =>
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                if (int.TryParse(fileNameWithoutExtension, out int number))
                {
                    return number;
                }
                return 0; // 如果文件名不是纯数字，返回0
            }).Max();
            return maxNumber;
        }

        static int GetCurrentRows(string filePath)
        {
            int count = 0;
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        sr.ReadLine();
                        count++;
                    }
                }
            }
            return count;
        }

        private void InitializePlot()
        {
            var model = new PlotModel { Title = "vRMS" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time"});
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "mm/s" ,Minimum =0, Maximum =320});
            var lineSeries = new LineSeries();
            model.Series.Add(lineSeries);
            plotView1.Model = model;

            var model1 = new PlotModel { Title = "aRMS" };
            model1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time" });
            model1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "g", Minimum = 0, Maximum = 10 });
            var lineSeries1 = new LineSeries();
            model1.Series.Add(lineSeries1);
            plotView2.Model = model1;

            var model2 = new PlotModel { Title = "aPeak" };
            model2.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time" });
            model2.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "g", Minimum = 0, Maximum = 10 });
            var lineSeries2 = new LineSeries();
            model2.Series.Add(lineSeries2);
            plotView3.Model = model2;

            var model3 = new PlotModel { Title = "Temperature" };
            model3.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time" });
            model3.Axes.Add(new LinearAxis { Position = AxisPosition.Left,Title = "℃", Minimum = -40, Maximum = 85, MinorStep = 10 });
            var lineSeries3 = new LineSeries();
            model3.Series.Add(lineSeries3);
            plotView4.Model = model3;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient(textBoxIP.Text, 502);
                master = ModbusIpMaster.CreateIp(tcpClient);
                MessageBox.Show("Connected successfully!");
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonReadData.Enabled = true;
                buttonStopRead.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }


        private void buttonReadData_Click(object sender, EventArgs e)
        {
            if (isReading) return;
            isReading = true;

            switch (comboBox1.SelectedIndex)//confirm address according master and port
            {
                case 0://ICE11
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0:
                                address = (ushort)256;
                                break;
                            case 1:
                                address = (ushort)272;
                                break;
                            case 2:
                                address = (ushort)288;
                                break;
                            case 3:
                                address = (ushort)304;
                                break;
                            case 4:
                                address = (ushort)320;
                                break;
                            case 5:
                                address = (ushort)336;
                                break;
                            case 6:
                                address = (ushort)352;
                                break;
                            case 7:
                                address = (ushort)368;
                                break;
                        }
                        break;
                    }
                case 1://ICE2/3
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0:
                                address = (ushort)999;
                                break;
                            case 1:
                                address = (ushort)1999;
                                break;
                            case 2:
                                address = (ushort)2999;
                                break;
                            case 3:
                                address = (ushort)3999;
                                break;
                            case 4:
                                address = (ushort)4999;
                                break;
                            case 5:
                                address = (ushort)5999;
                                break;
                            case 6:
                                address = (ushort)6999;
                                break;
                            case 7:
                                address = (ushort)7999;
                                break;
                        }
                    }
                    break;
                default:
                    address = 0;
                    break;
            }

            readThread = new Thread(ReadData);
            readThread.Start();

        }

        private void ReadData()
        {
            
            while (isReading)
            {
                try
                {
                    ushort[] registers = master.ReadHoldingRegisters(address, 8);
                    dataBuffer.Add(registers[0] /100);
                    dataBuffer1.Add((float)registers[2] / 100);
                    dataBuffer2.Add((float)registers[4] / 100);
                    dataBuffer3.Add(registers[6]);
                    if (dataBuffer.Count > 1000)
                    {
                        dataBuffer.RemoveAt(0);
                        dataBuffer1.RemoveAt(0);
                        dataBuffer2.RemoveAt(0);
                        dataBuffer3.RemoveAt(0);
                    }

                    int current_maxrows= GetCurrentRows(newFilePath);

                    if (current_maxrows >=5000)
                    {
                        string[] files = Directory.GetFiles(folderPath, "*.csv");
                        int maxNumberoffiles = GetMaxNumoffiles(files);
                        newFileName = (maxNumberoffiles + 1) + ".csv";
                        newFilePath = Path.Combine(folderPath, newFileName);
                        //File.Create(newFilePath);
                        using (StreamWriter sw = new StreamWriter(newFilePath, true))
                        {
                            sw.WriteLine("Date,Time,vRMS(mm/s),aRMS(g),aPeak(g),Temperature(℃)");
                        }
                    }
                    
                    using (StreamWriter sw = new StreamWriter(newFilePath, true))
                    {
                        sw.WriteLine($"{System.DateTime.Now.ToString("yyyy-MM-dd")},{System.DateTime.Now.ToString("HH:mm:ss")},{registers[0]/100},{(float)registers[2]/100},{(float)registers[4]/100},{registers[6]}");
                    }


                    Invoke(new Action(() =>
                    {
                        var series = (LineSeries)plotView1.Model.Series[0];
                        var series1 = (LineSeries)plotView2.Model.Series[0];
                        var series2 = (LineSeries)plotView3.Model.Series[0];
                        var series3 = (LineSeries)plotView4.Model.Series[0];
                        series.Points.Clear();
                        series1.Points.Clear();
                        series2.Points.Clear();
                        series3.Points.Clear();
                        DateTime my_time = DateTime.Now;
                        for (int i = 0; i < dataBuffer.Count; i++)
                        {
                            series.Points.Add(new DataPoint(i, dataBuffer[i]));
                            series1.Points.Add(new DataPoint(i, dataBuffer1[i]));
                            series2.Points.Add(new DataPoint(i, dataBuffer2[i]));
                            series3.Points.Add(new DataPoint(i, dataBuffer3[i]));
                        }
                        plotView1.InvalidatePlot(true);
                        plotView2.InvalidatePlot(true);
                        plotView3.InvalidatePlot(true);
                        plotView4.InvalidatePlot(true);
                    }));

                    Thread.Sleep(10); // Read every second  
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading data: {ex.Message}");
                    isReading = false;
                }
            }
        }

        private void buttonStopRead_Click(object sender, EventArgs e)
        {
            isReading = false;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Tcp_disconnect();

            // 如果ModbusIpMaster有特定的断开连接方法，也应该调用它（尽管这通常不是必需的，因为关闭TcpClient就足够了）  
            // 但请注意，NModbus4等库可能没有提供显式的断开连接方法
        }

        private void Tcp_disconnect()
        {
            if (tcpClient != null)
            {
                try
                {
                    isReading = false;
                    tcpClient.Close(); // 或者使用 tcpClient.Dispose();  
                    tcpClient = null; // 可选：将tcpClient设置为null，以便垃圾回收  
                    master = null; // 可选：将ModbusIpMaster实例设置为null                    
                    MessageBox.Show("连接已断开");
                    buttonConnect.Enabled = true;
                    buttonDisconnect.Enabled = false;
                    buttonReadData.Enabled = false;
                    buttonStopRead.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error disconnect: {ex.Message}");

                }

            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tcp_disconnect();
        }
    }
}
