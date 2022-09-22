namespace LawtechPTSystem.US
{
    partial class MailReceive
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox_kind = new System.Windows.Forms.ComboBox();
            this.dataGridView_Receive = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_email = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_reciever = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_CC = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Bcc = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Window = new System.Windows.Forms.ComboBox();
            this.isWindowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.isWindowsTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.IsWindowsTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_Receiver = new System.Windows.Forms.TextBox();
            this.txt_cc = new System.Windows.Forms.TextBox();
            this.txt_Bcc = new System.Windows.Forms.TextBox();
            this.but_Bcc = new System.Windows.Forms.Button();
            this.Liaisoner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Receive)).BeginInit();
            this.contextMenuStrip_email.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isWindowsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_kind
            // 
            this.comboBox_kind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_kind.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_kind.FormattingEnabled = true;
            this.comboBox_kind.Items.AddRange(new object[] {
            "主要委託人",
            "承辦事務所",
            "本所人員"});
            this.comboBox_kind.Location = new System.Drawing.Point(14, 32);
            this.comboBox_kind.Name = "comboBox_kind";
            this.comboBox_kind.Size = new System.Drawing.Size(158, 28);
            this.comboBox_kind.TabIndex = 0;
            this.comboBox_kind.SelectedIndexChanged += new System.EventHandler(this.comboBox_kind_SelectedIndexChanged);
            // 
            // dataGridView_Receive
            // 
            this.dataGridView_Receive.AllowUserToAddRows = false;
            this.dataGridView_Receive.AllowUserToDeleteRows = false;
            this.dataGridView_Receive.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView_Receive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Receive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Receive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Receive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Receive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Liaisoner,
            this.email,
            this.Position,
            this.ContractType});
            this.dataGridView_Receive.ContextMenuStrip = this.contextMenuStrip_email;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Receive.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Receive.Location = new System.Drawing.Point(12, 66);
            this.dataGridView_Receive.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView_Receive.MultiSelect = false;
            this.dataGridView_Receive.Name = "dataGridView_Receive";
            this.dataGridView_Receive.ReadOnly = true;
            this.dataGridView_Receive.RowHeadersWidth = 30;
            this.dataGridView_Receive.RowTemplate.Height = 24;
            this.dataGridView_Receive.Size = new System.Drawing.Size(537, 315);
            this.dataGridView_Receive.TabIndex = 2;
            this.dataGridView_Receive.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Receive_CellDoubleClick);
            // 
            // contextMenuStrip_email
            // 
            this.contextMenuStrip_email.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_reciever,
            this.ToolStripMenuItem_CC,
            this.ToolStripMenuItem_Bcc});
            this.contextMenuStrip_email.Name = "contextMenuStrip_email";
            this.contextMenuStrip_email.Size = new System.Drawing.Size(147, 70);
            this.contextMenuStrip_email.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_email_ItemClicked);
            // 
            // ToolStripMenuItem_reciever
            // 
            this.ToolStripMenuItem_reciever.Name = "ToolStripMenuItem_reciever";
            this.ToolStripMenuItem_reciever.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_reciever.Text = "加到收件者";
            // 
            // ToolStripMenuItem_CC
            // 
            this.ToolStripMenuItem_CC.Name = "ToolStripMenuItem_CC";
            this.ToolStripMenuItem_CC.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_CC.Text = "加到副本";
            // 
            // ToolStripMenuItem_Bcc
            // 
            this.ToolStripMenuItem_Bcc.Name = "ToolStripMenuItem_Bcc";
            this.ToolStripMenuItem_Bcc.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_Bcc.Text = "加到密件副本";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "對   象";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(188, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "窗   口";
            // 
            // comboBox_Window
            // 
            this.comboBox_Window.DataSource = this.isWindowsBindingSource;
            this.comboBox_Window.DisplayMember = "string";
            this.comboBox_Window.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Window.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Window.FormattingEnabled = true;
            this.comboBox_Window.Location = new System.Drawing.Point(192, 32);
            this.comboBox_Window.Name = "comboBox_Window";
            this.comboBox_Window.Size = new System.Drawing.Size(172, 28);
            this.comboBox_Window.TabIndex = 1;
            this.comboBox_Window.ValueMember = "value";
            this.comboBox_Window.SelectedIndexChanged += new System.EventHandler(this.comboBox_kind_SelectedIndexChanged);
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
            // isWindowsTableAdapter
            // 
            this.isWindowsTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(283, 533);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(177, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "郵件收件者";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.Line1;
            this.pictureBox1.Location = new System.Drawing.Point(83, 386);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 12);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(32, 409);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "收件者";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(32, 449);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 36);
            this.button4.TabIndex = 5;
            this.button4.Text = "副本";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_Receiver
            // 
            this.txt_Receiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Receiver.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_Receiver.Location = new System.Drawing.Point(113, 409);
            this.txt_Receiver.Multiline = true;
            this.txt_Receiver.Name = "txt_Receiver";
            this.txt_Receiver.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Receiver.Size = new System.Drawing.Size(436, 36);
            this.txt_Receiver.TabIndex = 4;
            // 
            // txt_cc
            // 
            this.txt_cc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_cc.Location = new System.Drawing.Point(113, 449);
            this.txt_cc.Multiline = true;
            this.txt_cc.Name = "txt_cc";
            this.txt_cc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_cc.Size = new System.Drawing.Size(436, 36);
            this.txt_cc.TabIndex = 6;
            // 
            // txt_Bcc
            // 
            this.txt_Bcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Bcc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_Bcc.Location = new System.Drawing.Point(113, 491);
            this.txt_Bcc.Multiline = true;
            this.txt_Bcc.Name = "txt_Bcc";
            this.txt_Bcc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Bcc.Size = new System.Drawing.Size(436, 36);
            this.txt_Bcc.TabIndex = 8;
            // 
            // but_Bcc
            // 
            this.but_Bcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_Bcc.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Bcc.Location = new System.Drawing.Point(32, 491);
            this.but_Bcc.Name = "but_Bcc";
            this.but_Bcc.Size = new System.Drawing.Size(75, 36);
            this.but_Bcc.TabIndex = 7;
            this.but_Bcc.Text = "密件副本";
            this.but_Bcc.UseVisualStyleBackColor = true;
            this.but_Bcc.Click += new System.EventHandler(this.but_Bcc_Click);
            // 
            // Liaisoner
            // 
            this.Liaisoner.DataPropertyName = "LiaisonerName";
            this.Liaisoner.HeaderText = "姓名";
            this.Liaisoner.Name = "Liaisoner";
            this.Liaisoner.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.email.DefaultCellStyle = dataGridViewCellStyle3;
            this.email.HeaderText = "電子信箱";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 150;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "職稱";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // ContractType
            // 
            this.ContractType.DataPropertyName = "ContractType";
            this.ContractType.HeaderText = "窗口類型";
            this.ContractType.Name = "ContractType";
            this.ContractType.ReadOnly = true;
            // 
            // MailReceive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.candyhole;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(561, 578);
            this.Controls.Add(this.txt_Bcc);
            this.Controls.Add(this.but_Bcc);
            this.Controls.Add(this.txt_cc);
            this.Controls.Add(this.txt_Receiver);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Window);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Receive);
            this.Controls.Add(this.comboBox_kind);
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收件人";
            this.Load += new System.EventHandler(this.MailReceive_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MailReceive_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Receive)).EndInit();
            this.contextMenuStrip_email.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.isWindowsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_kind;
        private System.Windows.Forms.DataGridView dataGridView_Receive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Window;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource isWindowsBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.IsWindowsTableAdapter isWindowsTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txt_Receiver;
        private System.Windows.Forms.TextBox txt_cc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_email;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_reciever;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CC;
        private System.Windows.Forms.TextBox txt_Bcc;
        private System.Windows.Forms.Button but_Bcc;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Bcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Liaisoner;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractType;
    }
}