namespace WordAnalyzer
{
    partial class Form2
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
            txtResults = new TextBox();
            btnSaveResults = new Button();
            SuspendLayout();
            // 
            // txtResults
            // 
            txtResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtResults.Location = new Point(12, 12);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(678, 218);
            txtResults.TabIndex = 0;
            // 
            // btnSaveResults
            // 
            btnSaveResults.Location = new Point(286, 259);
            btnSaveResults.Name = "btnSaveResults";
            btnSaveResults.Size = new Size(133, 29);
            btnSaveResults.TabIndex = 1;
            btnSaveResults.Text = "Save Results";
            btnSaveResults.UseVisualStyleBackColor = true;
            btnSaveResults.Click += btnSaveResults_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 300);
            Controls.Add(btnSaveResults);
            Controls.Add(txtResults);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtResults;
        private Button btnSaveResults;
    }
}