/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: IPanel
 * Date    : 2018/03/10
 * Version : v1.0
 * Describe: 
 */

namespace GEngine.Managers
{
    public enum PanelType
    {
        HUD = 0,
        Normal = 1,
        Fixed = 2,
        PopUp = 3,
        None = 4,
    }

    public enum PanelMode
    {
        DoNothing,
        HideOthers,
        HideSameLayer,
    }

    /// <summary>
    /// UI���ط�ʽ
    /// </summary>
    public enum PanelLoad
    {
        Load = 0,//ͬ��
        SyncLoad = 1,//�첽
    }

    /// <summary>
    /// ���״̬
    /// </summary>
    public enum PanelState
    {
        None,//�ճ�ʼ��
        Loading,//���ڼ�����
        Showing,//������ʾ
        Close,//�ѹر�
        Destroy,//������
    }

    public interface IPanel
    {
        /// <summary>
        /// ��ǰ���״̬
        /// </summary>
        PanelState PanelState { get; }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="parm">����</param>
        /// <param name="callback">�ص�</param>
        void Show(object parm = null, Callback_0 callback = null);
        /// <summary>
        /// ���ػ�
        /// </summary>
        void Localize();
        //void Init();
        /// <summary>
        /// UI����
        /// </summary>
        void Resize();
        /// <summary>
        /// �رս���
        /// </summary>
        /// <param name="callback"></param>
        void Close();
        /// <summary>
        /// ����
        /// </summary>
        void Destroy();
    }
}