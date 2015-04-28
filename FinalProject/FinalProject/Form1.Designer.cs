namespace FinalProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_ProbBlocking = new System.Windows.Forms.CheckBox();
            this.cb_ExpectedNumCustInSystem = new System.Windows.Forms.CheckBox();
            this.cb_ExpectedQueueLen = new System.Windows.Forms.CheckBox();
            this.cb_Throughput = new System.Windows.Forms.CheckBox();
            this.cb_AvgTimeCustInSystem = new System.Windows.Forms.CheckBox();
            this.cb_AvgTimeBetweenArrivals = new System.Windows.Forms.CheckBox();
            this.cb_AverageServerUtilization = new System.Windows.Forms.CheckBox();
            this.cb_AvgServiceTime = new System.Windows.Forms.CheckBox();
            this.cb_ProbServerIdle = new System.Windows.Forms.CheckBox();
            this.cb_ProbWaiting = new System.Windows.Forms.CheckBox();
            this.cb_AvgWaitTime = new System.Windows.Forms.CheckBox();
            this.ddl_QModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_numCust = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_numServers = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_numTrials = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_RunSim = new System.Windows.Forms.Button();
            this.tb_avgInterarrivalTime = new System.Windows.Forms.TextBox();
            this.tb_avgServiceTime = new System.Windows.Forms.TextBox();
            this.tb_sigma = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_ProbBlocking);
            this.groupBox1.Controls.Add(this.cb_ExpectedNumCustInSystem);
            this.groupBox1.Controls.Add(this.cb_ExpectedQueueLen);
            this.groupBox1.Controls.Add(this.cb_Throughput);
            this.groupBox1.Controls.Add(this.cb_AvgTimeCustInSystem);
            this.groupBox1.Controls.Add(this.cb_AvgTimeBetweenArrivals);
            this.groupBox1.Controls.Add(this.cb_AverageServerUtilization);
            this.groupBox1.Controls.Add(this.cb_AvgServiceTime);
            this.groupBox1.Controls.Add(this.cb_ProbServerIdle);
            this.groupBox1.Controls.Add(this.cb_ProbWaiting);
            this.groupBox1.Controls.Add(this.cb_AvgWaitTime);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 554);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cb_ProbBlocking
            // 
            this.cb_ProbBlocking.AutoSize = true;
            this.cb_ProbBlocking.Location = new System.Drawing.Point(7, 260);
            this.cb_ProbBlocking.Name = "cb_ProbBlocking";
            this.cb_ProbBlocking.Size = new System.Drawing.Size(176, 17);
            this.cb_ProbBlocking.TabIndex = 10;
            this.cb_ProbBlocking.Text = "Probability of blocking occurring";
            this.cb_ProbBlocking.UseVisualStyleBackColor = true;
            // 
            // cb_ExpectedNumCustInSystem
            // 
            this.cb_ExpectedNumCustInSystem.AutoSize = true;
            this.cb_ExpectedNumCustInSystem.Location = new System.Drawing.Point(7, 236);
            this.cb_ExpectedNumCustInSystem.Name = "cb_ExpectedNumCustInSystem";
            this.cb_ExpectedNumCustInSystem.Size = new System.Drawing.Size(241, 17);
            this.cb_ExpectedNumCustInSystem.TabIndex = 9;
            this.cb_ExpectedNumCustInSystem.Text = "Expected Number of Customers in the System";
            this.cb_ExpectedNumCustInSystem.UseVisualStyleBackColor = true;
            // 
            // cb_ExpectedQueueLen
            // 
            this.cb_ExpectedQueueLen.AutoSize = true;
            this.cb_ExpectedQueueLen.Location = new System.Drawing.Point(7, 212);
            this.cb_ExpectedQueueLen.Name = "cb_ExpectedQueueLen";
            this.cb_ExpectedQueueLen.Size = new System.Drawing.Size(142, 17);
            this.cb_ExpectedQueueLen.TabIndex = 8;
            this.cb_ExpectedQueueLen.Text = "Expected Queue Length";
            this.cb_ExpectedQueueLen.UseVisualStyleBackColor = true;
            // 
            // cb_Throughput
            // 
            this.cb_Throughput.AutoSize = true;
            this.cb_Throughput.Location = new System.Drawing.Point(7, 188);
            this.cb_Throughput.Name = "cb_Throughput";
            this.cb_Throughput.Size = new System.Drawing.Size(81, 17);
            this.cb_Throughput.TabIndex = 7;
            this.cb_Throughput.Text = "Throughput";
            this.cb_Throughput.UseVisualStyleBackColor = true;
            // 
            // cb_AvgTimeCustInSystem
            // 
            this.cb_AvgTimeCustInSystem.AutoSize = true;
            this.cb_AvgTimeCustInSystem.Location = new System.Drawing.Point(7, 164);
            this.cb_AvgTimeCustInSystem.Name = "cb_AvgTimeCustInSystem";
            this.cb_AvgTimeCustInSystem.Size = new System.Drawing.Size(244, 17);
            this.cb_AvgTimeCustInSystem.TabIndex = 6;
            this.cb_AvgTimeCustInSystem.Text = "Average Time Customer Spends in the System";
            this.cb_AvgTimeCustInSystem.UseVisualStyleBackColor = true;
            // 
            // cb_AvgTimeBetweenArrivals
            // 
            this.cb_AvgTimeBetweenArrivals.AutoSize = true;
            this.cb_AvgTimeBetweenArrivals.Location = new System.Drawing.Point(7, 140);
            this.cb_AvgTimeBetweenArrivals.Name = "cb_AvgTimeBetweenArrivals";
            this.cb_AvgTimeBetweenArrivals.Size = new System.Drawing.Size(174, 17);
            this.cb_AvgTimeBetweenArrivals.TabIndex = 5;
            this.cb_AvgTimeBetweenArrivals.Text = "Average Time Between Arrivals";
            this.cb_AvgTimeBetweenArrivals.UseVisualStyleBackColor = true;
            // 
            // cb_AverageServerUtilization
            // 
            this.cb_AverageServerUtilization.AutoSize = true;
            this.cb_AverageServerUtilization.Location = new System.Drawing.Point(7, 116);
            this.cb_AverageServerUtilization.Name = "cb_AverageServerUtilization";
            this.cb_AverageServerUtilization.Size = new System.Drawing.Size(148, 17);
            this.cb_AverageServerUtilization.TabIndex = 4;
            this.cb_AverageServerUtilization.Text = "Average Server Utilization";
            this.cb_AverageServerUtilization.UseVisualStyleBackColor = true;
            // 
            // cb_AvgServiceTime
            // 
            this.cb_AvgServiceTime.AutoSize = true;
            this.cb_AvgServiceTime.Location = new System.Drawing.Point(7, 92);
            this.cb_AvgServiceTime.Name = "cb_AvgServiceTime";
            this.cb_AvgServiceTime.Size = new System.Drawing.Size(131, 17);
            this.cb_AvgServiceTime.TabIndex = 3;
            this.cb_AvgServiceTime.Text = "Average Service Time";
            this.cb_AvgServiceTime.UseVisualStyleBackColor = true;
            // 
            // cb_ProbServerIdle
            // 
            this.cb_ProbServerIdle.AutoSize = true;
            this.cb_ProbServerIdle.Location = new System.Drawing.Point(7, 68);
            this.cb_ProbServerIdle.Name = "cb_ProbServerIdle";
            this.cb_ProbServerIdle.Size = new System.Drawing.Size(170, 17);
            this.cb_ProbServerIdle.TabIndex = 2;
            this.cb_ProbServerIdle.Text = "Probability of Server Being Idle";
            this.cb_ProbServerIdle.UseVisualStyleBackColor = true;
            // 
            // cb_ProbWaiting
            // 
            this.cb_ProbWaiting.AutoSize = true;
            this.cb_ProbWaiting.Location = new System.Drawing.Point(7, 44);
            this.cb_ProbWaiting.Name = "cb_ProbWaiting";
            this.cb_ProbWaiting.Size = new System.Drawing.Size(125, 17);
            this.cb_ProbWaiting.TabIndex = 1;
            this.cb_ProbWaiting.Text = "Probability of Waiting";
            this.cb_ProbWaiting.UseVisualStyleBackColor = true;
            // 
            // cb_AvgWaitTime
            // 
            this.cb_AvgWaitTime.AutoSize = true;
            this.cb_AvgWaitTime.Location = new System.Drawing.Point(7, 20);
            this.cb_AvgWaitTime.Name = "cb_AvgWaitTime";
            this.cb_AvgWaitTime.Size = new System.Drawing.Size(131, 17);
            this.cb_AvgWaitTime.TabIndex = 0;
            this.cb_AvgWaitTime.Text = "Average Waiting Time";
            this.cb_AvgWaitTime.UseVisualStyleBackColor = true;
            // 
            // ddl_QModel
            // 
            this.ddl_QModel.FormattingEnabled = true;
            this.ddl_QModel.Items.AddRange(new object[] {
            "Single Server",
            "MultiServer",
            "MultiServer MultiQueue",
            "MultiServer MultiQueue w/ Smart Queue"});
            this.ddl_QModel.Location = new System.Drawing.Point(265, 29);
            this.ddl_QModel.Name = "ddl_QModel";
            this.ddl_QModel.Size = new System.Drawing.Size(248, 21);
            this.ddl_QModel.TabIndex = 1;
            this.ddl_QModel.SelectedIndexChanged += new System.EventHandler(this.ddl_QModel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Queueing Model";
            // 
            // tb_numCust
            // 
            this.tb_numCust.Location = new System.Drawing.Point(546, 29);
            this.tb_numCust.Name = "tb_numCust";
            this.tb_numCust.Size = new System.Drawing.Size(108, 20);
            this.tb_numCust.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Customers";
            // 
            // tb_numServers
            // 
            this.tb_numServers.Location = new System.Drawing.Point(681, 29);
            this.tb_numServers.Name = "tb_numServers";
            this.tb_numServers.Size = new System.Drawing.Size(134, 20);
            this.tb_numServers.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of Servers/Queues";
            // 
            // tb_numTrials
            // 
            this.tb_numTrials.Location = new System.Drawing.Point(834, 29);
            this.tb_numTrials.Name = "tb_numTrials";
            this.tb_numTrials.Size = new System.Drawing.Size(100, 20);
            this.tb_numTrials.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(834, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of Trials";
            // 
            // btn_RunSim
            // 
            this.btn_RunSim.Location = new System.Drawing.Point(834, 57);
            this.btn_RunSim.Name = "btn_RunSim";
            this.btn_RunSim.Size = new System.Drawing.Size(100, 23);
            this.btn_RunSim.TabIndex = 9;
            this.btn_RunSim.Text = "Run";
            this.btn_RunSim.UseVisualStyleBackColor = true;
            this.btn_RunSim.Click += new System.EventHandler(this.btn_RunSim_Click);
            // 
            // tb_avgInterarrivalTime
            // 
            this.tb_avgInterarrivalTime.Location = new System.Drawing.Point(273, 78);
            this.tb_avgInterarrivalTime.Name = "tb_avgInterarrivalTime";
            this.tb_avgInterarrivalTime.Size = new System.Drawing.Size(100, 20);
            this.tb_avgInterarrivalTime.TabIndex = 11;
            // 
            // tb_avgServiceTime
            // 
            this.tb_avgServiceTime.Location = new System.Drawing.Point(413, 78);
            this.tb_avgServiceTime.Name = "tb_avgServiceTime";
            this.tb_avgServiceTime.Size = new System.Drawing.Size(100, 20);
            this.tb_avgServiceTime.TabIndex = 12;
            // 
            // tb_sigma
            // 
            this.tb_sigma.Location = new System.Drawing.Point(554, 79);
            this.tb_sigma.Name = "tb_sigma";
            this.tb_sigma.Size = new System.Drawing.Size(100, 20);
            this.tb_sigma.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Average Interarrival Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Average Service Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(578, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sigma";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 824);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_sigma);
            this.Controls.Add(this.tb_avgServiceTime);
            this.Controls.Add(this.tb_avgInterarrivalTime);
            this.Controls.Add(this.btn_RunSim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_numTrials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_numServers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_numCust);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddl_QModel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_ProbBlocking;
        private System.Windows.Forms.CheckBox cb_ExpectedNumCustInSystem;
        private System.Windows.Forms.CheckBox cb_ExpectedQueueLen;
        private System.Windows.Forms.CheckBox cb_Throughput;
        private System.Windows.Forms.CheckBox cb_AvgTimeCustInSystem;
        private System.Windows.Forms.CheckBox cb_AvgTimeBetweenArrivals;
        private System.Windows.Forms.CheckBox cb_AverageServerUtilization;
        private System.Windows.Forms.CheckBox cb_AvgServiceTime;
        private System.Windows.Forms.CheckBox cb_ProbServerIdle;
        private System.Windows.Forms.CheckBox cb_ProbWaiting;
        private System.Windows.Forms.CheckBox cb_AvgWaitTime;
        private System.Windows.Forms.ComboBox ddl_QModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_numCust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_numServers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_numTrials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_RunSim;
        private System.Windows.Forms.TextBox tb_avgInterarrivalTime;
        private System.Windows.Forms.TextBox tb_avgServiceTime;
        private System.Windows.Forms.TextBox tb_sigma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

