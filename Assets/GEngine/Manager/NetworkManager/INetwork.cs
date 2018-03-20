/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: INetwork
 * Date    : 2018/03/07
 * Version : v1.0
 * Describe: 
 */

using System.Net.Sockets;

namespace GEngine.Managers
{
    public enum ChannelType
    {
        Auth, //��֤��
        Zone, //����
        Battle, //ս����
        Span, //���
        Log,//log
    }

    public enum SocketState
    {
        /// <summary>
        /// ��״̬
        /// </summary>
        None = 0,
        /// <summary>
        /// ������
        /// </summary>
        Connecting,
        /// <summary>
        /// ������
        /// </summary>
        Connected,
        /// <summary>
        /// ����ʧ��/�����ж�
        /// </summary>
        BreakOff,
        /// <summary>
        /// �Ͽ�
        /// </summary>
        Dispose
    }

    public interface INetwork
    {
        /// <summary>
        /// ��ǰ����ͨ��
        /// </summary>
        ChannelType ChannelType { get; }
        /// <summary>
        /// Socket����
        /// </summary>
        SocketType SocketType { get; }
        /// <summary>
        /// ��������
        /// </summary>
        ProtocolType ProtocolType { get; }
        /// <summary>
        /// ���ջ����С
        /// </summary>
        uint BufferSize { get; set; }
        /// <summary>
        /// ��ʱ
        /// </summary>
        int Timeout { get; set; }
        /// <summary>
        /// �Ƿ�������
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// ��ǰ����״̬
        /// </summary>
        SocketState State { get; }
        /// <summary>
        /// ��������
        /// </summary>
        long SendLength { get; }
        /// <summary>
        /// ��������
        /// </summary>
        long ReceiveLength { get; }
        /// <summary>
        /// ��������
        /// </summary>
        long NetUsage { get; }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        void Connect(string ip, int port);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="bytes"></param>
        void Send(byte[] bytes);
        /// <summary>
        /// �Ͽ�
        /// </summary>
        void Close();
        /// <summary>
        /// ״̬�仯
        /// </summary>
        /// <param name="state"></param>
        void OnStateChanged(SocketState state);
        /// <summary>
        /// ��ȡ��Ϣ
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msgBytes"></param>
        /// <returns></returns>
        bool PopMessage(ref int msgType, out byte[] msgBytes);
    }
}