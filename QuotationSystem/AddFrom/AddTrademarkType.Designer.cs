namespace LawtechPTSystem.AddFrom
{
    partial class AddTrademarkType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTrademarkType));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown_SN = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_TypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trademarkTypeModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_TM = new LawtechPTSystem.DataSet_TM();
            this.trademarkTypeModeTableAdapter = new LawtechPTSystem.DataSet_TMTableAdapters.TrademarkTypeModeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkTypeModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TM)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(195, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 82;
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
            this.button1.Location = new System.Drawing.Point(89, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 81;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown_SN
            // 
            this.numericUpDown_SN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_SN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_SN.Location = new System.Drawing.Point(87, 27);
            this.numericUpDown_SN.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_SN.Name = "numericUpDown_SN";
            this.numericUpDown_SN.Size = new System.Drawing.Size(152, 29);
            this.numericUpDown_SN.TabIndex = 77;
            this.numericUpDown_SN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label15.Location = new System.Drawing.Point(45, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 80;
            this.label15.Text = "排序";
            // 
            // txt_TypeName
            // 
            this.txt_TypeName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_TypeName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_TypeName.Location = new System.Drawing.Point(87, 90);
            this.txt_TypeName.MaxLength = 20;
            this.txt_TypeName.Name = "txt_TypeName";
            this.txt_TypeName.Size = new System.Drawing.Size(274, 29);
            this.txt_TypeName.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(13, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "案件類別";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(45, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "類型";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.trademarkTypeModeBindingSource;
            this.comboBox1.DisplayMember = "TypeModeName";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 28);
            this.comboBox1.TabIndex = 84;
            this.comboBox1.ValueMember = "TypeMode";
            // 
            // trademarkTypeModeBindingSource
            // 
            this.trademarkTypeModeBindingSource.DataMember = "TrademarkTypeMode";
            this.trademarkTypeModeBindingSource.DataSource = this.dataSet_TM;
            // 
            // dataSet_TM
            // 
            this.dataSet_TM.DataSetName = "DataSet_TM";
            this.dataSet_TM.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // trademarkTypeModeTableAdapter
            // 
            this.trademarkTypeModeTableAdapter.ClearBeforeFill = true;
            // 
            // AddTrademarkType
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(385, 172);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown_SN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_TypeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTrademarkType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增案件類別";
            this.Load += new System.EventHandler(this.AddTrademarkType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkTypeModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown_SN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_TypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private DataSet_TM dataSet_TM;
        private System.Windows.Forms.BindingSource trademarkTypeModeBindingSource;
        private LawtechPTSystem.DataSet_TMTableAdapters.TrademarkTypeModeTableAdapter trademarkTypeModeTableAdapter;
    }
}