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
    public partial class Autorize : Form
    {
        public Autorize()
        {
            InitializeComponent();
            Constructor.Logger.CreateLogRecord("Инициализация формы авторизации");
        }

        void LoginButton_Click(object sender, EventArgs e)
        {
            //if (usernameField.Text == "admin" && passwordField.Text == "12345") // Успешный логин
            //{
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else MessageBox.Show("Кривой логин или пароль");
            Constructor.Logger.CreateLogRecord("Подтверждение входа");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var signIn = new SignIn();
            signIn.ShowDialog();
            Constructor.Logger.CreateLogRecord("Открытие окна регистрации");

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Constructor.MB.WindowState = FormWindowState.Normal;
            Constructor.MB.ShowInTaskbar = true;
            Constructor.Logger.CreateLogRecord("Вход");
            Close();
        }

        
    }
}
