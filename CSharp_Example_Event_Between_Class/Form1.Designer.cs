namespace CSharp_Example_Event_Between_Class
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Go = new System.Windows.Forms.Button();
            this.Rich_Tbx = new System.Windows.Forms.RichTextBox();
            this.Btn_BackGroundWorker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Go
            // 
            this.Btn_Go.Location = new System.Drawing.Point(12, 130);
            this.Btn_Go.Name = "Btn_Go";
            this.Btn_Go.Size = new System.Drawing.Size(125, 23);
            this.Btn_Go.TabIndex = 0;
            this.Btn_Go.Text = "Go";
            this.Btn_Go.UseVisualStyleBackColor = true;
            this.Btn_Go.Click += new System.EventHandler(this.Btn_Go_Click);
            // 
            // Rich_Tbx
            // 
            this.Rich_Tbx.Location = new System.Drawing.Point(12, 12);
            this.Rich_Tbx.Name = "Rich_Tbx";
            this.Rich_Tbx.Size = new System.Drawing.Size(260, 112);
            this.Rich_Tbx.TabIndex = 1;
            this.Rich_Tbx.Text = "";
            // 
            // Btn_BackGroundWorker
            // 
            this.Btn_BackGroundWorker.Location = new System.Drawing.Point(147, 130);
            this.Btn_BackGroundWorker.Name = "Btn_BackGroundWorker";
            this.Btn_BackGroundWorker.Size = new System.Drawing.Size(125, 23);
            this.Btn_BackGroundWorker.TabIndex = 2;
            this.Btn_BackGroundWorker.Text = "BackGroundWorker";
            this.Btn_BackGroundWorker.UseVisualStyleBackColor = true;
            this.Btn_BackGroundWorker.Click += new System.EventHandler(this.Btn_BackGroundWorker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.Btn_BackGroundWorker);
            this.Controls.Add(this.Rich_Tbx);
            this.Controls.Add(this.Btn_Go);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Go;
        private System.Windows.Forms.RichTextBox Rich_Tbx;
        private System.Windows.Forms.Button Btn_BackGroundWorker;
    }
}

