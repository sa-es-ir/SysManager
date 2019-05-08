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
using Common;


namespace GetBaseEventFromETW
{
    /// <summary>
    /// Interaction logic for ProcessGraph.xaml
    /// </summary>
    public partial class ProcessGraph : UserControl
    {
        private MainWindowViewModel vm;
        public ProcessGraph(string processHistory)
        {
            vm = new MainWindowViewModel(processHistory);
            GraphSharp.Algorithms.Layout.Simple.Tree.SimpleTreeLayoutParameters dds =
                new GraphSharp.Algorithms.Layout.Simple.Tree.SimpleTreeLayoutParameters();
            
            this.DataContext = vm;
            
            InitializeComponent();
            
        }
        
        public ProcessGraph(List<string> AllProcess,List<ProcessTreeMine> psTree)
        {
            vm=new MainWindowViewModel(AllProcess,psTree);
            this.DataContext = vm;
            InitializeComponent();
        }
      

        public void RebuildGraph(string ph)
        {
            vm.ReLayoutGraph(ph);
        }
        public void RebuildGraph()
        {
            vm.ReLayoutGraph();
        }
        private void ProcessText_OnMouseEnter(object sender, MouseButtonEventArgs e)
        {
           
                var vm = (PocVertex)((StackPanel)sender).DataContext;

                MessageBox.Show(vm.ID);
           
        }

        private void FrameworkElement_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            RebuildGraph();
          
        }

        private void UIElement_OnFocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void GraphLayout_OnIsStylusCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
