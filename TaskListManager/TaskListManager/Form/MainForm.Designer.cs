namespace TaskListManager
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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.addButton = new System.Windows.Forms.Button();
            this.taskTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "新しいタスク";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // taskTableLayoutPanel
            // 
            this.taskTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskTableLayoutPanel.AutoScroll = true;
            this.taskTableLayoutPanel.ColumnCount = 1;
            this.taskTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.taskTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.taskTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.taskTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.taskTableLayoutPanel.Name = "taskTableLayoutPanel";
            this.taskTableLayoutPanel.RowCount = 2;
            this.taskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.taskTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.taskTableLayoutPanel.Size = new System.Drawing.Size(330, 120);
            this.taskTableLayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.taskTableLayoutPanel, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(330, 617);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 655);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.addButton);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "ToDo List";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TableLayoutPanel taskTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}

