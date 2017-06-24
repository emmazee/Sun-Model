//------------------------------------------------------------------------------
// EZ Sun Model.cs
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SunModelWindows
{
    using System.Drawing.Drawing2D;
    using System.Reflection;
    using System.Xml;
    using USMM;

    public partial class EZSunModel : Form
    {
        private ConceptualModel cmodel;
        private String filename = "Untitled.xml";
        private String fileLocation;
        private Graphics graphics;
        private double zoom = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="EZSunModel"/> class.
        /// </summary>
        public EZSunModel()
        {

            InitializeComponent();
            this.AddBusinessProcess.Enabled = false;
            this.AddMeasure.Enabled = false;
            this.AddDimension.Enabled = false;
            this.AddAttribute.Enabled = false;
            this.groupBoxDrawArea.Enabled = false;
            this.graphics = groupBoxDrawArea.CreateGraphics();
    }

        /// <summary>
        /// Enables the buttons.
        /// </summary>
        private void enableButtons()
        {
            this.AddBusinessProcess.Enabled = true;
            this.AddMeasure.Enabled = true;
            this.AddDimension.Enabled = true;
            this.AddAttribute.Enabled = true;
            this.saveAsToolStripMenuItem.Enabled = true;
            this.insertToolStripMenuItem.Enabled = true;
            this.groupBoxDrawArea.Enabled = true;
            this.businessProcessToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.measureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.dimensionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.attributeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
        }
        /// <summary>
        /// Enables the save button.
        /// </summary>
        private void enableSaveButton()
        {
            this.saveToolStripMenuItem.Enabled = true;
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
        }
        /// <summary>
        /// Disables the save button.
        /// </summary>
        private void disableSaveButton()
        {
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.None)));

        }
        /// <summary>
        /// Handles the Click event of the Main Menu File -> Save control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fileLocation) == false)
            {
                string path = this.fileLocation + "\\" + this.filename;

                using (Stream myStream = File.Open(path, FileMode.Open))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    XmlSerializer serializer = new XmlSerializer(this.cmodel.GetType());

                    serializer.Serialize(myStream, this.cmodel);
                    myStream.Position = 0;
                    xmlDocument.Load(myStream);

                    myStream.Close();
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the Main Menu File -> SaveAs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = this.filename;
            saveFileDialog1.RestoreDirectory = true;

            if (string.IsNullOrEmpty(this.fileLocation) == false)
            {
                saveFileDialog1.InitialDirectory = this.fileLocation;
            }
            saveFileDialog1.Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    XmlSerializer serializer = new XmlSerializer(this.cmodel.GetType());

                    serializer.Serialize(myStream, this.cmodel);
                    myStream.Position = 0;
                    xmlDocument.Load(myStream);

                    myStream.Close();
                }
            }
            this.fileLocation = Path.GetDirectoryName(saveFileDialog1.FileName);
            this.filename = Path.GetFileName(saveFileDialog1.FileName);
            this.Text = "EZ Sun Model - " + this.filename;
            this.enableSaveButton();
        }
        
        /// <summary>
        /// Handles the Click event of the Main menu File -> Load control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Stream myStream = null;

            openFileDialog1.Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            using (var reader = new System.IO.StreamReader(myStream))
                            {
                                var serializer = new XmlSerializer(typeof(ConceptualModel));
                                try
                                {
                                    this.filename = openFileDialog1.SafeFileName;
                                    this.cmodel = (ConceptualModel)serializer.Deserialize(reader);


                                    this.Text = "EZ Sun Model - " + this.filename;

                                    enableButtons();
                                    enableSaveButton();
                                    this.Draw();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.InnerException.Message.ToString(), "Error: Could not parse XML. Error: " + ex.Message);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        
        /// <summary>
        /// Handles the 1 event of the Main Menu File -> New control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filename = "Untitled.xml";
            this.Text = "EZ Sun Model - " + this.filename;
            ConceptualModel c = new ConceptualModel();
            this.cmodel = c;
            LaunchAddBusinessProcess();
            enableButtons();
            disableSaveButton();

        }

        /// <summary>
        /// Launches the add business process form.
        /// </summary>
        public void LaunchAddBusinessProcess()
        {
            using (AddBusinessProcess m = new AddBusinessProcess(this.cmodel))
            {
                Point location = new Point((this.Left + (this.Width / 2)) - m.Width / 2, (this.Top + (this.Height / 2)) - m.Height / 2);
                m.StartPosition = FormStartPosition.Manual;
                m.Location = location;
                var result = m.ShowDialog();
                if (result == DialogResult.OK)
                {
                    BusinessProcess b = new BusinessProcess();
                    b.Name = m.businessProcess.Text;
                    this.cmodel.AddBusinessProcess(b);
                    this.Draw();
                    tabControlArea.SelectTab(b.Name);
                }
            }
        }
        
        /// <summary>
        /// Handles the Click event of the AddBusinessProcess button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddBusinessProcess_Click(object sender, EventArgs e)
        {
            LaunchAddBusinessProcess();
        }

        /// <summary>
        /// Updates the property grid.
        /// </summary>
        /// <param name="node">The node to be shown.</param>
        private void UpdatePropertyGrid(TreeNode node)
        {
            SunModelPart p = Utils.GetTreeNodeClass(node);
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess b = this.cmodel.GetBusinessProcess(businessProcess);
            if (p == SunModelPart.BusinessProcess)
            {
                this.propertyGridArea.SelectedObject = b;
            }
            else if (p == SunModelPart.Measure || p == SunModelPart.Dimension)
            {
                this.propertyGridArea.SelectedObject = node.Tag;
            }
            else if (p == SunModelPart.Attribute || p == SunModelPart.SharedNode)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(node.Tag.GetType());
                foreach (PropertyDescriptor desc in props)
                {
                    ReadOnlyAttribute roAttribute = (ReadOnlyAttribute)
                              desc.Attributes[typeof(ReadOnlyAttribute)];
                    FieldInfo roFieldToChange = roAttribute.GetType().GetField("isReadOnly",
                                                     System.Reflection.BindingFlags.NonPublic |
                                                     System.Reflection.BindingFlags.Instance);
                    roFieldToChange.SetValue(roAttribute, (desc.Name == "UID"));

                    BrowsableAttribute brAttribute = (BrowsableAttribute)
                                                      desc.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo brFieldToChange = brAttribute.GetType().GetField("browsable",
                                                         System.Reflection.BindingFlags.NonPublic |
                                                         System.Reflection.BindingFlags.Instance);
                    brFieldToChange.SetValue(brAttribute, (desc.Name !="Level1" && desc.Name !="X_position" && desc.Name != "Y_position" && (
                        p != SunModelPart.SharedNode 
                        || (p == SunModelPart.SharedNode && desc.Name != "CDAKey"  && desc.Name != "ConvergedKey" && desc.Name != "Key"))));


                }
                

                this.propertyGridArea.SelectedObject = node.Tag;
            }
            else if (p == SunModelPart.SharedNodeReference)
            {

                PropertyDescriptorCollection props = TypeDescriptor.GetProperties((typeof(Level)));
                foreach (PropertyDescriptor desc in props)
                {
                    ReadOnlyAttribute roAttribute = (ReadOnlyAttribute)
                                                  desc.Attributes[typeof(ReadOnlyAttribute)];
                    FieldInfo roFieldToChange = roAttribute.GetType().GetField("isReadOnly",
                                                     System.Reflection.BindingFlags.NonPublic |
                                                     System.Reflection.BindingFlags.Instance);
                    roFieldToChange.SetValue(roAttribute, true);

                    BrowsableAttribute brAttribute = (BrowsableAttribute)
                                                      desc.Attributes[typeof(BrowsableAttribute)];
                    FieldInfo brFieldToChange = brAttribute.GetType().GetField("browsable",
                                                         System.Reflection.BindingFlags.NonPublic |
                                                         System.Reflection.BindingFlags.Instance);
                    brFieldToChange.SetValue(brAttribute, (desc.Name == "UID" || desc.Name == "CDAKey" || desc.Name == "ConvergedKey" || desc.Name == "Key"));
                }
                
                this.propertyGridArea.SelectedObject = node.Tag;

            }
            else
            {

                this.propertyGridArea.SelectedObject = node.Tag;
            }
        }

        /// <summary>
        /// Handles a NodeMouseClick to the Tree View
        /// It should dynamically generate a menu if the node is right clicked
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        private void DynTree_AfterSelect(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Get the selected node.
            TreeNode node = e.Node;
            SunModelPart p = Utils.GetTreeNodeClass((TreeNode)e.Node);

            UpdatePropertyGrid(node);


            if (e.Button == MouseButtons.Right)
            {

                ContextMenu cm = new ContextMenu();

                if (p == SunModelPart.BusinessProcess && this.cmodel.BusinessProcess.Count() > 1)
                {
                    MenuItem item = new MenuItem();
                    item.Text = "Delete";
                    item.Click += (s, EventArgs) => { RemoveItem_Click(sender, EventArgs, (TreeNode)e.Node); };
                    cm.MenuItems.Add(item);
                }
               if (p == SunModelPart.Measure || p == SunModelPart.Dimension || p == SunModelPart.Attribute)
                {
                        MenuItem item = new MenuItem();
                        item.Text = "Delete";
                        item.Click += (s, EventArgs) => { RemoveItem_Click(sender, EventArgs, (TreeNode)e.Node); };
                        cm.MenuItems.Add(item);
                }
                if (p == SunModelPart.SharedNodeReference && ((Level)e.Node.Tag).IsSharedLevel())
                {
                    MenuItem item = new MenuItem();
                    item.Text = "Delete";
                    item.Click += (s, EventArgs) => { RemoveItem_Click(sender, EventArgs, (TreeNode)e.Node); };
                    cm.MenuItems.Add(item);
                }
                if (p == SunModelPart.Attribute)
                {
                    MenuItem item = new MenuItem();
                    item.Text = "Convert To Shared Node";
                    item.Click += (s, EventArgs) => { ConvertItem_Click(sender, EventArgs, (TreeNode)e.Node, ReferenceType.Key); };
                    cm.MenuItems.Add(item);
                    item = new MenuItem();
                    item.Text = "Convert To Cross Dimensional Attribute";
                    item.Click += (s, EventArgs) => { ConvertItem_Click(sender, EventArgs, (TreeNode)e.Node, ReferenceType.CDAKey); };
                    cm.MenuItems.Add(item);
                    item = new MenuItem();
                    item.Text = "Convert To Converged Shared Node";
                    item.Click += (s, EventArgs) => { ConvertItem_Click(sender, EventArgs, (TreeNode)e.Node, ReferenceType.ConvergedKey); };
                    cm.MenuItems.Add(item);
                }

                if (p == SunModelPart.BusinessProcess || p == SunModelPart.DimensionGroup)
                {
                    MenuItem item = new MenuItem("Add Dimension", AddDimension_Click);
                    cm.MenuItems.Add(item);
                }
                if (p == SunModelPart.BusinessProcess || p == SunModelPart.MeasureGroup)
                {
                    MenuItem item = new MenuItem("Add Measure", AddMeasure_Click);
                    cm.MenuItems.Add(item);
                }
                if (p == SunModelPart.Measure)
                {
                    MenuItem item = new MenuItem();
                    item.Text = "Add Aggegation";
                    item.Click += (s, EventArgs) => { AddAggregation_Click(sender, EventArgs, (TreeNode)e.Node); };
                    cm.MenuItems.Add(item);

                }
                if (p == SunModelPart.Dimension)
                {
                    TreeNodeCollection n = ((TreeNode)e.Node).Nodes;
                    if (n == null || n.Count == 0)
                    {
                        MenuItem item = new MenuItem();
                        item.Text = "Add Attribute";
                        item.Click += (s, EventArgs) => { AddAttribute_Click(sender, EventArgs, (TreeNode)e.Node); };
                        cm.MenuItems.Add(item);
                    }
                }
                if (p == SunModelPart.Attribute)
                {
                    MenuItem item = new MenuItem();
                    item.Text = "Add Attribute";
                    item.Click += (s, EventArgs) => { AddAttribute_Click(sender, EventArgs, (TreeNode)e.Node); };
                    cm.MenuItems.Add(item);
                }
                cm.Show((Control)sender, e.Location);

            }
        }

        private void AddAggregation_Click(object sender, EventArgs e, TreeNode t)
        {
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess b = this.cmodel.GetBusinessProcess(businessProcess);
            Measure m = b.GetMeasure(t.Text);

            using (AddAggregation am = new AddAggregation(b))
            {
                Point location = new Point((this.Left + (this.Width / 2)) - am.Width / 2, (this.Top + (this.Height / 2)) - am.Height / 2);
                am.StartPosition = FormStartPosition.Manual;
                am.Location = location;
                var result = am.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Aggregation a = new Aggregation();
                    a.AggType = am.AggType.Text;
                    a.AssocLevelUID = am.Level.SelectedValue.ToString();
                    m.AddAggregation(a);
                    this.Draw();
                    tabControlArea.SelectTab(businessProcess);
                }
            }
        }

        /// <summary>
        /// Converts the item into a shared node.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="t">The tree node to be converted.</param>
        /// <param name="type">The type of conversion.</param>
        private void ConvertItem_Click(object sender, EventArgs eventArgs, TreeNode t, ReferenceType type)
        {
            this.cmodel.ConvertLevelByUID(t.Name, Utils.GetDimension(t), Utils.GetBusinessProcessName(t), type);
            this.Draw();
        }


        /// <summary>
        /// Draws the tree.
        /// </summary>
        private void DrawTree()
        {
            tabControlArea.SelectedIndexChanged -= tabControlArea_SelectedIndexChanged;
            tabControlArea.TabPages.Clear();
            tabControlArea.SelectedIndexChanged += tabControlArea_SelectedIndexChanged;


            foreach (BusinessProcess b in this.cmodel.BusinessProcess)
            {
                string title = b.Name;
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                myTabPage.BorderStyle = BorderStyle.None;
                myTabPage.Size = new Size(tabControlArea.Width, tabControlArea.Height);
                myTabPage.AutoSize = true;
                myTabPage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                tabControlArea.TabPages.Add(myTabPage);
                TreeView t = new TreeView();
                t.BorderStyle = BorderStyle.None;
                t.Name = title;
                t.Size = new System.Drawing.Size(myTabPage.Width, myTabPage.Height);
                t.HideSelection = false;
                t.AutoSize = true;
                t.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                myTabPage.Controls.Add(t);
                t.Nodes.Add(b.GetTree());
                t.ExpandAll();
                t.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(DynTree_AfterSelect);
            }
        }
        
        /// <summary>
        /// Draws the treeview and the graphics.
        /// </summary>
        public void Draw()
        {
            DrawTree();
            RefreshGraphics();
        }

        /// <summary>
        /// Handles the Click event of the AddMeasure control. Button, Menu or Tree Node.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddMeasure_Click(object sender, EventArgs e)
        {
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess b = this.cmodel.GetBusinessProcess(businessProcess);

            using (AddMeasure am = new AddMeasure(b))
            {
                Point location = new Point((this.Left + (this.Width / 2)) - am.Width / 2, (this.Top + (this.Height / 2)) - am.Height / 2);
                am.StartPosition = FormStartPosition.Manual;
                am.Location = location;
                var result = am.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Measure m = new Measure();
                    m.Name = am.MeasureName.Text;
                    m.Type = (MeasureType)Enum.Parse(typeof(MeasureType), am.MeasureType.Text);
                    b.AddMeasure(m);
                    this.Draw();
                    tabControlArea.SelectTab(businessProcess);
                }
            }
        }
        
        /// <summary>
        /// Remove Item on Tree Node selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="t">The t.</param>
        private void RemoveItem_Click(object sender, EventArgs e, TreeNode t)
        {
            SunModelPart p = Utils.GetTreeNodeClass(t);
            string s = String.Concat("Please confirm you are deleteing ",p.ToString(), " ",t.Text);
            using (Confirm c = new Confirm(s))
            {
                Point location = new Point((this.Left + (this.Width / 2)) - c.Width / 2, (this.Top + (this.Height / 2)) - c.Height / 2);
                c.StartPosition = FormStartPosition.Manual;
                c.Location = location;
                var result = c.ShowDialog();
                if (result == DialogResult.OK)
                {
                    
                    if (p == SunModelPart.Measure)
                    {
                        this.cmodel.RemoveMeasure(t.Text, Utils.GetBusinessProcessName(t));
                    }
                    if (p == SunModelPart.Dimension)
                    {
                        this.cmodel.RemoveDimension(t.Text, Utils.GetBusinessProcessName(t));
                    }
                    if (p == SunModelPart.Attribute || p == SunModelPart.SharedNodeReference)
                    {
                        this.cmodel.RemoveLevelByUID(t.Name, Utils.GetDimension(t), Utils.GetBusinessProcessName(t));
                    }
                    if (p == SunModelPart.BusinessProcess)
                    {
                        this.cmodel.RemoveBusinessProcess(t.Text);
                        tabControlArea.TabPages.Remove(tabControlArea.SelectedTab);
                    }
                    else
                    {
                        t.Remove();
                    }
                    RefreshGraphics();
                }
            }
        }
        
        /// <summary>
        /// Handles the Click event of the AddDimension control. Button, Menu or Tree Node.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddDimension_Click(object sender, EventArgs e)
        {
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess b = this.cmodel.GetBusinessProcess(businessProcess);
            using (AddDimension am = new AddDimension(b))
            {
                Point location = new Point((this.Left + (this.Width / 2)) - am.Width / 2, (this.Top + (this.Height / 2)) - am.Height / 2);
                am.StartPosition = FormStartPosition.Manual;
                am.Location = location;
                var result = am.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dimension d = new Dimension();
                    d.Name = am.DimensionName.Text;

                    b.AddDimension(d);
                    this.Draw();
                    tabControlArea.SelectTab(businessProcess);
                }
            }

        }
        
        /// <summary>
        /// Adds the add attribute click from the tree.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="t">The t.</param>
        private void AddAttribute_Click(object sender, EventArgs e, TreeNode t)
        {

            string d = Utils.GetDimension(t);
            string n = t.Name;
            this.LaunchAddAttribute(d, n);

        }

        /// <summary>
        /// Launches the add attribute form.
        /// </summary>
        /// <param name="dimensionName">Name of the dimension.</param>
        /// <param name="parentName">Name of the parent.</param>
        private void LaunchAddAttribute(string dimensionName, string parentName)
        {
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess b = this.cmodel.GetBusinessProcess(businessProcess);

            using (AddAttribute am = new AddAttribute(b, dimensionName, parentName))
            {
                Point location = new Point((this.Left + (this.Width / 2)) - am.Width / 2, (this.Top + (this.Height / 2)) - am.Height / 2);
                am.StartPosition = FormStartPosition.Manual;
                am.Location = location;
                var result = am.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Level l = new Level();

                    if (am.IsSharedNode.Checked)
                    {
                        Level sh = b.GetSharedNodeLevelByUID(am.SharedNodeName.SelectedValue.ToString());
                        if (am.ConvergedKey.Checked)
                        {
                            l.ConvergedKey = sh.Key;
                        }
                        else if (am.CDAKey.Checked)
                        {
                            l.CDAKey = sh.Key;
                        }
                        else
                        {
                            l.Key = sh.Key;

                        }
                    }
                    else
                    {
                        l.Name = am.AttributeName.Text;
                        l.Type = (LevelType)Enum.Parse(typeof(LevelType), am.AttributeType.Text);
                        l.OptionalLevel = am.OptionalLevel.Checked;
                        l.OptionalRelationship = am.OptionalBranch.Checked;
                        l.MultipleRelationship = am.ManyToMany.Checked;
                        l.Recursive = am.Recursive.Checked;
                    }
                    Dimension d = b.GetDimension(am.Dimension.Text);
                    if (am.Parent.Text.ToString() == "n/a" && am.Parent.SelectedValue == null)
                    {
                        d.Level = l;
                    }
                    else
                    {
                        Level parent = d.GetLevelByUID(am.Parent.SelectedValue.ToString());
                        if (parent.Level1 == null)
                        {
                            parent.Level1 = new List<Level>(); ;
                        }
                        parent.Level1.Add(l);
                    }
                    
                    this.Draw();
                    tabControlArea.SelectTab(businessProcess);
                }
            }
        }


        /// <summary>
        /// Refreshes the graphics.
        /// </summary>
        /// <param name="centerX">The center x.</param>
        /// <param name="centerY">The center y.</param>
        private void RefreshGraphics(int centerX = 0, int centerY = 0)
        {
            if (centerX == 0 || centerY == 0)
            {
                centerX = groupBoxDrawArea.Bounds.Width / 2;
                centerY = groupBoxDrawArea.Bounds.Height / 2;
            }
            this.graphics.Clear(Color.White);
            this.graphics = groupBoxDrawArea.CreateGraphics();
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess bc = this.cmodel.GetBusinessProcess(businessProcess);
            bc.DrawSunModelGraphics(this.graphics, centerX, centerY, groupBoxDrawArea.Bounds.Width, groupBoxDrawArea.Bounds.Height, this.zoom);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the tabControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tabControlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl t = (TabControl)sender;
            if (t.SelectedTab == null || t.TabPages.Count == 0)
                return;
            RefreshGraphics();
        }

        /// <summary>
        /// Handles the Resize event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if(this.tabControlArea != null && this.tabControlArea.TabCount>0)
            {
                if (this.tabControlArea.SelectedTab == null)
                    return;
                RefreshGraphics();
            }
  
        }

        /// <summary>
        /// Handles the Click event of the AddAttribute control. Used for all but treeview where we know the parent
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddAttribute_Click(object sender, EventArgs e)
        {
            LaunchAddAttribute(null, null);
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of the PropertyGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyValueChangedEventArgs"/> instance containing the event data.</param>
        private void propertyGridArea_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e)
        {
            Draw();
            
        }

        /// <summary>
        /// Handles the Click event of the drawing area control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void groupBoxDrawArea_Click(object sender, EventArgs e)
        {
            Point point = groupBoxDrawArea.PointToClient(Cursor.Position);
            string businessProcess = this.tabControlArea.SelectedTab.Text;
            BusinessProcess bc = this.cmodel.GetBusinessProcess(businessProcess);
            foreach (Node entry in bc.Paths)
            {
                if (entry.Path.IsVisible(point))
                {
                    TreeView t = (TreeView)this.tabControlArea.SelectedTab.GetChildAtPoint(new Point(0, 0));
                    TreeNode tn = Utils.GetTreeNodeByGUID(entry.Level.UID, t);
                    if (tn != null)
                    {
                        t.SelectedNode = tn;
                        UpdatePropertyGrid(tn);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Scroll event of the trackBarZoom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (System.Windows.Forms.TrackBar)sender;
            this.zoom = ((double)tb.Value) / 10;
            this.RefreshGraphics();
        }

        /// <summary>
        /// Handles the MouseWheel event of the groupBoxDrawArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void groupBoxDrawArea_MouseWheel(object sender, MouseEventArgs e)
        {

            int numberofPoints = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (trackBarZoom.Value + numberofPoints <= trackBarZoom.Maximum && trackBarZoom.Value + numberofPoints >= trackBarZoom.Minimum)
            {
                trackBarZoom.Value += numberofPoints;
            }
            this.zoom = ((double)trackBarZoom.Value) / 10;
            this.RefreshGraphics();
        }

        /// <summary>
        /// Handles the Click event of the Main Menu Insert -> Attribute  control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void attributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchAddAttribute(null, null);
        }

        /// <summary>
        /// Handles the ResizeEnd event of the EZSunModel control. When moving the form off the page the drawing can disappear. This handles the redraw
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EZSunModel_ResizeEnd(object sender, EventArgs e)
        {
            if (this.cmodel != null && this.cmodel.BusinessProcess != null && this.cmodel.BusinessProcess.Count > 0)
            {
                Draw();
            }
        }
    }
}
