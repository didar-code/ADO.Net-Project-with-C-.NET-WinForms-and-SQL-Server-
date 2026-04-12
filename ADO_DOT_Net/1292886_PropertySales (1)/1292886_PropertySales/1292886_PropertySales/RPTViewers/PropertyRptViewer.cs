using _1292886_PropertySales.Entities;
using _1292886_PropertySales.Reports;
using _1292886_PropertySales.RPTViewers;
using _1292886_PropertySales.ViewModels;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1292886_PropertySales.RPTViewers
{
    public partial class PropertyRptViewer : Form
    {
        private readonly List<PropertyViewModel> _list;
        public PropertyRptViewer(List<PropertyViewModel> list)
        {
            InitializeComponent();
            _list = list;
        }


        private void PropertyRptViewer_Load(object sender, EventArgs e)
        {
            string rptPath = Path.Combine(Application.StartupPath, "Reports", "PropertyInfo.rpt");

            if (!File.Exists(rptPath))
            {
                MessageBox.Show("Report not found:\n" + rptPath);
                return;
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(rptPath);

            DataTable dt = ToDataTable(_list);
            rpt.SetDataSource(dt);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        private DataTable ToDataTable(List<PropertyViewModel> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PropertyId", typeof(int));
            dt.Columns.Add("PropertyType", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("SalesId", typeof(int));

            foreach (var x in list)
            {
                dt.Rows.Add(
                    x.PropertyId,
                    x.PropertyType,
                    x.Location,
                    x.SalesId
                );
            }

            return dt;
        }
    }
}