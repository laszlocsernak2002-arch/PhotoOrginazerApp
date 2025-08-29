using System.Drawing;

namespace PhotoOrginaserApp
{
    partial class Form1
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
            this.search_btn = new System.Windows.Forms.Button();
            this.folder_text = new System.Windows.Forms.TextBox();
            this.list_of_filenames = new System.Windows.Forms.ListBox();
            this.list_items = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.RunAlgorithm_btn = new System.Windows.Forms.Button();
            this.image_radioBtn = new System.Windows.Forms.RadioButton();
            this.video_radioBtn = new System.Windows.Forms.RadioButton();
            this.hideDuplicates_chkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // search_btn
            // 
            this.search_btn.Location = new System.Drawing.Point(474, 64);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(105, 23);
            this.search_btn.TabIndex = 0;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // folder_text
            // 
            this.folder_text.BackColor = System.Drawing.Color.White;
            this.folder_text.Enabled = false;
            this.folder_text.ForeColor = System.Drawing.Color.Black;
            this.folder_text.Location = new System.Drawing.Point(29, 28);
            this.folder_text.Name = "folder_text";
            this.folder_text.Size = new System.Drawing.Size(550, 20);
            this.folder_text.TabIndex = 1;
            // 
            // list_of_filenames
            // 
            this.list_of_filenames.FormattingEnabled = true;
            this.list_of_filenames.Location = new System.Drawing.Point(29, 64);
            this.list_of_filenames.Name = "list_of_filenames";
            this.list_of_filenames.Size = new System.Drawing.Size(423, 563);
            this.list_of_filenames.TabIndex = 2;
            // 
            // list_items
            // 
            this.list_items.Location = new System.Drawing.Point(483, 93);
            this.list_items.Name = "list_items";
            this.list_items.Size = new System.Drawing.Size(85, 37);
            this.list_items.TabIndex = 3;
            this.list_items.Text = "List";
            this.list_items.UseVisualStyleBackColor = true;
            this.list_items.Click += new System.EventHandler(this.list_items_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(29, 633);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Datacount:";
            // 
            // countTextBox
            // 
            this.countTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.countTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countTextBox.Location = new System.Drawing.Point(127, 633);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(92, 22);
            this.countTextBox.TabIndex = 5;
            // 
            // RunAlgorithm_btn
            // 
            this.RunAlgorithm_btn.Location = new System.Drawing.Point(483, 136);
            this.RunAlgorithm_btn.Name = "RunAlgorithm_btn";
            this.RunAlgorithm_btn.Size = new System.Drawing.Size(85, 38);
            this.RunAlgorithm_btn.TabIndex = 6;
            this.RunAlgorithm_btn.Text = "Algorithm";
            this.RunAlgorithm_btn.UseVisualStyleBackColor = true;
            this.RunAlgorithm_btn.Click += new System.EventHandler(this.RunAlgorithm_btn_Click);
            // 
            // image_radioBtn
            // 
            this.image_radioBtn.AutoSize = true;
            this.image_radioBtn.Location = new System.Drawing.Point(498, 191);
            this.image_radioBtn.Name = "image_radioBtn";
            this.image_radioBtn.Size = new System.Drawing.Size(59, 17);
            this.image_radioBtn.TabIndex = 7;
            this.image_radioBtn.TabStop = true;
            this.image_radioBtn.Text = "Images";
            this.image_radioBtn.UseVisualStyleBackColor = true;
            this.image_radioBtn.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // video_radioBtn
            // 
            this.video_radioBtn.AutoSize = true;
            this.video_radioBtn.Location = new System.Drawing.Point(498, 214);
            this.video_radioBtn.Name = "video_radioBtn";
            this.video_radioBtn.Size = new System.Drawing.Size(57, 17);
            this.video_radioBtn.TabIndex = 8;
            this.video_radioBtn.TabStop = true;
            this.video_radioBtn.Text = "Videos";
            this.video_radioBtn.UseVisualStyleBackColor = true;
            this.video_radioBtn.CheckedChanged += new System.EventHandler(this.video_radioBtn_CheckedChanged);
            // 
            // hideDuplicates_chkbox
            // 
            this.hideDuplicates_chkbox.AutoSize = true;
            this.hideDuplicates_chkbox.Location = new System.Drawing.Point(488, 249);
            this.hideDuplicates_chkbox.Name = "hideDuplicates_chkbox";
            this.hideDuplicates_chkbox.Size = new System.Drawing.Size(99, 17);
            this.hideDuplicates_chkbox.TabIndex = 9;
            this.hideDuplicates_chkbox.Text = "Hide duplicates";
            this.hideDuplicates_chkbox.UseVisualStyleBackColor = true;
            this.hideDuplicates_chkbox.CheckedChanged += new System.EventHandler(this.hideDuplicates_chkbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 685);
            this.Controls.Add(this.hideDuplicates_chkbox);
            this.Controls.Add(this.video_radioBtn);
            this.Controls.Add(this.image_radioBtn);
            this.Controls.Add(this.RunAlgorithm_btn);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.list_items);
            this.Controls.Add(this.list_of_filenames);
            this.Controls.Add(this.folder_text);
            this.Controls.Add(this.search_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox folder_text;
        private System.Windows.Forms.ListBox list_of_filenames;
        private System.Windows.Forms.Button list_items;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Button RunAlgorithm_btn;
        private System.Windows.Forms.RadioButton image_radioBtn;
        private System.Windows.Forms.RadioButton video_radioBtn;
        private System.Windows.Forms.CheckBox hideDuplicates_chkbox;
    }
}

