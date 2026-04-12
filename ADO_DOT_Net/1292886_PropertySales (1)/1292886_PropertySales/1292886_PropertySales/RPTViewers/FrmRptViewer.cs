using _1292886_PropertySales.Repositories;
using _1292886_PropertySales.ViewModels;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _1292886_PropertySales.RPTViewers
{
    public partial class FrmRptViewer : Form
    {
        private readonly List<SalesInfoViewModel> _list;
        SalesRepo repo = new SalesRepo();

        public FrmRptViewer(List<SalesInfoViewModel> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void FrmRptViewer_Load(object sender, System.EventArgs e)
        {
            string rptPath = Path.Combine(Application.StartupPath, "Reports", "RPTSalesInfo.rpt");

            if (!File.Exists(rptPath))
            {
                MessageBox.Show("Report not found:\n" + rptPath);
                return;
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(rptPath);

            DataTable dt = ToDataTable(_list);
            rpt.SetDataSource(dt);

            var moduleData = repo.GetAllProperties();
            rpt.Subreports["PropertyInfo.rpt"].SetDataSource(moduleData);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }


        private DataTable ToDataTable(List<SalesInfoViewModel> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SalesId", typeof(int));
            dt.Columns.Add("SaleDate", typeof(System.DateTime));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            dt.Columns.Add("ClientName", typeof(string));
            dt.Columns.Add("MobileNo", typeof(string));
            dt.Columns.Add("IsPaid", typeof(bool));
            dt.Columns.Add("PaymentType", typeof(string));
            //dt.Columns.Add("PropertyType", typeof(string));
            //dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("ImageBinary", typeof(byte[]));

            foreach (var x in list)
            {
                dt.Rows.Add(
                    x.SalesId,
                    x.SaleDate,
                    x.TotalPrice,
                    x.ClientName,
                    x.MobileNo,
                    x.IsPaid,
                    x.PaymentType,
                    //x.PropertyType,
                    //x.Location,
                    x.ImageBinary
                );
            }

            return dt;
        }
    }
}
