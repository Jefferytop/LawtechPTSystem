namespace LawtechPTSystemByFirm.AddFrom
{
    partial class AddComitContent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddComitContent));
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.txtComitContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_Sort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_processKind = new System.Windows.Forms.ComboBox();
            this.processKindTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.comboBox_patStatus = new System.Windows.Forms.ComboBox();
            this.patStatusTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.processKindT_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.ProcessKindT_DropTableAdapter();
            this.patStatusT_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processKindTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(228, 215);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 140;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(122, 215);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 130;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txtComitContent
            // 
            this.txtComitContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComitContent.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtComitContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtComitContent.Location = new System.Drawing.Point(144, 117);
            this.txtComitContent.Name = "txtComitContent";
            this.txtComitContent.Size = new System.Drawing.Size(289, 29);
            this.txtComitContent.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(69, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "事件內容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(101, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "排序";
            // 
            // numericUpDown_Sort
            // 
            this.numericUpDown_Sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Sort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_Sort.Location = new System.Drawing.Point(144, 19);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(7, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "指定標準作業流程";
            // 
            // comboBox_processKind
            // 
            this.comboBox_processKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_processKind.DataSource = this.processKindTDropBindingSource;
            this.comboBox_processKind.DisplayMember = "ProcessKind";
            this.comboBox_processKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_processKind.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_processKind.FormattingEnabled = true;
            this.comboBox_processKind.Location = new System.Drawing.Point(144, 151);
            this.comboBox_processKind.Name = "comboBox_processKind";
            this.comboBox_processKind.Size = new System.Drawing.Size(289, 32);
            this.comboBox_processKind.TabIndex = 3;
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
            // comboBox_patStatus
            // 
            this.comboBox_patStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_patStatus.DataSource = this.patStatusTDropBindingSource;
            this.comboBox_patStatus.DisplayMember = "Status";
            this.comboBox_patStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_patStatus.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_patStatus.FormattingEnabled = true;
            this.comboBox_patStatus.Location = new System.Drawing.Point(144, 52);
            this.comboBox_patStatus.Name = "comboBox_patStatus";
            this.comboBox_patStatus.Size = new System.Drawing.Size(289, 32);
            this.comboBox_patStatus.TabIndex = 1;
            this.comboBox_patStatus.ValueMember = "StatusID";
            // 
            // patStatusTDropBindingSource
            // 
            this.patStatusTDropBindingSource.DataMember = "PatStatusT-Drop";
            this.patStatusTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(21, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "對應的案件階段";
            // 
            // processKindT_DropTableAdapter
            // 
            this.processKindT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // patStatusT_DropTableAdapter
            // 
            this.patStatusT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Sienna;
            this.label5.Location = new System.Drawing.Point(142, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "* 若無作業流程，可不選";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label6.ForeColor = System.Drawing.Color.Sienna;
            this.label6.Location = new System.Drawing.Point(142, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 16);
            this.label6.TabIndex = 141;
            this.label6.Text = "* 若無對應的案件階段，可不選";
            // 
            // AddComitContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg1;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(450, 260);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddComitContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增專利事件內容";
            this.Load += new System.EventHandler(this.AddComitContent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddComitContent_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processKindTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.TextBox txtComitContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_processKind;
        private System.Windows.Forms.ComboBox comboBox_patStatus;
        private System.Windows.Forms.Label label4;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource processKindTDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.ProcessKindT_DropTableAdapter processKindT_DropTableAdapter;
        private System.Windows.Forms.BindingSource patStatusTDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter patStatusT_DropTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}