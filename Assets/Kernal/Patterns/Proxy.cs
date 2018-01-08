/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: Proxy
 * Date    : 2018/01/04
 * Version : v1.0
 * Describe: 
 */

namespace Kernal.Patterns
{
    /// <summary>
    /// ���ݹ���
    /// </summary>
    public class Proxy : KernalBase
    {
        public const string NAME = "Proxy";
        private string m_proxyName = "";

        #region Constructors
        public Proxy() : this("") { }
        public Proxy(string name)
        {
            m_proxyName = string.IsNullOrEmpty(name) ? NAME : name;
        }
        #endregion

        #region Public
        /// <summary>
        /// ���ƣ��ɹ��캯������
        /// </summary>
        public string ProxyName {get { return m_proxyName;}}
        /// <summary>
        /// �ձ�ע��ʱ����
        /// </summary>
        public virtual void OnRegister() { }
        /// <summary>
        /// �Ƴ�ʱ����
        /// </summary>
        public virtual void OnRemove() { }

        #endregion


    }
}