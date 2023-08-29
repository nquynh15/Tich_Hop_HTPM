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


namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument doc = new XmlDocument();
        string tentep = @"E:\TichHop\Bai6_ontap_tx2\Dom1\Bai2\Bai2.xml";
        int d;

        private void HienThi()
        {
            doc.Load(tentep);
            datanhanvien.Rows.Clear();
            datanhanvien.ColumnCount = 5;
            int sd = 0;
            datanhanvien.Rows.Add();
            XmlNodeList ds = doc.SelectNodes("/ds/nhanvien");
            foreach (XmlNode nv in ds)
            {
                XmlNode manv = nv.SelectSingleNode("@manv");
                datanhanvien.Rows[sd].Cells[0].Value = manv.InnerText.ToString();
                XmlNode hoten = nv.SelectSingleNode("hoten");
                datanhanvien.Rows[sd].Cells[1].Value = hoten.InnerText.ToString();
                XmlNode gioitinh = nv.SelectSingleNode("gioitinh");
                datanhanvien.Rows[sd].Cells[2].Value = gioitinh.InnerText.ToString();
                XmlNode trinhdo = nv.SelectSingleNode("trinhdo");
                datanhanvien.Rows[sd].Cells[3].Value = trinhdo.InnerText.ToString();
                XmlNode diachi = nv.SelectSingleNode("diachi");
                datanhanvien.Rows[sd].Cells[4].Value = diachi.InnerText.ToString();
                datanhanvien.Rows.Add();
                sd++;

            }
            cboTrinhDo.Items.Add("Đại học");
            cboTrinhDo.Items.Add("Cao đẳng");
            cboTrinhDo.Items.Add("Trung cấp");
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void datanhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txtma.Text = datanhanvien.Rows[d].Cells[0].Value.ToString();
            txthoten.Text = datanhanvien.Rows[d].Cells[1].Value.ToString();

            if (datanhanvien.Rows[d].Cells[2].Value.ToString() == "Nam")
                radNam.Checked = true;
            else radNu.Checked = true;

            cboTrinhDo.Text = datanhanvien.Rows[d].Cells[3].Value.ToString();
            txtdiachi.Text = datanhanvien.Rows[d].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nhanvien = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txtma.Text;
            nhanvien.Attributes.Append(manv);

            XmlNode hoten = doc.CreateElement("hoten");
            hoten.InnerText = txthoten.Text;
            nhanvien.AppendChild(hoten);

            XmlNode gioitinh = doc.CreateElement("gioitinh");
            if (radNam.Checked) gioitinh.InnerText = "Nam";
            else gioitinh.InnerText = "Nữ";
            nhanvien.AppendChild(gioitinh);

            XmlNode trinhdo = doc.CreateElement("trinhdo");
            trinhdo.InnerText = cboTrinhDo.Text;
            nhanvien.AppendChild(trinhdo);

            XmlNode diachi = doc.CreateElement("diachi");
            diachi.InnerText = txtdiachi.Text;
            nhanvien.AppendChild(diachi);

            goc.AppendChild(nhanvien);
            doc.Save(tentep);
            HienThi();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNode nv_cu = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtma.Text + "']");
            XmlNode nv_moi = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txtma.Text;
            nv_moi.Attributes.Append(manv);

            XmlNode hoten = doc.CreateElement("hoten");
            hoten.InnerText = txthoten.Text;
            nv_moi.AppendChild(hoten);

            XmlNode gioitinh = doc.CreateElement("gioitinh");
            if (radNam.Checked) gioitinh.InnerText = "Nam";
            else gioitinh.InnerText = "Nữ";
            nv_moi.AppendChild(gioitinh);

            XmlNode trinhdo = doc.CreateElement("trinhdo");
            trinhdo.InnerText = cboTrinhDo.Text;
            nv_moi.AppendChild(trinhdo);

            XmlNode diachi = doc.CreateElement("diachi");
            diachi.InnerText = txtdiachi.Text;
            nv_moi.AppendChild(diachi);

            goc.ReplaceChild(nv_moi, nv_cu);
            doc.Save(tentep);
            HienThi();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNode nv_xoa = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtma.Text + "']");
            goc.RemoveChild(nv_xoa);
            doc.Save(tentep);
            HienThi();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            string check = txtma.Text;
            datanhanvien.Rows.Clear();
            XmlNodeList ds = doc.SelectNodes("/ds/nhanvien");
            foreach (XmlNode node in ds)
            {
                XmlNode manv = node.SelectSingleNode("@manv");
                XmlNode hoten = node.SelectSingleNode("hoten");

                XmlNode gioitinh = node.SelectSingleNode("gioitinh"); 

                XmlNode trinhdo = node.SelectSingleNode("trinhdo");

                XmlNode diachi = node.SelectSingleNode("diachi");

                if (manv.InnerText.Contains(check))
                {
                    datanhanvien.Rows.Add(manv.InnerText, hoten.InnerText, gioitinh.InnerText, trinhdo.InnerText, diachi.InnerText);
                }
            }
        }
    }
}
