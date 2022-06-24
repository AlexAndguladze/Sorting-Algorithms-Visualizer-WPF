using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualizer.SortingAlgorithms
{
    internal class QuickSort : SortAlgorithm
    {
        public override string AlgName => "Quick sort";
        int low;
        int high;
        bool iterate = false;
        int[] stack;
        int top;
        public override void Sort(List<float> lines)
        {
            if (iterate == false)
            {
                Quick_Sort(lines, 0, lines.Count - 1, iterate);
            }
            Quick_Sort(lines, low, high, iterate);
        }
        private void Quick_Sort(List<float> lines, int l, int h, bool iterate)
        {
            if (iterate == false)
            {
                stack = new int[h - l + 1];

                top = -1;

                stack[++top] = l;
                stack[++top] = h;
                this.iterate = true;
            }

            
            //while
            if (top >= 0)
            {
                //OnRefresh();
                //pop h and l
                h = stack[top--];
                l = stack[top--];
                high = h;
                low = l;
                int p = Partition(lines, low, high);
                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }

                if (p + 1 < h)
                {
                    stack[++top] = p + 1;
                    stack[++top] = h;
                }
                //OnRefresh();
            }
            else
            {
                OnRefresh();
                Reset();
                OnFinished();
            }
        }

        private int Partition(List<float> lines, int low, int high)
        {
            float partitionPivot=lines[high];

            //index of a smaller element
            int i = (low - 1);
            for(int j=low; j <= high - 1; j++)
            {
                //If current element is smaller
                //than or equal to pivot
                if(lines[j] <= partitionPivot)
                {
                    i++;
                    Swap(lines, i, j);
                    OnRefresh();
                }
            }
            Swap(lines,i+1,high);
            OnRefresh();
            return i + 1;
            
        }

        public override void Reset()
        {
            iterate = false;
        }

        
    }
}
