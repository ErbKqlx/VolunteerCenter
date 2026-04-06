namespace VolunteerCenter
{
    partial class FormAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtName = new TextBox();
            cmbUsers = new ComboBox();
            cmbStatuses = new ComboBox();
            numRequiredAmount = new NumericUpDown();
            dtpDate = new DateTimePicker();
            cmbCategories = new ComboBox();
            cmbPlaces = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRequiredAmount).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(10, 356);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(571, 35);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(462, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 28);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(76, 175, 80);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(354, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 28);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 57);
            label1.Name = "label1";
            label1.Size = new Size(73, 19);
            label1.TabIndex = 1;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 128);
            label2.Name = "label2";
            label2.Size = new Size(41, 19);
            label2.TabIndex = 2;
            label2.Text = "Дата";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 199);
            label3.Name = "label3";
            label3.Size = new Size(79, 19);
            label3.TabIndex = 3;
            label3.Text = "Категория";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 271);
            label4.Name = "label4";
            label4.Size = new Size(52, 19);
            label4.TabIndex = 4;
            label4.Text = "Место";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(345, 58);
            label5.Name = "label5";
            label5.Size = new Size(138, 19);
            label5.TabIndex = 5;
            label5.Text = "Нужно волонтеров";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(345, 129);
            label6.Name = "label6";
            label6.Size = new Size(144, 19);
            label6.TabIndex = 6;
            label6.Text = "Координатор (email)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(345, 201);
            label7.Name = "label7";
            label7.Size = new Size(55, 19);
            label7.TabIndex = 7;
            label7.Text = "Статус";
            // 
            // txtName
            // 
            txtName.Location = new Point(59, 89);
            txtName.Name = "txtName";
            txtName.Size = new Size(191, 26);
            txtName.TabIndex = 8;
            // 
            // cmbUsers
            // 
            cmbUsers.FormattingEnabled = true;
            cmbUsers.Location = new Point(345, 161);
            cmbUsers.Name = "cmbUsers";
            cmbUsers.Size = new Size(191, 27);
            cmbUsers.TabIndex = 13;
            // 
            // cmbStatuses
            // 
            cmbStatuses.FormattingEnabled = true;
            cmbStatuses.Location = new Point(345, 233);
            cmbStatuses.Name = "cmbStatuses";
            cmbStatuses.Size = new Size(191, 27);
            cmbStatuses.TabIndex = 14;
            // 
            // numRequiredAmount
            // 
            numRequiredAmount.Location = new Point(345, 90);
            numRequiredAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRequiredAmount.Name = "numRequiredAmount";
            numRequiredAmount.Size = new Size(191, 26);
            numRequiredAmount.TabIndex = 15;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(59, 160);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(191, 26);
            dtpDate.TabIndex = 16;
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(59, 231);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(191, 27);
            cmbCategories.TabIndex = 17;
            // 
            // cmbPlaces
            // 
            cmbPlaces.FormattingEnabled = true;
            cmbPlaces.Location = new Point(59, 303);
            cmbPlaces.Name = "cmbPlaces";
            cmbPlaces.Size = new Size(191, 27);
            cmbPlaces.TabIndex = 18;
            // 
            // FormAdd
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(591, 401);
            Controls.Add(cmbPlaces);
            Controls.Add(cmbCategories);
            Controls.Add(dtpDate);
            Controls.Add(numRequiredAmount);
            Controls.Add(cmbStatuses);
            Controls.Add(cmbUsers);
            Controls.Add(txtName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormAdd";
            Padding = new Padding(10);
            Text = "Добавление/редактирование мероприятия";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numRequiredAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtName;
        private TextBox textBox2;
        private ComboBox cmbPlaces;
        private ComboBox comboBox2;
        private ComboBox cmbUsers;
        private ComboBox cmbStatuses;
        private NumericUpDown numRequiredAmount;
        private DateTimePicker dtpDate;
        private ComboBox cmbCategories;
    }
}