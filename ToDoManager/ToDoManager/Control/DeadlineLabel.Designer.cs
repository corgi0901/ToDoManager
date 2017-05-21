namespace ToDoManager
{
    partial class DeadlineLabel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dateLabel = new System.Windows.Forms.Label();
            this.remainDayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateLabel.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.dateLabel.Location = new System.Drawing.Point(0, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dateLabel.Size = new System.Drawing.Size(100, 25);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "label1";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // remainDayLabel
            // 
            this.remainDayLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.remainDayLabel.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.remainDayLabel.Location = new System.Drawing.Point(97, 0);
            this.remainDayLabel.Name = "remainDayLabel";
            this.remainDayLabel.Size = new System.Drawing.Size(100, 25);
            this.remainDayLabel.TabIndex = 1;
            this.remainDayLabel.Text = "label2";
            this.remainDayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DeadlineLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.remainDayLabel);
            this.Controls.Add(this.dateLabel);
            this.Name = "DeadlineLabel";
            this.Size = new System.Drawing.Size(200, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label remainDayLabel;
    }
}
