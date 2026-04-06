using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
                var e = db.Events.Where(i => i.Id == _selectedId).FirstOrDefault();

                if (_selectedId != -1)
                {
                    db.Categories.Load();
                    db.Places.Load();
                    db.Users.Load();
                    db.EventStatuses.Load();

                    txtName.Text = e.EventName;
                    dtpDate.Value = e.Date.ToDateTime(new TimeOnly());
                    numRequiredAmount.Value = e.RequiredAmount;

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

                    cmbCategories.SelectedValue = e.IdCategory;
                    cmbPlaces.SelectedValue = e.IdPlace;
                    cmbStatuses.SelectedValue = e.IdEventStatus;
                    cmbUsers.SelectedValue = e.IdUser;
                }
            }
        }
    }
}
