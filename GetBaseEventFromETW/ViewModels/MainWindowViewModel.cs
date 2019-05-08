using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Common;
using GraphSharp.Algorithms.Layout.Simple.Tree;
using GraphSharp.Controls;



namespace GetBaseEventFromETW
{
    public class PocGraphLayout : GraphLayout<PocVertex, PocEdge, PocGraph> { }



    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Data

        private string _layoutAlgorithmType;
        private PocGraph _graph;
        private readonly List<String> _layoutAlgorithmTypes = new List<string>();
        private SimpleTreeLayoutParameters _treeLayoutParameters;
        private static List<string> allProcessString = new List<string>();
        private static List<ProcessTreeMine> psTreeMine = new List<ProcessTreeMine>();
        #endregion

        #region Ctor
        public MainWindowViewModel(string processHistory)
        {
            Graph = new PocGraph(true);

            List<PocVertex> existingVertices = new List<PocVertex>();

            //existingVertices.Reverse();
            //existingVertices.Add(new PocVertex("Sacha Barber", true)); //0
            //existingVertices.Add(new PocVertex("Sarah Barber", false)); //1
            existingVertices.Add(new PocVertex("Child Process", true)); //2
            existingVertices.Add(new PocVertex("Parent Process", true)); //2


            foreach (PocVertex vertex in existingVertices)
                Graph.AddVertex(vertex);

            if (existingVertices.Count > 0)
            {
                int nodecount = existingVertices.Count;
                //add some edges to the graph
                while (nodecount - 1 > 0)
                {
                    int current = nodecount - 1;
                    int next = current - 1;
                    AddNewGraphEdge(existingVertices[current], existingVertices[next]);
                    nodecount--;
                }

            }

            //Add Layout Algorithm Types
            ConfigLayoutAlgorithmType();

            //Pick a default Layout Algorithm Type
            LayoutAlgorithmType = "EfficientSugiyama";
            //ReLayoutGraph();



        }

        public MainWindowViewModel(List<string> allProcess, List<ProcessTreeMine> psTree)
        {
            allProcessString = allProcess;
            psTreeMine = psTree;
            Graph = new PocGraph(true);
            allProcess.RemoveRange(0, 2);
            List<PocVertex> existingVertices = new List<PocVertex>();
            existingVertices.Add(new PocVertex("Start_Process", true));
            foreach (var item in allProcess)
            {
                if (HashClass.UnPermittedProcess.FirstOrDefault(x=>item.ToLower().Contains(x.ToLower().Replace(".exe","")))!=null)
                    existingVertices.Add(new PocVertex(item, false, item));
                else
                    existingVertices.Add(new PocVertex(item, true, item));
            }
            foreach (var existingVertex in existingVertices)
            {
                Graph.AddVertex(existingVertex);
            }
            foreach (var item in psTree)
            {
                AddNewGraphEdge(existingVertices[0], existingVertices.FirstOrDefault(x => x.ID == item.fatherName) ?? new PocVertex("NullProcess", false));
                if (item.ChildList.Count > 0)
                {
                    foreach (var processTreeMine in item.ChildList)
                    {
                        GenerateTree(processTreeMine, item.fatherName, existingVertices);
                    }
                }
                //else
                //{
                //    AddNewGraphEdge(existingVertices[0], existingVertices.FirstOrDefault(x => x.ID==item.fatherName)??new PocVertex("NullProcess",false));
                //}
            }
            TreeLayoutParameters = new SimpleTreeLayoutParameters();
            TreeLayoutParameters.Direction = GraphSharp.Algorithms.Layout.LayoutDirection.TopToBottom; //THIS IS WHAT YOU EXPECT
            TreeLayoutParameters.LayerGap = 200.0;
            TreeLayoutParameters.OptimizeWidthAndHeight = true;
            //TreeLayoutParameters.SpanningTreeGeneration =SpanningTreeGeneration.DFS;
            TreeLayoutParameters.VertexGap = 1.0;
            TreeLayoutParameters.WidthPerHeight = 1.0;

            ConfigLayoutAlgorithmType();
            //Pick a default Layout Algorithm Type
            LayoutAlgorithmType = "ISOM";
        }

        private void GenerateTree(ProcessTreeMine psobj, string fatherName, List<PocVertex> existingVertices)
        {
            if (psobj != null)
            {
                AddNewGraphEdge(existingVertices.FirstOrDefault(x => x.ID == fatherName),
                        existingVertices.FirstOrDefault(x => x.ID == psobj.fatherName));
                if (psobj.ChildList.Count > 0)
                {
                    foreach (var processTreeMine in psobj.ChildList)
                    {
                        GenerateTree(processTreeMine, psobj.fatherName, existingVertices);
                    }
                }

            }
        }

        #endregion

        private void ConfigLayoutAlgorithmType()
        {
            _layoutAlgorithmTypes.Add("BoundedFR");
            _layoutAlgorithmTypes.Add("Circular");
            _layoutAlgorithmTypes.Add("CompoundFDP");
            _layoutAlgorithmTypes.Add("EfficientSugiyama");
            _layoutAlgorithmTypes.Add("FR");
            _layoutAlgorithmTypes.Add("ISOM");
            _layoutAlgorithmTypes.Add("KK");
            _layoutAlgorithmTypes.Add("LinLog");
            _layoutAlgorithmTypes.Add("Tree");
        }

        public void ReLayoutGraph(string processHistory)
        {
            _graph = new PocGraph(true);


            List<PocVertex> existingVertices = new List<PocVertex>();
            int countX = 0;
            foreach (var item in processHistory.Split('*'))
            {

                if (countX % 2 == 1)
                {
                    existingVertices.Add(new PocVertex(item, true));
                }
                countX++;
            }
            //existingVertices.Add(new PocVertex(String.Format("Barn Rubble{0}", count), true)); //0
            //existingVertices.Add(new PocVertex(String.Format("Frank Zappa{0}", count), false)); //1
            //existingVertices.Add(new PocVertex(String.Format("Gerty CrinckleBottom{0}", count), true)); //2


            foreach (PocVertex vertex in existingVertices)
                Graph.AddVertex(vertex);

            if (existingVertices.Count > 0)
            {
                int nodecount = existingVertices.Count;
                //add some edges to the graph
                while (nodecount - 1 > 0)
                {
                    int current = nodecount - 1;
                    int next = current - 1;
                    AddNewGraphEdge(existingVertices[current], existingVertices[next]);
                    nodecount--;
                }


            }
            ////add some edges to the graph
            //AddNewGraphEdge(existingVertices[0], existingVertices[1]);
            //AddNewGraphEdge(existingVertices[0], existingVertices[2]);


            NotifyPropertyChanged("Graph");




        }

        public void ReLayoutGraph()
        {
            //new MainWindowViewModel(allProcessString, psTreeMine);
        }

        #region Private Methods
        private PocEdge AddNewGraphEdge(PocVertex from, PocVertex to)
        {
            string edgeString = string.Format("{0}-{1} Connected", from.ID, to.ID);

            PocEdge newEdge = new PocEdge(edgeString, from, to);
            Graph.AddEdge(newEdge);
            return newEdge;
        }


        #endregion

        #region Public Properties

        public List<String> LayoutAlgorithmTypes
        {
            get { return _layoutAlgorithmTypes; }
        }


        public string LayoutAlgorithmType
        {
            get { return _layoutAlgorithmType; }
            set
            {
                _layoutAlgorithmType = value;
                NotifyPropertyChanged("LayoutAlgorithmType");
            }
        }


        public SimpleTreeLayoutParameters TreeLayoutParameters
        {
            get
            {
                return _treeLayoutParameters;
            }
            set
            {
                _treeLayoutParameters = value;
                NotifyPropertyChanged("TreeLayoutParameters");
            }
        }
        public PocGraph Graph
        {
            get { return _graph; }
            set
            {
                _graph = value;
                NotifyPropertyChanged("Graph");
            }
        }
        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
                catch
                {
                }
            }
        }

        #endregion
    }
}
