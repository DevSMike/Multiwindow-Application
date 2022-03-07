
namespace TheKursBegins
{
    partial class FormCreate
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.menuLableForMethod = new System.Windows.Forms.Label();
            this.TextBoxMenu1 = new System.Windows.Forms.TextBox();
            this.labelForPlace = new System.Windows.Forms.Label();
            this.textBoxForPlace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(10, 167);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Добавить";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(174, 166);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // menuLableForMethod
            // 
            this.menuLableForMethod.AutoSize = true;
            this.menuLableForMethod.Location = new System.Drawing.Point(10, 68);
            this.menuLableForMethod.Name = "menuLableForMethod";
            this.menuLableForMethod.Size = new System.Drawing.Size(28, 15);
            this.menuLableForMethod.TabIndex = 4;
            this.menuLableForMethod.Text = "Text";
            // 
            // TextBoxMenu1
            // 
            this.TextBoxMenu1.Location = new System.Drawing.Point(187, 60);
            this.TextBoxMenu1.Name = "TextBoxMenu1";
            this.TextBoxMenu1.Size = new System.Drawing.Size(100, 23);
            this.TextBoxMenu1.TabIndex = 5;
            // 
            // labelForPlace
            // 
            this.labelForPlace.AutoSize = true;
            this.labelForPlace.Location = new System.Drawing.Point(10, 99);
            this.labelForPlace.Name = "labelForPlace";
            this.labelForPlace.Size = new System.Drawing.Size(34, 15);
            this.labelForPlace.TabIndex = 6;
            this.labelForPlace.Text = "Text2";
            // 
            // textBoxForPlace
            // 
            this.textBoxForPlace.Location = new System.Drawing.Point(187, 99);
            this.textBoxForPlace.Name = "textBoxForPlace";
            this.textBoxForPlace.Size = new System.Drawing.Size(100, 23);
            this.textBoxForPlace.TabIndex = 7;
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 254);
            this.Controls.Add(this.textBoxForPlace);
            this.Controls.Add(this.labelForPlace);
            this.Controls.Add(this.TextBoxMenu1);
            this.Controls.Add(this.menuLableForMethod);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormCreate";
            this.Text = "Добавить объект";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label menuLableForMethod;
        private System.Windows.Forms.TextBox TextBoxMenu1;
        private System.Windows.Forms.Label labelForPlace;
        private System.Windows.Forms.TextBox textBoxForPlace;
    }
}