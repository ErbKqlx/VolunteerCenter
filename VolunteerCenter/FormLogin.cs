using VolunteerCenter.Models;

namespace VolunteerCenter
{
    public partial class FormLogin : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new VolunteerCenterContext())
            {
                if (String.IsNullOrWhiteSpace(txtLogin.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены", 
                        "Ошибка", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                }
                else
                {
                    var user = db.Users
                        .Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Text)
                        .FirstOrDefault();

                    if (user == null)
                    {
                        MessageBox.Show("Неверный логин или пароль",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        CurrentUser = user;
                        IsGuest = false;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        //var formEvents = new FormEvents(CurrentUser, IsGuest);
                        //formEvents.ShowDialog();
                    }
                }
                
            }
                
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;

            //var formEvents = new FormEvents(CurrentUser, IsGuest);
            //formEvents.ShowDialog();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
