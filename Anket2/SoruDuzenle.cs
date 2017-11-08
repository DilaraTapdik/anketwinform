using DAL;
using DomainEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anket2
{
    public partial class SoruDuzenle : Form
    {
        public Soru GelenSoru { get; set; }
        public SoruDuzenle()
        {
            InitializeComponent();
        }

        private void SoruDuzenle_Load(object sender, EventArgs e)
        {
            textBox1.Text = GelenSoru.SoruCumlesi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnketV2Context db = new AnketV2Context();
            var duzenlenecek = db.Sorular.Find(GelenSoru.SoruID);
            duzenlenecek.SoruCumlesi = textBox1.Text;
            db.Entry(duzenlenecek).State = EntityState.Modified;
            db.SaveChanges();
            Form1 f = (Form1)Application.OpenForms["Form1"];
            f.Form1_Load(sender, e);
            f.SorulariYenile();
            f.CevaplariYenile();
            this.Close();
        }
    }
}
