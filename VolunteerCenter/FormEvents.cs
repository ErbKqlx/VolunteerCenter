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
    public partial class FormEvents : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormEvents(User currentUser, bool isGuest)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            IsGuest = isGuest;

            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            dgvEvents.Columns.AddRange([
                colId, colInfo
            ]);

            lblUsername.Text = IsGuest ? "Гость" : $"{CurrentUser.Surname} {CurrentUser.Name} {CurrentUser.Patronymic}";

            foreach(Button button in flowLayoutPanelButtons.Controls)
            {
                button.Visible = !IsGuest;
            }

            LoadEvents();
        }

        private void LoadEvents()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var events = db.Events
                        .Include(i => i.IdCategoryNavigation)
                        .Include(i => i.IdPlaceNavigation)
                        .Include(i => i.IdUserNavigation)
                        .Include(i => i.IdEventStatusNavigation)
                        .Include(i => i.VolunteerRegistrations).ThenInclude(i => i.IdRegistrationStatusNavigation)
                        .ToList();

                    dgvEvents.SuspendLayout();
                    dgvEvents.Rows.Clear();

                    foreach (var e in events)
                    {
                        int rowIndex = dgvEvents.Rows.Add();
                        var row = dgvEvents.Rows[rowIndex];

                        row.Cells["colId"].Value = e.Id;
                        row.Cells["colInfo"].Value = FormatEventInfo(e);

                        ApplyRowStyle(row, e);
                    }

                    dgvEvents.ResumeLayout();
                    dgvEvents.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            
        }

        private void ApplyRowStyle(DataGridViewRow row, Event e)
        {
            var availableAmount = e.RequiredAmount - e.VolunteerRegistrations.Where(i => i.IdRegistrationStatusNavigation.RegistrationStatusName == "Подтверждено").Count();

            if (e.IdEventStatusNavigation.EventStatusName == "Запланировано" 
                && availableAmount < 3)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4");
            }

            if (e.IdEventStatusNavigation.EventStatusName == "Завершено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            }

            if (e.IdEventStatusNavigation.EventStatusName == "Отменено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1");
            }
        }

        private string FormatEventInfo(Event e)
        {
            //using (var db = new VolunteerCenterContext)
            //{
            //    var d = db.VolunteerRegistrations.Include(i => i.IdRegistrationStatusNavigation);
            //    var d = db.RegistrationStatuses.Include(i => i.)


            //}
            var confirmedRegistrations = e.VolunteerRegistrations
                .Count(i => i.IdRegistrationStatusNavigation.RegistrationStatusName == "Подтверждено");
            var percent = (float)confirmedRegistrations / e.RequiredAmount * 100;

            return $"Название: {e.EventName}" + Environment.NewLine +
                $"Категория: {e.IdCategoryNavigation.CategoryName}" + Environment.NewLine +
                $"Дата: {e.Date}" + Environment.NewLine +
                $"Место: {e.IdPlaceNavigation.PlaceName}" + Environment.NewLine +
                $"Нужно волонтеров: {e.RequiredAmount}" + Environment.NewLine +
                $"Координатор (email): {e.IdUserNavigation.Email}" + Environment.NewLine +
                $"Статус мероприятия: {e.IdEventStatusNavigation.EventStatusName}" + Environment.NewLine +
                $"Количество свободных мест: {e.RequiredAmount - confirmedRegistrations}" + Environment.NewLine +
                $"Процент набора волонтеров: {Math.Round(percent, 2)}%";
            
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdd();
            formAdd.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdd();
            formAdd.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы действительно хотите удалить мероприятие?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new VolunteerCenterContext())
                    {
                        var ev = db.Events.Find((int)dgvEvents.CurrentRow.Cells[0].Value);


                        db.Events.Remove(ev);
                        db.SaveChanges();

                        MessageBox.Show($"Мероприятие удалено",
                            "Удаление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }


                LoadEvents();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
