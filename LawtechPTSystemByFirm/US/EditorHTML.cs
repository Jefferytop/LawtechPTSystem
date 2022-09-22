using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Diagnostics;

namespace LawtechPTSystemByFirm.US
{

    #region ========enum========
    /// <summary>
    /// Enumeration of possible font sizes for the Editor component
    /// </summary>
    public enum FontSize
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        NA
    }

    public enum SelectionType
    {
        Text,
        Control,
        None
    }

    public enum ReadyState
    {
        Uninitialized,
        Loading,
        Loaded,
        Interactive,
        Complete
    }
    #endregion

    public partial class EditorHTML : UserControl
    {
        private IHTMLDocument2 doc;
        private bool updatingFontName = false;
        private bool updatingFontSize = false;

        public event WebBrowserNavigatedEventHandler Navigated;

        public event EventHandler<EnterKeyEventArgs> EnterKeyEvent;


        public class EnterKeyEventArgs : EventArgs
        {
            private bool _cancel = false;

            public bool Cancel
            {
                get { return _cancel; }
                set { _cancel = value; }
            }

        }


        public EditorHTML()
        {
            InitializeComponent();
            SetupEvents();

            SetupBrowser();
            SetupFontComboBox();
            SetupFontSizeComboBox();
        }


        /// <summary>
        /// Setup navigation and focus event handlers.
        /// </summary>
        private void SetupEvents()
        {
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            webBrowser1.GotFocus += new EventHandler(webBrowser1_GotFocus);
        }


        /// <summary>
        /// Get/Set the current font size.
        /// </summary>
        [Browsable(false)]
        public FontSize FontSize
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return FontSize.NA;
                switch (doc.queryCommandValue("FontSize") as string)
                {
                    case "1":
                        return FontSize.One;
                    case "2":
                        return FontSize.Two;
                    case "3":
                        return FontSize.Three;
                    case "4":
                        return FontSize.Four;
                    case "5":
                        return FontSize.Five;
                    case "6":
                        return FontSize.Six;
                    case "7":
                        return FontSize.Seven;
                    default:
                        return FontSize.NA;
                }
            }
            set
            {
                int sz;
                switch (value)
                {
                    case FontSize.One:
                        sz = 1;
                        break;
                    case FontSize.Two:
                        sz = 2;
                        break;
                    case FontSize.Three:
                        sz = 3;
                        break;
                    case FontSize.Four:
                        sz = 4;
                        break;
                    case FontSize.Five:
                        sz = 5;
                        break;
                    case FontSize.Six:
                        sz = 6;
                        break;
                    case FontSize.Seven:
                        sz = 7;
                        break;
                    default:
                        sz = 7;
                        break;
                }
                webBrowser1.Document.ExecCommand("FontSize", false, sz.ToString());
            }
        }


        /// <summary>
        /// Get/Set the current font name.
        /// </summary>
        [Browsable(false)]
        public FontFamily FontName
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return null;
                string name = doc.queryCommandValue("FontName") as string;
                if (name == null) return null;
                return new FontFamily(name);
            }
            set
            {
                if (value != null)
                    webBrowser1.Document.ExecCommand("FontName", false, value.Name);
            }
        }


        /// <summary>
        /// When this control receives focus, it transfers focus to the 
        /// document body.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void webBrowser1_GotFocus(object sender, EventArgs e)
        {
            SuperFocus();
        }

        /// <summary>
        /// Set the focus on the document body.  
        /// </summary>
        private void SuperFocus()
        {
            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.Focus();
        }

        /// <summary>
        /// This is called when the initial html/body framework is set up, 
        /// or when document.DocumentText is set.  At this point, the 
        /// document is editable.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">navigation args</param>
        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            SetBackgroundColor(BackColor);
            if (Navigated != null)
            {
                Navigated(this, e);
            }
        }

        /// <summary>
        /// Set the background color of the body by setting it's CSS style
        /// </summary>
        /// <param name="value">the color to use for the background</param>
        private void SetBackgroundColor(Color value)
        {
            if (webBrowser1.Document != null &&
                webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.Style =
                    string.Format("background-color: {0}", value.Name);
        }


        /// <summary>
        /// Add document body, turn on design mode on the whole document, 
        /// and overred the context menu
        /// </summary>
        private void SetupBrowser()
        {
            webBrowser1.DocumentText = "<HTML><HEAD><TITLE></TITLE></HEAD><BODY></BODY></HTML>";           
            

            doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";
            doc.write("<HTML><HEAD><TITLE></TITLE></HEAD><BODY></BODY></HTML>");
            webBrowser1.Document.ContextMenuShowing += new HtmlElementEventHandler(Document_ContextMenuShowing);
        }


        /// <summary>
        /// Called when the editor context menu should be displayed.
        /// The return value of the event is set to false to disable the 
        /// default context menu.  A custom context menu (contextMenuStrip1) is 
        /// shown instead.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">HtmlElementEventArgs</param>
        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            e.ReturnValue = false;
            cutToolStripMenuItem1.Enabled = CanCut();
            copyToolStripMenuItem2.Enabled = CanCopy();
            pasteToolStripMenuItem3.Enabled = CanPaste();
            deleteToolStripMenuItem.Enabled = CanDelete();
            contextMenuStrip1.Show(this, e.ClientMousePosition);
        }

        /// <summary>
        /// Determine the status of the Cut command in the document editor.
        /// </summary>
        /// <returns>whether or not a cut operation is currently valid</returns>
        public bool CanCut()
        {
            return doc.queryCommandEnabled("Cut");
        }

        /// <summary>
        /// Determine the status of the Copy command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanCopy()
        {
            return doc.queryCommandEnabled("Copy");
        }

        /// <summary>
        /// Determine the status of the Paste command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanPaste()
        {
            return doc.queryCommandEnabled("Paste");
        }

        /// <summary>
        /// Determine the status of the Delete command in the document editor.
        /// </summary>
        /// <returns>whether or not a copy operation is currently valid</returns>
        public bool CanDelete()
        {
            return doc.queryCommandEnabled("Delete");
        }


        /// <summary>
        /// Populate the font combo box and autocomplete handlers.
        /// Add a text changed handler to the font combo box to handle new font selections.
        /// </summary>
        private void SetupFontComboBox()
        {
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (FontFamily fam in FontFamily.Families)
            {
                fontComboBox.Items.Add(fam.Name);
                ac.Add(fam.Name);
            }
            fontComboBox.SelectedIndexChanged += new EventHandler(fontComboBox_TextChanged);
            fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            fontComboBox.AutoCompleteCustomSource = ac;
        }

        /// <summary>
        /// Called when the font combo box has changed.
        /// Ignores the event when the timer is updating the font combo Box 
        /// to synchronize the editor selection with the font combo box.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void fontComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontName) return;
            FontFamily ff;
            try
            {
                ff = new FontFamily(fontComboBox.Text);
            }
            catch (Exception)
            {
                updatingFontName = true;
                fontComboBox.Text = FontName.GetName(0);
                updatingFontName = false;
                return;
            }
            FontName = ff;
        }

        /// <summary>
        /// Populate the font size combobox.
        /// Add text changed and key press handlers to handle input and update 
        /// the editor selection font size.
        /// </summary>
        private void SetupFontSizeComboBox()
        {
            for (int x = 1; x <= 7; x++)
            {
                fontSizeComboBox.Items.Add(x.ToString());
            }
            fontSizeComboBox.TextChanged += new EventHandler(fontSizeComboBox_TextChanged);
            fontSizeComboBox.KeyPress += new KeyPressEventHandler(fontSizeComboBox_KeyPress);
        }


        /// <summary>
        /// Set editor's current selection to the value of the font size combo box.
        /// Ignore if the timer is currently updating the font size to synchronize 
        /// the font size combo box with the editor's current selection.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">EventArgs</param>
        private void fontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingFontSize) return;
            switch (fontSizeComboBox.Text.Trim())
            {
                case "1":
                    FontSize = FontSize.One;
                    break;
                case "2":
                    FontSize = FontSize.Two;
                    break;
                case "3":
                    FontSize = FontSize.Three;
                    break;
                case "4":
                    FontSize = FontSize.Four;
                    break;
                case "5":
                    FontSize = FontSize.Five;
                    break;
                case "6":
                    FontSize = FontSize.Six;
                    break;
                case "7":
                    FontSize = FontSize.Seven;
                    break;
                default:
                    FontSize = FontSize.Seven;
                    break;
            }
        }

        /// <summary>
        /// Called when a key is pressed on the font size combo box.
        /// The font size in the boxy box is set to the key press value.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        private void fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                    fontSizeComboBox.Text = e.KeyChar.ToString();
            }
            else if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Get the ready state of the internal browser component.
        /// </summary>
        public ReadyState ReadyState
        {
            get
            {
                switch (doc.readyState.ToLower())
                {
                    case "uninitialized":
                        return ReadyState.Uninitialized;
                    case "loading":
                        return ReadyState.Loading;
                    case "loaded":
                        return ReadyState.Loaded;
                    case "interactive":
                        return ReadyState.Interactive;
                    case "complete":
                        return ReadyState.Complete;
                    default:
                        return ReadyState.Uninitialized;
                }
            }
        }
       

        /// <summary>
        /// Get/Set the editor's foreground (text) color for the current selection.
        /// </summary>
        [Browsable(false)]
        public Color EditorForeColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.Black;
                return ConvertToColor(doc.queryCommandValue("ForeColor")as string);
            }
            set
            {
                string colorstr =
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("ForeColor", false, colorstr);
            }
        }

        /// <summary>
        /// Convert the custom integer (B G R) format to a color object.
        /// </summary>
        /// <param name="clrs">the custorm color as a string</param>
        /// <returns>the color</returns>
        private static Color ConvertToColor(string clrs)
        {
            int red, green, blue;
            // sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            if (clrs.StartsWith("#"))
            {
                int clrn = Convert.ToInt32(clrs.Substring(1), 16);
                red = (clrn >> 16) & 255;
                green = (clrn >> 8) & 255;
                blue = clrn & 255;
            }
            else // otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
            {
                int clrn = Convert.ToInt32(clrs);
                red = clrn & 255;
                green = (clrn >> 8) & 255;
                blue = (clrn >> 16) & 255;
            }
            Color incolor = Color.FromArgb(red, green, blue);
            return incolor;
        }

        /// <summary>
        /// Clear the contents of the document, leaving the body intact.
        /// </summary>
        public void Clear()
        {
            if (webBrowser1.Document.Body != null)
                webBrowser1.Document.Body.InnerHtml = "";
        }

        /// <summary>
        /// Get the web browser component's document
        /// </summary>
        public HtmlDocument Document
        {
            get { return webBrowser1.Document; }
        }

        /// <summary>
        /// Get/Set the editor's background color for the current selection.
        /// </summary>
        [Browsable(false)]
        public Color EditorBackColor
        {
            get
            {
                if (ReadyState != ReadyState.Complete)
                    return Color.White;
                return ConvertToColor(doc.queryCommandValue("BackColor")as string);
            }
            set
            {
                string colorstr =
                    string.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B);
                webBrowser1.Document.ExecCommand("BackColor", false, colorstr);
            }
        }



        /// <summary>
        /// Get/Set the contents of the document Body, in html.
        /// </summary>
        [Browsable(false)]
        public string BodyHtml
        {
            get
            {
                if (webBrowser1.Document != null && webBrowser1.Document.Body != null)
                {
                    return webBrowser1.Document.Body.InnerHtml;
                }
                else
                    return string.Empty;
            }
            set
            {
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerHtml = value;
            }
        }

        /// <summary>
        /// Get/Set the documents body as text.
        /// </summary>
        [Browsable(false)]
        public string BodyText
        {
            get
            {
                if (webBrowser1.Document != null &&
                    webBrowser1.Document.Body != null)
                {
                    return webBrowser1.Document.Body.InnerText;
                }
                else
                    return string.Empty;
            }
            set
            {
                if (webBrowser1.Document.Body != null)
                    webBrowser1.Document.Body.InnerText = value;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "boldButton":
                    Bold();
                    break;
                case "italicButton":
                    Italic();
                    break;
                case "underlineButton":
                    Underline();
                    break;
                case "colorButton":
                    SelectForeColor();
                    break;
                case "backColorButton":
                    SelectBackColor();
                    break;
                case "linkButton":
                    SelectLink();
                    break;
                case "imageButton":
                    InsertImage();
                    break;
                case "justifyLeftButton":
                    JustifyLeft();
                    break;
                case "justifyCenterButton":
                    JustifyCenter();
                    break;
                case "justifyRightButton":
                    JustifyRight();
                    break;
                case "justifyFullButton":
                    JustifyFull();
                    break;
                case "orderedListButton":
                    OrderedList();
                    break;
                case "unorderedListButton":
                    UnorderedList();
                    break;
                case "outdentButton":
                    Outdent();
                    break;
                case "indentButton":
                    Indent();
                    break;
              
               
            }
        }


        /// <summary>
        /// Print the current document
        /// </summary>
        public void Print()
        {
            webBrowser1.Document.ExecCommand("Print", true, null);
        }

        /// <summary>
        /// Insert a paragraph break
        /// </summary>
        public void InsertParagraph()
        {
            webBrowser1.Document.ExecCommand("InsertParagraph", false, null);
        }

        /// <summary>
        /// Insert a horizontal rule
        /// </summary>
        public void InsertBreak()
        {
            webBrowser1.Document.ExecCommand("InsertHorizontalRule", false, null);
        }

        /// <summary>
        /// Select all text in the document.
        /// </summary>
        public void SelectAll()
        {
            webBrowser1.Document.ExecCommand("SelectAll", false, null);
        }

        /// <summary>
        /// Undo the last operation
        /// </summary>
        public void Undo()
        {
            webBrowser1.Document.ExecCommand("Undo", false, null);
        }

        /// <summary>
        /// Redo based on the last Undo
        /// </summary>
        public void Redo()
        {
            webBrowser1.Document.ExecCommand("Redo", false, null);
        }

        /// <summary>
        /// Cut the current selection and place it in the clipboard.
        /// </summary>
        public void Cut()
        {
            webBrowser1.Document.ExecCommand("Cut", false, null);
        }

        /// <summary>
        /// Paste the contents of the clipboard into the current selection.
        /// </summary>
        public void Paste()
        {
            webBrowser1.Document.ExecCommand("Paste", false, null);
        }

        /// <summary>
        /// Copy the current selection into the clipboard.
        /// </summary>
        public void Copy()
        {
            webBrowser1.Document.ExecCommand("Copy", false, null);
        }

        /// <summary>
        /// Toggle the ordered list property for the current paragraph.
        /// </summary>
        public void OrderedList()
        {
            webBrowser1.Document.ExecCommand("InsertOrderedList", false, null);
        }

        /// <summary>
        /// Toggle the unordered list property for the current paragraph.
        /// </summary>
        public void UnorderedList()
        {
            webBrowser1.Document.ExecCommand("InsertUnorderedList", false, null);
        }

        /// <summary>
        /// Toggle the left justify property for the currnet block.
        /// </summary>
        public void JustifyLeft()
        {
            webBrowser1.Document.ExecCommand("JustifyLeft", false, null);
        }

        /// <summary>
        /// Toggle the right justify property for the current block.
        /// </summary>
        public void JustifyRight()
        {
            webBrowser1.Document.ExecCommand("JustifyRight", false, null);
        }

        /// <summary>
        /// Toggle the center justify property for the current block.
        /// </summary>
        public void JustifyCenter()
        {
            webBrowser1.Document.ExecCommand("JustifyCenter", false, null);
        }

        /// <summary>
        /// Toggle the full justify property for the current block.
        /// </summary>
        public void JustifyFull()
        {
            webBrowser1.Document.ExecCommand("JustifyFull", false, null);
        }

        /// <summary>
        /// Toggle bold formatting on the current selection.
        /// </summary>
        public void Bold()
        {
            webBrowser1.Document.ExecCommand("Bold", false, null);
        }

        /// <summary>
        /// Toggle italic formatting on the current selection.
        /// </summary>
        public void Italic()
        {
            webBrowser1.Document.ExecCommand("Italic", false, null);
        }

        /// <summary>
        /// Toggle underline formatting on the current selection.
        /// </summary>
        public void Underline()
        {
            webBrowser1.Document.ExecCommand("Underline", false, null);
        }

        /// <summary>
        /// Delete the current selection.
        /// </summary>
        public void Delete()
        {
            webBrowser1.Document.ExecCommand("Delete", false, null);
        }

        /// <summary>
        /// Insert an imange.
        /// </summary>
        public void InsertImage()
        {
            webBrowser1.Document.ExecCommand("InsertImage", true, null);
        }

        /// <summary>
        /// Indent the current paragraph.
        /// </summary>
        public void Indent()
        {
            webBrowser1.Document.ExecCommand("Indent", false, null);
        }

        /// <summary>
        /// Outdent the current paragraph.
        /// </summary>
        public void Outdent()
        {
            webBrowser1.Document.ExecCommand("Outdent", false, null);
        }

        /// <summary>
        /// Insert a link at the current selection.
        /// </summary>
        /// <param name="url">The link url</param>
        public void InsertLink(string url)
        {
            webBrowser1.Document.ExecCommand("CreateLink", false, url);
        }


        /// <summary>
        /// Initiate the foreground (text) color dialog for the current selection.
        /// </summary>
        public void SelectForeColor()
        {
            Color color = EditorForeColor;
            if (ShowColorDialog(ref color))
                EditorForeColor = color;
        }

        /// <summary>
        /// Initiate the background color dialog for the current selection.
        /// </summary>
        public void SelectBackColor()
        {
            Color color = EditorBackColor;
            if (ShowColorDialog(ref color))
                EditorBackColor = color;
        }

        /// <summary>
        /// Show a custom insert link dialog, and create the link.
        /// </summary>
        public void SelectLink()
        {
            using (LinkDialog dlg = new LinkDialog())
            {
                dlg.ShowDialog(this.ParentForm);
                if (!dlg.Accepted) return;
                string link = dlg.URI;
                if (link == null || link.Length == 0)
                {
                    MessageBox.Show(this.ParentForm, "Invalid URL");
                    return;
                }
                InsertLink(dlg.URL);
            }
        }

        /// <summary>
        /// Show the interactive Color dialog.
        /// </summary>
        /// <param name="color">the input and output color</param>
        /// <returns>true if dialog accepted, false if dialog cancelled</returns>
        private bool ShowColorDialog(ref Color color)
        {
            bool selected;
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.SolidColorOnly = true;
                dlg.AllowFullOpen = false;
                dlg.AnyColor = false;
                dlg.FullOpen = false;
                dlg.CustomColors = null;
                dlg.Color = color;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    selected = true;
                    color = dlg.Color;
                }
                else
                {
                    selected = false;
                }
            }
            return selected;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "cutToolStripMenuItem1":
                    Cut();
                    break;
                case "copyToolStripMenuItem2":
                    Copy();
                    break;
                case "pasteToolStripMenuItem3":
                    Paste();
                    break;
                case "deleteToolStripMenuItem":
                    Delete();
                    break;
                case "toolStripMenuItem_Source":
                    MessageBox.Show(BodyHtml);
                    break;
                case "ToolStripMenuItem_Text":
                    MessageBox.Show(BodyText);
                    break;

                case "toolStripMenuItem_Break":
                    InsertBreak();
                    break;
                case "toolStripMenuItem_html":
                    using (US.InsertHTML insertHtml = new US.InsertHTML(BodyHtml))
                    {
                        insertHtml.ShowDialog(this);
                        if (insertHtml.Accepted)
                        {
                            this.BodyHtml = insertHtml.HTML;
                        }
                    }
                    break;

            }
        }

        private void EditorHTML_Load(object sender, EventArgs e)
        {
            


        }
    }
}
