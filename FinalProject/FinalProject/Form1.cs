using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            tb_numServers.Text = "1";
            ddl_QModel.SelectedIndex = 0;
        }

        private void ddl_QModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_numServers.Enabled = (ddl_QModel.SelectedIndex != 0) ? true : false;
        }

        private void btn_RunSim_Click(object sender, EventArgs e)
        {
            Simulator.runSimulator(ddl_QModel.SelectedText, int.Parse(tb_numCust.Text), int.Parse(tb_numServers.Text), int.Parse(tb_numTrials.Text));
        }
    }
}
