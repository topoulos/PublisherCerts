using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Entity;
using CertData;

namespace CertUtility
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private async void btnReprintLast_Click(object sender, EventArgs e)
        {
            int num = (int)numCerts.Value;
            SetRunningLabel(lblStatus);

            await CertRepository.SetCompleteionStatusOnLastXCertsAsync(num, false);
            SetLabelStatus(lblStatus);
        }

        private void SetRunningLabel(Label lbl, string runningMessage = "...")
        {
            lbl.Text = runningMessage;
        }

        private async void btnGoComplete_Click(object sender, EventArgs e)
        {
            int num = (int)numCerts.Value;
            SetRunningLabel(lblMarkCompleteStatus);

            await CertRepository.SetCompleteionStatusOnLastXCertsAsync(num, true);
            SetLabelStatus(lblMarkCompleteStatus);
        }

        private static void SetLabelStatus(Label lbl, string successMessage = "Success", string failureMessage = "Failure")
        {
            try
            {
                lbl.Text =successMessage;
                lbl.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lbl.Text = failureMessage + " : " + ex.Message;
                lbl.ForeColor = Color.Red;
            }
        }

        private static void SetCompletions(List<membercert> certs, bool completed)
        {
            foreach (var cert in certs)
            {
                cert.Completed = completed;
            }
        }
    }
}
