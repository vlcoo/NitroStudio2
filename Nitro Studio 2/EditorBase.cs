using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using GotaSequenceLib;
using GotaSoundIO.IO;
using Multimedia.UI;
using System.Drawing;
using NitroFileLoader;
using GotaSoundBank.SF2;
using GotaSoundBank.DLS;

namespace NitroStudio2 {

    /// <summary>
    /// An editor base for files.
    /// </summary>
    public abstract class EditorBase : Form {

        /// <summary>
        /// File type to use.
        /// </summary>
        public IOFile File;

        /// <summary>
        /// External file.
        /// </summary>
        public IOFile ExtFile;

        /// <summary>
        /// File name.
        /// </summary>
        public string FileName;

        /// <summary>
        /// File path.
        /// </summary>
        public string FilePath;

        /// <summary>
        /// Description of the extension.
        /// </summary>
        public string ExtensionDescription;

        /// <summary>
        /// Extension of format.
        /// </summary>
        public string Extension;

        /// <summary>
        /// Editor name.
        /// </summary>
        public string EditorName;

        /// <summary>
        /// Current file open.
        /// </summary>
        public bool FileOpen;

        /// <summary>
        /// File type.
        /// </summary>
        public Type FileType;

        /// <summary>
        /// Other editor.
        /// </summary>
        public EditorBase OtherEditor;

        /// <summary>
        /// Writing info.
        /// </summary>
        public bool WritingInfo;

        /// <summary>
        /// The current note that is down.
        /// </summary>
        public Notes NoteDown;
        public Panel pnlPianoKeys;
        private Multimedia.UI.PianoKey pkeyC7;
        private Multimedia.UI.PianoKey pkeyE7;
        private Multimedia.UI.PianoKey pkeyCSharp7;
        private Multimedia.UI.PianoKey pkeyD7;
        private Multimedia.UI.PianoKey pkeyDSharp7;
        private Multimedia.UI.PianoKey pkeyF7;
        private Multimedia.UI.PianoKey pkeyFSharp7;
        private Multimedia.UI.PianoKey pkeyG7;
        private Multimedia.UI.PianoKey pkeyGSharp7;
        private Multimedia.UI.PianoKey pkeyA7;
        private Multimedia.UI.PianoKey pkeyASharp7;
        private Multimedia.UI.PianoKey pkeyB7;
        private Multimedia.UI.PianoKey pkeyC6;
        private Multimedia.UI.PianoKey pkeyE6;
        private Multimedia.UI.PianoKey pkeyCSharp6;
        private Multimedia.UI.PianoKey pkeyD6;
        private Multimedia.UI.PianoKey pkeyDSharp6;
        private Multimedia.UI.PianoKey pkeyF6;
        private Multimedia.UI.PianoKey pkeyFSharp6;
        private Multimedia.UI.PianoKey pkeyG6;
        private Multimedia.UI.PianoKey pkeyGSharp6;
        private Multimedia.UI.PianoKey pkeyA6;
        private Multimedia.UI.PianoKey pkeyASharp6;
        private Multimedia.UI.PianoKey pkeyB6;
        private Multimedia.UI.PianoKey pkeyC1;
        private Multimedia.UI.PianoKey pkeyCSharp1;
        private Multimedia.UI.PianoKey pkeyD1;
        private Multimedia.UI.PianoKey pkeyDSharp1;
        private Multimedia.UI.PianoKey pkeyE1;
        private Multimedia.UI.PianoKey pkeyF1;
        private Multimedia.UI.PianoKey pkeyFSharp1;
        private Multimedia.UI.PianoKey pkeyG1;
        private Multimedia.UI.PianoKey pkeyGSharp1;
        private Multimedia.UI.PianoKey pkeyA1;
        private Multimedia.UI.PianoKey pkeyASharp1;
        private Multimedia.UI.PianoKey pkeyB1;
        private Multimedia.UI.PianoKey pkeyC2;
        private Multimedia.UI.PianoKey pkeyCSharp2;
        private Multimedia.UI.PianoKey pkeyD2;
        private Multimedia.UI.PianoKey pkeyDSharp2;
        private Multimedia.UI.PianoKey pkeyE2;
        private Multimedia.UI.PianoKey pkeyF2;
        private Multimedia.UI.PianoKey pkeyFSharp2;
        private Multimedia.UI.PianoKey pkeyG2;
        private Multimedia.UI.PianoKey pkeyGSharp2;
        private Multimedia.UI.PianoKey pkeyA2;
        private Multimedia.UI.PianoKey pkeyASharp2;
        private Multimedia.UI.PianoKey pkeyB2;
        private Multimedia.UI.PianoKey pkeyC3;
        private Multimedia.UI.PianoKey pkeyCSharp3;
        private Multimedia.UI.PianoKey pkeyD3;
        private Multimedia.UI.PianoKey pkeyDSharp3;
        private Multimedia.UI.PianoKey pkeyE3;
        private Multimedia.UI.PianoKey pkeyF3;
        private Multimedia.UI.PianoKey pkeyFSharp3;
        private Multimedia.UI.PianoKey pkeyG3;
        private Multimedia.UI.PianoKey pkeyGSharp3;
        private Multimedia.UI.PianoKey pkeyA3;
        private Multimedia.UI.PianoKey pkeyASharp3;
        private Multimedia.UI.PianoKey pkeyB3;
        private Multimedia.UI.PianoKey pkeyC4;
        private Multimedia.UI.PianoKey pkeyCSharp4;
        private Multimedia.UI.PianoKey pkeyD4;
        private Multimedia.UI.PianoKey pkeyDSharp4;
        private Multimedia.UI.PianoKey pkeyE4;
        private Multimedia.UI.PianoKey pkeyF4;
        private Multimedia.UI.PianoKey pkeyFSharp4;
        private Multimedia.UI.PianoKey pkeyG4;
        private Multimedia.UI.PianoKey pkeyGSharp4;
        private Multimedia.UI.PianoKey pkeyA4;
        private Multimedia.UI.PianoKey pkeyASharp4;
        private Multimedia.UI.PianoKey pkeyB4;
        private Multimedia.UI.PianoKey pkeyC5;
        private Multimedia.UI.PianoKey pkeyCSharp5;
        private Multimedia.UI.PianoKey pkeyD5;
        private Multimedia.UI.PianoKey pkeyDSharp5;
        private Multimedia.UI.PianoKey pkeyE5;
        private Multimedia.UI.PianoKey pkeyF5;
        private Multimedia.UI.PianoKey pkeyFSharp5;
        private Multimedia.UI.PianoKey pkeyG5;
        private Multimedia.UI.PianoKey pkeyGSharp5;
        private Multimedia.UI.PianoKey pkeyA5;
        private Multimedia.UI.PianoKey pkeyASharp5;
        private Multimedia.UI.PianoKey pkeyB5;
        private Multimedia.UI.PianoKey pkeyC8;
        public ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem getHelpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutNitroStudio2ToolStripMenuItem;
        private ToolStripMenuItem bankGeneratorToolStripMenuItem;
        private ToolStripMenuItem exportSDKProjectToolStripMenuItem;
        public Panel settingsPanel;
        private Label label2;
        public CheckBox writeNamesBox;
        private Label label3;
        public ComboBox seqImportModeBox;
        public ComboBox seqExportModeBox;
        private Label label4;
        public Panel indexPanel;
        private Label label5;
        public NumericUpDown itemIndexBox;
        public Button swapAtIndexButton;
        public Panel forceUniqueFilePanel;
        public CheckBox forceUniqueFileBox;
        private Label label8;
        public Panel warPanel;
        public CheckBox loadIndividuallyBox;
        private Label label9;
        public Panel blankPanel;
        public Panel bankPanel;
        private TableLayoutPanel tableLayoutPanel2;
        public ComboBox bnkWar0ComboBox;
        private Label label6;
        public NumericUpDown bnkWar0Box;
        private TableLayoutPanel tableLayoutPanel5;
        public ComboBox bnkWar3ComboBox;
        public NumericUpDown bnkWar3Box;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel4;
        public ComboBox bnkWar2ComboBox;
        public NumericUpDown bnkWar2Box;
        private Label label10;
        private TableLayoutPanel tableLayoutPanel3;
        public ComboBox bnkWar1ComboBox;
        public NumericUpDown bnkWar1Box;
        private Label label7;
        public Panel grpPanel;
        public DataGridView grpEntries;
        private DataGridViewComboBoxColumn item;
        private DataGridViewComboBoxColumn loadFlags;
        public Panel streamPlayerPanel;
        private TableLayoutPanel tableLayoutPanel6;
        public Label leftChannelLabel;
        public ComboBox stmPlayerChannelType;
        private Label label12;
        public Label rightChannelLabel;
        public NumericUpDown stmPlayerLeftChannelBox;
        public NumericUpDown stmPlayerRightChannelBox;
        public Panel stmPanel;
        private Label label13;
        public NumericUpDown stmPriorityBox;
        private Label label14;
        public NumericUpDown stmVolumeBox;
        private Label label15;
        private TableLayoutPanel tableLayoutPanel7;
        public ComboBox stmPlayerComboBox;
        public NumericUpDown stmPlayerBox;
        public CheckBox stmMonoToStereoBox;
        private Label label16;
        public Panel playerPanel;
        public NumericUpDown playerMaxSequencesBox;
        private Label label17;
        public NumericUpDown playerHeapSizeBox;
        private Label label18;
        private Label label19;
        private TableLayoutPanel tableLayoutPanel8;
        public CheckBox playerFlag15Box;
        public CheckBox playerFlag14Box;
        public CheckBox playerFlag13Box;
        public CheckBox playerFlag12Box;
        public CheckBox playerFlag11Box;
        public CheckBox playerFlag10Box;
        public CheckBox playerFlag9Box;
        public CheckBox playerFlag8Box;
        public CheckBox playerFlag7Box;
        public CheckBox playerFlag6Box;
        public CheckBox playerFlag5Box;
        public CheckBox playerFlag4Box;
        public CheckBox playerFlag3Box;
        public CheckBox playerFlag2Box;
        public CheckBox playerFlag1Box;
        public CheckBox playerFlag0Box;
        public Panel kermalisSoundPlayerPanel;
        public Label soundPlayerLabel;
        private TableLayoutPanel tableLayoutPanel9;
        public Button kermalisStopButton;
        public Button kermalisPauseButton;
        public TrackBar kermalisVolumeSlider;
        public Button kermalisPlayButton;
        private Label label21;
        public CheckBox kermalisLoopBox;
        private Label label22;
        public Panel seqPanel;
        private Label label23;
        private TableLayoutPanel tableLayoutPanel10;
        public ComboBox seqBankComboBox;
        public NumericUpDown seqBankBox;
        private Label label24;
        public NumericUpDown seqVolumeBox;
        public NumericUpDown seqChannelPriorityBox;
        private Label label25;
        public NumericUpDown seqPlayerPriorityBox;
        private Label label26;
        private Label label27;
        private TableLayoutPanel tableLayoutPanel11;
        public ComboBox seqPlayerComboBox;
        public NumericUpDown seqPlayerBox;
        public Panel seqBankPanel;
        private Label label28;
        private TableLayoutPanel tableLayoutPanel12;
        public ComboBox seqEditorBankComboBox;
        public NumericUpDown seqEditorBankBox;
        public Panel seqArcPanel;
        public Button seqArcOpenFileButton;
        public Panel seqArcSeqPanel;
        private Label label29;
        private TableLayoutPanel tableLayoutPanel13;
        public ComboBox seqArcSeqComboBox;
        public NumericUpDown seqArcSeqBox;
        public Panel bankEditorPanel;
        private Label label30;
        private TableLayoutPanel tableLayoutPanel14;
        public RadioButton directBox;
        public RadioButton keySplitBox;
        public RadioButton drumSetBox;
        public Label drumSetRangeStartLabel;
        private TableLayoutPanel tableLayoutPanel15;
        public ComboBox drumSetStartRangeComboBox;
        public NumericUpDown drumSetStartRangeBox;
        private Label label32;
        public DataGridView bankRegions;
        public Panel bankEditorWars;
        private TableLayoutPanel tableLayoutPanel16;
        public ComboBox war3ComboBox;
        public NumericUpDown war3Box;
        private Label label31;
        private TableLayoutPanel tableLayoutPanel17;
        public ComboBox war2ComboBox;
        public NumericUpDown war2Box;
        private Label label33;
        private TableLayoutPanel tableLayoutPanel18;
        public ComboBox war1ComboBox;
        public NumericUpDown war1Box;
        private Label label34;
        private TableLayoutPanel tableLayoutPanel19;
        public ComboBox war0ComboBox;
        public NumericUpDown war0Box;
        private Label label35;
        private ToolStripMenuItem sequenceEditorToolStripMenuItem;
        private ToolStripMenuItem sequenceArchiveEditorToolStripMenuItem;
        private ToolStripMenuItem bankEditorToolStripMenuItem;
        private ToolStripMenuItem createStreamToolStripMenuItem;
        private ToolStripMenuItem creaveWaveToolStripMenuItem;
        private ToolStripMenuItem waveArchiveEditorToolStripMenuItem;
        public ToolStripStatusLabel currentNote;
        private TableLayoutPanel tableLayoutPanel1;
        public CheckBox track0Box;
        public PictureBox track0Picture;
        public Button track0Solo;
        private TableLayoutPanel tableLayoutPanel20;
        private TableLayoutPanel tableLayoutPanel27;
        public CheckBox track12Box;
        public PictureBox track12Picture;
        public Button track12Solo;
        private TableLayoutPanel tableLayoutPanel26;
        public CheckBox track10Box;
        public PictureBox track10Picture;
        public Button track10Solo;
        private TableLayoutPanel tableLayoutPanel25;
        public CheckBox track8Box;
        public PictureBox track8Picture;
        public Button track8Solo;
        private TableLayoutPanel tableLayoutPanel24;
        public CheckBox track6Box;
        public PictureBox track6Picture;
        public Button track6Solo;
        private TableLayoutPanel tableLayoutPanel23;
        public CheckBox track4Box;
        public PictureBox track4Picture;
        public Button track4Solo;
        private TableLayoutPanel tableLayoutPanel22;
        public CheckBox track2Box;
        public PictureBox track2Picture;
        public Button track2Solo;
        private TableLayoutPanel tableLayoutPanel21;
        public CheckBox track1Box;
        public PictureBox track1Picture;
        public Button track1Solo;
        private TableLayoutPanel tableLayoutPanel35;
        public CheckBox track15Box;
        public PictureBox track15Picture;
        public Button track15Solo;
        private TableLayoutPanel tableLayoutPanel34;
        public CheckBox track13Box;
        public PictureBox track13Picture;
        public Button track13Solo;
        private TableLayoutPanel tableLayoutPanel33;
        public CheckBox track11Box;
        public PictureBox track11Picture;
        public Button track11Solo;
        private TableLayoutPanel tableLayoutPanel32;
        public CheckBox track9Box;
        public PictureBox track9Picture;
        public Button track9Solo;
        private TableLayoutPanel tableLayoutPanel31;
        public CheckBox track7Box;
        public PictureBox track7Picture;
        public Button track7Solo;
        private TableLayoutPanel tableLayoutPanel30;
        public CheckBox track5Box;
        public PictureBox track5Picture;
        public Button track5Solo;
        private TableLayoutPanel tableLayoutPanel29;
        public CheckBox track3Box;
        public PictureBox track3Picture;
        public Button track3Solo;
        private TableLayoutPanel tableLayoutPanel28;
        public CheckBox track14Box;
        public PictureBox track14Picture;
        public Button track14Solo;
        private DataGridViewButtonColumn playSampleButton;
        private DataGridViewComboBoxColumn endNote;
        private DataGridViewComboBoxColumn instrumentType;
        private DataGridViewTextBoxColumn waveId;
        private DataGridViewTextBoxColumn waveArchiveId;
        private DataGridViewComboBoxColumn baseNote;
        private DataGridViewTextBoxColumn attack;
        private DataGridViewTextBoxColumn decay;
        private DataGridViewTextBoxColumn sustain;
        private DataGridViewTextBoxColumn release;
        private DataGridViewTextBoxColumn pan;
        private ToolStripMenuItem sF2ToDLSToolStripMenuItem;
        private ToolStripMenuItem dLSToSF2ToolStripMenuItem;
        public TrackBar kermalisPosition;
        private ToolStripMenuItem batchExportMIDIDLSSF2ToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel36;
        public Button exportWavButton;
        public Button exportMidiButton;

        /// <summary>
        /// Main window.
        /// </summary>
        public static MainWindow MainWindow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileType">Type of file.</param>
        /// <param name="extensionDescription">Description of the extension.</param>
        /// <param name="extension">File extension type.</param>
        /// <param name="editorName">Editor name.</param>
        /// <param name="mainWindow">Main window.</param>
        public EditorBase(Type fileType, string extensionDescription, string extension, string editorName, MainWindow mainWindow) {

            //Initialize component.
            InitializeComponent();

            //Set main window.
            MainWindow = mainWindow;

            //Set file type.
            FileType = fileType;

            //Extension description.
            ExtensionDescription = extensionDescription;

            //Extension.
            Extension = extension;

            //Editor name.
            EditorName = editorName;
            Text = EditorName;

            //Update nodes.
            UpdateNodes();

            //Do info stuff.
            DoInfoStuff();

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileType">Type of file.</param>
        /// <param name="extensionDescription">Description of the extension.</param>
        /// <param name="extension">File extension type.</param>
        /// <param name="editorName">Editor name.</param>
        /// <param name="fileToOpen">File to open.</param>
        /// <param name="mainWindow">Main window.</param>
        public EditorBase(Type fileType, string extensionDescription, string extension, string editorName, string fileToOpen, MainWindow mainWindow) {

            //Initialize component.
            InitializeComponent();

            //Set main window.
            MainWindow = mainWindow;

            //Set file type.
            FileType = fileType;

            //Extension description.
            ExtensionDescription = extensionDescription;

            //Extension.
            Extension = extension;

            //Editor name.
            EditorName = editorName;

            //Open file.
            File = (IOFile)Activator.CreateInstance(FileType);
            FilePath = fileToOpen;
            Text = EditorName + " - " + Path.GetFileName(fileToOpen);
            FileOpen = true;
            FileName = Path.GetFileNameWithoutExtension(FilePath);

            //Read data.
            File.Read(fileToOpen);

            //Update.
            UpdateNodes();
            DoInfoStuff();

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileType">Type of file.</param>
        /// <param name="extensionDescription">Description of the extension.</param>
        /// <param name="extension">File extension type.</param>
        /// <param name="editorName">Editor name.</param>
        /// <param name="fileToOpen">File to open.</param>
        /// <param name="mainWindow">Main window.</param>
        /// <param name="fileName">Filename.</param>
        public EditorBase(Type fileType, string extensionDescription, string extension, string editorName, IOFile fileToOpen, MainWindow mainWindow, string fileName) {

            //Initialize component.
            InitializeComponent();

            //Set main window.
            MainWindow = mainWindow;

            //Set file type.
            FileType = fileType;

            //Extension description.
            ExtensionDescription = extensionDescription;

            //Extension.
            Extension = extension;

            //Editor name.
            EditorName = editorName;

            //Open file.
            ExtFile = fileToOpen;
            File = (IOFile)Activator.CreateInstance(ExtFile.GetType());
            File.Read(ExtFile.Write());
            FilePath = "";
            string name = fileName;
            if (name == null) {
                name = "{ Null File Name }";
            }
            Text = EditorName + " - " + name + ".s" + extension;
            FileOpen = true;
            FileName = fileName;

            //Update.
            UpdateNodes();
            DoInfoStuff();

        }
        public MenuStrip menuStrip;
        public ToolStripMenuItem newToolStripMenuItem;
        public ToolStripMenuItem openToolStripMenuItem;
        public ToolStripMenuItem saveToolStripMenuItem;
        public ToolStripMenuItem saveAsToolStripMenuItem;
        public ToolStripMenuItem closeToolStripMenuItem;
        public ToolStripMenuItem quitToolStripMenuItem;
        public ToolStripMenuItem editToolStripMenuItem;
        public ToolStripMenuItem blankFileToolStripMenuItem;
        public ToolStripMenuItem importFileToolStripMenuItem;
        public ToolStripMenuItem exportFileToolStripMenuItem;
        public SplitContainer splitContainer1;
        public TreeView tree;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private StatusStrip statusStrip;
        public ToolStripStatusLabel status;
        public ImageList treeIcons;
        private System.ComponentModel.IContainer components;
        public ContextMenuStrip rootMenu;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem expandToolStripMenuItem;
        private ToolStripMenuItem collapseToolStripMenuItem;
        public Panel noInfoPanel;
        private Label label1;
        private ToolTip toolTip;
        public ToolStripMenuItem fileMenu;
        public ContextMenuStrip nodeMenu;
        private ToolStripMenuItem addAboveToolStripMenuItem1;
        private ToolStripMenuItem addBelowToolStripMenuItem1;
        private ToolStripMenuItem moveUpToolStripMenuItem1;
        private ToolStripMenuItem moveDownToolStripMenuItem1;
        private ToolStripMenuItem replaceFileToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem1;
        public Panel sequenceEditorPanel;
        private BindingSource bindingSource1;
        public ContextMenuStrip sarEntryMenu;
        private ToolStripMenuItem sarAddAbove;
        private ToolStripMenuItem sarAddBelow;
        private ToolStripMenuItem sarMoveUp;
        private ToolStripMenuItem sarMoveDown;
        private ToolStripMenuItem sarReplace;
        private ToolStripMenuItem sarExport;
        private ToolStripMenuItem sarRename;
        private ToolStripMenuItem sarDelete;

        public void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorBase));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("File Information", 10, 10);
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            blankFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sequenceEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sequenceArchiveEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bankEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            waveArchiveEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bankGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            creaveWaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            createStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportSDKProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sF2ToDLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dLSToSF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            batchExportMIDIDLSSF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            getHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutNitroStudio2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            seqBankPanel = new System.Windows.Forms.Panel();
            tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            exportWavButton = new System.Windows.Forms.Button();
            exportMidiButton = new System.Windows.Forms.Button();
            tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            track15Box = new System.Windows.Forms.CheckBox();
            track15Picture = new System.Windows.Forms.PictureBox();
            track15Solo = new System.Windows.Forms.Button();
            tableLayoutPanel34 = new System.Windows.Forms.TableLayoutPanel();
            track13Box = new System.Windows.Forms.CheckBox();
            track13Picture = new System.Windows.Forms.PictureBox();
            track13Solo = new System.Windows.Forms.Button();
            tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            track11Box = new System.Windows.Forms.CheckBox();
            track11Picture = new System.Windows.Forms.PictureBox();
            track11Solo = new System.Windows.Forms.Button();
            tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            track9Box = new System.Windows.Forms.CheckBox();
            track9Picture = new System.Windows.Forms.PictureBox();
            track9Solo = new System.Windows.Forms.Button();
            tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            track7Box = new System.Windows.Forms.CheckBox();
            track7Picture = new System.Windows.Forms.PictureBox();
            track7Solo = new System.Windows.Forms.Button();
            tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            track5Box = new System.Windows.Forms.CheckBox();
            track5Picture = new System.Windows.Forms.PictureBox();
            track5Solo = new System.Windows.Forms.Button();
            tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            track3Box = new System.Windows.Forms.CheckBox();
            track3Picture = new System.Windows.Forms.PictureBox();
            track3Solo = new System.Windows.Forms.Button();
            tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            track14Box = new System.Windows.Forms.CheckBox();
            track14Picture = new System.Windows.Forms.PictureBox();
            track14Solo = new System.Windows.Forms.Button();
            tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            track12Box = new System.Windows.Forms.CheckBox();
            track12Picture = new System.Windows.Forms.PictureBox();
            track12Solo = new System.Windows.Forms.Button();
            tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            track10Box = new System.Windows.Forms.CheckBox();
            track10Picture = new System.Windows.Forms.PictureBox();
            track10Solo = new System.Windows.Forms.Button();
            tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            track8Box = new System.Windows.Forms.CheckBox();
            track8Picture = new System.Windows.Forms.PictureBox();
            track8Solo = new System.Windows.Forms.Button();
            tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            track6Box = new System.Windows.Forms.CheckBox();
            track6Picture = new System.Windows.Forms.PictureBox();
            track6Solo = new System.Windows.Forms.Button();
            tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            track4Box = new System.Windows.Forms.CheckBox();
            track4Picture = new System.Windows.Forms.PictureBox();
            track4Solo = new System.Windows.Forms.Button();
            tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            track2Box = new System.Windows.Forms.CheckBox();
            track2Picture = new System.Windows.Forms.PictureBox();
            track2Solo = new System.Windows.Forms.Button();
            tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            track1Box = new System.Windows.Forms.CheckBox();
            track1Picture = new System.Windows.Forms.PictureBox();
            track1Solo = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            track0Box = new System.Windows.Forms.CheckBox();
            track0Picture = new System.Windows.Forms.PictureBox();
            track0Solo = new System.Windows.Forms.Button();
            label28 = new System.Windows.Forms.Label();
            tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            seqEditorBankComboBox = new System.Windows.Forms.ComboBox();
            seqEditorBankBox = new System.Windows.Forms.NumericUpDown();
            bankEditorPanel = new System.Windows.Forms.Panel();
            bankRegions = new System.Windows.Forms.DataGridView();
            playSampleButton = new System.Windows.Forms.DataGridViewButtonColumn();
            endNote = new System.Windows.Forms.DataGridViewComboBoxColumn();
            instrumentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            waveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            waveArchiveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            baseNote = new System.Windows.Forms.DataGridViewComboBoxColumn();
            attack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            decay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sustain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            release = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label32 = new System.Windows.Forms.Label();
            tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            drumSetStartRangeComboBox = new System.Windows.Forms.ComboBox();
            drumSetStartRangeBox = new System.Windows.Forms.NumericUpDown();
            drumSetRangeStartLabel = new System.Windows.Forms.Label();
            tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            keySplitBox = new System.Windows.Forms.RadioButton();
            drumSetBox = new System.Windows.Forms.RadioButton();
            directBox = new System.Windows.Forms.RadioButton();
            label30 = new System.Windows.Forms.Label();
            seqArcSeqPanel = new System.Windows.Forms.Panel();
            label29 = new System.Windows.Forms.Label();
            tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            seqArcSeqComboBox = new System.Windows.Forms.ComboBox();
            seqArcSeqBox = new System.Windows.Forms.NumericUpDown();
            seqArcPanel = new System.Windows.Forms.Panel();
            seqArcOpenFileButton = new System.Windows.Forms.Button();
            seqPanel = new System.Windows.Forms.Panel();
            tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            seqPlayerComboBox = new System.Windows.Forms.ComboBox();
            seqPlayerBox = new System.Windows.Forms.NumericUpDown();
            label27 = new System.Windows.Forms.Label();
            seqPlayerPriorityBox = new System.Windows.Forms.NumericUpDown();
            label26 = new System.Windows.Forms.Label();
            seqChannelPriorityBox = new System.Windows.Forms.NumericUpDown();
            label25 = new System.Windows.Forms.Label();
            seqVolumeBox = new System.Windows.Forms.NumericUpDown();
            label24 = new System.Windows.Forms.Label();
            tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            seqBankComboBox = new System.Windows.Forms.ComboBox();
            seqBankBox = new System.Windows.Forms.NumericUpDown();
            label23 = new System.Windows.Forms.Label();
            playerPanel = new System.Windows.Forms.Panel();
            tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            playerFlag15Box = new System.Windows.Forms.CheckBox();
            playerFlag14Box = new System.Windows.Forms.CheckBox();
            playerFlag13Box = new System.Windows.Forms.CheckBox();
            playerFlag12Box = new System.Windows.Forms.CheckBox();
            playerFlag11Box = new System.Windows.Forms.CheckBox();
            playerFlag10Box = new System.Windows.Forms.CheckBox();
            playerFlag9Box = new System.Windows.Forms.CheckBox();
            playerFlag8Box = new System.Windows.Forms.CheckBox();
            playerFlag7Box = new System.Windows.Forms.CheckBox();
            playerFlag6Box = new System.Windows.Forms.CheckBox();
            playerFlag5Box = new System.Windows.Forms.CheckBox();
            playerFlag4Box = new System.Windows.Forms.CheckBox();
            playerFlag3Box = new System.Windows.Forms.CheckBox();
            playerFlag2Box = new System.Windows.Forms.CheckBox();
            playerFlag1Box = new System.Windows.Forms.CheckBox();
            playerFlag0Box = new System.Windows.Forms.CheckBox();
            label19 = new System.Windows.Forms.Label();
            playerHeapSizeBox = new System.Windows.Forms.NumericUpDown();
            label18 = new System.Windows.Forms.Label();
            playerMaxSequencesBox = new System.Windows.Forms.NumericUpDown();
            label17 = new System.Windows.Forms.Label();
            stmPanel = new System.Windows.Forms.Panel();
            stmMonoToStereoBox = new System.Windows.Forms.CheckBox();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            stmPlayerComboBox = new System.Windows.Forms.ComboBox();
            stmPlayerBox = new System.Windows.Forms.NumericUpDown();
            stmPriorityBox = new System.Windows.Forms.NumericUpDown();
            label14 = new System.Windows.Forms.Label();
            stmVolumeBox = new System.Windows.Forms.NumericUpDown();
            label13 = new System.Windows.Forms.Label();
            streamPlayerPanel = new System.Windows.Forms.Panel();
            stmPlayerChannelType = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            stmPlayerLeftChannelBox = new System.Windows.Forms.NumericUpDown();
            stmPlayerRightChannelBox = new System.Windows.Forms.NumericUpDown();
            rightChannelLabel = new System.Windows.Forms.Label();
            leftChannelLabel = new System.Windows.Forms.Label();
            grpPanel = new System.Windows.Forms.Panel();
            grpEntries = new System.Windows.Forms.DataGridView();
            item = new System.Windows.Forms.DataGridViewComboBoxColumn();
            loadFlags = new System.Windows.Forms.DataGridViewComboBoxColumn();
            bankPanel = new System.Windows.Forms.Panel();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            bnkWar3ComboBox = new System.Windows.Forms.ComboBox();
            bnkWar3Box = new System.Windows.Forms.NumericUpDown();
            label11 = new System.Windows.Forms.Label();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            bnkWar2ComboBox = new System.Windows.Forms.ComboBox();
            bnkWar2Box = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            bnkWar1ComboBox = new System.Windows.Forms.ComboBox();
            bnkWar1Box = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            bnkWar0ComboBox = new System.Windows.Forms.ComboBox();
            bnkWar0Box = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            blankPanel = new System.Windows.Forms.Panel();
            warPanel = new System.Windows.Forms.Panel();
            loadIndividuallyBox = new System.Windows.Forms.CheckBox();
            label9 = new System.Windows.Forms.Label();
            forceUniqueFilePanel = new System.Windows.Forms.Panel();
            forceUniqueFileBox = new System.Windows.Forms.CheckBox();
            label8 = new System.Windows.Forms.Label();
            indexPanel = new System.Windows.Forms.Panel();
            swapAtIndexButton = new System.Windows.Forms.Button();
            itemIndexBox = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            settingsPanel = new System.Windows.Forms.Panel();
            seqExportModeBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            seqImportModeBox = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            writeNamesBox = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            noInfoPanel = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            kermalisSoundPlayerPanel = new System.Windows.Forms.Panel();
            kermalisPosition = new System.Windows.Forms.TrackBar();
            tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            label22 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            kermalisStopButton = new System.Windows.Forms.Button();
            kermalisPauseButton = new System.Windows.Forms.Button();
            kermalisVolumeSlider = new System.Windows.Forms.TrackBar();
            kermalisLoopBox = new System.Windows.Forms.CheckBox();
            kermalisPlayButton = new System.Windows.Forms.Button();
            soundPlayerLabel = new System.Windows.Forms.Label();
            pnlPianoKeys = new System.Windows.Forms.Panel();
            pkeyC7 = new Multimedia.UI.PianoKey();
            pkeyE7 = new Multimedia.UI.PianoKey();
            pkeyCSharp7 = new Multimedia.UI.PianoKey();
            pkeyD7 = new Multimedia.UI.PianoKey();
            pkeyDSharp7 = new Multimedia.UI.PianoKey();
            pkeyF7 = new Multimedia.UI.PianoKey();
            pkeyFSharp7 = new Multimedia.UI.PianoKey();
            pkeyG7 = new Multimedia.UI.PianoKey();
            pkeyGSharp7 = new Multimedia.UI.PianoKey();
            pkeyA7 = new Multimedia.UI.PianoKey();
            pkeyASharp7 = new Multimedia.UI.PianoKey();
            pkeyB7 = new Multimedia.UI.PianoKey();
            pkeyC6 = new Multimedia.UI.PianoKey();
            pkeyE6 = new Multimedia.UI.PianoKey();
            pkeyCSharp6 = new Multimedia.UI.PianoKey();
            pkeyD6 = new Multimedia.UI.PianoKey();
            pkeyDSharp6 = new Multimedia.UI.PianoKey();
            pkeyF6 = new Multimedia.UI.PianoKey();
            pkeyFSharp6 = new Multimedia.UI.PianoKey();
            pkeyG6 = new Multimedia.UI.PianoKey();
            pkeyGSharp6 = new Multimedia.UI.PianoKey();
            pkeyA6 = new Multimedia.UI.PianoKey();
            pkeyASharp6 = new Multimedia.UI.PianoKey();
            pkeyB6 = new Multimedia.UI.PianoKey();
            pkeyC1 = new Multimedia.UI.PianoKey();
            pkeyCSharp1 = new Multimedia.UI.PianoKey();
            pkeyD1 = new Multimedia.UI.PianoKey();
            pkeyDSharp1 = new Multimedia.UI.PianoKey();
            pkeyE1 = new Multimedia.UI.PianoKey();
            pkeyF1 = new Multimedia.UI.PianoKey();
            pkeyFSharp1 = new Multimedia.UI.PianoKey();
            pkeyG1 = new Multimedia.UI.PianoKey();
            pkeyGSharp1 = new Multimedia.UI.PianoKey();
            pkeyA1 = new Multimedia.UI.PianoKey();
            pkeyASharp1 = new Multimedia.UI.PianoKey();
            pkeyB1 = new Multimedia.UI.PianoKey();
            pkeyC2 = new Multimedia.UI.PianoKey();
            pkeyCSharp2 = new Multimedia.UI.PianoKey();
            pkeyD2 = new Multimedia.UI.PianoKey();
            pkeyDSharp2 = new Multimedia.UI.PianoKey();
            pkeyE2 = new Multimedia.UI.PianoKey();
            pkeyF2 = new Multimedia.UI.PianoKey();
            pkeyFSharp2 = new Multimedia.UI.PianoKey();
            pkeyG2 = new Multimedia.UI.PianoKey();
            pkeyGSharp2 = new Multimedia.UI.PianoKey();
            pkeyA2 = new Multimedia.UI.PianoKey();
            pkeyASharp2 = new Multimedia.UI.PianoKey();
            pkeyB2 = new Multimedia.UI.PianoKey();
            pkeyC3 = new Multimedia.UI.PianoKey();
            pkeyCSharp3 = new Multimedia.UI.PianoKey();
            pkeyD3 = new Multimedia.UI.PianoKey();
            pkeyDSharp3 = new Multimedia.UI.PianoKey();
            pkeyE3 = new Multimedia.UI.PianoKey();
            pkeyF3 = new Multimedia.UI.PianoKey();
            pkeyFSharp3 = new Multimedia.UI.PianoKey();
            pkeyG3 = new Multimedia.UI.PianoKey();
            pkeyGSharp3 = new Multimedia.UI.PianoKey();
            pkeyA3 = new Multimedia.UI.PianoKey();
            pkeyASharp3 = new Multimedia.UI.PianoKey();
            pkeyB3 = new Multimedia.UI.PianoKey();
            pkeyC4 = new Multimedia.UI.PianoKey();
            pkeyCSharp4 = new Multimedia.UI.PianoKey();
            pkeyD4 = new Multimedia.UI.PianoKey();
            pkeyDSharp4 = new Multimedia.UI.PianoKey();
            pkeyE4 = new Multimedia.UI.PianoKey();
            pkeyF4 = new Multimedia.UI.PianoKey();
            pkeyFSharp4 = new Multimedia.UI.PianoKey();
            pkeyG4 = new Multimedia.UI.PianoKey();
            pkeyGSharp4 = new Multimedia.UI.PianoKey();
            pkeyA4 = new Multimedia.UI.PianoKey();
            pkeyASharp4 = new Multimedia.UI.PianoKey();
            pkeyB4 = new Multimedia.UI.PianoKey();
            pkeyC5 = new Multimedia.UI.PianoKey();
            pkeyCSharp5 = new Multimedia.UI.PianoKey();
            pkeyD5 = new Multimedia.UI.PianoKey();
            pkeyDSharp5 = new Multimedia.UI.PianoKey();
            pkeyE5 = new Multimedia.UI.PianoKey();
            pkeyF5 = new Multimedia.UI.PianoKey();
            pkeyFSharp5 = new Multimedia.UI.PianoKey();
            pkeyG5 = new Multimedia.UI.PianoKey();
            pkeyGSharp5 = new Multimedia.UI.PianoKey();
            pkeyA5 = new Multimedia.UI.PianoKey();
            pkeyASharp5 = new Multimedia.UI.PianoKey();
            pkeyB5 = new Multimedia.UI.PianoKey();
            pkeyC8 = new Multimedia.UI.PianoKey();
            bankEditorWars = new System.Windows.Forms.Panel();
            tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            war3ComboBox = new System.Windows.Forms.ComboBox();
            war3Box = new System.Windows.Forms.NumericUpDown();
            label31 = new System.Windows.Forms.Label();
            tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            war2ComboBox = new System.Windows.Forms.ComboBox();
            war2Box = new System.Windows.Forms.NumericUpDown();
            label33 = new System.Windows.Forms.Label();
            tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            war1ComboBox = new System.Windows.Forms.ComboBox();
            war1Box = new System.Windows.Forms.NumericUpDown();
            label34 = new System.Windows.Forms.Label();
            tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            war0ComboBox = new System.Windows.Forms.ComboBox();
            war0Box = new System.Windows.Forms.NumericUpDown();
            label35 = new System.Windows.Forms.Label();
            tree = new System.Windows.Forms.TreeView();
            treeIcons = new System.Windows.Forms.ImageList(this.components);
            sequenceEditorPanel = new System.Windows.Forms.Panel();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            statusStrip = new System.Windows.Forms.StatusStrip();
            status = new System.Windows.Forms.ToolStripStatusLabel();
            currentNote = new System.Windows.Forms.ToolStripStatusLabel();
            rootMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolTip = new System.Windows.Forms.ToolTip(this.components);
            nodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            addAboveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            addBelowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            moveUpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            moveDownToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            replaceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            sarEntryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            sarAddAbove = new System.Windows.Forms.ToolStripMenuItem();
            sarAddBelow = new System.Windows.Forms.ToolStripMenuItem();
            sarMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            sarMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            sarReplace = new System.Windows.Forms.ToolStripMenuItem();
            sarExport = new System.Windows.Forms.ToolStripMenuItem();
            sarRename = new System.Windows.Forms.ToolStripMenuItem();
            sarDelete = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            seqBankPanel.SuspendLayout();
            tableLayoutPanel36.SuspendLayout();
            tableLayoutPanel20.SuspendLayout();
            tableLayoutPanel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track15Picture)).BeginInit();
            tableLayoutPanel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track13Picture)).BeginInit();
            tableLayoutPanel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track11Picture)).BeginInit();
            tableLayoutPanel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track9Picture)).BeginInit();
            tableLayoutPanel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track7Picture)).BeginInit();
            tableLayoutPanel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track5Picture)).BeginInit();
            tableLayoutPanel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track3Picture)).BeginInit();
            tableLayoutPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track14Picture)).BeginInit();
            tableLayoutPanel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track12Picture)).BeginInit();
            tableLayoutPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track10Picture)).BeginInit();
            tableLayoutPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track8Picture)).BeginInit();
            tableLayoutPanel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track6Picture)).BeginInit();
            tableLayoutPanel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track4Picture)).BeginInit();
            tableLayoutPanel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track2Picture)).BeginInit();
            tableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track1Picture)).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track0Picture)).BeginInit();
            tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seqEditorBankBox)).BeginInit();
            bankEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankRegions)).BeginInit();
            tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drumSetStartRangeBox)).BeginInit();
            tableLayoutPanel14.SuspendLayout();
            seqArcSeqPanel.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seqArcSeqBox)).BeginInit();
            seqArcPanel.SuspendLayout();
            seqPanel.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seqPlayerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seqPlayerPriorityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seqChannelPriorityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seqVolumeBox)).BeginInit();
            tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seqBankBox)).BeginInit();
            playerPanel.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerHeapSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerMaxSequencesBox)).BeginInit();
            stmPanel.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stmPlayerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stmPriorityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stmVolumeBox)).BeginInit();
            streamPlayerPanel.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stmPlayerLeftChannelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stmPlayerRightChannelBox)).BeginInit();
            grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEntries)).BeginInit();
            bankPanel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar3Box)).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar2Box)).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar1Box)).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar0Box)).BeginInit();
            warPanel.SuspendLayout();
            forceUniqueFilePanel.SuspendLayout();
            indexPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemIndexBox)).BeginInit();
            settingsPanel.SuspendLayout();
            noInfoPanel.SuspendLayout();
            kermalisSoundPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kermalisPosition)).BeginInit();
            tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kermalisVolumeSlider)).BeginInit();
            pnlPianoKeys.SuspendLayout();
            bankEditorWars.SuspendLayout();
            tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.war3Box)).BeginInit();
            tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.war2Box)).BeginInit();
            tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.war1Box)).BeginInit();
            tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.war0Box)).BeginInit();
            sequenceEditorPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            rootMenu.SuspendLayout();
            nodeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            sarEntryMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileMenu,
            editToolStripMenuItem,
            toolsToolStripMenuItem,
            helpToolStripMenuItem,
            aboutToolStripMenuItem});
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(984, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newToolStripMenuItem,
            openToolStripMenuItem,
            saveToolStripMenuItem,
            saveAsToolStripMenuItem,
            closeToolStripMenuItem,
            quitToolStripMenuItem});
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new System.Drawing.Size(37, 20);
            fileMenu.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.New;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Open;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Save;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Save_As;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Close;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Quit;
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            blankFileToolStripMenuItem,
            importFileToolStripMenuItem,
            exportFileToolStripMenuItem});
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // blankFileToolStripMenuItem
            // 
            blankFileToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Rename;
            blankFileToolStripMenuItem.Name = "blankFileToolStripMenuItem";
            blankFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            blankFileToolStripMenuItem.Text = "Blank File";
            blankFileToolStripMenuItem.Click += new System.EventHandler(this.blankFileToolStripMenuItem_Click);
            // 
            // importFileToolStripMenuItem
            // 
            importFileToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Import;
            importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
            importFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            importFileToolStripMenuItem.Text = "Import File";
            importFileToolStripMenuItem.Click += new System.EventHandler(this.importFileToolStripMenuItem_Click);
            // 
            // exportFileToolStripMenuItem
            // 
            exportFileToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Export;
            exportFileToolStripMenuItem.Name = "exportFileToolStripMenuItem";
            exportFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            exportFileToolStripMenuItem.Text = "Export File";
            exportFileToolStripMenuItem.Click += new System.EventHandler(this.exportFileToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            sequenceEditorToolStripMenuItem,
            sequenceArchiveEditorToolStripMenuItem,
            bankEditorToolStripMenuItem,
            waveArchiveEditorToolStripMenuItem,
            bankGeneratorToolStripMenuItem,
            creaveWaveToolStripMenuItem,
            createStreamToolStripMenuItem,
            exportSDKProjectToolStripMenuItem,
            sF2ToDLSToolStripMenuItem,
            dLSToSF2ToolStripMenuItem,
            batchExportMIDIDLSSF2ToolStripMenuItem});
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            toolsToolStripMenuItem.Visible = false;
            // 
            // sequenceEditorToolStripMenuItem
            // 
            sequenceEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sequenceEditorToolStripMenuItem.Image")));
            sequenceEditorToolStripMenuItem.Name = "sequenceEditorToolStripMenuItem";
            sequenceEditorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            sequenceEditorToolStripMenuItem.Text = "Sequence Editor";
            sequenceEditorToolStripMenuItem.Click += new System.EventHandler(this.SequenceEditorToolStripMenuItem_Click);
            // 
            // sequenceArchiveEditorToolStripMenuItem
            // 
            sequenceArchiveEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sequenceArchiveEditorToolStripMenuItem.Image")));
            sequenceArchiveEditorToolStripMenuItem.Name = "sequenceArchiveEditorToolStripMenuItem";
            sequenceArchiveEditorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            sequenceArchiveEditorToolStripMenuItem.Text = "Sequence Archive Editor";
            sequenceArchiveEditorToolStripMenuItem.Click += new System.EventHandler(this.SequenceArchiveEditorToolStripMenuItem_Click);
            // 
            // bankEditorToolStripMenuItem
            // 
            bankEditorToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Bank;
            bankEditorToolStripMenuItem.Name = "bankEditorToolStripMenuItem";
            bankEditorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            bankEditorToolStripMenuItem.Text = "Bank Editor";
            bankEditorToolStripMenuItem.Click += new System.EventHandler(this.BankEditorToolStripMenuItem_Click);
            // 
            // waveArchiveEditorToolStripMenuItem
            // 
            waveArchiveEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("waveArchiveEditorToolStripMenuItem.Image")));
            waveArchiveEditorToolStripMenuItem.Name = "waveArchiveEditorToolStripMenuItem";
            waveArchiveEditorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            waveArchiveEditorToolStripMenuItem.Text = "Wave Archive Editor";
            waveArchiveEditorToolStripMenuItem.Click += new System.EventHandler(this.WaveArchiveEditorToolStripMenuItem_Click);
            // 
            // bankGeneratorToolStripMenuItem
            // 
            bankGeneratorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bankGeneratorToolStripMenuItem.Image")));
            bankGeneratorToolStripMenuItem.Name = "bankGeneratorToolStripMenuItem";
            bankGeneratorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            bankGeneratorToolStripMenuItem.Text = "Bank Generator";
            bankGeneratorToolStripMenuItem.Click += new System.EventHandler(this.BankGeneratorToolStripMenuItem_Click);
            // 
            // creaveWaveToolStripMenuItem
            // 
            creaveWaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("creaveWaveToolStripMenuItem.Image")));
            creaveWaveToolStripMenuItem.Name = "creaveWaveToolStripMenuItem";
            creaveWaveToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            creaveWaveToolStripMenuItem.Text = "Creave Wave";
            creaveWaveToolStripMenuItem.Click += new System.EventHandler(this.CreaveWaveToolStripMenuItem_Click);
            // 
            // createStreamToolStripMenuItem
            // 
            createStreamToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createStreamToolStripMenuItem.Image")));
            createStreamToolStripMenuItem.Name = "createStreamToolStripMenuItem";
            createStreamToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            createStreamToolStripMenuItem.Text = "Create Stream";
            createStreamToolStripMenuItem.Click += new System.EventHandler(this.CreateStreamToolStripMenuItem_Click);
            // 
            // exportSDKProjectToolStripMenuItem
            // 
            exportSDKProjectToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.NSM;
            exportSDKProjectToolStripMenuItem.Name = "exportSDKProjectToolStripMenuItem";
            exportSDKProjectToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            exportSDKProjectToolStripMenuItem.Text = "Export SDK Project";
            exportSDKProjectToolStripMenuItem.Click += new System.EventHandler(this.ExportSDKProjectToolStripMenuItem_Click);
            // 
            // sF2ToDLSToolStripMenuItem
            // 
            sF2ToDLSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sF2ToDLSToolStripMenuItem.Image")));
            sF2ToDLSToolStripMenuItem.Name = "sF2ToDLSToolStripMenuItem";
            sF2ToDLSToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            sF2ToDLSToolStripMenuItem.Text = "SF2 To DLS";
            sF2ToDLSToolStripMenuItem.Click += new System.EventHandler(this.sF2ToDLSToolStripMenuItem_Click);
            // 
            // dLSToSF2ToolStripMenuItem
            // 
            dLSToSF2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dLSToSF2ToolStripMenuItem.Image")));
            dLSToSF2ToolStripMenuItem.Name = "dLSToSF2ToolStripMenuItem";
            dLSToSF2ToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            dLSToSF2ToolStripMenuItem.Text = "DLS To SF2";
            dLSToSF2ToolStripMenuItem.Click += new System.EventHandler(this.dLSToSF2ToolStripMenuItem_Click);
            // 
            // batchExportMIDIDLSSF2ToolStripMenuItem
            // 
            batchExportMIDIDLSSF2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("batchExportMIDIDLSSF2ToolStripMenuItem.Image")));
            batchExportMIDIDLSSF2ToolStripMenuItem.Name = "batchExportMIDIDLSSF2ToolStripMenuItem";
            batchExportMIDIDLSSF2ToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            batchExportMIDIDLSSF2ToolStripMenuItem.Text = "Batch Export MIDI/DLS/SF2";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            getHelpToolStripMenuItem});
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // getHelpToolStripMenuItem
            // 
            getHelpToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Help;
            getHelpToolStripMenuItem.Name = "getHelpToolStripMenuItem";
            getHelpToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            getHelpToolStripMenuItem.Text = "Get Help";
            getHelpToolStripMenuItem.Click += new System.EventHandler(this.GetHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            aboutNitroStudio2ToolStripMenuItem});
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // aboutNitroStudio2ToolStripMenuItem
            // 
            aboutNitroStudio2ToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Ico;
            aboutNitroStudio2ToolStripMenuItem.Name = "aboutNitroStudio2ToolStripMenuItem";
            aboutNitroStudio2ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            aboutNitroStudio2ToolStripMenuItem.Text = "About Nitro Studio 2";
            aboutNitroStudio2ToolStripMenuItem.Click += new System.EventHandler(this.AboutNitroStudio2ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.seqBankPanel);
            splitContainer1.Panel1.Controls.Add(this.bankEditorPanel);
            splitContainer1.Panel1.Controls.Add(this.seqArcSeqPanel);
            splitContainer1.Panel1.Controls.Add(this.seqArcPanel);
            splitContainer1.Panel1.Controls.Add(this.seqPanel);
            splitContainer1.Panel1.Controls.Add(this.playerPanel);
            splitContainer1.Panel1.Controls.Add(this.stmPanel);
            splitContainer1.Panel1.Controls.Add(this.streamPlayerPanel);
            splitContainer1.Panel1.Controls.Add(this.grpPanel);
            splitContainer1.Panel1.Controls.Add(this.bankPanel);
            splitContainer1.Panel1.Controls.Add(this.blankPanel);
            splitContainer1.Panel1.Controls.Add(this.warPanel);
            splitContainer1.Panel1.Controls.Add(this.forceUniqueFilePanel);
            splitContainer1.Panel1.Controls.Add(this.indexPanel);
            splitContainer1.Panel1.Controls.Add(this.settingsPanel);
            splitContainer1.Panel1.Controls.Add(this.noInfoPanel);
            splitContainer1.Panel1.Controls.Add(this.kermalisSoundPlayerPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.pnlPianoKeys);
            splitContainer1.Panel2.Controls.Add(this.bankEditorWars);
            splitContainer1.Panel2.Controls.Add(this.tree);
            splitContainer1.Panel2.Controls.Add(this.sequenceEditorPanel);
            splitContainer1.Size = new System.Drawing.Size(984, 540);
            splitContainer1.SplitterDistance = 327;
            splitContainer1.TabIndex = 1;
            // 
            // seqBankPanel
            // 
            seqBankPanel.Controls.Add(this.tableLayoutPanel36);
            seqBankPanel.Controls.Add(this.tableLayoutPanel20);
            seqBankPanel.Controls.Add(this.label28);
            seqBankPanel.Controls.Add(this.tableLayoutPanel12);
            seqBankPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            seqBankPanel.Location = new System.Drawing.Point(0, 334);
            seqBankPanel.Name = "seqBankPanel";
            seqBankPanel.Size = new System.Drawing.Size(325, 204);
            seqBankPanel.TabIndex = 18;
            seqBankPanel.Visible = false;
            // 
            // tableLayoutPanel36
            // 
            tableLayoutPanel36.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel36.ColumnCount = 2;
            tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel36.Controls.Add(this.exportWavButton, 0, 0);
            tableLayoutPanel36.Controls.Add(this.exportMidiButton, 0, 0);
            tableLayoutPanel36.Location = new System.Drawing.Point(14, 244);
            tableLayoutPanel36.Name = "tableLayoutPanel36";
            tableLayoutPanel36.RowCount = 1;
            tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel36.Size = new System.Drawing.Size(298, 25);
            tableLayoutPanel36.TabIndex = 30;
            // 
            // exportWavButton
            // 
            exportWavButton.Dock = System.Windows.Forms.DockStyle.Fill;
            exportWavButton.Location = new System.Drawing.Point(149, 0);
            exportWavButton.Margin = new System.Windows.Forms.Padding(0);
            exportWavButton.Name = "exportWavButton";
            exportWavButton.Size = new System.Drawing.Size(149, 25);
            exportWavButton.TabIndex = 5;
            exportWavButton.Text = "Export WAV";
            exportWavButton.UseVisualStyleBackColor = true;
            // 
            // exportMidiButton
            // 
            exportMidiButton.Dock = System.Windows.Forms.DockStyle.Fill;
            exportMidiButton.Location = new System.Drawing.Point(0, 0);
            exportMidiButton.Margin = new System.Windows.Forms.Padding(0);
            exportMidiButton.Name = "exportMidiButton";
            exportMidiButton.Size = new System.Drawing.Size(149, 25);
            exportMidiButton.TabIndex = 4;
            exportMidiButton.Text = "Export MIDI";
            exportMidiButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel20
            // 
            tableLayoutPanel20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel20.ColumnCount = 2;
            tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel35, 1, 7);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel34, 1, 6);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel33, 1, 5);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel32, 1, 4);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel31, 1, 3);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel30, 1, 2);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel29, 1, 1);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel28, 0, 7);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel27, 0, 6);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel26, 0, 5);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel25, 0, 4);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel24, 0, 3);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel23, 0, 2);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel22, 0, 1);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel21, 1, 0);
            tableLayoutPanel20.Controls.Add(this.tableLayoutPanel1, 0, 0);
            tableLayoutPanel20.Location = new System.Drawing.Point(14, 62);
            tableLayoutPanel20.Name = "tableLayoutPanel20";
            tableLayoutPanel20.RowCount = 8;
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel20.Size = new System.Drawing.Size(298, 176);
            tableLayoutPanel20.TabIndex = 28;
            // 
            // tableLayoutPanel35
            // 
            tableLayoutPanel35.ColumnCount = 3;
            tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel35.Controls.Add(this.track15Box, 0, 0);
            tableLayoutPanel35.Controls.Add(this.track15Picture, 2, 0);
            tableLayoutPanel35.Controls.Add(this.track15Solo, 1, 0);
            tableLayoutPanel35.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel35.Location = new System.Drawing.Point(149, 154);
            tableLayoutPanel35.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel35.Name = "tableLayoutPanel35";
            tableLayoutPanel35.RowCount = 1;
            tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel35.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel35.TabIndex = 41;
            // 
            // track15Box
            // 
            track15Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track15Box.Checked = true;
            track15Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track15Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track15Box.Location = new System.Drawing.Point(3, 3);
            track15Box.Name = "track15Box";
            track15Box.Size = new System.Drawing.Size(68, 16);
            track15Box.TabIndex = 2;
            track15Box.Text = "Track 15:";
            track15Box.UseVisualStyleBackColor = true;
            // 
            // track15Picture
            // 
            track15Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track15Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track15Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track15Picture.Location = new System.Drawing.Point(111, 0);
            track15Picture.Margin = new System.Windows.Forms.Padding(0);
            track15Picture.Name = "track15Picture";
            track15Picture.Size = new System.Drawing.Size(38, 22);
            track15Picture.TabIndex = 0;
            track15Picture.TabStop = false;
            // 
            // track15Solo
            // 
            track15Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track15Solo.Location = new System.Drawing.Point(74, 0);
            track15Solo.Margin = new System.Windows.Forms.Padding(0);
            track15Solo.Name = "track15Solo";
            track15Solo.Size = new System.Drawing.Size(37, 22);
            track15Solo.TabIndex = 3;
            track15Solo.Text = "Solo";
            track15Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel34
            // 
            tableLayoutPanel34.ColumnCount = 3;
            tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel34.Controls.Add(this.track13Box, 0, 0);
            tableLayoutPanel34.Controls.Add(this.track13Picture, 2, 0);
            tableLayoutPanel34.Controls.Add(this.track13Solo, 1, 0);
            tableLayoutPanel34.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel34.Location = new System.Drawing.Point(149, 132);
            tableLayoutPanel34.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel34.Name = "tableLayoutPanel34";
            tableLayoutPanel34.RowCount = 1;
            tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel34.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel34.TabIndex = 40;
            // 
            // track13Box
            // 
            track13Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track13Box.Checked = true;
            track13Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track13Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track13Box.Location = new System.Drawing.Point(3, 3);
            track13Box.Name = "track13Box";
            track13Box.Size = new System.Drawing.Size(68, 16);
            track13Box.TabIndex = 2;
            track13Box.Text = "Track 13:";
            track13Box.UseVisualStyleBackColor = true;
            // 
            // track13Picture
            // 
            track13Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track13Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track13Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track13Picture.Location = new System.Drawing.Point(111, 0);
            track13Picture.Margin = new System.Windows.Forms.Padding(0);
            track13Picture.Name = "track13Picture";
            track13Picture.Size = new System.Drawing.Size(38, 22);
            track13Picture.TabIndex = 0;
            track13Picture.TabStop = false;
            // 
            // track13Solo
            // 
            track13Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track13Solo.Location = new System.Drawing.Point(74, 0);
            track13Solo.Margin = new System.Windows.Forms.Padding(0);
            track13Solo.Name = "track13Solo";
            track13Solo.Size = new System.Drawing.Size(37, 22);
            track13Solo.TabIndex = 3;
            track13Solo.Text = "Solo";
            track13Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel33
            // 
            tableLayoutPanel33.ColumnCount = 3;
            tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel33.Controls.Add(this.track11Box, 0, 0);
            tableLayoutPanel33.Controls.Add(this.track11Picture, 2, 0);
            tableLayoutPanel33.Controls.Add(this.track11Solo, 1, 0);
            tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel33.Location = new System.Drawing.Point(149, 110);
            tableLayoutPanel33.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel33.Name = "tableLayoutPanel33";
            tableLayoutPanel33.RowCount = 1;
            tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel33.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel33.TabIndex = 39;
            // 
            // track11Box
            // 
            track11Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track11Box.Checked = true;
            track11Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track11Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track11Box.Location = new System.Drawing.Point(3, 3);
            track11Box.Name = "track11Box";
            track11Box.Size = new System.Drawing.Size(68, 16);
            track11Box.TabIndex = 2;
            track11Box.Text = "Track 11:";
            track11Box.UseVisualStyleBackColor = true;
            // 
            // track11Picture
            // 
            track11Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track11Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track11Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track11Picture.Location = new System.Drawing.Point(111, 0);
            track11Picture.Margin = new System.Windows.Forms.Padding(0);
            track11Picture.Name = "track11Picture";
            track11Picture.Size = new System.Drawing.Size(38, 22);
            track11Picture.TabIndex = 0;
            track11Picture.TabStop = false;
            // 
            // track11Solo
            // 
            track11Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track11Solo.Location = new System.Drawing.Point(74, 0);
            track11Solo.Margin = new System.Windows.Forms.Padding(0);
            track11Solo.Name = "track11Solo";
            track11Solo.Size = new System.Drawing.Size(37, 22);
            track11Solo.TabIndex = 3;
            track11Solo.Text = "Solo";
            track11Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel32
            // 
            tableLayoutPanel32.ColumnCount = 3;
            tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel32.Controls.Add(this.track9Box, 0, 0);
            tableLayoutPanel32.Controls.Add(this.track9Picture, 2, 0);
            tableLayoutPanel32.Controls.Add(this.track9Solo, 1, 0);
            tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel32.Location = new System.Drawing.Point(149, 88);
            tableLayoutPanel32.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel32.Name = "tableLayoutPanel32";
            tableLayoutPanel32.RowCount = 1;
            tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel32.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel32.TabIndex = 38;
            // 
            // track9Box
            // 
            track9Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track9Box.Checked = true;
            track9Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track9Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track9Box.Location = new System.Drawing.Point(3, 3);
            track9Box.Name = "track9Box";
            track9Box.Size = new System.Drawing.Size(68, 16);
            track9Box.TabIndex = 2;
            track9Box.Text = "Track 9:";
            track9Box.UseVisualStyleBackColor = true;
            // 
            // track9Picture
            // 
            track9Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track9Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track9Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track9Picture.Location = new System.Drawing.Point(111, 0);
            track9Picture.Margin = new System.Windows.Forms.Padding(0);
            track9Picture.Name = "track9Picture";
            track9Picture.Size = new System.Drawing.Size(38, 22);
            track9Picture.TabIndex = 0;
            track9Picture.TabStop = false;
            // 
            // track9Solo
            // 
            track9Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track9Solo.Location = new System.Drawing.Point(74, 0);
            track9Solo.Margin = new System.Windows.Forms.Padding(0);
            track9Solo.Name = "track9Solo";
            track9Solo.Size = new System.Drawing.Size(37, 22);
            track9Solo.TabIndex = 3;
            track9Solo.Text = "Solo";
            track9Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel31
            // 
            tableLayoutPanel31.ColumnCount = 3;
            tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel31.Controls.Add(this.track7Box, 0, 0);
            tableLayoutPanel31.Controls.Add(this.track7Picture, 2, 0);
            tableLayoutPanel31.Controls.Add(this.track7Solo, 1, 0);
            tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel31.Location = new System.Drawing.Point(149, 66);
            tableLayoutPanel31.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel31.Name = "tableLayoutPanel31";
            tableLayoutPanel31.RowCount = 1;
            tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel31.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel31.TabIndex = 37;
            // 
            // track7Box
            // 
            track7Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track7Box.Checked = true;
            track7Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track7Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track7Box.Location = new System.Drawing.Point(3, 3);
            track7Box.Name = "track7Box";
            track7Box.Size = new System.Drawing.Size(68, 16);
            track7Box.TabIndex = 2;
            track7Box.Text = "Track 7:";
            track7Box.UseVisualStyleBackColor = true;
            // 
            // track7Picture
            // 
            track7Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track7Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track7Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track7Picture.Location = new System.Drawing.Point(111, 0);
            track7Picture.Margin = new System.Windows.Forms.Padding(0);
            track7Picture.Name = "track7Picture";
            track7Picture.Size = new System.Drawing.Size(38, 22);
            track7Picture.TabIndex = 0;
            track7Picture.TabStop = false;
            // 
            // track7Solo
            // 
            track7Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track7Solo.Location = new System.Drawing.Point(74, 0);
            track7Solo.Margin = new System.Windows.Forms.Padding(0);
            track7Solo.Name = "track7Solo";
            track7Solo.Size = new System.Drawing.Size(37, 22);
            track7Solo.TabIndex = 3;
            track7Solo.Text = "Solo";
            track7Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel30
            // 
            tableLayoutPanel30.ColumnCount = 3;
            tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel30.Controls.Add(this.track5Box, 0, 0);
            tableLayoutPanel30.Controls.Add(this.track5Picture, 2, 0);
            tableLayoutPanel30.Controls.Add(this.track5Solo, 1, 0);
            tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel30.Location = new System.Drawing.Point(149, 44);
            tableLayoutPanel30.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel30.Name = "tableLayoutPanel30";
            tableLayoutPanel30.RowCount = 1;
            tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel30.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel30.TabIndex = 36;
            // 
            // track5Box
            // 
            track5Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track5Box.Checked = true;
            track5Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track5Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track5Box.Location = new System.Drawing.Point(3, 3);
            track5Box.Name = "track5Box";
            track5Box.Size = new System.Drawing.Size(68, 16);
            track5Box.TabIndex = 2;
            track5Box.Text = "Track 5:";
            track5Box.UseVisualStyleBackColor = true;
            // 
            // track5Picture
            // 
            track5Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track5Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track5Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track5Picture.Location = new System.Drawing.Point(111, 0);
            track5Picture.Margin = new System.Windows.Forms.Padding(0);
            track5Picture.Name = "track5Picture";
            track5Picture.Size = new System.Drawing.Size(38, 22);
            track5Picture.TabIndex = 0;
            track5Picture.TabStop = false;
            // 
            // track5Solo
            // 
            track5Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track5Solo.Location = new System.Drawing.Point(74, 0);
            track5Solo.Margin = new System.Windows.Forms.Padding(0);
            track5Solo.Name = "track5Solo";
            track5Solo.Size = new System.Drawing.Size(37, 22);
            track5Solo.TabIndex = 3;
            track5Solo.Text = "Solo";
            track5Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel29
            // 
            tableLayoutPanel29.ColumnCount = 3;
            tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel29.Controls.Add(this.track3Box, 0, 0);
            tableLayoutPanel29.Controls.Add(this.track3Picture, 2, 0);
            tableLayoutPanel29.Controls.Add(this.track3Solo, 1, 0);
            tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel29.Location = new System.Drawing.Point(149, 22);
            tableLayoutPanel29.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel29.Name = "tableLayoutPanel29";
            tableLayoutPanel29.RowCount = 1;
            tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel29.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel29.TabIndex = 35;
            // 
            // track3Box
            // 
            track3Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track3Box.Checked = true;
            track3Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track3Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track3Box.Location = new System.Drawing.Point(3, 3);
            track3Box.Name = "track3Box";
            track3Box.Size = new System.Drawing.Size(68, 16);
            track3Box.TabIndex = 2;
            track3Box.Text = "Track 3:";
            track3Box.UseVisualStyleBackColor = true;
            // 
            // track3Picture
            // 
            track3Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track3Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track3Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track3Picture.Location = new System.Drawing.Point(111, 0);
            track3Picture.Margin = new System.Windows.Forms.Padding(0);
            track3Picture.Name = "track3Picture";
            track3Picture.Size = new System.Drawing.Size(38, 22);
            track3Picture.TabIndex = 0;
            track3Picture.TabStop = false;
            // 
            // track3Solo
            // 
            track3Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track3Solo.Location = new System.Drawing.Point(74, 0);
            track3Solo.Margin = new System.Windows.Forms.Padding(0);
            track3Solo.Name = "track3Solo";
            track3Solo.Size = new System.Drawing.Size(37, 22);
            track3Solo.TabIndex = 3;
            track3Solo.Text = "Solo";
            track3Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel28
            // 
            tableLayoutPanel28.ColumnCount = 3;
            tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel28.Controls.Add(this.track14Box, 0, 0);
            tableLayoutPanel28.Controls.Add(this.track14Picture, 2, 0);
            tableLayoutPanel28.Controls.Add(this.track14Solo, 1, 0);
            tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel28.Location = new System.Drawing.Point(0, 154);
            tableLayoutPanel28.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel28.Name = "tableLayoutPanel28";
            tableLayoutPanel28.RowCount = 1;
            tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel28.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel28.TabIndex = 34;
            // 
            // track14Box
            // 
            track14Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track14Box.Checked = true;
            track14Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track14Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track14Box.Location = new System.Drawing.Point(3, 3);
            track14Box.Name = "track14Box";
            track14Box.Size = new System.Drawing.Size(68, 16);
            track14Box.TabIndex = 2;
            track14Box.Text = "Track 14:";
            track14Box.UseVisualStyleBackColor = true;
            // 
            // track14Picture
            // 
            track14Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track14Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track14Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track14Picture.Location = new System.Drawing.Point(111, 0);
            track14Picture.Margin = new System.Windows.Forms.Padding(0);
            track14Picture.Name = "track14Picture";
            track14Picture.Size = new System.Drawing.Size(38, 22);
            track14Picture.TabIndex = 0;
            track14Picture.TabStop = false;
            // 
            // track14Solo
            // 
            track14Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track14Solo.Location = new System.Drawing.Point(74, 0);
            track14Solo.Margin = new System.Windows.Forms.Padding(0);
            track14Solo.Name = "track14Solo";
            track14Solo.Size = new System.Drawing.Size(37, 22);
            track14Solo.TabIndex = 3;
            track14Solo.Text = "Solo";
            track14Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel27
            // 
            tableLayoutPanel27.ColumnCount = 3;
            tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel27.Controls.Add(this.track12Box, 0, 0);
            tableLayoutPanel27.Controls.Add(this.track12Picture, 2, 0);
            tableLayoutPanel27.Controls.Add(this.track12Solo, 1, 0);
            tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel27.Location = new System.Drawing.Point(0, 132);
            tableLayoutPanel27.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel27.Name = "tableLayoutPanel27";
            tableLayoutPanel27.RowCount = 1;
            tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel27.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel27.TabIndex = 33;
            // 
            // track12Box
            // 
            track12Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track12Box.Checked = true;
            track12Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track12Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track12Box.Location = new System.Drawing.Point(3, 3);
            track12Box.Name = "track12Box";
            track12Box.Size = new System.Drawing.Size(68, 16);
            track12Box.TabIndex = 2;
            track12Box.Text = "Track 12:";
            track12Box.UseVisualStyleBackColor = true;
            // 
            // track12Picture
            // 
            track12Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track12Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track12Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track12Picture.Location = new System.Drawing.Point(111, 0);
            track12Picture.Margin = new System.Windows.Forms.Padding(0);
            track12Picture.Name = "track12Picture";
            track12Picture.Size = new System.Drawing.Size(38, 22);
            track12Picture.TabIndex = 0;
            track12Picture.TabStop = false;
            // 
            // track12Solo
            // 
            track12Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track12Solo.Location = new System.Drawing.Point(74, 0);
            track12Solo.Margin = new System.Windows.Forms.Padding(0);
            track12Solo.Name = "track12Solo";
            track12Solo.Size = new System.Drawing.Size(37, 22);
            track12Solo.TabIndex = 3;
            track12Solo.Text = "Solo";
            track12Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel26
            // 
            tableLayoutPanel26.ColumnCount = 3;
            tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel26.Controls.Add(this.track10Box, 0, 0);
            tableLayoutPanel26.Controls.Add(this.track10Picture, 2, 0);
            tableLayoutPanel26.Controls.Add(this.track10Solo, 1, 0);
            tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel26.Location = new System.Drawing.Point(0, 110);
            tableLayoutPanel26.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel26.Name = "tableLayoutPanel26";
            tableLayoutPanel26.RowCount = 1;
            tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel26.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel26.TabIndex = 32;
            // 
            // track10Box
            // 
            track10Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track10Box.Checked = true;
            track10Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track10Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track10Box.Location = new System.Drawing.Point(3, 3);
            track10Box.Name = "track10Box";
            track10Box.Size = new System.Drawing.Size(68, 16);
            track10Box.TabIndex = 2;
            track10Box.Text = "Track 10:";
            track10Box.UseVisualStyleBackColor = true;
            // 
            // track10Picture
            // 
            track10Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track10Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track10Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track10Picture.Location = new System.Drawing.Point(111, 0);
            track10Picture.Margin = new System.Windows.Forms.Padding(0);
            track10Picture.Name = "track10Picture";
            track10Picture.Size = new System.Drawing.Size(38, 22);
            track10Picture.TabIndex = 0;
            track10Picture.TabStop = false;
            // 
            // track10Solo
            // 
            track10Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track10Solo.Location = new System.Drawing.Point(74, 0);
            track10Solo.Margin = new System.Windows.Forms.Padding(0);
            track10Solo.Name = "track10Solo";
            track10Solo.Size = new System.Drawing.Size(37, 22);
            track10Solo.TabIndex = 3;
            track10Solo.Text = "Solo";
            track10Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel25
            // 
            tableLayoutPanel25.ColumnCount = 3;
            tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel25.Controls.Add(this.track8Box, 0, 0);
            tableLayoutPanel25.Controls.Add(this.track8Picture, 2, 0);
            tableLayoutPanel25.Controls.Add(this.track8Solo, 1, 0);
            tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel25.Location = new System.Drawing.Point(0, 88);
            tableLayoutPanel25.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel25.Name = "tableLayoutPanel25";
            tableLayoutPanel25.RowCount = 1;
            tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel25.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel25.TabIndex = 31;
            // 
            // track8Box
            // 
            track8Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track8Box.Checked = true;
            track8Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track8Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track8Box.Location = new System.Drawing.Point(3, 3);
            track8Box.Name = "track8Box";
            track8Box.Size = new System.Drawing.Size(68, 16);
            track8Box.TabIndex = 2;
            track8Box.Text = "Track 8:";
            track8Box.UseVisualStyleBackColor = true;
            // 
            // track8Picture
            // 
            track8Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track8Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track8Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track8Picture.Location = new System.Drawing.Point(111, 0);
            track8Picture.Margin = new System.Windows.Forms.Padding(0);
            track8Picture.Name = "track8Picture";
            track8Picture.Size = new System.Drawing.Size(38, 22);
            track8Picture.TabIndex = 0;
            track8Picture.TabStop = false;
            // 
            // track8Solo
            // 
            track8Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track8Solo.Location = new System.Drawing.Point(74, 0);
            track8Solo.Margin = new System.Windows.Forms.Padding(0);
            track8Solo.Name = "track8Solo";
            track8Solo.Size = new System.Drawing.Size(37, 22);
            track8Solo.TabIndex = 3;
            track8Solo.Text = "Solo";
            track8Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel24
            // 
            tableLayoutPanel24.ColumnCount = 3;
            tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel24.Controls.Add(this.track6Box, 0, 0);
            tableLayoutPanel24.Controls.Add(this.track6Picture, 2, 0);
            tableLayoutPanel24.Controls.Add(this.track6Solo, 1, 0);
            tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel24.Location = new System.Drawing.Point(0, 66);
            tableLayoutPanel24.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel24.Name = "tableLayoutPanel24";
            tableLayoutPanel24.RowCount = 1;
            tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel24.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel24.TabIndex = 30;
            // 
            // track6Box
            // 
            track6Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track6Box.Checked = true;
            track6Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track6Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track6Box.Location = new System.Drawing.Point(3, 3);
            track6Box.Name = "track6Box";
            track6Box.Size = new System.Drawing.Size(68, 16);
            track6Box.TabIndex = 2;
            track6Box.Text = "Track 6:";
            track6Box.UseVisualStyleBackColor = true;
            // 
            // track6Picture
            // 
            track6Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track6Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track6Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track6Picture.Location = new System.Drawing.Point(111, 0);
            track6Picture.Margin = new System.Windows.Forms.Padding(0);
            track6Picture.Name = "track6Picture";
            track6Picture.Size = new System.Drawing.Size(38, 22);
            track6Picture.TabIndex = 0;
            track6Picture.TabStop = false;
            // 
            // track6Solo
            // 
            track6Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track6Solo.Location = new System.Drawing.Point(74, 0);
            track6Solo.Margin = new System.Windows.Forms.Padding(0);
            track6Solo.Name = "track6Solo";
            track6Solo.Size = new System.Drawing.Size(37, 22);
            track6Solo.TabIndex = 3;
            track6Solo.Text = "Solo";
            track6Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel23
            // 
            tableLayoutPanel23.ColumnCount = 3;
            tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel23.Controls.Add(this.track4Box, 0, 0);
            tableLayoutPanel23.Controls.Add(this.track4Picture, 2, 0);
            tableLayoutPanel23.Controls.Add(this.track4Solo, 1, 0);
            tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel23.Location = new System.Drawing.Point(0, 44);
            tableLayoutPanel23.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel23.Name = "tableLayoutPanel23";
            tableLayoutPanel23.RowCount = 1;
            tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel23.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel23.TabIndex = 29;
            // 
            // track4Box
            // 
            track4Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track4Box.Checked = true;
            track4Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track4Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track4Box.Location = new System.Drawing.Point(3, 3);
            track4Box.Name = "track4Box";
            track4Box.Size = new System.Drawing.Size(68, 16);
            track4Box.TabIndex = 2;
            track4Box.Text = "Track 4:";
            track4Box.UseVisualStyleBackColor = true;
            // 
            // track4Picture
            // 
            track4Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track4Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track4Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track4Picture.Location = new System.Drawing.Point(111, 0);
            track4Picture.Margin = new System.Windows.Forms.Padding(0);
            track4Picture.Name = "track4Picture";
            track4Picture.Size = new System.Drawing.Size(38, 22);
            track4Picture.TabIndex = 0;
            track4Picture.TabStop = false;
            // 
            // track4Solo
            // 
            track4Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track4Solo.Location = new System.Drawing.Point(74, 0);
            track4Solo.Margin = new System.Windows.Forms.Padding(0);
            track4Solo.Name = "track4Solo";
            track4Solo.Size = new System.Drawing.Size(37, 22);
            track4Solo.TabIndex = 3;
            track4Solo.Text = "Solo";
            track4Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel22
            // 
            tableLayoutPanel22.ColumnCount = 3;
            tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel22.Controls.Add(this.track2Box, 0, 0);
            tableLayoutPanel22.Controls.Add(this.track2Picture, 2, 0);
            tableLayoutPanel22.Controls.Add(this.track2Solo, 1, 0);
            tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel22.Location = new System.Drawing.Point(0, 22);
            tableLayoutPanel22.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel22.Name = "tableLayoutPanel22";
            tableLayoutPanel22.RowCount = 1;
            tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel22.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel22.TabIndex = 28;
            // 
            // track2Box
            // 
            track2Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track2Box.Checked = true;
            track2Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track2Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track2Box.Location = new System.Drawing.Point(3, 3);
            track2Box.Name = "track2Box";
            track2Box.Size = new System.Drawing.Size(68, 16);
            track2Box.TabIndex = 2;
            track2Box.Text = "Track 2:";
            track2Box.UseVisualStyleBackColor = true;
            // 
            // track2Picture
            // 
            track2Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track2Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track2Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track2Picture.Location = new System.Drawing.Point(111, 0);
            track2Picture.Margin = new System.Windows.Forms.Padding(0);
            track2Picture.Name = "track2Picture";
            track2Picture.Size = new System.Drawing.Size(38, 22);
            track2Picture.TabIndex = 0;
            track2Picture.TabStop = false;
            // 
            // track2Solo
            // 
            track2Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track2Solo.Location = new System.Drawing.Point(74, 0);
            track2Solo.Margin = new System.Windows.Forms.Padding(0);
            track2Solo.Name = "track2Solo";
            track2Solo.Size = new System.Drawing.Size(37, 22);
            track2Solo.TabIndex = 3;
            track2Solo.Text = "Solo";
            track2Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel21
            // 
            tableLayoutPanel21.ColumnCount = 3;
            tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel21.Controls.Add(this.track1Box, 0, 0);
            tableLayoutPanel21.Controls.Add(this.track1Picture, 2, 0);
            tableLayoutPanel21.Controls.Add(this.track1Solo, 1, 0);
            tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel21.Location = new System.Drawing.Point(149, 0);
            tableLayoutPanel21.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel21.Name = "tableLayoutPanel21";
            tableLayoutPanel21.RowCount = 1;
            tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel21.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel21.TabIndex = 27;
            // 
            // track1Box
            // 
            track1Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track1Box.Checked = true;
            track1Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track1Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track1Box.Location = new System.Drawing.Point(3, 3);
            track1Box.Name = "track1Box";
            track1Box.Size = new System.Drawing.Size(68, 16);
            track1Box.TabIndex = 2;
            track1Box.Text = "Track 1:";
            track1Box.UseVisualStyleBackColor = true;
            // 
            // track1Picture
            // 
            track1Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track1Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track1Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track1Picture.Location = new System.Drawing.Point(111, 0);
            track1Picture.Margin = new System.Windows.Forms.Padding(0);
            track1Picture.Name = "track1Picture";
            track1Picture.Size = new System.Drawing.Size(38, 22);
            track1Picture.TabIndex = 0;
            track1Picture.TabStop = false;
            // 
            // track1Solo
            // 
            track1Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track1Solo.Location = new System.Drawing.Point(74, 0);
            track1Solo.Margin = new System.Windows.Forms.Padding(0);
            track1Solo.Name = "track1Solo";
            track1Solo.Size = new System.Drawing.Size(37, 22);
            track1Solo.TabIndex = 3;
            track1Solo.Text = "Solo";
            track1Solo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(this.track0Box, 0, 0);
            tableLayoutPanel1.Controls.Add(this.track0Picture, 2, 0);
            tableLayoutPanel1.Controls.Add(this.track0Solo, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(149, 22);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // track0Box
            // 
            track0Box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            track0Box.Checked = true;
            track0Box.CheckState = System.Windows.Forms.CheckState.Checked;
            track0Box.Dock = System.Windows.Forms.DockStyle.Fill;
            track0Box.Location = new System.Drawing.Point(3, 3);
            track0Box.Name = "track0Box";
            track0Box.Size = new System.Drawing.Size(68, 16);
            track0Box.TabIndex = 2;
            track0Box.Text = "Track 0:";
            track0Box.UseVisualStyleBackColor = true;
            // 
            // track0Picture
            // 
            track0Picture.BackgroundImage = global::NitroStudio2.Properties.Resources.Idle;
            track0Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            track0Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            track0Picture.Location = new System.Drawing.Point(111, 0);
            track0Picture.Margin = new System.Windows.Forms.Padding(0);
            track0Picture.Name = "track0Picture";
            track0Picture.Size = new System.Drawing.Size(38, 22);
            track0Picture.TabIndex = 0;
            track0Picture.TabStop = false;
            // 
            // track0Solo
            // 
            track0Solo.Dock = System.Windows.Forms.DockStyle.Fill;
            track0Solo.Location = new System.Drawing.Point(74, 0);
            track0Solo.Margin = new System.Windows.Forms.Padding(0);
            track0Solo.Name = "track0Solo";
            track0Solo.Size = new System.Drawing.Size(37, 22);
            track0Solo.TabIndex = 3;
            track0Solo.Text = "Solo";
            track0Solo.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label28.Location = new System.Drawing.Point(11, 3);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(301, 20);
            label28.TabIndex = 25;
            label28.Text = "Preview Bank:";
            label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel12.ColumnCount = 2;
            tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel12.Controls.Add(this.seqEditorBankComboBox, 0, 0);
            tableLayoutPanel12.Controls.Add(this.seqEditorBankBox, 1, 0);
            tableLayoutPanel12.Location = new System.Drawing.Point(14, 25);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 1;
            tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel12.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel12.TabIndex = 24;
            // 
            // seqEditorBankComboBox
            // 
            seqEditorBankComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqEditorBankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            seqEditorBankComboBox.FormattingEnabled = true;
            seqEditorBankComboBox.Location = new System.Drawing.Point(3, 3);
            seqEditorBankComboBox.Name = "seqEditorBankComboBox";
            seqEditorBankComboBox.Size = new System.Drawing.Size(247, 21);
            seqEditorBankComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.seqEditorBankComboBox, "Bank to use with the sequence.");
            // 
            // seqEditorBankBox
            // 
            seqEditorBankBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqEditorBankBox.Location = new System.Drawing.Point(256, 3);
            seqEditorBankBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            seqEditorBankBox.Name = "seqEditorBankBox";
            seqEditorBankBox.Size = new System.Drawing.Size(39, 20);
            seqEditorBankBox.TabIndex = 7;
            toolTip.SetToolTip(this.seqEditorBankBox, "Id of the bank to use with the sequence.");
            // 
            // bankEditorPanel
            // 
            bankEditorPanel.Controls.Add(this.bankRegions);
            bankEditorPanel.Controls.Add(this.label32);
            bankEditorPanel.Controls.Add(this.tableLayoutPanel15);
            bankEditorPanel.Controls.Add(this.drumSetRangeStartLabel);
            bankEditorPanel.Controls.Add(this.tableLayoutPanel14);
            bankEditorPanel.Controls.Add(this.label30);
            bankEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            bankEditorPanel.Location = new System.Drawing.Point(0, 334);
            bankEditorPanel.Name = "bankEditorPanel";
            bankEditorPanel.Size = new System.Drawing.Size(325, 204);
            bankEditorPanel.TabIndex = 21;
            bankEditorPanel.Visible = false;
            // 
            // bankRegions
            // 
            bankRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            bankRegions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            bankRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // bankRegions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            // playSampleButton,
            // endNote,
            // instrumentType,
            // waveId,
            // waveArchiveId,
            // baseNote,
            // attack,
            // decay,
            // sustain,
            // release,
            // pan});
            bankRegions.Location = new System.Drawing.Point(14, 141);
            bankRegions.Name = "bankRegions";
            bankRegions.Size = new System.Drawing.Size(298, 54);
            bankRegions.TabIndex = 26;
            // 
            // playSampleButton
            // 
            playSampleButton.HeaderText = "Play";
            playSampleButton.Name = "playSampleButton";
            playSampleButton.Text = "Play";
            playSampleButton.UseColumnTextForButtonValue = true;
            playSampleButton.Width = 33;
            // 
            // endNote
            // 
            endNote.FillWeight = 50F;
            endNote.HeaderText = "End Note";
            endNote.Items.AddRange(new object[] {
            "cnm1 (0)",
            "csm1 (1)",
            "dnm1 (2)",
            "dsm1 (3)",
            "enm1 (4)",
            "fnm1 (5)",
            "fsm1 (6)",
            "gnm1 (7)",
            "gsm1 (8)",
            "anm1 (9)",
            "asm1 (10)",
            "bnm1 (11)",
            "cn0 (12)",
            "cs0 (13)",
            "dn0 (14)",
            "ds0 (15)",
            "en0 (16)",
            "fn0 (17)",
            "fs0 (18)",
            "gn0 (19)",
            "gs0 (20)",
            "an0 (21)",
            "as0 (22)",
            "bn0 (23)",
            "cn1 (24)",
            "cs1 (25)",
            "dn1 (26)",
            "ds1 (27)",
            "en1 (28)",
            "fn1 (29)",
            "fs1 (30)",
            "gn1 (31)",
            "gs1 (32)",
            "an1 (33)",
            "as1 (34)",
            "bn1 (35)",
            "cn2 (36)",
            "cs2 (37)",
            "dn2 (38)",
            "ds2 (39)",
            "en2 (40)",
            "fn2 (41)",
            "fs2 (42)",
            "gn2 (43)",
            "gs2 (44)",
            "an2 (45)",
            "as2 (46)",
            "bn2 (47)",
            "cn3 (48)",
            "cs3 (49)",
            "dn3 (50)",
            "ds3 (51)",
            "en3 (52)",
            "fn3 (53)",
            "fs3 (54)",
            "gn3 (55)",
            "gs3 (56)",
            "an3 (57)",
            "as3 (58)",
            "bn3 (59)",
            "cn4 (60)",
            "cs4 (61)",
            "dn4 (62)",
            "ds4 (63)",
            "en4 (64)",
            "fn4 (65)",
            "fs4 (66)",
            "gn4 (67)",
            "gs4 (68)",
            "an4 (69)",
            "as4 (70)",
            "bn4 (71)",
            "cn5 (72)",
            "cs5 (73)",
            "dn5 (74)",
            "ds5 (75)",
            "en5 (76)",
            "fn5 (77)",
            "fs5 (78)",
            "gn5 (79)",
            "gs5 (80)",
            "an5 (81)",
            "as5 (82)",
            "bn5 (83)",
            "cn6 (84)",
            "cs6 (85)",
            "dn6 (86)",
            "ds6 (87)",
            "en6 (88)",
            "fn6 (89)",
            "fs6 (90)",
            "gn6 (91)",
            "gs6 (92)",
            "an6 (93)",
            "as6 (94)",
            "bn6 (95)",
            "cn7 (96)",
            "cs7 (97)",
            "dn7 (98)",
            "ds7 (99)",
            "en7 (100)",
            "fn7 (101)",
            "fs7 (102)",
            "gn7 (103)",
            "gs7 (104)",
            "an7 (105)",
            "as7 (106)",
            "bn7 (107)",
            "cn8 (108)",
            "cs8 (109)",
            "dn8 (110)",
            "ds8 (111)",
            "en8 (112)",
            "fn8 (113)",
            "fs8 (114)",
            "gn8 (115)",
            "gs8 (116)",
            "an8 (117)",
            "as8 (118)",
            "bn8 (119)",
            "cn9 (120)",
            "cs9 (121)",
            "dn9 (122)",
            "ds9 (123)",
            "en9 (124)",
            "fn9 (125)",
            "fs9 (126)",
            "gn9 (127)"});
            endNote.Name = "endNote";
            endNote.Width = 52;
            // 
            // instrumentType
            // 
            instrumentType.HeaderText = "Instrument Type";
            instrumentType.Items.AddRange(new object[] {
            "PCM",
            "PSG",
            "Noise",
            "Direct PCM",
            "Null"});
            instrumentType.Name = "instrumentType";
            instrumentType.Width = 80;
            // 
            // waveId
            // 
            waveId.HeaderText = "Wave Id/PSG Cycle";
            waveId.MaxInputLength = 5;
            waveId.Name = "waveId";
            waveId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            waveId.Width = 99;
            // 
            // waveArchiveId
            // 
            waveArchiveId.HeaderText = "Wave Archive Id";
            waveArchiveId.MaxInputLength = 5;
            waveArchiveId.Name = "waveArchiveId";
            waveArchiveId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            waveArchiveId.Width = 76;
            // 
            // baseNote
            // 
            baseNote.HeaderText = "Base Note";
            baseNote.Items.AddRange(new object[] {
            "cnm1 (0)",
            "csm1 (1)",
            "dnm1 (2)",
            "dsm1 (3)",
            "enm1 (4)",
            "fnm1 (5)",
            "fsm1 (6)",
            "gnm1 (7)",
            "gsm1 (8)",
            "anm1 (9)",
            "asm1 (10)",
            "bnm1 (11)",
            "cn0 (12)",
            "cs0 (13)",
            "dn0 (14)",
            "ds0 (15)",
            "en0 (16)",
            "fn0 (17)",
            "fs0 (18)",
            "gn0 (19)",
            "gs0 (20)",
            "an0 (21)",
            "as0 (22)",
            "bn0 (23)",
            "cn1 (24)",
            "cs1 (25)",
            "dn1 (26)",
            "ds1 (27)",
            "en1 (28)",
            "fn1 (29)",
            "fs1 (30)",
            "gn1 (31)",
            "gs1 (32)",
            "an1 (33)",
            "as1 (34)",
            "bn1 (35)",
            "cn2 (36)",
            "cs2 (37)",
            "dn2 (38)",
            "ds2 (39)",
            "en2 (40)",
            "fn2 (41)",
            "fs2 (42)",
            "gn2 (43)",
            "gs2 (44)",
            "an2 (45)",
            "as2 (46)",
            "bn2 (47)",
            "cn3 (48)",
            "cs3 (49)",
            "dn3 (50)",
            "ds3 (51)",
            "en3 (52)",
            "fn3 (53)",
            "fs3 (54)",
            "gn3 (55)",
            "gs3 (56)",
            "an3 (57)",
            "as3 (58)",
            "bn3 (59)",
            "cn4 (60)",
            "cs4 (61)",
            "dn4 (62)",
            "ds4 (63)",
            "en4 (64)",
            "fn4 (65)",
            "fs4 (66)",
            "gn4 (67)",
            "gs4 (68)",
            "an4 (69)",
            "as4 (70)",
            "bn4 (71)",
            "cn5 (72)",
            "cs5 (73)",
            "dn5 (74)",
            "ds5 (75)",
            "en5 (76)",
            "fn5 (77)",
            "fs5 (78)",
            "gn5 (79)",
            "gs5 (80)",
            "an5 (81)",
            "as5 (82)",
            "bn5 (83)",
            "cn6 (84)",
            "cs6 (85)",
            "dn6 (86)",
            "ds6 (87)",
            "en6 (88)",
            "fn6 (89)",
            "fs6 (90)",
            "gn6 (91)",
            "gs6 (92)",
            "an6 (93)",
            "as6 (94)",
            "bn6 (95)",
            "cn7 (96)",
            "cs7 (97)",
            "dn7 (98)",
            "ds7 (99)",
            "en7 (100)",
            "fn7 (101)",
            "fs7 (102)",
            "gn7 (103)",
            "gs7 (104)",
            "an7 (105)",
            "as7 (106)",
            "bn7 (107)",
            "cn8 (108)",
            "cs8 (109)",
            "dn8 (110)",
            "ds8 (111)",
            "en8 (112)",
            "fn8 (113)",
            "fs8 (114)",
            "gn8 (115)",
            "gs8 (116)",
            "an8 (117)",
            "as8 (118)",
            "bn8 (119)",
            "cn9 (120)",
            "cs9 (121)",
            "dn9 (122)",
            "ds9 (123)",
            "en9 (124)",
            "fn9 (125)",
            "fs9 (126)",
            "gn9 (127)"});
            baseNote.Name = "baseNote";
            baseNote.Width = 57;
            // 
            // attack
            // 
            attack.HeaderText = "Attack";
            attack.MaxInputLength = 3;
            attack.Name = "attack";
            attack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            attack.Width = 44;
            // 
            // decay
            // 
            decay.HeaderText = "Decay";
            decay.MaxInputLength = 3;
            decay.Name = "decay";
            decay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            decay.Width = 44;
            // 
            // sustain
            // 
            sustain.HeaderText = "Sustain";
            sustain.MaxInputLength = 3;
            sustain.Name = "sustain";
            sustain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            sustain.Width = 48;
            // 
            // release
            // 
            release.HeaderText = "Release";
            release.MaxInputLength = 3;
            release.Name = "release";
            release.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            release.Width = 52;
            // 
            // pan
            // 
            pan.HeaderText = "Pan";
            pan.MaxInputLength = 3;
            pan.Name = "pan";
            pan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            pan.Width = 32;
            // 
            // label32
            // 
            label32.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label32.Location = new System.Drawing.Point(11, 118);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(301, 20);
            label32.TabIndex = 25;
            label32.Text = "Regions:";
            label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel15
            // 
            tableLayoutPanel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel15.ColumnCount = 2;
            tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel15.Controls.Add(this.drumSetStartRangeComboBox, 0, 0);
            tableLayoutPanel15.Controls.Add(this.drumSetStartRangeBox, 1, 0);
            tableLayoutPanel15.Location = new System.Drawing.Point(14, 84);
            tableLayoutPanel15.Name = "tableLayoutPanel15";
            tableLayoutPanel15.RowCount = 1;
            tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel15.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel15.TabIndex = 24;
            // 
            // drumSetStartRangeComboBox
            // 
            drumSetStartRangeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            drumSetStartRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            drumSetStartRangeComboBox.FormattingEnabled = true;
            drumSetStartRangeComboBox.Items.AddRange(new object[] {
            "cnm1",
            "csm1",
            "dnm1",
            "dsm1",
            "enm1",
            "fnm1",
            "fsm1",
            "gnm1",
            "gsm1",
            "anm1",
            "asm1",
            "bnm1",
            "cn0",
            "cs0",
            "dn0",
            "ds0",
            "en0",
            "fn0",
            "fs0",
            "gn0",
            "gs0",
            "an0",
            "as0",
            "bn0",
            "cn1",
            "cs1",
            "dn1",
            "ds1",
            "en1",
            "fn1",
            "fs1",
            "gn1",
            "gs1",
            "an1",
            "as1",
            "bn1",
            "cn2",
            "cs2",
            "dn2",
            "ds2",
            "en2",
            "fn2",
            "fs2",
            "gn2",
            "gs2",
            "an2",
            "as2",
            "bn2",
            "cn3",
            "cs3",
            "dn3",
            "ds3",
            "en3",
            "fn3",
            "fs3",
            "gn3",
            "gs3",
            "an3",
            "as3",
            "bn3",
            "cn4",
            "cs4",
            "dn4",
            "ds4",
            "en4",
            "fn4",
            "fs4",
            "gn4",
            "gs4",
            "an4",
            "as4",
            "bn4",
            "cn5",
            "cs5",
            "dn5",
            "ds5",
            "en5",
            "fn5",
            "fs5",
            "gn5",
            "gs5",
            "an5",
            "as5",
            "bn5",
            "cn6",
            "cs6",
            "dn6",
            "ds6",
            "en6",
            "fn6",
            "fs6",
            "gn6",
            "gs6",
            "an6",
            "as6",
            "bn6",
            "cn7",
            "cs7",
            "dn7",
            "ds7",
            "en7",
            "fn7",
            "fs7",
            "gn7",
            "gs7",
            "an7",
            "as7",
            "bn7",
            "cn8",
            "cs8",
            "dn8",
            "ds8",
            "en8",
            "fn8",
            "fs8",
            "gn8",
            "gs8",
            "an8",
            "as8",
            "bn8",
            "cn9",
            "cs9",
            "dn9",
            "ds9",
            "en9",
            "fn9",
            "fs9",
            "gn9"});
            drumSetStartRangeComboBox.Location = new System.Drawing.Point(3, 3);
            drumSetStartRangeComboBox.Name = "drumSetStartRangeComboBox";
            drumSetStartRangeComboBox.Size = new System.Drawing.Size(247, 21);
            drumSetStartRangeComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.drumSetStartRangeComboBox, "What note to start the drum set range at.");
            // 
            // drumSetStartRangeBox
            // 
            drumSetStartRangeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            drumSetStartRangeBox.Location = new System.Drawing.Point(256, 3);
            drumSetStartRangeBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            drumSetStartRangeBox.Name = "drumSetStartRangeBox";
            drumSetStartRangeBox.Size = new System.Drawing.Size(39, 20);
            drumSetStartRangeBox.TabIndex = 7;
            toolTip.SetToolTip(this.drumSetStartRangeBox, "What note to start the drum set range at.");
            // 
            // drumSetRangeStartLabel
            // 
            drumSetRangeStartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            drumSetRangeStartLabel.Location = new System.Drawing.Point(8, 61);
            drumSetRangeStartLabel.Name = "drumSetRangeStartLabel";
            drumSetRangeStartLabel.Size = new System.Drawing.Size(301, 20);
            drumSetRangeStartLabel.TabIndex = 3;
            drumSetRangeStartLabel.Text = "Drum Set Range Start:";
            drumSetRangeStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel14.ColumnCount = 3;
            tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel14.Controls.Add(this.keySplitBox, 2, 0);
            tableLayoutPanel14.Controls.Add(this.drumSetBox, 1, 0);
            tableLayoutPanel14.Controls.Add(this.directBox, 0, 0);
            tableLayoutPanel14.Location = new System.Drawing.Point(14, 28);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 1;
            tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel14.Size = new System.Drawing.Size(298, 28);
            tableLayoutPanel14.TabIndex = 2;
            toolTip.SetToolTip(this.tableLayoutPanel14, "Type of instrument.");
            // 
            // keySplitBox
            // 
            keySplitBox.Dock = System.Windows.Forms.DockStyle.Fill;
            keySplitBox.Location = new System.Drawing.Point(201, 3);
            keySplitBox.Name = "keySplitBox";
            keySplitBox.Size = new System.Drawing.Size(94, 22);
            keySplitBox.TabIndex = 2;
            keySplitBox.TabStop = true;
            keySplitBox.Text = "Key Split";
            keySplitBox.UseVisualStyleBackColor = true;
            // 
            // drumSetBox
            // 
            drumSetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            drumSetBox.Location = new System.Drawing.Point(102, 3);
            drumSetBox.Name = "drumSetBox";
            drumSetBox.Size = new System.Drawing.Size(93, 22);
            drumSetBox.TabIndex = 1;
            drumSetBox.TabStop = true;
            drumSetBox.Text = "Drum Set";
            drumSetBox.UseVisualStyleBackColor = true;
            // 
            // directBox
            // 
            directBox.Dock = System.Windows.Forms.DockStyle.Fill;
            directBox.Location = new System.Drawing.Point(3, 3);
            directBox.Name = "directBox";
            directBox.Size = new System.Drawing.Size(93, 22);
            directBox.TabIndex = 0;
            directBox.TabStop = true;
            directBox.Text = "Direct";
            directBox.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label30.Location = new System.Drawing.Point(11, 3);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(301, 20);
            label30.TabIndex = 1;
            label30.Text = "Instrument Type:";
            label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seqArcSeqPanel
            // 
            seqArcSeqPanel.Controls.Add(this.label29);
            seqArcSeqPanel.Controls.Add(this.tableLayoutPanel13);
            seqArcSeqPanel.Dock = System.Windows.Forms.DockStyle.Top;
            seqArcSeqPanel.Location = new System.Drawing.Point(0, 270);
            seqArcSeqPanel.Name = "seqArcSeqPanel";
            seqArcSeqPanel.Size = new System.Drawing.Size(325, 64);
            seqArcSeqPanel.TabIndex = 20;
            seqArcSeqPanel.Visible = false;
            // 
            // label29
            // 
            label29.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label29.Location = new System.Drawing.Point(11, 3);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(301, 20);
            label29.TabIndex = 25;
            label29.Text = "Preview Sequence:";
            label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel13.Controls.Add(this.seqArcSeqComboBox, 0, 0);
            tableLayoutPanel13.Controls.Add(this.seqArcSeqBox, 1, 0);
            tableLayoutPanel13.Location = new System.Drawing.Point(14, 25);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel13.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel13.TabIndex = 24;
            // 
            // seqArcSeqComboBox
            // 
            seqArcSeqComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqArcSeqComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            seqArcSeqComboBox.FormattingEnabled = true;
            seqArcSeqComboBox.Location = new System.Drawing.Point(3, 3);
            seqArcSeqComboBox.Name = "seqArcSeqComboBox";
            seqArcSeqComboBox.Size = new System.Drawing.Size(247, 21);
            seqArcSeqComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.seqArcSeqComboBox, "Sequence to play.");
            // 
            // seqArcSeqBox
            // 
            seqArcSeqBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqArcSeqBox.Location = new System.Drawing.Point(256, 3);
            seqArcSeqBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            seqArcSeqBox.Name = "seqArcSeqBox";
            seqArcSeqBox.Size = new System.Drawing.Size(39, 20);
            seqArcSeqBox.TabIndex = 7;
            toolTip.SetToolTip(this.seqArcSeqBox, "Id of the sequence to play.");
            // 
            // seqArcPanel
            // 
            seqArcPanel.Controls.Add(this.seqArcOpenFileButton);
            seqArcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            seqArcPanel.Location = new System.Drawing.Point(0, 270);
            seqArcPanel.Name = "seqArcPanel";
            seqArcPanel.Size = new System.Drawing.Size(325, 268);
            seqArcPanel.TabIndex = 19;
            seqArcPanel.Visible = false;
            // 
            // seqArcOpenFileButton
            // 
            seqArcOpenFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            seqArcOpenFileButton.Location = new System.Drawing.Point(14, 6);
            seqArcOpenFileButton.Name = "seqArcOpenFileButton";
            seqArcOpenFileButton.Size = new System.Drawing.Size(298, 25);
            seqArcOpenFileButton.TabIndex = 1;
            seqArcOpenFileButton.Text = "Open File";
            seqArcOpenFileButton.UseVisualStyleBackColor = true;
            // 
            // seqPanel
            // 
            seqPanel.Controls.Add(this.tableLayoutPanel11);
            seqPanel.Controls.Add(this.label27);
            seqPanel.Controls.Add(this.seqPlayerPriorityBox);
            seqPanel.Controls.Add(this.label26);
            seqPanel.Controls.Add(this.seqChannelPriorityBox);
            seqPanel.Controls.Add(this.label25);
            seqPanel.Controls.Add(this.seqVolumeBox);
            seqPanel.Controls.Add(this.label24);
            seqPanel.Controls.Add(this.tableLayoutPanel10);
            seqPanel.Controls.Add(this.label23);
            seqPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            seqPanel.Location = new System.Drawing.Point(0, 270);
            seqPanel.Name = "seqPanel";
            seqPanel.Size = new System.Drawing.Size(325, 268);
            seqPanel.TabIndex = 17;
            seqPanel.Visible = false;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel11.ColumnCount = 2;
            tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel11.Controls.Add(this.seqPlayerComboBox, 0, 0);
            tableLayoutPanel11.Controls.Add(this.seqPlayerBox, 1, 0);
            tableLayoutPanel11.Location = new System.Drawing.Point(14, 220);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel11.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel11.TabIndex = 23;
            // 
            // seqPlayerComboBox
            // 
            seqPlayerComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqPlayerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            seqPlayerComboBox.FormattingEnabled = true;
            seqPlayerComboBox.Location = new System.Drawing.Point(3, 3);
            seqPlayerComboBox.Name = "seqPlayerComboBox";
            seqPlayerComboBox.Size = new System.Drawing.Size(247, 21);
            seqPlayerComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.seqPlayerComboBox, "Player to play the sequence.");
            // 
            // seqPlayerBox
            // 
            seqPlayerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqPlayerBox.Location = new System.Drawing.Point(256, 3);
            seqPlayerBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            seqPlayerBox.Name = "seqPlayerBox";
            seqPlayerBox.Size = new System.Drawing.Size(39, 20);
            seqPlayerBox.TabIndex = 7;
            toolTip.SetToolTip(this.seqPlayerBox, "Id of the player to play the sequence.");
            // 
            // label27
            // 
            label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label27.Location = new System.Drawing.Point(11, 198);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(301, 22);
            label27.TabIndex = 22;
            label27.Text = "Player:";
            label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seqPlayerPriorityBox
            // 
            seqPlayerPriorityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            seqPlayerPriorityBox.Location = new System.Drawing.Point(14, 175);
            seqPlayerPriorityBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            seqPlayerPriorityBox.Name = "seqPlayerPriorityBox";
            seqPlayerPriorityBox.Size = new System.Drawing.Size(298, 20);
            seqPlayerPriorityBox.TabIndex = 21;
            toolTip.SetToolTip(this.seqPlayerPriorityBox, "If the sounds can not all be played at once, the one with the highest priority wi" +
        "ll play.");
            // 
            // label26
            // 
            label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label26.Location = new System.Drawing.Point(11, 152);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(301, 22);
            label26.TabIndex = 20;
            label26.Text = "Player Priority:";
            label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seqChannelPriorityBox
            // 
            seqChannelPriorityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            seqChannelPriorityBox.Location = new System.Drawing.Point(14, 129);
            seqChannelPriorityBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            seqChannelPriorityBox.Name = "seqChannelPriorityBox";
            seqChannelPriorityBox.Size = new System.Drawing.Size(298, 20);
            seqChannelPriorityBox.TabIndex = 19;
            toolTip.SetToolTip(this.seqChannelPriorityBox, "If the sounds can not all be played at once, the one with the highest priority wi" +
        "ll play.");
            // 
            // label25
            // 
            label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label25.Location = new System.Drawing.Point(11, 106);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(301, 22);
            label25.TabIndex = 18;
            label25.Text = "Channel Priority:";
            label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seqVolumeBox
            // 
            seqVolumeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            seqVolumeBox.Location = new System.Drawing.Point(14, 82);
            seqVolumeBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            seqVolumeBox.Name = "seqVolumeBox";
            seqVolumeBox.Size = new System.Drawing.Size(298, 20);
            seqVolumeBox.TabIndex = 17;
            toolTip.SetToolTip(this.seqVolumeBox, "The volume of the sequence.");
            // 
            // label24
            // 
            label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label24.Location = new System.Drawing.Point(11, 59);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(301, 22);
            label24.TabIndex = 16;
            label24.Text = "Volume:";
            label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel10.ColumnCount = 2;
            tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel10.Controls.Add(this.seqBankComboBox, 0, 0);
            tableLayoutPanel10.Controls.Add(this.seqBankBox, 1, 0);
            tableLayoutPanel10.Location = new System.Drawing.Point(14, 25);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel10.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel10.TabIndex = 15;
            // 
            // seqBankComboBox
            // 
            seqBankComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqBankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            seqBankComboBox.FormattingEnabled = true;
            seqBankComboBox.Location = new System.Drawing.Point(3, 3);
            seqBankComboBox.Name = "seqBankComboBox";
            seqBankComboBox.Size = new System.Drawing.Size(247, 21);
            seqBankComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.seqBankComboBox, "Bank to use with the sequence.");
            // 
            // seqBankBox
            // 
            seqBankBox.Dock = System.Windows.Forms.DockStyle.Fill;
            seqBankBox.Location = new System.Drawing.Point(256, 3);
            seqBankBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            seqBankBox.Name = "seqBankBox";
            seqBankBox.Size = new System.Drawing.Size(39, 20);
            seqBankBox.TabIndex = 7;
            toolTip.SetToolTip(this.seqBankBox, "Id of the bank to use with the sequence.");
            // 
            // label23
            // 
            label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label23.Location = new System.Drawing.Point(11, 3);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(301, 22);
            label23.TabIndex = 2;
            label23.Text = "Bank:";
            label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerPanel
            // 
            playerPanel.Controls.Add(this.tableLayoutPanel8);
            playerPanel.Controls.Add(this.label19);
            playerPanel.Controls.Add(this.playerHeapSizeBox);
            playerPanel.Controls.Add(this.label18);
            playerPanel.Controls.Add(this.playerMaxSequencesBox);
            playerPanel.Controls.Add(this.label17);
            playerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            playerPanel.Location = new System.Drawing.Point(0, 270);
            playerPanel.Name = "playerPanel";
            playerPanel.Size = new System.Drawing.Size(325, 268);
            playerPanel.TabIndex = 15;
            playerPanel.Visible = false;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel8.ColumnCount = 4;
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.Controls.Add(this.playerFlag15Box, 3, 3);
            tableLayoutPanel8.Controls.Add(this.playerFlag14Box, 2, 3);
            tableLayoutPanel8.Controls.Add(this.playerFlag13Box, 1, 3);
            tableLayoutPanel8.Controls.Add(this.playerFlag12Box, 0, 3);
            tableLayoutPanel8.Controls.Add(this.playerFlag11Box, 3, 2);
            tableLayoutPanel8.Controls.Add(this.playerFlag10Box, 2, 2);
            tableLayoutPanel8.Controls.Add(this.playerFlag9Box, 1, 2);
            tableLayoutPanel8.Controls.Add(this.playerFlag8Box, 0, 2);
            tableLayoutPanel8.Controls.Add(this.playerFlag7Box, 3, 1);
            tableLayoutPanel8.Controls.Add(this.playerFlag6Box, 2, 1);
            tableLayoutPanel8.Controls.Add(this.playerFlag5Box, 1, 1);
            tableLayoutPanel8.Controls.Add(this.playerFlag4Box, 0, 1);
            tableLayoutPanel8.Controls.Add(this.playerFlag3Box, 3, 0);
            tableLayoutPanel8.Controls.Add(this.playerFlag2Box, 2, 0);
            tableLayoutPanel8.Controls.Add(this.playerFlag1Box, 1, 0);
            tableLayoutPanel8.Controls.Add(this.playerFlag0Box, 0, 0);
            tableLayoutPanel8.Location = new System.Drawing.Point(14, 118);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 4;
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel8.Size = new System.Drawing.Size(298, 100);
            tableLayoutPanel8.TabIndex = 10;
            toolTip.SetToolTip(this.tableLayoutPanel8, "Which channels the player is allowed to use.");
            // 
            // playerFlag15Box
            // 
            playerFlag15Box.AutoSize = true;
            playerFlag15Box.Location = new System.Drawing.Point(225, 78);
            playerFlag15Box.Name = "playerFlag15Box";
            playerFlag15Box.Size = new System.Drawing.Size(38, 17);
            playerFlag15Box.TabIndex = 15;
            playerFlag15Box.Text = "15";
            playerFlag15Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag14Box
            // 
            playerFlag14Box.AutoSize = true;
            playerFlag14Box.Location = new System.Drawing.Point(151, 78);
            playerFlag14Box.Name = "playerFlag14Box";
            playerFlag14Box.Size = new System.Drawing.Size(38, 17);
            playerFlag14Box.TabIndex = 14;
            playerFlag14Box.Text = "14";
            playerFlag14Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag13Box
            // 
            playerFlag13Box.AutoSize = true;
            playerFlag13Box.Location = new System.Drawing.Point(77, 78);
            playerFlag13Box.Name = "playerFlag13Box";
            playerFlag13Box.Size = new System.Drawing.Size(38, 17);
            playerFlag13Box.TabIndex = 13;
            playerFlag13Box.Text = "13";
            playerFlag13Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag12Box
            // 
            playerFlag12Box.AutoSize = true;
            playerFlag12Box.Location = new System.Drawing.Point(3, 78);
            playerFlag12Box.Name = "playerFlag12Box";
            playerFlag12Box.Size = new System.Drawing.Size(38, 17);
            playerFlag12Box.TabIndex = 12;
            playerFlag12Box.Text = "12";
            playerFlag12Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag11Box
            // 
            playerFlag11Box.AutoSize = true;
            playerFlag11Box.Location = new System.Drawing.Point(225, 53);
            playerFlag11Box.Name = "playerFlag11Box";
            playerFlag11Box.Size = new System.Drawing.Size(38, 17);
            playerFlag11Box.TabIndex = 11;
            playerFlag11Box.Text = "11";
            playerFlag11Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag10Box
            // 
            playerFlag10Box.AutoSize = true;
            playerFlag10Box.Location = new System.Drawing.Point(151, 53);
            playerFlag10Box.Name = "playerFlag10Box";
            playerFlag10Box.Size = new System.Drawing.Size(38, 17);
            playerFlag10Box.TabIndex = 10;
            playerFlag10Box.Text = "10";
            playerFlag10Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag9Box
            // 
            playerFlag9Box.AutoSize = true;
            playerFlag9Box.Location = new System.Drawing.Point(77, 53);
            playerFlag9Box.Name = "playerFlag9Box";
            playerFlag9Box.Size = new System.Drawing.Size(32, 17);
            playerFlag9Box.TabIndex = 9;
            playerFlag9Box.Text = "9";
            playerFlag9Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag8Box
            // 
            playerFlag8Box.AutoSize = true;
            playerFlag8Box.Location = new System.Drawing.Point(3, 53);
            playerFlag8Box.Name = "playerFlag8Box";
            playerFlag8Box.Size = new System.Drawing.Size(32, 17);
            playerFlag8Box.TabIndex = 8;
            playerFlag8Box.Text = "8";
            playerFlag8Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag7Box
            // 
            playerFlag7Box.AutoSize = true;
            playerFlag7Box.Location = new System.Drawing.Point(225, 28);
            playerFlag7Box.Name = "playerFlag7Box";
            playerFlag7Box.Size = new System.Drawing.Size(32, 17);
            playerFlag7Box.TabIndex = 7;
            playerFlag7Box.Text = "7";
            playerFlag7Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag6Box
            // 
            playerFlag6Box.AutoSize = true;
            playerFlag6Box.Location = new System.Drawing.Point(151, 28);
            playerFlag6Box.Name = "playerFlag6Box";
            playerFlag6Box.Size = new System.Drawing.Size(32, 17);
            playerFlag6Box.TabIndex = 6;
            playerFlag6Box.Text = "6";
            playerFlag6Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag5Box
            // 
            playerFlag5Box.AutoSize = true;
            playerFlag5Box.Location = new System.Drawing.Point(77, 28);
            playerFlag5Box.Name = "playerFlag5Box";
            playerFlag5Box.Size = new System.Drawing.Size(32, 17);
            playerFlag5Box.TabIndex = 5;
            playerFlag5Box.Text = "5";
            playerFlag5Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag4Box
            // 
            playerFlag4Box.AutoSize = true;
            playerFlag4Box.Location = new System.Drawing.Point(3, 28);
            playerFlag4Box.Name = "playerFlag4Box";
            playerFlag4Box.Size = new System.Drawing.Size(32, 17);
            playerFlag4Box.TabIndex = 4;
            playerFlag4Box.Text = "4";
            playerFlag4Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag3Box
            // 
            playerFlag3Box.AutoSize = true;
            playerFlag3Box.Location = new System.Drawing.Point(225, 3);
            playerFlag3Box.Name = "playerFlag3Box";
            playerFlag3Box.Size = new System.Drawing.Size(32, 17);
            playerFlag3Box.TabIndex = 3;
            playerFlag3Box.Text = "3";
            playerFlag3Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag2Box
            // 
            playerFlag2Box.AutoSize = true;
            playerFlag2Box.Location = new System.Drawing.Point(151, 3);
            playerFlag2Box.Name = "playerFlag2Box";
            playerFlag2Box.Size = new System.Drawing.Size(32, 17);
            playerFlag2Box.TabIndex = 2;
            playerFlag2Box.Text = "2";
            playerFlag2Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag1Box
            // 
            playerFlag1Box.AutoSize = true;
            playerFlag1Box.Location = new System.Drawing.Point(77, 3);
            playerFlag1Box.Name = "playerFlag1Box";
            playerFlag1Box.Size = new System.Drawing.Size(32, 17);
            playerFlag1Box.TabIndex = 1;
            playerFlag1Box.Text = "1";
            playerFlag1Box.UseVisualStyleBackColor = true;
            // 
            // playerFlag0Box
            // 
            playerFlag0Box.AutoSize = true;
            playerFlag0Box.Location = new System.Drawing.Point(3, 3);
            playerFlag0Box.Name = "playerFlag0Box";
            playerFlag0Box.Size = new System.Drawing.Size(32, 17);
            playerFlag0Box.TabIndex = 0;
            playerFlag0Box.Text = "0";
            playerFlag0Box.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label19.Location = new System.Drawing.Point(11, 93);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(301, 22);
            label19.TabIndex = 9;
            label19.Text = "Channel Flags:";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerHeapSizeBox
            // 
            playerHeapSizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            playerHeapSizeBox.Hexadecimal = true;
            playerHeapSizeBox.Location = new System.Drawing.Point(14, 70);
            playerHeapSizeBox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            playerHeapSizeBox.Name = "playerHeapSizeBox";
            playerHeapSizeBox.Size = new System.Drawing.Size(298, 20);
            playerHeapSizeBox.TabIndex = 8;
            toolTip.SetToolTip(this.playerHeapSizeBox, "How much memory to reserve in the sound heap for the player.");
            // 
            // label18
            // 
            label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label18.Location = new System.Drawing.Point(11, 48);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(301, 22);
            label18.TabIndex = 7;
            label18.Text = "Heap Size:";
            label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerMaxSequencesBox
            // 
            playerMaxSequencesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            playerMaxSequencesBox.Location = new System.Drawing.Point(14, 25);
            playerMaxSequencesBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            playerMaxSequencesBox.Name = "playerMaxSequencesBox";
            playerMaxSequencesBox.Size = new System.Drawing.Size(298, 20);
            playerMaxSequencesBox.TabIndex = 6;
            toolTip.SetToolTip(this.playerMaxSequencesBox, "Max number of sequences the player can play.");
            // 
            // label17
            // 
            label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label17.Location = new System.Drawing.Point(11, 3);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(301, 22);
            label17.TabIndex = 5;
            label17.Text = "Max Sequences:";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stmPanel
            // 
            stmPanel.Controls.Add(this.stmMonoToStereoBox);
            stmPanel.Controls.Add(this.label16);
            stmPanel.Controls.Add(this.label15);
            stmPanel.Controls.Add(this.tableLayoutPanel7);
            stmPanel.Controls.Add(this.stmPriorityBox);
            stmPanel.Controls.Add(this.label14);
            stmPanel.Controls.Add(this.stmVolumeBox);
            stmPanel.Controls.Add(this.label13);
            stmPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            stmPanel.Location = new System.Drawing.Point(0, 270);
            stmPanel.Name = "stmPanel";
            stmPanel.Size = new System.Drawing.Size(325, 268);
            stmPanel.TabIndex = 14;
            stmPanel.Visible = false;
            // 
            // stmMonoToStereoBox
            // 
            stmMonoToStereoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            stmMonoToStereoBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            stmMonoToStereoBox.Location = new System.Drawing.Point(11, 171);
            stmMonoToStereoBox.Name = "stmMonoToStereoBox";
            stmMonoToStereoBox.Size = new System.Drawing.Size(301, 24);
            stmMonoToStereoBox.TabIndex = 17;
            toolTip.SetToolTip(this.stmMonoToStereoBox, "If the stream is mono, play it through two channels.");
            stmMonoToStereoBox.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label16.Location = new System.Drawing.Point(11, 149);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(301, 22);
            label16.TabIndex = 16;
            label16.Text = "Mono To Stereo:";
            label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label15.Location = new System.Drawing.Point(11, 93);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(301, 22);
            label15.TabIndex = 15;
            label15.Text = "Player:";
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel7.Controls.Add(this.stmPlayerComboBox, 0, 0);
            tableLayoutPanel7.Controls.Add(this.stmPlayerBox, 1, 0);
            tableLayoutPanel7.Location = new System.Drawing.Point(14, 115);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel7.TabIndex = 14;
            // 
            // stmPlayerComboBox
            // 
            stmPlayerComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            stmPlayerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            stmPlayerComboBox.FormattingEnabled = true;
            stmPlayerComboBox.Location = new System.Drawing.Point(3, 3);
            stmPlayerComboBox.Name = "stmPlayerComboBox";
            stmPlayerComboBox.Size = new System.Drawing.Size(247, 21);
            stmPlayerComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.stmPlayerComboBox, "The player to play the stream.");
            // 
            // stmPlayerBox
            // 
            stmPlayerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            stmPlayerBox.Location = new System.Drawing.Point(256, 3);
            stmPlayerBox.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            stmPlayerBox.Name = "stmPlayerBox";
            stmPlayerBox.Size = new System.Drawing.Size(39, 20);
            stmPlayerBox.TabIndex = 7;
            toolTip.SetToolTip(this.stmPlayerBox, "Id of the player to play the stream.");
            // 
            // stmPriorityBox
            // 
            stmPriorityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            stmPriorityBox.Location = new System.Drawing.Point(14, 70);
            stmPriorityBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            stmPriorityBox.Name = "stmPriorityBox";
            stmPriorityBox.Size = new System.Drawing.Size(298, 20);
            stmPriorityBox.TabIndex = 7;
            toolTip.SetToolTip(this.stmPriorityBox, "If the sounds can not all be played at once, the one with the highest priority wi" +
        "ll play.");
            // 
            // label14
            // 
            label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label14.Location = new System.Drawing.Point(11, 48);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(301, 22);
            label14.TabIndex = 6;
            label14.Text = "Priority:";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stmVolumeBox
            // 
            stmVolumeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            stmVolumeBox.Location = new System.Drawing.Point(14, 25);
            stmVolumeBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            stmVolumeBox.Name = "stmVolumeBox";
            stmVolumeBox.Size = new System.Drawing.Size(298, 20);
            stmVolumeBox.TabIndex = 5;
            toolTip.SetToolTip(this.stmVolumeBox, "The volume of the stream.");
            // 
            // label13
            // 
            label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label13.Location = new System.Drawing.Point(11, 3);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(301, 22);
            label13.TabIndex = 4;
            label13.Text = "Volume:";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // streamPlayerPanel
            // 
            streamPlayerPanel.Controls.Add(this.stmPlayerChannelType);
            streamPlayerPanel.Controls.Add(this.label12);
            streamPlayerPanel.Controls.Add(this.tableLayoutPanel6);
            streamPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            streamPlayerPanel.Location = new System.Drawing.Point(0, 270);
            streamPlayerPanel.Name = "streamPlayerPanel";
            streamPlayerPanel.Size = new System.Drawing.Size(325, 268);
            streamPlayerPanel.TabIndex = 13;
            streamPlayerPanel.Visible = false;
            // 
            // stmPlayerChannelType
            // 
            stmPlayerChannelType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            stmPlayerChannelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            stmPlayerChannelType.FormattingEnabled = true;
            stmPlayerChannelType.Items.AddRange(new object[] {
            "Mono",
            "Stereo"});
            stmPlayerChannelType.Location = new System.Drawing.Point(14, 28);
            stmPlayerChannelType.Name = "stmPlayerChannelType";
            stmPlayerChannelType.Size = new System.Drawing.Size(298, 21);
            stmPlayerChannelType.TabIndex = 4;
            toolTip.SetToolTip(this.stmPlayerChannelType, "If the stream is stereo or mono.");
            // 
            // label12
            // 
            label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label12.Location = new System.Drawing.Point(11, 3);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(301, 22);
            label12.TabIndex = 3;
            label12.Text = "Channel Type:";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(this.stmPlayerLeftChannelBox, 0, 1);
            tableLayoutPanel6.Controls.Add(this.stmPlayerRightChannelBox, 0, 1);
            tableLayoutPanel6.Controls.Add(this.rightChannelLabel, 1, 0);
            tableLayoutPanel6.Controls.Add(this.leftChannelLabel, 0, 0);
            tableLayoutPanel6.Location = new System.Drawing.Point(14, 55);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new System.Drawing.Size(298, 45);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // stmPlayerLeftChannelBox
            // 
            stmPlayerLeftChannelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            stmPlayerLeftChannelBox.Location = new System.Drawing.Point(3, 25);
            stmPlayerLeftChannelBox.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            stmPlayerLeftChannelBox.Name = "stmPlayerLeftChannelBox";
            stmPlayerLeftChannelBox.Size = new System.Drawing.Size(143, 20);
            stmPlayerLeftChannelBox.TabIndex = 4;
            toolTip.SetToolTip(this.stmPlayerLeftChannelBox, "Channel to use for the stream.");
            // 
            // stmPlayerRightChannelBox
            // 
            stmPlayerRightChannelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            stmPlayerRightChannelBox.Location = new System.Drawing.Point(152, 25);
            stmPlayerRightChannelBox.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            stmPlayerRightChannelBox.Name = "stmPlayerRightChannelBox";
            stmPlayerRightChannelBox.Size = new System.Drawing.Size(143, 20);
            stmPlayerRightChannelBox.TabIndex = 3;
            toolTip.SetToolTip(this.stmPlayerRightChannelBox, "Channel to use for the stream.");
            // 
            // rightChannelLabel
            // 
            rightChannelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightChannelLabel.Location = new System.Drawing.Point(152, 0);
            rightChannelLabel.Name = "rightChannelLabel";
            rightChannelLabel.Size = new System.Drawing.Size(143, 22);
            rightChannelLabel.TabIndex = 2;
            rightChannelLabel.Text = "Right Channel:";
            rightChannelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftChannelLabel
            // 
            leftChannelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftChannelLabel.Location = new System.Drawing.Point(3, 0);
            leftChannelLabel.Name = "leftChannelLabel";
            leftChannelLabel.Size = new System.Drawing.Size(143, 22);
            leftChannelLabel.TabIndex = 1;
            leftChannelLabel.Text = "Left Channel:";
            leftChannelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpPanel
            // 
            grpPanel.Controls.Add(this.grpEntries);
            grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            grpPanel.Location = new System.Drawing.Point(0, 270);
            grpPanel.Name = "grpPanel";
            grpPanel.Size = new System.Drawing.Size(325, 268);
            grpPanel.TabIndex = 12;
            grpPanel.Visible = false;
            // 
            // grpEntries
            // 
            grpEntries.AllowUserToOrderColumns = true;
            grpEntries.AllowUserToResizeRows = false;
            grpEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grpEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            item,
            loadFlags});
            grpEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            grpEntries.Location = new System.Drawing.Point(0, 0);
            grpEntries.Name = "grpEntries";
            grpEntries.Size = new System.Drawing.Size(325, 268);
            grpEntries.TabIndex = 0;
            // 
            // item
            // 
            item.FillWeight = 1750F;
            item.HeaderText = "Item";
            item.Name = "item";
            item.Width = 175;
            // 
            // loadFlags
            // 
            loadFlags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            loadFlags.HeaderText = "Load Flags";
            loadFlags.Name = "loadFlags";
            loadFlags.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            loadFlags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bankPanel
            // 
            bankPanel.Controls.Add(this.tableLayoutPanel5);
            bankPanel.Controls.Add(this.label11);
            bankPanel.Controls.Add(this.tableLayoutPanel4);
            bankPanel.Controls.Add(this.label10);
            bankPanel.Controls.Add(this.tableLayoutPanel3);
            bankPanel.Controls.Add(this.label7);
            bankPanel.Controls.Add(this.tableLayoutPanel2);
            bankPanel.Controls.Add(this.label6);
            bankPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            bankPanel.Location = new System.Drawing.Point(0, 270);
            bankPanel.Name = "bankPanel";
            bankPanel.Size = new System.Drawing.Size(325, 268);
            bankPanel.TabIndex = 11;
            bankPanel.Visible = false;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel5.Controls.Add(this.bnkWar3ComboBox, 0, 0);
            tableLayoutPanel5.Controls.Add(this.bnkWar3Box, 1, 0);
            tableLayoutPanel5.Location = new System.Drawing.Point(14, 193);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel5.TabIndex = 13;
            // 
            // bnkWar3ComboBox
            // 
            bnkWar3ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bnkWar3ComboBox.FormattingEnabled = true;
            bnkWar3ComboBox.Location = new System.Drawing.Point(3, 3);
            bnkWar3ComboBox.Name = "bnkWar3ComboBox";
            bnkWar3ComboBox.Size = new System.Drawing.Size(247, 21);
            bnkWar3ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.bnkWar3ComboBox, "Wave archive to be used for the bank.");
            // 
            // bnkWar3Box
            // 
            bnkWar3Box.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar3Box.Location = new System.Drawing.Point(256, 3);
            bnkWar3Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            bnkWar3Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            bnkWar3Box.Name = "bnkWar3Box";
            bnkWar3Box.Size = new System.Drawing.Size(39, 20);
            bnkWar3Box.TabIndex = 7;
            toolTip.SetToolTip(this.bnkWar3Box, "Id of the wave archive to use for this bank.");
            // 
            // label11
            // 
            label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label11.Location = new System.Drawing.Point(11, 171);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(301, 22);
            label11.TabIndex = 12;
            label11.Text = "Wave Archive 3:";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel4.Controls.Add(this.bnkWar2ComboBox, 0, 0);
            tableLayoutPanel4.Controls.Add(this.bnkWar2Box, 1, 0);
            tableLayoutPanel4.Location = new System.Drawing.Point(14, 137);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel4.TabIndex = 11;
            // 
            // bnkWar2ComboBox
            // 
            bnkWar2ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bnkWar2ComboBox.FormattingEnabled = true;
            bnkWar2ComboBox.Location = new System.Drawing.Point(3, 3);
            bnkWar2ComboBox.Name = "bnkWar2ComboBox";
            bnkWar2ComboBox.Size = new System.Drawing.Size(247, 21);
            bnkWar2ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.bnkWar2ComboBox, "Wave archive to be used for the bank.");
            // 
            // bnkWar2Box
            // 
            bnkWar2Box.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar2Box.Location = new System.Drawing.Point(256, 3);
            bnkWar2Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            bnkWar2Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            bnkWar2Box.Name = "bnkWar2Box";
            bnkWar2Box.Size = new System.Drawing.Size(39, 20);
            bnkWar2Box.TabIndex = 7;
            toolTip.SetToolTip(this.bnkWar2Box, "Id of the wave archive to use for this bank.");
            // 
            // label10
            // 
            label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label10.Location = new System.Drawing.Point(11, 115);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(301, 22);
            label10.TabIndex = 10;
            label10.Text = "Wave Archive 2:";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel3.Controls.Add(this.bnkWar1ComboBox, 0, 0);
            tableLayoutPanel3.Controls.Add(this.bnkWar1Box, 1, 0);
            tableLayoutPanel3.Location = new System.Drawing.Point(14, 81);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // bnkWar1ComboBox
            // 
            bnkWar1ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bnkWar1ComboBox.FormattingEnabled = true;
            bnkWar1ComboBox.Location = new System.Drawing.Point(3, 3);
            bnkWar1ComboBox.Name = "bnkWar1ComboBox";
            bnkWar1ComboBox.Size = new System.Drawing.Size(247, 21);
            bnkWar1ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.bnkWar1ComboBox, "Wave archive to be used for the bank.");
            // 
            // bnkWar1Box
            // 
            bnkWar1Box.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar1Box.Location = new System.Drawing.Point(256, 3);
            bnkWar1Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            bnkWar1Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            bnkWar1Box.Name = "bnkWar1Box";
            bnkWar1Box.Size = new System.Drawing.Size(39, 20);
            bnkWar1Box.TabIndex = 7;
            toolTip.SetToolTip(this.bnkWar1Box, "Id of the wave archive to use for this bank.");
            // 
            // label7
            // 
            label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label7.Location = new System.Drawing.Point(11, 59);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(301, 22);
            label7.TabIndex = 8;
            label7.Text = "Wave Archive 1:";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel2.Controls.Add(this.bnkWar0ComboBox, 0, 0);
            tableLayoutPanel2.Controls.Add(this.bnkWar0Box, 1, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(14, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // bnkWar0ComboBox
            // 
            bnkWar0ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar0ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bnkWar0ComboBox.FormattingEnabled = true;
            bnkWar0ComboBox.Location = new System.Drawing.Point(3, 3);
            bnkWar0ComboBox.Name = "bnkWar0ComboBox";
            bnkWar0ComboBox.Size = new System.Drawing.Size(247, 21);
            bnkWar0ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.bnkWar0ComboBox, "Wave archive to be used for the bank.");
            // 
            // bnkWar0Box
            // 
            bnkWar0Box.Dock = System.Windows.Forms.DockStyle.Fill;
            bnkWar0Box.Location = new System.Drawing.Point(256, 3);
            bnkWar0Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            bnkWar0Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            bnkWar0Box.Name = "bnkWar0Box";
            bnkWar0Box.Size = new System.Drawing.Size(39, 20);
            bnkWar0Box.TabIndex = 7;
            toolTip.SetToolTip(this.bnkWar0Box, "Id of the wave archive to use for this bank.");
            // 
            // label6
            // 
            label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label6.Location = new System.Drawing.Point(11, 3);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(301, 22);
            label6.TabIndex = 2;
            label6.Text = "Wave Archive 0:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blankPanel
            // 
            blankPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            blankPanel.Location = new System.Drawing.Point(0, 270);
            blankPanel.Name = "blankPanel";
            blankPanel.Size = new System.Drawing.Size(325, 268);
            blankPanel.TabIndex = 10;
            blankPanel.Visible = false;
            // 
            // warPanel
            // 
            warPanel.Controls.Add(this.loadIndividuallyBox);
            warPanel.Controls.Add(this.label9);
            warPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            warPanel.Location = new System.Drawing.Point(0, 270);
            warPanel.Name = "warPanel";
            warPanel.Size = new System.Drawing.Size(325, 268);
            warPanel.TabIndex = 9;
            warPanel.Visible = false;
            // 
            // loadIndividuallyBox
            // 
            loadIndividuallyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            loadIndividuallyBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            loadIndividuallyBox.Location = new System.Drawing.Point(11, 25);
            loadIndividuallyBox.Name = "loadIndividuallyBox";
            loadIndividuallyBox.Size = new System.Drawing.Size(301, 24);
            loadIndividuallyBox.TabIndex = 1;
            toolTip.SetToolTip(this.loadIndividuallyBox, "If the wave archive should be loaded individually.");
            loadIndividuallyBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label9.Location = new System.Drawing.Point(11, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(301, 22);
            label9.TabIndex = 0;
            label9.Text = "Load Individually:";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // forceUniqueFilePanel
            // 
            forceUniqueFilePanel.Controls.Add(this.forceUniqueFileBox);
            forceUniqueFilePanel.Controls.Add(this.label8);
            forceUniqueFilePanel.Dock = System.Windows.Forms.DockStyle.Top;
            forceUniqueFilePanel.Location = new System.Drawing.Point(0, 231);
            forceUniqueFilePanel.Name = "forceUniqueFilePanel";
            forceUniqueFilePanel.Size = new System.Drawing.Size(325, 39);
            forceUniqueFilePanel.TabIndex = 8;
            forceUniqueFilePanel.Visible = false;
            // 
            // forceUniqueFileBox
            // 
            forceUniqueFileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            forceUniqueFileBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            forceUniqueFileBox.Location = new System.Drawing.Point(11, 19);
            forceUniqueFileBox.Name = "forceUniqueFileBox";
            forceUniqueFileBox.Size = new System.Drawing.Size(301, 18);
            forceUniqueFileBox.TabIndex = 1;
            toolTip.SetToolTip(this.forceUniqueFileBox, "Write this file in the sound archive as its own file, even if it has the exact sa" +
        "me data as another one. If this is not checked, files will be shared between ent" +
        "ries for efficiency.");
            forceUniqueFileBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label8.Location = new System.Drawing.Point(11, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(301, 17);
            label8.TabIndex = 0;
            label8.Text = "Force Unique File:";
            label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // indexPanel
            // 
            indexPanel.Controls.Add(this.swapAtIndexButton);
            indexPanel.Controls.Add(this.itemIndexBox);
            indexPanel.Controls.Add(this.label5);
            indexPanel.Dock = System.Windows.Forms.DockStyle.Top;
            indexPanel.Location = new System.Drawing.Point(0, 150);
            indexPanel.Name = "indexPanel";
            indexPanel.Size = new System.Drawing.Size(325, 81);
            indexPanel.TabIndex = 0;
            indexPanel.Visible = false;
            // 
            // swapAtIndexButton
            // 
            swapAtIndexButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            swapAtIndexButton.Location = new System.Drawing.Point(14, 49);
            swapAtIndexButton.Name = "swapAtIndexButton";
            swapAtIndexButton.Size = new System.Drawing.Size(298, 25);
            swapAtIndexButton.TabIndex = 0;
            swapAtIndexButton.Text = "Swap With Index";
            toolTip.SetToolTip(this.swapAtIndexButton, "Swap this entry with the one at the new index. If that entry doesn\'t exist, simpl" +
        "y just change the index.");
            swapAtIndexButton.UseVisualStyleBackColor = true;
            // 
            // itemIndexBox
            // 
            itemIndexBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            itemIndexBox.Location = new System.Drawing.Point(14, 23);
            itemIndexBox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            itemIndexBox.Name = "itemIndexBox";
            itemIndexBox.Size = new System.Drawing.Size(298, 20);
            itemIndexBox.TabIndex = 1;
            toolTip.SetToolTip(this.itemIndexBox, "The index of the item as referenced to by the game.");
            // 
            // label5
            // 
            label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label5.Location = new System.Drawing.Point(11, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(301, 20);
            label5.TabIndex = 0;
            label5.Text = "Item Index:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(this.seqExportModeBox);
            settingsPanel.Controls.Add(this.label4);
            settingsPanel.Controls.Add(this.seqImportModeBox);
            settingsPanel.Controls.Add(this.label3);
            settingsPanel.Controls.Add(this.writeNamesBox);
            settingsPanel.Controls.Add(this.label2);
            settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            settingsPanel.Location = new System.Drawing.Point(0, 150);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new System.Drawing.Size(325, 388);
            settingsPanel.TabIndex = 1;
            settingsPanel.Visible = false;
            // 
            // seqExportModeBox
            // 
            seqExportModeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            seqExportModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            seqExportModeBox.FormattingEnabled = true;
            seqExportModeBox.Items.AddRange(new object[] {
            "Nitro Studio",
            "Sseq2Midi"});
            seqExportModeBox.Location = new System.Drawing.Point(11, 126);
            seqExportModeBox.Name = "seqExportModeBox";
            seqExportModeBox.Size = new System.Drawing.Size(301, 21);
            seqExportModeBox.TabIndex = 5;
            toolTip.SetToolTip(this.seqExportModeBox, "What program should be used to export sequences. Nitro Studio is my custom export" +
        "er, while Sseq2Midi is the exe included. I recommend you use my exporter.");
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label4.Location = new System.Drawing.Point(11, 101);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(301, 22);
            label4.TabIndex = 4;
            label4.Text = "Sequence Export Mode:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seqImportModeBox
            // 
            seqImportModeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            seqImportModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            seqImportModeBox.FormattingEnabled = true;
            seqImportModeBox.Items.AddRange(new object[] {
            "Nitro Studio",
            "Midi2Sseq",
            "Nintendo Tools"});
            seqImportModeBox.Location = new System.Drawing.Point(11, 77);
            seqImportModeBox.Name = "seqImportModeBox";
            seqImportModeBox.Size = new System.Drawing.Size(301, 21);
            seqImportModeBox.TabIndex = 3;
            toolTip.SetToolTip(this.seqImportModeBox, resources.GetString("seqImportModeBox.ToolTip"));
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.Location = new System.Drawing.Point(11, 52);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(301, 22);
            label3.TabIndex = 2;
            label3.Text = "Sequence Import Mode:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // writeNamesBox
            // 
            writeNamesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            writeNamesBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            writeNamesBox.Location = new System.Drawing.Point(11, 25);
            writeNamesBox.Name = "writeNamesBox";
            writeNamesBox.Size = new System.Drawing.Size(301, 24);
            writeNamesBox.TabIndex = 1;
            toolTip.SetToolTip(this.writeNamesBox, "If the editor should export names for the sound archive.");
            writeNamesBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.Location = new System.Drawing.Point(11, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(301, 22);
            label2.TabIndex = 0;
            label2.Text = "Write Names:";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // noInfoPanel
            // 
            noInfoPanel.Controls.Add(this.label1);
            noInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            noInfoPanel.Location = new System.Drawing.Point(0, 150);
            noInfoPanel.Name = "noInfoPanel";
            noInfoPanel.Size = new System.Drawing.Size(325, 388);
            noInfoPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(325, 388);
            label1.TabIndex = 0;
            label1.Text = "No Valid Info Selected!";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kermalisSoundPlayerPanel
            // 
            kermalisSoundPlayerPanel.Controls.Add(this.kermalisPosition);
            kermalisSoundPlayerPanel.Controls.Add(this.tableLayoutPanel9);
            kermalisSoundPlayerPanel.Controls.Add(this.kermalisPlayButton);
            kermalisSoundPlayerPanel.Controls.Add(this.soundPlayerLabel);
            kermalisSoundPlayerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            kermalisSoundPlayerPanel.Location = new System.Drawing.Point(0, 0);
            kermalisSoundPlayerPanel.Name = "kermalisSoundPlayerPanel";
            kermalisSoundPlayerPanel.Size = new System.Drawing.Size(325, 150);
            kermalisSoundPlayerPanel.TabIndex = 16;
            kermalisSoundPlayerPanel.Visible = false;
            // 
            // kermalisPosition
            // 
            kermalisPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            kermalisPosition.LargeChange = 20;
            kermalisPosition.Location = new System.Drawing.Point(14, 118);
            kermalisPosition.Maximum = 100;
            kermalisPosition.Name = "kermalisPosition";
            kermalisPosition.Size = new System.Drawing.Size(298, 45);
            kermalisPosition.TabIndex = 5;
            kermalisPosition.TickFrequency = 5;
            toolTip.SetToolTip(this.kermalisPosition, "Sound position.");
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(this.label22, 1, 1);
            tableLayoutPanel9.Controls.Add(this.label21, 0, 1);
            tableLayoutPanel9.Controls.Add(this.kermalisStopButton, 1, 0);
            tableLayoutPanel9.Controls.Add(this.kermalisPauseButton, 0, 0);
            tableLayoutPanel9.Controls.Add(this.kermalisVolumeSlider, 0, 2);
            tableLayoutPanel9.Controls.Add(this.kermalisLoopBox, 1, 2);
            tableLayoutPanel9.Location = new System.Drawing.Point(14, 49);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 3;
            tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            tableLayoutPanel9.Size = new System.Drawing.Size(298, 63);
            tableLayoutPanel9.TabIndex = 4;
            // 
            // label22
            // 
            label22.Dock = System.Windows.Forms.DockStyle.Fill;
            label22.Location = new System.Drawing.Point(152, 27);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(143, 15);
            label22.TabIndex = 5;
            label22.Text = "Loop:";
            label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label21
            // 
            label21.Dock = System.Windows.Forms.DockStyle.Fill;
            label21.Location = new System.Drawing.Point(3, 27);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(143, 15);
            label21.TabIndex = 4;
            label21.Text = "Volume:";
            label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // kermalisStopButton
            // 
            kermalisStopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            kermalisStopButton.Location = new System.Drawing.Point(152, 3);
            kermalisStopButton.Name = "kermalisStopButton";
            kermalisStopButton.Size = new System.Drawing.Size(143, 21);
            kermalisStopButton.TabIndex = 1;
            kermalisStopButton.Text = "Stop";
            kermalisStopButton.UseVisualStyleBackColor = true;
            // 
            // kermalisPauseButton
            // 
            kermalisPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            kermalisPauseButton.Location = new System.Drawing.Point(3, 3);
            kermalisPauseButton.Name = "kermalisPauseButton";
            kermalisPauseButton.Size = new System.Drawing.Size(143, 21);
            kermalisPauseButton.TabIndex = 0;
            kermalisPauseButton.Text = "Pause / Resume";
            kermalisPauseButton.UseVisualStyleBackColor = true;
            // 
            // kermalisVolumeSlider
            // 
            kermalisVolumeSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            kermalisVolumeSlider.LargeChange = 10;
            kermalisVolumeSlider.Location = new System.Drawing.Point(3, 45);
            kermalisVolumeSlider.Maximum = 100;
            kermalisVolumeSlider.Name = "kermalisVolumeSlider";
            kermalisVolumeSlider.Size = new System.Drawing.Size(143, 21);
            kermalisVolumeSlider.SmallChange = 5;
            kermalisVolumeSlider.TabIndex = 2;
            kermalisVolumeSlider.TickFrequency = 10;
            kermalisVolumeSlider.Value = 75;
            // 
            // kermalisLoopBox
            // 
            kermalisLoopBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            kermalisLoopBox.Dock = System.Windows.Forms.DockStyle.Fill;
            kermalisLoopBox.Location = new System.Drawing.Point(152, 45);
            kermalisLoopBox.Name = "kermalisLoopBox";
            kermalisLoopBox.Size = new System.Drawing.Size(143, 21);
            kermalisLoopBox.TabIndex = 3;
            kermalisLoopBox.UseVisualStyleBackColor = true;
            // 
            // kermalisPlayButton
            // 
            kermalisPlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            kermalisPlayButton.Location = new System.Drawing.Point(14, 25);
            kermalisPlayButton.Name = "kermalisPlayButton";
            kermalisPlayButton.Size = new System.Drawing.Size(298, 20);
            kermalisPlayButton.TabIndex = 3;
            kermalisPlayButton.Text = "Play";
            kermalisPlayButton.UseVisualStyleBackColor = true;
            // 
            // soundPlayerLabel
            // 
            soundPlayerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            soundPlayerLabel.Location = new System.Drawing.Point(11, 3);
            soundPlayerLabel.Name = "soundPlayerLabel";
            soundPlayerLabel.Size = new System.Drawing.Size(301, 22);
            soundPlayerLabel.TabIndex = 1;
            soundPlayerLabel.Text = "Kermalis Sound Player:";
            soundPlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPianoKeys
            // 
            pnlPianoKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            pnlPianoKeys.BackColor = System.Drawing.SystemColors.ControlLightLight;
            pnlPianoKeys.Controls.Add(this.pkeyC7);
            pnlPianoKeys.Controls.Add(this.pkeyE7);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp7);
            pnlPianoKeys.Controls.Add(this.pkeyD7);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp7);
            pnlPianoKeys.Controls.Add(this.pkeyF7);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp7);
            pnlPianoKeys.Controls.Add(this.pkeyG7);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp7);
            pnlPianoKeys.Controls.Add(this.pkeyA7);
            pnlPianoKeys.Controls.Add(this.pkeyASharp7);
            pnlPianoKeys.Controls.Add(this.pkeyB7);
            pnlPianoKeys.Controls.Add(this.pkeyC6);
            pnlPianoKeys.Controls.Add(this.pkeyE6);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp6);
            pnlPianoKeys.Controls.Add(this.pkeyD6);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp6);
            pnlPianoKeys.Controls.Add(this.pkeyF6);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp6);
            pnlPianoKeys.Controls.Add(this.pkeyG6);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp6);
            pnlPianoKeys.Controls.Add(this.pkeyA6);
            pnlPianoKeys.Controls.Add(this.pkeyASharp6);
            pnlPianoKeys.Controls.Add(this.pkeyB6);
            pnlPianoKeys.Controls.Add(this.pkeyC1);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp1);
            pnlPianoKeys.Controls.Add(this.pkeyD1);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp1);
            pnlPianoKeys.Controls.Add(this.pkeyE1);
            pnlPianoKeys.Controls.Add(this.pkeyF1);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp1);
            pnlPianoKeys.Controls.Add(this.pkeyG1);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp1);
            pnlPianoKeys.Controls.Add(this.pkeyA1);
            pnlPianoKeys.Controls.Add(this.pkeyASharp1);
            pnlPianoKeys.Controls.Add(this.pkeyB1);
            pnlPianoKeys.Controls.Add(this.pkeyC2);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp2);
            pnlPianoKeys.Controls.Add(this.pkeyD2);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp2);
            pnlPianoKeys.Controls.Add(this.pkeyE2);
            pnlPianoKeys.Controls.Add(this.pkeyF2);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp2);
            pnlPianoKeys.Controls.Add(this.pkeyG2);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp2);
            pnlPianoKeys.Controls.Add(this.pkeyA2);
            pnlPianoKeys.Controls.Add(this.pkeyASharp2);
            pnlPianoKeys.Controls.Add(this.pkeyB2);
            pnlPianoKeys.Controls.Add(this.pkeyC3);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp3);
            pnlPianoKeys.Controls.Add(this.pkeyD3);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp3);
            pnlPianoKeys.Controls.Add(this.pkeyE3);
            pnlPianoKeys.Controls.Add(this.pkeyF3);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp3);
            pnlPianoKeys.Controls.Add(this.pkeyG3);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp3);
            pnlPianoKeys.Controls.Add(this.pkeyA3);
            pnlPianoKeys.Controls.Add(this.pkeyASharp3);
            pnlPianoKeys.Controls.Add(this.pkeyB3);
            pnlPianoKeys.Controls.Add(this.pkeyC4);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp4);
            pnlPianoKeys.Controls.Add(this.pkeyD4);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp4);
            pnlPianoKeys.Controls.Add(this.pkeyE4);
            pnlPianoKeys.Controls.Add(this.pkeyF4);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp4);
            pnlPianoKeys.Controls.Add(this.pkeyG4);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp4);
            pnlPianoKeys.Controls.Add(this.pkeyA4);
            pnlPianoKeys.Controls.Add(this.pkeyASharp4);
            pnlPianoKeys.Controls.Add(this.pkeyB4);
            pnlPianoKeys.Controls.Add(this.pkeyC5);
            pnlPianoKeys.Controls.Add(this.pkeyCSharp5);
            pnlPianoKeys.Controls.Add(this.pkeyD5);
            pnlPianoKeys.Controls.Add(this.pkeyDSharp5);
            pnlPianoKeys.Controls.Add(this.pkeyE5);
            pnlPianoKeys.Controls.Add(this.pkeyF5);
            pnlPianoKeys.Controls.Add(this.pkeyFSharp5);
            pnlPianoKeys.Controls.Add(this.pkeyG5);
            pnlPianoKeys.Controls.Add(this.pkeyGSharp5);
            pnlPianoKeys.Controls.Add(this.pkeyA5);
            pnlPianoKeys.Controls.Add(this.pkeyASharp5);
            pnlPianoKeys.Controls.Add(this.pkeyB5);
            pnlPianoKeys.Controls.Add(this.pkeyC8);
            pnlPianoKeys.Location = new System.Drawing.Point(44, 478);
            pnlPianoKeys.Name = "pnlPianoKeys";
            pnlPianoKeys.Size = new System.Drawing.Size(565, 46);
            pnlPianoKeys.TabIndex = 6;
            pnlPianoKeys.Visible = false;
            // 
            // pkeyC7
            // 
            pkeyC7.KeyOffColor = System.Drawing.Color.White;
            pkeyC7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC7.Location = new System.Drawing.Point(466, 2);
            pkeyC7.Name = "pkeyC7";
            pkeyC7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC7.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC7.Size = new System.Drawing.Size(12, 42);
            pkeyC7.TabIndex = 83;
            pkeyC7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE7
            // 
            pkeyE7.KeyOffColor = System.Drawing.Color.White;
            pkeyE7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE7.Location = new System.Drawing.Point(488, 2);
            pkeyE7.Name = "pkeyE7";
            pkeyE7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE7.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE7.Size = new System.Drawing.Size(12, 42);
            pkeyE7.TabIndex = 84;
            pkeyE7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp7
            // 
            pkeyCSharp7.BackColor = System.Drawing.Color.Black;
            pkeyCSharp7.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp7.Location = new System.Drawing.Point(474, 2);
            pkeyCSharp7.Name = "pkeyCSharp7";
            pkeyCSharp7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp7.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp7.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp7.TabIndex = 74;
            pkeyCSharp7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD7
            // 
            pkeyD7.KeyOffColor = System.Drawing.Color.White;
            pkeyD7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD7.Location = new System.Drawing.Point(477, 2);
            pkeyD7.Name = "pkeyD7";
            pkeyD7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD7.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD7.Size = new System.Drawing.Size(12, 42);
            pkeyD7.TabIndex = 73;
            pkeyD7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp7
            // 
            pkeyDSharp7.BackColor = System.Drawing.Color.Black;
            pkeyDSharp7.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp7.Location = new System.Drawing.Point(485, 2);
            pkeyDSharp7.Name = "pkeyDSharp7";
            pkeyDSharp7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp7.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp7.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp7.TabIndex = 75;
            pkeyDSharp7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF7
            // 
            pkeyF7.KeyOffColor = System.Drawing.Color.White;
            pkeyF7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF7.Location = new System.Drawing.Point(499, 2);
            pkeyF7.Name = "pkeyF7";
            pkeyF7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF7.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF7.Size = new System.Drawing.Size(12, 42);
            pkeyF7.TabIndex = 76;
            pkeyF7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp7
            // 
            pkeyFSharp7.BackColor = System.Drawing.Color.Black;
            pkeyFSharp7.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp7.Location = new System.Drawing.Point(507, 2);
            pkeyFSharp7.Name = "pkeyFSharp7";
            pkeyFSharp7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp7.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp7.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp7.TabIndex = 78;
            pkeyFSharp7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG7
            // 
            pkeyG7.KeyOffColor = System.Drawing.Color.White;
            pkeyG7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG7.Location = new System.Drawing.Point(510, 2);
            pkeyG7.Name = "pkeyG7";
            pkeyG7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG7.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG7.Size = new System.Drawing.Size(12, 42);
            pkeyG7.TabIndex = 77;
            pkeyG7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp7
            // 
            pkeyGSharp7.BackColor = System.Drawing.Color.Black;
            pkeyGSharp7.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp7.Location = new System.Drawing.Point(518, 2);
            pkeyGSharp7.Name = "pkeyGSharp7";
            pkeyGSharp7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp7.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp7.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp7.TabIndex = 79;
            pkeyGSharp7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA7
            // 
            pkeyA7.KeyOffColor = System.Drawing.Color.White;
            pkeyA7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA7.Location = new System.Drawing.Point(521, 2);
            pkeyA7.Name = "pkeyA7";
            pkeyA7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA7.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA7.Size = new System.Drawing.Size(12, 42);
            pkeyA7.TabIndex = 80;
            pkeyA7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp7
            // 
            pkeyASharp7.BackColor = System.Drawing.Color.Black;
            pkeyASharp7.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp7.Location = new System.Drawing.Point(529, 2);
            pkeyASharp7.Name = "pkeyASharp7";
            pkeyASharp7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp7.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp7.Size = new System.Drawing.Size(8, 29);
            pkeyASharp7.TabIndex = 81;
            pkeyASharp7.Text = "pianoKey13";
            pkeyASharp7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB7
            // 
            pkeyB7.KeyOffColor = System.Drawing.Color.White;
            pkeyB7.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB7.Location = new System.Drawing.Point(532, 2);
            pkeyB7.Name = "pkeyB7";
            pkeyB7.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB7.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB7.Size = new System.Drawing.Size(12, 42);
            pkeyB7.TabIndex = 82;
            pkeyB7.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC6
            // 
            pkeyC6.KeyOffColor = System.Drawing.Color.White;
            pkeyC6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC6.Location = new System.Drawing.Point(389, 2);
            pkeyC6.Name = "pkeyC6";
            pkeyC6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC6.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC6.Size = new System.Drawing.Size(12, 42);
            pkeyC6.TabIndex = 71;
            pkeyC6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE6
            // 
            pkeyE6.KeyOffColor = System.Drawing.Color.White;
            pkeyE6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE6.Location = new System.Drawing.Point(411, 2);
            pkeyE6.Name = "pkeyE6";
            pkeyE6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE6.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE6.Size = new System.Drawing.Size(12, 42);
            pkeyE6.TabIndex = 72;
            pkeyE6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp6
            // 
            pkeyCSharp6.BackColor = System.Drawing.Color.Black;
            pkeyCSharp6.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp6.Location = new System.Drawing.Point(397, 2);
            pkeyCSharp6.Name = "pkeyCSharp6";
            pkeyCSharp6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp6.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp6.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp6.TabIndex = 62;
            pkeyCSharp6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD6
            // 
            pkeyD6.KeyOffColor = System.Drawing.Color.White;
            pkeyD6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD6.Location = new System.Drawing.Point(400, 2);
            pkeyD6.Name = "pkeyD6";
            pkeyD6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD6.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD6.Size = new System.Drawing.Size(12, 42);
            pkeyD6.TabIndex = 61;
            pkeyD6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp6
            // 
            pkeyDSharp6.BackColor = System.Drawing.Color.Black;
            pkeyDSharp6.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp6.Location = new System.Drawing.Point(408, 2);
            pkeyDSharp6.Name = "pkeyDSharp6";
            pkeyDSharp6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp6.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp6.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp6.TabIndex = 63;
            pkeyDSharp6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF6
            // 
            pkeyF6.KeyOffColor = System.Drawing.Color.White;
            pkeyF6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF6.Location = new System.Drawing.Point(422, 2);
            pkeyF6.Name = "pkeyF6";
            pkeyF6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF6.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF6.Size = new System.Drawing.Size(12, 42);
            pkeyF6.TabIndex = 64;
            pkeyF6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp6
            // 
            pkeyFSharp6.BackColor = System.Drawing.Color.Black;
            pkeyFSharp6.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp6.Location = new System.Drawing.Point(430, 2);
            pkeyFSharp6.Name = "pkeyFSharp6";
            pkeyFSharp6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp6.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp6.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp6.TabIndex = 66;
            pkeyFSharp6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG6
            // 
            pkeyG6.KeyOffColor = System.Drawing.Color.White;
            pkeyG6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG6.Location = new System.Drawing.Point(433, 2);
            pkeyG6.Name = "pkeyG6";
            pkeyG6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG6.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG6.Size = new System.Drawing.Size(12, 42);
            pkeyG6.TabIndex = 65;
            pkeyG6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp6
            // 
            pkeyGSharp6.BackColor = System.Drawing.Color.Black;
            pkeyGSharp6.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp6.Location = new System.Drawing.Point(441, 2);
            pkeyGSharp6.Name = "pkeyGSharp6";
            pkeyGSharp6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp6.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp6.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp6.TabIndex = 67;
            pkeyGSharp6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA6
            // 
            pkeyA6.KeyOffColor = System.Drawing.Color.White;
            pkeyA6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA6.Location = new System.Drawing.Point(444, 2);
            pkeyA6.Name = "pkeyA6";
            pkeyA6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA6.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA6.Size = new System.Drawing.Size(12, 42);
            pkeyA6.TabIndex = 68;
            pkeyA6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp6
            // 
            pkeyASharp6.BackColor = System.Drawing.Color.Black;
            pkeyASharp6.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp6.Location = new System.Drawing.Point(452, 2);
            pkeyASharp6.Name = "pkeyASharp6";
            pkeyASharp6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp6.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp6.Size = new System.Drawing.Size(8, 29);
            pkeyASharp6.TabIndex = 69;
            pkeyASharp6.Text = "pianoKey13";
            pkeyASharp6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB6
            // 
            pkeyB6.KeyOffColor = System.Drawing.Color.White;
            pkeyB6.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB6.Location = new System.Drawing.Point(455, 2);
            pkeyB6.Name = "pkeyB6";
            pkeyB6.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB6.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB6.Size = new System.Drawing.Size(12, 42);
            pkeyB6.TabIndex = 70;
            pkeyB6.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC1
            // 
            pkeyC1.KeyOffColor = System.Drawing.Color.White;
            pkeyC1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC1.Location = new System.Drawing.Point(4, 2);
            pkeyC1.Name = "pkeyC1";
            pkeyC1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC1.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC1.Size = new System.Drawing.Size(12, 42);
            pkeyC1.TabIndex = 0;
            pkeyC1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp1
            // 
            pkeyCSharp1.BackColor = System.Drawing.Color.Black;
            pkeyCSharp1.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp1.Location = new System.Drawing.Point(12, 2);
            pkeyCSharp1.Name = "pkeyCSharp1";
            pkeyCSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp1.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp1.TabIndex = 3;
            pkeyCSharp1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD1
            // 
            pkeyD1.KeyOffColor = System.Drawing.Color.White;
            pkeyD1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD1.Location = new System.Drawing.Point(15, 2);
            pkeyD1.Name = "pkeyD1";
            pkeyD1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD1.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD1.Size = new System.Drawing.Size(12, 42);
            pkeyD1.TabIndex = 1;
            pkeyD1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp1
            // 
            pkeyDSharp1.BackColor = System.Drawing.Color.Black;
            pkeyDSharp1.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp1.Location = new System.Drawing.Point(23, 2);
            pkeyDSharp1.Name = "pkeyDSharp1";
            pkeyDSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp1.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp1.TabIndex = 4;
            pkeyDSharp1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE1
            // 
            pkeyE1.KeyOffColor = System.Drawing.Color.White;
            pkeyE1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE1.Location = new System.Drawing.Point(26, 2);
            pkeyE1.Name = "pkeyE1";
            pkeyE1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE1.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE1.Size = new System.Drawing.Size(12, 42);
            pkeyE1.TabIndex = 2;
            pkeyE1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF1
            // 
            pkeyF1.KeyOffColor = System.Drawing.Color.White;
            pkeyF1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF1.Location = new System.Drawing.Point(37, 2);
            pkeyF1.Name = "pkeyF1";
            pkeyF1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF1.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF1.Size = new System.Drawing.Size(12, 42);
            pkeyF1.TabIndex = 5;
            pkeyF1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp1
            // 
            pkeyFSharp1.BackColor = System.Drawing.Color.Black;
            pkeyFSharp1.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp1.Location = new System.Drawing.Point(45, 2);
            pkeyFSharp1.Name = "pkeyFSharp1";
            pkeyFSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp1.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp1.TabIndex = 7;
            pkeyFSharp1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG1
            // 
            pkeyG1.KeyOffColor = System.Drawing.Color.White;
            pkeyG1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG1.Location = new System.Drawing.Point(48, 2);
            pkeyG1.Name = "pkeyG1";
            pkeyG1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG1.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG1.Size = new System.Drawing.Size(12, 42);
            pkeyG1.TabIndex = 6;
            pkeyG1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp1
            // 
            pkeyGSharp1.BackColor = System.Drawing.Color.Black;
            pkeyGSharp1.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp1.Location = new System.Drawing.Point(56, 2);
            pkeyGSharp1.Name = "pkeyGSharp1";
            pkeyGSharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp1.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp1.TabIndex = 8;
            pkeyGSharp1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA1
            // 
            pkeyA1.KeyOffColor = System.Drawing.Color.White;
            pkeyA1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA1.Location = new System.Drawing.Point(59, 2);
            pkeyA1.Name = "pkeyA1";
            pkeyA1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA1.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA1.Size = new System.Drawing.Size(12, 42);
            pkeyA1.TabIndex = 9;
            pkeyA1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp1
            // 
            pkeyASharp1.BackColor = System.Drawing.Color.Black;
            pkeyASharp1.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp1.Location = new System.Drawing.Point(67, 2);
            pkeyASharp1.Name = "pkeyASharp1";
            pkeyASharp1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp1.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp1.Size = new System.Drawing.Size(8, 29);
            pkeyASharp1.TabIndex = 10;
            pkeyASharp1.Text = "pianoKey13";
            pkeyASharp1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB1
            // 
            pkeyB1.KeyOffColor = System.Drawing.Color.White;
            pkeyB1.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB1.Location = new System.Drawing.Point(70, 2);
            pkeyB1.Name = "pkeyB1";
            pkeyB1.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB1.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB1.Size = new System.Drawing.Size(12, 42);
            pkeyB1.TabIndex = 11;
            pkeyB1.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC2
            // 
            pkeyC2.KeyOffColor = System.Drawing.Color.White;
            pkeyC2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC2.Location = new System.Drawing.Point(81, 2);
            pkeyC2.Name = "pkeyC2";
            pkeyC2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC2.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC2.Size = new System.Drawing.Size(12, 42);
            pkeyC2.TabIndex = 12;
            pkeyC2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp2
            // 
            pkeyCSharp2.BackColor = System.Drawing.Color.Black;
            pkeyCSharp2.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp2.Location = new System.Drawing.Point(89, 2);
            pkeyCSharp2.Name = "pkeyCSharp2";
            pkeyCSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp2.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp2.TabIndex = 15;
            pkeyCSharp2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD2
            // 
            pkeyD2.KeyOffColor = System.Drawing.Color.White;
            pkeyD2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD2.Location = new System.Drawing.Point(92, 2);
            pkeyD2.Name = "pkeyD2";
            pkeyD2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD2.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD2.Size = new System.Drawing.Size(12, 42);
            pkeyD2.TabIndex = 13;
            pkeyD2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp2
            // 
            pkeyDSharp2.BackColor = System.Drawing.Color.Black;
            pkeyDSharp2.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp2.Location = new System.Drawing.Point(100, 2);
            pkeyDSharp2.Name = "pkeyDSharp2";
            pkeyDSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp2.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp2.TabIndex = 16;
            pkeyDSharp2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE2
            // 
            pkeyE2.KeyOffColor = System.Drawing.Color.White;
            pkeyE2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE2.Location = new System.Drawing.Point(103, 2);
            pkeyE2.Name = "pkeyE2";
            pkeyE2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE2.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE2.Size = new System.Drawing.Size(12, 42);
            pkeyE2.TabIndex = 14;
            pkeyE2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF2
            // 
            pkeyF2.KeyOffColor = System.Drawing.Color.White;
            pkeyF2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF2.Location = new System.Drawing.Point(114, 2);
            pkeyF2.Name = "pkeyF2";
            pkeyF2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF2.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF2.Size = new System.Drawing.Size(12, 42);
            pkeyF2.TabIndex = 17;
            pkeyF2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp2
            // 
            pkeyFSharp2.BackColor = System.Drawing.Color.Black;
            pkeyFSharp2.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp2.Location = new System.Drawing.Point(122, 2);
            pkeyFSharp2.Name = "pkeyFSharp2";
            pkeyFSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp2.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp2.TabIndex = 19;
            pkeyFSharp2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG2
            // 
            pkeyG2.KeyOffColor = System.Drawing.Color.White;
            pkeyG2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG2.Location = new System.Drawing.Point(125, 2);
            pkeyG2.Name = "pkeyG2";
            pkeyG2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG2.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG2.Size = new System.Drawing.Size(12, 42);
            pkeyG2.TabIndex = 18;
            pkeyG2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp2
            // 
            pkeyGSharp2.BackColor = System.Drawing.Color.Black;
            pkeyGSharp2.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp2.Location = new System.Drawing.Point(133, 2);
            pkeyGSharp2.Name = "pkeyGSharp2";
            pkeyGSharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp2.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp2.TabIndex = 20;
            pkeyGSharp2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA2
            // 
            pkeyA2.KeyOffColor = System.Drawing.Color.White;
            pkeyA2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA2.Location = new System.Drawing.Point(136, 2);
            pkeyA2.Name = "pkeyA2";
            pkeyA2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA2.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA2.Size = new System.Drawing.Size(12, 42);
            pkeyA2.TabIndex = 21;
            pkeyA2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp2
            // 
            pkeyASharp2.BackColor = System.Drawing.Color.Black;
            pkeyASharp2.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp2.Location = new System.Drawing.Point(144, 2);
            pkeyASharp2.Name = "pkeyASharp2";
            pkeyASharp2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp2.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp2.Size = new System.Drawing.Size(8, 29);
            pkeyASharp2.TabIndex = 22;
            pkeyASharp2.Text = "pianoKey13";
            pkeyASharp2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB2
            // 
            pkeyB2.KeyOffColor = System.Drawing.Color.White;
            pkeyB2.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB2.Location = new System.Drawing.Point(147, 2);
            pkeyB2.Name = "pkeyB2";
            pkeyB2.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB2.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB2.Size = new System.Drawing.Size(12, 42);
            pkeyB2.TabIndex = 23;
            pkeyB2.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC3
            // 
            pkeyC3.KeyOffColor = System.Drawing.Color.White;
            pkeyC3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC3.Location = new System.Drawing.Point(158, 2);
            pkeyC3.Name = "pkeyC3";
            pkeyC3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC3.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC3.Size = new System.Drawing.Size(12, 42);
            pkeyC3.TabIndex = 24;
            pkeyC3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp3
            // 
            pkeyCSharp3.BackColor = System.Drawing.Color.Black;
            pkeyCSharp3.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp3.Location = new System.Drawing.Point(166, 2);
            pkeyCSharp3.Name = "pkeyCSharp3";
            pkeyCSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp3.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp3.TabIndex = 27;
            pkeyCSharp3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD3
            // 
            pkeyD3.KeyOffColor = System.Drawing.Color.White;
            pkeyD3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD3.Location = new System.Drawing.Point(169, 2);
            pkeyD3.Name = "pkeyD3";
            pkeyD3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD3.Size = new System.Drawing.Size(12, 42);
            pkeyD3.TabIndex = 25;
            pkeyD3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp3
            // 
            pkeyDSharp3.BackColor = System.Drawing.Color.Black;
            pkeyDSharp3.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp3.Location = new System.Drawing.Point(177, 2);
            pkeyDSharp3.Name = "pkeyDSharp3";
            pkeyDSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp3.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp3.TabIndex = 28;
            pkeyDSharp3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE3
            // 
            pkeyE3.KeyOffColor = System.Drawing.Color.White;
            pkeyE3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE3.Location = new System.Drawing.Point(180, 2);
            pkeyE3.Name = "pkeyE3";
            pkeyE3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE3.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE3.Size = new System.Drawing.Size(12, 42);
            pkeyE3.TabIndex = 26;
            pkeyE3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF3
            // 
            pkeyF3.KeyOffColor = System.Drawing.Color.White;
            pkeyF3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF3.Location = new System.Drawing.Point(191, 2);
            pkeyF3.Name = "pkeyF3";
            pkeyF3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF3.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF3.Size = new System.Drawing.Size(12, 42);
            pkeyF3.TabIndex = 29;
            pkeyF3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp3
            // 
            pkeyFSharp3.BackColor = System.Drawing.Color.Black;
            pkeyFSharp3.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp3.Location = new System.Drawing.Point(199, 2);
            pkeyFSharp3.Name = "pkeyFSharp3";
            pkeyFSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp3.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp3.TabIndex = 31;
            pkeyFSharp3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG3
            // 
            pkeyG3.KeyOffColor = System.Drawing.Color.White;
            pkeyG3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG3.Location = new System.Drawing.Point(202, 2);
            pkeyG3.Name = "pkeyG3";
            pkeyG3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG3.Size = new System.Drawing.Size(12, 42);
            pkeyG3.TabIndex = 30;
            pkeyG3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp3
            // 
            pkeyGSharp3.BackColor = System.Drawing.Color.Black;
            pkeyGSharp3.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp3.Location = new System.Drawing.Point(210, 2);
            pkeyGSharp3.Name = "pkeyGSharp3";
            pkeyGSharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp3.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp3.TabIndex = 32;
            pkeyGSharp3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA3
            // 
            pkeyA3.KeyOffColor = System.Drawing.Color.White;
            pkeyA3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA3.Location = new System.Drawing.Point(213, 2);
            pkeyA3.Name = "pkeyA3";
            pkeyA3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA3.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA3.Size = new System.Drawing.Size(12, 42);
            pkeyA3.TabIndex = 33;
            pkeyA3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp3
            // 
            pkeyASharp3.BackColor = System.Drawing.Color.Black;
            pkeyASharp3.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp3.Location = new System.Drawing.Point(221, 2);
            pkeyASharp3.Name = "pkeyASharp3";
            pkeyASharp3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp3.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp3.Size = new System.Drawing.Size(8, 29);
            pkeyASharp3.TabIndex = 34;
            pkeyASharp3.Text = "pianoKey13";
            pkeyASharp3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB3
            // 
            pkeyB3.KeyOffColor = System.Drawing.Color.White;
            pkeyB3.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB3.Location = new System.Drawing.Point(224, 2);
            pkeyB3.Name = "pkeyB3";
            pkeyB3.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB3.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB3.Size = new System.Drawing.Size(12, 42);
            pkeyB3.TabIndex = 35;
            pkeyB3.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC4
            // 
            pkeyC4.KeyOffColor = System.Drawing.Color.White;
            pkeyC4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC4.Location = new System.Drawing.Point(235, 2);
            pkeyC4.Name = "pkeyC4";
            pkeyC4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC4.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC4.Size = new System.Drawing.Size(12, 42);
            pkeyC4.TabIndex = 36;
            pkeyC4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp4
            // 
            pkeyCSharp4.BackColor = System.Drawing.Color.Black;
            pkeyCSharp4.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp4.Location = new System.Drawing.Point(243, 2);
            pkeyCSharp4.Name = "pkeyCSharp4";
            pkeyCSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp4.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp4.TabIndex = 39;
            pkeyCSharp4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD4
            // 
            pkeyD4.KeyOffColor = System.Drawing.Color.White;
            pkeyD4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD4.Location = new System.Drawing.Point(246, 2);
            pkeyD4.Name = "pkeyD4";
            pkeyD4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD4.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD4.Size = new System.Drawing.Size(12, 42);
            pkeyD4.TabIndex = 37;
            pkeyD4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp4
            // 
            pkeyDSharp4.BackColor = System.Drawing.Color.Black;
            pkeyDSharp4.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp4.Location = new System.Drawing.Point(254, 2);
            pkeyDSharp4.Name = "pkeyDSharp4";
            pkeyDSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp4.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp4.TabIndex = 40;
            pkeyDSharp4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE4
            // 
            pkeyE4.KeyOffColor = System.Drawing.Color.White;
            pkeyE4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE4.Location = new System.Drawing.Point(257, 2);
            pkeyE4.Name = "pkeyE4";
            pkeyE4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE4.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE4.Size = new System.Drawing.Size(12, 42);
            pkeyE4.TabIndex = 38;
            pkeyE4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF4
            // 
            pkeyF4.KeyOffColor = System.Drawing.Color.White;
            pkeyF4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF4.Location = new System.Drawing.Point(268, 2);
            pkeyF4.Name = "pkeyF4";
            pkeyF4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF4.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF4.Size = new System.Drawing.Size(12, 42);
            pkeyF4.TabIndex = 41;
            pkeyF4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp4
            // 
            pkeyFSharp4.BackColor = System.Drawing.Color.Black;
            pkeyFSharp4.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp4.Location = new System.Drawing.Point(276, 2);
            pkeyFSharp4.Name = "pkeyFSharp4";
            pkeyFSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp4.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp4.TabIndex = 43;
            pkeyFSharp4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG4
            // 
            pkeyG4.KeyOffColor = System.Drawing.Color.White;
            pkeyG4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG4.Location = new System.Drawing.Point(279, 2);
            pkeyG4.Name = "pkeyG4";
            pkeyG4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG4.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG4.Size = new System.Drawing.Size(12, 42);
            pkeyG4.TabIndex = 42;
            pkeyG4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp4
            // 
            pkeyGSharp4.BackColor = System.Drawing.Color.Black;
            pkeyGSharp4.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp4.Location = new System.Drawing.Point(287, 2);
            pkeyGSharp4.Name = "pkeyGSharp4";
            pkeyGSharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp4.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp4.TabIndex = 44;
            pkeyGSharp4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA4
            // 
            pkeyA4.KeyOffColor = System.Drawing.Color.White;
            pkeyA4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA4.Location = new System.Drawing.Point(290, 2);
            pkeyA4.Name = "pkeyA4";
            pkeyA4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA4.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA4.Size = new System.Drawing.Size(12, 42);
            pkeyA4.TabIndex = 45;
            pkeyA4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp4
            // 
            pkeyASharp4.BackColor = System.Drawing.Color.Black;
            pkeyASharp4.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp4.Location = new System.Drawing.Point(298, 2);
            pkeyASharp4.Name = "pkeyASharp4";
            pkeyASharp4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp4.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp4.Size = new System.Drawing.Size(8, 29);
            pkeyASharp4.TabIndex = 46;
            pkeyASharp4.Text = "pianoKey13";
            pkeyASharp4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB4
            // 
            pkeyB4.KeyOffColor = System.Drawing.Color.White;
            pkeyB4.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB4.Location = new System.Drawing.Point(301, 2);
            pkeyB4.Name = "pkeyB4";
            pkeyB4.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB4.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB4.Size = new System.Drawing.Size(12, 42);
            pkeyB4.TabIndex = 47;
            pkeyB4.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC5
            // 
            pkeyC5.KeyOffColor = System.Drawing.Color.White;
            pkeyC5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC5.Location = new System.Drawing.Point(312, 2);
            pkeyC5.Name = "pkeyC5";
            pkeyC5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC5.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyC5.Size = new System.Drawing.Size(12, 42);
            pkeyC5.TabIndex = 48;
            pkeyC5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyCSharp5
            // 
            pkeyCSharp5.BackColor = System.Drawing.Color.Black;
            pkeyCSharp5.KeyOffColor = System.Drawing.Color.Black;
            pkeyCSharp5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyCSharp5.Location = new System.Drawing.Point(320, 2);
            pkeyCSharp5.Name = "pkeyCSharp5";
            pkeyCSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyCSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyCSharp5.Size = new System.Drawing.Size(8, 28);
            pkeyCSharp5.TabIndex = 51;
            pkeyCSharp5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyD5
            // 
            pkeyD5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            pkeyD5.KeyOffColor = System.Drawing.Color.White;
            pkeyD5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyD5.Location = new System.Drawing.Point(323, 2);
            pkeyD5.Name = "pkeyD5";
            pkeyD5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyD5.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyD5.Size = new System.Drawing.Size(12, 42);
            pkeyD5.TabIndex = 49;
            pkeyD5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyDSharp5
            // 
            pkeyDSharp5.BackColor = System.Drawing.Color.Black;
            pkeyDSharp5.KeyOffColor = System.Drawing.Color.Black;
            pkeyDSharp5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyDSharp5.Location = new System.Drawing.Point(331, 2);
            pkeyDSharp5.Name = "pkeyDSharp5";
            pkeyDSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyDSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyDSharp5.Size = new System.Drawing.Size(8, 29);
            pkeyDSharp5.TabIndex = 52;
            pkeyDSharp5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyE5
            // 
            pkeyE5.KeyOffColor = System.Drawing.Color.White;
            pkeyE5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyE5.Location = new System.Drawing.Point(334, 2);
            pkeyE5.Name = "pkeyE5";
            pkeyE5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyE5.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyE5.Size = new System.Drawing.Size(12, 42);
            pkeyE5.TabIndex = 50;
            pkeyE5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyF5
            // 
            pkeyF5.KeyOffColor = System.Drawing.Color.White;
            pkeyF5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyF5.Location = new System.Drawing.Point(345, 2);
            pkeyF5.Name = "pkeyF5";
            pkeyF5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyF5.Shape = Multimedia.UI.PianoKeyShape.LShape;
            pkeyF5.Size = new System.Drawing.Size(12, 42);
            pkeyF5.TabIndex = 53;
            pkeyF5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyFSharp5
            // 
            pkeyFSharp5.BackColor = System.Drawing.Color.Black;
            pkeyFSharp5.KeyOffColor = System.Drawing.Color.Black;
            pkeyFSharp5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyFSharp5.Location = new System.Drawing.Point(353, 2);
            pkeyFSharp5.Name = "pkeyFSharp5";
            pkeyFSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyFSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyFSharp5.Size = new System.Drawing.Size(8, 28);
            pkeyFSharp5.TabIndex = 55;
            pkeyFSharp5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyG5
            // 
            pkeyG5.KeyOffColor = System.Drawing.Color.White;
            pkeyG5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyG5.Location = new System.Drawing.Point(356, 2);
            pkeyG5.Name = "pkeyG5";
            pkeyG5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyG5.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyG5.Size = new System.Drawing.Size(12, 42);
            pkeyG5.TabIndex = 54;
            pkeyG5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyGSharp5
            // 
            pkeyGSharp5.BackColor = System.Drawing.Color.Black;
            pkeyGSharp5.KeyOffColor = System.Drawing.Color.Black;
            pkeyGSharp5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyGSharp5.Location = new System.Drawing.Point(364, 2);
            pkeyGSharp5.Name = "pkeyGSharp5";
            pkeyGSharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyGSharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyGSharp5.Size = new System.Drawing.Size(8, 29);
            pkeyGSharp5.TabIndex = 56;
            pkeyGSharp5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyA5
            // 
            pkeyA5.KeyOffColor = System.Drawing.Color.White;
            pkeyA5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyA5.Location = new System.Drawing.Point(367, 2);
            pkeyA5.Name = "pkeyA5";
            pkeyA5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyA5.Shape = Multimedia.UI.PianoKeyShape.TShape;
            pkeyA5.Size = new System.Drawing.Size(12, 42);
            pkeyA5.TabIndex = 57;
            pkeyA5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyASharp5
            // 
            pkeyASharp5.BackColor = System.Drawing.Color.Black;
            pkeyASharp5.KeyOffColor = System.Drawing.Color.Black;
            pkeyASharp5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyASharp5.Location = new System.Drawing.Point(375, 2);
            pkeyASharp5.Name = "pkeyASharp5";
            pkeyASharp5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyASharp5.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyASharp5.Size = new System.Drawing.Size(8, 29);
            pkeyASharp5.TabIndex = 58;
            pkeyASharp5.Text = "pianoKey13";
            pkeyASharp5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyB5
            // 
            pkeyB5.KeyOffColor = System.Drawing.Color.White;
            pkeyB5.KeyOnColor = System.Drawing.Color.Blue;
            pkeyB5.Location = new System.Drawing.Point(378, 2);
            pkeyB5.Name = "pkeyB5";
            pkeyB5.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyB5.Shape = Multimedia.UI.PianoKeyShape.LShapeBackwards;
            pkeyB5.Size = new System.Drawing.Size(12, 42);
            pkeyB5.TabIndex = 59;
            pkeyB5.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // pkeyC8
            // 
            pkeyC8.KeyOffColor = System.Drawing.Color.White;
            pkeyC8.KeyOnColor = System.Drawing.Color.Blue;
            pkeyC8.Location = new System.Drawing.Point(543, 2);
            pkeyC8.Name = "pkeyC8";
            pkeyC8.Orientation = Multimedia.UI.PianoKeyOrientation.Vertical;
            pkeyC8.Shape = Multimedia.UI.PianoKeyShape.RectShape;
            pkeyC8.Size = new System.Drawing.Size(12, 42);
            pkeyC8.TabIndex = 60;
            pkeyC8.StateChanged += new System.EventHandler(this.PianoChanged);
            // 
            // bankEditorWars
            // 
            bankEditorWars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            bankEditorWars.BackColor = System.Drawing.SystemColors.ControlLightLight;
            bankEditorWars.Controls.Add(this.tableLayoutPanel16);
            bankEditorWars.Controls.Add(this.label31);
            bankEditorWars.Controls.Add(this.tableLayoutPanel17);
            bankEditorWars.Controls.Add(this.label33);
            bankEditorWars.Controls.Add(this.tableLayoutPanel18);
            bankEditorWars.Controls.Add(this.label34);
            bankEditorWars.Controls.Add(this.tableLayoutPanel19);
            bankEditorWars.Controls.Add(this.label35);
            bankEditorWars.Location = new System.Drawing.Point(315, 13);
            bankEditorWars.Name = "bankEditorWars";
            bankEditorWars.Size = new System.Drawing.Size(325, 253);
            bankEditorWars.TabIndex = 13;
            bankEditorWars.Visible = false;
            // 
            // tableLayoutPanel16
            // 
            tableLayoutPanel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel16.ColumnCount = 2;
            tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel16.Controls.Add(this.war3ComboBox, 0, 0);
            tableLayoutPanel16.Controls.Add(this.war3Box, 1, 0);
            tableLayoutPanel16.Location = new System.Drawing.Point(14, 193);
            tableLayoutPanel16.Name = "tableLayoutPanel16";
            tableLayoutPanel16.RowCount = 1;
            tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel16.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel16.TabIndex = 13;
            // 
            // war3ComboBox
            // 
            war3ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            war3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            war3ComboBox.FormattingEnabled = true;
            war3ComboBox.Location = new System.Drawing.Point(3, 3);
            war3ComboBox.Name = "war3ComboBox";
            war3ComboBox.Size = new System.Drawing.Size(247, 21);
            war3ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.war3ComboBox, "Wave archive to be used for the bank.");
            // 
            // war3Box
            // 
            war3Box.Dock = System.Windows.Forms.DockStyle.Fill;
            war3Box.Location = new System.Drawing.Point(256, 3);
            war3Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            war3Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            war3Box.Name = "war3Box";
            war3Box.Size = new System.Drawing.Size(39, 20);
            war3Box.TabIndex = 7;
            toolTip.SetToolTip(this.war3Box, "Id of the wave archive to use for this bank.");
            // 
            // label31
            // 
            label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label31.Location = new System.Drawing.Point(11, 171);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(301, 22);
            label31.TabIndex = 12;
            label31.Text = "Wave Archive 3:";
            label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel17
            // 
            tableLayoutPanel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel17.ColumnCount = 2;
            tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel17.Controls.Add(this.war2ComboBox, 0, 0);
            tableLayoutPanel17.Controls.Add(this.war2Box, 1, 0);
            tableLayoutPanel17.Location = new System.Drawing.Point(14, 137);
            tableLayoutPanel17.Name = "tableLayoutPanel17";
            tableLayoutPanel17.RowCount = 1;
            tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel17.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel17.TabIndex = 11;
            // 
            // war2ComboBox
            // 
            war2ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            war2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            war2ComboBox.FormattingEnabled = true;
            war2ComboBox.Location = new System.Drawing.Point(3, 3);
            war2ComboBox.Name = "war2ComboBox";
            war2ComboBox.Size = new System.Drawing.Size(247, 21);
            war2ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.war2ComboBox, "Wave archive to be used for the bank.");
            // 
            // war2Box
            // 
            war2Box.Dock = System.Windows.Forms.DockStyle.Fill;
            war2Box.Location = new System.Drawing.Point(256, 3);
            war2Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            war2Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            war2Box.Name = "war2Box";
            war2Box.Size = new System.Drawing.Size(39, 20);
            war2Box.TabIndex = 7;
            toolTip.SetToolTip(this.war2Box, "Id of the wave archive to use for this bank.");
            // 
            // label33
            // 
            label33.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label33.Location = new System.Drawing.Point(11, 115);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(301, 22);
            label33.TabIndex = 10;
            label33.Text = "Wave Archive 2:";
            label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel18
            // 
            tableLayoutPanel18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel18.ColumnCount = 2;
            tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel18.Controls.Add(this.war1ComboBox, 0, 0);
            tableLayoutPanel18.Controls.Add(this.war1Box, 1, 0);
            tableLayoutPanel18.Location = new System.Drawing.Point(14, 81);
            tableLayoutPanel18.Name = "tableLayoutPanel18";
            tableLayoutPanel18.RowCount = 1;
            tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel18.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel18.TabIndex = 9;
            // 
            // war1ComboBox
            // 
            war1ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            war1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            war1ComboBox.FormattingEnabled = true;
            war1ComboBox.Location = new System.Drawing.Point(3, 3);
            war1ComboBox.Name = "war1ComboBox";
            war1ComboBox.Size = new System.Drawing.Size(247, 21);
            war1ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.war1ComboBox, "Wave archive to be used for the bank.");
            // 
            // war1Box
            // 
            war1Box.Dock = System.Windows.Forms.DockStyle.Fill;
            war1Box.Location = new System.Drawing.Point(256, 3);
            war1Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            war1Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            war1Box.Name = "war1Box";
            war1Box.Size = new System.Drawing.Size(39, 20);
            war1Box.TabIndex = 7;
            toolTip.SetToolTip(this.war1Box, "Id of the wave archive to use for this bank.");
            // 
            // label34
            // 
            label34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label34.Location = new System.Drawing.Point(11, 59);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(301, 22);
            label34.TabIndex = 8;
            label34.Text = "Wave Archive 1:";
            label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel19
            // 
            tableLayoutPanel19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel19.ColumnCount = 2;
            tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel19.Controls.Add(this.war0ComboBox, 0, 0);
            tableLayoutPanel19.Controls.Add(this.war0Box, 1, 0);
            tableLayoutPanel19.Location = new System.Drawing.Point(14, 25);
            tableLayoutPanel19.Name = "tableLayoutPanel19";
            tableLayoutPanel19.RowCount = 1;
            tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel19.Size = new System.Drawing.Size(298, 31);
            tableLayoutPanel19.TabIndex = 7;
            // 
            // war0ComboBox
            // 
            war0ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            war0ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            war0ComboBox.FormattingEnabled = true;
            war0ComboBox.Location = new System.Drawing.Point(3, 3);
            war0ComboBox.Name = "war0ComboBox";
            war0ComboBox.Size = new System.Drawing.Size(247, 21);
            war0ComboBox.TabIndex = 6;
            toolTip.SetToolTip(this.war0ComboBox, "Wave archive to be used for the bank.");
            // 
            // war0Box
            // 
            war0Box.Dock = System.Windows.Forms.DockStyle.Fill;
            war0Box.Location = new System.Drawing.Point(256, 3);
            war0Box.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            war0Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            war0Box.Name = "war0Box";
            war0Box.Size = new System.Drawing.Size(39, 20);
            war0Box.TabIndex = 7;
            toolTip.SetToolTip(this.war0Box, "Id of the wave archive to use for this bank.");
            // 
            // label35
            // 
            label35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label35.Location = new System.Drawing.Point(11, 3);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(301, 22);
            label35.TabIndex = 2;
            label35.Text = "Wave Archive 0:";
            label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tree
            // 
            tree.Dock = System.Windows.Forms.DockStyle.Fill;
            tree.ImageIndex = 0;
            tree.ImageList = this.treeIcons;
            tree.Indent = 12;
            tree.Location = new System.Drawing.Point(0, 0);
            tree.Name = "tree";
            treeNode1.ImageIndex = 10;
            treeNode1.Name = "fileInfo";
            treeNode1.SelectedImageIndex = 10;
            treeNode1.Text = "File Information";
            tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            tree.SelectedImageIndex = 0;
            tree.ShowLines = false;
            tree.Size = new System.Drawing.Size(651, 538);
            tree.TabIndex = 0;
            tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseDoubleClick);
            tree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tree_NodeKey);
            // 
            // treeIcons
            // 
            treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
            treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            treeIcons.Images.SetKeyName(0, "blank.png");
            treeIcons.Images.SetKeyName(1, "version.png");
            treeIcons.Images.SetKeyName(2, "sseq.png");
            treeIcons.Images.SetKeyName(3, "seqArc.png");
            treeIcons.Images.SetKeyName(4, "bank.png");
            treeIcons.Images.SetKeyName(5, "waveArchive.png");
            treeIcons.Images.SetKeyName(6, "player.png");
            treeIcons.Images.SetKeyName(7, "group.png");
            treeIcons.Images.SetKeyName(8, "streamPlayer.png");
            treeIcons.Images.SetKeyName(9, "strm.png");
            treeIcons.Images.SetKeyName(10, "record.png");
            treeIcons.Images.SetKeyName(11, "recordArc.png");
            treeIcons.Images.SetKeyName(12, "lookup.png");
            treeIcons.Images.SetKeyName(13, "recordRegion.png");
            treeIcons.Images.SetKeyName(14, "wave.png");
            treeIcons.Images.SetKeyName(15, "ranged.png");
            treeIcons.Images.SetKeyName(16, "regional.png");
            treeIcons.Images.SetKeyName(17, "psg.png");
            treeIcons.Images.SetKeyName(18, "whiteNoise.png");
            // 
            // sequenceEditorPanel
            // 
            sequenceEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            sequenceEditorPanel.Location = new System.Drawing.Point(0, 0);
            sequenceEditorPanel.Name = "sequenceEditorPanel";
            sequenceEditorPanel.Size = new System.Drawing.Size(651, 538);
            sequenceEditorPanel.TabIndex = 3;
            sequenceEditorPanel.Visible = false;
            // 
            // openFileDialog
            // 
            openFileDialog.RestoreDirectory = true;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            status,
            currentNote});
            statusStrip.Location = new System.Drawing.Point(0, 564);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(984, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            status.Name = "status";
            status.Size = new System.Drawing.Size(125, 17);
            status.Text = "No Valid Info Selected!";
            // 
            // currentNote
            // 
            currentNote.Name = "currentNote";
            currentNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            currentNote.Size = new System.Drawing.Size(0, 17);
            // 
            // rootMenu
            // 
            rootMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            addToolStripMenuItem,
            expandToolStripMenuItem,
            collapseToolStripMenuItem});
            rootMenu.Name = "rootMenu";
            rootMenu.Size = new System.Drawing.Size(120, 70);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.New;
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // expandToolStripMenuItem
            // 
            expandToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Save;
            expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            expandToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            expandToolStripMenuItem.Text = "Expand";
            expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // collapseToolStripMenuItem
            // 
            collapseToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Save_As;
            collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            collapseToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            collapseToolStripMenuItem.Text = "Collapse";
            collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // nodeMenu
            // 
            nodeMenu.ImeMode = System.Windows.Forms.ImeMode.Off;
            nodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            addAboveToolStripMenuItem1,
            addBelowToolStripMenuItem1,
            moveUpToolStripMenuItem1,
            moveDownToolStripMenuItem1,
            replaceFileToolStripMenuItem,
            exportToolStripMenuItem1,
            deleteToolStripMenuItem1});
            nodeMenu.Name = "contextMenuStrip1";
            nodeMenu.Size = new System.Drawing.Size(139, 158);
            // 
            // addAboveToolStripMenuItem1
            // 
            addAboveToolStripMenuItem1.Image = global::NitroStudio2.Properties.Resources.New;
            addAboveToolStripMenuItem1.Name = "addAboveToolStripMenuItem1";
            addAboveToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            addAboveToolStripMenuItem1.Text = "Add Above";
            addAboveToolStripMenuItem1.Click += new System.EventHandler(this.addAboveToolStripMenuItem1_Click);
            // 
            // addBelowToolStripMenuItem1
            // 
            addBelowToolStripMenuItem1.Image = global::NitroStudio2.Properties.Resources.Open;
            addBelowToolStripMenuItem1.Name = "addBelowToolStripMenuItem1";
            addBelowToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            addBelowToolStripMenuItem1.Text = "Add Below";
            addBelowToolStripMenuItem1.Click += new System.EventHandler(this.addBelowToolStripMenuItem1_Click);
            // 
            // moveUpToolStripMenuItem1
            // 
            moveUpToolStripMenuItem1.Image = global::NitroStudio2.Properties.Resources.Save;
            moveUpToolStripMenuItem1.Name = "moveUpToolStripMenuItem1";
            moveUpToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            moveUpToolStripMenuItem1.Text = "Move Up";
            moveUpToolStripMenuItem1.Click += new System.EventHandler(this.moveUpToolStripMenuItem1_Click);
            // 
            // moveDownToolStripMenuItem1
            // 
            moveDownToolStripMenuItem1.Image = global::NitroStudio2.Properties.Resources.Save_As;
            moveDownToolStripMenuItem1.Name = "moveDownToolStripMenuItem1";
            moveDownToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            moveDownToolStripMenuItem1.Text = "Move Down";
            moveDownToolStripMenuItem1.Click += new System.EventHandler(this.moveDownToolStripMenuItem1_Click);
            // 
            // replaceFileToolStripMenuItem
            // 
            replaceFileToolStripMenuItem.Image = global::NitroStudio2.Properties.Resources.Import;
            replaceFileToolStripMenuItem.Name = "replaceFileToolStripMenuItem";
            replaceFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            replaceFileToolStripMenuItem.Text = "Replace";
            replaceFileToolStripMenuItem.Click += new System.EventHandler(this.replaceFileToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem1
            // 
            exportToolStripMenuItem1.Image = global::NitroStudio2.Properties.Resources.Export;
            exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            exportToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            exportToolStripMenuItem1.Text = "Export";
            exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.Image = global::NitroStudio2.Properties.Resources.Close;
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            deleteToolStripMenuItem1.Text = "Delete";
            deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // sarEntryMenu
            // 
            sarEntryMenu.ImeMode = System.Windows.Forms.ImeMode.Off;
            sarEntryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            sarAddAbove,
            sarAddBelow,
            sarMoveUp,
            sarMoveDown,
            sarReplace,
            sarExport,
            sarRename,
            sarDelete});
            sarEntryMenu.Name = "contextMenuStrip1";
            sarEntryMenu.Size = new System.Drawing.Size(139, 180);
            // 
            // sarAddAbove
            // 
            sarAddAbove.Image = global::NitroStudio2.Properties.Resources.New;
            sarAddAbove.Name = "sarAddAbove";
            sarAddAbove.Size = new System.Drawing.Size(138, 22);
            sarAddAbove.Text = "Add Above";
            sarAddAbove.Click += new System.EventHandler(this.SarAddAbove_Click);
            // 
            // sarAddBelow
            // 
            sarAddBelow.Image = global::NitroStudio2.Properties.Resources.Open;
            sarAddBelow.Name = "sarAddBelow";
            sarAddBelow.Size = new System.Drawing.Size(138, 22);
            sarAddBelow.Text = "Add Below";
            sarAddBelow.Click += new System.EventHandler(this.SarAddBelow_Click);
            // 
            // sarMoveUp
            // 
            sarMoveUp.Image = global::NitroStudio2.Properties.Resources.Save;
            sarMoveUp.Name = "sarMoveUp";
            sarMoveUp.Size = new System.Drawing.Size(138, 22);
            sarMoveUp.Text = "Move Up";
            sarMoveUp.Click += new System.EventHandler(this.SarMoveUp_Click);
            // 
            // sarMoveDown
            // 
            sarMoveDown.Image = global::NitroStudio2.Properties.Resources.Save_As;
            sarMoveDown.Name = "sarMoveDown";
            sarMoveDown.Size = new System.Drawing.Size(138, 22);
            sarMoveDown.Text = "Move Down";
            sarMoveDown.Click += new System.EventHandler(this.SarMoveDown_Click);
            // 
            // sarReplace
            // 
            sarReplace.Image = global::NitroStudio2.Properties.Resources.Import;
            sarReplace.Name = "sarReplace";
            sarReplace.Size = new System.Drawing.Size(138, 22);
            sarReplace.Text = "Replace";
            sarReplace.Click += new System.EventHandler(this.SarReplace_Click);
            // 
            // sarExport
            // 
            sarExport.Image = global::NitroStudio2.Properties.Resources.Export;
            sarExport.Name = "sarExport";
            sarExport.Size = new System.Drawing.Size(138, 22);
            sarExport.Text = "Export";
            sarExport.Click += new System.EventHandler(this.SarExport_Click);
            // 
            // sarRename
            // 
            sarRename.Image = global::NitroStudio2.Properties.Resources.Rename;
            sarRename.Name = "sarRename";
            sarRename.Size = new System.Drawing.Size(138, 22);
            sarRename.Text = "Rename";
            sarRename.Click += new System.EventHandler(this.SarRename_Click);
            // 
            // sarDelete
            // 
            sarDelete.Image = global::NitroStudio2.Properties.Resources.Close;
            sarDelete.Name = "sarDelete";
            sarDelete.Size = new System.Drawing.Size(138, 22);
            sarDelete.Text = "Delete";
            sarDelete.Click += new System.EventHandler(this.SarDelete_Click);
            // 
            // EditorBase
            // 
            ClientSize = new System.Drawing.Size(984, 586);
            Controls.Add(this.splitContainer1);
            Controls.Add(this.menuStrip);
            Controls.Add(this.statusStrip);
            MainMenuStrip = this.menuStrip;
            Name = "EditorBase";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Close);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            seqBankPanel.ResumeLayout(false);
            tableLayoutPanel36.ResumeLayout(false);
            tableLayoutPanel20.ResumeLayout(false);
            tableLayoutPanel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track15Picture)).EndInit();
            tableLayoutPanel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track13Picture)).EndInit();
            tableLayoutPanel33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track11Picture)).EndInit();
            tableLayoutPanel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track9Picture)).EndInit();
            tableLayoutPanel31.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track7Picture)).EndInit();
            tableLayoutPanel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track5Picture)).EndInit();
            tableLayoutPanel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track3Picture)).EndInit();
            tableLayoutPanel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track14Picture)).EndInit();
            tableLayoutPanel27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track12Picture)).EndInit();
            tableLayoutPanel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track10Picture)).EndInit();
            tableLayoutPanel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track8Picture)).EndInit();
            tableLayoutPanel24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track6Picture)).EndInit();
            tableLayoutPanel23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track4Picture)).EndInit();
            tableLayoutPanel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track2Picture)).EndInit();
            tableLayoutPanel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track1Picture)).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track0Picture)).EndInit();
            tableLayoutPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seqEditorBankBox)).EndInit();
            bankEditorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bankRegions)).EndInit();
            tableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drumSetStartRangeBox)).EndInit();
            tableLayoutPanel14.ResumeLayout(false);
            seqArcSeqPanel.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seqArcSeqBox)).EndInit();
            seqArcPanel.ResumeLayout(false);
            seqPanel.ResumeLayout(false);
            tableLayoutPanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seqPlayerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seqPlayerPriorityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seqChannelPriorityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seqVolumeBox)).EndInit();
            tableLayoutPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seqBankBox)).EndInit();
            playerPanel.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerHeapSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerMaxSequencesBox)).EndInit();
            stmPanel.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stmPlayerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stmPriorityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stmVolumeBox)).EndInit();
            streamPlayerPanel.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stmPlayerLeftChannelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stmPlayerRightChannelBox)).EndInit();
            grpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpEntries)).EndInit();
            bankPanel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar3Box)).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar2Box)).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar1Box)).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnkWar0Box)).EndInit();
            warPanel.ResumeLayout(false);
            forceUniqueFilePanel.ResumeLayout(false);
            indexPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemIndexBox)).EndInit();
            settingsPanel.ResumeLayout(false);
            noInfoPanel.ResumeLayout(false);
            kermalisSoundPlayerPanel.ResumeLayout(false);
            kermalisSoundPlayerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kermalisPosition)).EndInit();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kermalisVolumeSlider)).EndInit();
            pnlPianoKeys.ResumeLayout(false);
            bankEditorWars.ResumeLayout(false);
            tableLayoutPanel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.war3Box)).EndInit();
            tableLayoutPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.war2Box)).EndInit();
            tableLayoutPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.war1Box)).EndInit();
            tableLayoutPanel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.war0Box)).EndInit();
            sequenceEditorPanel.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            rootMenu.ResumeLayout(false);
            nodeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            sarEntryMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }


        /// <summary>
        /// Get the path for opening a file.
        /// </summary>
        /// <param name="description">File description.</param>
        /// <param name="extension">File extension.</param>
        /// <returns>Path of the file to open.</returns>
        public string GetFileOpenerPath(string description, string extension) {

            //Set filer.
            openFileDialog.FileName = "";
            openFileDialog.Filter = description + "|" + "*.s" + extension.ToLower();
            openFileDialog.ShowDialog();

            //Return the file name.
            return openFileDialog.FileName;

        }

        /// <summary>
        /// Get the path for saving a file.
        /// </summary>
        /// <param name="description">File description.</param>
        /// <param name="extension">File extension.</param>
        /// <returns>Path of the file to save.</returns>
        public string GetFileSaverPath(string description, string extension) {

            //Set filer.
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = description + "|" + "*.s" + extension.ToLower();
            saveFileDialog.ShowDialog();            

            //Set write mode.
            if (saveFileDialog.FileName != "") {

                //Fix extension.
                if (Path.GetExtension(saveFileDialog.FileName) == "") {
                    saveFileDialog.FileName += ".s" + extension.ToLower();
                }

            }

            //Return the file name.
            return saveFileDialog.FileName;

        }

        /// <summary>
        /// On closing hook.
        /// </summary>
        private void form_Close(object sender, FormClosingEventArgs e) {
            OnClosing();
        }

        /// <summary>
        /// On closing.
        /// </summary>
        public virtual void OnClosing() {}

        public ContextMenuStrip CreateMenuStrip(ContextMenuStrip orig, int[] indices, EventHandler[] eventHandlers) {

            ContextMenuStrip c = new ContextMenuStrip();

            int num = 0;
            foreach (int ind in indices) {

                var i = orig.Items[ind];
                c.Items.Add(i.Text, i.Image, eventHandlers[num++]);

            }

            return c;

        }

        //Updating.
        #region Updating

        /// <summary>
        /// Do the info stuff on node selected.
        /// </summary>
        public virtual void DoInfoStuff() {

            //Fix selected node issue.
            if (tree.SelectedNode == null) {
                tree.SelectedNode = tree.Nodes[0];
            }

            //Not file open.
            if (!FileOpen) {

                //Show no info panel.
                noInfoPanel.BringToFront();
                noInfoPanel.Show();

                //Update status.
                status.Text = "No Valid Info Selected!";

            }

        }

        Stack<int> nodeIndices;
        List<string> expandedNodes;

        /// <summary>
        /// Begin the updating of nodes.
        /// </summary>
        public void BeginUpdateNodes() {

            //Begin update.
            tree.BeginUpdate();

            //Get list of expanded nodes.
            expandedNodes = collectExpandedNodes(tree.Nodes);

            //Safety.
            if (tree.SelectedNode == null) {
                tree.SelectedNode = tree.Nodes[0];
            }

            //Get the selected index.
            nodeIndices = new Stack<int>();
            nodeIndices.Push(tree.SelectedNode.Index);
            while (tree.SelectedNode.Parent != null) {
                tree.SelectedNode = tree.SelectedNode.Parent;
                nodeIndices.Push(tree.SelectedNode.Index);
            }

            //Clear each node.
            for (int i = 0; i < tree.Nodes.Count; i++) {
                tree.Nodes[i].Nodes.Clear();
            }

        }

        /// <summary>
        /// Update the nodes in the tree. THIS MUST CONTAIN THE BEGIN AND END UPDATE NODES!
        /// </summary>
        public abstract void UpdateNodes();

        /// <summary>
        /// Complete the updating of nodes.
        /// </summary>
        public void EndUpdateNodes() {

            //Restore the expanded nodes if they exist.
            if (expandedNodes.Count > 0) {
                TreeNode IamExpandedNode;
                for (int i = 0; i < expandedNodes.Count; i++) {
                    IamExpandedNode = FindNodeByName(tree.Nodes, expandedNodes[i]);
                    expandNodePath(IamExpandedNode);
                }

            }

            //Set the selected node.
            tree.SelectedNode = tree.Nodes[nodeIndices.Pop()];
            while (nodeIndices.Count > 0) {
                try {
                    tree.SelectedNode = tree.SelectedNode.Nodes[nodeIndices.Pop()];
                } catch {
                    nodeIndices.Clear();
                }
            }
            tree.SelectedNode.EnsureVisible();

            //End update.
            tree.EndUpdate();

        }

        #endregion

        //File menu.
        #region fileMenu

        //New.
        public virtual void newToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open and can save test.
            if (!FileTest(sender, e, true)) {
                return;
            }

            //Create instance of file.
            File = (IOFile)Activator.CreateInstance(FileType);

            //Reset values.
            FilePath = "";
            FileOpen = true;
            ExtFile = null;
            Text = EditorName + " - New " + ExtensionDescription + ".s" + Extension;

            //Update.
            UpdateNodes();
            DoInfoStuff();

        }

        //Open.
        public virtual void openToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open and save test.
            if (!FileTest(sender, e, true)) {
                return;
            }

            //Open the file.
            string path = GetFileOpenerPath(ExtensionDescription, Extension);

            //File is not null.
            if (path != "") {

                //Set value.
                File = (IOFile)Activator.CreateInstance(FileType);
                ExtFile = null;
                FilePath = path;
                Text = EditorName + " - " + Path.GetFileName(path);
                FileOpen = true;

                //Read data.
                File.Read(path);

                //Update.
                UpdateNodes();
                DoInfoStuff();

            }

        }

        //Save.
        public virtual void saveToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open test.
            if (!FileTest(sender, e, false, true)) {
                return;
            }

            //No where to save.
            if (ExtFile == null && FilePath == "") {

                //Save as.
                saveAsToolStripMenuItem_Click(sender, e);

                //Return.
                return;

            }

            //External file is not null.
            if (ExtFile != null) {

                //Set the file.
                ExtFile.Read(File.Write());

                //Update the main window.
                if (MainWindow != null) {
                    MainWindow.UpdateNodes();
                    MainWindow.DoInfoStuff();
                }
                if (OtherEditor != null) {
                    OtherEditor.UpdateNodes();
                    OtherEditor.DoInfoStuff();
                }

            }

            //External file is null.
            else {

                //Write the file.
                File.Write(FilePath);

            }

        }

        //Save as.
        public void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open test.
            if (!FileTest(sender, e, false, true)) {
                return;
            }

            //Get the save file name.
            string path = GetFileSaverPath(ExtensionDescription, Extension);

            //If the path is valid.
            if (path != "") {

                //Set values.
                FilePath = path;
                ExtFile = null;
                Text = EditorName + " - " + Path.GetFileName(path);

                //Save the file.
                saveToolStripMenuItem_Click(sender, e);

            }

        }

        //Close.
        public virtual void closeToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open and can save test.
            if (!FileTest(sender, e, true, true)) {
                return;
            }

            //Close the file.
            File = null;
            ExtFile = null;
            FilePath = "";
            FileOpen = false;
            Text = EditorName;

            //Update.
            UpdateNodes();
            DoInfoStuff();

        }

        //Quit.
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {

            //Quit if wanted.
            if (FileOpen) {
                SaveQuitDialog q = new SaveQuitDialog(this);
                q.ShowDialog();
            } else {
                Close();
            }

        }

        #endregion

        //Edit menu.
        #region editMenu

        //Blank the file.
        public virtual void blankFileToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open save test.
            if (!FileTest(sender, e, false, true)) {
                return;
            }

            //Create instance of file.
            File = (IOFile)Activator.CreateInstance(FileType);

            //Update.
            UpdateNodes();
            DoInfoStuff();

        }

        //Import data from another file.
        public virtual void importFileToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open test.
            if (!FileTest(sender, e, false, true)) {
                return;
            }

            //Open the file.
            string path = GetFileOpenerPath(ExtensionDescription, Extension);

            //File is not null.
            if (path != "") {

                //Set value.
                File = (IOFile)Activator.CreateInstance(FileType);

                //Read data.
                File.Read(path);

                //Update.
                UpdateNodes();
                DoInfoStuff();

            }

        }

        //Export data to somewhere.
        public virtual void exportFileToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open.
            if (!FileTest(sender, e, false, true)) {
                return;
            }

            //Get the save file name.
            string path = GetFileSaverPath(ExtensionDescription, Extension);

            //If the path is valid.
            if (path != "") {

                //Write the file.
                File.Write(path);

            }

        }

        //Set file data to null.
        private void nullifyFileToolStripMenuItem_Click(object sender, EventArgs e) {

            //File open test.
            if (!FileTest(sender, e, false, true)) {
                return;
            }

            //External file cannot be null.
            if (ExtFile == null) {

                //Call out the user.
                MessageBox.Show("You can't nullify data that is not in a parent file!", "Notice:");
                return;

            }

            //Nullify file.
            File = null;

            //Update.
            UpdateNodes();
            DoInfoStuff();

        }

        /// <summary>
        /// Returns true if the user wants to continue.
        /// </summary>
        public bool FileTest(object sender, EventArgs e, bool save, bool forceOpen = false) {

            //File is open.
            if (FileOpen) {

                //Ask user if they want to save.
                if (save) {

                    SaveCloseDialog c = new SaveCloseDialog();
                    switch (c.getValue()) {

                        //Save.
                        case 0:
                            saveToolStripMenuItem_Click(sender, e);
                            return true;

                        //No button.
                        case 1:
                            return true;

                        //Cancel.
                        default:
                            return false;

                    }

                }

                //Passed test.
                return true;

            } else {

                if (forceOpen) {
                    MessageBox.Show("There must be a file open to do this!", "Notice:");
                    return false;
                } else {
                    return true;
                }

            }

        }

        #endregion


        //Node shit.
        #region nodeShit

        //Expand node and parents.
        void expandNodePath(TreeNode node) {
            if (node == null)
                return;
            if (node.Level != 0) //check if it is not root
            {
                node.Expand();
                expandNodePath(node.Parent);
            } else {
                node.Expand(); // this is root 
            }



        }

        //Make right click actually select, and show infoViewer.
        void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                // Select the clicked node
                tree.SelectedNode = tree.GetNodeAt(e.X, e.Y);
            } else if (e.Button == MouseButtons.Left) {
                // Select the clicked node
                tree.SelectedNode = tree.GetNodeAt(e.X, e.Y);
            }

            DoInfoStuff();

        }

        void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {

            //Select.
            if (e.Button == MouseButtons.Right) {
                // Select the clicked node
                tree.SelectedNode = tree.GetNodeAt(e.X, e.Y);
            } else if (e.Button == MouseButtons.Left) {
                // Select the clicked node
                tree.SelectedNode = tree.GetNodeAt(e.X, e.Y);
            }

            //Do info stuff.
            DoInfoStuff();

            //Do double click action.
            NodeMouseDoubleClick();

        }

        public virtual void NodeMouseDoubleClick() {}

        void tree_NodeKey(object sender, KeyEventArgs e) {

            DoInfoStuff();

        }

        //Get expanded nodes.
        List<string> collectExpandedNodes(TreeNodeCollection Nodes) {
            List<string> _lst = new List<string>();
            foreach (TreeNode checknode in Nodes) {
                if (checknode.IsExpanded)
                    _lst.Add(checknode.Name);
                if (checknode.Nodes.Count > 0)
                    _lst.AddRange(collectExpandedNodes(checknode.Nodes));
            }
            return _lst;
        }


        /// <summary>
        /// Find nodes by name.
        /// </summary>
        /// <param name="NodesCollection"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        TreeNode FindNodeByName(TreeNodeCollection NodesCollection, string Name) {
            TreeNode returnNode = null; // Default value to return
            foreach (TreeNode checkNode in NodesCollection) {
                if (checkNode.Name == Name)  //checks if this node name is correct
                    returnNode = checkNode;
                else if (checkNode.Nodes.Count > 0) //node has child
                {
                    returnNode = FindNodeByName(checkNode.Nodes, Name);
                }

                if (returnNode != null) //check if founded do not continue and break
                {
                    return returnNode;
                }

            }
            //not found
            return returnNode;
        }

        #endregion


        //Sound player deluxe.
        #region soundPlayerDeluxe

        //Play.
        private void playSoundTrack_Click(object sender, EventArgs e) {
            Play();
        }

        //Pause.
        private void pauseSoundTrack_Click(object sender, EventArgs e) {
            Pause();
        }

        //Stop.
        private void stopSoundTrack_Click(object sender, EventArgs e) {
            Stop();
        }

        public virtual void Play() {}
        public virtual void Pause() {}
        public virtual void Stop() {}

        #endregion


        //Other buttons.
        #region otherButtons

        private void forceWaveVersionButton_Click(object sender, EventArgs e) {
            ForceWaveVersionButtonClick();
        }

        public virtual void ForceWaveVersionButtonClick() {}

        #endregion


        //Root menu.
        #region rootMenu

        private void addToolStripMenuItem_Click(object sender, EventArgs e) {
            RootAdd();
        }

        public void expandToolStripMenuItem_Click(object sender, EventArgs e) {
            tree.SelectedNode.Expand();
        }

        public void collapseToolStripMenuItem_Click(object sender, EventArgs e) {
            tree.SelectedNode.Collapse();
        }

        public virtual void RootAdd() {}

        #endregion


        //Node menu.
        #region nodeMenu

        public void addAboveToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeAddAbove();
        }

        public void addBelowToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeAddBelow();
        }

        public void moveUpToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeMoveUp();
        }

        public void moveDownToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeMoveDown();
        }

        public void blankToolStripMenuItem_Click(object sender, EventArgs e) {
            NodeBlank();
        }

        public void replaceFileToolStripMenuItem_Click(object sender, EventArgs e) {
            NodeReplace();
        }

        public void exportToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeExport();
        }

        public void nullifyToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeNullify();
        }

        public void deleteToolStripMenuItem1_Click(object sender, EventArgs e) {
            NodeDelete();
        }

        public virtual void NodeAddAbove() {}
        public virtual void NodeAddBelow() {}
        public virtual void NodeMoveUp() {}
        public virtual void NodeMoveDown() {}
        public virtual void NodeBlank() {}
        public virtual void NodeReplace() {}
        public virtual void NodeExport() {}
        public virtual void NodeNullify() {}
        public virtual void NodeDelete() {}

        /// <summary>
        /// Swap the a and b objects.
        /// </summary>
        /// <param name="objects">Objects list.</param>
        /// <param name="a">Object a to swap.</param>
        /// <param name="b">Object b to swap.</param>
        public bool Swap<T>(IList<T> objects, int a, int b) {

            //Make sure it is possible.
            if (a < 0 || a >= objects.Count || b < 0 || b >= objects.Count) {
                return false;
            }

            //Swap objects.
            T temp = objects[a];
            objects[a] = objects[b];
            objects[b] = temp;
            return true;

        }

        #endregion


        //War boxes.
        #region warBoxes

        private void vMajBoxWar_ValueChanged(object sender, EventArgs e) {
            BoxWarMajChanged();
        }

        private void vMinBoxWar_ValueChanged(object sender, EventArgs e) {
            BoxWarMinChanged();
        }

        private void vRevBoxWar_ValueChanged(object sender, EventArgs e) {
            BoxWarRevChanged();
        }

        private void vWavMajBox_ValueChanged(object sender, EventArgs e) {
            BoxWavMajChanged();
        }

        private void vWavMinBox_ValueChanged(object sender, EventArgs e) {
            BoxWavMinChanged();
        }

        private void vWavRevBox_ValueChanged(object sender, EventArgs e) {
            BoxWavRevChanged();
        }

        public virtual void BoxWarMajChanged() {}
        public virtual void BoxWarMinChanged() {}
        public virtual void BoxWarRevChanged() {}
        public virtual void BoxWavMajChanged() {}
        public virtual void BoxWavMinChanged() {}
        public virtual void BoxWavRevChanged() {}

        #endregion


        //War tools.
        #region warTools

        private void batchExtractWavesToolStripMenuItem_Click(object sender, EventArgs e) {
            WarExtractWave();
        }

        private void batchExtract3dsWavesToolStripMenuItem_Click(object sender, EventArgs e) {
            WarExtractWave3ds();
        }

        private void batchExtractWiiUWavesToolStripMenuItem_Click(object sender, EventArgs e) {
            WarExtractWaveWiiU();
        }

        private void batchExtractSwitchWavesToolStripMenuItem_Click(object sender, EventArgs e) {
            WarExtractWaveSwitch();
        }

        private void batchImportToolStripMenuItem_Click(object sender, EventArgs e) {
            WarBatchImport();
        }

        public virtual void WarExtractWave() {}
        public virtual void WarExtractWave3ds() {}
        public virtual void WarExtractWaveWiiU() {}
        public virtual void WarExtractWaveSwitch() {}
        public virtual void WarBatchImport() {}

        #endregion


        //Group versions.
        #region grpVersions

        private void grpSeqForceButton_Click(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupForceSequenceVersion();
            }
        }

        private void grpBnkForceButton_Click(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupForceBankVersion();
            }
        }

        private void grpWarForceButton_Click(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupForceWaveArchiveVersion();
            }
        }

        private void grpWsdForceButton_Click(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupForceWaveSoundDataVersion();
            }
        }

        private void grpStpForceButton_Click(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupForcePrefetchVersion();
            }
        }

        private void grpMajBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpMinBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpRevBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpSeqMajBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpSeqMinBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpSeqRevBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpBnkMajBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpBnkMinBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpBnkRevBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpWarMajBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpWarMinBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpWarRevBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpWsdMajBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpWsdMinBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpWsdRevBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpStpMajBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpStpMinBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        private void grpStpRevBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupVersionChanged();
            }
        }

        public virtual void GroupForceSequenceVersion() {}
        public virtual void GroupForceBankVersion() {}
        public virtual void GroupForceWaveArchiveVersion() {}
        public virtual void GroupForceWaveSoundDataVersion() {}
        public virtual void GroupForcePrefetchVersion() {}
        public virtual void GroupVersionChanged() {}

        #endregion


        //Group file data.
        #region grpFile

        private void grpFileIdComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupFileIdComboChanged();
            }
        }

        private void grpFileIdBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupFileIdNumBoxChanged();
            }
        }

        private void grpEmbedModeBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupFileIdEmbedModeChanged();
            }
        }

        public virtual void GroupFileIdComboChanged() {}
        public virtual void GroupFileIdNumBoxChanged() {}
        public virtual void GroupFileIdEmbedModeChanged() {}

        #endregion


        //Group dependency.
        #region grpDependency

        private void grpDepEntryTypeBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupDependencyTypeChanged();
            }
        }

        private void grpDepEntryNumComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupDependencyEntryComboChanged();
            }
        }

        private void grpDepEntryNumBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupDependencyEntryNumBoxChanged();
            }
        }

        private void grpDepLoadFlagsBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                GroupDependencyFlagsChanged();
            }
        }

        public virtual void GroupDependencyTypeChanged() {}
        public virtual void GroupDependencyEntryComboChanged() {}
        public virtual void GroupDependencyEntryNumBoxChanged() {}
        public virtual void GroupDependencyFlagsChanged() {}

        #endregion

        //SAR Project info.
        #region SARProjectInfo

        private void MaxSeqNumBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void MaxSeqTrackNumBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void MaxStreamNumBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void MaxStreamNumTracksBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void MaxStreamNumChannelsBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void MaxWaveNumBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void MaxWaveNumTracksBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void StreamBufferTimesBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void OptionsPIBox_ValueChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        private void SarIncludeStringBlock_CheckedChanged(object sender, EventArgs e) {
            if (!WritingInfo) {
                SarProjectInfoUpdated();
            }
        }

        public virtual void SarProjectInfoUpdated() { }

        #endregion

        public virtual void StmSound3dButton_Click(object sender, EventArgs e) {}

        public virtual void WsdSound3dButton_Click(object sender, EventArgs e) {}

        public virtual void SeqEditSound3dInfoButton_Click(object sender, EventArgs e) {}

        public virtual void SeqEditSoundInfoButton_Click(object sender, EventArgs e) {}

        public virtual void WsdEditSoundInfoButton_Click(object sender, EventArgs e) {}

        public virtual void StmSoundInfoButton_Click(object sender, EventArgs e) {}

        public virtual void FileTypeBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void PlayerSoundLimitBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void PlayerEnableSoundLimitBox_CheckedChanged(object sender, EventArgs e) {}

        public virtual void PlayerHeapSizeBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void SarGrpFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SarWarFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void WarLoadIndividuallyBox_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WarIncludeWaveCountBox_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SarBnkFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void BnkWarsChanged(object sender, EventArgs e) {}

        public virtual void SoundGrpStartIndex_ValueChanged(object sender, EventArgs e) {}

        public virtual void SoundGrpEndIndex_ValueChanged(object sender, EventArgs e) {}

        public virtual void SoundGroupFilesChanged(object sender, EventArgs e) {}

        public virtual void SoundGroupWarsChanged(object sender, EventArgs e) {}

        public virtual void SarSeqFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SarSeqPlay_Click(object sender, EventArgs e) {}

        public virtual void SarSeqPause_Click(object sender, EventArgs e) {}

        public virtual void SarSeqStop_Click(object sender, EventArgs e) {}

        public virtual void SeqSound3dInfoExists_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqBank0Box_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SeqBank1Box_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SeqBank2Box_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SeqBank3Box_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SeqOffsetFromLabelButton_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqOffsetManualButton_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqOffsetFromLabelBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SeqOffsetManualBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void SeqChannelPriorityBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void SeqIsReleasePriorityBox_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC0_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC1_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC2_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC3_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC4_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC5_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC6_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC7_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC8_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC9_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC10_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC11_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC12_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC13_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC14_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SeqC15_CheckedChanged(object sender, EventArgs e) {}

        public virtual void SarWsdFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void SarWsdPlay_Click(object sender, EventArgs e) {}

        public virtual void SarWsdPause_Click(object sender, EventArgs e) {}

        public virtual void SarWsdStop_Click(object sender, EventArgs e) {}

        public virtual void WsdSound3dEnable_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdWaveIndex_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdTracksToAllocate_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdCopyCount_Click(object sender, EventArgs e) {}

        public virtual void WsdChannelPriority_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdFixPriority_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void StmPlay_Click(object sender, EventArgs e) {}

        public virtual void StmPause_Click(object sender, EventArgs e) {}

        public virtual void StmStop_Click(object sender, EventArgs e) {}

        public virtual void StmSound3dEnable_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmWriteTrackInfo_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmUpdateTrackInfo_Click(object sender, EventArgs e) {}

        public virtual void StmTrack0_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack1_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack2_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack3_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack4_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack5_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack6_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack7_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack8_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack9_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack10_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack11_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack12_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack13_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack14_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmTrack15_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmStreamType_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void StmAllocateChannelsNum_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmCopyChannelCountFromFile_Click(object sender, EventArgs e) {}

        public virtual void StmPitch_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmIncludeExtension_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmLoopStartFrame_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmLoopEndFrame_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmCopyExtensionFromFile_Click(object sender, EventArgs e) {}

        public virtual void StmGeneratePrefetch_CheckedChanged(object sender, EventArgs e) {}

        public virtual void StmPrefetchFileIdBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void StmUpdatePrefetchInfo_Click(object sender, EventArgs e) {}

        public virtual void StmCreateUniquePrefetchFile_Click(object sender, EventArgs e) {}

        public virtual void StmSendMain_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmSendA_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmSendB_ValueChanged(object sender, EventArgs e) {}

        public virtual void StmSendC_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackVolume_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackPan_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackSpan_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackSurround_CheckedChanged(object sender, EventArgs e) {}

        public virtual void TrackLPFFrequency_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackBiquadType_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void TrackBiquadValue_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackSendMain_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackSendA_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackSendB_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackSendC_ValueChanged(object sender, EventArgs e) {}

        public virtual void TrackChannelsChanged(object sender, EventArgs e) {}

        public virtual void ByteOrderBox_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void VersionMax_ValueChanged(object sender, EventArgs e) {}

        public virtual void VersionMin_ValueChanged(object sender, EventArgs e) {}

        public virtual void VersionRev_ValueChanged(object sender, EventArgs e) {}

        public virtual void SeqVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void BankVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void WarVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void WsdVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void GrpVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void StmVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void StpVersionUpdate_Click(object sender, EventArgs e) {}

        public virtual void FilesIncludeGroups_CheckedChanged(object sender, EventArgs e) {}

        public virtual void FilesGroupGridCellChanged(object sender, EventArgs e) {}

        public virtual void ReplaceToolStripMenuItem_Click(object sender, EventArgs e) {}

        public virtual void ExportToolStripMenuItem_Click(object sender, EventArgs e) {}

        public virtual void ChangeExternalPathToolStripMenuItem_Click(object sender, EventArgs e) {}

        public virtual void SarAddAbove_Click(object sender, EventArgs e) {}

        public virtual void SarAddBelow_Click(object sender, EventArgs e) {}

        public virtual void SarAddInside_Click(object sender, EventArgs e) {}

        public virtual void SarMoveUp_Click(object sender, EventArgs e) {}

        public virtual void SarMoveDown_Click(object sender, EventArgs e) {}

        public virtual void SarReplace_Click(object sender, EventArgs e) {}

        public virtual void SarExport_Click(object sender, EventArgs e) {}

        public virtual void SarRename_Click(object sender, EventArgs e) {}

        public virtual void SarNullify_Click(object sender, EventArgs e) {}

        public virtual void SarDelete_Click(object sender, EventArgs e) {}

        //Wsd editor.
        #region WsdEditor

        public virtual void WsdTrackPlay_Click(object sender, EventArgs e) {}

        public virtual void WsdTrackPause_Click(object sender, EventArgs e) {}

        public virtual void WsdTrackStop_Click(object sender, EventArgs e) {}

        public virtual void WsdTrackPlayOnce_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdTrackPlayLoop_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdPlayNext_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdEventGrid_CellChange(object sende, EventArgs e) {}

        public virtual void WsdEntryPlay_Click(object sender, EventArgs e) {}

        public virtual void WsdEntryPause_Click(object sender, EventArgs e) {}

        public virtual void WsdEntryStop_Click(object sender, EventArgs e) {}

        public virtual void WsdEntryPlayOnce_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdEntryPlayLoop_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdEntryPlayNext_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdAttack_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdDecay_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdSustain_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdRelease_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdHold_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdLPF_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdBiquadType_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void WsdBiquadValue_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdSendMain_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdSendA_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdSendB_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdSendC_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdPan_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdSpan_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdPitch_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdReference_CellChanged(object sender, EventArgs e) {}

        public virtual void WsdReferencePlay_Click(object sender, EventArgs e) {}

        public virtual void WsdReferencePause_Click(object sender, EventArgs e) {}

        public virtual void WsdReferenceStop_Click(object sender, EventArgs e) {}

        public virtual void WsdReferencePlayOnce_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdReferencePlayLoop_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdReferencePlayNext_CheckedChanged(object sender, EventArgs e) {}

        public virtual void WsdRefArchiveCombo_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void WsdRefArchiveBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void WsdRefWaveCombo_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void WsdRefWaveBox_ValueChanged(object sender, EventArgs e) {}

        #endregion

        //Version change.
        #region VersionChange

        public virtual void VMajBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void VMinBox_ValueChanged(object sender, EventArgs e) {}

        public virtual void VRevBox_ValueChanged(object sender, EventArgs e) {}

        #endregion

        //Note info.
        #region NoteInfo

        public virtual void NoteReferenceWave_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void NoteInterpolationType_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void NotePercussionMode_CheckedChanged(object sender, EventArgs e) {}

        public virtual void NotePitchSemitones_ValueChanged(object sender, EventArgs e) {}

        public virtual void NotePitchCents_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteVolume_ValueChanged(object sender, EventArgs e) {}

        public virtual void NotePan_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteSurroundPan_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteOriginalKey_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteKeyGroup_SelectedIndexChanged(object sender, EventArgs e) {}

        public virtual void NoteAttack_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteDecay_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteSustain_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteRelease_ValueChanged(object sender, EventArgs e) {}

        public virtual void NoteHold_ValueChanged(object sender, EventArgs e) {}

        public virtual void InstrumentApplyChanges_Click(object sender, EventArgs e) {}

        #endregion

        private void PianoChanged(object sender, EventArgs e) {
            if (pkeyC1.IsKeyOn()) {
                NoteDown = Notes.cn1;
                OnPianoPress();
            } else if (pkeyC2.IsKeyOn()) {
                NoteDown = Notes.cn2;
                OnPianoPress();
            } else if (pkeyC3.IsKeyOn()) {
                NoteDown = Notes.cn3;
                OnPianoPress();
            } else if (pkeyC4.IsKeyOn()) {
                NoteDown = Notes.cn4;
                OnPianoPress();
            } else if (pkeyC5.IsKeyOn()) {
                NoteDown = Notes.cn5;
                OnPianoPress();
            } else if (pkeyC6.IsKeyOn()) {
                NoteDown = Notes.cn6;
                OnPianoPress();
            } else if (pkeyC7.IsKeyOn()) {
                NoteDown = Notes.cn7;
                OnPianoPress();
            } else if (pkeyC8.IsKeyOn()) {
                NoteDown = Notes.cn8;
                OnPianoPress();
            } else if (pkeyD1.IsKeyOn()) {
                NoteDown = Notes.dn1;
                OnPianoPress();
            } else if (pkeyD2.IsKeyOn()) {
                NoteDown = Notes.dn2;
                OnPianoPress();
            } else if (pkeyD3.IsKeyOn()) {
                NoteDown = Notes.dn3;
                OnPianoPress();
            } else if (pkeyD4.IsKeyOn()) {
                NoteDown = Notes.dn4;
                OnPianoPress();
            } else if (pkeyD5.IsKeyOn()) {
                NoteDown = Notes.dn5;
                OnPianoPress();
            } else if (pkeyD6.IsKeyOn()) {
                NoteDown = Notes.dn6;
                OnPianoPress();
            } else if (pkeyD7.IsKeyOn()) {
                NoteDown = Notes.dn7;
                OnPianoPress();
            } else if (pkeyE1.IsKeyOn()) {
                NoteDown = Notes.en1;
                OnPianoPress();
            } else if (pkeyE2.IsKeyOn()) {
                NoteDown = Notes.en2;
                OnPianoPress();
            } else if (pkeyE3.IsKeyOn()) {
                NoteDown = Notes.en3;
                OnPianoPress();
            } else if (pkeyE4.IsKeyOn()) {
                NoteDown = Notes.en4;
                OnPianoPress();
            } else if (pkeyE5.IsKeyOn()) {
                NoteDown = Notes.en5;
                OnPianoPress();
            } else if (pkeyE6.IsKeyOn()) {
                NoteDown = Notes.en6;
                OnPianoPress();
            } else if (pkeyE7.IsKeyOn()) {
                NoteDown = Notes.en7;
                OnPianoPress();
            } else if (pkeyF1.IsKeyOn()) {
                NoteDown = Notes.fn1;
                OnPianoPress();
            } else if (pkeyF2.IsKeyOn()) {
                NoteDown = Notes.fn2;
                OnPianoPress();
            } else if (pkeyF3.IsKeyOn()) {
                NoteDown = Notes.fn3;
                OnPianoPress();
            } else if (pkeyF4.IsKeyOn()) {
                NoteDown = Notes.fn4;
                OnPianoPress();
            } else if (pkeyF5.IsKeyOn()) {
                NoteDown = Notes.fn5;
                OnPianoPress();
            } else if (pkeyF6.IsKeyOn()) {
                NoteDown = Notes.fn6;
                OnPianoPress();
            } else if (pkeyF7.IsKeyOn()) {
                NoteDown = Notes.fn7;
                OnPianoPress();
            } else if (pkeyG1.IsKeyOn()) {
                NoteDown = Notes.gn1;
                OnPianoPress();
            } else if (pkeyG2.IsKeyOn()) {
                NoteDown = Notes.gn2;
                OnPianoPress();
            } else if (pkeyG3.IsKeyOn()) {
                NoteDown = Notes.gn3;
                OnPianoPress();
            } else if (pkeyG4.IsKeyOn()) {
                NoteDown = Notes.gn4;
                OnPianoPress();
            } else if (pkeyG5.IsKeyOn()) {
                NoteDown = Notes.gn5;
                OnPianoPress();
            } else if (pkeyG6.IsKeyOn()) {
                NoteDown = Notes.gn6;
                OnPianoPress();
            } else if (pkeyG7.IsKeyOn()) {
                NoteDown = Notes.gn7;
                OnPianoPress();
            } else if (pkeyA1.IsKeyOn()) {
                NoteDown = Notes.an1;
                OnPianoPress();
            } else if (pkeyA2.IsKeyOn()) {
                NoteDown = Notes.an2;
                OnPianoPress();
            } else if (pkeyA3.IsKeyOn()) {
                NoteDown = Notes.an3;
                OnPianoPress();
            } else if (pkeyA4.IsKeyOn()) {
                NoteDown = Notes.an4;
                OnPianoPress();
            } else if (pkeyA5.IsKeyOn()) {
                NoteDown = Notes.an5;
                OnPianoPress();
            } else if (pkeyA6.IsKeyOn()) {
                NoteDown = Notes.an6;
                OnPianoPress();
            } else if (pkeyA7.IsKeyOn()) {
                NoteDown = Notes.an7;
                OnPianoPress();
            } else if (pkeyB1.IsKeyOn()) {
                NoteDown = Notes.bn1;
                OnPianoPress();
            } else if (pkeyB2.IsKeyOn()) {
                NoteDown = Notes.bn2;
                OnPianoPress();
            } else if (pkeyB3.IsKeyOn()) {
                NoteDown = Notes.bn3;
                OnPianoPress();
            } else if (pkeyB4.IsKeyOn()) {
                NoteDown = Notes.bn4;
                OnPianoPress();
            } else if (pkeyB5.IsKeyOn()) {
                NoteDown = Notes.bn5;
                OnPianoPress();
            } else if (pkeyB6.IsKeyOn()) {
                NoteDown = Notes.bn6;
                OnPianoPress();
            } else if (pkeyB7.IsKeyOn()) {
                NoteDown = Notes.bn7;
                OnPianoPress();
            } else if (pkeyCSharp1.IsKeyOn()) {
                NoteDown = Notes.cs1;
                OnPianoPress();
            } else if (pkeyCSharp2.IsKeyOn()) {
                NoteDown = Notes.cs2;
                OnPianoPress();
            } else if (pkeyCSharp3.IsKeyOn()) {
                NoteDown = Notes.cs3;
                OnPianoPress();
            } else if (pkeyCSharp4.IsKeyOn()) {
                NoteDown = Notes.cs4;
                OnPianoPress();
            } else if (pkeyCSharp5.IsKeyOn()) {
                NoteDown = Notes.cs5;
                OnPianoPress();
            } else if (pkeyCSharp6.IsKeyOn()) {
                NoteDown = Notes.cs6;
                OnPianoPress();
            } else if (pkeyCSharp7.IsKeyOn()) {
                NoteDown = Notes.cs7;
                OnPianoPress();
            } else if (pkeyDSharp1.IsKeyOn()) {
                NoteDown = Notes.ds1;
                OnPianoPress();
            } else if (pkeyDSharp2.IsKeyOn()) {
                NoteDown = Notes.ds2;
                OnPianoPress();
            } else if (pkeyDSharp3.IsKeyOn()) {
                NoteDown = Notes.ds3;
                OnPianoPress();
            } else if (pkeyDSharp4.IsKeyOn()) {
                NoteDown = Notes.ds4;
                OnPianoPress();
            } else if (pkeyDSharp5.IsKeyOn()) {
                NoteDown = Notes.ds5;
                OnPianoPress();
            } else if (pkeyDSharp6.IsKeyOn()) {
                NoteDown = Notes.ds6;
                OnPianoPress();
            } else if (pkeyDSharp7.IsKeyOn()) {
                NoteDown = Notes.ds7;
                OnPianoPress();
            } else if (pkeyFSharp1.IsKeyOn()) {
                NoteDown = Notes.fs1;
                OnPianoPress();
            } else if (pkeyFSharp2.IsKeyOn()) {
                NoteDown = Notes.fs2;
                OnPianoPress();
            } else if (pkeyFSharp3.IsKeyOn()) {
                NoteDown = Notes.fs3;
                OnPianoPress();
            } else if (pkeyFSharp4.IsKeyOn()) {
                NoteDown = Notes.fs4;
                OnPianoPress();
            } else if (pkeyFSharp5.IsKeyOn()) {
                NoteDown = Notes.fs5;
                OnPianoPress();
            } else if (pkeyFSharp6.IsKeyOn()) {
                NoteDown = Notes.fs6;
                OnPianoPress();
            } else if (pkeyFSharp7.IsKeyOn()) {
                NoteDown = Notes.fs7;
                OnPianoPress();
            } else if (pkeyGSharp1.IsKeyOn()) {
                NoteDown = Notes.gs1;
                OnPianoPress();
            } else if (pkeyGSharp2.IsKeyOn()) {
                NoteDown = Notes.gs2;
                OnPianoPress();
            } else if (pkeyGSharp3.IsKeyOn()) {
                NoteDown = Notes.gs3;
                OnPianoPress();
            } else if (pkeyGSharp4.IsKeyOn()) {
                NoteDown = Notes.gs4;
                OnPianoPress();
            } else if (pkeyGSharp5.IsKeyOn()) {
                NoteDown = Notes.gs5;
                OnPianoPress();
            } else if (pkeyGSharp6.IsKeyOn()) {
                NoteDown = Notes.gs6;
                OnPianoPress();
            } else if (pkeyGSharp7.IsKeyOn()) {
                NoteDown = Notes.gs7;
                OnPianoPress();
            } else if (pkeyASharp1.IsKeyOn()) {
                NoteDown = Notes.as1;
                OnPianoPress();
            } else if (pkeyASharp2.IsKeyOn()) {
                NoteDown = Notes.as2;
                OnPianoPress();
            } else if (pkeyASharp3.IsKeyOn()) {
                NoteDown = Notes.as3;
                OnPianoPress();
            } else if (pkeyASharp4.IsKeyOn()) {
                NoteDown = Notes.as4;
                OnPianoPress();
            } else if (pkeyASharp5.IsKeyOn()) {
                NoteDown = Notes.as5;
                OnPianoPress();
            } else if (pkeyASharp6.IsKeyOn()) {
                NoteDown = Notes.as6;
                OnPianoPress();
            } else if (pkeyASharp7.IsKeyOn()) {
                NoteDown = Notes.as7;
                OnPianoPress();
            } else {
                OnPianoRelease();
            }
        }

        public virtual void OnPianoPress() {}

        public virtual void OnPianoRelease() {}

        private void ExportStringsToolStripMenuItem_Click(object sender, EventArgs e) {
            ExportStrings();
        }

        public virtual void ExportStrings() {}

        private void SequenceEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            // var ed = new SequenceEditor(this as MainWindow);
            // ed.Show();
        }

        private void SequenceArchiveEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            // var ed = new SequenceArchiveEditor(this as MainWindow);
            // ed.Show();
        }

        private void BankEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            var ed = new BankEditor(this as MainWindow);
            ed.Show();
        }

        private void WaveArchiveEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            var ed = new WaveArchiveEditor(this as MainWindow);
            ed.Show();
        }

        private void BankGeneratorToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!FileOpen || File == null) {
                MessageBox.Show("There must be a file open to do this!");
                return;
            }
            var ed = new BankGenerator(this as MainWindow);
            ed.Show();
        }

        private void CreaveWaveToolStripMenuItem_Click(object sender, EventArgs e) {
            CreateStreamTool ed = new CreateStreamTool(true);
            ed.Show();
        }

        private void CreateStreamToolStripMenuItem_Click(object sender, EventArgs e) {
            CreateStreamTool ed = new CreateStreamTool(false);
            ed.Show();
        }

        private void ExportSDKProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Sound Project|*.sprj";
            if (FilePath != null && FilePath != "") { s.FileName = Path.GetFileNameWithoutExtension(FilePath) + ".sprj"; }
            s.RestoreDirectory = true;
            if (s.ShowDialog() == DialogResult.OK) {
                (File as SoundArchive).ExportSDKProject(Path.GetDirectoryName(s.FileName), Path.GetFileNameWithoutExtension(s.FileName));
            }
        }

        private void GetHelpToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://gota7.github.io/NitroStudio2/#guide");
            } catch { }
        }

        /// <summary>
        /// Get the color region.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <param name="start">Start note.</param>
        /// <param name="end">End note.</param>
        public void ColorRegion(Color color, byte start, byte end) {
            for (byte b = start; b <= end; b++) {
                var n = GetKey((Notes)b);
                if (n != null) {
                    if (n.Shape == PianoKeyShape.RectShape && n != pkeyC8) {
                        n.KeyOffColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    } else {
                        n.KeyOffColor = color;
                    }
                }
            }
        }

        /// <summary>
        /// Get the piano key.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public PianoKey GetKey(Notes n) {
            switch (n) {
                case Notes.an1:
                    return pkeyA1;
                case Notes.an2:
                    return pkeyA2;
                case Notes.an3:
                    return pkeyA3;
                case Notes.an4:
                    return pkeyA4;
                case Notes.an5:
                    return pkeyA5;
                case Notes.an6:
                    return pkeyA6;
                case Notes.an7:
                    return pkeyA7;
                case Notes.bn1:
                    return pkeyB1;
                case Notes.bn2:
                    return pkeyB2;
                case Notes.bn3:
                    return pkeyB3;
                case Notes.bn4:
                    return pkeyB4;
                case Notes.bn5:
                    return pkeyB5;
                case Notes.bn6:
                    return pkeyB6;
                case Notes.bn7:
                    return pkeyB7;
                case Notes.cn1:
                    return pkeyC1;
                case Notes.cn2:
                    return pkeyC2;
                case Notes.cn3:
                    return pkeyC3;
                case Notes.cn4:
                    return pkeyC4;
                case Notes.cn5:
                    return pkeyC5;
                case Notes.cn6:
                    return pkeyC6;
                case Notes.cn7:
                    return pkeyC7;
                case Notes.cn8:
                    return pkeyC8;
                case Notes.dn1:
                    return pkeyD1;
                case Notes.dn2:
                    return pkeyD2;
                case Notes.dn3:
                    return pkeyD3;
                case Notes.dn4:
                    return pkeyD4;
                case Notes.dn5:
                    return pkeyD5;
                case Notes.dn6:
                    return pkeyD6;
                case Notes.dn7:
                    return pkeyD7;
                case Notes.en1:
                    return pkeyE1;
                case Notes.en2:
                    return pkeyE2;
                case Notes.en3:
                    return pkeyE3;
                case Notes.en4:
                    return pkeyE4;
                case Notes.en5:
                    return pkeyE5;
                case Notes.en6:
                    return pkeyE6;
                case Notes.en7:
                    return pkeyE7;
                case Notes.fn1:
                    return pkeyF1;
                case Notes.fn2:
                    return pkeyF2;
                case Notes.fn3:
                    return pkeyF3;
                case Notes.fn4:
                    return pkeyF4;
                case Notes.fn5:
                    return pkeyF5;
                case Notes.fn6:
                    return pkeyF6;
                case Notes.fn7:
                    return pkeyF7;
                case Notes.gn1:
                    return pkeyG1;
                case Notes.gn2:
                    return pkeyG2;
                case Notes.gn3:
                    return pkeyG3;
                case Notes.gn4:
                    return pkeyG4;
                case Notes.gn5:
                    return pkeyG5;
                case Notes.gn6:
                    return pkeyG6;
                case Notes.gn7:
                    return pkeyG7;
                case Notes.as1:
                    return pkeyASharp1;
                case Notes.as2:
                    return pkeyASharp2;
                case Notes.as3:
                    return pkeyASharp3;
                case Notes.as4:
                    return pkeyASharp4;
                case Notes.as5:
                    return pkeyASharp5;
                case Notes.as6:
                    return pkeyASharp6;
                case Notes.as7:
                    return pkeyASharp7;
                case Notes.cs1:
                    return pkeyCSharp1;
                case Notes.cs2:
                    return pkeyCSharp2;
                case Notes.cs3:
                    return pkeyCSharp3;
                case Notes.cs4:
                    return pkeyCSharp4;
                case Notes.cs5:
                    return pkeyCSharp5;
                case Notes.cs6:
                    return pkeyCSharp6;
                case Notes.cs7:
                    return pkeyCSharp7;
                case Notes.ds1:
                    return pkeyDSharp1;
                case Notes.ds2:
                    return pkeyDSharp2;
                case Notes.ds3:
                    return pkeyDSharp3;
                case Notes.ds4:
                    return pkeyDSharp4;
                case Notes.ds5:
                    return pkeyDSharp5;
                case Notes.ds6:
                    return pkeyDSharp6;
                case Notes.ds7:
                    return pkeyDSharp7;
                case Notes.fs1:
                    return pkeyFSharp1;
                case Notes.fs2:
                    return pkeyFSharp2;
                case Notes.fs3:
                    return pkeyFSharp3;
                case Notes.fs4:
                    return pkeyFSharp4;
                case Notes.fs5:
                    return pkeyFSharp5;
                case Notes.fs6:
                    return pkeyFSharp6;
                case Notes.fs7:
                    return pkeyFSharp7;
                case Notes.gs1:
                    return pkeyGSharp1;
                case Notes.gs2:
                    return pkeyGSharp2;
                case Notes.gs3:
                    return pkeyGSharp3;
                case Notes.gs4:
                    return pkeyGSharp4;
                case Notes.gs5:
                    return pkeyGSharp5;
                case Notes.gs6:
                    return pkeyGSharp6;
                case Notes.gs7:
                    return pkeyGSharp7;
                default:
                    return null;
            }
        }

        private void AboutNitroStudio2ToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutWindow a = new AboutWindow();
            a.ShowDialog();
        }

        private void sF2ToDLSToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog o = new OpenFileDialog();
            o.RestoreDirectory = true;
            o.Filter = "Sound Font|*.sf2";
            if (o.ShowDialog() == DialogResult.OK) {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Downloadable Sounds|*.dls";
                s.RestoreDirectory = true;
                s.FileName = Path.GetFileNameWithoutExtension(o.FileName) + ".dls";
                if (s.ShowDialog() == DialogResult.OK) {
                    var h = new SoundFont(o.FileName);
                    new DownloadableSounds(h).Write(s.FileName);
                }
            }
        }

        private void dLSToSF2ToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog o = new OpenFileDialog();
            o.RestoreDirectory = true;
            o.Filter = "Downloadable Sounds|*.dls";
            if (o.ShowDialog() == DialogResult.OK) {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Sound Font|*.sf2";
                s.RestoreDirectory = true;
                s.FileName = Path.GetFileNameWithoutExtension(o.FileName) + ".sf2";
                if (s.ShowDialog() == DialogResult.OK) {
                    var h = new DownloadableSounds(o.FileName);
                    new SoundFont(h).Write(s.FileName);
                }
            }
        }

    }

}