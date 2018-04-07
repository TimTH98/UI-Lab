using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace GameShark
{
    public partial class Explorer : Form
    {
        public Explorer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var exp = new OpenFileDialog();
            exp.ShowDialog();
            Constructor.Logger.CreateLogRecord("Открытие НИЧЕГО");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var exp = new SaveFileDialog();
            exp.ShowDialog();
            Constructor.Logger.CreateLogRecord("Сохранение НИЧЕГО");
        }
    }
}
