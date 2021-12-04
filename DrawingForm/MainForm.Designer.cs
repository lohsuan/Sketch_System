
namespace DrawingForm
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._clear = new System.Windows.Forms.Button();
            this._ellipse = new System.Windows.Forms.Button();
            this._rectangle = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // _rectangle
            this._rectangle.Location = new System.Drawing.Point(100, 10);
            this._rectangle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(150, 30);
            this._rectangle.TabIndex = 2;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleShapeButtonClick);

            // _ellipse
            this._ellipse.Location = new System.Drawing.Point(375, 10);
            this._ellipse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(150, 30);
            this._ellipse.TabIndex = 1;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            this._ellipse.Click += new System.EventHandler(this.HandleShapeButtonClick);

            // _clear
            this._clear.Location = new System.Drawing.Point(650, 10);
            this._clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(150, 30);
            this._clear.TabIndex = 0;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this._rectangle);
            this.Controls.Add(this._ellipse);
            this.Controls.Add(this._clear);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _clear;
    }
}

