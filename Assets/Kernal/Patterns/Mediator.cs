/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: Mediator
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: 
 */

namespace Kernal.Patterns
{
    /// <summary>
    /// ������ʾ����
    /// </summary>
    public class Mediator : KernalBase
    {
        public const string NAME = "Mediator";
        private string m_mediatorName = "";

        #region Constants
        public Mediator() : this("") { }
        public Mediator(string name)
        {
            this.m_mediatorName = string.IsNullOrEmpty(name) ? NAME : name;
        }
        #endregion


        #region Public
        /// <summary>
        /// ���ƣ��ɹ��캯������
        /// </summary>
        public string MediatorName { get { return m_mediatorName; } }
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