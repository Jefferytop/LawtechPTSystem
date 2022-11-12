namespace LawtechPTSystem.US
{
    partial class PatentPaymentComplete
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.maskedTextBox_RenewTo = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip_ForDate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Calculation = new System.Windows.Forms.ToolStripMenuItem();
            this.label94 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txt_PayYear = new System.Windows.Forms.NumericUpDown();
            this.Label32 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatentNo = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_ForDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PayYear)).BeginInit();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(257, 167);
            this.butCancel.Margin = new System.Windows.Forms.Padding(1);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 17;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(155, 167);
            this.butOK.Margin = new System.Windows.Forms.Padding(1);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 16;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // maskedTextBox_RenewTo
            // 
            this.maskedTextBox_RenewTo.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_RenewTo.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_RenewTo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.maskedTextBox_RenewTo.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_RenewTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_RenewTo.Location = new System.Drawing.Point(133, 126);
            this.maskedTextBox_RenewTo.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_RenewTo.Mask = "0000-00-00";
            this.maskedTextBox_RenewTo.Name = "maskedTextBox_RenewTo";
            this.maskedTextBox_RenewTo.Size = new System.Drawing.Size(111, 29);
            this.maskedTextBox_RenewTo.TabIndex = 315;
            this.maskedTextBox_RenewTo.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_RenewTo.DoubleClick += new System.EventHandler(this.maskedTextBox_RenewTo_DoubleClick);
            this.maskedTextBox_RenewTo.Leave += new System.EventHandler(this.maskedTextBox_RenewTo_Leave);
            // 
            // contextMenuStrip_ForDate
            // 
            this.contextMenuStrip_ForDate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Calculation});
            this.contextMenuStrip_ForDate.Name = "contextMenuStrip_ForDate";
            this.contextMenuStrip_ForDate.Size = new System.Drawing.Size(123, 26);
            this.contextMenuStrip_ForDate.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ForDate_ItemClicked);
            // 
            // ToolStripMenuItem_Calculation
            // 
            this.ToolStripMenuItem_Calculation.Name = "ToolStripMenuItem_Calculation";
            this.ToolStripMenuItem_Calculation.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_Calculation.Text = "計算日期";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label94.Location = new System.Drawing.Point(27, 131);
            this.label94.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(105, 20);
            this.label94.TabIndex = 314;
            this.label94.Text = "年費有效期限";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label53.Location = new System.Drawing.Point(252, 96);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(25, 20);
            this.label53.TabIndex = 313;
            this.label53.Text = "年";
            // 
            // txt_PayYear
            // 
            this.txt_PayYear.BackColor = System.Drawing.Color.White;
            this.txt_PayYear.DecimalPlaces = 1;
            this.txt_PayYear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_PayYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_PayYear.Location = new System.Drawing.Point(133, 91);
            this.txt_PayYear.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PayYear.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txt_PayYear.Name = "txt_PayYear";
            this.txt_PayYear.ReadOnly = true;
            this.txt_PayYear.Size = new System.Drawing.Size(111, 29);
            this.txt_PayYear.TabIndex = 312;
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label32.Location = new System.Drawing.Point(59, 96);
            this.Label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(73, 20);
            this.Label32.TabIndex = 311;
            this.Label32.Text = "年費繳至";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label9.Location = new System.Drawing.Point(43, 60);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(89, 20);
            this.Label9.TabIndex = 316;
            this.Label9.Text = "申請案名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(43, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 319;
            this.label1.Text = "申請案卷號";
            // 
            // txtPatentNo
            // 
            this.txtPatentNo.BackColor = System.Drawing.Color.LightCyan;
            this.txtPatentNo.ForeColor = System.Drawing.Color.Black;
            this.txtPatentNo.Location = new System.Drawing.Point(133, 22);
            this.txtPatentNo.Name = "txtPatentNo";
            this.txtPatentNo.ReadOnly = true;
            this.txtPatentNo.Size = new System.Drawing.Size(366, 29);
            this.txtPatentNo.TabIndex = 320;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.LightBlue;
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(133, 55);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(366, 29);
            this.txtTitle.TabIndex = 321;
            // 
            // PatentPaymentComplete
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(512, 214);
            this.Controls.Add(this.maskedTextBox_RenewTo);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtPatentNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.label94);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.txt_PayYear);
            this.Controls.Add(this.Label32);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatentPaymentComplete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "年費繳費完成";
            this.Load += new System.EventHandler(this.PatentPaymentComplete_Load);
            this.contextMenuStrip_ForDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PayYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RenewTo;
        internal System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.NumericUpDown txt_PayYear;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatentNo;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ForDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Calculation;
    }
}