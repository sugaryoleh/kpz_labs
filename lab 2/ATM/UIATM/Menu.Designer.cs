
namespace UIATM
{
    partial class Menu
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
            this.button_put = new System.Windows.Forms.Button();
            this.button_withdraw = new System.Windows.Forms.Button();
            this.button_checkBalance = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_put
            // 
            this.button_put.Location = new System.Drawing.Point(41, 296);
            this.button_put.Name = "button_put";
            this.button_put.Size = new System.Drawing.Size(200, 75);
            this.button_put.TabIndex = 0;
            this.button_put.Text = "Put";
            this.button_put.UseVisualStyleBackColor = true;
            this.button_put.Click += new System.EventHandler(this.button_put_Click);
            // 
            // button_withdraw
            // 
            this.button_withdraw.Location = new System.Drawing.Point(41, 215);
            this.button_withdraw.Name = "button_withdraw";
            this.button_withdraw.Size = new System.Drawing.Size(200, 75);
            this.button_withdraw.TabIndex = 1;
            this.button_withdraw.Text = "Withdraw";
            this.button_withdraw.UseVisualStyleBackColor = true;
            this.button_withdraw.Click += new System.EventHandler(this.button_withdraw_Click);
            // 
            // button_checkBalance
            // 
            this.button_checkBalance.Location = new System.Drawing.Point(41, 134);
            this.button_checkBalance.Name = "button_checkBalance";
            this.button_checkBalance.Size = new System.Drawing.Size(200, 75);
            this.button_checkBalance.TabIndex = 2;
            this.button_checkBalance.Text = "Balance";
            this.button_checkBalance.UseVisualStyleBackColor = true;
            this.button_checkBalance.Click += new System.EventHandler(this.button_checkBalance_Click);
            // 
            // label_message
            // 
            this.label_message.BackColor = System.Drawing.SystemColors.Info;
            this.label_message.Location = new System.Drawing.Point(41, 39);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(200, 76);
            this.label_message.TabIndex = 3;
            this.label_message.Click += new System.EventHandler(this.label1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 453);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.button_checkBalance);
            this.Controls.Add(this.button_withdraw);
            this.Controls.Add(this.button_put);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_put;
        private System.Windows.Forms.Button button_withdraw;
        private System.Windows.Forms.Button button_checkBalance;
        private System.Windows.Forms.Label label_message;
    }
}