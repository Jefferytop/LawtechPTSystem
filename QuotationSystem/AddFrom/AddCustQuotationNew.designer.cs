namespace LawtechPTSystem.AddFrom
{
    partial class AddCustQuotationNew
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustQuotationNew));
            this.label1 = new System.Windows.Forms.Label();
            this.txtGovFeeNT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbProcedureName = new System.Windows.Forms.ComboBox();
            this.cbbPhase = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAttorneyFeeNT = new System.Windows.Forms.TextBox();
            this.txtMeFee = new System.Windows.Forms.TextBox();
            this.txtQuotaTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSignDocument = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExamtime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProcedureNameCHS = new System.Windows.Forms.TextBox();
            this.txtProcedureNameEN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemarkCHS = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemarkEN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label1.Location = new System.Drawing.Point(76, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序";
            // 
            // txtGovFeeNT
            // 
            this.txtGovFeeNT.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGovFeeNT.Location = new System.Drawing.Point(115, 210);
            this.txtGovFeeNT.MaxLength = 12;
            this.txtGovFeeNT.Name = "txtGovFeeNT";
            this.txtGovFeeNT.Size = new System.Drawing.Size(86, 25);
            this.txtGovFeeNT.TabIndex = 7;
            this.txtGovFeeNT.Text = "0";
            this.txtGovFeeNT.Validated += new System.EventHandler(this.CalculateMoney);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(48, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "所屬階段";
            // 
            // cbbProcedureName
            // 
            this.cbbProcedureName.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbbProcedureName.FormattingEnabled = true;
            this.cbbProcedureName.Location = new System.Drawing.Point(115, 40);
            this.cbbProcedureName.Name = "cbbProcedureName";
            this.cbbProcedureName.Size = new System.Drawing.Size(272, 25);
            this.cbbProcedureName.TabIndex = 1;
            // 
            // cbbPhase
            // 
            this.cbbPhase.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbbPhase.FormattingEnabled = true;
            this.cbbPhase.Location = new System.Drawing.Point(115, 125);
            this.cbbPhase.Name = "cbbPhase";
            this.cbbPhase.Size = new System.Drawing.Size(272, 25);
            this.cbbPhase.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.Location = new System.Drawing.Point(216, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "複代費用NT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label4.Location = new System.Drawing.Point(29, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "官方規費NT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label5.Location = new System.Drawing.Point(34, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "本所服務費";
            // 
            // txtAttorneyFeeNT
            // 
            this.txtAttorneyFeeNT.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAttorneyFeeNT.Location = new System.Drawing.Point(301, 211);
            this.txtAttorneyFeeNT.MaxLength = 12;
            this.txtAttorneyFeeNT.Name = "txtAttorneyFeeNT";
            this.txtAttorneyFeeNT.Size = new System.Drawing.Size(86, 25);
            this.txtAttorneyFeeNT.TabIndex = 8;
            this.txtAttorneyFeeNT.Text = "0";
            this.txtAttorneyFeeNT.Validated += new System.EventHandler(this.CalculateMoney);
            // 
            // txtMeFee
            // 
            this.txtMeFee.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMeFee.Location = new System.Drawing.Point(115, 238);
            this.txtMeFee.MaxLength = 12;
            this.txtMeFee.Name = "txtMeFee";
            this.txtMeFee.Size = new System.Drawing.Size(86, 25);
            this.txtMeFee.TabIndex = 9;
            this.txtMeFee.Text = "0";
            this.txtMeFee.Validated += new System.EventHandler(this.CalculateMoney);
            // 
            // txtQuotaTotal
            // 
            this.txtQuotaTotal.BackColor = System.Drawing.Color.White;
            this.txtQuotaTotal.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQuotaTotal.ForeColor = System.Drawing.Color.Blue;
            this.txtQuotaTotal.Location = new System.Drawing.Point(301, 239);
            this.txtQuotaTotal.MaxLength = 12;
            this.txtQuotaTotal.Name = "txtQuotaTotal";
            this.txtQuotaTotal.ReadOnly = true;
            this.txtQuotaTotal.Size = new System.Drawing.Size(86, 25);
            this.txtQuotaTotal.TabIndex = 10;
            this.txtQuotaTotal.TabStop = false;
            this.txtQuotaTotal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label6.Location = new System.Drawing.Point(235, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "報價總計";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnOK.Location = new System.Drawing.Point(112, 469);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnCancel.Location = new System.Drawing.Point(218, 469);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRemark.Location = new System.Drawing.Point(115, 267);
            this.txtRemark.MaxLength = 4000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(272, 62);
            this.txtRemark.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label7.Location = new System.Drawing.Point(76, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "備註";
            // 
            // txtSignDocument
            // 
            this.txtSignDocument.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSignDocument.Location = new System.Drawing.Point(115, 182);
            this.txtSignDocument.MaxLength = 120;
            this.txtSignDocument.Name = "txtSignDocument";
            this.txtSignDocument.Size = new System.Drawing.Size(272, 25);
            this.txtSignDocument.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label8.Location = new System.Drawing.Point(20, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "應備簽署文件";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label9.Location = new System.Drawing.Point(48, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "審查時間";
            // 
            // txtExamtime
            // 
            this.txtExamtime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtExamtime.Location = new System.Drawing.Point(115, 154);
            this.txtExamtime.MaxLength = 10;
            this.txtExamtime.Name = "txtExamtime";
            this.txtExamtime.Size = new System.Drawing.Size(272, 25);
            this.txtExamtime.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label10.Location = new System.Drawing.Point(76, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "排序";
            // 
            // txtSN
            // 
            this.txtSN.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSN.Location = new System.Drawing.Point(115, 12);
            this.txtSN.MaxLength = 10;
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(272, 25);
            this.txtSN.TabIndex = 0;
            this.txtSN.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label11.Location = new System.Drawing.Point(54, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 18);
            this.label11.TabIndex = 32;
            this.label11.Text = "程序(簡)";
            // 
            // txtProcedureNameCHS
            // 
            this.txtProcedureNameCHS.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtProcedureNameCHS.Location = new System.Drawing.Point(115, 69);
            this.txtProcedureNameCHS.MaxLength = 120;
            this.txtProcedureNameCHS.Name = "txtProcedureNameCHS";
            this.txtProcedureNameCHS.Size = new System.Drawing.Size(272, 25);
            this.txtProcedureNameCHS.TabIndex = 2;
            // 
            // txtProcedureNameEN
            // 
            this.txtProcedureNameEN.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtProcedureNameEN.Location = new System.Drawing.Point(115, 97);
            this.txtProcedureNameEN.MaxLength = 120;
            this.txtProcedureNameEN.Name = "txtProcedureNameEN";
            this.txtProcedureNameEN.Size = new System.Drawing.Size(272, 25);
            this.txtProcedureNameEN.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label12.Location = new System.Drawing.Point(54, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 18);
            this.label12.TabIndex = 34;
            this.label12.Text = "程序(英)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label13.Location = new System.Drawing.Point(54, 342);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 18);
            this.label13.TabIndex = 37;
            this.label13.Text = "備註(簡)";
            // 
            // txtRemarkCHS
            // 
            this.txtRemarkCHS.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRemarkCHS.Location = new System.Drawing.Point(115, 335);
            this.txtRemarkCHS.MaxLength = 4000;
            this.txtRemarkCHS.Multiline = true;
            this.txtRemarkCHS.Name = "txtRemarkCHS";
            this.txtRemarkCHS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemarkCHS.Size = new System.Drawing.Size(272, 62);
            this.txtRemarkCHS.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label14.Location = new System.Drawing.Point(54, 413);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 18);
            this.label14.TabIndex = 39;
            this.label14.Text = "備註(英)";
            // 
            // txtRemarkEN
            // 
            this.txtRemarkEN.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRemarkEN.Location = new System.Drawing.Point(115, 403);
            this.txtRemarkEN.MaxLength = 4000;
            this.txtRemarkEN.Multiline = true;
            this.txtRemarkEN.Name = "txtRemarkEN";
            this.txtRemarkEN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemarkEN.Size = new System.Drawing.Size(272, 62);
            this.txtRemarkEN.TabIndex = 13;
            // 
            // AddCustQuotationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(408, 514);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRemarkEN);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRemarkCHS);
            this.Controls.Add(this.txtProcedureNameEN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtProcedureNameCHS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSN);
            this.Controls.Add(this.txtSignDocument);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtExamtime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtQuotaTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMeFee);
            this.Controls.Add(this.txtAttorneyFeeNT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbPhase);
            this.Controls.Add(this.cbbProcedureName);
            this.Controls.Add(this.txtGovFeeNT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCustQuotationNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增報價";
            this.Load += new System.EventHandler(this.AddCustQuotationNew_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddCustQuotationNew_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGovFeeNT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbProcedureName;
        private System.Windows.Forms.ComboBox cbbPhase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAttorneyFeeNT;
        private System.Windows.Forms.TextBox txtMeFee;
        private System.Windows.Forms.TextBox txtQuotaTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSignDocument;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtExamtime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProcedureNameCHS;
        private System.Windows.Forms.TextBox txtProcedureNameEN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemarkCHS;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemarkEN;
    }
}