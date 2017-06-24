//------------------------------------------------------------------------------
// AddAggregation.cs
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
    public partial class AddAggregation : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddAggregation"/> class.
        /// </summary>
        /// <param name="b">The BusinessProcess b.</param>
        public AddAggregation(BusinessProcess b)
        {
            InitializeComponent();

            if (b.Dimensions != null && b.Dimensions.Count() > 0)
            {
                List<Object> items = new List<Object>();
                foreach (Dimension d in b.Dimensions)
                {
                    if (d.Level != null && d.Level.Level1 != null && d.Level.Level1.Count() != 0)
                    {
                        List<Level> list = d.Level.FlattenChildren();

                        foreach (Level l in list)

                            items.Add(new
                            {
                                Text = d.Name+": "+(l.Name!=null?l.Name:(l.Key!=null?l.Key:(l.CDAKey!=null?l.CDAKey:(l.ConvergedKey!=null?l.ConvergedKey:"Unknown")))),
                                Value = l.UID
                            });
                    }
                }
                this.Level.DisplayMember = "Text";
                this.Level.ValueMember = "Value";
                this.Level.DataSource = items;

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

            if (this.AggType.Text =="")
            {
                return false;
            }
            if (this.Level.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}
