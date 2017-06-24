//------------------------------------------------------------------------------
// Confirm.cs
//
//------------------------------------------------------------------------------

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
    public partial class Confirm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Confirm"/> class.
        /// </summary>
        /// <param name="text">The text displayed by the control.</param>
        public Confirm(String text)
        {
            InitializeComponent();
            this.label1.Text = text;
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
            this.DialogResult = DialogResult.OK;
        }
    }
}
