using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Charts;
using DevComponents.DotNetBar.Charts.Style;

namespace GetBaseEventFromETW
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetupChart();
            Controls.Add(_ChartControl);
        }

        #region Private variables

        private ChartControl _ChartControl;

        private SeriesStyle[] _SeriesStyles =
        {
            new SeriesStyle("Africa", Color.Blue),
            new SeriesStyle("Americas", Color.Orange),
            new SeriesStyle("Asia", Color.Green),
            new SeriesStyle("Europe", Color.Red),
            new SeriesStyle("Oceania", Color.Purple),
        };

        #endregion

        #region SetupChart

        /// <summary>
        /// Initializes the control chart.
        /// </summary>
        private void SetupChart()
        {
            _ChartControl = new ChartControl();

            _ChartControl.Name = "BubblePlot";
            _ChartControl.Location = new Point(10, 10);
            _ChartControl.Size = new Size(ClientRectangle.Width - 30, 550);
            _ChartControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            SetupScrollBarStyles();

            AddChart();
        }

        #region SetupScrollBarStyles

        /// <summary>
        /// Sets up the scrollbar styles.
        /// </summary>
        private void SetupScrollBarStyles()
        {
            ScrollBarVisualStyle moStyle =
                _ChartControl.DefaultVisualStyles.HScrollBarVisualStyles.MouseOver;

            moStyle.ArrowBackground = new Background(Color.AliceBlue);
            moStyle.ThumbBackground = new Background(Color.AliceBlue);

            ScrollBarVisualStyle smoStyle =
                _ChartControl.DefaultVisualStyles.HScrollBarVisualStyles.SelectedMouseOver;

            smoStyle.ArrowBackground = new Background(Color.White);
            smoStyle.ThumbBackground = new Background(Color.White);

            moStyle = _ChartControl.DefaultVisualStyles.VScrollBarVisualStyles.MouseOver;

            moStyle.ArrowBackground = new Background(Color.AliceBlue);
            moStyle.ThumbBackground = new Background(Color.AliceBlue);

            smoStyle = _ChartControl.DefaultVisualStyles.VScrollBarVisualStyles.SelectedMouseOver;

            smoStyle.ArrowBackground = new Background(Color.White);
            smoStyle.ThumbBackground = new Background(Color.White);
        }

        #endregion

        #region AddChart

        /// <summary>
        /// Adds a new chart to the ChartControl
        /// </summary> 
        readonly ChartXy _chartXy = new ChartXy("Process");
        private void AddChart()
        {
            // Create a new ChartXy.



            // Set the minimum size of the chart.

            _chartXy.MinContentSize = new Size(600, 400);

            // Setup our Crosshair display.

            _chartXy.ChartCrosshair.HighlightPoints = true;

            _chartXy.ChartCrosshair.AxisOrientation = AxisOrientation.X;

            // Let's only display the point nearest to the mouse cursor
            // that intersects with the crosshair line.

            _chartXy.ChartCrosshair.CrosshairLabelMode = CrosshairLabelMode.NearestSeries;
            _chartXy.ChartCrosshair.ShowCrosshairLabels = true;

            _chartXy.ChartCrosshair.ShowValueXLine = true;
            _chartXy.ChartCrosshair.ShowValueYLine = true;
            _chartXy.ChartCrosshair.ShowValueXLabels = true;
            _chartXy.ChartCrosshair.ShowValueYLabels = true;

            // Setup various styles for the chart...

            SetupChartStyle(_chartXy);
            SetupContainerStyle(_chartXy);
            SetupChartAxes(_chartXy);
            SetupChartLegend(_chartXy);

            // Add a chart title and associated series.

            AddChartTitle(_chartXy);
            _chartXy.Legend.Visible = false;
            Action<ChartXy> ac = p =>
            {
                AddSeries(_chartXy);
            };

            // And finally, add the chart to the ChartContainers
            // collection of chart elements.
            ac.Invoke(_chartXy);
            _ChartControl.ChartPanel.ChartContainers.Add(_chartXy);

        }

        #region SetupChartAxes

        /// <summary>
        /// Sets up the chart axes.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupChartAxes(ChartXy chartXy)
        {
            // X Axis

            ChartAxis axis = chartXy.AxisX;

           // axis.AxisMargins = 75;

            axis.MajorTickmarks.StaggerLabels = false;
            axis.MinorTickmarks.TickmarkCount = 1;

            axis.MinorGridLines.Visible = false;

            axis.MajorGridLines.GridLinesVisualStyle.LineColor = Color.PowderBlue;

            // Let's add a title associated with the axis.

            axis.Title.Text = "Process ID";

            ChartTitleVisualStyle tstyle = axis.Title.ChartTitleVisualStyle;

            tstyle.Font = new Font("Georgia",11);
            tstyle.TextColor = Color.Navy;
            tstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(0, 6, 0, 0);
            tstyle.Alignment = Alignment.MiddleCenter;

             axis.MajorTickmarks.LabelVisualStyle.TextFormat = "ID##;\"\";";

            // Y Axis

            axis = chartXy.AxisY;

            axis.AxisAlignment = AxisAlignment.Far;

            axis.GridSpacing = 1;
            //axis.AxisMargins = 100;

            axis.MinorTickmarks.TickmarkCount = 1;
            axis.MinorGridLines.Visible = false;

            axis.MajorGridLines.GridLinesVisualStyle.LineColor = Color.PowderBlue;

            // Let's add a title associated with the axis.

            axis.Title.Text = "Memory Usage (KB)";

            tstyle = axis.Title.ChartTitleVisualStyle;

            tstyle.Font = new Font("Georgia", 11);
            axis.MajorTickmarks.LabelVisualStyle.TextFormat = "##;\"\";";
            tstyle.TextColor = Color.Navy;
            tstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(8, 0, 8, 0);
            tstyle.Alignment = Alignment.MiddleCenter;
        }

        #endregion

        #region SetupChartStyle

        /// <summary>
        /// Sets up the chart style.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupChartStyle(ChartXy chartXy)
        {
            ChartXyVisualStyle xystyle = chartXy.ChartVisualStyle;

            xystyle.Background = new Background(Color.LightSteelBlue, Color.WhiteSmoke, BackFillType.ForwardDiagonalCenter);
            xystyle.BorderThickness = new Thickness(1);
            xystyle.BorderColor = new BorderColor(Color.Black);
            xystyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(10);
        }

        #endregion

        #region SetupContainerStyle

        /// <summary>
        /// Sets up the chart's container style.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupContainerStyle(ChartXy chartXy)
        {
            ContainerVisualStyle dstyle = chartXy.ContainerVisualStyles.Default;

            dstyle.Background = new Background(Color.White);
            dstyle.BorderColor = new BorderColor(Color.DimGray);
            dstyle.BorderThickness = new Thickness(1);

            dstyle.DropShadow.Enabled = Tbool.True;
            dstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(6);
        }

        #endregion

        #region SetupChartLegend

        /// <summary>
        /// Sets up the Legend style.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupChartLegend(ChartXy chartXy)
        {
            //ChartLegend legend = chartXy.Legend;

            //legend.ShowCheckBoxes = false;

            //legend.Placement = Placement.Inside;
            //legend.Alignment = Alignment.TopCenter;
            //legend.Direction = Direction.LeftToRight;

            //legend.AlignVerticalItems = true;

            //ChartLegendVisualStyle lstyle = legend.ChartLegendVisualStyles.Default;

            //lstyle.BorderThickness = new Thickness(1);
            //lstyle.BorderColor = new BorderColor(Color.Red);

            //lstyle.Margin = new DevComponents.DotNetBar.Charts.Style.Padding(8);
            //lstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(4);

            //lstyle.Background = new Background(Color.FromArgb(200, Color.White));
        }

        #endregion

        #region AddChartTitle

        /// <summary>
        /// Sets up the chart title style.
        /// </summary>
        /// <param name="chartXy"></param>
        private void AddChartTitle(ChartXy chartXy)
        {
            ChartTitle title = new ChartTitle();

            title.Text = "Memory Consumption By Processes";

            title.XyAlignment = XyAlignment.Top;

            ChartTitleVisualStyle tstyle = title.ChartTitleVisualStyle;

            tstyle.Font = new Font("Georgia", 16);
            tstyle.TextColor = Color.Navy;
            tstyle.Alignment = Alignment.MiddleCenter;
            tstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(10);

            chartXy.Titles.Add(title);
        }

        #endregion

        #region AddSeries

        /// <summary>
        /// Adds a series to the given chart.
        /// </summary>
        /// <param name="chartXy"></param>
        public void AddSeries(ChartXy chartXy)
        {
            // Let's load our data in from our app resources.

            System.Diagnostics.PerformanceCounter cpuCounter;
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfProc_Process");

            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            //get collection of WMI objects
            ManagementObjectCollection data = searcher.Get();
            //List<string> data = ShellServices.LoadText("BubblePlot_Life.Resources.LifeExpectancy.txt");

            // data.Sort();

            string lastPosition = string.Empty;

            ChartSeries series = null;

            // Iterate through each data element, creating new series based
            // upon the associated Country name.

            foreach (var item in data)
            {
                if (int.Parse(item["IDProcess"].ToString()) != 0)
                {
                     string s = item["Name"] + "\t" + "Process" + "\t" + item["IDProcess"] + "\t" +
                               item["WorkingSet"] + "\t" + item["PercentProcessorTime"] + "\t" + item["WorkingSet"];
                    CountryInfo cinfo = new CountryInfo(s);

                    if (series == null || series.Name.Equals(cinfo.ProcessName) == false)
                    {
                        // Add the current series, and create the new country series.

                        if (series != null)
                            chartXy.ChartSeries.Add(series);

                        series = new ChartSeries(cinfo.ProcessName, SeriesType.Bubble);

                       

                        // Locate our predefined series style, and use it
                        // to establish the series look and feel.

                        //SeriesStyle ss = GetSeriesStyle(cinfo.Country);
                        //Random rdm = new Random();
                        //KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                        //KnownColor randomColorName = names[rdm.Next(names.Length)];
                        //Color rdmColor = Color.FromKnownColor(randomColorName);
                        //ss.MarkerColor = rdmColor;

                        ChartSeriesVisualStyle sstyle =series.ChartSeriesVisualStyle;
                        PointMarkerVisualStyle pstyle = sstyle.MarkerVisualStyle;
                        sstyle.ItemColor = Color.Black;
                        pstyle.BorderColor = Color.FromArgb(150, Color.WhiteSmoke);
                        pstyle.BorderWidth = 2;
                       // pstyle.Background = new Background(Color.FromArgb(128, ss.MarkerColor));

                        pstyle = sstyle.MarkerHighlightVisualStyle;

                        pstyle.BorderColor = Color.White;
                        pstyle.BorderWidth = 4;
                    }

                    // Our SeriesPoint defines the x/y coordinate (GDP/LifeExpectancy),
                    // plus the relative bubble size (Size).

                    series.SeriesPoints.Add(new
                        SeriesPoint(cinfo.ProcessID, cinfo.MemoryUsage, cinfo.Size));
                }

                if (series != null)
                    chartXy.ChartSeries.Add(series);
            }
        }

        #region GetSeriesStyle

        /// <summary>
        /// Gets our predefined series style for the given country.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private SeriesStyle GetSeriesStyle(string country)
        {
            foreach (SeriesStyle ss in _SeriesStyles)
            {
                if (ss.Country.Equals(country))
                    return (ss);
            }

            return (_SeriesStyles[0]);
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region Class CountryInfo

        /// <summary>
        /// Class def defining out Series data
        /// </summary>
        public class CountryInfo
        {
            // country, region, GDP, expectancy, population, size

            public string ProcessName;
            //public string Region;
            public long ProcessID;
            public long MemoryUsage;
            public long Size;

            public CountryInfo(string s)
            {
                string[] data = s.Split('\t');

                ProcessName = data[0];
                //Region = data[1];

                ProcessID = int.Parse(data[2]);
                MemoryUsage = long.Parse(data[3])/1000;
                Size = long.Parse(data[5])/1000;
            }
        }

        #endregion

        #region Class SeriesStyle

        /// <summary>
        /// Class def defining our predefined country styles
        /// </summary>
        public class SeriesStyle
        {
            public string Country;
            public Color MarkerColor;

            public SeriesStyle(
                string country, Color markerColor)
            {
                Country = country;
                MarkerColor = markerColor;
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            _chartXy.ChartSeries.Clear();
           AddSeries(_chartXy);
        }
    }
}
