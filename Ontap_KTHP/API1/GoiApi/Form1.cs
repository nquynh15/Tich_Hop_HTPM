using System;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace GoiApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadDataGridView()
        {
            string link = "http://localhost:90/hocapi/api/sanpham";

            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());

            SanPham[]  arr = data as SanPham[];
            dataSanPham.DataSource = arr;
        }
        public void LoadComboBox()
        {
            string link = "http://localhost:90/hocapi/api/danhmuc";

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

        private void dataSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txt_ma.Text = dataSanPham.Rows[d].Cells[0].Value.ToString();
            txt_ten.Text = dataSanPham.Rows[d].Cells[1].Value.ToString();
            txt_gia.Text = dataSanPham.Rows[d].Cells[2].Value.ToString();
            cboDanhMuc.Text = dataSanPham.Rows[d].Cells[3].Value.ToString();
        }
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string madm = txt_tim.Text;
            string link = "http://localhost:90/hocapi/api/sanpham?madm=" + madm;

            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());

            SanPham[] arr = data as SanPham[];
            dataSanPham.DataSource = arr;

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}", txt_ma.Text, txt_ten.Text, 
                                                txt_gia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost:90/hocapi/api/sanpham" + postString;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method= "POST";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;
            //tao luong yeu cau
            Stream dataStream  = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Them thanh cong!");
            }
            else
            {
                MessageBox.Show("Them san pham that bai!");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string putString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}", txt_ma.Text, txt_ten.Text,
                                                txt_gia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost:90/hocapi/api/sanpham" + putString;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(putString);
            request.ContentLength = byteArray.Length;
            //tao luong yeu cau
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Sua thanh cong!");
            }
            else
            {
                MessageBox.Show("Sua san pham that bai!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string masp = txt_ma.Text; 
            string postString = string.Format("?id={0}", masp);
            string link = "http://localhost:90/hocapi/api/sanpham";

            HttpWebRequest request = HttpWebRequest.CreateHttp(link + postString);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
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
                MessageBox.Show("Xoa thanh cong!");
            }
            else
            {
                LoadDataGridView();
                MessageBox.Show("Xoa khong thanh cong!");
            }

        }
    }
}
