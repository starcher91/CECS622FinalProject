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
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        public Results(string Model, int numCust, int numServers, double avgInterarrivalTime, double avgServiceTime, double sigma, int trialNum)
        {
            InitializeComponent();
            trialNum++;
            Text += " - Trial " + trialNum;
            Simulator sim = new Simulator(Model, numCust, numServers,
                                            avgInterarrivalTime, avgServiceTime, sigma
                                        );
            sim.runSimulator();
            dataGridView1.DataSource = sim.outCustomerQueue.ToArray();
            dataGridView2.DataSource = sim.servers.ToArray();
            bindChart(sim);
        }

        private void bindChart(Simulator sim)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            chart1.Titles.Add("Time In System per Server");
            chart2.Titles.Add("Service Time per Server");

            ChartArea TimeInSystemChartArea = new ChartArea("TimeInSystem");
            TimeInSystemChartArea.AxisX.Title = "Arrival Time";
            TimeInSystemChartArea.AxisY.Title = "Time in System";
            TimeInSystemChartArea.AxisX.Minimum = 0;
            chart1.ChartAreas.Add(TimeInSystemChartArea);

            for (int i = 0; i < sim.servers.Count; i++)
            {
                chart1.Series.Add(new Series
                {
                    Name = "Server " + sim.servers[i].ID,
                    ChartType = SeriesChartType.Line,
                    ChartArea = TimeInSystemChartArea.Name
                });
            }

            for (int i = 0; i < sim.servers.Count; i++)
            {
                foreach (Customer c in sim.servers[i].customersServed)
                {
                    chart1.Series[i].Points.AddXY(c.arrivalTime, c.inSystemTime);
                }
            }

            ChartArea serviceTimeChartArea = new ChartArea("ServiceTime");
            serviceTimeChartArea.AxisX.Title = "Arrival Time";
            serviceTimeChartArea.AxisY.Title = "Service Time";
            serviceTimeChartArea.AxisX.Minimum = 0;
            chart2.ChartAreas.Add(serviceTimeChartArea);

            for (int i = 0; i < sim.servers.Count; i++)
            {
                chart2.Series.Add(new Series
                {
                    Name = "Server " + sim.servers[i].ID,
                    ChartType = SeriesChartType.Line,
                    ChartArea = serviceTimeChartArea.Name
                });
            }

            for (int i = 0; i < sim.servers.Count; i++)
            {
                foreach (Customer c in sim.servers[i].customersServed)
                {
                    chart2.Series[i].Points.AddXY(c.arrivalTime, c.serviceTime);
                }
            }
        }
    }
}
