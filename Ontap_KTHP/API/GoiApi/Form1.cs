using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GoiApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txt_ma.Text = dataSP.Rows[d].Cells[0].Value.ToString();
            txt_ten.Text = dataSP.Rows[d].Cells[1].Value.ToString();
            txt_gia.Text = dataSP.Rows[d].Cells[2].Value.ToString();
            cboDanhMuc.Text = dataSP.Rows[d].Cells[3].Value.ToString();

        }
        public void LoadDataGridView()
        {
            string link = "http://localhost:90/ontapapi/api/sanpham";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;

        }
        public void LoadComboBox()
        {
            string link = "http://localhost:90/ontapapi/api/danhmuc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            object data = js.ReadObject(response.GetResponseStream());
            DanhMuc[] arr = data as DanhMuc[];
            cboDanhMuc.DataSource = arr;
            cboDanhMuc.ValueMember = "MaDanhMuc";
            cboDanhMuc.DisplayMember = "TenDanhMuc";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string link = "http://localhost:90/ontapapi/api/sanpham?madm="+ txt_tim.Text;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string postString = string.Format("http://localhost:90/ontapapi/api/sanpham?ma={0}&ten={1}&gia={2}&madm={3)", txt_ma.Text, txt_ten.Text,
                txt_gia.Text, cboDanhMuc.SelectedValue);
            HttpWebRequest request = WebRequest.CreateHttp(postString);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }
    }
}
