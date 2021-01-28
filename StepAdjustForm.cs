using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDRSharp.TuningDial
{
    public partial class StepAdjustForm : Form
    {
        VirtualEncoder parentEncoder;
        public StepAdjustForm(VirtualEncoder parent)
        {
            parentEncoder = parent;
            InitializeComponent();
        }

        private void StepAdjustForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = parentEncoder.UseAutoStep;
            numericUpDown1.Value = parentEncoder.CustomStep;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
              parentEncoder.UseAutoStep = checkBox1.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           parentEncoder.CustomStep = (int)numericUpDown1.Value;
        }
    }
}
