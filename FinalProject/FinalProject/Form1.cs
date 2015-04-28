using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setDefaults();
        }

        private void setDefaults()
        {
            this.Text = "Queueing Simulator";
            tb_numTrials.Text = "1";
            tb_numCust.Text = "100";
            tb_numServers.Text = "2";
            ddl_QModel.SelectedIndex = 0;
            tb_avgInterarrivalTime.Text = "4.5";
            tb_avgServiceTime.Text = "3.2";
            tb_sigma.Text = "0.6";
        }

        private void ddl_QModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_numServers.Enabled = (ddl_QModel.SelectedIndex != 0);
        }

        private void btn_RunSim_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(tb_numTrials.Text); i++)
            {
                Results form = new Results(ddl_QModel.Text, int.Parse(tb_numCust.Text), int.Parse(tb_numServers.Text),double.Parse(tb_avgInterarrivalTime.Text),
                    double.Parse(tb_avgServiceTime.Text), double.Parse(tb_sigma.Text), i
                    );
                form.Show();
            }
        }
    }
}
