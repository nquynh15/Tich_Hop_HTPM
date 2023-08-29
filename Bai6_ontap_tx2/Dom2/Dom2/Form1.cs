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

namespace Dom2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        string tentep = @"E:\TichHop\Bai6_ontap_tx2\Dom2\Dom2\Bai1.xml";
        int d;

        private void HienThi()
        {
            doc.Load(tentep);
            datanhanvien.ColumnCount = 3;
            datanhanvien.Rows.Clear();
            datanhanvien.Rows.Add();
            int sd = 0;

            XmlNodeList ds = doc.SelectNodes("/ds/nhanvien");
            foreach (XmlNode node in ds)
            {
                XmlNode ma = node.SelectSingleNode("@manv");
                datanhanvien.Rows[sd].Cells[0].Value = ma.InnerText;
                XmlNode hoten = node.SelectSingleNode("hoten");
                datanhanvien.Rows[sd].Cells[1].Value = hoten.InnerText;
                XmlNode diachi = node.SelectSingleNode("diachi");
                datanhanvien.Rows[sd].Cells[2].Value = diachi.InnerText;
                datanhanvien.Rows.Add();
                sd++;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void datanhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txt_ma.Text = datanhanvien.Rows[d].Cells[0].Value.ToString();
            txthoten.Text = datanhanvien.Rows[d].Cells[1].Value.ToString();
            txt_diachi.Text = datanhanvien.Rows[d].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlElement nhanvien = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txt_ma.Text;
            nhanvien.Attributes.Append(manv);

            XmlElement hoten = doc.CreateElement("hoten");
            hoten.InnerText = txthoten.Text;
            nhanvien.AppendChild(hoten);

            XmlElement diachi = doc.CreateElement("diachi");
            diachi.InnerText = txt_diachi.Text;
            nhanvien.AppendChild(diachi);

            goc.AppendChild(nhanvien);
            doc.Save(tentep);
            HienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNode nv_cu = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txt_ma.Text + "']");

            XmlElement nv_moi = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txt_ma.Text;
            nv_moi.Attributes.Append(manv);

            XmlElement hoten = doc.CreateElement("hoten");
            hoten.InnerText = txthoten.Text;
            nv_moi.AppendChild(hoten);

            XmlElement diachi = doc.CreateElement("diachi");
            diachi.InnerText = txt_diachi.Text;
            nv_moi.AppendChild(diachi);

            goc.ReplaceChild(nv_moi, nv_cu);
            doc.Save(tentep);
            HienThi();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNode nv_xoa = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txt_ma.Text + "']");

            goc.RemoveChild(nv_xoa);
            doc.Save(tentep);
            HienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            string check = txt_ma.Text;

            XmlNodeList ds = doc.SelectNodes("/ds/nhanvien");
            datanhanvien.Rows.Clear();

            foreach (XmlNode node in ds)
            {
                XmlNode ma = node.SelectSingleNode("@manv");
                XmlNode hoten = node.SelectSingleNode("hoten");
                XmlNode diachi = node.SelectSingleNode("diachi");
                if (ma.InnerText.Contains(check))
                {
                    datanhanvien.Rows.Add(ma.InnerText, hoten.InnerText, diachi.InnerText);
                }
            }

        }
    }
}
