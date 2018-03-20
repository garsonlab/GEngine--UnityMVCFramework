/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: InputBase
 * Date    : 2018/01/25
 * Version : v1.0
 * Describe: 
 */

using UnityEngine;

namespace GEngine.Managers
{
    public class InputBase
    {
        protected bool m_isTouchOnUI;
        protected TouchStatus m_touchStatus; //״̬
        protected Vector3 m_pointPos; //���λ��
        protected Vector3 m_curPos; //��ǰ���λ��
        protected Vector3 m_scaleDelata; //����λ�ñ���

        protected InputManager m_inputManager;//���������
        protected float m_longPressTimer; //������ʱ��
        protected float m_moveDis; //�ƶ�����

        public InputBase(InputManager manager)
        {
            m_inputManager = manager;
            Reset();
        }

        /// <summary>
        /// ֻ����InputManager���õĸ���
        /// </summary>
        public virtual void OnUpdate()
        {
            if (!m_inputManager.IsActive)
                return;

        }

        /// <summary>
        /// �����Ƿ����
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            if (!active)
                Reset();
        }

        /// <summary>
        /// �Ƿ�����UI��
        /// </summary>
        public bool IsTouchOnUI
        {
            get { return m_isTouchOnUI; }
        }


        /// <summary>
        /// ����״̬
        /// </summary>
        protected virtual void Reset()
        {
            m_isTouchOnUI = false;
            m_touchStatus = TouchStatus.None;
            m_longPressTimer = 0;
        }

        /// <summary>
        /// ��ʼ���
        /// </summary>
        /// <param name="pointPos"></param>
        protected virtual void OnTouchStart(Vector3 curPos)
        {
            m_touchStatus = TouchStatus.Touch;
            m_pointPos = curPos;
            m_curPos = curPos;
            m_longPressTimer = 0;

            m_inputManager.InvokeInput(InputType.OnTouchBegin, m_pointPos);
        }

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="pointPos"></param>
        protected virtual void OnTouch(Vector3 curPos)
        {
            m_longPressTimer += Time.deltaTime;
            m_curPos = curPos;

            if (m_touchStatus != TouchStatus.Moving)
            {
                m_moveDis = Vector2.Distance(m_pointPos, m_curPos);
                if (m_moveDis >= m_inputManager.m_moveTolerace)
                {
                    m_touchStatus = TouchStatus.Moving;
                    m_inputManager.InvokeInput(InputType.OnMoveBegin, m_curPos);
                }

                if (m_touchStatus == TouchStatus.Touch && m_longPressTimer >= m_inputManager.m_longPressSpan)
                {
                    m_touchStatus = TouchStatus.LongPress;
                    m_inputManager.InvokeInput(InputType.OnLongPress, m_curPos);
                }
            }
            else
            {
                m_inputManager.InvokeInput(InputType.OnMove, m_curPos);
            }
        }

        protected virtual void OnTouchEnd(Vector3 curPos)
        {
            m_curPos = curPos;

            if (m_touchStatus == TouchStatus.Moving)
                m_inputManager.InvokeInput(InputType.OnMoveEnd, m_curPos);
            if (m_touchStatus == TouchStatus.LongPress)
                m_inputManager.InvokeInput(InputType.OnEndLongPress, m_curPos);
            if (m_touchStatus == TouchStatus.Touch)
                m_inputManager.InvokeInput(InputType.OnClick, m_curPos);

            m_inputManager.InvokeInput(InputType.OnTouchEnd, m_curPos);

            m_touchStatus = TouchStatus.None;
            m_isTouchOnUI = false;
        }

        protected virtual void OnScale()
        {

        }

        protected virtual void CheckOnUI(int fingerId)
        {
            if (UnityEngine.EventSystems.EventSystem.current == null)
                return;
            if (fingerId < 0)
                m_isTouchOnUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            else
                m_isTouchOnUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(fingerId);
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        protected enum TouchStatus
        {
            /// <summary>
            /// ��״̬
            /// </summary>
            None,

            /// <summary>
            /// �ոհ���
            /// </summary>
            Touch,

            /// <summary>
            /// ����
            /// </summary>
            LongPress,

            /// <summary>
            /// �ƶ�
            /// </summary>
            Moving,
        }
    }
}