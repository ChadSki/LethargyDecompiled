//using Lethargy.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
namespace Lethargy
{
    public class LethargyForm : Form
    {
        private IContainer components;
        [AccessedThroughProperty("tv")]
        private TreeView _tagTreeView;
        [AccessedThroughProperty("FileToolStripMenuItem0")]
        private ToolStripMenuItem _FileToolStripMenuItem0;
        [AccessedThroughProperty("ToolStripSeparator1")]
        private ToolStripSeparator _ToolStripSeparator1;
        [AccessedThroughProperty("ExitToolStripMenuItem")]
        private ToolStripMenuItem _ExitToolStripMenuItem;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("Label10")]
        private Label _Label10;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("txtIndexOrder")]
        private TextBox _txtIndexOrder;
        [AccessedThroughProperty("txtTagMetaSize")]
        private TextBox _txtTagMetaSize;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("txtTagName")]
        private TextBox _txtTagName;
        [AccessedThroughProperty("cb3")]
        private ComboBox _cb3;
        [AccessedThroughProperty("cb2")]
        private ComboBox _cb2;
        [AccessedThroughProperty("cb1")]
        private ComboBox _cb1;
        [AccessedThroughProperty("txtMetaOffset")]
        private TextBox _txtMetaOffset;
        [AccessedThroughProperty("txtNameOffset")]
        private TextBox _txtNameOffset;
        [AccessedThroughProperty("txtOffset")]
        private TextBox _txtOffset;
        [AccessedThroughProperty("txtID")]
        private TextBox _txtID;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("txtMetaSize")]
        private TextBox _txtMetaSize;
        [AccessedThroughProperty("txtIndexOffset")]
        private TextBox _txtIndexOffset;
        [AccessedThroughProperty("txtTagCount")]
        private TextBox _txtTagCount;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("txtMagic")]
        private TextBox _txtMagic;
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;
        [AccessedThroughProperty("Label11")]
        private Label _Label11;
        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip _StatusStrip1;
        [AccessedThroughProperty("StatusOld")]
        private ToolStripStatusLabel _StatusOld;
        [AccessedThroughProperty("btnExtract")]
        private Button _btnExtract;
        [AccessedThroughProperty("MapView")]
        private SplitContainer _MapView;
        [AccessedThroughProperty("Tabs")]
        private TabControl _Tabs;
        [AccessedThroughProperty("MetaTab")]
        private TabPage _MetaTab;
        [AccessedThroughProperty("DepsTab")]
        private TabPage _DepsTab;
        [AccessedThroughProperty("dgv")]
        private DataGridView _dgv;
        [AccessedThroughProperty("DepClass")]
        private DataGridViewTextBoxColumn _DepClass;
        [AccessedThroughProperty("DepName")]
        private DataGridViewTextBoxColumn _DepName;
        [AccessedThroughProperty("DepType")]
        private DataGridViewTextBoxColumn _DepType;
        [AccessedThroughProperty("btnSave")]
        private Button _btnSave;
        [AccessedThroughProperty("HelpToolStripMenuItem")]
        private ToolStripMenuItem _HelpToolStripMenuItem;
        [AccessedThroughProperty("AboutToolStripMenuItem")]
        private ToolStripMenuItem _AboutToolStripMenuItem;
        [AccessedThroughProperty("MenuStrip1")]
        private MenuStrip _MenuStrip1;
        [AccessedThroughProperty("FileToolStripMenuItem1")]
        private ToolStripMenuItem _FileToolStripMenuItem1;
        [AccessedThroughProperty("OpenMapToolStripMenuItem")]
        private ToolStripMenuItem _OpenMapToolStripMenuItem;
        [AccessedThroughProperty("Status")]
        private ToolStripStatusLabel _Status;
        [AccessedThroughProperty("ExitToolStripMenuItem1")]
        private ToolStripMenuItem _ExitToolStripMenuItem1;
        [AccessedThroughProperty("HelpToolStripMenuItem1")]
        private ToolStripMenuItem _HelpToolStripMenuItem1;
        [AccessedThroughProperty("AboutToolStripMenuItem1")]
        private ToolStripMenuItem _AboutToolStripMenuItem1;
        [AccessedThroughProperty("cbName")]
        private ComboBox _cbName;
        [AccessedThroughProperty("cbClass")]
        private ComboBox _cbClass;
        [AccessedThroughProperty("btnSwap")]
        private Button _btnSwap;
        [AccessedThroughProperty("ToolStripSeparator2")]
        private ToolStripSeparator _ToolStripSeparator2;
        [AccessedThroughProperty("CloseMapToolStripMenuItem")]
        private ToolStripMenuItem _CloseMapToolStripMenuItem;
        [AccessedThroughProperty("ToolsToolStripMenuItem")]
        private ToolStripMenuItem _ToolsToolStripMenuItem;
        [AccessedThroughProperty("InsertToolStripMenuItem")]
        private ToolStripMenuItem _InsertToolStripMenuItem;
        [AccessedThroughProperty("FindTagByIndexOrderToolStripMenuItem")]
        private ToolStripMenuItem _FindTagByIndexOrderToolStripMenuItem;
        [AccessedThroughProperty("ShowTagsOrderToolStripMenuItem")]
        private ToolStripMenuItem _ShowTagsOrderToolStripMenuItem;
        [AccessedThroughProperty("InsertBlankDataToolStripMenuItem")]
        private ToolStripMenuItem _InsertBlankDataToolStripMenuItem;
        private XMLMain.TAG_STRUCT[] @struct;
        public HaloMap MAP;
        public HaloTag[] TagsCache;
        private Hashtable IDhash;
        private bool userdidit;
        private bool pluginLoaded;

        /// <summary>
        /// The expandable tree of tags. When the tree is replaced
        /// (new map loaded), we attach the selection event handler.
        /// </summary>
        internal virtual TreeView TagTreeView
        {
            get
            {
                return this._tagTreeView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                TreeViewEventHandler value2 = new TreeViewEventHandler(this.tagTree_selectTag);
                if (this._tagTreeView != null)
                {
                    this._tagTreeView.AfterSelect -= value2;
                }

                this._tagTreeView = value;
                if (this._tagTreeView != null)
                {
                    this._tagTreeView.AfterSelect += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem FileToolStripMenuItem0
        {
            get
            {
                return this._FileToolStripMenuItem0;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FileToolStripMenuItem0 = value;
            }

        }
        internal virtual ToolStripSeparator ToolStripSeparator1
        {
            get
            {
                return this._ToolStripSeparator1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator1 = value;
            }

        }
        internal virtual ToolStripMenuItem ExitToolStripMenuItem
        {
            get
            {
                return this._ExitToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.ExitToolStripMenuItem_Click);
                if (this._ExitToolStripMenuItem != null)
                {
                    this._ExitToolStripMenuItem.Click -= value2;
                }

                this._ExitToolStripMenuItem = value;
                if (this._ExitToolStripMenuItem != null)
                {
                    this._ExitToolStripMenuItem.Click += value2;
                }

            }
        }

        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }

        }
        internal virtual Label Label10
        {
            get
            {
                return this._Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label10 = value;
            }

        }
        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label9 = value;
            }

        }
        internal virtual TextBox txtIndexOrder
        {
            get
            {
                return this._txtIndexOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtIndexOrder = value;
            }

        }
        internal virtual TextBox txtTagMetaSize
        {
            get
            {
                return this._txtTagMetaSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtTagMetaSize = value;
            }

        }
        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
            }

        }
        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
            }

        }
        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
            }

        }
        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }

        }
        internal virtual TextBox txtTagName
        {
            get
            {
                return this._txtTagName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtTagName = value;
            }

        }
        internal virtual ComboBox cb3
        {
            get
            {
                return this._cb3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cb3 = value;
            }

        }
        internal virtual ComboBox cb2
        {
            get
            {
                return this._cb2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cb2 = value;
            }

        }
        internal virtual ComboBox cb1
        {
            get
            {
                return this._cb1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cb1 = value;
            }

        }
        internal virtual TextBox txtMetaOffset
        {
            get
            {
                return this._txtMetaOffset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtMetaOffset = value;
            }

        }
        internal virtual TextBox txtNameOffset
        {
            get
            {
                return this._txtNameOffset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtNameOffset = value;
            }

        }
        internal virtual TextBox txtOffset
        {
            get
            {
                return this._txtOffset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtOffset = value;
            }

        }
        internal virtual TextBox txtID
        {
            get
            {
                return this._txtID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtID = value;
            }

        }
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }

        }
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }

        }
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }

        }
        internal virtual TextBox txtMetaSize
        {
            get
            {
                return this._txtMetaSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtMetaSize = value;
            }

        }
        internal virtual TextBox txtIndexOffset
        {
            get
            {
                return this._txtIndexOffset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtIndexOffset = value;
            }

        }
        internal virtual TextBox txtTagCount
        {
            get
            {
                return this._txtTagCount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtTagCount = value;
            }

        }
        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
            }

        }
        internal virtual Label MapLabel_Magic
        {
            get
            {
                return this._Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }

        }
        internal virtual TextBox txtMagic
        {
            get
            {
                return this._txtMagic;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtMagic = value;
            }

        }
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }

        }
        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label11 = value;
            }

        }
        internal virtual StatusStrip StatusStrip1
        {
            get
            {
                return this._StatusStrip1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._StatusStrip1 = value;
            }

        }
        internal virtual ToolStripStatusLabel StatusOld
        {
            get
            {
                return this._StatusOld;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._StatusOld = value;
            }

        }
        internal virtual Button btnExtract
        {
            get
            {
                return this._btnExtract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.btnExtract_Click);
                if (this._btnExtract != null)
                {
                    this._btnExtract.Click -= value2;
                }

                this._btnExtract = value;
                if (this._btnExtract != null)
                {
                    this._btnExtract.Click += value2;
                }

            }
        }

        internal virtual SplitContainer MapView
        {
            get
            {
                return this._MapView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MapView = value;
            }

        }
        internal virtual TabControl Tabs
        {
            get
            {
                return this._Tabs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Tabs = value;
            }

        }
        internal virtual TabPage MetaTab
        {
            get
            {
                return this._MetaTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MetaTab = value;
            }

        }
        internal virtual TabPage DepsTab
        {
            get
            {
                return this._DepsTab;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._DepsTab = value;
            }

        }
        internal virtual DataGridView dgv
        {
            get
            {
                return this._dgv;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DataGridViewCellEventHandler value2 = new DataGridViewCellEventHandler(this.dgv_CellClick);
                DataGridViewCellEventHandler value3 = new DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
                EventHandler value4 = new EventHandler(this.dgv_SelectionChanged);
                if (this._dgv != null)
                {
                    this._dgv.CellClick -= value2;
                    this._dgv.CellDoubleClick -= value3;
                    this._dgv.SelectionChanged -= value4;
                }

                this._dgv = value;
                if (this._dgv != null)
                {
                    this._dgv.CellClick += value2;
                    this._dgv.CellDoubleClick += value3;
                    this._dgv.SelectionChanged += value4;
                }

            }
        }

        internal virtual DataGridViewTextBoxColumn DepClass
        {
            get
            {
                return this._DepClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._DepClass = value;
            }

        }
        internal virtual DataGridViewTextBoxColumn DepName
        {
            get
            {
                return this._DepName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._DepName = value;
            }

        }
        internal virtual DataGridViewTextBoxColumn DepType
        {
            get
            {
                return this._DepType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._DepType = value;
            }

        }
        internal virtual Button btnSave
        {
            get
            {
                return this._btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.btnSave_Click);
                if (this._btnSave != null)
                {
                    this._btnSave.Click -= value2;
                }

                this._btnSave = value;
                if (this._btnSave != null)
                {
                    this._btnSave.Click += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem HelpToolStripMenuItem
        {
            get
            {
                return this._HelpToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._HelpToolStripMenuItem = value;
            }

        }
        internal virtual ToolStripMenuItem AboutToolStripMenuItem
        {
            get
            {
                return this._AboutToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._AboutToolStripMenuItem = value;
            }

        }
        internal virtual MenuStrip MenuStrip1
        {
            get
            {
                return this._MenuStrip1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MenuStrip1 = value;
            }

        }
        internal virtual ToolStripMenuItem FileToolStripMenuItem1
        {
            get
            {
                return this._FileToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FileToolStripMenuItem1 = value;
            }

        }
        internal virtual ToolStripMenuItem OpenMapToolStripMenuItem
        {
            get
            {
                return this._OpenMapToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.OpenMapToolStripMenuItem_Click);
                if (this._OpenMapToolStripMenuItem != null)
                {
                    this._OpenMapToolStripMenuItem.Click -= value2;
                }

                this._OpenMapToolStripMenuItem = value;
                if (this._OpenMapToolStripMenuItem != null)
                {
                    this._OpenMapToolStripMenuItem.Click += value2;
                }

            }
        }

        internal virtual ToolStripStatusLabel Status
        {
            get
            {
                return this._Status;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Status = value;
            }

        }
        internal virtual ToolStripMenuItem ExitToolStripMenuItem1
        {
            get
            {
                return this._ExitToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.ExitToolStripMenuItem1_Click);
                if (this._ExitToolStripMenuItem1 != null)
                {
                    this._ExitToolStripMenuItem1.Click -= value2;
                }

                this._ExitToolStripMenuItem1 = value;
                if (this._ExitToolStripMenuItem1 != null)
                {
                    this._ExitToolStripMenuItem1.Click += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem HelpToolStripMenuItem1
        {
            get
            {
                return this._HelpToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._HelpToolStripMenuItem1 = value;
            }

        }
        internal virtual ToolStripMenuItem AboutToolStripMenuItem1
        {
            get
            {
                return this._AboutToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.AboutToolStripMenuItem1_Click);
                if (this._AboutToolStripMenuItem1 != null)
                {
                    this._AboutToolStripMenuItem1.Click -= value2;
                }

                this._AboutToolStripMenuItem1 = value;
                if (this._AboutToolStripMenuItem1 != null)
                {
                    this._AboutToolStripMenuItem1.Click += value2;
                }

            }
        }

        internal virtual ComboBox cbName
        {
            get
            {
                return this._cbName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cbName = value;
            }

        }
        internal virtual ComboBox cbClass
        {
            get
            {
                return this._cbClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.cbClass_SelectedIndexChanged);
                if (this._cbClass != null)
                {
                    this._cbClass.SelectedIndexChanged -= value2;
                }

                this._cbClass = value;
                if (this._cbClass != null)
                {
                    this._cbClass.SelectedIndexChanged += value2;
                }

            }
        }

        internal virtual Button btnSwap
        {
            get
            {
                return this._btnSwap;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.btnSwap_Click);
                if (this._btnSwap != null)
                {
                    this._btnSwap.Click -= value2;
                }

                this._btnSwap = value;
                if (this._btnSwap != null)
                {
                    this._btnSwap.Click += value2;
                }

            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator2
        {
            get
            {
                return this._ToolStripSeparator2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator2 = value;
            }

        }
        internal virtual ToolStripMenuItem CloseMapToolStripMenuItem
        {
            get
            {
                return this._CloseMapToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.CloseMapToolStripMenuItem_Click);
                if (this._CloseMapToolStripMenuItem != null)
                {
                    this._CloseMapToolStripMenuItem.Click -= value2;
                }

                this._CloseMapToolStripMenuItem = value;
                if (this._CloseMapToolStripMenuItem != null)
                {
                    this._CloseMapToolStripMenuItem.Click += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem ToolsToolStripMenuItem
        {
            get
            {
                return this._ToolsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolsToolStripMenuItem = value;
            }

        }
        internal virtual ToolStripMenuItem InsertToolStripMenuItem
        {
            get
            {
                return this._InsertToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.InsertToolStripMenuItem_Click);
                if (this._InsertToolStripMenuItem != null)
                {
                    this._InsertToolStripMenuItem.Click -= value2;
                }

                this._InsertToolStripMenuItem = value;
                if (this._InsertToolStripMenuItem != null)
                {
                    this._InsertToolStripMenuItem.Click += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem FindTagByIndexOrderToolStripMenuItem
        {
            get
            {
                return this._FindTagByIndexOrderToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.FindTagByIndexOrderToolStripMenuItem_Click);
                if (this._FindTagByIndexOrderToolStripMenuItem != null)
                {
                    this._FindTagByIndexOrderToolStripMenuItem.Click -= value2;
                }

                this._FindTagByIndexOrderToolStripMenuItem = value;
                if (this._FindTagByIndexOrderToolStripMenuItem != null)
                {
                    this._FindTagByIndexOrderToolStripMenuItem.Click += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem ShowTagsOrderToolStripMenuItem
        {
            get
            {
                return this._ShowTagsOrderToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.ShowTagsOrderToolStripMenuItem_Click);
                if (this._ShowTagsOrderToolStripMenuItem != null)
                {
                    this._ShowTagsOrderToolStripMenuItem.Click -= value2;
                }

                this._ShowTagsOrderToolStripMenuItem = value;
                if (this._ShowTagsOrderToolStripMenuItem != null)
                {
                    this._ShowTagsOrderToolStripMenuItem.Click += value2;
                }

            }
        }

        internal virtual ToolStripMenuItem InsertBlankDataToolStripMenuItem
        {
            get
            {
                return this._InsertBlankDataToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.InsertBlankDataToolStripMenuItem_Click);
                if (this._InsertBlankDataToolStripMenuItem != null)
                {
                    this._InsertBlankDataToolStripMenuItem.Click -= value2;
                }

                this._InsertBlankDataToolStripMenuItem = value;
                if (this._InsertBlankDataToolStripMenuItem != null)
                {
                    this._InsertBlankDataToolStripMenuItem.Click += value2;
                }

            }
        }

        public LethargyForm()
        {
            this.MAP = new HaloMap();
            this.IDhash = new Hashtable();
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && this.components != null)
                {
                    this.components.Dispose();
                }

            }
            finally
            {
                base.Dispose(disposing);
            }

        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            this.TagTreeView = new TreeView();
            this.FileToolStripMenuItem0 = new ToolStripMenuItem();
            this.ToolStripSeparator1 = new ToolStripSeparator();
            this.ExitToolStripMenuItem = new ToolStripMenuItem();
            this.GroupBox2 = new GroupBox();
            this.btnSave = new Button();
            this.Label10 = new Label();
            this.Label9 = new Label();
            this.Label7 = new Label();
            this.txtMetaOffset = new TextBox();
            this.txtIndexOrder = new TextBox();
            this.txtTagMetaSize = new TextBox();
            this.Label8 = new Label();
            this.Label6 = new Label();
            this.Label5 = new Label();
            this.txtTagName = new TextBox();
            this.cb3 = new ComboBox();
            this.cb2 = new ComboBox();
            this.cb1 = new ComboBox();
            this.txtNameOffset = new TextBox();
            this.txtOffset = new TextBox();
            this.txtID = new TextBox();
            this.GroupBox1 = new GroupBox();
            this.Label4 = new Label();
            this.Label3 = new Label();
            this.txtMetaSize = new TextBox();
            this.txtIndexOffset = new TextBox();
            this.txtTagCount = new TextBox();
            this.Label2 = new Label();
            this.MapLabel_Magic = new Label();
            this.txtMagic = new TextBox();
            this.GroupBox3 = new GroupBox();
            this.btnExtract = new Button();
            this.Label11 = new Label();
            this.StatusStrip1 = new StatusStrip();
            this.Status = new ToolStripStatusLabel();
            this.StatusOld = new ToolStripStatusLabel();
            this.MapView = new SplitContainer();
            this.Tabs = new TabControl();
            this.MetaTab = new TabPage();
            this.DepsTab = new TabPage();
            this.btnSwap = new Button();
            this.cbName = new ComboBox();
            this.cbClass = new ComboBox();
            this.dgv = new DataGridView();
            this.DepClass = new DataGridViewTextBoxColumn();
            this.DepName = new DataGridViewTextBoxColumn();
            this.DepType = new DataGridViewTextBoxColumn();
            this.HelpToolStripMenuItem = new ToolStripMenuItem();
            this.AboutToolStripMenuItem = new ToolStripMenuItem();
            this.MenuStrip1 = new MenuStrip();
            this.FileToolStripMenuItem1 = new ToolStripMenuItem();
            this.OpenMapToolStripMenuItem = new ToolStripMenuItem();
            this.CloseMapToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator2 = new ToolStripSeparator();
            this.ExitToolStripMenuItem1 = new ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new ToolStripMenuItem();
            this.FindTagByIndexOrderToolStripMenuItem = new ToolStripMenuItem();
            this.ShowTagsOrderToolStripMenuItem = new ToolStripMenuItem();
            this.InsertToolStripMenuItem = new ToolStripMenuItem();
            this.InsertBlankDataToolStripMenuItem = new ToolStripMenuItem();
            this.HelpToolStripMenuItem1 = new ToolStripMenuItem();
            this.AboutToolStripMenuItem1 = new ToolStripMenuItem();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.MapView.Panel1.SuspendLayout();
            this.MapView.Panel2.SuspendLayout();
            this.MapView.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.DepsTab.SuspendLayout();
            ((ISupportInitialize)this.dgv).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            this.TagTreeView.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            Control arg_36E_0 = this.TagTreeView;
            Point location = new Point(3, 25);
            arg_36E_0.Location = location;
            this.TagTreeView.Name = "tv";
            Control arg_39C_0 = this.TagTreeView;
            Size size = new Size(315, 460);
            arg_39C_0.Size = size;
            this.TagTreeView.TabIndex = 0;
            this.FileToolStripMenuItem0.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.ToolStripSeparator1,
                this.ExitToolStripMenuItem
            });
            this.FileToolStripMenuItem0.Name = "FileToolStripMenuItem0";
            ToolStripItem arg_3FE_0 = this.FileToolStripMenuItem0;
            size = new Size(37, 20);
            arg_3FE_0.Size = size;
            this.FileToolStripMenuItem0.Text = "File";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripItem arg_435_0 = this.ToolStripSeparator1;
            size = new Size(89, 6);
            arg_435_0.Size = size;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ToolStripItem arg_45D_0 = this.ExitToolStripMenuItem;
            size = new Size(92, 22);
            arg_45D_0.Size = size;
            this.ExitToolStripMenuItem.Text = "Exit";
            this.GroupBox2.Controls.Add(this.btnSave);
            this.GroupBox2.Controls.Add(this.Label10);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.txtMetaOffset);
            this.GroupBox2.Controls.Add(this.txtIndexOrder);
            this.GroupBox2.Controls.Add(this.txtTagMetaSize);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.txtTagName);
            this.GroupBox2.Controls.Add(this.cb3);
            this.GroupBox2.Controls.Add(this.cb2);
            this.GroupBox2.Controls.Add(this.cb1);
            this.GroupBox2.Controls.Add(this.txtNameOffset);
            this.GroupBox2.Controls.Add(this.txtOffset);
            this.GroupBox2.Controls.Add(this.txtID);
            this.GroupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.GroupBox2.ForeColor = SystemColors.ControlText;
            Control arg_62A_0 = this.GroupBox2;
            location = new Point(12, 160);
            arg_62A_0.Location = location;
            this.GroupBox2.Name = "GroupBox2";
            Control arg_658_0 = this.GroupBox2;
            size = new Size(201, 259);
            arg_658_0.Size = size;
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Tag";
            this.btnSave.Enabled = false;
            Control arg_6A5_0 = this.btnSave;
            location = new Point(6, 225);
            arg_6A5_0.Location = location;
            this.btnSave.Name = "btnSave";
            Control arg_6CD_0 = this.btnSave;
            size = new Size(86, 23);
            arg_6CD_0.Size = size;
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.Label10.BorderStyle = BorderStyle.Fixed3D;
            this.Label10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_738_0 = this.Label10;
            location = new Point(6, 202);
            arg_738_0.Location = location;
            this.Label10.Name = "Label10";
            Control arg_760_0 = this.Label10;
            size = new Size(86, 20);
            arg_760_0.Size = size;
            this.Label10.TabIndex = 21;
            this.Label10.Text = "Meta Size:";
            this.Label10.TextAlign = ContentAlignment.MiddleLeft;
            this.Label9.BorderStyle = BorderStyle.Fixed3D;
            this.Label9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_7CC_0 = this.Label9;
            location = new Point(6, 176);
            arg_7CC_0.Location = location;
            this.Label9.Name = "Label9";
            Control arg_7F4_0 = this.Label9;
            size = new Size(86, 20);
            arg_7F4_0.Size = size;
            this.Label9.TabIndex = 20;
            this.Label9.Text = "Index Order:";
            this.Label9.TextAlign = ContentAlignment.MiddleLeft;
            this.Label7.BackColor = SystemColors.ButtonHighlight;
            this.Label7.BorderStyle = BorderStyle.Fixed3D;
            this.Label7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_86D_0 = this.Label7;
            location = new Point(6, 72);
            arg_86D_0.Location = location;
            this.Label7.Name = "Label7";
            Control arg_895_0 = this.Label7;
            size = new Size(86, 20);
            arg_895_0.Size = size;
            this.Label7.TabIndex = 16;
            this.Label7.Text = "Meta Offset:";
            this.Label7.TextAlign = ContentAlignment.MiddleLeft;
            this.txtMetaOffset.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_8F3_0 = this.txtMetaOffset;
            location = new Point(98, 72);
            arg_8F3_0.Location = location;
            this.txtMetaOffset.Name = "txtMetaOffset";
            Control arg_91B_0 = this.txtMetaOffset;
            size = new Size(94, 20);
            arg_91B_0.Size = size;
            this.txtMetaOffset.TabIndex = 9;
            this.txtIndexOrder.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_95F_0 = this.txtIndexOrder;
            location = new Point(98, 176);
            arg_95F_0.Location = location;
            this.txtIndexOrder.Name = "txtIndexOrder";
            this.txtIndexOrder.ReadOnly = true;
            Control arg_993_0 = this.txtIndexOrder;
            size = new Size(94, 20);
            arg_993_0.Size = size;
            this.txtIndexOrder.TabIndex = 19;
            this.txtTagMetaSize.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_9D7_0 = this.txtTagMetaSize;
            location = new Point(98, 202);
            arg_9D7_0.Location = location;
            this.txtTagMetaSize.Name = "txtTagMetaSize";
            this.txtTagMetaSize.ReadOnly = true;
            Control arg_A0B_0 = this.txtTagMetaSize;
            size = new Size(94, 20);
            arg_A0B_0.Size = size;
            this.txtTagMetaSize.TabIndex = 18;
            this.Label8.BorderStyle = BorderStyle.Fixed3D;
            this.Label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_A5A_0 = this.Label8;
            location = new Point(6, 150);
            arg_A5A_0.Location = location;
            this.Label8.Name = "Label8";
            Control arg_A82_0 = this.Label8;
            size = new Size(86, 20);
            arg_A82_0.Size = size;
            this.Label8.TabIndex = 17;
            this.Label8.Text = "ID (Signed):";
            this.Label8.TextAlign = ContentAlignment.MiddleLeft;
            this.Label6.BorderStyle = BorderStyle.Fixed3D;
            this.Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_AEB_0 = this.Label6;
            location = new Point(6, 98);
            arg_AEB_0.Location = location;
            this.Label6.Name = "Label6";
            Control arg_B13_0 = this.Label6;
            size = new Size(86, 20);
            arg_B13_0.Size = size;
            this.Label6.TabIndex = 15;
            this.Label6.Text = "Offset:";
            this.Label6.TextAlign = ContentAlignment.MiddleLeft;
            this.Label5.BorderStyle = BorderStyle.Fixed3D;
            this.Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_B7C_0 = this.Label5;
            location = new Point(6, 124);
            arg_B7C_0.Location = location;
            this.Label5.Name = "Label5";
            Control arg_BA4_0 = this.Label5;
            size = new Size(86, 20);
            arg_BA4_0.Size = size;
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Name Offset:";
            this.Label5.TextAlign = ContentAlignment.MiddleLeft;
            this.txtTagName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_C02_0 = this.txtTagName;
            location = new Point(9, 19);
            arg_C02_0.Location = location;
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.ReadOnly = true;
            Control arg_C39_0 = this.txtTagName;
            size = new Size(183, 20);
            arg_C39_0.Size = size;
            this.txtTagName.TabIndex = 13;
            this.cb3.BackColor = Color.White;
            this.cb3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cb3.FormattingEnabled = true;
            Control arg_C99_0 = this.cb3;
            location = new Point(135, 45);
            arg_C99_0.Location = location;
            this.cb3.Name = "cb3";
            Control arg_CC1_0 = this.cb3;
            size = new Size(57, 21);
            arg_CC1_0.Size = size;
            this.cb3.Sorted = true;
            this.cb3.TabIndex = 12;
            this.cb2.BackColor = Color.White;
            this.cb2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cb2.FormattingEnabled = true;
            Control arg_D2A_0 = this.cb2;
            location = new Point(72, 45);
            arg_D2A_0.Location = location;
            this.cb2.Name = "cb2";
            Control arg_D52_0 = this.cb2;
            size = new Size(57, 21);
            arg_D52_0.Size = size;
            this.cb2.Sorted = true;
            this.cb2.TabIndex = 11;
            this.cb1.BackColor = Color.White;
            this.cb1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cb1.FormattingEnabled = true;
            Control arg_DBB_0 = this.cb1;
            location = new Point(9, 45);
            arg_DBB_0.Location = location;
            this.cb1.Name = "cb1";
            Control arg_DE3_0 = this.cb1;
            size = new Size(57, 21);
            arg_DE3_0.Size = size;
            this.cb1.Sorted = true;
            this.cb1.TabIndex = 10;
            this.txtNameOffset.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_E30_0 = this.txtNameOffset;
            location = new Point(98, 124);
            arg_E30_0.Location = location;
            this.txtNameOffset.Name = "txtNameOffset";
            this.txtNameOffset.ReadOnly = true;
            Control arg_E64_0 = this.txtNameOffset;
            size = new Size(94, 20);
            arg_E64_0.Size = size;
            this.txtNameOffset.TabIndex = 8;
            this.txtOffset.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_EA4_0 = this.txtOffset;
            location = new Point(98, 98);
            arg_EA4_0.Location = location;
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            Control arg_ED8_0 = this.txtOffset;
            size = new Size(94, 20);
            arg_ED8_0.Size = size;
            this.txtOffset.TabIndex = 7;
            this.txtID.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_F1B_0 = this.txtID;
            location = new Point(98, 150);
            arg_F1B_0.Location = location;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            Control arg_F4F_0 = this.txtID;
            size = new Size(94, 20);
            arg_F4F_0.Size = size;
            this.txtID.TabIndex = 6;
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtMetaSize);
            this.GroupBox1.Controls.Add(this.txtIndexOffset);
            this.GroupBox1.Controls.Add(this.txtTagCount);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.MapLabel_Magic);
            this.GroupBox1.Controls.Add(this.txtMagic);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.GroupBox1.ForeColor = SystemColors.ControlText;
            Control arg_104F_0 = this.GroupBox1;
            location = new Point(12, 27);
            arg_104F_0.Location = location;
            this.GroupBox1.Name = "GroupBox1";
            Control arg_107A_0 = this.GroupBox1;
            size = new Size(201, 127);
            arg_107A_0.Size = size;
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Map";
            this.Label4.BorderStyle = BorderStyle.Fixed3D;
            this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_10E1_0 = this.Label4;
            location = new Point(6, 94);
            arg_10E1_0.Location = location;
            this.Label4.Name = "Label4";
            Control arg_1109_0 = this.Label4;
            size = new Size(89, 20);
            arg_1109_0.Size = size;
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Meta Size:";
            this.Label4.TextAlign = ContentAlignment.MiddleLeft;
            this.Label3.BorderStyle = BorderStyle.Fixed3D;
            this.Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_1171_0 = this.Label3;
            location = new Point(6, 68);
            arg_1171_0.Location = location;
            this.Label3.Name = "Label3";
            Control arg_1199_0 = this.Label3;
            size = new Size(89, 20);
            arg_1199_0.Size = size;
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Index Offset:";
            this.Label3.TextAlign = ContentAlignment.MiddleLeft;
            this.txtMetaSize.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_11F6_0 = this.txtMetaSize;
            location = new Point(101, 94);
            arg_11F6_0.Location = location;
            this.txtMetaSize.Name = "txtMetaSize";
            this.txtMetaSize.ReadOnly = true;
            Control arg_122A_0 = this.txtMetaSize;
            size = new Size(94, 20);
            arg_122A_0.Size = size;
            this.txtMetaSize.TabIndex = 5;
            this.txtIndexOffset.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_126A_0 = this.txtIndexOffset;
            location = new Point(101, 68);
            arg_126A_0.Location = location;
            this.txtIndexOffset.Name = "txtIndexOffset";
            this.txtIndexOffset.ReadOnly = true;
            Control arg_129E_0 = this.txtIndexOffset;
            size = new Size(94, 20);
            arg_129E_0.Size = size;
            this.txtIndexOffset.TabIndex = 4;
            this.txtTagCount.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_12DE_0 = this.txtTagCount;
            location = new Point(101, 42);
            arg_12DE_0.Location = location;
            this.txtTagCount.Name = "txtTagCount";
            this.txtTagCount.ReadOnly = true;
            Control arg_1312_0 = this.txtTagCount;
            size = new Size(94, 20);
            arg_1312_0.Size = size;
            this.txtTagCount.TabIndex = 3;
            this.Label2.BorderStyle = BorderStyle.Fixed3D;
            this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Control arg_135D_0 = this.Label2;
            location = new Point(6, 42);
            arg_135D_0.Location = location;
            this.Label2.Name = "Label2";
            Control arg_1385_0 = this.Label2;
            size = new Size(89, 20);
            arg_1385_0.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Tag Count:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;
            //
            this.MapLabel_Magic.BorderStyle = BorderStyle.Fixed3D;
            this.MapLabel_Magic.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.MapLabel_Magic.Location = new Point(6, 16);
            this.MapLabel_Magic.Name = "Label1";
            this.MapLabel_Magic.Size = new Size(89, 20);
            this.MapLabel_Magic.TabIndex = 1;
            this.MapLabel_Magic.Text = "Magic:";
            this.MapLabel_Magic.TextAlign = ContentAlignment.MiddleLeft;
            //
            this.txtMagic.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtMagic.Location = new Point(101, 16);
            this.txtMagic.Name = "txtMagic";
            this.txtMagic.ReadOnly = true;
            this.txtMagic.Size = new Size(94, 20);
            this.txtMagic.TabIndex = 0;
            //
            this.GroupBox3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            this.GroupBox3.Controls.Add(this.btnExtract);
            Control arg_14EE_0 = this.GroupBox3;
            location = new Point(12, 425);
            arg_14EE_0.Location = location;
            this.GroupBox3.Name = "GroupBox3";
            Control arg_1519_0 = this.GroupBox3;
            size = new Size(201, 94);
            arg_1519_0.Size = size;
            this.GroupBox3.TabIndex = 6;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Actions";
            this.btnExtract.Enabled = false;
            Control arg_1564_0 = this.btnExtract;
            location = new Point(9, 31);
            arg_1564_0.Location = location;
            this.btnExtract.Name = "btnExtract";
            Control arg_158C_0 = this.btnExtract;
            size = new Size(83, 23);
            arg_158C_0.Size = size;
            this.btnExtract.TabIndex = 0;
            this.btnExtract.Text = "Extract Tag";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.Label11.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.Label11.BackColor = SystemColors.ButtonHighlight;
            this.Label11.BorderStyle = BorderStyle.Fixed3D;
            Control arg_15F2_0 = this.Label11;
            location = new Point(3, 3);
            arg_15F2_0.Location = location;
            this.Label11.Name = "Label11";
            Control arg_161D_0 = this.Label11;
            size = new Size(315, 19);
            arg_161D_0.Size = size;
            this.Label11.TabIndex = 7;
            this.Label11.Text = "Tag Viewer";
            this.Label11.TextAlign = ContentAlignment.MiddleCenter;
            this.StatusStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.Status
            });
            Control arg_1683_0 = this.StatusStrip1;
            location = new Point(0, 522);
            arg_1683_0.Location = location;
            this.StatusStrip1.Name = "StatusStrip1";
            Control arg_16AE_0 = this.StatusStrip1;
            size = new Size(949, 22);
            arg_16AE_0.Size = size;
            this.StatusStrip1.TabIndex = 8;
            this.StatusStrip1.Text = "StatusStrip1";
            this.Status.Name = "Status";
            ToolStripItem arg_16F2_0 = this.Status;
            size = new Size(61, 17);
            arg_16F2_0.Size = size;
            this.Status.Text = "Patrick H. ";
            this.StatusOld.Name = "StatusOld";
            ToolStripItem arg_172A_0 = this.StatusOld;
            size = new Size(74, 17);
            arg_172A_0.Size = size;
            this.StatusOld.Text = "By Patrick H.";
            this.MapView.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.MapView.BorderStyle = BorderStyle.Fixed3D;
            Control arg_176D_0 = this.MapView;
            location = new Point(219, 27);
            arg_176D_0.Location = location;
            this.MapView.Name = "MapView";
            this.MapView.Panel1.Controls.Add(this.TagTreeView);
            this.MapView.Panel1.Controls.Add(this.Label11);
            this.MapView.Panel2.Controls.Add(this.Tabs);
            Control arg_17EC_0 = this.MapView;
            size = new Size(718, 492);
            arg_17EC_0.Size = size;
            this.MapView.SplitterDistance = 325;
            this.MapView.TabIndex = 9;
            this.Tabs.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.Tabs.Controls.Add(this.MetaTab);
            this.Tabs.Controls.Add(this.DepsTab);
            Control arg_1857_0 = this.Tabs;
            location = new Point(3, 3);
            arg_1857_0.Location = location;
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            Control arg_1891_0 = this.Tabs;
            size = new Size(379, 482);
            arg_1891_0.Size = size;
            this.Tabs.TabIndex = 0;
            this.MetaTab.AutoScroll = true;
            this.MetaTab.BackColor = SystemColors.Control;
            this.MetaTab.BorderStyle = BorderStyle.Fixed3D;
            TabPage arg_18DB_0 = this.MetaTab;
            location = new Point(4, 22);
            arg_18DB_0.Location = location;
            this.MetaTab.Name = "MetaTab";
            Control arg_1900_0 = this.MetaTab;
            Padding padding = new Padding(3);
            arg_1900_0.Padding = padding;
            Control arg_191E_0 = this.MetaTab;
            size = new Size(371, 456);
            arg_191E_0.Size = size;
            this.MetaTab.TabIndex = 0;
            this.MetaTab.Text = "Meta Data";
            this.DepsTab.BorderStyle = BorderStyle.Fixed3D;
            this.DepsTab.Controls.Add(this.btnSwap);
            this.DepsTab.Controls.Add(this.cbName);
            this.DepsTab.Controls.Add(this.cbClass);
            this.DepsTab.Controls.Add(this.dgv);
            TabPage arg_19B4_0 = this.DepsTab;
            location = new Point(4, 22);
            arg_19B4_0.Location = location;
            this.DepsTab.Name = "DepsTab";
            Control arg_19D9_0 = this.DepsTab;
            padding = new Padding(3);
            arg_19D9_0.Padding = padding;
            Control arg_19F7_0 = this.DepsTab;
            size = new Size(371, 456);
            arg_19F7_0.Size = size;
            this.DepsTab.TabIndex = 1;
            this.DepsTab.Text = "Dependencies";
            this.DepsTab.UseVisualStyleBackColor = true;
            this.btnSwap.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.btnSwap.Enabled = false;
            this.btnSwap.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Control arg_1A72_0 = this.btnSwap;
            location = new Point(348, 425);
            arg_1A72_0.Location = location;
            this.btnSwap.Name = "btnSwap";
            Control arg_1A9A_0 = this.btnSwap;
            size = new Size(18, 21);
            arg_1A9A_0.Size = size;
            this.btnSwap.TabIndex = 3;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.cbName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.cbName.FormattingEnabled = true;
            Control arg_1AF5_0 = this.cbName;
            location = new Point(72, 425);
            arg_1AF5_0.Location = location;
            this.cbName.Name = "cbName";
            Control arg_1B20_0 = this.cbName;
            size = new Size(270, 21);
            arg_1B20_0.Size = size;
            this.cbName.TabIndex = 2;
            this.cbClass.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.cbClass.FormattingEnabled = true;
            Control arg_1B5D_0 = this.cbClass;
            location = new Point(6, 425);
            arg_1B5D_0.Location = location;
            this.cbClass.Name = "cbClass";
            Control arg_1B85_0 = this.cbClass;
            size = new Size(60, 21);
            arg_1B85_0.Size = size;
            this.cbClass.Sorted = true;
            this.cbClass.TabIndex = 1;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle.BackColor = SystemColors.Control;
            dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            this.dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new DataGridViewColumn[]
            {
                this.DepClass,
                this.DepName,
                this.DepType
            });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            Control arg_1D0E_0 = this.dgv;
            location = new Point(-2, 1);
            arg_1D0E_0.Location = location;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.ScrollBars = ScrollBars.Vertical;
            this.dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Control arg_1DD7_0 = this.dgv;
            size = new Size(368, 422);
            arg_1DD7_0.Size = size;
            this.dgv.TabIndex = 0;
            this.DepClass.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.DepClass.FillWeight = 10f;
            this.DepClass.Frozen = true;
            this.DepClass.HeaderText = "Class";
            this.DepClass.MinimumWidth = 45;
            this.DepClass.Name = "DepClass";
            this.DepClass.ReadOnly = true;
            this.DepClass.Resizable = DataGridViewTriState.False;
            this.DepClass.ToolTipText = "Primary Tag Class";
            this.DepClass.Width = 45;
            this.DepName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.DepName.FillWeight = 90f;
            this.DepName.HeaderText = "Tag Name";
            this.DepName.Name = "DepName";
            this.DepName.ReadOnly = true;
            this.DepName.ToolTipText = "Name of the tag referenced";
            this.DepType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.DepType.HeaderText = "Type";
            this.DepType.MinimumWidth = 40;
            this.DepType.Name = "DepType";
            this.DepType.ReadOnly = true;
            this.DepType.Width = 40;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            ToolStripItem arg_1F40_0 = this.HelpToolStripMenuItem;
            size = new Size(44, 20);
            arg_1F40_0.Size = size;
            this.HelpToolStripMenuItem.Text = "Help";
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            ToolStripItem arg_1F7B_0 = this.AboutToolStripMenuItem;
            size = new Size(152, 22);
            arg_1F7B_0.Size = size;
            this.MenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.FileToolStripMenuItem1,
                this.ToolsToolStripMenuItem,
                this.HelpToolStripMenuItem1
            });
            Control arg_1FC8_0 = this.MenuStrip1;
            location = new Point(0, 0);
            arg_1FC8_0.Location = location;
            this.MenuStrip1.Name = "MenuStrip1";
            Control arg_1FF3_0 = this.MenuStrip1;
            size = new Size(949, 24);
            arg_1FF3_0.Size = size;
            this.MenuStrip1.TabIndex = 10;
            this.MenuStrip1.Text = "MenuStrip1";
            this.FileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.OpenMapToolStripMenuItem,
                this.CloseMapToolStripMenuItem,
                this.ToolStripSeparator2,
                this.ExitToolStripMenuItem1
            });
            this.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1";
            ToolStripItem arg_207A_0 = this.FileToolStripMenuItem1;
            size = new Size(37, 20);
            arg_207A_0.Size = size;
            this.FileToolStripMenuItem1.Text = "File";
            this.OpenMapToolStripMenuItem.Name = "OpenMapToolStripMenuItem";
            this.OpenMapToolStripMenuItem.ShortcutKeys = (Keys)131151;
            ToolStripItem arg_20C5_0 = this.OpenMapToolStripMenuItem;
            size = new Size(182, 22);
            arg_20C5_0.Size = size;
            this.OpenMapToolStripMenuItem.Text = "Open map...";
            this.CloseMapToolStripMenuItem.Name = "CloseMapToolStripMenuItem";
            ToolStripItem arg_2100_0 = this.CloseMapToolStripMenuItem;
            size = new Size(182, 22);
            arg_2100_0.Size = size;
            this.CloseMapToolStripMenuItem.Text = "Close map";
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripItem arg_213A_0 = this.ToolStripSeparator2;
            size = new Size(179, 6);
            arg_213A_0.Size = size;
            this.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1";
            ToolStripItem arg_2165_0 = this.ExitToolStripMenuItem1;
            size = new Size(182, 22);
            arg_2165_0.Size = size;
            this.ExitToolStripMenuItem1.Text = "Exit";
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.ShowTagsOrderToolStripMenuItem,
                this.FindTagByIndexOrderToolStripMenuItem,
                this.InsertToolStripMenuItem,
                this.InsertBlankDataToolStripMenuItem
            });
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            ToolStripItem arg_21DF_0 = this.ToolsToolStripMenuItem;
            size = new Size(61, 20);
            arg_21DF_0.Size = size;
            this.ToolsToolStripMenuItem.Text = "Options";
            this.FindTagByIndexOrderToolStripMenuItem.Enabled = false;
            this.FindTagByIndexOrderToolStripMenuItem.Name = "FindTagByIndexOrderToolStripMenuItem";
            ToolStripItem arg_2226_0 = this.FindTagByIndexOrderToolStripMenuItem;
            size = new Size(195, 22);
            arg_2226_0.Size = size;
            this.FindTagByIndexOrderToolStripMenuItem.Text = "Find tag by index order";
            this.ShowTagsOrderToolStripMenuItem.Enabled = false;
            this.ShowTagsOrderToolStripMenuItem.Name = "ShowTagsOrderToolStripMenuItem";
            ToolStripItem arg_226D_0 = this.ShowTagsOrderToolStripMenuItem;
            size = new Size(195, 22);
            arg_226D_0.Size = size;
            this.ShowTagsOrderToolStripMenuItem.Text = "Show tags order";
            this.InsertToolStripMenuItem.Enabled = false;
            this.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem";
            ToolStripItem arg_22B4_0 = this.InsertToolStripMenuItem;
            size = new Size(195, 22);
            arg_22B4_0.Size = size;
            this.InsertToolStripMenuItem.Text = "Import tag";
            this.InsertBlankDataToolStripMenuItem.Enabled = false;
            this.InsertBlankDataToolStripMenuItem.Name = "InsertBlankDataToolStripMenuItem";
            ToolStripItem arg_22FB_0 = this.InsertBlankDataToolStripMenuItem;
            size = new Size(195, 22);
            arg_22FB_0.Size = size;
            this.InsertBlankDataToolStripMenuItem.Text = "Insert blank data";
            this.HelpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.AboutToolStripMenuItem1
            });
            this.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
            ToolStripItem arg_2357_0 = this.HelpToolStripMenuItem1;
            size = new Size(44, 20);
            arg_2357_0.Size = size;
            this.HelpToolStripMenuItem1.Text = "Help";
            this.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1";
            this.AboutToolStripMenuItem1.ShortcutKeys = Keys.F1;
            ToolStripItem arg_239C_0 = this.AboutToolStripMenuItem1;
            size = new Size(126, 22);
            arg_239C_0.Size = size;
            this.AboutToolStripMenuItem1.Text = "About";
            SizeF autoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleDimensions = autoScaleDimensions;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(949, 544);
            this.ClientSize = size;
            this.Controls.Add(this.MapView);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Form1";
            this.Text = "Lethargy";
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.MapView.Panel1.ResumeLayout(false);
            this.MapView.Panel2.ResumeLayout(false);
            this.MapView.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.DepsTab.ResumeLayout(false);
            ((ISupportInitialize)this.dgv).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ReadMAPHeaders()
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
            binaryReader.BaseStream.Position = 0L;
            string left = new string(binaryReader.ReadChars(4));
            if (left.Equals("daeh"))
            {
                binaryReader.BaseStream.Position = 4L;
                int num = binaryReader.ReadInt32();
                bool flag = true;
                if (flag == (num == 7))
                {
                    this.MAP.GameVersion = "[PC]";
                }

                else
                {
                    if (flag == (num == 609))
                    {
                        this.MAP.GameVersion = "[CE]";
                    }

                }
                binaryReader.BaseStream.Position = 16L;
                this.MAP.IndexOffset = binaryReader.ReadInt32();
                binaryReader.BaseStream.Position = 20L;
                this.MAP.TotalMetaSize = binaryReader.ReadInt32();
                int num2 = 0;
                while (true)
                {
                    binaryReader.BaseStream.Position = (long)checked(32 + num2);
                    if (binaryReader.ReadInt32() == 0)
                    {
                        break;
                    }

                    checked
                    {
                        num2++;
                        if (num2 > 31)
                        {
                            break;
                        }

                    }
                }

                binaryReader.BaseStream.Position = 32L;
                string text = new string(binaryReader.ReadChars(num2));
                bool flag2 = true;
                if (flag2 == (text.Equals("a10")))
                {
                    this.MAP.Name = "The Pillar of Autumn";
                }

                else
                {
                    if (flag2 == (text.Equals("a30")))
                    {
                        this.MAP.Name = "Halo";
                    }

                    else
                    {
                        if (flag2 == (text.Equals("a50")))
                        {
                            this.MAP.Name = "Truth and Reconciliation";
                        }

                        else
                        {
                            if (flag2 == (text.Equals("b30")))
                            {
                                this.MAP.Name = "The Silent Cartographer";
                            }

                            else
                            {
                                if (flag2 == (text.Equals("b40")))
                                {
                                    this.MAP.Name = "Assault on the Control Room";
                                }

                                else
                                {
                                    if (flag2 == (text.Equals("c10")))
                                    {
                                        this.MAP.Name = "343 Guilty Spark";
                                    }

                                    else
                                    {
                                        if (flag2 == (text.Equals("c20")))
                                        {
                                            this.MAP.Name = "The Library";
                                        }

                                        else
                                        {
                                            if (flag2 == (text.Equals("c40")))
                                            {
                                                this.MAP.Name = "Two Betrayals";
                                            }

                                            else
                                            {
                                                if (flag2 == (text.Equals("d20")))
                                                {
                                                    this.MAP.Name = "Keyes";
                                                }

                                                else
                                                {
                                                    if (flag2 == (text.Equals("d40")))
                                                    {
                                                        this.MAP.Name = "The Maw";
                                                    }

                                                    else
                                                    {
                                                        if (flag2 == (text.Equals("beavercreek")))
                                                        {
                                                            this.MAP.Name = "Battle Creek";
                                                        }

                                                        else
                                                        {
                                                            if (flag2 == (text.Equals("bloodgulch")))
                                                            {
                                                                this.MAP.Name = "Blood Gulch";
                                                            }

                                                            else
                                                            {
                                                                if (flag2 == (text.Equals("carousel")))
                                                                {
                                                                    this.MAP.Name = "Derelict";
                                                                }

                                                                else
                                                                {
                                                                    if (flag2 == (text.Equals("prisoner")))
                                                                    {
                                                                        this.MAP.Name = "Prisoner";
                                                                    }

                                                                    else
                                                                    {
                                                                        if (flag2 == (text.Equals("hangemhigh")))
                                                                        {
                                                                            this.MAP.Name = "Hang 'Em High";
                                                                        }

                                                                        else
                                                                        {
                                                                            if (flag2 == (text.Equals("dangercanyon")))
                                                                            {
                                                                                this.MAP.Name = "Danger Canyon";
                                                                            }

                                                                            else
                                                                            {
                                                                                if (flag2 == (text.Equals("putput")))
                                                                                {
                                                                                    this.MAP.Name = "Chiron TL34";
                                                                                }

                                                                                else
                                                                                {
                                                                                    if (flag2 == (text.Equals("deathisland")))
                                                                                    {
                                                                                        this.MAP.Name = "Death Island";
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        if (flag2 == (text.Equals("boardingaction")))
                                                                                        {
                                                                                            this.MAP.Name = "Boarding Action";
                                                                                        }

                                                                                        else
                                                                                        {
                                                                                            if (flag2 == (text.Equals("chillout")))
                                                                                            {
                                                                                                this.MAP.Name = "Chill Out";
                                                                                            }

                                                                                            else
                                                                                            {
                                                                                                if (flag2 == (text.Equals("damnation")))
                                                                                                {
                                                                                                    this.MAP.Name = "Damnation";
                                                                                                }

                                                                                                else
                                                                                                {
                                                                                                    if (flag2 == (text.Equals("gephyrophobia")))
                                                                                                    {
                                                                                                        this.MAP.Name = "Gephyrophobia";
                                                                                                    }

                                                                                                    else
                                                                                                    {
                                                                                                        if (flag2 == (text.Equals("icefields")))
                                                                                                        {
                                                                                                            this.MAP.Name = "Icefields";
                                                                                                        }

                                                                                                        else
                                                                                                        {
                                                                                                            if (flag2 == (text.Equals("infinity")))
                                                                                                            {
                                                                                                                this.MAP.Name = "Infinity";
                                                                                                            }

                                                                                                            else
                                                                                                            {
                                                                                                                if (flag2 == (text.Equals("longest")))
                                                                                                                {
                                                                                                                    this.MAP.Name = "Longest";
                                                                                                                }

                                                                                                                else
                                                                                                                {
                                                                                                                    if (flag2 == (text.Equals("ratrace")))
                                                                                                                    {
                                                                                                                        this.MAP.Name = "Rat Race";
                                                                                                                    }

                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (flag2 == (text.Equals("sidewinder")))
                                                                                                                        {
                                                                                                                            this.MAP.Name = "Sidewinder";
                                                                                                                        }

                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (flag2 == (text.Equals("timberland")))
                                                                                                                            {
                                                                                                                                this.MAP.Name = "Timberland";
                                                                                                                            }

                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (flag2 == (text.Equals("wizard")))
                                                                                                                                {
                                                                                                                                    this.MAP.Name = "Wizard";
                                                                                                                                }

                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (flag2 == (text.Equals("ui")))
                                                                                                                                    {
                                                                                                                                        this.MAP.Name = "User Interface";
                                                                                                                                    }

                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        this.MAP.Name = text;
                                                                                                                                    }

                                                                                                                                }
                                                                                                                            }

                                                                                                                        }
                                                                                                                    }

                                                                                                                }
                                                                                                            }

                                                                                                        }
                                                                                                    }

                                                                                                }
                                                                                            }

                                                                                        }
                                                                                    }

                                                                                }
                                                                            }

                                                                        }
                                                                    }

                                                                }
                                                            }

                                                        }
                                                    }

                                                }
                                            }

                                        }
                                    }

                                }
                            }

                        }
                    }

                }
                binaryReader.BaseStream.Position = 96L;
                short num3 = binaryReader.ReadInt16();
                bool flag3 = true;
                if (flag3 == (num3 == 0))
                {
                    this.MAP.PlayerType = "(SP)";
                }

                else
                {
                    if (flag3 == (num3 == 1))
                    {
                        this.MAP.PlayerType = "(MP)";
                    }

                    else
                    {
                        if (flag3 == (num3 == 2))
                        {
                            this.MAP.PlayerType = "(UI)";
                        }

                    }
                }

                binaryReader.BaseStream.Position = (long)checked(this.MAP.IndexOffset + 0);
                int magic = binaryReader.ReadInt32();
                binaryReader.BaseStream.Position = (long)checked(this.MAP.IndexOffset + 12);
                this.MAP.TagCount = binaryReader.ReadInt32();
                this.TagsCache = new HaloTag[checked(this.MAP.TagCount - 1 + 1)];
                this.MAP.Magic = magic;
            }

            else
            {
                if (left.Equals("dehE"))
                {
                    //Interaction.MsgBox("Buy the full version, it's only $20!!!", MsgBoxStyle.OkOnly, null);
                }

                else
                {
                    //Interaction.MsgBox("Invalid map file", MsgBoxStyle.OkOnly, null);
                }

            }
            binaryReader.Close();
        }

        public string ReverseString(string source)
        {
            char[] array = source.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private void ReadMAPTags()
        {
            this.TagTreeView.Sorted = true;
            this.TagTreeView.BeginUpdate();
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
            checked
            {
                int num = this.MAP.IndexOffset + 40;
                int num2 = 0;
                HaloMap mAP = this.MAP;
                mAP.Magic -= num;
                this.txtMagic.Text = Conversions.ToString(this.MAP.Magic);
                this.txtIndexOffset.Text = Conversions.ToString(this.MAP.IndexOffset);
                this.txtMetaSize.Text = Conversions.ToString(this.MAP.TotalMetaSize);
                this.txtTagCount.Text = Conversions.ToString(this.MAP.TagCount);
                this.TagTreeView.Nodes.Clear();
                this.IDhash.Clear();
                int num3 = 0;
                int arg_F1_0 = 0;
                int num4 = this.MAP.TagCount - 1;
                for (int i = arg_F1_0; i <= num4; i++)
                {
                    string text;
                    string text2;
                    string text3;
                    int num5;
                    int num6;
                    int num7;
                    int num8;
                    string text4;
                    byte b;
                    unchecked
                    {
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32);
                        text = new string(binaryReader.ReadChars(4));
                        text = this.ReverseString(text);
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32 + 4);
                        text2 = new string(binaryReader.ReadChars(4));
                        text2 = this.ReverseString(text2);
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32 + 8);
                        text3 = new string(binaryReader.ReadChars(4));
                        text3 = this.ReverseString(text3);
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32 + 12);
                        num5 = binaryReader.ReadInt32();
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32 + 16);
                        num6 = checked(binaryReader.ReadInt32() - this.MAP.Magic);
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32 + 20);
                        num7 = checked(binaryReader.ReadInt32() - this.MAP.Magic);
                        binaryReader.BaseStream.Position = (long)checked(num + i * 32 + 24);
                        num8 = binaryReader.ReadInt32();
                        text4 = "";
                        if (num6 < 0)
                        {
                            break;
                        }

                        binaryReader.BaseStream.Position = (long)num6;
                        b = binaryReader.ReadByte();
                    }

                    binaryReader.BaseStream.Position = binaryReader.BaseStream.Position - 1L;
                    while (b != 0)
                    {
                        text4 += new string(binaryReader.ReadChars(1));
                        b = binaryReader.ReadByte();
                        binaryReader.BaseStream.Position = binaryReader.BaseStream.Position - 1L;
                    }

                    string text5 = text4;
                    text = text.Replace("�", "ÿ");
                    text2 = text2.Replace("�", "ÿ");
                    text3 = text3.Replace("�", "ÿ");
                    if (!this.TagTreeView.Nodes.ContainsKey(text))
                    {
                        this.TagTreeView.Nodes.Add(text, "[" + text + "]");
                        this.cb1.Items.Add(text);
                        this.cbClass.Items.Add(text);
                    }

                    if (!this.cb2.Items.Contains(text2))
                    {
                        this.cb2.Items.Add(text2);
                    }

                    if (!this.cb3.Items.Contains(text3))
                    {
                        this.cb3.Items.Add(text3);
                    }

                    string key = text + "-" + text5;
                    this.TagTreeView.Nodes[text].Nodes.Add(key, text5);
                    this.TagTreeView.Nodes[text].Nodes[key].Tag = i;
                    if (num8 == 1)
                    {
                        this.TagTreeView.Nodes[text].Nodes[key].ForeColor = Color.Gray;
                    }

                    this.IDhash.Add(num5, i);
                    int metaSize = 0;
                    if (i == this.MAP.TagCount - 1)
                    {
                        metaSize = this.MAP.TotalMetaSize - num7;
                        this.TagsCache[i - 1].MetaSize = metaSize;
                    }

                    else
                    {
                        if (i != 0)
                        {
                            metaSize = num7 - num2;
                            this.TagsCache[i - 1].MetaSize = metaSize;
                        }

                    }
                    num2 = num7;
                    this.TagsCache[i] = new HaloTag(num5, num7, metaSize, text, text2, text3, text5, num6, num + i * 32, i);
                    if (text.Equals("sbsp"))
                    {
                        this.ReadBSP(num3, i);
                        num3++;
                    }

                }
                this.AddItemsCount();
                binaryReader.Close();
                this.TagTreeView.EndUpdate();
            }

        }
        public void ReadBSP(int number, int index)
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
            binaryReader.BaseStream.Position = (long)checked(this.TagsCache[0].MetaOffset + 1444);
            int num = binaryReader.ReadInt32();
            int num2 = checked(binaryReader.ReadInt32() - this.MAP.Magic);
            binaryReader.BaseStream.Position = (long)checked(num2 + number * 32);
            int metaOffset = binaryReader.ReadInt32();
            int metaSize = binaryReader.ReadInt32();
            int num3 = binaryReader.ReadInt32();
            this.TagsCache[index].MetaOffset = metaOffset;
            this.TagsCache[index].MetaSize = metaSize;
        }

        public void AddItemsCount()
        {
            int arg_10_0 = 0;
            checked
            {
                int num = this.TagTreeView.GetNodeCount(false) - 1;
                for (int i = arg_10_0; i <= num; i++)
                {
                    string text;
                    if (this.TagTreeView.Nodes[i].GetNodeCount(false) == 1)
                    {
                        text = " Item)";
                    }

                    else
                    {
                        text = " Items)";
                    }

                    bool flag = true;
                    string text2;
                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("actr")))
                    {
                        text2 = "Actor";
                    }

                    else
                    {
                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("actv")))
                        {
                            text2 = "Actor Variant";
                        }

                        else
                        {
                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("bitm")))
                            {
                                text2 = "Bitmaps";
                            }

                            else
                            {
                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("bipd")))
                                {
                                    text2 = "Biped";
                                }

                                else
                                {
                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("weap")))
                                    {
                                        text2 = "Weapon";
                                    }

                                    else
                                    {
                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("vehi")))
                                        {
                                            text2 = "Vehicle";
                                        }

                                        else
                                        {
                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("scen")))
                                            {
                                                text2 = "Scenery";
                                            }

                                            else
                                            {
                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("scnr")))
                                                {
                                                    text2 = "Scenario";
                                                }

                                                else
                                                {
                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("sbsp")))
                                                    {
                                                        text2 = "Structure BSP";
                                                    }

                                                    else
                                                    {
                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("effe")))
                                                        {
                                                            text2 = "Effect";
                                                        }

                                                        else
                                                        {
                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("glw!")))
                                                            {
                                                                text2 = "Glow";
                                                            }

                                                            else
                                                            {
                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("elec")))
                                                                {
                                                                    text2 = "Lightning";
                                                                }

                                                                else
                                                                {
                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("coll")))
                                                                    {
                                                                        text2 = "Collision Model";
                                                                    }

                                                                    else
                                                                    {
                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("antr")))
                                                                        {
                                                                            text2 = "Animation Trigger";
                                                                        }

                                                                        else
                                                                        {
                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("ant!")))
                                                                            {
                                                                                text2 = "Antenna";
                                                                            }

                                                                            else
                                                                            {
                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("colo")))
                                                                                {
                                                                                    text2 = "Color Table";
                                                                                }

                                                                                else
                                                                                {
                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("cont")))
                                                                                    {
                                                                                        text2 = "Contrail";
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("deca")))
                                                                                        {
                                                                                            text2 = "Decal";
                                                                                        }

                                                                                        else
                                                                                        {
                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("ant!")))
                                                                                            {
                                                                                                text2 = "Antenna";
                                                                                            }

                                                                                            else
                                                                                            {
                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("DeLa")))
                                                                                                {
                                                                                                    text2 = "UI Widget Definition";
                                                                                                }

                                                                                                else
                                                                                                {
                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("eqip")))
                                                                                                    {
                                                                                                        text2 = "Equipment";
                                                                                                    }

                                                                                                    else
                                                                                                    {
                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("foot")))
                                                                                                        {
                                                                                                            text2 = "Material Effect";
                                                                                                        }

                                                                                                        else
                                                                                                        {
                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("flag")))
                                                                                                            {
                                                                                                                text2 = "Flag";
                                                                                                            }

                                                                                                            else
                                                                                                            {
                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("font")))
                                                                                                                {
                                                                                                                    text2 = "Font";
                                                                                                                }

                                                                                                                else
                                                                                                                {
                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("grhi")))
                                                                                                                    {
                                                                                                                        text2 = "Grenade HUD Inteface";
                                                                                                                    }

                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("wphi")))
                                                                                                                        {
                                                                                                                            text2 = "Weapon HUD Inteface";
                                                                                                                        }

                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("hmt ")))
                                                                                                                            {
                                                                                                                                text2 = "HUD Message Text";
                                                                                                                            }

                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("fog ")))
                                                                                                                                {
                                                                                                                                    text2 = "Fog";
                                                                                                                                }

                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("hud#")))
                                                                                                                                    {
                                                                                                                                        text2 = "HUD Number";
                                                                                                                                    }

                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("hudg")))
                                                                                                                                        {
                                                                                                                                            text2 = "HUD Globals";
                                                                                                                                        }

                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("itmc")))
                                                                                                                                            {
                                                                                                                                                text2 = "Item Collection";
                                                                                                                                            }

                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("lens")))
                                                                                                                                                {
                                                                                                                                                    text2 = "Lens Flare";
                                                                                                                                                }

                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("soso")))
                                                                                                                                                    {
                                                                                                                                                        text2 = "Shader Model";
                                                                                                                                                    }

                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("scex")))
                                                                                                                                                        {
                                                                                                                                                            text2 = "Shader Transparent Chicago Extended";
                                                                                                                                                        }

                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("schi")))
                                                                                                                                                            {
                                                                                                                                                                text2 = "Shader Transparent Chicago";
                                                                                                                                                            }

                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("sky ")))
                                                                                                                                                                {
                                                                                                                                                                    text2 = "Sky";
                                                                                                                                                                }

                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("Soul")))
                                                                                                                                                                    {
                                                                                                                                                                        text2 = "UI Widget Collection";
                                                                                                                                                                    }

                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("trak")))
                                                                                                                                                                        {
                                                                                                                                                                            text2 = "Track";
                                                                                                                                                                        }

                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("swat")))
                                                                                                                                                                            {
                                                                                                                                                                                text2 = "Shader Water";
                                                                                                                                                                            }

                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("spla")))
                                                                                                                                                                                {
                                                                                                                                                                                    text2 = "Shader Plasma";
                                                                                                                                                                                }

                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("udlg")))
                                                                                                                                                                                    {
                                                                                                                                                                                        text2 = "Unit Dialog";
                                                                                                                                                                                    }

                                                                                                                                                                                    else
                                                                                                                                                                                    {
                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("wind")))
                                                                                                                                                                                        {
                                                                                                                                                                                            text2 = "Wind";
                                                                                                                                                                                        }

                                                                                                                                                                                        else
                                                                                                                                                                                        {
                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("ustr")))
                                                                                                                                                                                            {
                                                                                                                                                                                                text2 = "Unicode String List";
                                                                                                                                                                                            }

                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("str#")))
                                                                                                                                                                                                {
                                                                                                                                                                                                    text2 = "String List";
                                                                                                                                                                                                }

                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("ssce")))
                                                                                                                                                                                                    {
                                                                                                                                                                                                        text2 = "Sound Scenery";
                                                                                                                                                                                                    }

                                                                                                                                                                                                    else
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("smet")))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            text2 = "Shader Meter";
                                                                                                                                                                                                        }

                                                                                                                                                                                                        else
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("mod2")))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                text2 = "Model";
                                                                                                                                                                                                            }

                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("snd!")))
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    text2 = "Sound";
                                                                                                                                                                                                                }

                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("lsnd")))
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        text2 = "Sound Looping";
                                                                                                                                                                                                                    }

                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("tagc")))
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            text2 = "Tag Collection";
                                                                                                                                                                                                                        }

                                                                                                                                                                                                                        else
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("snde")))
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                text2 = "Sound Enviroment";
                                                                                                                                                                                                                            }

                                                                                                                                                                                                                            else
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("senv")))
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    text2 = "Shader Enviroment";
                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("proj")))
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        text2 = "Projectile";
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("phys")))
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            text2 = "Physics";
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("pphy")))
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                text2 = "Point Physics";
                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("pctl")))
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    text2 = "Particle System";
                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("sgla")))
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        text2 = "Shader Transparent Glass";
                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("mgs2")))
                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                            text2 = "Light Volume";
                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("matg")))
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                text2 = "Game Globals";
                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("unhi")))
                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                    text2 = "Unit HUD Interface";
                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("devc")))
                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                        text2 = "Device";
                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("metr")))
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                            text2 = "Meter";
                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("part")))
                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                text2 = "Particle";
                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("jpt!")))
                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                    text2 = "Damage";
                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("rain")))
                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                        text2 = "Rain";
                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("lifi")))
                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                            text2 = "Light Fixture";
                                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("mach")))
                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                text2 = "Machine";
                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("dobc")))
                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                    text2 = "Detail Object Collection";
                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("ligh")))
                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                        text2 = "Light";
                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                        if (flag == (this.TagTreeView.Nodes[i].Name.Equals("ctrl")))
                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                            text2 = "Control";
                                                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                            if (flag == (this.TagTreeView.Nodes[i].Name.Equals("garb")))
                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                text2 = "Garbage";
                                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                if (flag == (this.TagTreeView.Nodes[i].Name.Equals("vcky")))
                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                    text2 = "Virtual Keyboard";
                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                    if (flag == (this.TagTreeView.Nodes[i].Name.Equals("mply")))
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        text2 = "Multiplayer Scenarios";
                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        text2 = this.TagTreeView.Nodes[i].Name.ToUpper() + " Tag (Unknown)";
                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                }
                                                                                                                                                                                                                            }

                                                                                                                                                                                                                        }
                                                                                                                                                                                                                    }

                                                                                                                                                                                                                }
                                                                                                                                                                                                            }

                                                                                                                                                                                                        }
                                                                                                                                                                                                    }

                                                                                                                                                                                                }
                                                                                                                                                                                            }

                                                                                                                                                                                        }
                                                                                                                                                                                    }

                                                                                                                                                                                }
                                                                                                                                                                            }

                                                                                                                                                                        }
                                                                                                                                                                    }

                                                                                                                                                                }
                                                                                                                                                            }

                                                                                                                                                        }
                                                                                                                                                    }

                                                                                                                                                }
                                                                                                                                            }

                                                                                                                                        }
                                                                                                                                    }

                                                                                                                                }
                                                                                                                            }

                                                                                                                        }
                                                                                                                    }

                                                                                                                }
                                                                                                            }

                                                                                                        }
                                                                                                    }

                                                                                                }
                                                                                            }

                                                                                        }
                                                                                    }

                                                                                }
                                                                            }

                                                                        }
                                                                    }

                                                                }
                                                            }

                                                        }
                                                    }

                                                }
                                            }

                                        }
                                    }

                                }
                            }

                        }
                    }

                    this.TagTreeView.Nodes[i].Text = string.Concat(new string[]
                    {
                        this.TagTreeView.Nodes[i].Text,
                        " ",
                        text2,
                        " (",
                        Conversions.ToString(this.TagTreeView.Nodes[i].GetNodeCount(false)),
                        text
                    });
                }

            }
        }

        private void OpenMap(string path)
        {
            this.CloseMap();
            this.MAP = new HaloMap();
            this.MAP.Path = path;
            this.ReadMAPHeaders();
            this.Text = string.Concat(new string[]
            {
                "Lethargy - ",
                this.MAP.GameVersion,
                " ",
                this.MAP.PlayerType,
                " ",
                this.MAP.Name
            });
            this.Status.Text = "Loading Map '" + this.MAP.Name + "'...";
            this.Refresh();
            this.TagTreeView.Cursor = Cursors.WaitCursor;
            this.ReadMAPTags();
            this.TagTreeView.Cursor = Cursors.Default;
            this.Status.Text = this.MAP.Name + " loaded, " + Conversions.ToString(this.MAP.TagCount) + " tags processed.";
            this.FindTagByIndexOrderToolStripMenuItem.Enabled = true;
            this.ShowTagsOrderToolStripMenuItem.Enabled = true;
            this.InsertBlankDataToolStripMenuItem.Enabled = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tagTree_selectTag(object sender, TreeViewEventArgs e)
        {
            // If we selected a tag class, nobody cares
            if (Operators.ConditionalCompareObjectEqual(this.IsClass(this.TagTreeView.SelectedNode.Name), true, false))
            {
                return;
            }

            // Interesting, didn't know this existed.
            if (this.TagTreeView.SelectedNode.ForeColor == Color.Gray)
            {
                Interaction.MsgBox("Cannot edit indexed CE tags.", MsgBoxStyle.OkOnly, null);
                return;
            }

            this.btnExtract.Enabled = true;
            this.btnSave.Enabled = true;
            HaloTag haloTag = this.TagsCache[Convert.ToInt32(this.TagTreeView.SelectedNode.Tag)];
            this.txtID.Text = Conversions.ToString(haloTag.ID);
            this.txtMetaOffset.Text = Conversion.Hex(haloTag.MetaOffset);
            this.txtTagMetaSize.Text = Conversions.ToString(haloTag.MetaSize);
            this.txtTagName.Text = haloTag.Name;
            this.txtNameOffset.Text = Conversion.Hex(haloTag.NameOffset);
            this.cb1.SelectedItem = haloTag.Class1;
            this.cb2.SelectedItem = haloTag.Class2;
            this.cb3.SelectedItem = haloTag.Class3;
            this.txtOffset.Text = Conversion.Hex(haloTag.Offset);
            this.txtIndexOrder.Text = Conversions.ToString(haloTag.LoadOrder);
            this.dgv.Rows.Clear();
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
            checked
            {
                // Read 4 bytes at a time
                int num = haloTag.MetaSize - 4;
                for (int i = 0; i <= num; i += 4)
                {
                    binaryReader.BaseStream.Position = unchecked((long)checked(haloTag.MetaOffset + i));
                    if (binaryReader.BaseStream.Position == binaryReader.BaseStream.Length)
                    {
                        break;
                    }

                    // Check to see if we've found a reference
                    int maybeIdent = binaryReader.ReadInt32();
                    if (this.IDhash.ContainsKey(maybeIdent))
                    {
                        HaloTag referencedTag = this.TagsCache[Convert.ToInt32(this.IDhash[maybeIdent])];
                        try
                        {
                            binaryReader.BaseStream.Position = unchecked((long)checked(haloTag.MetaOffset + i - 12));
                            string text = new string(binaryReader.ReadChars(4));
                            text = this.ReverseString(text);

                            // Dependency
                            if (Operators.ConditionalCompareObjectEqual(this.IsClass(text), true, false))
                            {
                                this.dgv.Rows.Add(new object[]
                                {
                                    referencedTag.Class1,
                                    referencedTag.Name,
                                    "DEP"
                                });
                            }

                            // Lone ID
                            else
                            {
                                this.dgv.Rows.Add(new object[]
                                {
                                    referencedTag.Class1,
                                    referencedTag.Name,
                                    "LID"
                                });
                            }

                        }
                        catch (Exception)
                        {
                            //ProjectData.SetProjectError(ex);
                            this.dgv.Rows.Add(new object[]
                            {
                                referencedTag.Class1,
                                referencedTag.Name,
                                "LID"
                            });
                            //ProjectData.ClearProjectError();
                        }

                        this.dgv.Rows[this.dgv.Rows.Count - 1].Tag = haloTag.MetaOffset + i;
                    }

                    // There still may be a chance!  See if we've found a dependency that's been... nulled out, I think
                    else
                    {
                        if (maybeIdent == -1)
                        {
                            try
                            {
                                binaryReader.BaseStream.Position = unchecked((long)checked(haloTag.MetaOffset + i - 12));
                                string tagClass = new string(binaryReader.ReadChars(4));
                                tagClass = this.ReverseString(tagClass);
                                if (Operators.ConditionalCompareObjectEqual(this.IsClass(tagClass), true, false))
                                {
                                    this.dgv.Rows.Add(new object[]
                                    {
                                        tagClass,
                                        "Nulled Out",
                                        "DEP"
                                    });
                                    this.dgv.Rows[this.dgv.Rows.Count - 1].Tag = haloTag.MetaOffset + i;
                                }

                            }
                            catch (Exception)
                            {
                                //ProjectData.SetProjectError(ex);
                                //ProjectData.ClearProjectError();
                            }
                        }
                    }
                }
                // Done looking for references
                binaryReader.Close();

                // What, no plugins for sbsp?
                if (!(haloTag.Class1.Equals("sbsp")))
                {
                    XMLMain xmlMain = new XMLMain(haloTag);
                    xmlMain.Tag = haloTag;

                    // Attempt to load the plugin
                    this.pluginLoaded = true;
                    this.LoadPlugin(haloTag.Class1);
                    if (this.pluginLoaded)
                    {
                        this.ReadTag(haloTag.MetaOffset);
                        this.CreateGUI();
                    }

                }
            }

        }
        public object IsClass(string PrimaryClass)
        {
            bool flag = false;
            int arg_16_0 = 0;
            checked
            {
                int num = this.cb1.Items.Count - 1;
                for (int i = arg_16_0; i <= num; i++)
                {
                    if (PrimaryClass.Equals(this.cb1.Items[i].ToString()))
                    {
                        flag = true;
                        break;
                    }

                }
                return flag;
            }

        }
        public void ExtractMeta()
        {
            try
            {
                if (Operators.ConditionalCompareObjectEqual(this.IsClass(this.TagTreeView.SelectedNode.Name), true, false))
                {
                    return;
                }

                if (this.TagTreeView.SelectedNode.ForeColor == Color.Gray)
                {
                    //Interaction.MsgBox("Cannot extract indexed CE tags.", MsgBoxStyle.OkOnly, null);
                    return;
                }

            }
            catch (Exception expr_59)
            {
                //ProjectData.SetProjectError(expr_59);
                //ProjectData.ClearProjectError();
                return;
            }

            HaloTag haloTag = this.TagsCache[Convert.ToInt32(this.TagTreeView.SelectedNode.Tag)];
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = string.Concat(new string[]
            {
                haloTag.Class1.ToUpper(),
                " Tag (*.",
                haloTag.Class1,
                ".meta, *.",
                haloTag.Class1,
                ".xml)|*.",
                haloTag.Class1,
                ".meta"
            });
            string[] array = Strings.Split(haloTag.Name, "\\", -1, CompareMethod.Binary);
            checked
            {
                string fileName = array[array.Length - 1];
                saveFileDialog.FileName = fileName;
                saveFileDialog.AddExtension = false;
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string fileName2 = saveFileDialog.FileName;
                    BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
                    BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName2, FileMode.Create, FileAccess.Write));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName2.Remove(Strings.Len(fileName2) - 5) + ".xml", null);
                    binaryReader.BaseStream.Position = unchecked((long)haloTag.MetaOffset);
                    byte[] buffer = new byte[haloTag.MetaSize - 1 + 1];
                    binaryReader.Read(buffer, 0, haloTag.MetaSize);
                    binaryWriter.BaseStream.Position = 0L;
                    binaryWriter.Write(buffer, 0, haloTag.MetaSize);
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.WriteStartDocument();
                    xmlTextWriter.WriteComment("Metadata Structure File");
                    xmlTextWriter.WriteStartElement("Results", null);
                    xmlTextWriter.WriteElementString("Map", this.MAP.Name);
                    xmlTextWriter.WriteElementString("Tag", this.ReverseString(haloTag.Class1) + this.ReverseString(haloTag.Class2) + this.ReverseString(haloTag.Class3));
                    xmlTextWriter.WriteElementString("Tagname", haloTag.Name);
                    xmlTextWriter.WriteElementString("MetaSize", Conversions.ToString(haloTag.MetaSize));
                    xmlTextWriter.WriteElementString("ID", Conversions.ToString(haloTag.ID));
                    int num = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int arg_297_0 = 0;
                    int num4 = haloTag.MetaSize - 1;
                    for (int i = arg_297_0; i <= num4; i += 4)
                    {
                        binaryReader.BaseStream.Position = unchecked((long)checked(haloTag.MetaOffset + i));
                        int num5 = binaryReader.ReadInt32();
                        if (this.IDhash.Contains(num5))
                        {
                            HaloTag haloTag2 = this.TagsCache[Convert.ToInt32(this.IDhash[num5])];
                            binaryReader.BaseStream.Position = unchecked((long)checked(haloTag.MetaOffset + i - 12));
                            if (Operators.ConditionalCompareObjectEqual(this.IsClass(this.ReverseString(new string(binaryReader.ReadChars(4)))), true, false))
                            {
                                num++;
                                xmlTextWriter.WriteStartElement("Dependency", null);
                            }

                            else
                            {
                                num2++;
                                xmlTextWriter.WriteStartElement("LoneID", null);
                            }

                            xmlTextWriter.WriteElementString("Location", "0x" + Conversion.Hex(i));
                            xmlTextWriter.WriteElementString("Tagclass", this.ReverseString(haloTag2.Class1) + this.ReverseString(haloTag2.Class2) + this.ReverseString(haloTag2.Class3));
                            xmlTextWriter.WriteElementString("Filename", haloTag2.Name);
                            xmlTextWriter.WriteEndElement();
                        }

                        else
                        {
                            try
                            {
                                int num6 = num5 - this.MAP.Magic;
                                if (num6 > haloTag.MetaOffset & num6 < haloTag.MetaOffset + haloTag.MetaSize)
                                {
                                    num3++;
                                    binaryReader.BaseStream.Position = unchecked((long)checked(haloTag.MetaOffset + i - 4));
                                    int value = binaryReader.ReadInt32();
                                    xmlTextWriter.WriteStartElement("Reflexive", null);
                                    xmlTextWriter.WriteElementString("Offset", Conversions.ToString(i));
                                    xmlTextWriter.WriteElementString("Translation", Conversions.ToString(num6 - haloTag.MetaOffset));
                                    xmlTextWriter.WriteElementString("ChunkCount", Conversions.ToString(value));
                                    xmlTextWriter.WriteEndElement();
                                }

                            }
                            catch (Exception expr_47B)
                            {
                                //ProjectData.SetProjectError(expr_47B);
                                //ProjectData.ClearProjectError();
                            }

                        }
                    }

                    binaryReader.Close();
                    binaryWriter.Close();
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                    Interaction.MsgBox(string.Concat(new string[]
                    {
                        "Metadata Extraction Complete. Results: (Dependencies: ",
                        Conversions.ToString(num),
                        ", Lone I.D.s: ",
                        Conversions.ToString(num2),
                        ", Reflexives: ",
                        Conversions.ToString(num3),
                        ")"
                    }), MsgBoxStyle.OkOnly, null);
                }

            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            this.ExtractMeta();
        }

        public void LoadPlugin(string PrimaryTagClass)
        {
            string text = Application.StartupPath + "\\Plugins\\" + PrimaryTagClass + ".xml";
            XmlTextReader xmlTextReader = new XmlTextReader(text + ".xml");
            XmlDocument xmlDocument = new XmlDocument();
            checked
            {
                if (File.Exists(Application.StartupPath + "\\plugins\\" + PrimaryTagClass + ".xml"))
                {
                    xmlDocument.Load(text);
                    this.Tabs.SelectedIndex = 0;
                    XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("struct");
                    this.@struct = new XMLMain.TAG_STRUCT[elementsByTagName.Count - 1 + 1];
                    int arg_16F_0 = 0;
                    int num = elementsByTagName.Count - 1;
                    for (int i = arg_16F_0; i <= num; i++)
                    {
                        XmlNodeList[] array = new XmlNodeList[elementsByTagName.Count + 1];
                        array[i] = elementsByTagName[i].ChildNodes;
                        this.@struct[i].name = array[i][0].InnerText;
                        this.@struct[i].size = (int)Math.Round(Conversion.Val(array[i][1].InnerText));
                        this.@struct[i].values = new XMLMain.VALUE_STRUCT[array[i].Count - 3 + 1];
                        int arg_212_0 = 0;
                        int num2 = array[i].Count - 3;
                        for (int j = arg_212_0; j <= num2; j++)
                        {
                            XmlNodeList childNodes = array[i][j + 2].ChildNodes;
                            this.@struct[i].values[j].type = childNodes.Item(0).InnerText;
                            this.@struct[i].values[j].offset = (int)Math.Round(Conversion.Val("&H" + Strings.Mid(childNodes[1].InnerText, 3)));
                            this.@struct[i].values[j].name = childNodes[2].InnerText;
                            if (childNodes.Count - 3 > 0)
                            {
                                this.@struct[i].values[j].offset_options = new XMLMain.OFFSET_OPTIONS[childNodes.Count - 4 + 1];
                                int arg_308_0 = 3;
                                int num3 = childNodes.Count - 1;
                                for (int k = arg_308_0; k <= num3; k++)
                                {
                                    string name = childNodes[k].Name;
                                    if (name.Equals("option"))
                                    {
                                        this.@struct[i].values[j].offset_options[k - 3].op_value = (int)Math.Round(Conversion.Val(childNodes[k].ChildNodes[0].InnerText));
                                        this.@struct[i].values[j].offset_options[k - 3].op_name = childNodes[k].ChildNodes[1].InnerText;
                                    }

                                    else
                                    {
                                        if (name.Equals("bitmask"))
                                        {
                                            this.@struct[i].values[j].offset_options[k - 3].op_value = (int)Math.Round(Conversion.Val(childNodes[k].ChildNodes[0].InnerText));
                                            this.@struct[i].values[j].offset_options[k - 3].op_name = childNodes[k].ChildNodes[1].InnerText;
                                        }

                                    }
                                }

                            }
                        }

                    }
                    xmlTextReader.Close();
                    return;
                }

                this.MetaTab.Controls.Clear();
                Label label = new Label();
                label.Text = "(No plugin)";
                Control arg_114_0 = label;
                Point location = new Point((int)Math.Round(unchecked((double)this.MetaTab.Size.Width / 2.0 - (double)label.Size.Width / 2.0)), (int)Math.Round(unchecked((double)this.MetaTab.Size.Height / 2.0 - (double)label.Size.Height / 2.0)));
                arg_114_0.Location = location;
                this.MetaTab.Controls.Add(label);
                this.pluginLoaded = false;
                this.Tabs.SelectedIndex = 1;
            }

        }
        public void CreateGUI()
        {
            this.MetaTab.Controls.Clear();
            int num = 0;
            int num2 = 0;
            int arg_25_0 = 0;
            checked
            {
                int num3 = this.@struct.Length - 1;
                for (int i = arg_25_0; i <= num3; i++)
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Text = this.@struct[i].name;
                    groupBox.Name = this.@struct[i].name + "GroupBox";
                    Point location;
                    int j;
                    if (!(this.@struct[i].name.Equals("Main")))
                    {
                        ComboBox comboBox = new ComboBox();
                        Label label = new Label();
                        label.Text = this.@struct[i].name;
                        Control arg_C2_0 = label;
                        location = new Point(2, num);
                        arg_C2_0.Location = location;
                        label.Width = this.@struct[i].name.Length * 7;
                        comboBox.Name = this.@struct[i].name + "ComboBox";
                        Control arg_11F_0 = comboBox;
                        location = new Point(label.Width + 10, num);
                        arg_11F_0.Location = location;
                        comboBox.SelectedIndexChanged += new EventHandler(this.somethingChanged);
                        comboBox.Click += new EventHandler(this.SetUserDidIt);
                        this.MetaTab.Controls.Add(label);
                        this.MetaTab.Controls.Add(comboBox);
                        int arg_188_0 = 0;
                        int num4 = this.@struct[0].values.Length - 1;
                        for (j = arg_188_0; j <= num4; j++)
                        {
                            if (this.@struct[i].name.Equals(this.@struct[0].values[j].name) & this.@struct[0].values[j].type.Equals("reflexive"))
                            {
                                int arg_212_0 = 0;
                                int num5 = this.@struct[0].values[j].count - 1;
                                for (int k = arg_212_0; k <= num5; k++)
                                {
                                    comboBox.Items.Add(k);
                                }

                            }
                        }

                        num += 25;
                    }

                    Control arg_252_0 = groupBox;
                    location = new Point(2, num);
                    arg_252_0.Location = location;
                    int x = 10;
                    int num6 = 15;
                    int arg_277_0 = 0;
                    int num7 = this.@struct[i].values.Length - 1;
                    j = arg_277_0;
                    Size size;
                    while (j <= num7)
                    {
                        string type = this.@struct[i].values[j].type;
                        if (type.Equals("float"))
                        {
                            goto IL_2E2;
                        }

                        if (type.Equals("string32"))
                        {
                            goto IL_2E2;
                        }

                        if (type.Equals("integer"))
                        {
                            goto IL_2E2;
                        }

                        if (type.Equals("short"))
                        {
                            goto IL_2E2;
                        }

                        if (type.Equals("id32") || type.Equals("id16"))
                        {
                            GroupBox groupBox2 = new GroupBox();
                            groupBox2.Tag = this.@struct[i].values[j].offset;
                            groupBox2.Name = this.@struct[i].values[j].name.Replace(" ", "") + "Group";
                            groupBox2.Text = this.@struct[i].values[j].name;
                            groupBox2.Width = this.MetaTab.Width - 20;
                            groupBox2.Height = 20 + (this.@struct[i].values[j].offset_options.Length / 2 + this.@struct[i].values[j].offset_options.Length % 2) * 16;
                            Control arg_5BD_0 = groupBox2;
                            location = new Point(x, num6);
                            arg_5BD_0.Location = location;
                            groupBox2.TabIndex = num2;
                            num2++;
                            int x2 = 10;
                            int num8 = 15;
                            int arg_5F9_0 = 0;
                            int num9 = this.@struct[i].values[j].offset_options.Length - 1;
                            for (int k = arg_5F9_0; k <= num9; k++)
                            {
                                RadioButton radioButton = new RadioButton();
                                radioButton.Name = this.@struct[i].values[j].offset_options[k].op_name.Replace(" ", "") + "RadioButton";
                                radioButton.Text = this.@struct[i].values[j].offset_options[k].op_name;
                                radioButton.Tag = this.@struct[i].values[j].offset_options[k].op_value;
                                if (Operators.ConditionalCompareObjectEqual(this.@struct[i].values[j].offset_options[k].op_value, this.@struct[i].values[j].data, false))
                                {
                                    radioButton.Checked = true;
                                }

                                else
                                {
                                    radioButton.Checked = false;
                                }

                                Control arg_71F_0 = radioButton;
                                location = new Point(x2, num8);
                                arg_71F_0.Location = location;
                                Control arg_742_0 = radioButton;
                                size = new Size(radioButton.Name.Length * 5 + 15, 15);
                                arg_742_0.Size = size;
                                radioButton.TabIndex = num2 + k;
                                radioButton.CheckedChanged += new EventHandler(this.somethingChanged);
                                groupBox2.Controls.Add(radioButton);
                                radioButton.BringToFront();
                                if (k % 2 == 1)
                                {
                                    x2 = 10;
                                    num8 += 15;
                                }

                                else
                                {
                                    x2 = (int)Math.Round((double)this.MetaTab.Width / 2.0);
                                }

                            }
                            groupBox.Controls.Add(groupBox2);
                            num6 += groupBox2.Height;
                            x = 10;
                            num2 += this.@struct[i].values[j].offset_options.Length;
                        }

                        else
                        {
                            if (type.Equals("bitmask32"))
                            {
                                GroupBox groupBox3 = new GroupBox();
                                groupBox3.Tag = this.@struct[i].values[j].offset;
                                groupBox3.Name = this.@struct[i].values[j].name.Replace(" ", "") + "Group";
                                groupBox3.Text = this.@struct[i].values[j].name;
                                groupBox3.Width = this.MetaTab.Width - 20;
                                groupBox3.Height = 20 + (this.@struct[i].values[j].offset_options.Length / 2 + this.@struct[i].values[j].offset_options.Length % 2) * 16;
                                groupBox3.TabIndex = num2;
                                Control arg_916_0 = groupBox3;
                                location = new Point(x, num6);
                                arg_916_0.Location = location;
                                int x2 = 10;
                                int num8 = 15;
                                num2++;
                                int arg_94A_0 = 0;
                                int num10 = this.@struct[i].values[j].offset_options.Length - 1;
                                for (int k = arg_94A_0; k <= num10; k++)
                                {
                                    CheckBox checkBox = new CheckBox();
                                    checkBox.Name = this.@struct[i].values[j].offset_options[k].op_name.Replace(" ", "") + "CheckBox";
                                    checkBox.Text = this.@struct[i].values[j].offset_options[k].op_name;
                                    checkBox.Tag = this.@struct[i].values[j].offset_options[k].op_value;
                                    Control arg_A0E_0 = checkBox;
                                    location = new Point(x2, num8);
                                    arg_A0E_0.Location = location;
                                    Control arg_A31_0 = checkBox;
                                    size = new Size(checkBox.Name.Length * 5 + 15, 15);
                                    arg_A31_0.Size = size;
                                    checkBox.TabIndex = num2 + k;
                                    if (this.@struct[i].values[j].data != null)
                                    {
                                        object arg_ADE_0 = this.@struct[i].values[j].data;
                                        Type arg_ADE_1 = null;
                                        string arg_ADE_2 = "BitOn";
                                        object[] array = new object[1];
                                        object[] arg_AC6_0 = array;
                                        int arg_AC6_1 = 0;
                                        XMLMain.TAG_STRUCT[] arg_A99_0 = this.@struct;
                                        int num11 = i;
                                        XMLMain.VALUE_STRUCT[] arg_AA8_0 = arg_A99_0[num11].values;
                                        int num12 = j;
                                        XMLMain.OFFSET_OPTIONS[] arg_AB7_0 = arg_AA8_0[num12].offset_options;
                                        int num13 = k;
                                        arg_AC6_0[arg_AC6_1] = arg_AB7_0[num13].op_value;
                                        object[] array2 = array;
                                        object[] arg_ADE_3 = array2;
                                        string[] arg_ADE_4 = null;
                                        Type[] arg_ADE_5 = null;
                                        bool[] array3 = new bool[]
                                        {
                                            true
                                        };
                                        object arg_B35_0 = NewLateBinding.LateGet(arg_ADE_0, arg_ADE_1, arg_ADE_2, arg_ADE_3, arg_ADE_4, arg_ADE_5, array3);
                                        if (array3[0])
                                        {
                                            this.@struct[num11].values[num12].offset_options[num13].op_value = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(int));
                                        }

                                        if (Conversions.ToBoolean(arg_B35_0))
                                        {
                                            checkBox.Checked = true;
                                        }

                                    }
                                    checkBox.CheckedChanged += new EventHandler(this.somethingChanged);
                                    groupBox3.Controls.Add(checkBox);
                                    checkBox.BringToFront();
                                    if (k % 2 == 1)
                                    {
                                        x2 = 10;
                                        num8 += 15;
                                    }

                                    else
                                    {
                                        x2 = (int)Math.Round((double)this.MetaTab.Width / 2.0);
                                    }

                                }
                                groupBox.Controls.Add(groupBox3);
                                num6 += groupBox3.Height;
                                num2 += this.@struct[i].values[j].offset_options.Length;
                                x = 10;
                            }

                        }
                    IL_BE9:
                        j++;
                        continue;
                    IL_2E2:
                        TextBox textBox = new TextBox();
                        Label label2 = new Label();
                        textBox.Name = this.@struct[i].values[j].name + "TextBox";
                        textBox.Tag = this.@struct[i].values[j].offset;
                        if (this.@struct[i].values[j].data != null)
                        {
                            textBox.Text = Conversions.ToString(this.@struct[i].values[j].data);
                        }

                        label2.Name = this.@struct[i].values[j].name + "Label";
                        label2.Text = this.@struct[i].values[j].name;
                        label2.TabIndex = num2;
                        textBox.TabIndex = num2 + 1;
                        label2.AutoSize = true;
                        Control arg_404_0 = label2;
                        location = new Point(x, num6);
                        arg_404_0.Location = location;
                        x = (int)Math.Round((double)this.MetaTab.Width / 2.0);
                        Control arg_436_0 = textBox;
                        size = new Size(75, 20);
                        arg_436_0.Size = size;
                        Control arg_44A_0 = textBox;
                        location = new Point(x, num6);
                        arg_44A_0.Location = location;
                        textBox.TextChanged += new EventHandler(this.somethingChanged);
                        groupBox.Controls.Add(label2);
                        groupBox.Controls.Add(textBox);
                        textBox.BringToFront();
                        num6 += 20;
                        x = 10;
                        num2 += 2;
                        goto IL_BE9;
                    }

                    Control arg_C12_0 = groupBox;
                    size = new Size(this.MetaTab.Width - 24, num6 + 5);
                    arg_C12_0.Size = size;
                    num += groupBox.Height;
                    this.MetaTab.Controls.Add(groupBox);
                }

            }
        }

        private void SetUserDidIt(object sender, EventArgs e)
        {
            this.userdidit = true;
        }

        private void somethingChanged(object sender, EventArgs e)
        {
            checked
            {
                try
                {
                    if (sender is ComboBox)
                    {
                        if (this.userdidit)
                        {
                            ComboBox comboBox = (ComboBox)sender;
                            string name = comboBox.Name;
                            int selectedIndex = comboBox.SelectedIndex;
                            this.ReadReflexive(Strings.Mid(comboBox.Name, 1, comboBox.Name.IndexOf("ComboBox")), selectedIndex);
                            this.MetaTab.Controls.Clear();
                            this.CreateGUI();
                            int arg_79_0 = 0;
                            int num = this.MetaTab.Controls.Count - 1;
                            for (int i = arg_79_0; i <= num; i++)
                            {
                                if (this.MetaTab.Controls[i].Name.Equals(name))
                                {
                                    comboBox = (ComboBox)this.MetaTab.Controls[i];
                                    this.userdidit = false;
                                    comboBox.SelectedIndex = selectedIndex;
                                    break;
                                }

                            }
                        }

                    }
                    else
                    {
                        if (sender is TextBox)
                        {
                            TextBox textBox = (TextBox)sender;
                            this.SetValue(Strings.Mid(textBox.Name, 1, textBox.Name.IndexOf("TextBox")), textBox.Text);
                            if (textBox.Parent.Name.Equals("MainGroupBox"))
                            {
                                this.WriteTag();
                            }

                            else
                            {
                                int arg_14D_0 = 0;
                                int num2 = this.MetaTab.Controls.Count - 1;
                                for (int i = arg_14D_0; i <= num2; i++)
                                {
                                    if (Operators.CompareString(Strings.Mid(textBox.Parent.Name, 1, textBox.Parent.Name.IndexOf("GroupBox")) + "ComboBox", this.MetaTab.Controls[i].Name, false) == 0)
                                    {
                                        ComboBox comboBox2 = (ComboBox)this.MetaTab.Controls[i];
                                        this.WriteReflexive(Strings.Mid(textBox.Parent.Name, 1, textBox.Parent.Name.IndexOf("GroupBox")), comboBox2.SelectedIndex);
                                        break;
                                    }

                                }
                            }

                        }
                        else
                        {
                            if (sender is CheckBox)
                            {
                                CheckBox checkBox = (CheckBox)sender;
                                checkBox.Checked = this.SetOption(Strings.Mid(checkBox.Parent.Name, 1, checkBox.Parent.Name.IndexOf("Group")), RuntimeHelpers.GetObjectValue(checkBox.Tag));
                                if (checkBox.Parent.Parent.Name.Equals("MainGroupBox"))
                                {
                                    this.WriteTag();
                                }

                                else
                                {
                                    int arg_29A_0 = 0;
                                    int num3 = this.MetaTab.Controls.Count - 1;
                                    for (int i = arg_29A_0; i <= num3; i++)
                                    {
                                        if (Operators.CompareString(Strings.Mid(checkBox.Parent.Parent.Name, 1, checkBox.Parent.Parent.Name.IndexOf("GroupBox")) + "ComboBox", this.MetaTab.Controls[i].Name, false) == 0)
                                        {
                                            ComboBox comboBox3 = (ComboBox)this.MetaTab.Controls[i];
                                            this.WriteReflexive(Strings.Mid(checkBox.Parent.Parent.Name, 1, checkBox.Parent.Parent.Name.IndexOf("GroupBox")), comboBox3.SelectedIndex);
                                            break;
                                        }

                                    }
                                }

                            }
                            else
                            {
                                if (sender is RadioButton)
                                {
                                    RadioButton radioButton = (RadioButton)sender;
                                    if (radioButton.Checked)
                                    {
                                        radioButton.Checked = this.SetValue(Strings.Mid(radioButton.Parent.Name, 1, radioButton.Parent.Name.IndexOf("Group")), RuntimeHelpers.GetObjectValue(radioButton.Tag));
                                    }

                                    if (radioButton.Parent.Parent.Name.Equals("MainGroupBox"))
                                    {
                                        this.WriteTag();
                                    }

                                    else
                                    {
                                        int arg_404_0 = 0;
                                        int num4 = this.MetaTab.Controls.Count - 1;
                                        for (int i = arg_404_0; i <= num4; i++)
                                        {
                                            if (Operators.CompareString(Strings.Mid(radioButton.Parent.Parent.Name, 1, radioButton.Parent.Parent.Name.IndexOf("GroupBox")) + "ComboBox", this.MetaTab.Controls[i].Name, false) == 0)
                                            {
                                                ComboBox comboBox4 = (ComboBox)this.MetaTab.Controls[i];
                                                this.WriteReflexive(Strings.Mid(radioButton.Parent.Parent.Name, 1, radioButton.Parent.Parent.Name.IndexOf("GroupBox")), comboBox4.SelectedIndex);
                                                break;
                                            }

                                        }
                                    }

                                }
                            }

                        }
                    }

                }
                catch (Exception arg_4D0_0)
                {
                    //ProjectData.SetProjectError(arg_4D0_0);
                    MessageBox.Show("An error occured while attempting to update the metadata.");
                    //ProjectData.ClearProjectError();
                }

            }
        }

        public bool SetValue(string valName, object val)
        {
            int arg_0C_0 = 0;
            checked
            {
                int num = this.@struct.Length - 1;
                for (int i = arg_0C_0; i <= num; i++)
                {
                    int arg_2A_0 = 0;
                    int num2 = this.@struct[i].values.Length - 1;
                    for (int j = arg_2A_0; j <= num2; j++)
                    {
                        if ((this.@struct[i].values[j].name.Replace(" ", "")).Equals(valName.Replace(" ", "")))
                        {
                            this.@struct[i].values[j].data = RuntimeHelpers.GetObjectValue(val);
                            return true;
                        }

                    }
                }

                return false;
            }

        }
        public bool SetOption(string valName, object val)
        {
            bool flag = false;
            int length = (int)this.@struct.Length - 1;
            for (int i = 0; i <= length; i++)
            {
                int num = (int)this.@struct[i].values.Length - 1;
                for (int j = 0; j <= num; j++)
                {
                    if (Operators.CompareString(this.@struct[i].values[j].name.Replace(" ", ""), valName.Replace(" ", ""), false) == 0)
                    {
                        if (this.@struct[i].values[j].data != null)
                        {
                            if (Operators.CompareString(this.@struct[i].values[j].type, "bitmask32", false) == 0)
                            {
                                object[] objectValue = new object[1];
                                objectValue[0] = RuntimeHelpers.GetObjectValue(val);
                                object[] objArray = objectValue;
                                bool[] flagArray = new bool[1];
                                flagArray[0] = true;
                                NewLateBinding.LateCall(this.@struct[i].values[j].data, null, "ToggleBit", objArray, null, null, flagArray, true);
                                if (flagArray[0])
                                {
                                    val = RuntimeHelpers.GetObjectValue(objArray[0]);
                                }

                                objArray = new object[1];
                                objArray[0] = RuntimeHelpers.GetObjectValue(val);
                                objectValue = objArray;
                                flagArray = new bool[1];
                                flagArray[0] = true;
                                object obj = NewLateBinding.LateGet(this.@struct[i].values[j].data, null, "BitOn", objectValue, null, null, flagArray);
                                if (flagArray[0])
                                {
                                    val = RuntimeHelpers.GetObjectValue(objectValue[0]);
                                }

                                return Conversions.ToBoolean(obj);
                            }

                        }
                        else
                        {
                            return false;
                        }

                    }
                }

            }
            return flag;
        }

        public void WriteTag()
        {
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Write));
            int num = Convert.ToInt32(this.TagTreeView.SelectedNode.Tag);
            HaloTag haloTag = this.TagsCache[num];
            int metaOffset = haloTag.MetaOffset;
            int arg_58_0 = 0;
            checked
            {
                int num2 = this.@struct[0].values.Length - 1;
                for (int i = arg_58_0; i <= num2; i++)
                {
                    binaryWriter.BaseStream.Seek(unchecked((long)checked(metaOffset + this.@struct[0].values[i].offset)), SeekOrigin.Begin);
                    string type = this.@struct[0].values[i].type;
                    if (type.Equals("float"))
                    {
                        if (this.@struct[0].values[i].data is string && "".Equals(this.@struct[0].values[i].data))
                        {
                            this.@struct[0].values[i].data = 0;
                        }

                        float value = Convert.ToSingle(this.@struct[0].values[i].data);
                        binaryWriter.Write(value);
                    }

                    else
                    {
                        if (type.Equals("string32"))
                        {
                            string value2 = this.@struct[0].values[i].data as string;
                            binaryWriter.Write(value2);
                        }

                        else
                        {
                            if (type.Equals("id32") || type.Equals("integer"))
                            {
                                if (this.@struct[0].values[i].data is string && "".Equals(this.@struct[0].values[i].data))
                                {
                                    this.@struct[0].values[i].data = 0;
                                }

                                int value3 = Convert.ToInt32(this.@struct[0].values[i].data);
                                binaryWriter.Write(value3);
                            }

                            else
                            {
                                if (type.Equals("short") || type.Equals("id16"))
                                {
                                    if (this.@struct[0].values[i].data is string && Operators.ConditionalCompareObjectEqual(this.@struct[0].values[i].data, "", false))
                                    {
                                        this.@struct[0].values[i].data = 0;
                                    }

                                    short value4 = Conversions.ToShort(this.@struct[0].values[i].data);
                                    binaryWriter.Write(value4);
                                }

                                else
                                {
                                    if (type.Equals("reflexive"))
                                    {
                                        if (this.@struct[0].values[i].data is string && Operators.ConditionalCompareObjectEqual(this.@struct[0].values[i].data, "", false))
                                        {
                                            this.@struct[0].values[i].data = 0;
                                        }

                                        int count = this.@struct[0].values[i].count;
                                        int value5 = Convert.ToInt32(this.@struct[0].values[i].data);
                                        binaryWriter.Write(count);
                                        binaryWriter.Write(value5);
                                    }

                                    else
                                    {
                                        if (type.Equals("bitmask32"))
                                        {
                                            int value6 = Convert.ToInt32(NewLateBinding.LateGet(this.@struct[0].values[i].data, null, "ToInt", new object[0], null, null, null));
                                            binaryWriter.Write(value6);
                                        }

                                    }
                                }

                            }
                        }

                    }
                }

                binaryWriter.Close();
            }

        }
        public void ReadTag(int offset)
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
            int arg_2F_0 = 0;
            checked
            {
                int num = this.@struct[0].values.Length - 1;
                for (int i = arg_2F_0; i <= num; i++)
                {
                    binaryReader.BaseStream.Seek(unchecked((long)checked(offset + this.@struct[0].values[i].offset)), SeekOrigin.Begin);
                    string type = this.@struct[0].values[i].type;
                    if (type.Equals("float"))
                    {
                        this.@struct[0].values[i].data = binaryReader.ReadSingle();
                    }

                    else
                    {
                        if (type.Equals("string32"))
                        {
                            this.@struct[0].values[i].data = binaryReader.ReadString();
                            NewLateBinding.LateCall(this.@struct[0].values[i].data, null, "PadRight", new object[]
                            {
                                32
                            }, null, null, null, true);
                        }

                        else
                        {
                            if (type.Equals("id32"))
                            {
                                this.@struct[0].values[i].data = binaryReader.ReadInt32();
                            }

                            else
                            {
                                if (type.Equals("integer"))
                                {
                                    this.@struct[0].values[i].data = binaryReader.ReadInt32();
                                }

                                else
                                {
                                    if (type.Equals("short") || type.Equals("id16"))
                                    {
                                        this.@struct[0].values[i].data = binaryReader.ReadInt16();
                                    }

                                    else
                                    {
                                        if (type.Equals("reflexive"))
                                        {
                                            this.@struct[0].values[i].count = binaryReader.ReadInt32();
                                            this.@struct[0].values[i].data = binaryReader.ReadInt32();
                                        }

                                        else
                                        {
                                            if (type.Equals("bitmask32"))
                                            {
                                                this.@struct[0].values[i].data = new BitMask(binaryReader.ReadInt32());
                                            }

                                        }
                                    }

                                }
                            }

                        }
                    }

                }
                binaryReader.Close();
            }

        }
        public void ReadReflexive(string type, int num)
        {
            object objectValue = null;
            object obj = null;
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Read));
            int length = (int)this.@struct[0].values.Length - 1;
            for (int i = 0; i <= length; i++)
            {
                if (Operators.CompareString(this.@struct[0].values[i].name, type, false) == 0)
                {
                    objectValue = RuntimeHelpers.GetObjectValue(this.@struct[0].values[i].data);
                }

            }
            int length1 = (int)this.@struct.Length - 1;
            for (int i = 0; i <= length1; i++)
            {
                if (Operators.CompareString(this.@struct[i].name, type, false) == 0)
                {
                    obj = i;
                }

            }
            objectValue = Operators.AddObject(Operators.SubtractObject(objectValue, this.MAP.Magic), num * this.@struct[Conversions.ToInteger(obj)].size);
            int num1 = (int)this.@struct[Conversions.ToInteger(obj)].values.Length - 1;
            for (int j = 0; j <= num1; j++)
            {
                binaryReader.BaseStream.Seek(Conversions.ToLong(Operators.AddObject(objectValue, this.@struct[Conversions.ToInteger(obj)].values[j].offset)), SeekOrigin.Begin);
                string str = this.@struct[Conversions.ToInteger(obj)].values[j].type;
                if (Operators.CompareString(str, "float", false) != 0)
                {
                    if (Operators.CompareString(str, "string32", false) != 0)
                    {
                        if (Operators.CompareString(str, "id32", false) == 0 || Operators.CompareString(str, "integer", false) == 0)
                        {
                            this.@struct[Conversions.ToInteger(obj)].values[j].data = binaryReader.ReadInt32();
                        }

                        else
                        {
                            if (Operators.CompareString(str, "short", false) == 0 || Operators.CompareString(str, "id16", false) == 0)
                            {
                                this.@struct[Conversions.ToInteger(obj)].values[j].data = binaryReader.ReadInt16();
                            }

                            else
                            {
                                if (Operators.CompareString(str, "bitmask32", false) == 0)
                                {
                                    this.@struct[Conversions.ToInteger(obj)].values[j].data = new BitMask(binaryReader.ReadInt32());
                                }

                            }
                        }

                    }
                    else
                    {
                        this.@struct[Conversions.ToInteger(obj)].values[j].data = "";
                        for (int k = 0; k < 31 & binaryReader.PeekChar() != 10 & binaryReader.PeekChar() != 13; k++)
                        {
                            this.@struct[Conversions.ToInteger(obj)].values[j].data = Operators.ConcatenateObject(this.@struct[Conversions.ToInteger(obj)].values[j].data, Strings.Chr(binaryReader.ReadByte()));
                        }

                    }
                }

                else
                {
                    this.@struct[Conversions.ToInteger(obj)].values[j].data = binaryReader.ReadSingle();
                }

            }
            binaryReader.Close();
        }

        public void WriteReflexive(string type, int num)
        {
            object objectValue = null;
            object obj = null;
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Write));
            int length = (int)this.@struct[0].values.Length - 1;
            for (int i = 0; i <= length; i++)
            {
                if (Operators.CompareString(this.@struct[0].values[i].name, type, false) == 0)
                {
                    objectValue = RuntimeHelpers.GetObjectValue(this.@struct[0].values[i].data);
                }

            }
            int length1 = (int)this.@struct.Length - 1;
            for (int i = 0; i <= length1; i++)
            {
                if (Operators.CompareString(this.@struct[i].name, type, false) == 0)
                {
                    obj = i;
                }

            }
            objectValue = Operators.AddObject(Operators.SubtractObject(objectValue, this.MAP.Magic), num * this.@struct[Conversions.ToInteger(obj)].size);
            int num1 = (int)this.@struct[Conversions.ToInteger(obj)].values.Length - 1;
            for (int j = 0; j <= num1; j++)
            {
                binaryWriter.BaseStream.Seek(Conversions.ToLong(Operators.AddObject(objectValue, this.@struct[Conversions.ToInteger(obj)].values[j].offset)), SeekOrigin.Begin);
                string str = this.@struct[Conversions.ToInteger(obj)].values[j].type;
                if (Operators.CompareString(str, "float", false) != 0)
                {
                    if (Operators.CompareString(str, "string32", false) != 0)
                    {
                        if (Operators.CompareString(str, "id32", false) == 0 || Operators.CompareString(str, "integer", false) == 0)
                        {
                            int integer = Conversions.ToInteger(this.@struct[Conversions.ToInteger(obj)].values[j].data);
                            binaryWriter.Write(integer);
                        }

                        else
                        {
                            if (Operators.CompareString(str, "short", false) == 0 || Operators.CompareString(str, "id16", false) == 0)
                            {
                                short num2 = Conversions.ToShort(this.@struct[Conversions.ToInteger(obj)].values[j].data);
                                binaryWriter.Write(num2);
                            }

                            else
                            {
                                if (Operators.CompareString(str, "bitmask32", false) == 0)
                                {
                                    int integer1 = Conversions.ToInteger(NewLateBinding.LateGet(this.@struct[Conversions.ToInteger(obj)].values[j].data, null, "ToInt", new object[0], null, null, null));
                                    binaryWriter.Write(integer1);
                                }

                            }
                        }

                    }
                    else
                    {
                        byte num3 = 0;
                        int num4 = 0;
                        do
                        {
                            if (!Operators.ConditionalCompareObjectGreaterEqual(num4, NewLateBinding.LateGet(this.@struct[Conversions.ToInteger(obj)].values[j].data, null, "Length", new object[0], null, null, null), false))
                            {
                                object[] objArray = new object[1];
                                objArray[0] = num4;
                                object[] objArray1 = objArray;
                                bool[] flagArray = new bool[1];
                                flagArray[0] = true;
                                object obj1 = NewLateBinding.LateGet(this.@struct[Conversions.ToInteger(obj)].values[j].data, null, "Chars", objArray1, null, null, flagArray);
                                if (flagArray[0])
                                {
                                    num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray1[0]), typeof(int));
                                }

                                if (obj1 == null)
                                {
                                    goto Label1;
                                }

                                BinaryWriter binaryWriter1 = binaryWriter;
                                object obj2 = null;
                                string str1 = "Write";
                                object[] objArray2 = new object[1];
                                object[] objectValue1 = objArray2;
                                int num5 = 0;
                                object obj3 = this.@struct[Conversions.ToInteger(obj)].values[j].data;
                                objArray1 = new object[1];
                                objArray1[0] = num4;
                                objArray = objArray1;
                                flagArray = new bool[1];
                                flagArray[0] = true;
                                object obj4 = NewLateBinding.LateGet(obj3, null, "Chars", objArray, null, null, flagArray);
                                if (flagArray[0])
                                {
                                    num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(int));
                                }

                                objectValue1[num5] = RuntimeHelpers.GetObjectValue(obj4);
                                object[] objArray3 = objArray2;
                                bool[] flagArray1 = new bool[1];
                                flagArray1[0] = true;
                                NewLateBinding.LateCall(binaryWriter1, (Type)obj2, str1, objArray3, null, null, flagArray1, true);
                                if (flagArray1[0])
                                {
                                    object[] objectValue2 = new object[2];
                                    objectValue2[0] = num4;
                                    objectValue2[1] = RuntimeHelpers.GetObjectValue(objArray3[0]);
                                    NewLateBinding.LateSetComplex(obj3, null, "Chars", objectValue2, null, null, true, false);
                                    goto Label0;
                                }

                                else
                                {
                                    goto Label0;
                                }

                            }
                        Label1:
                            binaryWriter.Write(num3);
                        Label0:
                            num4++;
                        }

                        while (num4 <= 31);
                    }

                }
                else
                {
                    float single = Conversions.ToSingle(this.@struct[Conversions.ToInteger(obj)].values[j].data);
                    binaryWriter.Write(single);
                }

            }
            binaryWriter.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dataGridViewRow = this.dgv.Rows[e.RowIndex];
                int num = Convert.ToInt32(dataGridViewRow.Tag);
                string text = Conversions.ToString(dataGridViewRow.Cells[0].Value);
                string selectedItem = Conversions.ToString(dataGridViewRow.Cells[1].Value);
                string left = Conversions.ToString(dataGridViewRow.Cells[2].Value);
                bool dep = false;
                if (left.Equals("DEP"))
                {
                    dep = true;
                }

                this.cbClass.SelectedItem = text;
                this.AddNames(text, dep);
                this.cbName.SelectedItem = selectedItem;
                this.btnSwap.Enabled = true;
            }

            catch (Exception expr_B0)
            {
                //ProjectData.SetProjectError(expr_B0);
                //ProjectData.ClearProjectError();
            }

        }
        public void AddNames(string class1, bool dep)
        {
            this.cbName.Items.Clear();
            int arg_2F_0 = 0;
            checked
            {
                int num = this.TagTreeView.Nodes[class1].Nodes.Count - 1;
                for (int i = arg_2F_0; i <= num; i++)
                {
                    this.cbName.Items.Add(this.TagTreeView.Nodes[class1].Nodes[i].Text);
                }

                if (dep)
                {
                    this.cbName.Items.Add("Nulled Out");
                }

                this.cbName.SelectedIndex = 0;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HaloTag haloTag;
            BinaryWriter binaryWriter;
            int num;
            checked
            {
                haloTag = this.TagsCache[(int)Math.Round(Conversion.Val(this.txtIndexOrder.Text))];
                binaryWriter = new BinaryWriter(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Write));
                num = (int)Math.Round(Conversion.Val("&H" + this.txtMetaOffset.Text));
                haloTag.MetaOffset = num;
                num += this.MAP.Magic;
            }

            binaryWriter.BaseStream.Position = (long)checked(haloTag.Offset + 20);
            binaryWriter.Write(num);
            this.TagsCache[haloTag.LoadOrder] = haloTag;
            binaryWriter.Close();
        }

        private void OpenMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Halo Map Files (*.Map)|*.Map";
            openFileDialog.InitialDirectory = "C:\\Program Files\\Microsoft Games\\";
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.OpenMap(openFileDialog.FileName);
            }

        }
        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MyProject.Forms.About1.Show();
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AddNames(this.cbClass.SelectedItem.ToString(), false);
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.Write));
            checked
            {
                if (Operators.ConditionalCompareObjectEqual(this.cbName.SelectedItem, "Nulled Out", false))
                {
                    int arg_48_0 = 0;
                    int num = this.dgv.SelectedRows.Count - 1;
                    for (int i = arg_48_0; i <= num; i++)
                    {
                        int num2 = Convert.ToInt32(this.dgv.SelectedRows[i].Tag);
                        binaryWriter.BaseStream.Position = unchecked((long)num2);
                        int value = -1;
                        binaryWriter.Write(value);
                        this.dgv.SelectedRows[i].Cells[0].Value = this.cbClass.SelectedItem.ToString();
                        this.dgv.SelectedRows[i].Cells[1].Value = this.cbName.SelectedItem.ToString();
                    }

                }
                else
                {
                    HaloTag haloTag = this.TagsCache[Convert.ToInt32(this.TagTreeView.Nodes[this.cbClass.SelectedItem.ToString()].Nodes[this.cbClass.SelectedItem.ToString() + "-" + this.cbName.SelectedItem.ToString()].Tag)];
                    int arg_16F_0 = 0;
                    int num3 = this.dgv.SelectedRows.Count - 1;
                    for (int j = arg_16F_0; j <= num3; j++)
                    {
                        int num4 = Convert.ToInt32(this.dgv.SelectedRows[j].Tag);
                        binaryWriter.BaseStream.Position = unchecked((long)num4);
                        binaryWriter.Write(haloTag.ID);
                        this.dgv.SelectedRows[j].Cells[0].Value = haloTag.Class1;
                        this.dgv.SelectedRows[j].Cells[1].Value = haloTag.Name;
                    }

                }
                binaryWriter.Close();
                Interaction.MsgBox("Swapping done", MsgBoxStyle.Information, "Kablam.");
            }

        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TagTreeView.CollapseAll();
                DataGridViewRow dataGridViewRow = this.dgv.Rows[e.RowIndex];
                string text = Conversions.ToString(dataGridViewRow.Cells[0].Value);
                string str = Conversions.ToString(dataGridViewRow.Cells[1].Value);
                this.TagTreeView.Nodes[text].Expand();
                this.TagTreeView.SelectedNode = this.TagTreeView.Nodes[text].Nodes[text + "-" + str];
            }

            catch (Exception expr_9A)
            {
                //ProjectData.SetProjectError(expr_9A);
                //ProjectData.ClearProjectError();
            }

        }
        private void CloseMap()
        {
            this.clearBoxes();
            this.TagTreeView.Nodes.Clear();
            this.dgv.Rows.Clear();
            this.MetaTab.Controls.Clear();
            this.cbClass.Items.Clear();
            this.cbName.Items.Clear();
            this.cb1.Items.Clear();
            this.cb2.Items.Clear();
            this.cb3.Items.Clear();
            this.btnSwap.Enabled = false;
            this.btnExtract.Enabled = false;
            this.btnSave.Enabled = false;
            this.Text = "Lethargy";
            this.Status.Text = "Patrick H.";
            this.cb1.Text = "";
            this.cb2.Text = "";
            this.cb3.Text = "";
            this.cbClass.Text = "";
            this.cbName.Text = "";
            this.FindTagByIndexOrderToolStripMenuItem.Enabled = false;
            this.ShowTagsOrderToolStripMenuItem.Enabled = false;
        }

        private void CloseMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CloseMap();
        }

        private void clearBoxes()
        {
            int arg_0F_0 = 0;
            checked
            {
                int num = this.Controls.Count - 1;
                for (int i = arg_0F_0; i <= num; i++)
                {
                    if (this.Controls[i] is TextBox)
                    {
                        this.Controls[i].Text = "";
                    }

                    else
                    {
                        int arg_5A_0 = 0;
                        int num2 = this.Controls[i].Controls.Count - 1;
                        for (int j = arg_5A_0; j <= num2; j++)
                        {
                            if (this.Controls[i].Controls[j] is TextBox)
                            {
                                this.Controls[i].Controls[j].Text = "";
                            }

                        }
                    }

                }
            }

        }
        public void Insert(int StartOffset, int Size)
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
            int num;
            byte[] buffer;
            checked
            {
                num = (int)(binaryReader.BaseStream.Length - unchecked((long)StartOffset));
                buffer = new byte[num - 1 + 1];
                binaryReader.BaseStream.Position = unchecked((long)StartOffset);
                binaryReader.Read(buffer, 0, num);
                binaryReader.Close();
                byte value = 0;
                int arg_73_0 = 0;
                int num2 = Size - 1;
                for (int i = arg_73_0; i <= num2; i++)
                {
                    binaryWriter.BaseStream.Position = unchecked((long)checked(StartOffset + i));
                    binaryWriter.Write(value);
                }

            }
            binaryWriter.BaseStream.Position = (long)checked(StartOffset + Size);
            binaryWriter.Write(buffer, 0, num);
            binaryWriter.Close();
        }

        public void AddTag(string metapath, string xmlpath)
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(this.MAP.Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
            XmlTextReader xmlTextReader = new XmlTextReader(xmlpath);
            string text = "";
            string value = Conversions.ToString(0);
            string text2 = "";
            while (xmlTextReader.Read())
            {
                string name = xmlTextReader.Name;
                if (name.Equals("Tagname"))
                {
                    text = xmlTextReader.ReadElementContentAsString();
                    this.Status.Text = "Importing " + text;
                    this.StatusStrip1.Refresh();
                }

                else
                {
                    if (name.Equals("MetaSize"))
                    {
                        value = Conversions.ToString(xmlTextReader.ReadElementContentAsInt());
                    }

                    else
                    {
                        if (name.Equals("Tag"))
                        {
                            text2 = xmlTextReader.ReadElementContentAsString();
                        }

                    }
                }

            }
            int num = Strings.Len(text);
            char[] array;
            checked
            {
                num += 4 - num % 4;
                int arg_101_0 = 0;
                int num2 = this.MAP.TagCount - 1;
                for (int i = arg_101_0; i <= num2; i++)
                {
                    HaloTag haloTag = this.TagsCache[i];
                    if (haloTag.Class1.Equals("sbsp"))
                    {
                        binaryWriter.BaseStream.Position = unchecked((long)checked(haloTag.Offset + 16));
                        binaryWriter.Write(Convert.ToInt32(haloTag.NameOffset + this.MAP.Magic + 32));
                    }

                    else
                    {
                        binaryWriter.BaseStream.Position = unchecked((long)checked(haloTag.Offset + 20));
                        binaryWriter.Write(Convert.ToInt32(haloTag.MetaOffset + 32 + num + this.MAP.Magic));
                        binaryWriter.BaseStream.Position = unchecked((long)checked(haloTag.Offset + 16));
                        binaryWriter.Write(Convert.ToInt32(haloTag.NameOffset + 32 + this.MAP.Magic));
                    }

                }
                int num3 = this.TagsCache[this.MAP.TagCount - 1].Offset + 32;
                int value2 = this.TagsCache[this.MAP.TagCount - 1].ID + 65537;
                int num4 = this.TagsCache[0].MetaOffset + 28;
                long value3 = binaryReader.BaseStream.Length + unchecked((long)num) + 32L;
                this.Insert(num3, 32);
                string text3 = text2.Substring(0, 4);
                string text4 = text2.Substring(4, 4);
                string text5 = text2.Substring(8, 4);
                binaryWriter.BaseStream.Position = unchecked((long)num3);
                binaryWriter.Write(text3.ToCharArray());
                if (text4.Equals(""))
                {
                    binaryWriter.Write(-1);
                }

                else
                {
                    binaryWriter.Write(text4.ToCharArray());
                }

                if (text5.Equals(""))
                {
                    binaryWriter.Write(-1);
                }

                else
                {
                    binaryWriter.Write(text5.ToCharArray());
                }

                binaryWriter.Write(value2);
                binaryWriter.Write(num4 + this.MAP.Magic);
                binaryWriter.Write(value3);
                binaryWriter.Write(0);
                binaryWriter.Write(0);
                this.Insert(num4, num);
                binaryWriter.BaseStream.Position = unchecked((long)num4);
                array = text.ToCharArray();
                binaryWriter.Write(array);
                BinaryReader binaryReader2 = new BinaryReader(new FileStream(metapath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
                binaryReader2.BaseStream.Position = 0L;
                byte[] buffer = new byte[(int)Math.Round(unchecked(Conversions.ToDouble(value) - 1.0)) + 1];
                binaryReader2.Read(buffer, 0, Convert.ToInt32(value));
                binaryWriter.BaseStream.Position = binaryWriter.BaseStream.Length;
                binaryWriter.Write(buffer, 0, Convert.ToInt32(value));
                binaryWriter.BaseStream.Position = unchecked((long)checked(this.MAP.IndexOffset + 12));
                binaryWriter.Write(Convert.ToInt32(this.MAP.TagCount + 1));
                binaryWriter.BaseStream.Position = 20L;
            }

            binaryWriter.Write(Convert.ToInt32((double)this.MAP.TotalMetaSize + Conversions.ToDouble(value)));
            xmlTextReader.Close();
            binaryReader.Close();
            binaryWriter.Close();
            this.OpenMap(this.MAP.Path);
            this.Status.Text = "Done importing " + new string(array);
            Interaction.MsgBox("Butchering is complete", MsgBoxStyle.OkOnly, null);
        }

        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Lethargy extracted meta files (*.meta)|*.meta";
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                string fileName = openFileDialog.FileName;
                string xmlpath = fileName.Remove(checked(Strings.Len(fileName) - 4)) + "xml";
                this.Cursor = Cursors.WaitCursor;
                this.AddTag(fileName, xmlpath);
                this.Cursor = Cursors.Default;
            }

        }
        private void FindTagByIndexOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("Index order:", "Find Tag By Index Order", "0", -1, -1);
            bool flag = true;
            if (flag == !Versioned.IsNumeric(text))
            {
                Interaction.MsgBox("Invalid input, value must be numeric.", MsgBoxStyle.OkOnly, null);
                return;
            }

            checked
            {
                if (flag == Conversions.ToDouble(text) > (double)(this.MAP.TagCount - 1))
                {
                    Interaction.MsgBox("Invalid input, must be less than the tags count of the map minus one.", MsgBoxStyle.OkOnly, null);
                    return;
                }

                if (flag == Conversions.ToDouble(text) < 0.0)
                {
                    Interaction.MsgBox("Invalid input, must be greater than or equal to zero.", MsgBoxStyle.OkOnly, null);
                    return;
                }

                int arg_8C_0 = 0;
                int num = this.MAP.TagCount - 1;
                for (int i = arg_8C_0; i <= num; i++)
                {
                    HaloTag haloTag = this.TagsCache[i];
                    if ((double)haloTag.LoadOrder == Conversions.ToDouble(text))
                    {
                        this.TagTreeView.SelectedNode = this.TagTreeView.Nodes[haloTag.Class1].Nodes[haloTag.Class1 + "-" + haloTag.Name];
                    }

                }
            }

        }
        private void ShowTagsOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Name = "frmOrder";
            Form arg_25_0 = form;
            Size size = new Size(500, 600);
            arg_25_0.Size = size;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.Text = "Tags in order";
            ListBox listBox = new ListBox();
            listBox.Name = "lb";
            Control arg_61_0 = listBox;
            size = new Size(460, 560);
            arg_61_0.Size = size;
            Point location = new Point(10, 10);
            listBox.Location = location;
            form.Controls.Add(listBox);
            listBox.DoubleClick += new EventHandler(this.DoubleClickLB);
            int arg_A7_0 = 0;
            checked
            {
                int num = this.MAP.TagCount - 1;
                for (int i = arg_A7_0; i <= num; i++)
                {
                    HaloTag haloTag = this.TagsCache[i];
                    string item = string.Concat(new string[]
                    {
                        Conversions.ToString(i + 1),
                        ".  ",
                        haloTag.Class1,
                        ": ",
                        haloTag.Name
                    });
                    listBox.Items.Add(item);
                }

                listBox.SelectedIndex = 0;
                form.Show();
            }

        }
        public void DoubleClickLB(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.SelectedIndex;
            HaloTag haloTag = this.TagsCache[selectedIndex];
            this.TagTreeView.SelectedNode = this.TagTreeView.Nodes[haloTag.Class1].Nodes[haloTag.Class1 + "-" + haloTag.Name];
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dataGridViewRow = this.dgv.Rows[this.dgv.SelectedRows[0].Cells[0].RowIndex];
                int num = Convert.ToInt32(dataGridViewRow.Tag);
                string text = Conversions.ToString(dataGridViewRow.Cells[0].Value);
                string selectedItem = Conversions.ToString(dataGridViewRow.Cells[1].Value);
                string left = Conversions.ToString(dataGridViewRow.Cells[2].Value);
                bool dep = false;
                if (left.Equals("DEP"))
                {
                    dep = true;
                }

                this.cbClass.SelectedItem = text;
                this.AddNames(text, dep);
                this.cbName.SelectedItem = selectedItem;
                this.btnSwap.Enabled = true;
            }

            catch (Exception expr_CB)
            {
                //ProjectData.SetProjectError(expr_CB);
                //ProjectData.ClearProjectError();
            }

        }
        private void InsertBlankDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int startOffset = Convert.ToInt32(Interaction.InputBox("Enter the offset (Dec.) at which you would like to insert blank data, or precede hex offsets with '0x'.", "Insert blank data", "", -1, -1).Replace("0x", "&H"));
                int size = Convert.ToInt32(Interaction.InputBox("Enter the number (of bytes you would like to insert", "Insert blank data", "", -1, -1));
                this.Insert(startOffset, size);
                Interaction.MsgBox("Done", MsgBoxStyle.OkOnly, null);
            }

            catch (Exception expr_5E)
            {
                //ProjectData.SetProjectError(expr_5E);
                Exception ex = expr_5E;
                MessageBox.Show(ex.Message);
                //ProjectData.ClearProjectError();
            }

        }
    }

}
