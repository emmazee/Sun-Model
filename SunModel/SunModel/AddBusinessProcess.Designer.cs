//------------------------------------------------------------------------------
// AddBusinessProcess.Designer.cs
//
//------------------------------------------------------------------------------

using System.Windows.Forms;

namespace SunModelWindows
{
    partial class AddBusinessProcess
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
            this.businessProcess = new System.Windows.Forms.TextBox();
            this.name_label = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // businessProcess
            // 
            this.businessProcess.Location = new System.Drawing.Point(99, 12);
            this.businessProcess.Name = "businessProcess";
            this.businessProcess.Size = new System.Drawing.Size(165, 20);
            this.businessProcess.TabIndex = 0;
            this.businessProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.businessProcess_KeyDown);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(3, 15);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(90, 13);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Business Process";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(108, 50);
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
            this.cancel.Location = new System.Drawing.Point(189, 50);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // AddBusinessProcess
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 94);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.businessProcess);
            this.Name = "AddBusinessProcess";
            this.Text = "Add Business Process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Button ok;
        public System.Windows.Forms.TextBox businessProcess;
        private System.Windows.Forms.Button cancel;
    }
}
