//------------------------------------------------------------------------------
// AddAttribute.cs
//
//------------------------------------------------------------------------------

using SunModelWindows.USMM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunModelWindows
{
    public partial class AddAttribute : Form
    {
        private BusinessProcess process;
        private string parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAttribute"/> class form.
        /// </summary>
        /// <param name="b">The BusinessProcess b.</param>
        /// <param name="dimensionSelected">The dimension selected.</param>
        /// <param name="parentLevelSelected">The parent level selected.</param>
        public AddAttribute(BusinessProcess b, string dimensionSelected, string parentLevelSelected)
        {
            InitializeComponent();
            NotSharedPanel.Visible = true;
            SharedPanel.Visible = false;

            this.process = b;
            this.parent = parentLevelSelected;

            if (b.Dimensions != null && b.Dimensions.Count() > 0)
            {
                List<Object> items = new List<Object>();
                foreach (Dimension d in b.Dimensions)
                {
                    items.Add(new { Text = d.Name, Value = d.Name
                    });
                }
                this.Dimension.DisplayMember = "Text";
                this.Dimension.ValueMember = "Value";
                this.Dimension.DataSource = items;

            }
            if (dimensionSelected != null)
            {
                this.Dimension.SelectedValue = dimensionSelected;
            }
            if (b.SharedNodes == null || b.SharedNodes.Level.Count() == 0)
            {
                IsSharedNode.Visible = false;
            }
            else { 
                List<Object> items = new List<Object>();
                foreach (Level l in b.SharedNodes.Level)
                {
                    items.Add(new
                    {
                        Text = l.Name,
                        Value = l.UID
                    });
                }
                this.SharedNodeName.DisplayMember = "Text";
                this.SharedNodeName.ValueMember = "Value";
                this.SharedNodeName.DataSource = items;
            }
        }
        /// <summary>
        /// Handles the Click event of the ok control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ok_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {

                this.DialogResult = DialogResult.OK;
            }
       
        }

        /// <summary>
        /// Handles the Click event of the cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {

            if (this.process == null || process.GetDimension(this.Dimension.Text) == null)
            {
                return false;
            }
            if (IsSharedNode.Checked == false)
            {
                if (this.AttributeName.Text == "")
                {
                    return false;
                }
            }else if(this.SharedNodeName.Text =="")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the Dimension control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Dimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Object> items = new List<Object>();
            ComboBox c = (ComboBox)sender;
            if(this.process == null || this.process.GetDimension(c.SelectedValue.ToString()) == null
                 || this.process.GetDimension(c.SelectedValue.ToString()).Level == null)
            {
                this.Parent.Enabled = false;
                this.Parent.DataSource = null;
                this.Parent.Text = "n/a";
                return;
            }
            this.Parent.Enabled = true;
            Dimension d = this.process.GetDimension(c.SelectedValue.ToString());
            List<Level> list = d.GetDimensionAllLevels();
          
           
                foreach (Level l in list)
                {
                    items.Add(new
                    {
                        Text = l.Name,
                        Value = l.UID
                    });
                }
            
            this.Parent.DisplayMember = "Text";
            this.Parent.ValueMember = "Value";
            this.Parent.DataSource = items;
            
            if (parent != null)
            {
                this.Parent.SelectedValue = parent;
            }
        }


        /// <summary>
        /// Handles the CheckedChanged event of the IsSharedNode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void IsSharedNode_CheckedChanged(object sender, EventArgs e)
        {
            if (IsSharedNode.Checked)
            {
                NotSharedPanel.Visible = false;
                SharedPanel.Visible = true;
            }
            else
            {
                NotSharedPanel.Visible = true;
                SharedPanel.Visible = false;
            }
        }
        
    }
}
