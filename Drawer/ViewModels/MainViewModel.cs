using Drawer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Drawer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ItemsControl _canvas;
        private ObservableCollection<IShape> _shapes;
        public ObservableCollection<IShape> Shapes
        {
            get { return _shapes; }
            set
            {
                if(_shapes != value)
                {
                    _shapes = value;
                    OnPropertyChanged(nameof(Shapes));
                }
            }
        }

        public MainViewModel(ItemsControl canvas)
        {
            _canvas = canvas;
            _shapes = new ObservableCollection<IShape>();
            _canvas.MouseDown += OnMouseDown;
            _canvas.MouseMove += OnMouseMove;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // dla luznego rysowania
            var line = new LineModel
            {
                X1 = (int)e.GetPosition(_canvas).X,
                Y1 = (int)e.GetPosition(_canvas).Y,
                X2 = (int)e.GetPosition(_canvas).X,
                Y2 = (int)e.GetPosition(_canvas).Y,
                Brush = Brushes.Blue,
                Stroke = 2.0
            };
            Shapes.Add(line);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {

            // dla luznego rysowania
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                var prev = Shapes.Last() as LineModel;
                var line = new LineModel
                {
                    X1 = prev.X2,
                    Y1 = prev.Y2,
                    X2 = (int)e.GetPosition(_canvas).X,
                    Y2 = (int)e.GetPosition(_canvas).Y,
                    Brush = Brushes.Blue,
                    Stroke = 2.0
                };
                Shapes.Add(line);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
