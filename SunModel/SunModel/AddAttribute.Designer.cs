//------------------------------------------------------------------------------
// AddAttribute.Designer.cs
//
//------------------------------------------------------------------------------

namespace SunModelWindows
{
    partial class AddAttribute
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
            this.dimensionLabel = new System.Windows.Forms.Label();
            this.Dimension = new System.Windows.Forms.ComboBox();
            this.attributeNameLabel = new System.Windows.Forms.Label();
            this.AttributeName = new System.Windows.Forms.TextBox();
            this.attributeTypeLabel = new System.Windows.Forms.Label();
            this.AttributeType = new System.Windows.Forms.ComboBox();
            this.OptionalLevel = new System.Windows.Forms.CheckBox();
            this.OptionalBranch = new System.Windows.Forms.CheckBox();
            this.ManyToMany = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.parentLabel = new System.Windows.Forms.Label();
            this.Parent = new System.Windows.Forms.ComboBox();
            this.IsSharedNode = new System.Windows.Forms.CheckBox();
            this.SharedNodeName = new System.Windows.Forms.ComboBox();
            this.sharedNodeLabel = new System.Windows.Forms.Label();
            this.NotSharedPanel = new System.Windows.Forms.Panel();
            this.Recursive = new System.Windows.Forms.CheckBox();
            this.SharedPanel = new System.Windows.Forms.Panel();
            this.ConvergedKey = new System.Windows.Forms.RadioButton();
            this.CDAKey = new System.Windows.Forms.RadioButton();
            this.NotSharedPanel.SuspendLayout();
            this.SharedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dimensionLabel
            // 
            this.dimensionLabel.AutoSize = true;
            this.dimensionLabel.Location = new System.Drawing.Point(14, 16);
            this.dimensionLabel.Name = "dimensionLabel";
            this.dimensionLabel.Size = new System.Drawing.Size(56, 13);
            this.dimensionLabel.TabIndex = 12;
            this.dimensionLabel.Text = "Dimension";
            // 
            // Dimension
            // 
            this.Dimension.FormattingEnabled = true;
            this.Dimension.Location = new System.Drawing.Point(97, 13);
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(121, 21);
            this.Dimension.TabIndex = 8;
            this.Dimension.SelectedIndexChanged += new System.EventHandler(this.Dimension_SelectedIndexChanged);
            // 
            // attributeNameLabel
            // 
            this.attributeNameLabel.AutoSize = true;
            this.attributeNameLabel.Location = new System.Drawing.Point(-3, 6);
            this.attributeNameLabel.Name = "attributeNameLabel";
            this.attributeNameLabel.Size = new System.Drawing.Size(77, 13);
            this.attributeNameLabel.TabIndex = 7;
            this.attributeNameLabel.Text = "Attribute Name";
            // 
            // AttributeName
            // 
            this.AttributeName.Location = new System.Drawing.Point(80, 3);
            this.AttributeName.Name = "AttributeName";
            this.AttributeName.Size = new System.Drawing.Size(121, 20);
            this.AttributeName.TabIndex = 0;
            // 
            // attributeTypeLabel
            // 
            this.attributeTypeLabel.AutoSize = true;
            this.attributeTypeLabel.Location = new System.Drawing.Point(-3, 32);
            this.attributeTypeLabel.Name = "attributeTypeLabel";
            this.attributeTypeLabel.Size = new System.Drawing.Size(73, 13);
            this.attributeTypeLabel.TabIndex = 6;
            this.attributeTypeLabel.Text = "Attribute Type";
            // 
            // AttributeType
            // 
            this.AttributeType.FormattingEnabled = true;
            this.AttributeType.Items.AddRange(new object[] {
            "analytical",
            "descriptive"});
            this.AttributeType.Location = new System.Drawing.Point(80, 29);
            this.AttributeType.Name = "AttributeType";
            this.AttributeType.Size = new System.Drawing.Size(121, 21);
            this.AttributeType.TabIndex = 1;
            this.AttributeType.Text = "analytical";
            // 
            // OptionalLevel
            // 
            this.OptionalLevel.AutoSize = true;
            this.OptionalLevel.Location = new System.Drawing.Point(0, 56);
            this.OptionalLevel.Name = "OptionalLevel";
            this.OptionalLevel.Size = new System.Drawing.Size(107, 17);
            this.OptionalLevel.TabIndex = 2;
            this.OptionalLevel.Text = "Optional Attribute";
            this.OptionalLevel.UseVisualStyleBackColor = true;
            // 
            // OptionalBranch
            // 
            this.OptionalBranch.AutoSize = true;
            this.OptionalBranch.Location = new System.Drawing.Point(0, 79);
            this.OptionalBranch.Name = "OptionalBranch";
            this.OptionalBranch.Size = new System.Drawing.Size(102, 17);
            this.OptionalBranch.TabIndex = 3;
            this.OptionalBranch.Text = "Optional Branch";
            this.OptionalBranch.UseVisualStyleBackColor = true;
            // 
            // ManyToMany
            // 
            this.ManyToMany.AutoSize = true;
            this.ManyToMany.Location = new System.Drawing.Point(0, 102);
            this.ManyToMany.Name = "ManyToMany";
            this.ManyToMany.Size = new System.Drawing.Size(210, 17);
            this.ManyToMany.TabIndex = 4;
            this.ManyToMany.Text = "Many to Many Relationship with Parent";
            this.ManyToMany.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(198, 388);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(116, 388);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // parentLabel
            // 
            this.parentLabel.AutoSize = true;
            this.parentLabel.Location = new System.Drawing.Point(14, 43);
            this.parentLabel.Name = "parentLabel";
            this.parentLabel.Size = new System.Drawing.Size(38, 13);
            this.parentLabel.TabIndex = 11;
            this.parentLabel.Text = "Parent";
            // 
            // Parent
            // 
            this.Parent.FormattingEnabled = true;
            this.Parent.Items.AddRange(new object[] {
            "n/a"});
            this.Parent.Location = new System.Drawing.Point(97, 40);
            this.Parent.Name = "Parent";
            this.Parent.Size = new System.Drawing.Size(121, 21);
            this.Parent.TabIndex = 9;
            this.Parent.Text = "n/a";
            // 
            // IsSharedNode
            // 
            this.IsSharedNode.AutoSize = true;
            this.IsSharedNode.Location = new System.Drawing.Point(97, 68);
            this.IsSharedNode.Name = "IsSharedNode";
            this.IsSharedNode.Size = new System.Drawing.Size(122, 17);
            this.IsSharedNode.TabIndex = 10;
            this.IsSharedNode.Text = "Use a shared node?";
            this.IsSharedNode.UseVisualStyleBackColor = true;
            this.IsSharedNode.CheckedChanged += new System.EventHandler(this.IsSharedNode_CheckedChanged);
            // 
            // SharedNodeName
            // 
            this.SharedNodeName.FormattingEnabled = true;
            this.SharedNodeName.Location = new System.Drawing.Point(80, 5);
            this.SharedNodeName.Name = "SharedNodeName";
            this.SharedNodeName.Size = new System.Drawing.Size(121, 21);
            this.SharedNodeName.TabIndex = 11;
            // 
            // sharedNodeLabel
            // 
            this.sharedNodeLabel.AutoSize = true;
            this.sharedNodeLabel.Location = new System.Drawing.Point(-4, 5);
            this.sharedNodeLabel.Name = "sharedNodeLabel";
            this.sharedNodeLabel.Size = new System.Drawing.Size(70, 13);
            this.sharedNodeLabel.Text = "Shared Node";
            // 
            // NotSharedPanel
            // 
            this.NotSharedPanel.Controls.Add(this.Recursive);
            this.NotSharedPanel.Controls.Add(this.OptionalBranch);
            this.NotSharedPanel.Controls.Add(this.OptionalLevel);
            this.NotSharedPanel.Controls.Add(this.ManyToMany);
            this.NotSharedPanel.Controls.Add(this.AttributeType);
            this.NotSharedPanel.Controls.Add(this.attributeTypeLabel);
            this.NotSharedPanel.Controls.Add(this.attributeNameLabel);
            this.NotSharedPanel.Controls.Add(this.AttributeName);
            this.NotSharedPanel.Location = new System.Drawing.Point(15, 216);
            this.NotSharedPanel.Name = "NotSharedPanel";
            this.NotSharedPanel.Size = new System.Drawing.Size(258, 151);
            // 
            // Recursive
            // 
            this.Recursive.AutoSize = true;
            this.Recursive.Location = new System.Drawing.Point(0, 125);
            this.Recursive.Name = "Recursive";
            this.Recursive.Size = new System.Drawing.Size(74, 17);
            this.Recursive.TabIndex = 5;
            this.Recursive.Text = "Recursive";
            this.Recursive.UseVisualStyleBackColor = true;
            // 
            // SharedPanel
            // 
            this.SharedPanel.Controls.Add(this.ConvergedKey);
            this.SharedPanel.Controls.Add(this.CDAKey);
            this.SharedPanel.Controls.Add(this.sharedNodeLabel);
            this.SharedPanel.Controls.Add(this.SharedNodeName);
            this.SharedPanel.Location = new System.Drawing.Point(17, 84);
            this.SharedPanel.Name = "SharedPanel";
            this.SharedPanel.Size = new System.Drawing.Size(258, 76);
            this.SharedPanel.TabIndex = 0;
            // 
            // ConvergedKey
            // 
            this.ConvergedKey.AutoSize = true;
            this.ConvergedKey.Location = new System.Drawing.Point(80, 55);
            this.ConvergedKey.Name = "ConvergedKey";
            this.ConvergedKey.Size = new System.Drawing.Size(89, 17);
            this.ConvergedKey.TabIndex = 13;
            this.ConvergedKey.TabStop = true;
            this.ConvergedKey.Text = "Convergence";
            this.ConvergedKey.UseVisualStyleBackColor = true;
            // 
            // CDAKey
            // 
            this.CDAKey.AutoSize = true;
            this.CDAKey.Location = new System.Drawing.Point(80, 32);
            this.CDAKey.Name = "CDAKey";
            this.CDAKey.Size = new System.Drawing.Size(153, 17);
            this.CDAKey.TabIndex = 12;
            this.CDAKey.TabStop = true;
            this.CDAKey.Text = "Cross Dimensional Attribute";
            this.CDAKey.UseVisualStyleBackColor = true;
            // 
            // AddAttribute
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 423);
            this.Controls.Add(this.SharedPanel);
            this.Controls.Add(this.NotSharedPanel);
            this.Controls.Add(this.IsSharedNode);
            this.Controls.Add(this.Parent);
            this.Controls.Add(this.parentLabel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.dimensionLabel);
            this.Name = "AddAttribute";
            this.Text = "Add Attribute";
            this.NotSharedPanel.ResumeLayout(false);
            this.NotSharedPanel.PerformLayout();
            this.SharedPanel.ResumeLayout(false);
            this.SharedPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dimensionLabel;
        private System.Windows.Forms.Label attributeNameLabel;
        private System.Windows.Forms.Label attributeTypeLabel;
        public System.Windows.Forms.TextBox AttributeName;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        public System.Windows.Forms.ComboBox Dimension;
        public System.Windows.Forms.ComboBox AttributeType;
        public System.Windows.Forms.CheckBox OptionalLevel;
        public System.Windows.Forms.CheckBox OptionalBranch;
        public System.Windows.Forms.CheckBox ManyToMany;
        private System.Windows.Forms.Label parentLabel;
        public System.Windows.Forms.ComboBox Parent;
        private System.Windows.Forms.Label sharedNodeLabel;
        private System.Windows.Forms.Panel NotSharedPanel;
        private System.Windows.Forms.Panel SharedPanel;
        public System.Windows.Forms.CheckBox Recursive;
        public System.Windows.Forms.ComboBox SharedNodeName;
        public System.Windows.Forms.CheckBox IsSharedNode;
        public System.Windows.Forms.RadioButton ConvergedKey;
        public System.Windows.Forms.RadioButton CDAKey;
    }
}
