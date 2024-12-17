namespace WordAnalyzer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBoxDisplay = new RichTextBox();
            btnLoadFile = new Button();
            btnAnalyze = new Button();
            SuspendLayout();
            // 
            // richTextBoxDisplay
            // 
            richTextBoxDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxDisplay.Location = new Point(10, 55);
            richTextBoxDisplay.Name = "richTextBoxDisplay";
            richTextBoxDisplay.Size = new Size(860, 442);
            richTextBoxDisplay.TabIndex = 2;
            richTextBoxDisplay.Text = "";
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(52, 12);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(94, 29);
            btnLoadFile.TabIndex = 3;
            btnLoadFile.Text = "Load File";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(186, 12);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(94, 29);
            btnAnalyze.TabIndex = 4;
            btnAnalyze.Text = "Analyze";
            btnAnalyze.UseVisualStyleBackColor = true;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 503);
            Controls.Add(btnAnalyze);
            Controls.Add(btnLoadFile);
            Controls.Add(richTextBoxDisplay);
            Name = "Form1";
            Text = "Word Analyzer";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox richTextBoxDisplay;
        private Button btnLoadFile;
        private Button btnAnalyze;
    }
}
