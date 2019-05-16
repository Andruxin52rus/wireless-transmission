using System.Drawing;

namespace GUI
{
    partial class GUI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SendTextButton = new System.Windows.Forms.Button();
            this.EnterTextLabel = new System.Windows.Forms.Label();
            this.DrawSomethingLabel = new System.Windows.Forms.Label();
            this.DrawingField = new System.Windows.Forms.PictureBox();
            this.BlackBrushButton = new System.Windows.Forms.Button();
            this.WhiteBrushButton = new System.Windows.Forms.Button();
            this.ClearDrawingButton = new System.Windows.Forms.Button();
            this.SizeSelectStrip = new System.Windows.Forms.MenuStrip();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.px6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.px8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.px10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.px12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.px14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.px16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendDrawingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingField)).BeginInit();
            this.SizeSelectStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TextBox.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new System.Drawing.Point(10, 40);
            this.TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox.MaxLength = 32;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(463, 33);
            this.TextBox.TabIndex = 0;
            // 
            // SendTextButton
            // 
            this.SendTextButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendTextButton.Location = new System.Drawing.Point(478, 40);
            this.SendTextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendTextButton.Name = "SendTextButton";
            this.SendTextButton.Size = new System.Drawing.Size(116, 33);
            this.SendTextButton.TabIndex = 1;
            this.SendTextButton.Text = "Send";
            this.SendTextButton.UseVisualStyleBackColor = true;
            this.SendTextButton.Click += new System.EventHandler(this.SendTextButton_Click);
            // 
            // EnterTextLabel
            // 
            this.EnterTextLabel.AutoSize = true;
            this.EnterTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterTextLabel.Location = new System.Drawing.Point(10, 13);
            this.EnterTextLabel.Name = "EnterTextLabel";
            this.EnterTextLabel.Size = new System.Drawing.Size(191, 18);
            this.EnterTextLabel.TabIndex = 2;
            this.EnterTextLabel.Text = "Enter text up to 32 symbols:";
            // 
            // DrawSomethingLabel
            // 
            this.DrawSomethingLabel.AutoSize = true;
            this.DrawSomethingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawSomethingLabel.Location = new System.Drawing.Point(10, 82);
            this.DrawSomethingLabel.Name = "DrawSomethingLabel";
            this.DrawSomethingLabel.Size = new System.Drawing.Size(120, 18);
            this.DrawSomethingLabel.TabIndex = 3;
            this.DrawSomethingLabel.Text = "Draw something:";
            // 
            // DrawingField
            // 
            this.DrawingField.BackColor = System.Drawing.Color.White;
            this.DrawingField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawingField.Location = new System.Drawing.Point(13, 112);
            this.DrawingField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawingField.Name = "DrawingField";
            this.DrawingField.Size = new System.Drawing.Size(480, 160);
            this.DrawingField.TabIndex = 4;
            this.DrawingField.TabStop = false;
            this.DrawingField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingField_MouseDown);
            this.DrawingField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingField_MouseMove);
            this.DrawingField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingField_MouseUp);
            // 
            // BlackBrushButton
            // 
            this.BlackBrushButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BlackBrushButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BlackBrushButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BlackBrushButton.Image = ((System.Drawing.Image)(resources.GetObject("BlackBrushButton.Image")));
            this.BlackBrushButton.Location = new System.Drawing.Point(13, 278);
            this.BlackBrushButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BlackBrushButton.Name = "BlackBrushButton";
            this.BlackBrushButton.Size = new System.Drawing.Size(40, 40);
            this.BlackBrushButton.TabIndex = 5;
            this.BlackBrushButton.UseVisualStyleBackColor = false;
            this.BlackBrushButton.Click += new System.EventHandler(this.BlackBrushButton_Click);
            // 
            // WhiteBrushButton
            // 
            this.WhiteBrushButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.WhiteBrushButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.WhiteBrushButton.Image = ((System.Drawing.Image)(resources.GetObject("WhiteBrushButton.Image")));
            this.WhiteBrushButton.Location = new System.Drawing.Point(59, 278);
            this.WhiteBrushButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WhiteBrushButton.Name = "WhiteBrushButton";
            this.WhiteBrushButton.Size = new System.Drawing.Size(40, 40);
            this.WhiteBrushButton.TabIndex = 6;
            this.WhiteBrushButton.UseVisualStyleBackColor = false;
            this.WhiteBrushButton.Click += new System.EventHandler(this.WhiteBrushButton_Click);
            // 
            // ClearDrawingButton
            // 
            this.ClearDrawingButton.Location = new System.Drawing.Point(366, 278);
            this.ClearDrawingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearDrawingButton.Name = "ClearDrawingButton";
            this.ClearDrawingButton.Size = new System.Drawing.Size(127, 40);
            this.ClearDrawingButton.TabIndex = 8;
            this.ClearDrawingButton.Text = "Erase";
            this.ClearDrawingButton.UseVisualStyleBackColor = true;
            this.ClearDrawingButton.Click += new System.EventHandler(this.ClearDrawingButton_Click);
            // 
            // SizeSelectStrip
            // 
            this.SizeSelectStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SizeSelectStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pxToolStripMenuItem});
            this.SizeSelectStrip.Location = new System.Drawing.Point(496, 112);
            this.SizeSelectStrip.Name = "SizeSelectStrip";
            this.SizeSelectStrip.Size = new System.Drawing.Size(48, 44);
            this.SizeSelectStrip.TabIndex = 9;
            this.SizeSelectStrip.Text = "menuStrip1";
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.AutoSize = false;
            this.pxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.px6ToolStripMenuItem,
            this.px8ToolStripMenuItem,
            this.px10ToolStripMenuItem,
            this.px12ToolStripMenuItem,
            this.px14ToolStripMenuItem,
            this.px16ToolStripMenuItem});
            this.pxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pxToolStripMenuItem.Image")));
            this.pxToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(40, 40);
            // 
            // px6ToolStripMenuItem
            // 
            this.px6ToolStripMenuItem.AutoSize = false;
            this.px6ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("px6ToolStripMenuItem.Image")));
            this.px6ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.px6ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.px6ToolStripMenuItem.Name = "px6ToolStripMenuItem";
            this.px6ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.px6ToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.px6ToolStripMenuItem.Text = "6 px";
            this.px6ToolStripMenuItem.Click += new System.EventHandler(this.px6ToolStripMenuItem_Click);
            // 
            // px8ToolStripMenuItem
            // 
            this.px8ToolStripMenuItem.AutoSize = false;
            this.px8ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("px8ToolStripMenuItem.Image")));
            this.px8ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.px8ToolStripMenuItem.Name = "px8ToolStripMenuItem";
            this.px8ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.px8ToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.px8ToolStripMenuItem.Text = "8 px";
            this.px8ToolStripMenuItem.Click += new System.EventHandler(this.px8ToolStripMenuItem_Click);
            // 
            // px10ToolStripMenuItem
            // 
            this.px10ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("px10ToolStripMenuItem.Image")));
            this.px10ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.px10ToolStripMenuItem.Name = "px10ToolStripMenuItem";
            this.px10ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.px10ToolStripMenuItem.Text = "10 px";
            this.px10ToolStripMenuItem.Click += new System.EventHandler(this.px10ToolStripMenuItem_Click);
            // 
            // px12ToolStripMenuItem
            // 
            this.px12ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("px12ToolStripMenuItem.Image")));
            this.px12ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.px12ToolStripMenuItem.Name = "px12ToolStripMenuItem";
            this.px12ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.px12ToolStripMenuItem.Text = "12 px";
            this.px12ToolStripMenuItem.Click += new System.EventHandler(this.px12ToolStripMenuItem_Click);
            // 
            // px14ToolStripMenuItem
            // 
            this.px14ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("px14ToolStripMenuItem.Image")));
            this.px14ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.px14ToolStripMenuItem.Name = "px14ToolStripMenuItem";
            this.px14ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.px14ToolStripMenuItem.Text = "14 px";
            this.px14ToolStripMenuItem.Click += new System.EventHandler(this.px14ToolStripMenuItem_Click);
            // 
            // px16ToolStripMenuItem
            // 
            this.px16ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("px16ToolStripMenuItem.Image")));
            this.px16ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.px16ToolStripMenuItem.Name = "px16ToolStripMenuItem";
            this.px16ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.px16ToolStripMenuItem.Text = "16 px";
            this.px16ToolStripMenuItem.Click += new System.EventHandler(this.px16ToolStripMenuItem_Click);
            // 
            // SendDrawingButton
            // 
            this.SendDrawingButton.Location = new System.Drawing.Point(233, 278);
            this.SendDrawingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendDrawingButton.Name = "SendDrawingButton";
            this.SendDrawingButton.Size = new System.Drawing.Size(127, 40);
            this.SendDrawingButton.TabIndex = 10;
            this.SendDrawingButton.Text = "Send";
            this.SendDrawingButton.UseVisualStyleBackColor = true;
            this.SendDrawingButton.Click += new System.EventHandler(this.SendDrawingButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 332);
            this.Controls.Add(this.SendDrawingButton);
            this.Controls.Add(this.ClearDrawingButton);
            this.Controls.Add(this.WhiteBrushButton);
            this.Controls.Add(this.BlackBrushButton);
            this.Controls.Add(this.DrawingField);
            this.Controls.Add(this.DrawSomethingLabel);
            this.Controls.Add(this.EnterTextLabel);
            this.Controls.Add(this.SendTextButton);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.SizeSelectStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GUI";
            this.Text = "Content Manager";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingField)).EndInit();
            this.SizeSelectStrip.ResumeLayout(false);
            this.SizeSelectStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        

        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button SendTextButton;
        private System.Windows.Forms.Label EnterTextLabel;
        private System.Windows.Forms.Label DrawSomethingLabel;
        private System.Windows.Forms.Button BlackBrushButton;
        private System.Windows.Forms.Button WhiteBrushButton;
        private System.Windows.Forms.Button ClearDrawingButton;
        public System.Windows.Forms.PictureBox DrawingField;
        private System.Windows.Forms.MenuStrip SizeSelectStrip;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem px6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem px8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem px10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem px12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem px14ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem px16ToolStripMenuItem;
        private System.Windows.Forms.Button SendDrawingButton;
    }
}