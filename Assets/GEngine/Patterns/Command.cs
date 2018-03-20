/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: Command
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: 
 */

namespace GEngine.Patterns
{
    /// <summary>
    /// �������㴦��
    /// </summary>
    public class Command : KernalBase
    {
        public const string NAME = "Command";
        private string m_name = "";

        #region Constants
        public Command() : this("") { }
        public Command(string name)
        {
            this.m_name = string.IsNullOrEmpty(name) ? NAME : m_name;
        }
        #endregion

        #region Public
        /// <summary>
        /// ���ƣ��ɹ��캯������
        /// </summary>
        public string CommandName { get { return m_name; } }
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
