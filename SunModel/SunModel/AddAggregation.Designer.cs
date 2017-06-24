//------------------------------------------------------------------------------
// AddAggregation.Designer.cs
//
//------------------------------------------------------------------------------

namespace SunModelWindows
{
    partial class AddAggregation
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
            this.AggType = new System.Windows.Forms.ComboBox();
            this.aggregationLabel = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.ComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AggType
            // 
            this.AggType.FormattingEnabled = true;
            this.AggType.Items.AddRange(new object[] {
            "None",
            "Sum",
            "Avg"});
            this.AggType.Location = new System.Drawing.Point(109, 13);
            this.AggType.Name = "AggType";
            this.AggType.Size = new System.Drawing.Size(144, 21);
            this.AggType.TabIndex = 0;
            // 
            // aggregationLabel
            // 
            this.aggregationLabel.AutoSize = true;
            this.aggregationLabel.Location = new System.Drawing.Point(12, 16);
            this.aggregationLabel.Name = "aggregationLabel";
            this.aggregationLabel.Size = new System.Drawing.Size(91, 13);
            this.aggregationLabel.TabIndex = 1;
            this.aggregationLabel.Text = "Aggregation Type";
            // 
            // Level
            // 
            this.Level.FormattingEnabled = true;
            this.Level.Location = new System.Drawing.Point(109, 40);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(144, 21);
            this.Level.TabIndex = 2;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(12, 43);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(33, 13);
            this.levelLabel.TabIndex = 3;
            this.levelLabel.Text = "Level";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(196, 86);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(115, 86);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // AddAggregation
            // 
            this.AcceptButton = this.ok;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.aggregationLabel);
            this.Controls.Add(this.AggType);
            this.Name = "AddAggregation";
            this.Text = "Add Aggregation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label aggregationLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        public System.Windows.Forms.ComboBox AggType;
        public System.Windows.Forms.ComboBox Level;
    }
}
