using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public void LoadDataGrid()
        {
            string link = "http://localhost:90/ontaprestful/api/sanpham";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;
        }
        public void LoadComboBox()
        {
            string link = "http://localhost:90/ontaprestful/api/danhmuc";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
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
            LoadDataGrid();
            LoadComboBox();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string link = "http://localhost:90/ontaprestful/api/sanpham?madm=" + txt_tim.Text;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataSP.DataSource = arr;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}", txt_ma.Text,
                                txt_ten.Text, txt_gia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost:90/ontaprestful/api/sanpham" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);

            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray  = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;

            Stream datastream = request.GetRequestStream();
            datastream.Write(byteArray, 0, byteArray.Length);
            datastream.Close();


            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGrid();
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                MessageBox.Show("Thêm mới không thành công!");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}", txt_ma.Text,
                                txt_ten.Text, txt_gia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost:90/ontaprestful/api/sanpham" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);

            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;

            Stream datastream = request.GetRequestStream();
            datastream.Write(byteArray, 0, byteArray.Length);
            datastream.Close();


            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGrid();
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa không thành công!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string link = "http://localhost:90/ontaprestful/api/sanpham?id=" + txt_ma.Text;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);

            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(txt_tim.Text);
            request.ContentLength = byteArray.Length;

            Stream datastream = request.GetRequestStream();
            datastream.Write(byteArray, 0, byteArray.Length);
            datastream.Close();


            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGrid();
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }
    }
}
