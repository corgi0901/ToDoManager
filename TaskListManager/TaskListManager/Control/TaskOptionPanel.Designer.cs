namespace TaskListManager
{
    partial class TaskOptionPanel
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
            this.editButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Silver;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.editButton.Location = new System.Drawing.Point(0, 25);
            this.editButton.Margin = new System.Windows.Forms.Padding(0);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(50, 25);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "編集";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.doneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.doneButton.FlatAppearance.BorderSize = 0;
            this.doneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.doneButton.Location = new System.Drawing.Point(0, 0);
            this.doneButton.Margin = new System.Windows.Forms.Padding(0);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(50, 25);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "完了";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // TaskOptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.doneButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TaskOptionPanel";
            this.Size = new System.Drawing.Size(50, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button editButton;
    }
}
