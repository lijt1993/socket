namespace socketClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.textMsg = new System.Windows.Forms.TextBox();
            this.btn_Connect_Click = new System.Windows.Forms.Button();
            this.btn_Send_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(41, 34);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(198, 21);
            this.textIP.TabIndex = 0;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(288, 34);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(84, 21);
            this.textPort.TabIndex = 1;
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(41, 114);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(331, 71);
            this.textLog.TabIndex = 2;
            this.textLog.TextChanged += new System.EventHandler(this.textLog_TextChanged);
            // 
            // textMsg
            // 
            this.textMsg.Location = new System.Drawing.Point(41, 231);
            this.textMsg.Multiline = true;
            this.textMsg.Name = "textMsg";
            this.textMsg.Size = new System.Drawing.Size(331, 85);
            this.textMsg.TabIndex = 3;
            // 
            // btn_Connect_Click
            // 
            this.btn_Connect_Click.Location = new System.Drawing.Point(470, 49);
            this.btn_Connect_Click.Name = "btn_Connect_Click";
            this.btn_Connect_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect_Click.TabIndex = 4;
            this.btn_Connect_Click.Text = "连接";
            this.btn_Connect_Click.UseVisualStyleBackColor = true;
            this.btn_Connect_Click.Click += new System.EventHandler(this.btn_Connect_Click_Click);
            // 
            // btn_Send_Click
            // 
            this.btn_Send_Click.Location = new System.Drawing.Point(462, 359);
            this.btn_Send_Click.Name = "btn_Send_Click";
            this.btn_Send_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Send_Click.TabIndex = 5;
            this.btn_Send_Click.Text = "发送消息";
            this.btn_Send_Click.UseVisualStyleBackColor = true;
            this.btn_Send_Click.Click += new System.EventHandler(this.btn_Send_Click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 396);
            this.Controls.Add(this.btn_Send_Click);
            this.Controls.Add(this.btn_Connect_Click);
            this.Controls.Add(this.textMsg);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.TextBox textMsg;
        private System.Windows.Forms.Button btn_Connect_Click;
        private System.Windows.Forms.Button btn_Send_Click;
    }
}

