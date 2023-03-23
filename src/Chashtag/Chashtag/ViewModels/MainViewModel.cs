using System;
using System.Collections.Generic;
using System.Linq;
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

        private double? _time;
        public double Time
        {
            get
            {
                if ( _time == null)
                {
                    _time = double.MinValue;
                }
                return (double) _time; 
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

        public Dictionary<string,Button> GridButtons;

        public ICommand OpenFileCommand { get; }
        public ICommand StartProcess { get; }

        public MainViewModel()
        {
            //FileName = null;
            Canvas = (Canvas)Application.Current.MainWindow.FindName("labirin");
            Border = (Border)Application.Current.MainWindow.FindName("border");
            GridButtons = new Dictionary<string,Button>();  
            OpenFileCommand = new OpenFileCommand(this);
            StartProcess = new StartProcess(this);

        }
    }
}
