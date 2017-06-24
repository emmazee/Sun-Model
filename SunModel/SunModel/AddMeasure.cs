//------------------------------------------------------------------------------
// AddMeasure.cs
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
    public partial class AddMeasure : Form
    {
        BusinessProcess process;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddMeasure"/> class.
        /// </summary>
        /// <param name="b">The business process b.</param>
        public AddMeasure(BusinessProcess b)
        {
            this.process = b;
            InitializeComponent();
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
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {

            if (this.process != null && process.GetMeasure(this.MeasureName.Text) != null)
            {
                return false;
            }
            if (this.MeasureName.Text == "")
            {
                return false;
            }
            Regex r = new Regex(@"\\");
            if (r.IsMatch(MeasureName.Text))
            {

                return false;
            }
            return true;
        }
        /// <summary>
        /// Handles the KeyDown event of the MeasureName control. This is intended to stop the "\" character being inserted
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void MeasureName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemBackslash || e.KeyCode == Keys.Oem5)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
