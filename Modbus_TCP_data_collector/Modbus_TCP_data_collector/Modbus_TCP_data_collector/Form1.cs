using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using Modbus.Device; // NModbus4  
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Modbus_TCP_data_collector
{
    public partial class Form1 : Form
    {
        private ModbusIpMaster master;
        private TcpClient tcpClient;
        private Thread readThread;
        private bool isReading = false;
        private static int[] myarray = new int[100];
        private List<int> dataBuffer = new List<int>(myarray);
        


        public Form1()
        {
            InitializeComponent();
            InitializePlot();
            buttonDisconnect.Enabled = false;
            buttonReadData.Enabled = false;
            buttonStopRead.Enabled = false;
        }

        private void InitializePlot()
        {
            var model = new PlotModel { Title = "Modbus Data" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time"});
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Value" });
            var lineSeries = new LineSeries();
            model.Series.Add(lineSeries);
            plotView1.Model = model;
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
            readThread = new Thread(ReadData);
            readThread.Start();
        }

        private void ReadData()
        {
            while (isReading)
            {
                try
                {
                    ushort[] registers = master.ReadHoldingRegisters(Convert.ToUInt16(textBoxaddress.Text), 1);
                    dataBuffer.Add(registers[0]);                
                    if (dataBuffer.Count > 100) dataBuffer.RemoveAt(0);

                    Invoke(new Action(() =>
                    {
                        var series = (LineSeries)plotView1.Model.Series[0];
                        series.Points.Clear();
                        DateTime my_time = DateTime.Now;
                        for (int i = 0; i < dataBuffer.Count; i++)
                        {
                            series.Points.Add(new DataPoint(i, dataBuffer[i]));
                        }
                        plotView1.InvalidatePlot(true);
                    }));

                    Thread.Sleep(1000); // Read every second  
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
                    tcpClient.Close(); // 或者使用 tcpClient.Dispose();  
                    tcpClient = null; // 可选：将tcpClient设置为null，以便垃圾回收  
                    master = null; // 可选：将ModbusIpMaster实例设置为null
                    isReading = false;
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
