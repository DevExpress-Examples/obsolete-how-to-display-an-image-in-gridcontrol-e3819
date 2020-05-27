using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {



        private DataTable CreateTable(int RowCount)
        {
            Image[] images = new Image[] { WindowsApplication1.Properties.Resources.about, WindowsApplication1.Properties.Resources.add, WindowsApplication1.Properties.Resources.apple, WindowsApplication1.Properties.Resources.arrow_down, WindowsApplication1.Properties.Resources.arrow_left};
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            tbl.Columns.Add("Image", typeof(Image));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i), images[i % images.Length] });
            return tbl;
        }

        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(20);

            RepositoryItemPictureEdit item = new RepositoryItemPictureEdit();
            gridControl1.RepositoryItems.Add(item);
            gridView1.Columns["Image"].ColumnEdit = item;
        }
    }
}
