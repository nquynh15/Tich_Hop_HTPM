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
using System.Xml.Linq;

namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument doc = new XmlDocument();
        string tentep = @"E:\TichHop\Bai6_ontap_tx2\Dom1\Bai3\Bai3.xml";
        int d;
        private void HienThi()
        {
            doc.Load(tentep);
            dataNV.ColumnCount = 4;
            dataNV.Rows.Clear();
            dataNV.Rows.Add();
            int sd = 0;
            XmlNodeList ds = doc.SelectNodes("/ds/nhanvien");
            foreach (XmlNode node in ds)
            {
                XmlNode ma = node.SelectSingleNode("@manv");
                dataNV.Rows[sd].Cells[0].Value = ma.InnerText.ToString();
                XmlNode ho = node.SelectSingleNode("hoten/ho");
                dataNV.Rows[sd].Cells[1].Value = ho.InnerText.ToString();
                XmlNode ten = node.SelectSingleNode("hoten/ten");
                dataNV.Rows[sd].Cells[2].Value = ten.InnerText.ToString();
                XmlNode diachi = node.SelectSingleNode("diachi");
                dataNV.Rows[sd].Cells[3].Value = diachi.InnerText.ToString();
                dataNV.Rows.Add();
                sd++;
            }
        }

        private void dataNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txt_ma.Text = dataNV.Rows[d].Cells[0].Value.ToString();
            txt_ho.Text = dataNV.Rows[d].Cells[1].Value.ToString();
            txt_ten.Text = dataNV.Rows[d].Cells[2].Value.ToString();
            txt_dc.Text = dataNV.Rows[d].Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlElement nhanvien = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txt_ma.Text;
            nhanvien.Attributes.Append(manv);

            XmlNode hoten = doc.CreateElement("hoten");
            XmlNode ho = doc.CreateElement("ho");
            ho.InnerText = txt_ho.Text;
            hoten.AppendChild(ho);
            XmlNode ten = doc.CreateElement("ten");
            ten.InnerText = txt_ten.Text;
            hoten.AppendChild(ten);
            nhanvien.AppendChild(hoten);

            XmlNode diachi = doc.CreateElement("diachi");
            diachi.InnerText = txt_dc.Text;
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

            XmlNode hoten = doc.CreateElement("hoten");
            XmlNode ho = doc.CreateElement("ho");
            ho.InnerText = txt_ho.Text;
            hoten.AppendChild(ho);
            XmlNode ten = doc.CreateElement("ten");
            ten.InnerText = txt_ten.Text;
            hoten.AppendChild(ten);
            nv_moi.AppendChild(hoten);

            XmlNode diachi = doc.CreateElement("diachi");
            diachi.InnerText = txt_dc.Text;
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
            dataNV.Rows.Clear();
            XmlNodeList ds = goc.SelectNodes("/ds/nhanvien");
            foreach(XmlNode nv in ds)
            {
                XmlNode ma = nv.SelectSingleNode("@manv");
                XmlNode ho = nv.SelectSingleNode("hoten/ho");
                XmlNode ten = nv.SelectSingleNode("hoten/ten");
                XmlNode diachi = nv.SelectSingleNode("diachi");
                if (ma.InnerText.Contains(check))
                {
                    dataNV.Rows.Add(ma.InnerText, ho.InnerText, ten.InnerText, diachi.InnerText);
                }
            }

        }
    }
}
