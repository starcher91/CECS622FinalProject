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
            this.SuspendLayout();
            // 
            // ddl_QModel
            // 
            this.ddl_QModel.FormattingEnabled = true;
            this.ddl_QModel.Items.AddRange(new object[] {
            "All",
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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

