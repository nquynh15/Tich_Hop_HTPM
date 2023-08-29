using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace NguyenThiQuynh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Tạo dodói tượng sử dụng tài liệu XML
        XmlDocument doc = new XmlDocument();
        //Đường dẫn tới file XML
        string tentep = @"E:\TichHop\Bai7\NguyenThiQuynh\NguyenThiQuynh\dsnhanvien.xml";
        int d;  //Xác định chỉ số dòng được chọn trên DataGrid

        private void HienThi()
        {
            datanhanvien.Rows.Clear();
            doc.Load(tentep);

            //Tạo đối tượng DS chứa ds các nút nhanvien
            XmlNodeList DS = doc.SelectNodes("ds/nhanvien");
            int sd = 0;
            datanhanvien.ColumnCount = 3;
            datanhanvien.Rows.Add(); 

            //duyệt từng nút nhân viên:
            foreach(XmlNode NV in DS)
            {
                //truy xuất thuộc tính @manv
                XmlNode ma_nv = NV.SelectSingleNode("@manv");
                //lấy giá trị của thuộc tính @manv đưa lên cột thứ 1 của dòng trên DataGrid
                datanhanvien.Rows[sd].Cells[0].Value = ma_nv.InnerText.ToString();
                //Truy xuatá nút họ tên
                XmlNode ho_ten = NV.SelectSingleNode("hoten");
                datanhanvien.Rows[sd].Cells[1].Value = ho_ten.InnerText.ToString();

                XmlNode dia_chi = NV.SelectSingleNode("diachi");
                datanhanvien.Rows[sd].Cells[2].Value = dia_chi.InnerText.ToString();
                datanhanvien.Rows.Add();
                sd++;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nhan_vien_moi = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtmanv.Text + "']");
            if (nhan_vien_moi != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại ");
                //HienThi();
            }
            else
            {
                XmlNode nhan_vien = doc.CreateElement("nhanvien");
                XmlAttribute ma_nv = doc.CreateAttribute("manv");
                //Xác định các giá trị của thuộc tính manv
                ma_nv.InnerText = txtmanv.Text;

                nhan_vien.Attributes.Append(ma_nv);
                //tạo nút hoten
                XmlNode ho_ten = doc.CreateElement("hoten");
                ho_ten.InnerText = txthoten.Text;
                nhan_vien.AppendChild(ho_ten);
                XmlNode dia_chi = doc.CreateElement("diachi");
                dia_chi.InnerText = txtdiachi.Text;
                nhan_vien.AppendChild(dia_chi);

                goc.AppendChild(nhan_vien);
                doc.Save(tentep);
                HienThi();
            }
            //XmlNode nhan_vien = doc.CreateElement("nhanvien");
            //XmlAttribute ma_nv = doc.CreateAttribute("manv");
            ////Xác định các giá trị của thuộc tính manv
            //ma_nv.InnerText = txtmanv.Text;

            //nhan_vien.Attributes.Append(ma_nv);
            ////tạo nút hoten
            //XmlNode ho_ten = doc.CreateElement("hoten");
            //ho_ten.InnerText = txthoten.Text;
            //nhan_vien.AppendChild(ho_ten);
            //XmlNode dia_chi = doc.CreateElement("diachi");
            //dia_chi.InnerText = txtdiachi.Text;
            //nhan_vien.AppendChild(dia_chi);

            //goc.AppendChild(nhan_vien);
            ////Lưu vào tệp xml
            //doc.Save(tentep);
            //HienThi();
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            //Xác định nút cần xóa
            XmlNode nv_xoa = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtmanv.Text + "']");
            goc.RemoveChild(nv_xoa);
            doc.Save(tentep);
            HienThi();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nv_cu = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtmanv.Text + "']");
            XmlNode nv_moi = doc.CreateElement("nhanvien");

            XmlAttribute ma_nv = doc.CreateAttribute("manv");            
            ma_nv.InnerText = txtmanv.Text;
            nv_moi.Attributes.Append(ma_nv);
            XmlNode ho_ten = doc.CreateElement("hoten");
            ho_ten.InnerText = txthoten.Text;
            nv_moi.AppendChild(ho_ten);
            XmlNode dia_chi = doc.CreateElement("diachi");
            dia_chi.InnerText = txtdiachi.Text;
            nv_moi.AppendChild(dia_chi);

            //Thay nút nhanvien cũ bang nhanvien mới
            goc.ReplaceChild(nv_moi, nv_cu);
            doc.Save(tentep);
            HienThi();
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            string path = @"E:\TichHop\Bai7\NguyenThiQuynh\NguyenThiQuynh\dsnhanvien.xml";
            System.Diagnostics.Process.Start("Explorer.exe", path);
        }

        private void Tim_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);

            XmlElement goc = doc.DocumentElement;
            XmlNode nv_tim = goc.SelectSingleNode("/ds/nhanvien[@manv = '" + txtmanv.Text + "']");

            XmlNode ma = nv_tim.SelectSingleNode("@manv");
            txtmanv.Text = ma.InnerText.ToString();
            XmlNode ht = nv_tim.SelectSingleNode("hoten");
            txthoten.Text = ht.InnerText.ToString();
            XmlNode dc = nv_tim.SelectSingleNode("diachi");
            txtdiachi.Text = dc.InnerText.ToString();



        }

        private void datanhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txtmanv.Text = datanhanvien.Rows[d].Cells[0].Value.ToString();
            txthoten.Text = datanhanvien.Rows[d].Cells[1].Value.ToString();
            txtdiachi.Text = datanhanvien.Rows[d].Cells[2].Value.ToString();
        }
    }
}
