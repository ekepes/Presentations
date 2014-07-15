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
            this.label1 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.BuyWidgets = new System.Windows.Forms.Button();
            this.SendBatches = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantity to Buy";
            // 
            // Quantity
            // 
            this.Quantity.Location = new System.Drawing.Point(31, 30);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(76, 20);
            this.Quantity.TabIndex = 1;
            this.Quantity.Text = "10";
            // 
            // BuyWidgets
            // 
            this.BuyWidgets.Location = new System.Drawing.Point(31, 57);
            this.BuyWidgets.Name = "BuyWidgets";
            this.BuyWidgets.Size = new System.Drawing.Size(75, 23);
            this.BuyWidgets.TabIndex = 2;
            this.BuyWidgets.Text = "Buy";
            this.BuyWidgets.UseVisualStyleBackColor = true;
            this.BuyWidgets.Click += new System.EventHandler(this.BuyWidgets_Click);
            // 
            // SendBatches
            // 
            this.SendBatches.Location = new System.Drawing.Point(32, 167);
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
            this.Controls.Add(this.BuyWidgets);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.label1);
            this.Name = "WidgetBuyer";
            this.Text = "WidgetBuyer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Button BuyWidgets;
        private System.Windows.Forms.Button SendBatches;
    }
}

