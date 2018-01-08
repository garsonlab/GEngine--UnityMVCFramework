/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: Manager
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: 
 */

using Kernal.Core;
using Kernal.Managers;

namespace Kernal.Patterns
{
    public class Manager
    {
        /// <summary>
        /// ���ƣ����������า��
        /// </summary>
        public const string NAME = "Manager";

        /// <summary>
        /// �ձ�ע��ʱ����
        /// </summary>
        public virtual void OnRegister() { }
        /// <summary>
        /// �Ƴ�ʱ����
        /// </summary>
        public virtual void OnRemove() { }




        #region Members

        private TimerManager m_timerManager;

        #endregion

        #region Accessors

        public TimerManager TimerManager
        {
            get
            {
                if (m_timerManager == null)
                    m_timerManager = Facade.Instance.RetrieveManager<TimerManager>(TimerManager.NAME);
                return m_timerManager;
            }
        }

        #endregion
    }
}