using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmVisualizer
{
    internal class BubbleSort : SortAlgorithm
    {
        int iter_i = 0;
        int iter_j = 0;
        public override string AlgName => "Bubble Sort";
        public override void Sort(List<float> lines)
        {
            if (iter_i < lines.Count)
            {
                if (iter_j < lines.Count - 1 - iter_i)
                {
                    if (lines[iter_j] > lines[iter_j + 1])
                    {
                        Swap(lines, iter_j, iter_j + 1);
                        OnRefresh();//Refresh(lines);
                        //((Line)canvas.Children[iter_j + 1]).SetValue(Line.StrokeProperty, Brushes.White);
                    }
                    else
                    {
                        //((Line)canvas.Children[iter_j]).SetValue(Line.StrokeProperty, Brushes.Red);
                    }
                    iter_j++;
                }
                else
                {
                    iter_i++;
                    iter_j = 0;
                }
            }
            else
            {
                OnFinished();//timer.stop
                Reset();
                OnRefresh();// Refresh(canvas, lines);
            }
        }
        public override void Reset()
        {
            iter_i = 0;
            iter_j = 0;
        }
    }
}
