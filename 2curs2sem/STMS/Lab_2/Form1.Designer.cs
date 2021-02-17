namespace _2k2SemLabs_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboModel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateRels = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateServis = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.fioBox = new System.Windows.Forms.TextBox();
            this.postBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.typePanel = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SaveBox = new System.Windows.Forms.ListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.LoadingBox = new System.Windows.Forms.ListBox();
            this.delSavButton = new System.Windows.Forms.Button();
            this.delLoadButton = new System.Windows.Forms.Button();
            this.addCrewButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.addAirplButton = new System.Windows.Forms.Button();
            this.airplansListBox = new System.Windows.Forms.ListBox();
            this.ID_Airplane = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.countBox = new System.Windows.Forms.MaskedTextBox();
            this.carryingBox = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.MaskedTextBox();
            this.exspiTrackBar = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addCrewmate = new System.Windows.Forms.Button();
            this.typePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exspiTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ввод данных о самолете";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID самолета";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(14, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тип самолета";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(14, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Модель";
            // 
            // comboModel
            // 
            this.comboModel.FormattingEnabled = true;
            this.comboModel.Items.AddRange(new object[] {
            "Boeing 737",
            "Boeing 747",
            "BAC 1-11",
            "Britten-Norman Defender",
            "RWD-11",
            "SAAB AB",
            "Seversky 2PA"});
            this.comboModel.Location = new System.Drawing.Point(18, 270);
            this.comboModel.Name = "comboModel";
            this.comboModel.Size = new System.Drawing.Size(200, 24);
            this.comboModel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(14, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количество пассажирских мест";
            // 
            // dateRels
            // 
            this.dateRels.Location = new System.Drawing.Point(18, 370);
            this.dateRels.Name = "dateRels";
            this.dateRels.Size = new System.Drawing.Size(200, 22);
            this.dateRels.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(14, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Год выпуска";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(14, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(317, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Дата последнего тех. обслуживания";
            // 
            // dateServis
            // 
            this.dateServis.Location = new System.Drawing.Point(18, 418);
            this.dateServis.Name = "dateServis";
            this.dateServis.Size = new System.Drawing.Size(200, 22);
            this.dateServis.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(16, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Грузоподъемность";
            // 
            // fioBox
            // 
            this.fioBox.Location = new System.Drawing.Point(366, 113);
            this.fioBox.MaxLength = 100;
            this.fioBox.Name = "fioBox";
            this.fioBox.Size = new System.Drawing.Size(279, 22);
            this.fioBox.TabIndex = 21;
            // 
            // postBox
            // 
            this.postBox.FormattingEnabled = true;
            this.postBox.Items.AddRange(new object[] {
            "Стюардесса",
            "Пилот",
            "Ремонтик",
            "Официант",
            "Медсестра"});
            this.postBox.Location = new System.Drawing.Point(366, 166);
            this.postBox.Name = "postBox";
            this.postBox.Size = new System.Drawing.Size(279, 24);
            this.postBox.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label12.Location = new System.Drawing.Point(358, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(191, 31);
            this.label12.TabIndex = 18;
            this.label12.Text = "Член экипажа";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(362, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "ФИО";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label16.Location = new System.Drawing.Point(362, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 20);
            this.label16.TabIndex = 34;
            this.label16.Text = "Должность";
            // 
            // typePanel
            // 
            this.typePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.typePanel.Controls.Add(this.radioButton3);
            this.typePanel.Controls.Add(this.radioButton2);
            this.typePanel.Controls.Add(this.radioButton1);
            this.typePanel.Location = new System.Drawing.Point(18, 163);
            this.typePanel.Name = "typePanel";
            this.typePanel.Size = new System.Drawing.Size(200, 81);
            this.typePanel.TabIndex = 35;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(4, 58);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Военный";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(4, 31);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Грузовой";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(124, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Поссажирский";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(362, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Стаж: 0 г.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(362, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Возраст";
            // 
            // SaveBox
            // 
            this.SaveBox.FormattingEnabled = true;
            this.SaveBox.ItemHeight = 16;
            this.SaveBox.Location = new System.Drawing.Point(693, 42);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(459, 148);
            this.SaveBox.TabIndex = 42;
            this.SaveBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(693, 198);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(118, 48);
            this.saveButton.TabIndex = 43;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(693, 430);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(118, 48);
            this.loadButton.TabIndex = 44;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // LoadingBox
            // 
            this.LoadingBox.FormattingEnabled = true;
            this.LoadingBox.ItemHeight = 16;
            this.LoadingBox.Location = new System.Drawing.Point(693, 256);
            this.LoadingBox.Name = "LoadingBox";
            this.LoadingBox.Size = new System.Drawing.Size(459, 164);
            this.LoadingBox.TabIndex = 45;
            this.LoadingBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // delSavButton
            // 
            this.delSavButton.Location = new System.Drawing.Point(1063, 198);
            this.delSavButton.Name = "delSavButton";
            this.delSavButton.Size = new System.Drawing.Size(89, 48);
            this.delSavButton.TabIndex = 46;
            this.delSavButton.Text = "Очистить";
            this.delSavButton.UseVisualStyleBackColor = true;
            // 
            // delLoadButton
            // 
            this.delLoadButton.Location = new System.Drawing.Point(1063, 430);
            this.delLoadButton.Name = "delLoadButton";
            this.delLoadButton.Size = new System.Drawing.Size(89, 48);
            this.delLoadButton.TabIndex = 47;
            this.delLoadButton.Text = "Очистить";
            this.delLoadButton.UseVisualStyleBackColor = true;
            // 
            // addCrewButton
            // 
            this.addCrewButton.Location = new System.Drawing.Point(366, 499);
            this.addCrewButton.Name = "addCrewButton";
            this.addCrewButton.Size = new System.Drawing.Size(279, 46);
            this.addCrewButton.TabIndex = 48;
            this.addCrewButton.Text = "Ввод данных";
            this.addCrewButton.UseVisualStyleBackColor = true;
            this.addCrewButton.Click += new System.EventHandler(this.AddDate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(362, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 52;
            this.label10.Text = "Самолет";
            // 
            // addAirplButton
            // 
            this.addAirplButton.Location = new System.Drawing.Point(18, 499);
            this.addAirplButton.Name = "addAirplButton";
            this.addAirplButton.Size = new System.Drawing.Size(200, 48);
            this.addAirplButton.TabIndex = 53;
            this.addAirplButton.Text = "Добавить самолет";
            this.addAirplButton.UseVisualStyleBackColor = true;
            this.addAirplButton.Click += new System.EventHandler(this.AddAirplButton_Click);
            // 
            // airplansListBox
            // 
            this.airplansListBox.FormattingEnabled = true;
            this.airplansListBox.ItemHeight = 16;
            this.airplansListBox.Location = new System.Drawing.Point(366, 320);
            this.airplansListBox.Name = "airplansListBox";
            this.airplansListBox.Size = new System.Drawing.Size(279, 100);
            this.airplansListBox.TabIndex = 54;
            this.airplansListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // ID_Airplane
            // 
            this.ID_Airplane.Location = new System.Drawing.Point(18, 113);
            this.ID_Airplane.Mask = "0000-999";
            this.ID_Airplane.Name = "ID_Airplane";
            this.ID_Airplane.Size = new System.Drawing.Size(200, 22);
            this.ID_Airplane.TabIndex = 55;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(18, 321);
            this.countBox.Mask = "000";
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(200, 22);
            this.countBox.TabIndex = 56;
            // 
            // carryingBox
            // 
            this.carryingBox.Location = new System.Drawing.Point(18, 466);
            this.carryingBox.Mask = "0000";
            this.carryingBox.Name = "carryingBox";
            this.carryingBox.Size = new System.Drawing.Size(200, 22);
            this.carryingBox.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(189, 469);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 17);
            this.label14.TabIndex = 58;
            this.label14.Text = "кг";
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(366, 222);
            this.ageBox.Mask = "00";
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(279, 22);
            this.ageBox.TabIndex = 59;
            // 
            // exspiTrackBar
            // 
            this.exspiTrackBar.Location = new System.Drawing.Point(364, 266);
            this.exspiTrackBar.Maximum = 40;
            this.exspiTrackBar.Name = "exspiTrackBar";
            this.exspiTrackBar.Size = new System.Drawing.Size(281, 56);
            this.exspiTrackBar.TabIndex = 36;
            this.exspiTrackBar.TickFrequency = 5;
            this.exspiTrackBar.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(817, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 48);
            this.button1.TabIndex = 60;
            this.button1.Text = "Экипаж";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(817, 430);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 48);
            this.button2.TabIndex = 61;
            this.button2.Text = "Экипаж";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // addCrewmate
            // 
            this.addCrewmate.Location = new System.Drawing.Point(366, 432);
            this.addCrewmate.Name = "addCrewmate";
            this.addCrewmate.Size = new System.Drawing.Size(279, 46);
            this.addCrewmate.TabIndex = 62;
            this.addCrewmate.Text = "Добавить сотрудника";
            this.addCrewmate.UseVisualStyleBackColor = true;
            this.addCrewmate.Click += new System.EventHandler(this.AddCrewmate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 559);
            this.Controls.Add(this.addCrewmate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ageBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.carryingBox);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.ID_Airplane);
            this.Controls.Add(this.airplansListBox);
            this.Controls.Add(this.addAirplButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.addCrewButton);
            this.Controls.Add(this.delLoadButton);
            this.Controls.Add(this.delSavButton);
            this.Controls.Add(this.LoadingBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.exspiTrackBar);
            this.Controls.Add(this.typePanel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.fioBox);
            this.Controls.Add(this.postBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateServis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateRels);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Аэропорт";
            this.typePanel.ResumeLayout(false);
            this.typePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exspiTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateRels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateServis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fioBox;
        private System.Windows.Forms.ComboBox postBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel typePanel;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox SaveBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.ListBox LoadingBox;
        private System.Windows.Forms.Button delSavButton;
        private System.Windows.Forms.Button delLoadButton;
        private System.Windows.Forms.Button addCrewButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button addAirplButton;
        private System.Windows.Forms.ListBox airplansListBox;
        private System.Windows.Forms.MaskedTextBox ID_Airplane;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox countBox;
        private System.Windows.Forms.MaskedTextBox carryingBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox ageBox;
        private System.Windows.Forms.TrackBar exspiTrackBar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addCrewmate;
    }
}

