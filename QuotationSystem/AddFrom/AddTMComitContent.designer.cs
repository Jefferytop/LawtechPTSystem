namespace LawtechPTSystem.AddFrom
{
    partial class AddTMComitContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTMComitContent));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_patStatus = new System.Windows.Forms.ComboBox();
            this.tMStatusTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Drop = new DataSet_Drop();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_processKind = new System.Windows.Forms.ComboBox();
            this.processKindTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new QS_DataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_Sort = new System.Windows.Forms.NumericUpDown();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.txtComitContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tMStatusTTableAdapter = new DataSet_DropTableAdapters.TMStatusTTableAdapter();
            this.processKindT_DropTableAdapter = new QS_DataSetTableAdapters.ProcessKindT_DropTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processKindTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label6.ForeColor = System.Drawing.Color.Sienna;
            this.label6.Location = new System.Drawing.Point(134, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "*若無影響專利狀態的異動，可不選";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label5.ForeColor = System.Drawing.Color.Sienna;
            this.label5.Location = new System.Drawing.Point(134, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "*若無觸發事件，可不選";
            // 
            // comboBox_patStatus
            // 
            this.comboBox_patStatus.DataSource = this.tMStatusTBindingSource;
            this.comboBox_patStatus.DisplayMember = "Status";
            this.comboBox_patStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_patStatus.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_patStatus.FormattingEnabled = true;
            this.comboBox_patStatus.Location = new System.Drawing.Point(136, 131);
            this.comboBox_patStatus.Name = "comboBox_patStatus";
            this.comboBox_patStatus.Size = new System.Drawing.Size(289, 32);
            this.comboBox_patStatus.TabIndex = 4;
            this.comboBox_patStatus.ValueMember = "TMStatusID";
            // 
            // tMStatusTBindingSource
            // 
            this.tMStatusTBindingSource.DataMember = "TMStatusT";
            this.tMStatusTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "dataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "對應的商標階段";
            // 
            // comboBox_processKind
            // 
            this.comboBox_processKind.DataSource = this.processKindTDropBindingSource;
            this.comboBox_processKind.DisplayMember = "ProcessKind";
            this.comboBox_processKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_processKind.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_processKind.FormattingEnabled = true;
            this.comboBox_processKind.Location = new System.Drawing.Point(136, 72);
            this.comboBox_processKind.Name = "comboBox_processKind";
            this.comboBox_processKind.Size = new System.Drawing.Size(289, 32);
            this.comboBox_processKind.TabIndex = 2;
            this.comboBox_processKind.ValueMember = "ProcessKEY";
            // 
            // processKindTDropBindingSource
            // 
            this.processKindTDropBindingSource.DataMember = "ProcessKindT-Drop";
            this.processKindTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "預設觸發的事件";
            // 
            // numericUpDown_Sort
            // 
            this.numericUpDown_Sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Sort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_Sort.Location = new System.Drawing.Point(136, 6);
            this.numericUpDown_Sort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_Sort.Name = "numericUpDown_Sort";
            this.numericUpDown_Sort.Size = new System.Drawing.Size(152, 29);
            this.numericUpDown_Sort.TabIndex = 0;
            this.numericUpDown_Sort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butCancel.BackgroundImage")));
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(226, 196);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 30;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(120, 196);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 29;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txtComitContent
            // 
            this.txtComitContent.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtComitContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtComitContent.Location = new System.Drawing.Point(136, 39);
            this.txtComitContent.Name = "txtComitContent";
            this.txtComitContent.Size = new System.Drawing.Size(289, 29);
            this.txtComitContent.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(61, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "委辦內容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "排序";
            // 
            // tMStatusTTableAdapter
            // 
            this.tMStatusTTableAdapter.ClearBeforeFill = true;
            // 
            // processKindT_DropTableAdapter
            // 
            this.processKindT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // AddTMComitContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(447, 241);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_patStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_processKind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_Sort);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.txtComitContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTMComitContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增商標委辦內容";
            this.Load += new System.EventHandler(this.AddTMComitContent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddTMComitContent_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processKindTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_patStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_processKind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sort;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.TextBox txtComitContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private QS_DataSet qS_DataSet;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource tMStatusTBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.TMStatusTTableAdapter tMStatusTTableAdapter;
        private System.Windows.Forms.BindingSource processKindTDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.ProcessKindT_DropTableAdapter processKindT_DropTableAdapter;
    }
}