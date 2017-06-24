//------------------------------------------------------------------------------
// AddMeasure.Designer.cs
//
//------------------------------------------------------------------------------

namespace SunModelWindows
{
    partial class AddMeasure
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
            this.MeasureName = new System.Windows.Forms.TextBox();
            this.measureNameLabel = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.MeasureType = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MeasureName
            // 
            this.MeasureName.CausesValidation = false;
            this.MeasureName.Location = new System.Drawing.Point(54, 35);
            this.MeasureName.Name = "MeasureName";
            this.MeasureName.Size = new System.Drawing.Size(176, 20);
            this.MeasureName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MeasureName_KeyDown);
            this.MeasureName.TabIndex = 0;
            // 
            // measureNameLabel
            // 
            this.measureNameLabel.AutoSize = true;
            this.measureNameLabel.Location = new System.Drawing.Point(13, 38);
            this.measureNameLabel.Name = "measureNameLabel";
            this.measureNameLabel.Size = new System.Drawing.Size(35, 13);
            this.measureNameLabel.Text = "Name";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(112, 226);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.CausesValidation = false;
            this.cancel.Location = new System.Drawing.Point(194, 226);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // MeasureType
            // 
            this.MeasureType.CausesValidation = false;
            this.MeasureType.FormattingEnabled = true;
            this.MeasureType.Items.AddRange(new object[] {
            "analytical",
            "descriptive"});
            this.MeasureType.Location = new System.Drawing.Point(54, 62);
            this.MeasureType.Name = "MeasureType";
            this.MeasureType.Size = new System.Drawing.Size(176, 21);
            this.MeasureType.TabIndex = 1;
            this.MeasureType.Text = "analytical";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(16, 69);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.Text = "Type";
            // 
            // AddMeasure
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.MeasureType);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.measureNameLabel);
            this.Controls.Add(this.MeasureName);
            this.Name = "AddMeasure";
            this.Text = "Add Measure";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.ActiveControl = MeasureName;

        }

        #endregion
        private System.Windows.Forms.Label measureNameLabel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        public System.Windows.Forms.TextBox MeasureName;
        private System.Windows.Forms.Label typeLabel;
        public System.Windows.Forms.ComboBox MeasureType;
    }
}
