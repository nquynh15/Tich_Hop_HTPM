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

namespace Dom1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        string tentep = @"E:\TichHop\Bai6_ontap_tx2\Dom1\Dom1\Bai1.xml";
        int d;

        private void HienThi()
        {
            doc.Load(tentep);
            dataNV.Rows.Clear();
            int sd = 0;
            dataNV.ColumnCount = 3;
            dataNV.Rows.Add();
            XmlNodeList ds = doc.SelectNodes("/ds/nhanvien");
            foreach (XmlNode node in ds)
            {
                XmlNode ma = node.SelectSingleNode("@manv");
                dataNV.Rows[sd].Cells[0].Value = ma.InnerText.ToString();

                XmlNode hoten = node.SelectSingleNode("hoten");
                dataNV.Rows[sd].Cells[1].Value = hoten.InnerText.ToString();

                XmlNode diachi = node.SelectSingleNode("diachi");
                dataNV.Rows[sd].Cells[2].Value = diachi.InnerText.ToString();

                dataNV.Rows.Add();
                sd++;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dataNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txt_ma.Text = dataNV.Rows[d].Cells[0].Value.ToString();
            txt_hoten.Text = dataNV.Rows[d].Cells[1].Value.ToString();
            txt_dc.Text = dataNV.Rows[d].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nhanvien = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txt_ma.Text;
            nhanvien.Attributes.Append(manv);

            XmlNode hoten = doc.CreateElement("hoten");
            hoten.InnerText = txt_hoten.Text;
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
            XmlNode nv_cu = goc.SelectSingleNode("/ds/nhanvien[@manv= '" + txt_ma.Text + "']");
            
            XmlNode nv_moi = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
            manv.InnerText = txt_ma.Text;
            nv_moi.Attributes.Append(manv);

            XmlNode hoten = doc.CreateElement("hoten");
            hoten.InnerText = txt_hoten.Text;
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
            XmlNode nv_xoa = goc.SelectSingleNode("/ds/nhanvien[@manv= '" + txt_ma.Text + "']");

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
            dataNV.Rows.Clear();
            foreach (XmlNode node in ds)
            {
                XmlNode ma = node.SelectSingleNode("@manv");
                XmlNode ht = node.SelectSingleNode("hoten");
                XmlNode dc = node.SelectSingleNode("diachi");
                if (ma.InnerText.Contains(check)){
                    dataNV.Rows.Add(ma.InnerText, ht.InnerText, dc.InnerText);
                }
            }
            //HienThi();
        }

    }
}
