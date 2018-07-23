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
        private List<vwCertificate> _certificates;

        public int StartId { get; set; }
        public int StopId { get; set; }
        public string SearchText { get; set; }
        public QueryType QueryType { get; set; }
        public List<int> SelectedIds { get; set; }

        public List<vwCertificate> Certificates
        {
            get => _certificates;
            set
            {
                _certificates = value;
                dgCerts.DataSource = _certificates;
                dgCerts.MultiSelect = true;
            }
        }

        public frmMain()
        {
            SelectedIds = new List<int>();
            InitializeComponent();
        }

        private async void btnReprintLast_Click(object sender, EventArgs e)
        {
            int num = (int)numCerts.Value;
            SetRunningLabel(lblStatus);

            this.Cursor = Cursors.WaitCursor;
            await CertRepository.SetCompleteionStatusOnLastXCertsAsync(num, false);
            this.Cursor = Cursors.Default;

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

            this.Cursor = Cursors.WaitCursor;

            await CertRepository.SetCompleteionStatusOnLastXCertsAsync(num, true);
            this.Cursor = Cursors.Default;

            SetLabelStatus(lblMarkCompleteStatus);
        }

        private static void SetLabelStatus(Label lbl, string successMessage = "Success", string failureMessage = "Failure")
        {
            try
            {
                lbl.Text = successMessage;
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

        private async void frmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ClearStatusLabels();
            await LoadAllCertificatesAsync();
            this.Cursor = Cursors.Default;

        }

        private async Task LoadAllCertificatesAsync()
        {
            this.Cursor = Cursors.WaitCursor;

            QueryType = QueryType.AllRecords;
            Certificates = await CertRepository.GetAllCertsAsync();
            this.Cursor = Cursors.Default;

        }

        private void ClearStatusLabels()
        {
            lblMarkCompleteStatus.Text = "";
            lblStatus.Text = "";
        }

        private async Task ReplayQuery()
        {
            this.Cursor = Cursors.WaitCursor;

            switch (QueryType)
            {
                case QueryType.SearchText:
                    await SearchByTextAsync(); 
                    break;
                case QueryType.Range:
                    await SearchByIdRangeAsync();
                    break;
                case QueryType.AllRecords:
                    await LoadAllCertificatesAsync();
                    break;
                default:
                    break;
            }

            this.Cursor = Cursors.Default;

        }
        private async void btnSetSelectedIncomplete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            SaveSelectedRows();

            foreach (DataGridViewRow row in dgCerts.SelectedRows)
            {
                var id = (int)row.Cells[0].Value;
                await CertRepository.SaveIncompleteAsync(id);
            }

            await ReplayQuery();
            ReselectRows();

            this.Cursor = Cursors.Default;

        }

        private async void btnSetSeletedComplete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            SaveSelectedRows();

            foreach (DataGridViewRow row in dgCerts.SelectedRows)
            {
                var id = (int)row.Cells[0].Value;
                await CertRepository.SaveCompleteAsync(id);
            }

            await ReplayQuery();
            ReselectRows();
            this.Cursor = Cursors.Default;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            SearchText = txtSearch.Text.Trim();
            await SearchByTextAsync();

            this.Cursor = Cursors.Default;

        }

        private async Task SearchByTextAsync()
        {
            this.Cursor = Cursors.WaitCursor;

            QueryType = QueryType.SearchText;
            Certificates = await CertRepository.SearchCertificatesAsync(SearchText);

            this.Cursor = Cursors.Default;

        }

        private async Task SearchByIdRangeAsync()
        {
            this.Cursor = Cursors.WaitCursor;

            QueryType = QueryType.Range;
            Certificates = await CertRepository.SearchCertificatesByIdRangeAsync(StartId, StopId);

            this.Cursor = Cursors.Default;

        }

        private async void btnFindIdsRange_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            StartId = (int)numRangeFrom.Value;
            StopId = (int)numRangeTo.Value;

            if (StopId < StartId || StopId == 0)
                StopId = StartId;

            await SearchByIdRangeAsync();

            this.Cursor = Cursors.Default;

        }

        private void dgCerts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveSelectedRows()
        {
            SelectedIds.Clear();

            foreach (DataGridViewRow row in dgCerts.SelectedRows)
            {
                var id = (int)row.Cells[0].Value;
                SelectedIds.Add(id);
            }
        }

        private void ReselectRows()
        {
            foreach (DataGridViewRow row in dgCerts.Rows)
            {
                var id = (int)row.Cells[0].Value;

                row.Selected = SelectedIds.Contains(id);
            }
        }

        private void dgCerts_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private async void btnResetForm_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtSearch.Text = string.Empty;
            numCerts.Value = 0;
            numCompleteCerts.Value = 0;
            numRangeFrom.Value = 0;
            numRangeTo.Value = 0;
            await LoadAllCertificatesAsync();
            this.Cursor = Cursors.Default;
            
        }
    }
}
