/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: ITimer
 * Date    : 2018/01/05
 * Version : v1.0
 * Describe: 
 */

namespace GEngine.Managers
{
    public interface ITimer
    {
        /// <summary>
        /// ��ʱ����
        /// </summary>
        /// <param name="delay">�ӳ�ʱ��</param>
        /// <param name="handler">�ص�����</param>
        /// <param name="parm">�ص�����</param>
        /// <returns></returns>
        TimerData DelayCall(float delay, TimerHandler handler, object parm = null);
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="times">���ô�����-1��ʾ�޾�ѭ������</param>
        /// <param name="interval">���ü��</param>
        /// <param name="handler">�ص�����</param>
        /// <param name="parm">�ص�����</param>
        /// <returns></returns>
        TimerData IntervalCall(int times, float interval, TimerHandler handler, object parm = null);
        /// <summary>
        /// ��ʱ����ص�
        /// </summary>
        /// <param name="times">���ô�����-1��ʾ�޾�ѭ������</param>
        /// <param name="delay">�ӳ�ʱ��</param>
        /// <param name="interval">���ü��</param>
        /// <param name="handler">�ص�����</param>
        /// <param name="parm">�ص�����</param>
        /// <returns></returns>
        TimerData IntervalDelayCall(int times, float delay, float interval, TimerHandler handler, object parm = null);
        /// <summary>
        /// �ظ�����
        /// </summary>
        /// <param name="times">���ô�����-1��ʾ�޾�ѭ������</param>
        /// <param name="delay">�ӳ�ʱ��</param>
        /// <param name="interval">���ü��</param>
        /// <param name="ignoreTimeScale">�Ƿ����ʱ������</param>
        /// <param name="handler">�ص�����</param>
        /// <param name="parm">�ص�����</param>
        /// <returns></returns>
        TimerData RepeatedCall(int times, float delay, float interval, bool ignoreTimeScale, TimerHandler handler, object parm = null);
        /// <summary>
        /// ������ͣ
        /// </summary>
        /// <param name="timerId">�ص�id</param>
        /// <param name="pause">�Ƿ���ͣ</param>
        void SetPause(uint timerId, bool pause);
        /// <summary>
        /// ȡ���ص�
        /// </summary>
        /// <param name="timerId">�ص�id</param>
        void CancelCallback(uint timerId);
        /// <summary>
        /// ��ȡ��ʱ������
        /// </summary>
        /// <param name="timerId">�ص�id</param>
        /// <returns></returns>
        TimerData GetTimerData(uint timerId);
    }
}