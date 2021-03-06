﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW8_3
{

    
    public partial class Form1 : Form
    {
        void SaveAs()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {                   
                    using (Stream stream = dialog.OpenFile())
                    {
                        try
                        {
                            database[(int)nudNumber.Value - 1].text = tbQuestion.Text;
                            database[(int)nudNumber.Value - 1].trueFalse = cbTrue.Checked;
                        }
                        catch (System.NullReferenceException)
                        {
                            MessageBox.Show("База данных пуста.");
                        }
                    }
                }
            }
        }
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;

            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value - 1].text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].trueFalse = cbTrue.Checked;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("База данных не создана.");
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
            catch (System.NullReferenceException )
            {
                MessageBox.Show("База данных пуста.");
                nudNumber.Value = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count+1).ToString(),true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия 1.0\nавтор Сахаров И.С.");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
    }
}
