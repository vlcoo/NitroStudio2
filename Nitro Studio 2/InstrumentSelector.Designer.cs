namespace NitroStudio2 {
    partial class InstrumentSelector {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentSelector));
            instGrid = new System.Windows.Forms.DataGridView();
            playColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            instrumentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            instrumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            useInstrument = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            checkMenu = new System.Windows.Forms.ContextMenuStrip(components);
            checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            finishedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)instGrid).BeginInit();
            checkMenu.SuspendLayout();
            SuspendLayout();
            // 
            // instGrid
            // 
            instGrid.AllowUserToAddRows = false;
            instGrid.AllowUserToDeleteRows = false;
            instGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            instGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            instGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            instGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { playColumn, instrumentId, instrumentName, useInstrument });
            instGrid.ContextMenuStrip = checkMenu;
            instGrid.Location = new System.Drawing.Point(14, 14);
            instGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            instGrid.Name = "instGrid";
            instGrid.Size = new System.Drawing.Size(604, 337);
            instGrid.TabIndex = 0;
            // 
            // playColumn
            // 
            playColumn.HeaderText = "Play Sample";
            playColumn.Name = "playColumn";
            playColumn.Text = "Play";
            playColumn.UseColumnTextForButtonValue = true;
            // 
            // instrumentId
            // 
            instrumentId.HeaderText = "Instrument Id";
            instrumentId.Name = "instrumentId";
            instrumentId.ReadOnly = true;
            instrumentId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // instrumentName
            // 
            instrumentName.HeaderText = "Instrument Name";
            instrumentName.Name = "instrumentName";
            instrumentName.ReadOnly = true;
            instrumentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            instrumentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // useInstrument
            // 
            useInstrument.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            useInstrument.HeaderText = "Use Instrument";
            useInstrument.Name = "useInstrument";
            // 
            // checkMenu
            // 
            checkMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { checkAllToolStripMenuItem, uncheckAllToolStripMenuItem });
            checkMenu.Name = "checkMenu";
            checkMenu.Size = new System.Drawing.Size(138, 48);
            // 
            // checkAllToolStripMenuItem
            // 
            checkAllToolStripMenuItem.Image = Properties.Resources.Save;
            checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            checkAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            checkAllToolStripMenuItem.Text = "Check All";
            checkAllToolStripMenuItem.Click += checkAllToolStripMenuItem_Click;
            // 
            // uncheckAllToolStripMenuItem
            // 
            uncheckAllToolStripMenuItem.Image = Properties.Resources.Save_As;
            uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            uncheckAllToolStripMenuItem.Text = "Uncheck All";
            uncheckAllToolStripMenuItem.Click += uncheckAllToolStripMenuItem_Click;
            // 
            // finishedButton
            // 
            finishedButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            finishedButton.Location = new System.Drawing.Point(14, 359);
            finishedButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            finishedButton.Name = "finishedButton";
            finishedButton.Size = new System.Drawing.Size(604, 27);
            finishedButton.TabIndex = 1;
            finishedButton.Text = "Finished";
            finishedButton.UseVisualStyleBackColor = true;
            finishedButton.Click += finishedButton_Click;
            // 
            // InstrumentSelector
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(632, 399);
            Controls.Add(finishedButton);
            Controls.Add(instGrid);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "InstrumentSelector";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Instrument Selector";
            ((System.ComponentModel.ISupportInitialize)instGrid).EndInit();
            checkMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView instGrid;
        private System.Windows.Forms.Button finishedButton;
        private System.Windows.Forms.DataGridViewButtonColumn playColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn useInstrument;
        private System.Windows.Forms.ContextMenuStrip checkMenu;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
    }
}