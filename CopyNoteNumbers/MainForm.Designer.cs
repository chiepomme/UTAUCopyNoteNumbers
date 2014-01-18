namespace CopyNoteNumbers
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.CopyButton = new System.Windows.Forms.Button();
            this.PasteButton = new System.Windows.Forms.Button();
            this.Offset = new System.Windows.Forms.TextBox();
            this.OffsetDescriptionLabel = new System.Windows.Forms.Label();
            this.AuthorLink = new System.Windows.Forms.LinkLabel();
            this.OffsetUnitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(12, 12);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(75, 23);
            this.CopyButton.TabIndex = 0;
            this.CopyButton.Text = "コピー";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.OnCopyButtonClicked);
            // 
            // PasteButton
            // 
            this.PasteButton.Location = new System.Drawing.Point(12, 41);
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.Size = new System.Drawing.Size(75, 23);
            this.PasteButton.TabIndex = 1;
            this.PasteButton.Text = "貼り付け";
            this.PasteButton.UseVisualStyleBackColor = true;
            this.PasteButton.Click += new System.EventHandler(this.OnPasteButtonClicked);
            // 
            // Offset
            // 
            this.Offset.Location = new System.Drawing.Point(208, 43);
            this.Offset.Name = "Offset";
            this.Offset.Size = new System.Drawing.Size(54, 19);
            this.Offset.TabIndex = 2;
            this.Offset.Text = "0";
            this.Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OffsetDescriptionLabel
            // 
            this.OffsetDescriptionLabel.AutoSize = true;
            this.OffsetDescriptionLabel.Location = new System.Drawing.Point(93, 46);
            this.OffsetDescriptionLabel.Name = "OffsetDescriptionLabel";
            this.OffsetDescriptionLabel.Size = new System.Drawing.Size(109, 12);
            this.OffsetDescriptionLabel.TabIndex = 3;
            this.OffsetDescriptionLabel.Text = "少し前から貼り付ける:";
            // 
            // AuthorLink
            // 
            this.AuthorLink.AutoSize = true;
            this.AuthorLink.LinkArea = new System.Windows.Forms.LinkArea(2, 12);
            this.AuthorLink.Location = new System.Drawing.Point(214, 17);
            this.AuthorLink.Name = "AuthorLink";
            this.AuthorLink.Size = new System.Drawing.Size(78, 17);
            this.AuthorLink.TabIndex = 4;
            this.AuthorLink.TabStop = true;
            this.AuthorLink.Text = "by chiepomme";
            this.AuthorLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AuthorLink.UseCompatibleTextRendering = true;
            this.AuthorLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnAuthorLinkClicked);
            // 
            // OffsetUnitLabel
            // 
            this.OffsetUnitLabel.AutoSize = true;
            this.OffsetUnitLabel.Location = new System.Drawing.Point(268, 46);
            this.OffsetUnitLabel.Name = "OffsetUnitLabel";
            this.OffsetUnitLabel.Size = new System.Drawing.Size(24, 12);
            this.OffsetUnitLabel.TabIndex = 5;
            this.OffsetUnitLabel.Text = "tick";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 73);
            this.Controls.Add(this.OffsetUnitLabel);
            this.Controls.Add(this.AuthorLink);
            this.Controls.Add(this.OffsetDescriptionLabel);
            this.Controls.Add(this.Offset);
            this.Controls.Add(this.PasteButton);
            this.Controls.Add(this.CopyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音程コピペ";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button PasteButton;
        private System.Windows.Forms.TextBox Offset;
        private System.Windows.Forms.Label OffsetDescriptionLabel;
        private System.Windows.Forms.LinkLabel AuthorLink;
        private System.Windows.Forms.Label OffsetUnitLabel;
    }
}

