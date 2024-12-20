using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siparisTakip
{
   public partial class FrmMusteri : Form
{
    private int musteriID;

    public FrmMusteri(int kullaniciID)
    {
        InitializeComponent();
        this.musteriID = kullaniciID; // Kullanıcı ID'sini al
    }

    private void btnMenuGoruntule_Click(object sender, EventArgs e)
    {
        FrmMenuGoruntule frmMenuGoruntule = new FrmMenuGoruntule(musteriID);
        frmMenuGoruntule.ShowDialog();
    }

    private void btnSiparisGoruntule_Click(object sender, EventArgs e)
    {
        FrmMusteriSiparisleri frmMusteriSiparisleri = new FrmMusteriSiparisleri(musteriID);
        frmMusteriSiparisleri.ShowDialog();
    }
}
 
    }
