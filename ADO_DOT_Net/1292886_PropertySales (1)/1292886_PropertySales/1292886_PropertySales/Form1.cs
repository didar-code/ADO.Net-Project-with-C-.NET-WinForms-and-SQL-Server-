//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;

//using _1292886_PropertySales.Entities;
//using _1292886_PropertySales.Repositories;
//using _1292886_PropertySales.RPTViewers;
//using _1292886_PropertySales.ViewModels;

//namespace _1292886_PropertySales
//{
//    public partial class Form1 : Form
//    {
//        private readonly OpenFileDialog ofd = new OpenFileDialog();

//        private bool isDefaultImage = true;
//        private string previousImage = "";
//        private int intSalesId = 0;

//        private int intPropertyId = 0;

//        private bool imageChanged = false;
//        private readonly List<Property> pendingNewSaleProperties = new List<Property>();
//        private readonly Dictionary<int, List<Property>> pendingPropertiesBySaleId = new Dictionary<int, List<Property>>();

//        private Sales sales = new Sales();
//        private Property property = new Property();

//        private readonly SalesRepo repo = new SalesRepo();

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            LoadPaymentCombo();
//            LoadSalesGridView();
//            ClearAll();
//        }

//        private void ClearAll()
//        {
//            LoadDefaultImage();
//            isDefaultImage = true;
//            previousImage = "";
//            ofd.FileName = "";
//            imageChanged = false;

//            txtPaid.Checked = false;

//            dgvProperty.DataSource = null;
//            dgvProperty.Columns.Clear();

//            dgvSalesWise.DataSource = null;
//            dgvSalesWise.Columns.Clear();

//            txtName.Text = "";
//            txtPhone.Text = "";
//            txtPrice.Text = "0";
//            txtPayment.SelectedIndex = 0;

//            txtProperty.Text = "";
//            txtLocation.Text = "";

//            txtSaveSale.Text = "Save...";
//            txtSaveProperty.Text = "Save..";

//            intSalesId = 0;
//            intPropertyId = 0;


//            pendingNewSaleProperties.Clear();
//            pendingPropertiesBySaleId.Clear();

//            sales = new Sales();
//            property = new Property();
//        }

//        private void LoadDefaultImage()
//        {
//            string noImagePath = Path.Combine(Application.StartupPath, "images", "noimage.png");
//            if (File.Exists(noImagePath))
//            {
//                using (var stream = new FileStream(noImagePath, FileMode.Open, FileAccess.Read))
//                {
//                    txtImage.Image = Image.FromStream(stream);
//                }
//            }
//        }

//        // -------------------- Combo --------------------
//        private void LoadPaymentCombo()
//        {
//            DataTable dt = repo.GetAllPaymentMethods();
//            DataRow topRow = dt.NewRow();
//            topRow[0] = 0;
//            topRow[1] = "--Select Payment--";
//            dt.Rows.InsertAt(topRow, 0);

//            txtPayment.DataSource = dt;
//            txtPayment.DisplayMember = "PaymentType";
//            txtPayment.ValueMember = "PaymentId";
//        }

//        // -------------------- Helper: Add Button Column --------------------
//        private void AddGridButton(DataGridView grid, string name, string text, int width = 60)
//        {
//            if (grid.Columns.Contains(name)) return;

//            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
//            {
//                Name = name,
//                HeaderText = text,
//                Text = text,
//                Width = width,
//                UseColumnTextForButtonValue = true
//            };
//            grid.Columns.Add(btn);
//        }

//        // -------------------- Load Sales Grid --------------------
//        private void LoadSalesGridView()
//        {
//            dgvSales.DataSource = null;
//            dgvSales.Columns.Clear();

//            DataTable dt = repo.GetAllSales();

//            if (!dt.Columns.Contains("Image"))
//                dt.Columns.Add("Image", typeof(byte[]));

//            foreach (DataRow dr in dt.Rows)
//            {
//                string imgName = dr["ClientImage"]?.ToString() ?? "";
//                string imgPath = Path.Combine(Application.StartupPath, "images", imgName);
//                string defaultPath = Path.Combine(Application.StartupPath, "images", "noimage.png");

//                try
//                {
//                    dr["Image"] = File.Exists(imgPath) ? File.ReadAllBytes(imgPath) : File.ReadAllBytes(defaultPath);
//                }
//                catch { dr["Image"] = null; }
//            }

//            dgvSales.AutoGenerateColumns = true;
//            dgvSales.DataSource = dt;

//            dgvSales.RowTemplate.Height = 80;

//            if (dgvSales.Columns["Image"] is DataGridViewImageColumn imgCol)
//            {
//                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
//            }

//            if (dgvSales.Columns.Contains("SalesId")) dgvSales.Columns["SalesId"].Visible = false;
//            if (dgvSales.Columns.Contains("ClientImage")) dgvSales.Columns["ClientImage"].Visible = false;

//            AddGridButton(dgvSales, "Details", "Details");
//            AddGridButton(dgvSales, "Edit", "Edit");
//            AddGridButton(dgvSales, "Delete", "Delete");

//            dgvSales.Columns["Details"].DisplayIndex = 0;
//            dgvSales.Columns["Edit"].DisplayIndex = 1;
//            dgvSales.Columns["Delete"].DisplayIndex = 2;
//            if (dgvSales.Columns.Contains("Image")) dgvSales.Columns["Image"].DisplayIndex = 3;
//            if (dgvSales.Columns.Contains("SalesId"))
//                dgvSales.Columns["SalesId"].Visible = false;

//            if (dgvSales.Columns.Contains("PaymentId"))
//                dgvSales.Columns["PaymentId"].Visible = false;

//            if (dgvSales.Columns.Contains("IsPaid"))
//                dgvSales.Columns["IsPaid"].Visible = false;
//        }

//        // -------------------- Browse / Cancel --------------------
//        private void txtBrowse_Click(object sender, EventArgs e)
//        {
//            ofd.Filter = "Images(.jpg,.png)|*.jpg;*.png";
//            if (ofd.ShowDialog() == DialogResult.OK)
//            {
//                using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
//                {
//                    txtImage.Image = Image.FromStream(stream);
//                }

//                isDefaultImage = false;
//                imageChanged = true;
//            }
//        }

//        private void txtcancel_Click(object sender, EventArgs e)
//        {
//            LoadDefaultImage();
//            isDefaultImage = true;
//            ofd.FileName = "";
//            imageChanged = false;
//        }

//        private string SaveImage(string imgPath)
//        {
//            string fileName = Path.GetFileNameWithoutExtension(imgPath);
//            string ext = Path.GetExtension(imgPath);

//            fileName = fileName.Length <= 15 ? fileName : fileName.Substring(0, 15);
//            fileName = fileName + DateTime.Now.ToString("yymmssfff") + ext;

//            string dir = Path.Combine(Application.StartupPath, "images");
//            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

//            string savePath = Path.Combine(dir, fileName);

//            using (Bitmap bmp = new Bitmap(txtImage.Image))
//            {
//                bmp.Save(savePath);
//            }

//            return fileName;
//        }

//        private void DeleteImageFile(string fileName)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(fileName)) return;

//                string path = Path.Combine(Application.StartupPath, "images", fileName);
//                if (File.Exists(path) && fileName.ToLower() != "noimage.png")
//                {
//                    txtImage.Image?.Dispose();
//                    txtImage.Image = null;
//                    File.Delete(path);
//                }
//            }
//            catch { }
//        }

//        // -------------------- Save / Update Sale --------------------
//        private void txtSaveSale_Click(object sender, EventArgs e)
//        {
//            if (!ValidatedSale())
//            {
//                MessageBox.Show("Please Fill All required sale fields");
//                return;
//            }

//            try
//            {
//                sales.SalesId = intSalesId;
//                sales.SaleDate = txtSaleDate.Value;
//                sales.TotalPrice = Convert.ToDecimal(txtPrice.Text);
//                sales.ClientName = txtName.Text;
//                sales.MobileNo = txtPhone.Text;
//                sales.PaymentId = Convert.ToInt32(txtPayment.SelectedValue);
//                sales.IsPaid = txtPaid.Checked;

//                // ✅ FIX: Only change image if user actually selected a new one
//                if (intSalesId == 0)
//                {
//                    // New sale
//                    if (isDefaultImage)
//                    {
//                        sales.ClientImage = "noimage.png";
//                    }
//                    else if (!string.IsNullOrEmpty(ofd.FileName))
//                    {
//                        sales.ClientImage = SaveImage(ofd.FileName);
//                    }
//                    else
//                    {
//                        // fallback
//                        sales.ClientImage = "noimage.png";
//                    }
//                }
//                else
//                {
//                    // Update sale
//                    if (imageChanged && !string.IsNullOrEmpty(ofd.FileName))
//                    {
//                        if (!string.IsNullOrEmpty(previousImage) && previousImage != "noimage.png")
//                            DeleteImageFile(previousImage);

//                        sales.ClientImage = SaveImage(ofd.FileName);
//                    }
//                    else
//                    {
//                        // ✅ keep previous image
//                        sales.ClientImage = previousImage;
//                    }
//                }

//                if (intSalesId == 0)
//                {
//                    int newSalesId = repo.SaveSale(sales);

//                    if (newSalesId > 0)
//                    {
//                        MessageBox.Show("Saved Successfully");
//                        SavePendingPropertiesToDb(newSalesId);
//                    }
//                }
//                else
//                {
//                    int updateCount = repo.UpdateSale(sales);

//                    if (updateCount > 0)
//                    {
//                        MessageBox.Show("Updated Successfully");
//                        SavePendingPropertiesToDb(intSalesId);
//                    }
//                }

//                LoadSalesGridView();
//                ClearAll();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error Occured {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // -------------------- Pending Properties to DB --------------------
//        private void SavePendingPropertiesToDb(int salesId)
//        {
//            // New sale pending properties
//            if (pendingNewSaleProperties.Count > 0)
//            {
//                foreach (var p in pendingNewSaleProperties)
//                {
//                    p.SalesId = salesId;
//                    repo.SaveProperty(p);
//                }
//                pendingNewSaleProperties.Clear();
//            }

//            // Existing sale pending properties
//            if (pendingPropertiesBySaleId.ContainsKey(salesId) && pendingPropertiesBySaleId[salesId].Count > 0)
//            {
//                foreach (var p in pendingPropertiesBySaleId[salesId])
//                {
//                    p.SalesId = salesId;
//                    repo.SaveProperty(p);
//                }
//                pendingPropertiesBySaleId[salesId].Clear();
//            }

//            LoadSaleWiseProperties(salesId);
//            LoadPropertyGridForEdit(salesId);
//        }

//        // -------------------- Save Property (Pending) --------------------
//        private void txtSaveProperty_Click(object sender, EventArgs e)
//        {
//            if (!ValidatedProperty())
//            {
//                MessageBox.Show("Please Fill required property fields");
//                return;
//            }

//            try
//            {
//                Property p = new Property
//                {
//                    PropertyId = 0,
//                    PropertyType = txtProperty.Text.Trim(),
//                    Location = txtLocation.Text.Trim(),
//                    SalesId = intSalesId
//                };

//                // New sale yet not saved
//                if (intSalesId == 0)
//                {
//                    pendingNewSaleProperties.Add(p);

//                    dgvSalesWise.DataSource = null;
//                    dgvSalesWise.Columns.Clear();

//                    dgvProperty.DataSource = null;
//                    dgvProperty.Columns.Clear();
//                    dgvProperty.DataSource = pendingNewSaleProperties;
//                }
//                else
//                {
//                    if (!pendingPropertiesBySaleId.ContainsKey(intSalesId))
//                        pendingPropertiesBySaleId[intSalesId] = new List<Property>();

//                    pendingPropertiesBySaleId[intSalesId].Add(p);

//                    LoadSaleWiseProperties(intSalesId);

//                    dgvProperty.DataSource = null;
//                    dgvProperty.Columns.Clear();
//                    dgvProperty.DataSource = pendingPropertiesBySaleId[intSalesId];
//                }

//                txtProperty.Text = "";
//                txtLocation.Text = "";

//                intPropertyId = 0;
//                txtSaveProperty.Text = "Save..";
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error Occured {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }



//        private void LoadSaleWiseProperties(int salesId)
//        {
//            dgvSalesWise.DataSource = repo.GetPropertiesBySalesId(salesId);


//            if (dgvSalesWise.Columns.Contains("PropertyId"))
//                dgvSalesWise.Columns["PropertyId"].Visible = false;

//            if (dgvSalesWise.Columns.Contains("SalesId"))
//                dgvSalesWise.Columns["SalesId"].Visible = false;
//        }


//        private void LoadPropertyGridForEdit(int salesId)
//        {
//            dgvProperty.DataSource = null;
//            dgvProperty.Columns.Clear();

//            DataTable dt = repo.GetPropertiesBySalesId(salesId);
//            dgvProperty.AutoGenerateColumns = true;
//            dgvProperty.DataSource = dt;

//            AddGridButton(dgvProperty, "PEdit", "Edit");
//            AddGridButton(dgvProperty, "PDelete", "Delete");

//            dgvProperty.Columns["PEdit"].DisplayIndex = 0;
//            dgvProperty.Columns["PDelete"].DisplayIndex = 1;

//            if (dgvProperty.Columns.Contains("SalesId")) dgvProperty.Columns["SalesId"].Visible = false;
//            if (dgvProperty.Columns.Contains("PropertyId"))
//                dgvProperty.Columns["PropertyId"].Visible = false;

//            if (dgvProperty.Columns.Contains("SalesId"))
//                dgvProperty.Columns["SalesId"].Visible = false;
//        }

//        // -------------------- Sales Grid Buttons --------------------
//        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            int salesId = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["SalesId"].Value);
//            string command = dgvSales.Columns[e.ColumnIndex].Name;

//            switch (command)
//            {
//                case "Details":
//                    intSalesId = salesId;
//                    LoadSaleWiseProperties(salesId);

//                    dgvProperty.DataSource = null;
//                    dgvProperty.Columns.Clear();

//                    intPropertyId = 0;
//                    txtSaveProperty.Text = "Save..";
//                    txtProperty.Text = "";
//                    txtLocation.Text = "";
//                    break;

//                case "Edit":
//                    EditSaleInfo(salesId);
//                    LoadPropertyGridForEdit(salesId);
//                    break;

//                case "Delete":
//                    if (MessageBox.Show("Are you sure to delete the record?", "Sales",
//                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
//                    {
//                        DeleteSaleInfo(salesId);
//                    }
//                    break;
//            }
//        }

//        private void EditSaleInfo(int salesId)
//        {
//            txtSaveSale.Text = "Update...";
//            intSalesId = salesId;
//            ofd.FileName = "";
//            imageChanged = false;

//            DataTable dt = repo.GetSalesById(salesId);
//            if (dt == null || dt.Rows.Count == 0) return;

//            DataRow row = dt.Rows[0];

//            txtName.Text = row["ClientName"].ToString();
//            txtPhone.Text = row["MobileNo"].ToString();
//            txtPrice.Text = row["TotalPrice"].ToString();
//            txtSaleDate.Value = Convert.ToDateTime(row["SaleDate"]);
//            txtPayment.SelectedValue = Convert.ToInt32(row["PaymentId"]);

//            txtPaid.Checked = row["IsPaid"] != DBNull.Value && (bool)row["IsPaid"];

//            previousImage = row["ClientImage"]?.ToString() ?? "";
//            string imgPath = Path.Combine(Application.StartupPath, "images", previousImage);

//            if (File.Exists(imgPath))
//            {
//                using (var stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
//                {
//                    txtImage.Image = Image.FromStream(stream);
//                }
//                isDefaultImage = false;
//            }
//            else
//            {
//                LoadDefaultImage();
//                isDefaultImage = true;
//            }

//            LoadSaleWiseProperties(salesId);
//            LoadPropertyGridForEdit(salesId);
//        }

//        private void DeleteSaleInfo(int salesId)
//        {
//            try
//            {
//                DataTable dt = repo.GetSalesById(salesId);
//                if (dt != null && dt.Rows.Count > 0)
//                {
//                    string imageName = dt.Rows[0]["ClientImage"]?.ToString() ?? "";
//                    DeleteImageFile(imageName);
//                }
//            }
//            catch { }

//            repo.DeletePropertiesBySalesId(salesId);
//            repo.DeleteSale(salesId);

//            LoadSalesGridView();
//            ClearAll();
//        }


//        private void dgvProperty_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            string columnName = dgvProperty.Columns[e.ColumnIndex].Name;


//            if (columnName == "TmpDelete")
//            {
//                if (MessageBox.Show("Remove this property?", "Confirm",
//                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                {

//                    if (intSalesId == 0)
//                    {
//                        pendingNewSaleProperties.RemoveAt(e.RowIndex);
//                        dgvProperty.DataSource = null;
//                        dgvProperty.DataSource = pendingNewSaleProperties;
//                        AddPendingDeleteButton(dgvProperty);
//                    }
//                    // Existing sale pending
//                    else if (pendingPropertiesBySaleId.ContainsKey(intSalesId))
//                    {
//                        pendingPropertiesBySaleId[intSalesId].RemoveAt(e.RowIndex);
//                        dgvProperty.DataSource = null;
//                        dgvProperty.DataSource = pendingPropertiesBySaleId[intSalesId];
//                        AddPendingDeleteButton(dgvProperty);
//                    }
//                }
//                return;
//            }

//            // 🔵 DB grid (Edit / Delete)
//            if (!(dgvProperty.DataSource is DataTable)) return;

//            int propertyId = Convert.ToInt32(dgvProperty.Rows[e.RowIndex].Cells["PropertyId"].Value);

//            switch (columnName)
//            {
//                case "PDelete":
//                    if (MessageBox.Show("Delete this property from database?", "Confirm",
//                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
//                    {
//                        repo.DeleteProperty(propertyId);
//                        LoadPropertyGridForEdit(intSalesId);
//                        LoadSaleWiseProperties(intSalesId);
//                    }
//                    break;

//                case "PEdit":
//                    intPropertyId = propertyId;
//                    txtSaveProperty.Text = "Update..";
//                    txtProperty.Text = dgvProperty.Rows[e.RowIndex].Cells["PropertyType"].Value.ToString();
//                    txtLocation.Text = dgvProperty.Rows[e.RowIndex].Cells["Location"].Value.ToString();
//                    break;
//            }
//        }

//        private void AddPendingDeleteButton(DataGridView grid)
//        {
//            if (grid.Columns.Contains("TmpDelete")) return;

//            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
//            {
//                Name = "TmpDelete",
//                HeaderText = "Delete",
//                Text = "Delete",
//                Width = 60,
//                UseColumnTextForButtonValue = true
//            };
//            grid.Columns.Add(btn);
//        }

//        // -------------------- Validation --------------------
//        private bool ValidatedSale()
//        {
//            if (string.IsNullOrEmpty(txtName.Text)) return false;
//            if (string.IsNullOrEmpty(txtPhone.Text)) return false;
//            if (string.IsNullOrEmpty(txtPrice.Text)) return false;
//            if (txtPayment.SelectedIndex == 0) return false;
//            return true;
//        }

//        private bool ValidatedProperty()
//        {
//            if (string.IsNullOrEmpty(txtProperty.Text)) return false;
//            if (string.IsNullOrEmpty(txtLocation.Text)) return false;
//            return true;
//        }

//        // -------------------- Report --------------------
//        private void btnViewReport_Click(object sender, EventArgs e)
//        {
//            List<SalesInfoViewModel> list = new List<SalesInfoViewModel>();

//            DataTable dt = repo.GetAllSalesInfo();
//            if (dt != null && dt.Rows.Count > 0)
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    SalesInfoViewModel obj = new SalesInfoViewModel();

//                    obj.SalesId = Convert.ToInt32(dt.Rows[i]["SalesId"]);
//                    obj.SaleDate = Convert.ToDateTime(dt.Rows[i]["SaleDate"]);
//                    obj.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
//                    obj.ClientName = dt.Rows[i]["ClientName"].ToString();
//                    obj.MobileNo = dt.Rows[i]["MobileNo"].ToString();
//                    obj.IsPaid = Convert.ToBoolean(dt.Rows[i]["IsPaid"]);

//                    obj.PaymentId = Convert.ToInt32(dt.Rows[i]["PaymentId"]);
//                    obj.PaymentType = dt.Rows[i]["PaymentType"].ToString();

//                    //obj.PropertyId = Convert.ToInt32(dt.Rows[i]["PropertyId"]);
//                    //obj.PropertyType = dt.Rows[i]["PropertyType"].ToString();
//                    //obj.Location = dt.Rows[i]["Location"].ToString();

//                    string fullPath = Path.Combine(Application.StartupPath, "images", dt.Rows[i]["ClientImage"].ToString());
//                    obj.ClientImage = fullPath;

//                    if (File.Exists(fullPath))
//                        obj.ImageBinary = File.ReadAllBytes(fullPath);

//                    list.Add(obj);
//                }
//            }

//            using (FrmRptViewer frmObj = new FrmRptViewer(list))
//            {
//                frmObj.ShowDialog();
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using _1292886_PropertySales.Entities;
using _1292886_PropertySales.Repositories;
using _1292886_PropertySales.RPTViewers;
using _1292886_PropertySales.ViewModels;

namespace _1292886_PropertySales
{
    public partial class Form1 : Form
    {
        private readonly OpenFileDialog ofd = new OpenFileDialog();

        private bool isDefaultImage = true;
        private string previousImage = "";
        private int intSalesId = 0;

        private int intPropertyId = 0;

        private bool imageChanged = false;
        private readonly List<Property> pendingNewSaleProperties = new List<Property>();
        private readonly Dictionary<int, List<Property>> pendingPropertiesBySaleId = new Dictionary<int, List<Property>>();

        private Sales sales = new Sales();
        private Property property = new Property();

        private readonly SalesRepo repo = new SalesRepo();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPaymentCombo();
            LoadSalesGridView();
            ClearAll();
        }

        private void ClearAll()
        {
            LoadDefaultImage();
            isDefaultImage = true;
            previousImage = "";
            ofd.FileName = "";
            imageChanged = false;

            txtPaid.Checked = false;

            dgvProperty.DataSource = null;
            dgvProperty.Columns.Clear();

            dgvSalesWise.DataSource = null;
            dgvSalesWise.Columns.Clear();

            txtName.Text = "";
            txtPhone.Text = "";
            txtPrice.Text = "0";
            txtPayment.SelectedIndex = 0;

            txtProperty.Text = "";
            txtLocation.Text = "";

            txtSaveSale.Text = "Save...";
            txtSaveProperty.Text = "Save..";

            intSalesId = 0;
            intPropertyId = 0;

            pendingNewSaleProperties.Clear();
            pendingPropertiesBySaleId.Clear();

            sales = new Sales();
            property = new Property();
        }

        
        private void SetPictureBoxImage(string path)
        {
            if (!File.Exists(path)) return;
            txtImage.Image?.Dispose();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var img = Image.FromStream(fs))
            {
                
                txtImage.Image = (Image)img.Clone();
            }
        }

        private void LoadDefaultImage()
        {
            string noImagePath = Path.Combine(Application.StartupPath, "images", "noimage.png");
            if (File.Exists(noImagePath))
            {
                SetPictureBoxImage(noImagePath);
            }
            else
            {
                txtImage.Image?.Dispose();
                txtImage.Image = null;
            }
        }

        // -------------------- Combo --------------------
        private void LoadPaymentCombo()
        {
            DataTable dt = repo.GetAllPaymentMethods();
            DataRow topRow = dt.NewRow();
            topRow[0] = 0;
            topRow[1] = "--Select Payment--";
            dt.Rows.InsertAt(topRow, 0);

            txtPayment.DataSource = dt;
            txtPayment.DisplayMember = "PaymentType";
            txtPayment.ValueMember = "PaymentId";
        }

        // -------------------- Helper: Add Button Column --------------------
        private void AddGridButton(DataGridView grid, string name, string text, int width = 60)
        {
            if (grid.Columns.Contains(name)) return;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = text,
                Text = text,
                Width = width,
                UseColumnTextForButtonValue = true
            };
            grid.Columns.Add(btn);
        }

        // -------------------- Load Sales Grid --------------------
        private void LoadSalesGridView()
        {
            dgvSales.DataSource = null;
            dgvSales.Columns.Clear();

            DataTable dt = repo.GetAllSales();

            if (!dt.Columns.Contains("Image"))
                dt.Columns.Add("Image", typeof(byte[]));

            foreach (DataRow dr in dt.Rows)
            {
                string imgName = dr["ClientImage"]?.ToString() ?? "";
                string imgPath = Path.Combine(Application.StartupPath, "images", imgName);
                string defaultPath = Path.Combine(Application.StartupPath, "images", "noimage.png");

                try
                {
                    dr["Image"] = File.Exists(imgPath) ? File.ReadAllBytes(imgPath) : File.ReadAllBytes(defaultPath);
                }
                catch { dr["Image"] = null; }
            }

            dgvSales.AutoGenerateColumns = true;
            dgvSales.DataSource = dt;

            dgvSales.RowTemplate.Height = 80;

            if (dgvSales.Columns["Image"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            if (dgvSales.Columns.Contains("SalesId")) dgvSales.Columns["SalesId"].Visible = false;
            if (dgvSales.Columns.Contains("ClientImage")) dgvSales.Columns["ClientImage"].Visible = false;

            AddGridButton(dgvSales, "Details", "Details");
            AddGridButton(dgvSales, "Edit", "Edit");
            AddGridButton(dgvSales, "Delete", "Delete");

            dgvSales.Columns["Details"].DisplayIndex = 0;
            dgvSales.Columns["Edit"].DisplayIndex = 1;
            dgvSales.Columns["Delete"].DisplayIndex = 2;
            if (dgvSales.Columns.Contains("Image")) dgvSales.Columns["Image"].DisplayIndex = 3;
            if (dgvSales.Columns.Contains("SalesId"))
                dgvSales.Columns["SalesId"].Visible = false;

            if (dgvSales.Columns.Contains("PaymentId"))
                dgvSales.Columns["PaymentId"].Visible = false;

            if (dgvSales.Columns.Contains("IsPaid"))
                dgvSales.Columns["IsPaid"].Visible = false;
        }

        // -------------------- Browse / Cancel --------------------
        private void txtBrowse_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Images(.jpg,.png)|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SetPictureBoxImage(ofd.FileName);
                isDefaultImage = false;
                imageChanged = true;
            }
        }

        private void txtcancel_Click(object sender, EventArgs e)
        {
            LoadDefaultImage();
            isDefaultImage = true;
            ofd.FileName = "";
            imageChanged = false;
        }

        
        private string SaveImage(string imgPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(imgPath);
            string ext = Path.GetExtension(imgPath);

            fileName = fileName.Length <= 15 ? fileName : fileName.Substring(0, 15);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + ext;

            string dir = Path.Combine(Application.StartupPath, "images");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            string savePath = Path.Combine(dir, fileName);

            using (Bitmap bmp = new Bitmap(imgPath))
            {
                bmp.Save(savePath);
            }

            return fileName;
        }

        private void DeleteImageFile(string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName)) return;

                string path = Path.Combine(Application.StartupPath, "images", fileName);
                if (File.Exists(path) && fileName.ToLower() != "noimage.png")
                {
                    File.Delete(path);
                }
            }
            catch { }
        }

        // -------------------- Save / Update Sale --------------------
        private void txtSaveSale_Click(object sender, EventArgs e)
        {
            if (!ValidatedSale())
            {
                MessageBox.Show("Please Fill All required sale fields");
                return;
            }

            try
            {
                sales.SalesId = intSalesId;
                sales.SaleDate = txtSaleDate.Value;
                sales.TotalPrice = Convert.ToDecimal(txtPrice.Text);
                sales.ClientName = txtName.Text;
                sales.MobileNo = txtPhone.Text;
                sales.PaymentId = Convert.ToInt32(txtPayment.SelectedValue);
                sales.IsPaid = txtPaid.Checked;

                if (intSalesId == 0)
                {
                    // New sale
                    if (isDefaultImage)
                    {
                        sales.ClientImage = "noimage.png";
                    }
                    else if (!string.IsNullOrEmpty(ofd.FileName))
                    {
                        sales.ClientImage = SaveImage(ofd.FileName);
                    }
                    else
                    {
                        sales.ClientImage = "noimage.png";
                    }
                }
                else
                {
                    // Update sale
                    if (imageChanged && !string.IsNullOrEmpty(ofd.FileName))
                    {
                        if (!string.IsNullOrEmpty(previousImage) && previousImage != "noimage.png")
                            DeleteImageFile(previousImage);

                        sales.ClientImage = SaveImage(ofd.FileName);
                    }
                    else
                    {
                        // keep previous image
                        sales.ClientImage = previousImage;
                    }
                }

                if (intSalesId == 0)
                {
                    int newSalesId = repo.SaveSale(sales);

                    if (newSalesId > 0)
                    {
                        MessageBox.Show("Saved Successfully");
                        SavePendingPropertiesToDb(newSalesId);
                    }
                }
                else
                {
                    int updateCount = repo.UpdateSale(sales);

                    if (updateCount > 0)
                    {
                        MessageBox.Show("Updated Successfully");
                        SavePendingPropertiesToDb(intSalesId);
                    }
                }

                LoadSalesGridView();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occured {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------- Pending Properties to DB --------------------
        private void SavePendingPropertiesToDb(int salesId)
        {
            // New sale pending properties
            if (pendingNewSaleProperties.Count > 0)
            {
                foreach (var p in pendingNewSaleProperties)
                {
                    p.SalesId = salesId;
                    repo.SaveProperty(p);
                }
                pendingNewSaleProperties.Clear();
            }

            // Existing sale pending properties
            if (pendingPropertiesBySaleId.ContainsKey(salesId) && pendingPropertiesBySaleId[salesId].Count > 0)
            {
                foreach (var p in pendingPropertiesBySaleId[salesId])
                {
                    p.SalesId = salesId;
                    repo.SaveProperty(p);
                }
                pendingPropertiesBySaleId[salesId].Clear();
            }

            LoadSaleWiseProperties(salesId);
            LoadPropertyGridForEdit(salesId);
        }

        // -------------------- Save Property (Pending) --------------------
        private void txtSaveProperty_Click(object sender, EventArgs e)
        {
            if (!ValidatedProperty())
            {
                MessageBox.Show("Please Fill required property fields");
                return;
            }

            try
            {
                Property p = new Property
                {
                    PropertyId = 0,
                    PropertyType = txtProperty.Text.Trim(),
                    Location = txtLocation.Text.Trim(),
                    SalesId = intSalesId
                };

                // New sale yet not saved
                if (intSalesId == 0)
                {
                    pendingNewSaleProperties.Add(p);

                    dgvSalesWise.DataSource = null;
                    dgvSalesWise.Columns.Clear();

                    dgvProperty.DataSource = null;
                    dgvProperty.Columns.Clear();
                    dgvProperty.DataSource = pendingNewSaleProperties;
                }
                else
                {
                    if (!pendingPropertiesBySaleId.ContainsKey(intSalesId))
                        pendingPropertiesBySaleId[intSalesId] = new List<Property>();

                    pendingPropertiesBySaleId[intSalesId].Add(p);

                    LoadSaleWiseProperties(intSalesId);

                    dgvProperty.DataSource = null;
                    dgvProperty.Columns.Clear();
                    dgvProperty.DataSource = pendingPropertiesBySaleId[intSalesId];
                }

                txtProperty.Text = "";
                txtLocation.Text = "";

                intPropertyId = 0;
                txtSaveProperty.Text = "Save..";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occured {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSaleWiseProperties(int salesId)
        {
            dgvSalesWise.DataSource = repo.GetPropertiesBySalesId(salesId);

            if (dgvSalesWise.Columns.Contains("PropertyId"))
                dgvSalesWise.Columns["PropertyId"].Visible = false;

            if (dgvSalesWise.Columns.Contains("SalesId"))
                dgvSalesWise.Columns["SalesId"].Visible = false;
        }

        private void LoadPropertyGridForEdit(int salesId)
        {
            dgvProperty.DataSource = null;
            dgvProperty.Columns.Clear();

            DataTable dt = repo.GetPropertiesBySalesId(salesId);
            dgvProperty.AutoGenerateColumns = true;
            dgvProperty.DataSource = dt;

            AddGridButton(dgvProperty, "PEdit", "Edit");
            AddGridButton(dgvProperty, "PDelete", "Delete");

            dgvProperty.Columns["PEdit"].DisplayIndex = 0;
            dgvProperty.Columns["PDelete"].DisplayIndex = 1;

            if (dgvProperty.Columns.Contains("SalesId")) dgvProperty.Columns["SalesId"].Visible = false;
            if (dgvProperty.Columns.Contains("PropertyId"))
                dgvProperty.Columns["PropertyId"].Visible = false;

            if (dgvProperty.Columns.Contains("SalesId"))
                dgvProperty.Columns["SalesId"].Visible = false;
        }

        // -------------------- Sales Grid Buttons --------------------
        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int salesId = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["SalesId"].Value);
            string command = dgvSales.Columns[e.ColumnIndex].Name;

            switch (command)
            {
                case "Details":
                    intSalesId = salesId;
                    LoadSaleWiseProperties(salesId);

                    dgvProperty.DataSource = null;
                    dgvProperty.Columns.Clear();

                    intPropertyId = 0;
                    txtSaveProperty.Text = "Save..";
                    txtProperty.Text = "";
                    txtLocation.Text = "";
                    break;

                case "Edit":
                    EditSaleInfo(salesId);
                    LoadPropertyGridForEdit(salesId);
                    break;

                case "Delete":
                    if (MessageBox.Show("Are you sure to delete the record?", "Sales",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DeleteSaleInfo(salesId);
                    }
                    break;
            }
        }

        private void EditSaleInfo(int salesId)
        {
            txtSaveSale.Text = "Update...";
            intSalesId = salesId;
            ofd.FileName = "";
            imageChanged = false;

            DataTable dt = repo.GetSalesById(salesId);
            if (dt == null || dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            txtName.Text = row["ClientName"].ToString();
            txtPhone.Text = row["MobileNo"].ToString();
            txtPrice.Text = row["TotalPrice"].ToString();
            txtSaleDate.Value = Convert.ToDateTime(row["SaleDate"]);
            txtPayment.SelectedValue = Convert.ToInt32(row["PaymentId"]);

            txtPaid.Checked = row["IsPaid"] != DBNull.Value && (bool)row["IsPaid"];

            previousImage = row["ClientImage"]?.ToString() ?? "";
            string imgPath = Path.Combine(Application.StartupPath, "images", previousImage);

            if (File.Exists(imgPath))
            {
                SetPictureBoxImage(imgPath);
                isDefaultImage = (previousImage.Equals("noimage.png", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                LoadDefaultImage();
                isDefaultImage = true;
            }

            LoadSaleWiseProperties(salesId);
            LoadPropertyGridForEdit(salesId);
        }

        private void DeleteSaleInfo(int salesId)
        {
            try
            {
                DataTable dt = repo.GetSalesById(salesId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string imageName = dt.Rows[0]["ClientImage"]?.ToString() ?? "";
                    DeleteImageFile(imageName);
                }
            }
            catch { }

            repo.DeletePropertiesBySalesId(salesId);
            repo.DeleteSale(salesId);

            LoadSalesGridView();
            ClearAll();
        }

        private void dgvProperty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvProperty.Columns[e.ColumnIndex].Name;

            if (columnName == "TmpDelete")
            {
                if (MessageBox.Show("Remove this property?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (intSalesId == 0)
                    {
                        pendingNewSaleProperties.RemoveAt(e.RowIndex);
                        dgvProperty.DataSource = null;
                        dgvProperty.DataSource = pendingNewSaleProperties;
                        AddPendingDeleteButton(dgvProperty);
                    }
                    else if (pendingPropertiesBySaleId.ContainsKey(intSalesId))
                    {
                        pendingPropertiesBySaleId[intSalesId].RemoveAt(e.RowIndex);
                        dgvProperty.DataSource = null;
                        dgvProperty.DataSource = pendingPropertiesBySaleId[intSalesId];
                        AddPendingDeleteButton(dgvProperty);
                    }
                }
                return;
            }

            // DB grid (Edit / Delete)
            if (!(dgvProperty.DataSource is DataTable)) return;

            int propertyId = Convert.ToInt32(dgvProperty.Rows[e.RowIndex].Cells["PropertyId"].Value);

            switch (columnName)
            {
                case "PDelete":
                    if (MessageBox.Show("Delete this property from database?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        repo.DeleteProperty(propertyId);
                        LoadPropertyGridForEdit(intSalesId);
                        LoadSaleWiseProperties(intSalesId);
                    }
                    break;

                case "PEdit":
                    intPropertyId = propertyId;
                    txtSaveProperty.Text = "Update..";
                    txtProperty.Text = dgvProperty.Rows[e.RowIndex].Cells["PropertyType"].Value.ToString();
                    txtLocation.Text = dgvProperty.Rows[e.RowIndex].Cells["Location"].Value.ToString();
                    break;
            }
        }

        private void AddPendingDeleteButton(DataGridView grid)
        {
            if (grid.Columns.Contains("TmpDelete")) return;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "TmpDelete",
                HeaderText = "Delete",
                Text = "Delete",
                Width = 60,
                UseColumnTextForButtonValue = true
            };
            grid.Columns.Add(btn);
        }

        // -------------------- Validation --------------------
        private bool ValidatedSale()
        {
            if (string.IsNullOrEmpty(txtName.Text)) return false;
            if (string.IsNullOrEmpty(txtPhone.Text)) return false;
            if (string.IsNullOrEmpty(txtPrice.Text)) return false;
            if (txtPayment.SelectedIndex == 0) return false;
            return true;
        }

        private bool ValidatedProperty()
        {
            if (string.IsNullOrEmpty(txtProperty.Text)) return false;
            if (string.IsNullOrEmpty(txtLocation.Text)) return false;
            return true;
        }

        // -------------------- Report --------------------
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            List<SalesInfoViewModel> list = new List<SalesInfoViewModel>();

            DataTable dt = repo.GetAllSalesInfo();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SalesInfoViewModel obj = new SalesInfoViewModel();

                    obj.SalesId = Convert.ToInt32(dt.Rows[i]["SalesId"]);
                    obj.SaleDate = Convert.ToDateTime(dt.Rows[i]["SaleDate"]);
                    obj.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    obj.ClientName = dt.Rows[i]["ClientName"].ToString();
                    obj.MobileNo = dt.Rows[i]["MobileNo"].ToString();
                    obj.IsPaid = Convert.ToBoolean(dt.Rows[i]["IsPaid"]);

                    obj.PaymentId = Convert.ToInt32(dt.Rows[i]["PaymentId"]);
                    obj.PaymentType = dt.Rows[i]["PaymentType"].ToString();

                    string fullPath = Path.Combine(Application.StartupPath, "images", dt.Rows[i]["ClientImage"].ToString());
                    obj.ClientImage = fullPath;

                    if (File.Exists(fullPath))
                        obj.ImageBinary = File.ReadAllBytes(fullPath);

                    list.Add(obj);
                }
            }

            using (FrmRptViewer frmObj = new FrmRptViewer(list))
            {
                frmObj.ShowDialog();
            }
        }
    }
}


