using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GoiAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txt_ma.Text = dataSP.Rows[d].Cells[0].Value.ToString();
            txt_ten.Text = dataSP.Rows[d].Cells[1].Value.ToString();
            txt_gia.Text = dataSP.Rows[d].Cells[2].Value.ToString();
            cboDanhMuc.Text = dataSP.Rows[d].Cells[3].Value.ToString();
        }
        public void LoadDataGridView()
        {
            string link = "http://localhost:90/hocrestful/api/sanpham";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            Object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;
        }
        public void LoadComboBox()
        {
            string link = "http://localhost:90/hocrestful/api/danhmuc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            Object data = js.ReadObject(response.GetResponseStream());
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
            string link = "http://localhost:90/hocrestful/api/sanpham?madm=" + txt_tim.Text;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            Object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}",
                    txt_ma.Text, txt_ten.Text, txt_gia.Text, cboDanhMuc.SelectedValue) ;
            string link = "http://localhost:90/hocrestful/api/sanpham" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();
            
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Them moi thanh cong");
            }
            else
            {
                MessageBox.Show("Them moi khong thanh cong");
            }
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}",
                    txt_ma.Text, txt_ten.Text, txt_gia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost:90/hocrestful/api/sanpham" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Sua moi thanh cong");
            }
            else
            {
                MessageBox.Show("Sua moi khong thanh cong");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string postString = string.Format("http://localhost:90/hocrestful/api/sanpham?id={0}", txt_ma.Text);
            HttpWebRequest request = HttpWebRequest.CreateHttp(postString);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa khong thanh cong");
            }
        }
    }
}
