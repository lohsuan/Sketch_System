using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        List<Button> _shapesButton = new List<Button>();

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _model._modelChanged += HandleModelChanged;

            _rectangle.Click += HandleShapeButtonClick;
            _ellipse.Click += HandleShapeButtonClick;
            _shapesButton.Add(_rectangle);
            _shapesButton.Add(_ellipse);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached. The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // HandleClearButtonClick
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        // HandleClearButtonClick
        private void HandleShapeButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (Button button in _shapesButton)
                button.IsEnabled = true;
            Button pressedButton = (Button)sender;
            pressedButton.IsEnabled = false;
            _model.ChangeShape(pressedButton.Content.ToString());
        }

        // HandleCanvasPressed
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.HandlePointerPressed(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleCanvasReleased
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            foreach (Button button in _shapesButton)
                button.IsEnabled = true;
            _model.HandlePointerReleased(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleCanvasMoved
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.HandlePointerMoved(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }
    }
}
