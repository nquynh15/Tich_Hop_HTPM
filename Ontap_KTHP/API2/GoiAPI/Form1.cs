using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace GoiAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string link = "http://localhost:90/api2/api/sanpham";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];

            dataSanPham.DataSource = arr;

        }
        public void LoadComboBox()
        {
            string link = "http://localhost:90/api2/api/danhmuc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            object data = js.ReadObject(response.GetResponseStream());
            DanhMuc[] arr = data as DanhMuc[];

            cboDM.DataSource = arr;
            cboDM.ValueMember = "MaDanhMuc";
            cboDM.DisplayMember = "TenDanhMuc";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }

        private void dataSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txt_ma.Text = dataSanPham.Rows[d].Cells[0].Value.ToString();
            txt_ten.Text = dataSanPham.Rows[d].Cells[1].Value.ToString();
            txt_gia.Text = dataSanPham.Rows[d].Cells[2].Value.ToString();
            cboDM.Text = dataSanPham.Rows[d].Cells[3].Value.ToString();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {

            string link = "http://localhost:90/api2/api/sanpham?madm=" + txt_tim.Text;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];

            dataSanPham.DataSource = arr;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string postStirng = string.Format("http://localhost:90/api2/api/sanpham?ma={0}&ten={1}&gia={2}&madm={3}", txt_ma.Text,
                txt_ten.Text, txt_gia.Text, cboDM.SelectedValue);
            HttpWebRequest request = WebRequest.CreateHttp(postStirng);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8" ;
            byte[] byteArray = Encoding.UTF8.GetBytes(postStirng);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream(); 
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

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
                LoadDataGridView();
                MessageBox.Show("Them moi khong thanh cong");
            }

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string postStirng = string.Format("http://localhost:90/api2/api/sanpham?ma={0}&ten={1}&gia={2}&madm={3}", txt_ma.Text,
                txt_ten.Text, txt_gia.Text, cboDM.SelectedValue);
            HttpWebRequest request = WebRequest.CreateHttp(postStirng);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteArray = Encoding.UTF8.GetBytes(postStirng);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Sua thanh cong");
            }
            else
            {
                LoadDataGridView();
                MessageBox.Show("Sua khong thanh cong");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string postStirng = string.Format("http://localhost:90/api2/api/sanpham?id={0}", txt_ma.Text);
            HttpWebRequest request = WebRequest.CreateHttp(postStirng);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteArray = Encoding.UTF8.GetBytes(postStirng);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

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
                LoadDataGridView();
                MessageBox.Show("Xoa khong thanh cong");
            }
        }
    }
}
