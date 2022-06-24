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
    public abstract class SortAlgorithm
    {
        public event EventHandler RefreshEventHandler;
        public event EventHandler FinishedSortingEventHandler;
        public abstract string AlgName { get; }
        public abstract void Sort(List<float> lines);
        public abstract void Reset();
        protected void Swap(List<float> lines, int i, int j)
        {
            float temp = lines[i];
            lines[i] = lines[j];
            lines[j] = temp;
        }
        protected virtual void OnRefresh()
        {
            var del = RefreshEventHandler as EventHandler;
            if (del != null)
            {
                RefreshEventHandler(this, EventArgs.Empty);
            }
        }
        protected virtual void OnFinished()
        {
            var del = FinishedSortingEventHandler as EventHandler;
            if(del != null)
            {
                FinishedSortingEventHandler(this, EventArgs.Empty);
            }
        }
    }
}
