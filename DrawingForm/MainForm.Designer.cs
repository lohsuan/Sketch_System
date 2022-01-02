
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
            this._line = new System.Windows.Forms.Button();
            this._rectangle = new System.Windows.Forms.Button();
            this._shapeInfoLabel = new System.Windows.Forms.Label();
            this._save = new System.Windows.Forms.Button();
            this._load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(461, 35);
            this._clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(130, 30);
            this._clear.TabIndex = 0;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _ellipse
            // 
            this._ellipse.Location = new System.Drawing.Point(319, 35);
            this._ellipse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(130, 30);
            this._ellipse.TabIndex = 1;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            this._ellipse.Click += new System.EventHandler(this.HandleShapeButtonClick);
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(171, 35);
            this._line.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(130, 30);
            this._line.TabIndex = 3;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleShapeButtonClick);
            // 
            // _rectangle
            // 
            this._rectangle.Location = new System.Drawing.Point(26, 35);
            this._rectangle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(130, 30);
            this._rectangle.TabIndex = 2;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleShapeButtonClick);
            // 
            // _shapeInfoLabel
            // 
            this._shapeInfoLabel.AccessibleName = "_shapeInfoLabel";
            this._shapeInfoLabel.AutoSize = true;
            this._shapeInfoLabel.Location = new System.Drawing.Point(631, 557);
            this._shapeInfoLabel.Name = "_shapeInfoLabel";
            this._shapeInfoLabel.Size = new System.Drawing.Size(0, 15);
            this._shapeInfoLabel.TabIndex = 4;
            // 
            // _save
            // 
            this._save.Location = new System.Drawing.Point(608, 35);
            this._save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(130, 30);
            this._save.TabIndex = 6;
            this._save.Text = "Save";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _load
            // 
            this._load.Location = new System.Drawing.Point(753, 35);
            this._load.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._load.Name = "_load";
            this._load.Size = new System.Drawing.Size(130, 30);
            this._load.TabIndex = 5;
            this._load.Text = "Load";
            this._load.UseVisualStyleBackColor = true;
            this._load.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this._save);
            this.Controls.Add(this._load);
            this.Controls.Add(this._shapeInfoLabel);
            this.Controls.Add(this._rectangle);
            this.Controls.Add(this._line);
            this.Controls.Add(this._ellipse);
            this.Controls.Add(this._clear);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.Label _shapeInfoLabel;
        private System.Windows.Forms.Button _save;
        private System.Windows.Forms.Button _load;
    }
}

