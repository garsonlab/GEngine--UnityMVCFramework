/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: MessageData
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: 
 */

using System;
using Kernal.Patterns;

namespace Kernal.Managers
{
    public class MessageData : IComparable<MessageData>
    {
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// ���ȼ�����ֵԽ�����ȼ�Խ��
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// ��Ϣ�ص�
        /// </summary>
        public MessageHandler Handler { get; set; }

        public void Invoke(MessageArgs args)
        {
            if (Handler != null)
                Handler(args);
        }

        public int CompareTo(MessageData other)
        {
            if (Priority > other.Priority)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public bool EqualTo(int type)
        {
            return type == Type;
        }

        public bool EqualTo(MessageHandler handler)
        {
            return handler == Handler;
        }

        public bool EqualTo(int type, MessageHandler hander)
        {
            return type == Type && hander == Handler;
        }
    }
}
