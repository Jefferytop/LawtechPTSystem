using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class TagTitle : UserControl
    {
        private string m_TitleStyle = "Style1";
        private string m_TitleLableText = "--";

        public TagTitle()
        {
            InitializeComponent();
        }

        [DisplayName("TitleLable")]
        public Label TitleLable
        {
            get { return labTagTitleName; }
        }

        [DisplayName("TitleLableText")]
        [Description("標題名稱")]
        public string TitleLableText
        {
            get { return m_TitleLableText; }
            set { m_TitleLableText = labTagTitleName.Text = value; }
        }


        [DisplayName("TagTitleStyle")]
        [Description("TagTitle 的樣式，預設為Style1(Style1~5)")]
        public string TagTitleStyle
        {
            get { return m_TitleStyle; }
            set
            {
                m_TitleStyle = value;
                switch (m_TitleStyle)
                {
                    case "Style1":
                        this.pic_L.Image = LawtechPTSystemByFirm.Properties.Resources.Tag1_L;
                        this.pic_R.Image = LawtechPTSystemByFirm.Properties.Resources.Tag1_R;
                        this.BackgroundImage = LawtechPTSystemByFirm.Properties.Resources.Tag1_bg;
                        break;
                    case "Style2":
                        this.pic_L.Image = LawtechPTSystemByFirm.Properties.Resources.Tag2_L;
                        this.pic_R.Image = LawtechPTSystemByFirm.Properties.Resources.Tag2_R;
                        this.BackgroundImage = LawtechPTSystemByFirm.Properties.Resources.Tag2_bg;
                        break;
                    case "Style3":
                        this.pic_L.Image = LawtechPTSystemByFirm.Properties.Resources.Tag3_L;
                        this.pic_R.Image = LawtechPTSystemByFirm.Properties.Resources.Tag3_R;
                        this.BackgroundImage = LawtechPTSystemByFirm.Properties.Resources.Tag3_bg;
                        break;
                    case "Style4":
                        this.pic_L.Image = LawtechPTSystemByFirm.Properties.Resources.Tag4_L;
                        this.pic_R.Image = LawtechPTSystemByFirm.Properties.Resources.Tag4_R;
                        this.BackgroundImage = LawtechPTSystemByFirm.Properties.Resources.Tag4_bg;
                        break;
                    case "Style5":
                        this.pic_L.Image = LawtechPTSystemByFirm.Properties.Resources.Tag5_L;
                        this.pic_R.Image = LawtechPTSystemByFirm.Properties.Resources.Tag5_R;
                        this.BackgroundImage = LawtechPTSystemByFirm.Properties.Resources.Tag5_bg;
                        break;
                    default:
                        this.pic_L.Image = LawtechPTSystemByFirm.Properties.Resources.Tag1_L;
                        this.pic_R.Image = LawtechPTSystemByFirm.Properties.Resources.Tag1_R;
                        this.BackgroundImage = LawtechPTSystemByFirm.Properties.Resources.Tag1_bg;
                        break;
                }
            }
        }


    }
}
