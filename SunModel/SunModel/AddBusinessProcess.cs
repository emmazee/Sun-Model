//------------------------------------------------------------------------------
// AddBusinessProcess.cs
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
    public partial class AddBusinessProcess : Form
    {
        ConceptualModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddBusinessProcess"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        public AddBusinessProcess(ConceptualModel c)
        {
            this.model = c;
            InitializeComponent();
            if(this.model == null || this.model.BusinessProcess==null)
            {
                this.Text = "New Sun Model";
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
            if (this.model != null && model.GetBusinessProcess(this.businessProcess.Text) != null)
            {
                return false;
            }
            if (this.businessProcess.Text == "")
            {
                return false;
            }
            Regex r = new Regex(@"\\");
            if (r.IsMatch(this.businessProcess.Text))
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// Handles the KeyDown event of the businessProcess control. This attempts to avoid the "|" character being used
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void businessProcess_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemBackslash || e.KeyCode == Keys.Oem5)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
