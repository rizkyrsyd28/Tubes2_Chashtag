using Chashtag.Views;
using Chashtag.Views.MainGrids;
using Stima2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TreasureHunt;

namespace Chashtag.ViewModels
{   
    class MainViewModel : ViewModelBase
    {
        private string _fileName;
        public string FileName
        {
            get
            {
                if (_fileName == null)
                {
                    _fileName = "";
                }
                return _fileName;
            }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        private string _filePath;
        public string FilePath
        {
            get
            {
                if (_filePath == null)
                {
                    _filePath = "";
                }
                return _filePath;
            }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        private int? _time;
        public int Time
        {
            get
            {
                if ( _time == null)
                {
                    _time = int.MinValue;
                }
                return (int) _time; 
            }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        private bool is_bfs;
        public bool isBFS
        {
            get
            {
                return is_bfs;
            }
            set
            {
                is_bfs = value;
                OnPropertyChanged(nameof(isBFS));
            }
        }

        private bool is_dfs;
        public bool isDFS
        {
            get
            {
                return is_dfs;
            }
            set
            {
                is_dfs = value;
                OnPropertyChanged(nameof(isDFS));
            }
        }

        private bool is_tsp;
        public bool isTSP
        {
            get { return is_tsp; }
            set
            {
                is_tsp = value;
                OnPropertyChanged(nameof(isTSP));
            }
        }

        private BFS _bfs;
        public BFS BFS
        {
            get { return _bfs; }
            set
            {
                _bfs = value;
                OnPropertyChanged(nameof(_bfs));
            }
        }
        private DFS _dfs;
        public DFS DFS
        {
            get { return _dfs; }
            set
            {
                _dfs = value;
                OnPropertyChanged(nameof(_dfs));
            }
        }


        private Canvas _canvas;
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = new Canvas();
                }
                return _canvas;
            }
            set
            {
                if ( _canvas != value)
                {
                    _canvas = value;
                    OnPropertyChanged(nameof(Canvas));
                }
            }
        }
        private Border _border;
        public Border Border
        {
           
            get
            {
                if (_border == null)
                {
                    _border = new Border();
                }
                return _border;
            }
            set
            {
                if ( _border != value)
                {
                    _border = value;
                    OnPropertyChanged(nameof(Border));
                }
            }
            
        }

        private string _route;
        public string Route
        {
            get
            {
                return _route;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _route = value;
                    OnPropertyChanged(nameof(Route));
                }
            }
        }

        private int _node;
        public int Node
        {
            get
            {
                return _node;
            }
            set
            {
                if (_node != value)
                {
                    _node = value;
                    OnPropertyChanged(nameof(Node));
                }
            }
        }

        private int _step;
        public int Step
        {
            get
            {
                return _step;
            }
            set
            {
                if ( value != _step)
                {
                    _step = value;
                    OnPropertyChanged(nameof(Step));
                }
            }
        }

        private string _timeexe;
        public string TimeExe
        {
            get
            {
                return _timeexe;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _timeexe = value;
                    OnPropertyChanged(nameof(TimeExe));
                }
            }
        }
        public bool isRun;
        public bool isVisual;
        public List<string> _goroute;
        public List<string> _backroute;

        public Dictionary<string,Button> GridButtons;

        public ICommand OpenFileCommand { get; }
        public ICommand StartProcess { get; }
        public ICommand Visualization { get; }

        public MainViewModel(MainWindow mainwin)
        {
            isRun = false;
            isVisual = false;
            var canvasGrid = mainwin.viewbase.MainGrid.CanvasGrid;
            Border = (Border)canvasGrid.FindName("border");
            Canvas = (Canvas)canvasGrid.FindName("labirin");
            GridButtons = new Dictionary<string,Button>();  
            OpenFileCommand = new OpenFileCommand(this);
            StartProcess = new StartProcess(this);
            Visualization = new Visualization(this);
        }
    }
}
