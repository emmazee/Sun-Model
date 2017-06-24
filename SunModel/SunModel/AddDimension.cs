//------------------------------------------------------------------------------
// AddDimension.cs
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunModelWindows
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddDimension : Form
    {
        BusinessProcess businessProcess;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddDimension"/> class.
        /// </summary>
        /// <param name="b">The business process b.</param>
        public AddDimension(BusinessProcess b)
        {
            InitializeComponent();
            this.businessProcess = b;
        }

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
        /// Handles the KeyDown event of the DimensionName control. Designed to stop the "\" character being included
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void DimensionName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemBackslash || e.KeyCode == Keys.Oem5)
            {
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (DimensionName.Text == "")
            {
                return false;
            }
            else if (businessProcess.GetDimension(DimensionName.Text) != null)
            {
                return false;
            }
            Regex r = new Regex(@"\\");
            if (r.IsMatch(DimensionName.Text))
            {

                return false;
            }
            return true;
        }
    }
}
