using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinalProject
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        public Results(string Model, int numCust, int numServers, double avgInterarrivalTime, double avgServiceTime, double sigma, int trialNum)
        {
            InitializeComponent();
            Simulator sim = new Simulator(Model, numCust, numServers,
                                            avgInterarrivalTime, avgServiceTime, sigma
                                        );
            sim.runSimulator();
            dataGridView1.DataSource = sim.outCustomerQueue.ToArray();
            dataGridView2.DataSource = sim.servers.ToArray();
            bindChart(sim);
            trialNum++;
            this.Text += " - Trial " + trialNum;
        }

        private void bindChart(Simulator sim)
        {
            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisX.Name = "Arrival Time";
            chart1.ChartAreas[0].AxisY.Name = "Time in System";

            foreach (Server s in sim.servers)
            {
                chart1.Series.Add(new Series
                {
                    Name = "Server " + s.ID,
                    ChartType = SeriesChartType.Line
                });
            }

            foreach (Series s in chart1.Series)
            {
                foreach (Customer c in sim.outCustomerQueue)
                {
                    s.Points.AddXY(c.arrivalTime, c.inSystemTime);
                }
            }
            chart1.Series.Invalidate();
        }
    }
}
