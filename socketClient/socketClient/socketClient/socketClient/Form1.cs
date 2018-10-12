using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textLog_TextChanged(object sender, EventArgs e)
        {

        }


        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private void btn_Connect_Click_Click(object sender, EventArgs e)
        {
            //连接到的目标ip
            IPAddress ip = IPAddress.Parse(textIP.Text);

            //连接到目标IP的哪个应用(端口号！)
            IPEndPoint point = new IPEndPoint(ip, int.Parse(textPort.Text));

            try
            {
                //连接到服务器
                client.Connect(point);
                ShowMsg("连接成功");
                ShowMsg("服务器" + client.RemoteEndPoint.ToString());
                ShowMsg("客户端:" + client.LocalEndPoint.ToString());
                Control.CheckForIllegalCrossThreadCalls = false;
                //连接成功后，就可以接收服务器发送的信息了
                Thread th = new Thread(ReceiveMsg);
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                
               ShowMsg(ex.Message);
            }

        }


         void ShowMsg(string msg)
 
        {
             textLog.AppendText(msg+"\r\n");
        }

        //接收服务器的消息
         void ReceiveMsg()
         {
             while (true)
             {

                 try
                 {

                     byte[] buffer = new byte[1024 * 1024];
                     int n = client.Receive(buffer);
                     string s = Encoding.UTF8.GetString(buffer, 0, n);
                     ShowMsg(client.RemoteEndPoint.ToString() + ":" + s);

                 }
                 catch (Exception ex)
                 {
                     
                     ShowMsg(ex.Message);
                     break;
                 }
             
             }
         
         
         
         }

         private void btn_Send_Click_Click(object sender, EventArgs e)
         {
             //客户端给服务器发消息
             if (client != null)
             {
                 try
                 {
                      ShowMsg(textMsg.Text);

                      byte[] buffer = Encoding.UTF8.GetBytes(textMsg.Text);

                      client.Send(buffer);
                 }
                 catch (Exception ex)
                 {
                     
                     ShowMsg(ex.Message);
                 }
             
             }
         }


 
    }
}
