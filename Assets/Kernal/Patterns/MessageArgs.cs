/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: MessageArgs
 * Date    : 2018/01/04
 * Version : v1.0
 * Describe: 
 */

namespace Kernal.Patterns
{
    public class MessageArgs
    {
        #region Members
        private int m_type;
        private object m_body;
        private object m_sender;
        #endregion

        #region Constructors
        public MessageArgs(int type) : this(type, null, null) { }
        public MessageArgs(int type, object body) : this(type, body, null) { }
        public MessageArgs(int type, object body, object sender)
        {
            this.m_type = type;
            this.m_body = body;
            this.m_sender = sender;
        }
        #endregion

        #region Public
        /// <summary>
        /// ��Ϣ������
        /// </summary>
        public int Type { get { return m_type; }}
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public object Body { get { return m_body; }}
        /// <summary>
        /// ������
        /// </summary>
        public object Sender { get { return m_sender; } }

        public override string ToString()
        {
            string msg = "Message Type: " + m_type;
            msg += "\nBody:" + (Body ?? "null");
            msg += "\nSender:" + (Sender ?? "null");
            return msg;
        }
        #endregion
    }
}
