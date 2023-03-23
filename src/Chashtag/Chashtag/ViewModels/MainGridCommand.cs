using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using stima2;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;
using Color = System.Windows.Media.Color;

namespace Chashtag.ViewModels
{
    class StartProcess : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel viewModel;

        public StartProcess(MainViewModel sideGridViewModel)
        {
            viewModel = sideGridViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                viewModel.isRun = false;
                if ((viewModel.isDFS != false || viewModel.isBFS != false) && viewModel.FilePath != "")
                {

                    if (viewModel.isBFS)
                    {
                        viewModel.BFS = new TreasureHunt.BFS(viewModel.FilePath);
                        CreateGrid(viewModel);
                        viewModel.BFS.driver();
                        viewModel.Route = viewModel.BFS.getStringRoute();
                        viewModel.Node = viewModel.BFS.getCountNode();
                        viewModel.Step = viewModel.BFS.getCountStep();
                        viewModel.TimeExe = viewModel.BFS.getStringTimeExe();
                        viewModel._goroute = viewModel.BFS.getGoPath();
                        viewModel._backroute = viewModel.BFS.getBackPath();
                    }
                    if (viewModel.isDFS)
                    {
                        Graph _graph = new Graph(viewModel.FilePath);
                        _graph.setUpGraph();
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        viewModel.DFS = new Stima2.DFS(_graph);
                        viewModel.DFS.runDFS();
                        stopwatch.Stop();
                        CreateGrid(viewModel);
                        double _timeexe = (double)stopwatch.ElapsedTicks * 10 / Stopwatch.Frequency;
                        viewModel.Route = viewModel.DFS.getStringRoute();
                        viewModel.Node = viewModel.DFS.getCountNode();
                        viewModel.Step = viewModel.DFS.getCountSteps();
                        viewModel.TimeExe = _timeexe.ToString("F4") + " microsecond";
                        viewModel._goroute = viewModel.DFS.getGoPath();
                        viewModel._backroute = viewModel.DFS.getBackPath();
                    }
                    viewModel.isRun = true;
                }
                else
                {
                    viewModel.isRun = false;
                    if (viewModel.isDFS == false && viewModel.isBFS == false)
                        throw new Exception("Algortima Belum Dipilih");
                    else if (viewModel.FilePath == "")
                        throw new Exception("File .txt Belum Dimasukkan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CreateGrid(MainViewModel viewModel)
        {
            viewModel.Canvas.Children.Clear();
            viewModel.GridButtons.Clear();
            int sizex = 0, sizey = 0;
            char[,] maze;
            if (viewModel.isBFS)
            {
                sizex = viewModel.BFS.getSizeX();
                sizey = viewModel.BFS.getSizeY();
                maze = viewModel.BFS.getMatrix();
            }
            else
            {
                sizex = viewModel.DFS.getSizeX();
                sizey = viewModel.DFS.getSizeY();
                maze = viewModel.DFS.getMatrix();
            }

            int sizeKotak = (int)(viewModel.Canvas.ActualHeight - 10) / sizey;

            if (sizeKotak * sizex > viewModel.Canvas.ActualWidth)
            {
                sizeKotak = (int)(viewModel.Canvas.ActualWidth - 10) / sizex;
            }

            int j = 0, i = 0;
            for (i = 0; i < sizex; i++)
            {
                for (j = 0; j < sizey; j++)
                {
                    Button kotak = new Button();

                    string _name = "N" + i.ToString() + j.ToString();
                    kotak.Content = _name;
                    kotak.Width = sizeKotak;
                    kotak.Height = sizeKotak;
                    SolidColorBrush warna = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    if (maze[j, i] == 'K')
                    {
                        warna = new SolidColorBrush(Color.FromRgb(20, 150, 100));
                    }
                    else if (maze[j, i] == 'X')
                    {
                        warna = new SolidColorBrush(Color.FromRgb(60, 0, 200));
                    }
                    else if (maze[j, i] == 'R')
                    {
                        warna = new SolidColorBrush(Color.FromRgb(60, 100, 200));
                    }
                    else if (maze[j, i] == 'T')
                    {
                        //kotak.Content = "Treasure";
                        warna = new SolidColorBrush(Color.FromRgb(10, 100, 20));
                    }
                    kotak.Background = warna;
                    kotak.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    kotak.Margin = new Thickness(i * sizeKotak, j * sizeKotak, 0, 0);
                    viewModel.GridButtons.Add(_name, kotak);
                    viewModel.Canvas.Children.Add(viewModel.GridButtons[_name]);
                }
            }
            viewModel.Canvas.Margin = new Thickness((viewModel.Border.ActualWidth / 2 - (i * sizeKotak) / 2), (viewModel.Border.ActualHeight / 2 - (j * sizeKotak) / 2), 10, 10);
        }
    }
    class Visualization : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel viewModel;

        public Visualization(MainViewModel ViewModel)
        {
            viewModel = ViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            SolidColorBrush red = new SolidColorBrush(Colors.Red);
            SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow); 
            SolidColorBrush green = new SolidColorBrush(Colors.Green);

            int delay = 1000* viewModel.Time/100;

            for (int i = viewModel._goroute.Count - 1; i >= 0; i--)
            {
                Button btn = viewModel.GridButtons[viewModel._goroute[i]];
                btn.Background = red;
                if (btn.Content != null && btn.Content == "Treasure")
                    btn.Content = "Taken";
                await Task.Delay(delay);
                btn.Background = green;
            }
            for (int i = 0; i < viewModel._backroute.Count; i++)
            {
                Button btn = viewModel.GridButtons[viewModel._backroute[i]];
                btn.Background = yellow;
                await Task.Delay(delay);
                if (i != viewModel._backroute.Count-1)
                    btn.Background = green;

            }
        }
    }
}
