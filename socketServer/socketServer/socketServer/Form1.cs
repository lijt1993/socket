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

namespace socketServer
{
    public partial class socketServer : Form
    {
        public socketServer()
        {
            InitializeComponent();
        }

        private void btn_Listen_Click(object sender, EventArgs e)
        {
            //ip地址
            IPAddress ip = IPAddress.Parse(textIP.Text);

            //端口号
            IPEndPoint point = new IPEndPoint(ip, int.Parse(textPort.Text));

            //使用IPv4地址，流式socket方式,tcp协议传递数据
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //socket监听哪个端口
                socket.Bind(point);

                //同一个时间点过来10个客户端，排队
                socket.Listen(10);
                ShowMsg("服务器开始监听");
                Control.CheckForIllegalCrossThreadCalls = false;
                Thread thread = new Thread(AcceptInfo);

                thread.IsBackground = true;
                thread.Start(socket);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        void ShowMsg(string msg)
        {
            textLog.AppendText(msg + "\r\n");
        }

        //记录通信用的Socket

        Dictionary<string, Socket> dic = new Dictionary<string, Socket>();

        void AcceptInfo(object o)
        {
            Socket socket = o as Socket;

            while (true)
            {
                //通信用socket
                try
                {
                    //创建通信用的Socket
                    Socket tSocket = socket.Accept();
                    string point = tSocket.RemoteEndPoint.ToString();
                    ShowMsg(point + "连接成功！");
                    comboBox1.Items.Add(point);
                    dic.Add(point, tSocket);

                    //接收消息
                    Thread th = new Thread(ReceiveMsg);
                    th.IsBackground = true;
                    th.Start(tSocket);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        //接收消息
        void ReceiveMsg(object o)
        {
            Socket client = o as Socket;

            while (true)
            {
                //接收客户端发送过来的数据
                try
                {
                    //定义byte数组存放从客户端接收过来的数据
                    byte[] buffer = new byte[1024 * 1024];

                    //将接收过来的数据放到buffer中，并返回实际接受数据的长度
                    int n = client.Receive(buffer);

                    //将字节转换成字符串
                    string words = Encoding.UTF8.GetString(buffer, 0, n);

                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + words);
                }
                catch (Exception ex)
                {

                    ShowMsg(ex.Message);
                    break;
                }

            }

        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //给客户端发送消息
        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMsg(textMsg.Text);
                string ip = comboBox1.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(textMsg.Text);
                dic[ip].Send(buffer);
            }
            catch (Exception ex)
            {

                ShowMsg(ex.Message);
            }

        }

    }
}
