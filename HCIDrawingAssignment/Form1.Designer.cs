namespace HCIDrawingAssignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.freehandButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.squareButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polygonButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.cutButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.pinButton = new System.Windows.Forms.Button();
            this.unpinButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.colourButton = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.selectedColorBox = new System.Windows.Forms.PictureBox();
            this.drawingSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.drawingOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.modeLabel);
            this.flowLayoutPanel1.Controls.Add(this.freehandButton);
            this.flowLayoutPanel1.Controls.Add(this.lineButton);
            this.flowLayoutPanel1.Controls.Add(this.rectangleButton);
            this.flowLayoutPanel1.Controls.Add(this.squareButton);
            this.flowLayoutPanel1.Controls.Add(this.ellipseButton);
            this.flowLayoutPanel1.Controls.Add(this.circleButton);
            this.flowLayoutPanel1.Controls.Add(this.polygonButton);
            this.flowLayoutPanel1.Controls.Add(this.colourButton);
            this.flowLayoutPanel1.Controls.Add(this.selectedColorBox);
            this.flowLayoutPanel1.Controls.Add(this.selectButton);
            this.flowLayoutPanel1.Controls.Add(this.selectedLabel);
            this.flowLayoutPanel1.Controls.Add(this.copyButton);
            this.flowLayoutPanel1.Controls.Add(this.cutButton);
            this.flowLayoutPanel1.Controls.Add(this.pasteButton);
            this.flowLayoutPanel1.Controls.Add(this.undoButton);
            this.flowLayoutPanel1.Controls.Add(this.redoButton);
            this.flowLayoutPanel1.Controls.Add(this.pinButton);
            this.flowLayoutPanel1.Controls.Add(this.unpinButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.loadButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 529);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // freehandButton
            // 
            this.freehandButton.Location = new System.Drawing.Point(3, 16);
            this.freehandButton.Name = "freehandButton";
            this.freehandButton.Size = new System.Drawing.Size(75, 23);
            this.freehandButton.TabIndex = 0;
            this.freehandButton.Text = "Freehand";
            this.freehandButton.UseVisualStyleBackColor = true;
            this.freehandButton.Click += new System.EventHandler(this.freehandButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(3, 45);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 1;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(3, 74);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 23);
            this.rectangleButton.TabIndex = 2;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // squareButton
            // 
            this.squareButton.Location = new System.Drawing.Point(3, 103);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(75, 23);
            this.squareButton.TabIndex = 3;
            this.squareButton.Text = "Square";
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(3, 132);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(3, 161);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 5;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(3, 190);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(75, 23);
            this.polygonButton.TabIndex = 6;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(3, 248);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(52, 23);
            this.selectButton.TabIndex = 7;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(3, 277);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 8;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // cutButton
            // 
            this.cutButton.Location = new System.Drawing.Point(3, 306);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(75, 23);
            this.cutButton.TabIndex = 9;
            this.cutButton.Text = "Cut";
            this.cutButton.UseVisualStyleBackColor = true;
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(3, 335);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 10;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(3, 364);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 11;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(3, 393);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(75, 23);
            this.redoButton.TabIndex = 12;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // pinButton
            // 
            this.pinButton.Location = new System.Drawing.Point(3, 422);
            this.pinButton.Name = "pinButton";
            this.pinButton.Size = new System.Drawing.Size(75, 23);
            this.pinButton.TabIndex = 13;
            this.pinButton.Text = "Pin";
            this.pinButton.UseVisualStyleBackColor = true;
            this.pinButton.Click += new System.EventHandler(this.pinButton_Click);
            // 
            // unpinButton
            // 
            this.unpinButton.Location = new System.Drawing.Point(3, 451);
            this.unpinButton.Name = "unpinButton";
            this.unpinButton.Size = new System.Drawing.Size(75, 23);
            this.unpinButton.TabIndex = 14;
            this.unpinButton.Text = "Unpin";
            this.unpinButton.UseVisualStyleBackColor = true;
            this.unpinButton.Click += new System.EventHandler(this.unpinButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(3, 509);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 16;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // colourButton
            // 
            this.colourButton.Location = new System.Drawing.Point(3, 219);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(52, 23);
            this.colourButton.TabIndex = 17;
            this.colourButton.Text = "Colour";
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.colourButton_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(3, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(52, 13);
            this.modeLabel.TabIndex = 1;
            this.modeLabel.Text = "Freehand";
            // 
            // canvasBox
            // 
            this.canvasBox.BackColor = System.Drawing.SystemColors.Window;
            this.canvasBox.Location = new System.Drawing.Point(102, 12);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(1149, 532);
            this.canvasBox.TabIndex = 1;
            this.canvasBox.TabStop = false;
            this.canvasBox.Click += new System.EventHandler(this.canvasBox_Click);
            this.canvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseDown);
            this.canvasBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseMove);
            this.canvasBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasBox_MouseUp);
            // 
            // selectedColorBox
            // 
            this.selectedColorBox.BackColor = System.Drawing.Color.Black;
            this.selectedColorBox.Location = new System.Drawing.Point(61, 219);
            this.selectedColorBox.Name = "selectedColorBox";
            this.selectedColorBox.Size = new System.Drawing.Size(18, 16);
            this.selectedColorBox.TabIndex = 18;
            this.selectedColorBox.TabStop = false;
            this.selectedColorBox.Click += new System.EventHandler(this.selectedColorBox_Click);
            // 
            // drawingSaveDialog
            // 
            this.drawingSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.drawingSaveDialog_FileOk);
            // 
            // drawingOpenDialog
            // 
            this.drawingOpenDialog.FileName = "openFileDialog1";
            this.drawingOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.drawingOpenDialog_FileOk);
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Location = new System.Drawing.Point(61, 245);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedLabel.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 569);
            this.Controls.Add(this.canvasBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button freehandButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button pinButton;
        private System.Windows.Forms.Button unpinButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button colourButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.PictureBox canvasBox;
        private System.Windows.Forms.PictureBox selectedColorBox;
        private System.Windows.Forms.SaveFileDialog drawingSaveDialog;
        private System.Windows.Forms.OpenFileDialog drawingOpenDialog;
        private System.Windows.Forms.Label selectedLabel;
    }
}

