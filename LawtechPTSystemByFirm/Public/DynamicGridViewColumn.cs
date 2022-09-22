using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 從DB 取得GridView的欄位資料
    /// </summary>
    public class DynamicGridViewColumn
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="list">當GridColumnType=</param>
        public static void GetGridColum(ref DataGridView dv,Dictionary<string,BindingSource>  list=null)
        {
            try
            {
                dv.Columns.Clear();
                List<DB_Models.DB_GridColumnTModel> colums = new List<DB_Models.DB_GridColumnTModel>();
                DB_Models.DB_GridColumnTModel.ReadList(ref colums, dv.Tag.ToString());

                foreach (var item in colums)
                {
                    switch (item.GridColumnType.Value)
                    {
                        #region DataGridViewLinkColumn
                        case 2:
                            DataGridViewLinkColumn gvColu2 = new DataGridViewLinkColumn();
                            gvColu2.Name = item.GridColumnName;
                            if (!string.IsNullOrEmpty(item.DataPropertyName))
                            {
                                gvColu2.DataPropertyName = item.DataPropertyName;
                                gvColu2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                            }
                            else
                            {
                                gvColu2.UseColumnTextForLinkValue = true;
                            }
                            gvColu2.HeaderText = item.HeaderText;
                            gvColu2.ToolTipText = item.ToolTipText;
                            gvColu2.Text = item.LinkText;
                            gvColu2.LinkColor = Color.Blue;
                            gvColu2.VisitedLinkColor = Color.BlueViolet;
                            
                            if (item.ReadOnly.HasValue)
                            {
                                gvColu2.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Width.HasValue)
                            {
                                gvColu2.Width = item.Width.Value;
                            }

                            if (item.ReadOnly.HasValue)
                            {
                                gvColu2.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Visible.HasValue)
                            {
                                gvColu2.Visible = item.Visible.Value;
                            }

                            DataGridViewCellStyle cellstyle2 = new DataGridViewCellStyle();

                            #region Alignment
                            if (!string.IsNullOrEmpty(item.Alignment))
                            {
                                switch (item.Alignment)
                                {
                                    case "MiddleCenter":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        break;
                                    case "MiddleLeft":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                        break;
                                    case "MiddleRight":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        break;
                                    case "BottomCenter":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.BottomCenter;
                                        break;
                                    case "BottomLeft":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.BottomLeft;
                                        break;
                                    case "BottomRight":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.BottomRight;
                                        break;
                                    case "TopCenter":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.TopCenter;
                                        break;
                                    case "TopLeft":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.TopLeft;
                                        break;
                                    case "TopRight":
                                        cellstyle2.Alignment = DataGridViewContentAlignment.TopRight;
                                        break;
                                    default:
                                        cellstyle2.Alignment = DataGridViewContentAlignment.NotSet;
                                        break;
                                }
                            }
                            #endregion

                            #region Format
                            if (!string.IsNullOrEmpty(item.Format))
                            {
                                cellstyle2.Format = item.Format;
                            }
                            #endregion

                            #region FontSize
                            float fontSize = 9;
                            if (!string.IsNullOrEmpty(item.FontSize))
                            {
                                float f = float.Parse(item.FontSize);
                                if (f > 9)
                                {
                                    fontSize = f;
                                }
                            }
                            #endregion

                            System.Drawing.Font myFont2;
                            if (!string.IsNullOrEmpty(item.Font))
                            {
                                myFont2 = new System.Drawing.Font(item.Font, fontSize);
                            }
                            else
                            {
                                myFont2 = new System.Drawing.Font("微軟正黑體", fontSize);
                            }

                            cellstyle2.Font = myFont2;

                            if (!string.IsNullOrEmpty(item.ForeColor))
                            {
                                cellstyle2.ForeColor = ColorTranslator.FromHtml(item.ForeColor);
                            }

                            if (!string.IsNullOrEmpty(item.BackColor))
                            {
                                cellstyle2.BackColor = ColorTranslator.FromHtml(item.BackColor);
                            }

                            gvColu2.DefaultCellStyle = cellstyle2;

                            dv.Columns.Add(gvColu2);
                            break;
                        #endregion

                        #region DataGridViewComboBoxColumn
                        case 4:
                            DataGridViewComboBoxColumn gvColu4 = new DataGridViewComboBoxColumn();
                            gvColu4.Name = item.GridColumnName;
                            gvColu4.DataPropertyName = item.DataPropertyName;
                            gvColu4.HeaderText = item.HeaderText;
                            gvColu4.ToolTipText = item.ToolTipText;
                            gvColu4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                            if (!string.IsNullOrEmpty(item.DataSource))
                            {

                                gvColu4.DataSource = list[item.DataSource];

                                gvColu4.DisplayMember = item.DisplayMember;
                                gvColu4.ValueMember = item.ValueMember;
                            }
                            if (item.ReadOnly.HasValue)
                            {
                                gvColu4.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Width.HasValue)
                            {
                                gvColu4.Width = item.Width.Value;
                            }

                            if (item.ReadOnly.HasValue)
                            {
                                gvColu4.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Visible.HasValue)
                            {
                                gvColu4.Visible = item.Visible.Value;
                            }

                            DataGridViewCellStyle cellstyle4 = new DataGridViewCellStyle();

                            #region Alignment
                            if (!string.IsNullOrEmpty(item.Alignment))
                            {
                                switch (item.Alignment)
                                {
                                    case "MiddleCenter":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        break;
                                    case "MiddleLeft":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                        break;
                                    case "MiddleRight":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        break;
                                    case "BottomCenter":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.BottomCenter;
                                        break;
                                    case "BottomLeft":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.BottomLeft;
                                        break;
                                    case "TopCenter":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.TopCenter;
                                        break;
                                    case "TopLeft":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.TopLeft;
                                        break;
                                    case "TopRight":
                                        cellstyle4.Alignment = DataGridViewContentAlignment.TopRight;
                                        break;
                                    default:
                                        cellstyle4.Alignment = DataGridViewContentAlignment.NotSet;
                                        break;
                                }
                            }
                            #endregion

                            #region Format
                            if (!string.IsNullOrEmpty(item.Format))
                            {
                                cellstyle4.Format = item.Format;
                            }
                            #endregion

                            #region FontSize
                            float fontSize4 = 9;
                            if (!string.IsNullOrEmpty(item.FontSize))
                            {
                                float f = float.Parse(item.FontSize);
                                if (f > 9)
                                {
                                    fontSize = f;
                                }
                            }
                            #endregion

                            System.Drawing.Font myFont4;
                            if (!string.IsNullOrEmpty(item.Font))
                            {
                                myFont4 = new System.Drawing.Font(item.Font, fontSize4);
                            }
                            else
                            {
                                myFont4 = new System.Drawing.Font("微軟正黑體", fontSize4);
                            }

                            cellstyle4.Font = myFont4;

                            if (!string.IsNullOrEmpty(item.ForeColor))
                            {
                                cellstyle4.ForeColor = ColorTranslator.FromHtml(item.ForeColor);
                            }

                            if (!string.IsNullOrEmpty(item.BackColor))
                            {
                                cellstyle4.BackColor = ColorTranslator.FromHtml(item.BackColor);
                            }

                            gvColu4.DefaultCellStyle = cellstyle4;
                            dv.Columns.Add(gvColu4);
                            break;
                        #endregion

                        #region DataGridViewCheckBoxColumn
                        case 5:
                            DataGridViewCheckBoxColumn gvColu5 = new DataGridViewCheckBoxColumn();
                            gvColu5.Name = item.GridColumnName;
                            if (!string.IsNullOrEmpty(item.DataPropertyName))
                            {
                                gvColu5.DataPropertyName = item.DataPropertyName;
                            }
                           
                            gvColu5.HeaderText = item.HeaderText;
                            gvColu5.ToolTipText = item.ToolTipText;
                            gvColu5.IndeterminateValue = false;
                            gvColu5.TrueValue = "True";
                            gvColu5.FalseValue = "False";                            
                            if (item.ReadOnly.HasValue)
                            {
                                gvColu5.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Width.HasValue)
                            {
                                gvColu5.Width = item.Width.Value;
                            }

                            if (item.ReadOnly.HasValue)
                            {
                                gvColu5.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Visible.HasValue)
                            {
                                gvColu5.Visible = item.Visible.Value;
                            }

                            DataGridViewCellStyle cellstyle5 = new DataGridViewCellStyle();

                            #region Alignment
                            if (!string.IsNullOrEmpty(item.Alignment))
                            {
                                switch (item.Alignment)
                                {
                                    case "MiddleCenter":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        break;
                                    case "MiddleLeft":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                        break;
                                    case "MiddleRight":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        break;
                                    case "BottomCenter":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.BottomCenter;
                                        break;
                                    case "BottomLeft":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.BottomLeft;
                                        break;
                                    case "TopCenter":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.TopCenter;
                                        break;
                                    case "TopLeft":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.TopLeft;
                                        break;
                                    case "TopRight":
                                        cellstyle5.Alignment = DataGridViewContentAlignment.TopRight;
                                        break;
                                    default:
                                        cellstyle5.Alignment = DataGridViewContentAlignment.NotSet;
                                        break;
                                }
                            }
                            #endregion

                            #region NullValue
                            if (string.IsNullOrEmpty(item.DataPropertyName))
                            {
                                cellstyle5.NullValue = "False";
                            }
                            #endregion

                            #region Format
                            if (!string.IsNullOrEmpty(item.Format))
                            {
                                cellstyle5.Format = item.Format;
                            }
                            #endregion

                            #region FontSize
                            float fontSize5 = 9;
                            if (!string.IsNullOrEmpty(item.FontSize))
                            {
                                float f = float.Parse(item.FontSize);
                                if (f > 9)
                                {
                                    fontSize = f;
                                }
                            }
                            #endregion

                            System.Drawing.Font myFont5;
                            if (!string.IsNullOrEmpty(item.Font))
                            {
                                myFont5 = new System.Drawing.Font(item.Font, fontSize5);
                            }
                            else
                            {
                                myFont5 = new System.Drawing.Font("微軟正黑體", fontSize5);
                            }

                            cellstyle5.Font = myFont5;

                            if (!string.IsNullOrEmpty(item.ForeColor))
                            {
                                cellstyle5.ForeColor = ColorTranslator.FromHtml(item.ForeColor);
                            }

                            if (!string.IsNullOrEmpty(item.BackColor))
                            {
                                cellstyle5.BackColor = ColorTranslator.FromHtml(item.BackColor);
                            }

                            gvColu5.DefaultCellStyle = cellstyle5;
                            dv.Columns.Add(gvColu5);
                            break;
                        #endregion

                        #region DataGridViewTextBoxColumn
                        case 1:
                        default:
                            DataGridViewTextBoxColumn gvColu1 = new DataGridViewTextBoxColumn();
                            gvColu1.Name = item.GridColumnName;
                            if (!string.IsNullOrEmpty(item.DataPropertyName))
                            {
                                gvColu1.DataPropertyName = item.DataPropertyName;
                            }
                            gvColu1.HeaderText = item.HeaderText;
                            gvColu1.ToolTipText = item.ToolTipText;
                            if (item.ReadOnly.HasValue)
                            {
                                gvColu1.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Width.HasValue)
                            {
                                gvColu1.Width = item.Width.Value;
                            }

                            if (item.ReadOnly.HasValue)
                            {
                                gvColu1.ReadOnly = item.ReadOnly.Value;
                            }

                            if (item.Visible.HasValue)
                            {
                                gvColu1.Visible = item.Visible.Value;
                            }

                            DataGridViewCellStyle cellstyle1 = new DataGridViewCellStyle();

                            #region Alignment
                            if (!string.IsNullOrEmpty(item.Alignment))
                            {
                                switch (item.Alignment)
                                {
                                    case "MiddleCenter":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        break;
                                    case "MiddleLeft":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                        break;
                                    case "MiddleRight":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        break;
                                    case "BottomCenter":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.BottomCenter;
                                        break;
                                    case "BottomLeft":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.BottomLeft;
                                        break;
                                    case "TopCenter":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.TopCenter;
                                        break;
                                    case "TopLeft":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.TopLeft;
                                        break;
                                    case "TopRight":
                                        cellstyle1.Alignment = DataGridViewContentAlignment.TopRight;
                                        break;
                                    default:
                                        cellstyle1.Alignment = DataGridViewContentAlignment.NotSet;
                                        break;
                                }
                            }
                            #endregion

                            #region Format
                            if (!string.IsNullOrEmpty(item.Format))
                            {
                                cellstyle1.Format = item.Format;
                            }
                            #endregion

                            #region FontSize
                            float fontSize1 = 9;
                            if (!string.IsNullOrEmpty(item.FontSize))
                            {
                                float f = float.Parse(item.FontSize);
                                if (f > 9)
                                {
                                    fontSize = f;
                                }
                            }
                            #endregion

                            System.Drawing.Font myFont1;
                            if (!string.IsNullOrEmpty(item.Font))
                            {
                                myFont1 = new System.Drawing.Font(item.Font, fontSize1);
                            }
                            else
                            {
                                myFont1 = new System.Drawing.Font("微軟正黑體", fontSize1);
                            }

                            cellstyle1.Font = myFont1;

                            if (!string.IsNullOrEmpty(item.ForeColor))
                            {
                                cellstyle1.ForeColor = ColorTranslator.FromHtml(item.ForeColor);
                            }


                            if (!string.IsNullOrEmpty(item.BackColor))
                            {
                                cellstyle1.BackColor = ColorTranslator.FromHtml(item.BackColor);
                            }

                            gvColu1.DefaultCellStyle = cellstyle1;
                            dv.Columns.Add(gvColu1);
                            break;
                        #endregion
                    }
                }
            }
            catch (System.Exception EX)
            {
                string ss = EX.Message;
            }

        }

        
    }
}
