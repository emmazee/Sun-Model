//------------------------------------------------------------------------------
// EZ Sun Model.Designer.cs
//
//------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace SunModelWindows
{
    partial class EZSunModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EZSunModel));
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBusinessProcess = new System.Windows.Forms.Button();
            this.groupBoxDrawArea = new System.Windows.Forms.Panel();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.AddMeasure = new System.Windows.Forms.Button();
            this.AddDimension = new System.Windows.Forms.Button();
            this.AddAttribute = new System.Windows.Forms.Button();
            this.tabControlArea = new System.Windows.Forms.TabControl();
            this.propertyGridArea = new System.Windows.Forms.PropertyGrid();
            this.menuStripTop.SuspendLayout();
            this.groupBoxDrawArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.insertToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(937, 24);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStripTop";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveAsToolStripMenuItem.Text = "Save As ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.businessProcessToolStripMenuItem,
            this.measureToolStripMenuItem,
            this.dimensionToolStripMenuItem,
            this.attributeToolStripMenuItem});
            this.insertToolStripMenuItem.Enabled = false;
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // businessProcessToolStripMenuItem
            // 
            this.businessProcessToolStripMenuItem.Name = "businessProcessToolStripMenuItem";
            this.businessProcessToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.businessProcessToolStripMenuItem.Text = "Business Process";
            this.businessProcessToolStripMenuItem.Click += new System.EventHandler(this.AddBusinessProcess_Click);
            // 
            // measureToolStripMenuItem
            // 
            this.measureToolStripMenuItem.Name = "measureToolStripMenuItem";
            this.measureToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.measureToolStripMenuItem.Text = "Measure";
            this.measureToolStripMenuItem.Click += new System.EventHandler(this.AddMeasure_Click);
            // 
            // dimensionToolStripMenuItem
            // 
            this.dimensionToolStripMenuItem.Name = "dimensionToolStripMenuItem";
            this.dimensionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.dimensionToolStripMenuItem.Text = "Dimension";
            this.dimensionToolStripMenuItem.Click += new System.EventHandler(this.AddDimension_Click);
            // 
            // attributeToolStripMenuItem
            // 
            this.attributeToolStripMenuItem.Name = "attributeToolStripMenuItem";
            this.attributeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.attributeToolStripMenuItem.Text = "Attribute";
            this.attributeToolStripMenuItem.Click += new System.EventHandler(this.attributeToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // AddBusinessProcess
            // 
            this.AddBusinessProcess.Location = new System.Drawing.Point(273, 27);
            this.AddBusinessProcess.Name = "AddBusinessProcess";
            this.AddBusinessProcess.Size = new System.Drawing.Size(116, 23);
            this.AddBusinessProcess.TabIndex = 0;
            this.AddBusinessProcess.Text = "+ Business Process";
            this.AddBusinessProcess.UseVisualStyleBackColor = true;
            this.AddBusinessProcess.Click += new System.EventHandler(this.AddBusinessProcess_Click);
            // 
            // groupBoxDrawArea
            // 
            this.groupBoxDrawArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDrawArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxDrawArea.BackColor = System.Drawing.Color.White;
            this.groupBoxDrawArea.Controls.Add(this.trackBarZoom);
            this.groupBoxDrawArea.Location = new System.Drawing.Point(273, 53);
            this.groupBoxDrawArea.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxDrawArea.Name = "groupBoxDrawArea";
            this.groupBoxDrawArea.Size = new System.Drawing.Size(406, 440);
            this.groupBoxDrawArea.TabIndex = 3;
            this.groupBoxDrawArea.Click += new System.EventHandler(this.groupBoxDrawArea_Click);
            this.groupBoxDrawArea.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.groupBoxDrawArea_MouseWheel);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarZoom.Location = new System.Drawing.Point(284, 392);
            this.trackBarZoom.Maximum = 20;
            this.trackBarZoom.Minimum = 1;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(119, 45);
            this.trackBarZoom.TabIndex = 9;
            this.trackBarZoom.Value = 10;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // AddMeasure
            // 
            this.AddMeasure.Location = new System.Drawing.Point(395, 27);
            this.AddMeasure.Name = "AddMeasure";
            this.AddMeasure.Size = new System.Drawing.Size(75, 23);
            this.AddMeasure.TabIndex = 4;
            this.AddMeasure.Text = "+ Measure";
            this.AddMeasure.UseVisualStyleBackColor = true;
            this.AddMeasure.Click += new System.EventHandler(this.AddMeasure_Click);
            // 
            // AddDimension
            // 
            this.AddDimension.Location = new System.Drawing.Point(476, 27);
            this.AddDimension.Name = "AddDimension";
            this.AddDimension.Size = new System.Drawing.Size(75, 23);
            this.AddDimension.TabIndex = 5;
            this.AddDimension.Text = "+ Dimension";
            this.AddDimension.UseVisualStyleBackColor = true;
            this.AddDimension.Click += new System.EventHandler(this.AddDimension_Click);
            // 
            // AddAttribute
            // 
            this.AddAttribute.Location = new System.Drawing.Point(557, 27);
            this.AddAttribute.Name = "AddAttribute";
            this.AddAttribute.Size = new System.Drawing.Size(75, 23);
            this.AddAttribute.TabIndex = 6;
            this.AddAttribute.Text = "+ Attribute";
            this.AddAttribute.UseVisualStyleBackColor = true;
            this.AddAttribute.Click += new System.EventHandler(this.AddAttribute_Click);
            // 
            // tabControlArea
            // 
            this.tabControlArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlArea.Location = new System.Drawing.Point(12, 27);
            this.tabControlArea.Name = "tabControlArea";
            this.tabControlArea.SelectedIndex = 0;
            this.tabControlArea.Size = new System.Drawing.Size(255, 466);
            this.tabControlArea.TabIndex = 1;
            this.tabControlArea.SelectedIndexChanged += new System.EventHandler(this.tabControlArea_SelectedIndexChanged);
            // 
            // propertyGridArea
            // 
            this.propertyGridArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridArea.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGridArea.Location = new System.Drawing.Point(682, 56);
            this.propertyGridArea.Name = "propertyGridArea";
            this.propertyGridArea.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridArea.Size = new System.Drawing.Size(243, 437);
            this.propertyGridArea.TabIndex = 8;
            this.propertyGridArea.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridArea_PropertyValueChanged);
            // 
            // EZSunModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 505);
            this.Controls.Add(this.propertyGridArea);
            this.Controls.Add(this.AddAttribute);
            this.Controls.Add(this.AddDimension);
            this.Controls.Add(this.AddMeasure);
            this.Controls.Add(this.groupBoxDrawArea);
            this.Controls.Add(this.tabControlArea);
            this.Controls.Add(this.AddBusinessProcess);
            this.Controls.Add(this.menuStripTop);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "EZSunModel";
            this.Text = "EZ Sun Model";
            this.ResizeEnd += new System.EventHandler(this.EZSunModel_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.FormMain_Resize);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.groupBoxDrawArea.ResumeLayout(false);
            this.groupBoxDrawArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      


        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button AddBusinessProcess;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Panel groupBoxDrawArea;
        private System.Windows.Forms.Button AddMeasure;
        private System.Windows.Forms.Button AddDimension;
        private System.Windows.Forms.Button AddAttribute;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributeToolStripMenuItem;
        private TabControl tabControlArea;
        private PropertyGrid propertyGridArea;
        private TrackBar trackBarZoom;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
    }
}

