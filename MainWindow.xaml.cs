using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AlgorithmVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        List<float> lines=new List<float>();
        List<float> initialLines;
        DispatcherTimer timer = new DispatcherTimer();

        public int widthInPixels = 800;// 5px width per line => 800/5 = 160 lines
        readonly int lineQuantity = 157;
        readonly int MaxLineHeight = 365;

        SortAlgorithm currentAlgorithm;
        public MainWindow()
        {
            InitializeComponent();
            AlgComboBox.DataContext = new ComboBoxViewModel();
            timer.Interval = TimeSpan.FromMilliseconds(0.001);
            //timer.Tick += TimerTickInsertion;
            timer.Tick += TimerTickSorting;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                currentAlgorithm.Reset();
            }
            if(initialLines != null)
            {
                lines = initialLines.GetRange(0, initialLines.Count);
                Fill_Canvas(lines);
            }
            else
            {
                MessageBox.Show("Generate random lines first!","There's nothing to reset",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                GenerateNewLines(lines);
                currentAlgorithm.Reset();
                timer.Start();
            }
            GenerateNewLines(lines);
            initialLines = lines.GetRange(0,lines.Count);
        }
        void GenerateNewLines(List<float> lines)
        {
            Fill_Lines(lines);
            Fill_Canvas(lines);
        }
        void Fill_Canvas(List<float>lines)
        {
            canvas.Children.Clear();
            for (int i = 0; i < lineQuantity*5; i += 5)
            {
                Line myLine = new Line()
                {
                    X1 = i+3,//offset for the first line because its 5px thick
                    Y1 = 0,
                    X2 = i+3,
                    Y2 = lines[i / 5],
                    Stroke = Brushes.Gray,
                    StrokeThickness = 5
                };
                canvas.Children.Add(myLine);
            }
        }
        void Fill_Lines(List<float> list)
        {
            list.Clear();
 
            for (int i = 0; i < lineQuantity*5; i+=5)
            {
                list.Add((float)rand.NextDouble() * MaxLineHeight);
            }
        }
        void Refresh(object o, EventArgs e)
        {
            canvas.Children.Clear();

            for (int i = 0; i < lineQuantity*5; i += 5)
            {
                Line myLine = new Line()
                {
                    X1 = i + 3,
                    Y1 = 0,
                    X2 = i + 3,
                    Y2 = lines[i / 5],
                    Stroke = Brushes.Gray,
                    StrokeThickness = 5
                };
                canvas.Children.Add(myLine);
            }
        }
        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentAlgorithm == null)
            {
                MessageBox.Show("Choose any algorithm from the dropdown list", "No sorting algorithm selected", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            timer.Start();
        }
        void TimerTickSorting(object o, EventArgs e)
        {
            currentAlgorithm.Sort(lines);
        }
        private void AlgComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ComboBox = sender as ComboBox;
            var viewModel = ComboBox.DataContext as ComboBoxViewModel;
            currentAlgorithm = viewModel.SelectedAlgorithm;
            currentAlgorithm.RefreshEventHandler += Refresh;
            currentAlgorithm.FinishedSortingEventHandler += finishedSorting;

        }
        void finishedSorting(object o, EventArgs e)
        {
            timer.Stop();
        }
    }
}// ((Line)canvas.Children[j]).SetValue(Line.StrokeProperty, Brushes.Gold); changing line color code
