namespace Speiseplan.Forms
{
    partial class frmZutat
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZutatID = new System.Windows.Forms.TextBox();
            this.txtEinheit = new System.Windows.Forms.TextBox();
            this.txtBezeichnung = new System.Windows.Forms.TextBox();
            this.txtAllergene = new System.Windows.Forms.TextBox();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ZutatID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Einheit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bezeichnung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Allergene *";
            // 
            // txtZutatID
            // 
            this.txtZutatID.Location = new System.Drawing.Point(137, 22);
            this.txtZutatID.Name = "txtZutatID";
            this.txtZutatID.ReadOnly = true;
            this.txtZutatID.Size = new System.Drawing.Size(181, 26);
            this.txtZutatID.TabIndex = 4;
            // 
            // txtEinheit
            // 
            this.txtEinheit.Location = new System.Drawing.Point(137, 83);
            this.txtEinheit.Name = "txtEinheit";
            this.txtEinheit.Size = new System.Drawing.Size(181, 26);
            this.txtEinheit.TabIndex = 5;
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.Location = new System.Drawing.Point(137, 144);
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Size = new System.Drawing.Size(181, 26);
            this.txtBezeichnung.TabIndex = 6;
            // 
            // txtAllergene
            // 
            this.txtAllergene.Location = new System.Drawing.Point(137, 205);
            this.txtAllergene.Name = "txtAllergene";
            this.txtAllergene.Size = new System.Drawing.Size(181, 26);
            this.txtAllergene.TabIndex = 7;
            this.txtAllergene.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAllergene_KeyDown);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(23, 248);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(295, 43);
            this.btnSpeichern.TabIndex = 8;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(23, 297);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(295, 43);
            this.btnAbbrechen.TabIndex = 9;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "* Drücken Sie F1 für nähere Informationen! ";
            // 
            // frmZutat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 380);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.txtAllergene);
            this.Controls.Add(this.txtBezeichnung);
            this.Controls.Add(this.txtEinheit);
            this.Controls.Add(this.txtZutatID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmZutat";
            this.Text = "frmZutat";
            this.Load += new System.EventHandler(this.frmZutat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnAbbrechen;
        internal System.Windows.Forms.TextBox txtZutatID;
        internal System.Windows.Forms.TextBox txtEinheit;
        internal System.Windows.Forms.TextBox txtBezeichnung;
        internal System.Windows.Forms.TextBox txtAllergene;
        private System.Windows.Forms.Label label6;
    }
}