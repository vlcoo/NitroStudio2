namespace NitroStudio2 {
    partial class CreateStreamTool {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateStreamTool));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            impFileBox = new System.Windows.Forms.TextBox();
            impFileButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            outFileBox = new System.Windows.Forms.TextBox();
            outFileButton = new System.Windows.Forms.Button();
            outputFormat = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            exportButton = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.7971F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2029F));
            tableLayoutPanel1.Controls.Add(impFileBox, 0, 0);
            tableLayoutPanel1.Controls.Add(impFileButton, 1, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(14, 33);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(402, 33);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // impFileBox
            // 
            impFileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            impFileBox.Location = new System.Drawing.Point(4, 3);
            impFileBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            impFileBox.Name = "impFileBox";
            impFileBox.ReadOnly = true;
            impFileBox.Size = new System.Drawing.Size(336, 23);
            impFileBox.TabIndex = 0;
            // 
            // impFileButton
            // 
            impFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            impFileButton.Location = new System.Drawing.Point(348, 3);
            impFileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            impFileButton.Name = "impFileButton";
            impFileButton.Size = new System.Drawing.Size(50, 27);
            impFileButton.TabIndex = 1;
            impFileButton.Text = "...";
            impFileButton.UseVisualStyleBackColor = true;
            impFileButton.Click += impFileButton_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Location = new System.Drawing.Point(14, 8);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(402, 22);
            label1.TabIndex = 1;
            label1.Text = "Input File:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.Location = new System.Drawing.Point(14, 67);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(402, 22);
            label2.TabIndex = 3;
            label2.Text = "Output File:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.7971F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2029F));
            tableLayoutPanel2.Controls.Add(outFileBox, 0, 0);
            tableLayoutPanel2.Controls.Add(outFileButton, 1, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(14, 92);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(402, 33);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // outFileBox
            // 
            outFileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            outFileBox.Location = new System.Drawing.Point(4, 3);
            outFileBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            outFileBox.Name = "outFileBox";
            outFileBox.ReadOnly = true;
            outFileBox.Size = new System.Drawing.Size(336, 23);
            outFileBox.TabIndex = 0;
            // 
            // outFileButton
            // 
            outFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            outFileButton.Location = new System.Drawing.Point(348, 3);
            outFileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            outFileButton.Name = "outFileButton";
            outFileButton.Size = new System.Drawing.Size(50, 27);
            outFileButton.TabIndex = 1;
            outFileButton.Text = "...";
            outFileButton.UseVisualStyleBackColor = true;
            outFileButton.Click += outFileButton_Click;
            // 
            // outputFormat
            // 
            outputFormat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            outputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            outputFormat.FormattingEnabled = true;
            outputFormat.Items.AddRange(new object[] { "PCM8", "PCM16", "IMA-ADPCM" });
            outputFormat.Location = new System.Drawing.Point(14, 155);
            outputFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            outputFormat.Name = "outputFormat";
            outputFormat.Size = new System.Drawing.Size(402, 23);
            outputFormat.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.Location = new System.Drawing.Point(14, 129);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(402, 22);
            label3.TabIndex = 5;
            label3.Text = "Format:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exportButton
            // 
            exportButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            exportButton.Location = new System.Drawing.Point(14, 186);
            exportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportButton.Name = "exportButton";
            exportButton.Size = new System.Drawing.Size(402, 27);
            exportButton.TabIndex = 6;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // CreateStreamTool
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(430, 235);
            Controls.Add(exportButton);
            Controls.Add(label3);
            Controls.Add(outputFormat);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "CreateStreamTool";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Create Stream";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox impFileBox;
        private System.Windows.Forms.Button impFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox outFileBox;
        private System.Windows.Forms.Button outFileButton;
        private System.Windows.Forms.ComboBox outputFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportButton;
    }
}