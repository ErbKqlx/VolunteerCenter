using Microsoft.EntityFrameworkCore;
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
    public partial class FormAdd : Form
    {
        private int _selectedId;
        public FormAdd(int selectedId = -1)
        {
            InitializeComponent();

            _selectedId = selectedId;

            using (var db = new VolunteerCenterContext())
            {
                db.Categories.Load();
                db.Places.Load();
                db.Users.Load();
                db.EventStatuses.Load();

                cmbCategories.DataSource = db.Categories.Local.ToBindingList();
                cmbCategories.DisplayMember = "CategoryName";
                cmbCategories.ValueMember = "Id";

                cmbPlaces.DataSource = db.Places.Local.ToBindingList();
                cmbPlaces.DisplayMember = "PlaceName";
                cmbPlaces.ValueMember = "Id";

                cmbStatuses.DataSource = db.EventStatuses.Local.ToBindingList();
                cmbStatuses.DisplayMember = "EventStatusName";
                cmbStatuses.ValueMember = "Id";

                cmbUsers.DataSource = db.Users.Local.ToBindingList();
                cmbUsers.DisplayMember = "Email";
                cmbUsers.ValueMember = "Id";

                if (_selectedId != -1)
                {
                    var e = db.Events.Where(i => i.Id == _selectedId).FirstOrDefault();

                    txtName.Text = e.EventName;
                    dtpDate.Value = e.Date.ToDateTime(new TimeOnly());
                    numRequiredAmount.Value = e.RequiredAmount;

                    cmbCategories.SelectedValue = e.IdCategory;
                    cmbPlaces.SelectedValue = e.IdPlace;
                    cmbStatuses.SelectedValue = e.IdEventStatus;
                    cmbUsers.SelectedValue = e.IdUser;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены", 
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    Event ev;
                    if (_selectedId != -1)
                    {
                        ev = db.Events.Find(_selectedId);
                    }
                    else
                    {
                        ev = new Event();
                    }

                    ev.EventName = txtName.Text;
                    ev.Date = DateOnly.FromDateTime(dtpDate.Value);
                    ev.RequiredAmount = (int)numRequiredAmount.Value;
                    ev.IdCategory = (int)cmbCategories.SelectedValue;
                    ev.IdUser = (int)cmbUsers.SelectedValue;
                    ev.IdPlace = (int)cmbPlaces.SelectedValue;
                    ev.IdEventStatus = (int)cmbStatuses.SelectedValue;

                    if (_selectedId != -1)
                    {
                        db.Events.Update(ev);
                    }
                    else
                    {
                        db.Events.Add(ev);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
