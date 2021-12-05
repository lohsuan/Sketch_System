using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;
namespace DrawingApp.PresentationModel
{
    class PresentationModel
    {
        Model _model;
        IGraphics _iGraphics;
        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _iGraphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        // Draw
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_iGraphics);
        }
    }
}