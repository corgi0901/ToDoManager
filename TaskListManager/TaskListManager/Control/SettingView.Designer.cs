namespace TaskListManager.Control
{
    partial class SettingView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.taskNumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskNumNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(176, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "アプリケーション設定";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文字サイズ (10 ～ 20)";
            // 
            // fontSizeNumericUpDown
            // 
            this.fontSizeNumericUpDown.Location = new System.Drawing.Point(5, 54);
            this.fontSizeNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            this.fontSizeNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.fontSizeNumericUpDown.TabIndex = 2;
            this.fontSizeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(5, 126);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(86, 126);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "表示するタスクの最大数（1 ～ 100）";
            // 
            // taskNumNumericUpDown
            // 
            this.taskNumNumericUpDown.Location = new System.Drawing.Point(5, 101);
            this.taskNumNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.taskNumNumericUpDown.Name = "taskNumNumericUpDown";
            this.taskNumNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.taskNumNumericUpDown.TabIndex = 6;
            this.taskNumNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // SettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.taskNumNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fontSizeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "SettingView";
            this.Size = new System.Drawing.Size(176, 161);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskNumNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown fontSizeNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown taskNumNumericUpDown;
    }
}
