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

        public Results(string Model, int numCust, int numServers, double avgInterarrivalTime, double avgServiceTime, double sigma, int trialNum )
        {
            InitializeComponent();
            trialNum++;
            Text += " | Trial " + trialNum + " | " + Model;

            Simulator sim = new Simulator(Model, numCust, numServers,
                                            avgInterarrivalTime, avgServiceTime, sigma
                                        );
            sim.runSimulator();

            dataGridView1.DataSource = sim.outCustomerQueue.ToArray();
            dataGridView2.DataSource = sim.servers.ToArray();
            bindCustomerChart(sim);
            bindServerChart(sim);
        }

        public Results(Simulator sim, int trialNum)
        {
            InitializeComponent();
            trialNum++;
            Text += " | Trial " + trialNum + " | Model " + sim.Model;
            sim.runSimulator();

            dataGridView1.DataSource = sim.outCustomerQueue.ToArray();
            dataGridView2.DataSource = sim.servers.ToArray();
            bindCustomerChart(sim);
            bindServerChart(sim);
        }

        private void bindCustomerChart(Simulator sim)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart5.Series.Clear();

            chart1.Titles.Add("Time In System per Server");
            chart2.Titles.Add("Service Time per Server");
            chart5.Titles.Add("Number In System per Server");

            ChartArea TimeInSystemChartArea = new ChartArea("TimeInSystem");
            TimeInSystemChartArea.AxisX.Title = "Time";
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
            serviceTimeChartArea.AxisX.Title = "Time";
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

            ChartArea custNumChartArea = new ChartArea("NumCustomers");
            custNumChartArea.AxisY.Title = "Number of Customers";
            chart5.ChartAreas.Add(custNumChartArea);

            for (int i = 0; i < sim.servers.Count; i++)
            {
                chart5.Series.Add(new Series
                {
                    Name = "Server " + sim.servers[i].ID,
                    ChartType = SeriesChartType.Column,
                    ChartArea = custNumChartArea.Name
                });
            }

            for (int i = 0; i < sim.servers.Count; i++)
            {
                var avgQueueLength = new DataPoint();
                avgQueueLength.SetValueY(sim.servers[i].avgQueueLength);
                avgQueueLength.AxisLabel = "Average Queue Length";

                var avgNumInSystem = new DataPoint();
                avgNumInSystem.SetValueY(sim.servers[i].avgNumInSystem);
                avgNumInSystem.AxisLabel = "Average Number in System";

                chart5.Series[i].Points.Add(avgQueueLength);
                chart5.Series[i].Points.Add(avgNumInSystem);
            }
        }

        private void bindServerChart(Simulator sim)
        {
            chart3.Series.Clear();
            chart4.Series.Clear();

            ChartArea serverProbabilitiesChartArea = new ChartArea("ServerProbabilities");
            serverProbabilitiesChartArea.AxisY.Title = "Probability";
            chart3.ChartAreas.Add(serverProbabilitiesChartArea);

            for (int i = 0; i < sim.servers.Count; i++)
            {
                chart3.Series.Add(new Series
                {
                    Name = "Server " + sim.servers[i].ID,
                    ChartType = SeriesChartType.Column,
                    ChartArea = serverProbabilitiesChartArea.Name
                });
            }

            for (int i = 0; i < sim.servers.Count; i++)
            {
                var probWaiting = new DataPoint();
                probWaiting.SetValueY(sim.servers[i].probWaiting);
                probWaiting.AxisLabel = "Probability of Waiting";

                var probServerIdle = new DataPoint();
                probServerIdle.SetValueY(sim.servers[i].probServerIdle);
                probServerIdle.AxisLabel = "Probability of Server Idle";

                chart3.Series[i].Points.Add(probWaiting);
                chart3.Series[i].Points.Add(probServerIdle);
            }

            ChartArea serverTimeChartArea = new ChartArea("ServerTimes");
            serverTimeChartArea.AxisY.Title = "Time";
            chart4.ChartAreas.Add(serverTimeChartArea);

            for (int i = 0; i < sim.servers.Count; i++)
            {
                chart4.Series.Add(new Series
                {
                    Name = "Server " + sim.servers[i].ID,
                    ChartType = SeriesChartType.Column,
                    ChartArea = serverTimeChartArea.Name
                });
            }

            for (int i = 0; i < sim.servers.Count; i++)
            {
                var avgWaitTimePoint = new DataPoint();
                avgWaitTimePoint.SetValueY(sim.servers[i].avgWaitTime);
                avgWaitTimePoint.AxisLabel = "Average Wait Time";

                var avgServiceTime = new DataPoint();
                avgServiceTime.SetValueY(sim.servers[i].avgServiceTime);
                avgServiceTime.AxisLabel = "Average Service Time";

                var avgTimeBetweenArrivals = new DataPoint();
                avgTimeBetweenArrivals.SetValueY(sim.servers[i].avgTimeBetweenArrivals);
                avgTimeBetweenArrivals.AxisLabel = "Average Time Between Arrivals";

                var avgTimeCustomerSpendsInSystem = new DataPoint();
                avgTimeCustomerSpendsInSystem.SetValueY(sim.servers[i].avgTimeCustomerSpendsInSystem);
                avgTimeCustomerSpendsInSystem.AxisLabel = "Average Time In System";

                var avgIdleTime = new DataPoint();
                avgIdleTime.SetValueY(sim.servers[i].avgIdleTime);
                avgIdleTime.AxisLabel = "Average Time Idle";

                chart4.Series[i].Points.Add(avgWaitTimePoint);
                chart4.Series[i].Points.Add(avgServiceTime);
                chart4.Series[i].Points.Add(avgTimeBetweenArrivals);
                chart4.Series[i].Points.Add(avgTimeCustomerSpendsInSystem);
                chart4.Series[i].Points.Add(avgIdleTime);
            }
        }
    }
}
