using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualizer.SortingAlgorithms
{
    internal class InsertionSort : SortAlgorithm
    {
        public override string AlgName => "Insertion sort";
        int iter_i = 0;
        public override void Sort(List<float> lines)
        {
            if (iter_i < lines.Count - 1)
            {
                int j = iter_i + 1;
                while (j > 0 && lines[j] < lines[j - 1])
                {
                    Swap(lines, j, j - 1);
                    j--;
                    OnRefresh();
                    
                }
                iter_i++;
            }
            else
            {
                OnFinished();
                Reset();
            }
        }
        public override void Reset()
        {
            iter_i = 0;
        }

    }
}
