namespace Modbus_TCP_data_collector
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.buttonReadData = new System.Windows.Forms.Button();
            this.buttonStopRead = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.plotView3 = new OxyPlot.WindowsForms.PlotView();
            this.plotView4 = new OxyPlot.WindowsForms.PlotView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonSetIO_Link = new System.Windows.Forms.Button();
            this.buttonResetIO_Link = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(31, 188);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(115, 33);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(74, 80);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(96, 22);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // plotView1
            // 
            this.plotView1.Location = new System.Drawing.Point(284, 36);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(493, 389);
            this.plotView1.TabIndex = 2;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // buttonReadData
            // 
            this.buttonReadData.Location = new System.Drawing.Point(31, 300);
            this.buttonReadData.Name = "buttonReadData";
            this.buttonReadData.Size = new System.Drawing.Size(115, 33);
            this.buttonReadData.TabIndex = 3;
            this.buttonReadData.Text = "ReadData";
            this.buttonReadData.UseVisualStyleBackColor = true;
            this.buttonReadData.Click += new System.EventHandler(this.buttonReadData_Click);
            // 
            // buttonStopRead
            // 
            this.buttonStopRead.Location = new System.Drawing.Point(163, 300);
            this.buttonStopRead.Name = "buttonStopRead";
            this.buttonStopRead.Size = new System.Drawing.Size(115, 33);
            this.buttonStopRead.TabIndex = 4;
            this.buttonStopRead.Text = "StopRead";
            this.buttonStopRead.UseVisualStyleBackColor = true;
            this.buttonStopRead.Click += new System.EventHandler(this.buttonStopRead_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(163, 188);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(115, 33);
            this.buttonDisconnect.TabIndex = 5;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Master:";
            // 
            // plotView2
            // 
            this.plotView2.Location = new System.Drawing.Point(770, 36);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(493, 389);
            this.plotView2.TabIndex = 9;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotView3
            // 
            this.plotView3.Location = new System.Drawing.Point(284, 415);
            this.plotView3.Name = "plotView3";
            this.plotView3.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView3.Size = new System.Drawing.Size(493, 389);
            this.plotView3.TabIndex = 10;
            this.plotView3.Text = "plotView3";
            this.plotView3.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView3.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView3.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotView4
            // 
            this.plotView4.Location = new System.Drawing.Point(770, 415);
            this.plotView4.Name = "plotView4";
            this.plotView4.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView4.Size = new System.Drawing.Size(493, 389);
            this.plotView4.TabIndex = 11;
            this.plotView4.Text = "plotView4";
            this.plotView4.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView4.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView4.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Port:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ICE11",
            "ICE2/3"});
            this.comboBox1.Location = new System.Drawing.Point(74, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 24);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox2.Location = new System.Drawing.Point(74, 123);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(96, 24);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.SelectedIndex = 0;
            // 
            // buttonSetIO_Link
            // 
            this.buttonSetIO_Link.Enabled = false;
            this.buttonSetIO_Link.Location = new System.Drawing.Point(31, 246);
            this.buttonSetIO_Link.Name = "buttonSetIO_Link";
            this.buttonSetIO_Link.Size = new System.Drawing.Size(115, 33);
            this.buttonSetIO_Link.TabIndex = 15;
            this.buttonSetIO_Link.Text = "Set IO-Link";
            this.buttonSetIO_Link.UseVisualStyleBackColor = true;
            this.buttonSetIO_Link.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonResetIO_Link
            // 
            this.buttonResetIO_Link.Enabled = false;
            this.buttonResetIO_Link.Location = new System.Drawing.Point(164, 246);
            this.buttonResetIO_Link.Name = "buttonResetIO_Link";
            this.buttonResetIO_Link.Size = new System.Drawing.Size(115, 33);
            this.buttonResetIO_Link.TabIndex = 16;
            this.buttonResetIO_Link.Text = "Reset IO-Link";
            this.buttonResetIO_Link.UseVisualStyleBackColor = true;
            this.buttonResetIO_Link.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1275, 816);
            this.Controls.Add(this.buttonResetIO_Link);
            this.Controls.Add(this.buttonSetIO_Link);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.plotView4);
            this.Controls.Add(this.plotView3);
            this.Controls.Add(this.plotView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonStopRead);
            this.Controls.Add(this.buttonReadData);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.buttonConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxIP;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button buttonReadData;
        private System.Windows.Forms.Button buttonStopRead;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private OxyPlot.WindowsForms.PlotView plotView3;
        private OxyPlot.WindowsForms.PlotView plotView4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonSetIO_Link;
        private System.Windows.Forms.Button buttonResetIO_Link;
    }
}

