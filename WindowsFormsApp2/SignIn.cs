using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShark
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            Constructor.Logger.CreateLogRecord("Инициализация формы регистрации");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckBox check = new CheckBox();
            MainBuyer buyer = new MainBuyer();
            MainSeller seller = new MainSeller();

            //if (check.Checked)
            //    seller.Show();
            //else buyer.Show();
            seller.Show();
            this.Hide();
            Constructor.Logger.CreateLogRecord("Окончание регистрации");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            //CheckBox check = new CheckBox();
            //MainBuyer buyer = new MainBuyer();
            //MainSeller seller = new MainSeller();     
            Constructor.Logger.CreateLogRecord("Смена типа аккаунта");
        }
    }
}
