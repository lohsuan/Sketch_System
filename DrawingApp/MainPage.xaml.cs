using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        private const string EMPTY_STRING = "";
        private const string SAVE_CONFIRM = "確定要儲存嗎?";
        private const string CONFIRM = "確定";
        private const string CANCEL = "取消";
        private const string LOAD_CONFIRM = "確定要重新載入?";
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        List<Button> _shapesButton = new List<Button>();

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            PrepareModelEventHandler();
            PrepareComponentEventHandler();
            _undo.IsEnabled = false;
            _redo.IsEnabled = false;
            _shapesButton.Add(_rectangle);
            _shapesButton.Add(_ellipse);
            _shapesButton.Add(_line);
        }

        // PrepareComponentEventHandler
        private void PrepareComponentEventHandler()
        {
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _rectangle.Click += HandleShapeButtonClick;
            _ellipse.Click += HandleShapeButtonClick;
            _line.Click += HandleShapeButtonClick;
            _undo.Click += UndoHandler;
            _redo.Click += RedoHandler;
            _save.Click += Save;
            _load.Click += Load;
        }

        // PrepareModelEventHandler
        private void PrepareModelEventHandler()
        {
            _model._modelChanged += HandleModelChanged;
            _model._shapeSelected += HandleShapeSelected;
            _model._shapeNotSelected += HandleShapeNotSelected;
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
            _line.IsEnabled = _model.IsLineButtonEnabled();
            HandleModelChanged();
        }

        // HandleCanvasMoved
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.HandlePointerMoved(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            _redo.IsEnabled = _model.IsRedoEnabled();
            _undo.IsEnabled = _model.IsUndoEnabled();
            _presentationModel.Draw();
        }

        // HandleShapeSelected
        public void HandleShapeSelected()
        {
            _shapeInfoTextBlock.Text = _model.GetShapeInfo();
        }

        // HandleShapeNotSelected
        public void HandleShapeNotSelected()
        {
            _shapeInfoTextBlock.Text = EMPTY_STRING;
        }

        // UndoHandler
        void UndoHandler(Object sender, RoutedEventArgs e)
        {
            _model.Undo();
            HandleModelChanged();
        }

        // RedoHandler
        void RedoHandler(Object sender, RoutedEventArgs e)
        {
            _model.Redo();
            HandleModelChanged();
        }

        // Save
        async void Save(Object sender, RoutedEventArgs e)
        {
            ContentDialog saveDialog = new ContentDialog();
            
            saveDialog.Title = SAVE_CONFIRM;
            saveDialog.PrimaryButtonText = CONFIRM;
            saveDialog.CloseButtonText = CANCEL;

            ContentDialogResult result = await saveDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await Task.Run(() =>
                {
                    _model.Save();
                });
                HandleModelChanged();
            }
        }

        // Load
        async void Load(Object sender, RoutedEventArgs e)
        {
            ContentDialog loadDialog = new ContentDialog();
            
            loadDialog.Title = LOAD_CONFIRM;
            loadDialog.PrimaryButtonText = CONFIRM;
            loadDialog.CloseButtonText = CANCEL;

            ContentDialogResult result = await loadDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await Task.Run(() =>
                {
                    _model.Load();
                });
                HandleModelChanged();
            }
        }
    }
}
