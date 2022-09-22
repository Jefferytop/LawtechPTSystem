namespace LawtechPTSystemByFirm.EditForm
{
    partial class EditLiaisoner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLiaisoner));
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_SN = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Addr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.isWindowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.label8 = new System.Windows.Forms.Label();
            this.Combo_S = new System.Windows.Forms.ComboBox();
            this.txt_Position = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_Moblephone = new System.Windows.Forms.TextBox();
            this.txt_Ext = new System.Windows.Forms.TextBox();
            this.txt_Liaisoner = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.isWindowsTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.IsWindowsTableAdapter();
            this.chb_Quit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isWindowsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(390, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 17);
            this.label11.TabIndex = 1111;
            this.label11.Text = "Shift+Enter：換下一行";
            // 
            // numericUpDown_SN
            // 
            this.numericUpDown_SN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_SN.Location = new System.Drawing.Point(98, 11);
            this.numericUpDown_SN.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_SN.Name = "numericUpDown_SN";
            this.numericUpDown_SN.Size = new System.Drawing.Size(148, 29);
            this.numericUpDown_SN.TabIndex = 1099;
            this.numericUpDown_SN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(57, 13);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 1097;
            this.label10.Text = "排序";
            // 
            // txt_Addr
            // 
            this.txt_Addr.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Addr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Addr.Location = new System.Drawing.Point(98, 187);
            this.txt_Addr.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Addr.Name = "txt_Addr";
            this.txt_Addr.Size = new System.Drawing.Size(440, 29);
            this.txt_Addr.TabIndex = 1107;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label9.Location = new System.Drawing.Point(25, 190);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 1096;
            this.label9.Text = "聯絡地址";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataSource = this.isWindowsBindingSource;
            this.comboBox1.DisplayMember = "string";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Location = new System.Drawing.Point(358, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 32);
            this.comboBox1.TabIndex = 1105;
            this.comboBox1.ValueMember = "value";
            // 
            // isWindowsBindingSource
            // 
            this.isWindowsBindingSource.DataMember = "IsWindows";
            this.isWindowsBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(285, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 1094;
            this.label8.Text = "窗口種類";
            // 
            // Combo_S
            // 
            this.Combo_S.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Combo_S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_S.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.Combo_S.FormattingEnabled = true;
            this.Combo_S.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_S.Items.AddRange(new object[] {
            "先生",
            "小姐"});
            this.Combo_S.Location = new System.Drawing.Point(358, 45);
            this.Combo_S.Name = "Combo_S";
            this.Combo_S.Size = new System.Drawing.Size(180, 32);
            this.Combo_S.TabIndex = 1103;
            // 
            // txt_Position
            // 
            this.txt_Position.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Position.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Position.Location = new System.Drawing.Point(358, 79);
            this.txt_Position.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Position.Name = "txt_Position";
            this.txt_Position.Size = new System.Drawing.Size(180, 29);
            this.txt_Position.TabIndex = 1104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(304, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 1093;
            this.label7.Text = "職   務";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(304, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 1095;
            this.label6.Text = "性   別";
            // 
            // but_Cancel
            // 
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(279, 322);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 1110;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(179, 322);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 1109;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Remark.Location = new System.Drawing.Point(98, 222);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(440, 85);
            this.txt_Remark.TabIndex = 1108;
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_email.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_email.Location = new System.Drawing.Point(98, 152);
            this.txt_email.Margin = new System.Windows.Forms.Padding(4);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(440, 29);
            this.txt_email.TabIndex = 1106;
            // 
            // txt_Moblephone
            // 
            this.txt_Moblephone.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Moblephone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Moblephone.Location = new System.Drawing.Point(98, 80);
            this.txt_Moblephone.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Moblephone.Name = "txt_Moblephone";
            this.txt_Moblephone.Size = new System.Drawing.Size(148, 29);
            this.txt_Moblephone.TabIndex = 1101;
            // 
            // txt_Ext
            // 
            this.txt_Ext.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Ext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Ext.Location = new System.Drawing.Point(98, 115);
            this.txt_Ext.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Ext.Name = "txt_Ext";
            this.txt_Ext.Size = new System.Drawing.Size(148, 29);
            this.txt_Ext.TabIndex = 1102;
            // 
            // txt_Liaisoner
            // 
            this.txt_Liaisoner.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Liaisoner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Liaisoner.Location = new System.Drawing.Point(98, 45);
            this.txt_Liaisoner.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Liaisoner.Name = "txt_Liaisoner";
            this.txt_Liaisoner.Size = new System.Drawing.Size(148, 29);
            this.txt_Liaisoner.TabIndex = 1100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(44, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 1090;
            this.label5.Text = "分   機";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(25, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 1092;
            this.label4.Text = "行動電話";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(25, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 1098;
            this.label3.Text = "電子信箱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(40, 225);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1091;
            this.label2.Text = "備    註";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(44, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 1089;
            this.label1.Text = "姓   名";
            // 
            // isWindowsTableAdapter
            // 
            this.isWindowsTableAdapter.ClearBeforeFill = true;
            // 
            // chb_Quit
            // 
            this.chb_Quit.AutoSize = true;
            this.chb_Quit.BackColor = System.Drawing.Color.Transparent;
            this.chb_Quit.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chb_Quit.Location = new System.Drawing.Point(358, 11);
            this.chb_Quit.Name = "chb_Quit";
            this.chb_Quit.Size = new System.Drawing.Size(77, 28);
            this.chb_Quit.TabIndex = 1112;
            this.chb_Quit.Text = "離  職";
            this.chb_Quit.UseVisualStyleBackColor = false;
            // 
            // EditLiaisoner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.EditForm_bg;
            this.ClientSize = new System.Drawing.Size(563, 366);
            this.Controls.Add(this.chb_Quit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown_SN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Addr);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Combo_S);
            this.Controls.Add(this.txt_Position);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_Moblephone);
            this.Controls.Add(this.txt_Ext);
            this.Controls.Add(this.txt_Liaisoner);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLiaisoner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯聯絡人";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditLiaisoner_FormClosed);
            this.Load += new System.EventHandler(this.EditLiaisoner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isWindowsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_SN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Addr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Combo_S;
        private System.Windows.Forms.TextBox txt_Position;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_Moblephone;
        private System.Windows.Forms.TextBox txt_Ext;
        private System.Windows.Forms.TextBox txt_Liaisoner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource isWindowsBindingSource;
        private QS_DataSetTableAdapters.IsWindowsTableAdapter isWindowsTableAdapter;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.CheckBox chb_Quit;
    }
}