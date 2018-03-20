/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: Panel
 * Date    : 2018/03/10
 * Version : v1.0
 * Describe: 
 */

using UnityEngine;

namespace GEngine.Managers
{
    /// <summary>
    /// ������
    /// </summary>
    public abstract class Panel : IPanel
    {
        private PanelState m_panelState;
        private UIManager m_manager;

        public string name;
        public PanelType panelType;
        public PanelMode panelMode;
        public PanelLoad panelLoad;

        public string assetPath;
        public GameObject gameObject;
        public Transform transform;

        public PanelState PanelState { get { return m_panelState; } }
        public Panel() : this(PanelType.Normal, PanelMode.DoNothing, PanelLoad.SyncLoad) { }

        public Panel(PanelType type, PanelMode mode, PanelLoad load)
        {
            this.m_manager = UIManager.Instance;
            this.panelType = type;
            this.panelMode = mode;
            this.panelLoad = load;
            this.name = this.GetType().ToString();
            this.m_panelState = PanelState.None;
        }

        public virtual void Show(object parm = null, Callback_0 callback = null)
        {
            if (gameObject == null && !string.IsNullOrEmpty(assetPath))
            {
                m_panelState = PanelState.Loading;
                Object obj = null;
                if (panelLoad == PanelLoad.Load)
                {
                    obj = ResourceManager.Instance.LoadAsset(assetPath);
                    OnLoadEnd(obj, parm, callback);
                    return;
                }
                else
                {
                    ResourceManager.Instance.LoadAssetSync(assetPath, o =>
                    {
                        obj = o;
                        OnLoadEnd(obj, parm, callback);
                    });
                }
            }

            if (m_panelState != PanelState.None || m_panelState != PanelState.Loading)
            {
                OnShow(parm);
                if (callback != null)
                    callback();
            }
        }
        /// <summary>
        /// ��ʼ�������Ϣ
        /// </summary>
        protected virtual void Init()
        {
            
        }

        public virtual void Localize()
        {
            
        }

        public void Resize()
        {
            
        }
        /// <summary>
        /// ��ʾ�����Ŷ�Ч
        /// </summary>
        /// <param name="parm"></param>
        protected virtual void OnShow(object parm)
        {
            
        }

        public virtual void Close()
        {
            if (gameObject != null)
            {
                OnClose();
            }
            else
            {
                m_panelState = PanelState.Close;
            }
        }
        /// <summary>
        /// �رչ��̣�������Ч
        /// </summary>
        /// <param name="callback"></param>
        protected virtual void OnClose()
        {
            gameObject.SetActive(false);
            m_panelState = PanelState.Close;
        }


        public virtual void Destroy()
        {
            if (gameObject != null)
            {
                OnDestroy();
            }
            else
            {
                m_panelState = PanelState.Destroy;
            }
        }
        /// <summary>
        /// ���ٹ��̣��ر���������
        /// </summary>
        private void OnDestroy()
        {
            m_panelState = PanelState.Destroy;
            GameObject.Destroy(gameObject);
            ResourceManager.Instance.Unload(assetPath, true);
        }

        //���ؽ���
        private void OnLoadEnd(Object obj, object parm, Callback_0 callback)
        {
            if (m_panelState == PanelState.Destroy)//�մ򿪾�Ҫ����
            {
                
            }

            if (obj == null)
            {
                GLog.E("Load UI Error:: file: " + name + ", assetPath: " + assetPath);
                m_panelState = PanelState.Showing;
                if (callback != null)
                    callback();
            }
            else
            {
                gameObject = GameObject.Instantiate(obj) as GameObject;
                transform = gameObject.transform;
                transform.SetParent(GetParent());
                transform.localPosition = Vector3.zero;

                Init();
                Localize();
                Resize();
                OnShow(parm);
                m_panelState = PanelState.Showing;
                if (callback != null)
                    callback();
            }
        }


        protected Transform GetParent()
        {
            switch (panelType)
            {
                case PanelType.HUD:
                    return m_manager.hudRoot;
                case PanelType.Fixed:
                    return m_manager.fixedRoot;
                case PanelType.Normal:
                    return m_manager.normalRoot;
                case PanelType.PopUp:
                    return m_manager.popupRoot;
                case PanelType.None:
                    return m_manager.uiRoot;
            }
            return null;
        }

    }
}