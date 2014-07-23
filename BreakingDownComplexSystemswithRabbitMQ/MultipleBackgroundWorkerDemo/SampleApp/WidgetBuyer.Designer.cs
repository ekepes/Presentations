namespace SampleApp
{
    partial class WidgetBuyer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendBatches = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendBatches
            // 
            this.SendBatches.Location = new System.Drawing.Point(12, 12);
            this.SendBatches.Name = "SendBatches";
            this.SendBatches.Size = new System.Drawing.Size(86, 23);
            this.SendBatches.TabIndex = 3;
            this.SendBatches.Text = "Send Batches";
            this.SendBatches.UseVisualStyleBackColor = true;
            this.SendBatches.Click += new System.EventHandler(this.SendBatches_Click);
            // 
            // WidgetBuyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SendBatches);
            this.Name = "WidgetBuyer";
            this.Text = "WidgetBuyer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SendBatches;
    }
}

