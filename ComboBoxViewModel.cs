using AlgorithmVisualizer.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualizer
{
    public class ComboBoxViewModel
    {
        private SortAlgorithm _selectedAlgorithm;
        public List<SortAlgorithm> SortAlgorithms { get; set; }

        public ComboBoxViewModel()
        {
            SortAlgorithms = new List<SortAlgorithm>() { new BubbleSort(), new InsertionSort(), new QuickSort()};
        }
        public SortAlgorithm SelectedAlgorithm
        {
            get{ return _selectedAlgorithm; }
            set { _selectedAlgorithm = value; }
        }
    }
}
