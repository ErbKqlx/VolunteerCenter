using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VolunteerCenter.Models;

namespace VolunteerCenter
{
    public partial class FormEvents : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormEvents(User currentUser, bool isGuest)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            IsGuest = isGuest;

            lblUsername.Text = IsGuest ? "Гость" : $"{CurrentUser.Surname} {CurrentUser.Name} {CurrentUser.Patronymic}";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdd();
            formAdd.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
