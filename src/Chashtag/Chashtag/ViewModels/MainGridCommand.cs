using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                if ((viewModel.isDFS != false || viewModel.isBFS != false) && viewModel.FilePath != "")
                {
                    
                    if (viewModel.isBFS)
                    {
                        viewModel.BFS = new TreasureHunt.BFS(viewModel.FilePath);
                        CreateGrid(viewModel);
                        //viewModel.BFS.driver();
                    }
                }
                else
                {
                    if (viewModel.isDFS == false && viewModel.isBFS == false)
                        throw new Exception("Algortima Belum Dipilih");
                    else if (viewModel.FilePath == "")
                        throw new Exception("File .txt Belum Dimasukkan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //viewModel.
            }
        }

        public void CreateGrid(MainViewModel viewModel)
        {
            viewModel.Canvas.Children.Clear();
            viewModel.GridButtons.Clear();
            int sizex = viewModel.BFS.getSizeX();
            int sizey = viewModel.BFS.getSizeY();
            char[,] maze = viewModel.BFS.getMatrix();

            int sizeKotak = (int)(viewModel.Canvas.ActualHeight);

            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    Button kotak = new Button();

                    string _name = "N" + i.ToString() + j.ToString();
                    kotak.Name = _name;
                    kotak.Width = sizex;
                    kotak.Height = sizey;
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
                        kotak.Content = "Treasure";
                        warna = new SolidColorBrush(Color.FromRgb(10, 100, 20));
                    }
                    kotak.Background = warna;
                    kotak.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));

                    kotak.Margin = new Thickness(i * sizeKotak, j * sizeKotak, 0, 0);
                    viewModel.GridButtons.Add(_name, kotak);
                    viewModel.Canvas.Children.Add(viewModel.GridButtons[_name]);
                }
            }
            throw new Exception(sizeKotak.ToString() + "Pass");
        }
    }
}
