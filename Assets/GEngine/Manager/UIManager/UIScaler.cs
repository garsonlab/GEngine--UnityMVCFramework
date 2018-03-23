/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: UIScaler
 * Date    : 2018/03/14
 * Version : v1.0
 * Describe: 
 */

using UnityEngine;

namespace GEngine.Managers
{
    /// <summary>
    /// ��ȫ������ģʽ
    /// </summary>
    public enum ScaleMode
    {
        /// <summary>
        /// ƥ����
        /// </summary>
        MatchWidth = 1,
        /// <summary>
        /// ƥ��߶�
        /// </summary>
        MatchHeight
    }

    /// <summary>
    /// ���䷽��
    /// </summary>
    public enum AdaptPolicy
    {
        TopLeft = 0,
        TopCenter = 1,
        TopRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        BottomLeft = 6,
        BottomCenter = 7,
        BottomRight = 8,
    }


    /// <summary>
    /// UI����������
    /// </summary>
    public class UIScaler
    {
        public static ScaleMode scaleMode = ScaleMode.MatchWidth;
        private static float m_scaleX;
        private static float m_scaleY;
        private static float m_scaleM;

        /// <summary>
        /// �����������
        /// </summary>
        public static void ResetScaler()
        {
            m_scaleX = Screen.width/Config.DesignWidth;
            m_scaleY = Screen.height/Config.DesignHeight;
            m_scaleM = m_scaleX >= m_scaleY ? m_scaleX : m_scaleY;
        }

        /// <summary>
        /// �����Ļ�������ţ����޸�ê��Ϊ���ģ�
        /// </summary>
        /// <param name="policy">�������</param>
        /// <param name="transform">����Ŀ��</param>
        /// <param name="isStretch">�Ƿ�����, ָ��������ű���</param>
        public static void Rescale(AdaptPolicy policy, RectTransform transform, bool isStretch = false)
        {
            float scale = isStretch ? m_scaleM : (scaleMode == ScaleMode.MatchWidth ? m_scaleX : m_scaleY);
            transform.localScale = Vector3.one*scale;

            transform.anchorMin = Vector2.one*0.5f;
            transform.anchorMax = Vector2.one*0.5f;
            switch (policy)
            {
                case AdaptPolicy.TopLeft:
                    transform.localPosition = new Vector3(-Screen.width*0.5f + transform.sizeDelta.x*scale*0.5f,
                        Screen.height*0.5f - transform.sizeDelta.y*scale*0.5f, 0);
                    break;
                case AdaptPolicy.TopCenter:
                    transform.localPosition = new Vector3(0, Screen.height*0.5f - transform.sizeDelta.y*scale*0.5f, 0);
                    break;
                case AdaptPolicy.TopRight:
                    transform.localPosition = new Vector3(Screen.width*0.5f - transform.sizeDelta.x*scale*0.5f,
                        Screen.height*0.5f - transform.sizeDelta.y*scale*0.5f, 0);
                    break;
                case AdaptPolicy.MiddleLeft:
                    transform.localPosition = new Vector3(-Screen.width*0.5f + transform.sizeDelta.x*scale*0.5f, 0, 0);
                    break;
                case AdaptPolicy.MiddleCenter:
                    transform.localPosition = Vector3.zero;
                    break;
                case AdaptPolicy.MiddleRight:
                    transform.localPosition = new Vector3(Screen.width*0.5f - transform.sizeDelta.x*scale*0.5f, 0, 0);
                    break;
                case AdaptPolicy.BottomLeft:
                    transform.localPosition = new Vector3(-Screen.width*0.5f + transform.sizeDelta.x*scale*0.5f,
                        -Screen.height*0.5f + transform.sizeDelta.y*scale*0.5f, 0);
                    break;
                case AdaptPolicy.BottomCenter:
                    transform.localPosition = new Vector3(0, -Screen.height*0.5f + transform.sizeDelta.y*scale*0.5f, 0);
                    break;
                case AdaptPolicy.BottomRight:
                    transform.localPosition = new Vector3(Screen.width*0.5f - transform.sizeDelta.x*scale*0.5f,
                        -Screen.height*0.5f + transform.sizeDelta.y*scale*0.5f, 0);
                    break;
            }
        }


        /// <summary>
        /// ��Թ����������λ�ã����޸�ê��Ϊ���ģ�
        /// </summary>
        /// <param name="target">����Ŀ��</param>
        /// <param name="relative">����Ŀ��</param>
        /// <param name="policy">�������</param>
        public static void SetRelativePos(RectTransform target, RectTransform relative, AdaptPolicy policy)
        {
            Vector2 pos = target.anchoredPosition;

            Vector2 p_middle = relative.sizeDelta * 0.5f;
            p_middle.x = p_middle.x * relative.localScale.x; p_middle.y = p_middle.y * relative.localScale.y;//���ǵ�����
            Vector2 s_middle = target.sizeDelta * 0.5f;
            s_middle.x = s_middle.x * target.localScale.x; s_middle.y = s_middle.y * target.localScale.y;

            target.anchorMax = Vector2.one * 0.5f;//����ê��λ��Ϊ����
            target.anchorMin = Vector2.one * 0.5f;
            target.anchoredPosition = Vector2.zero;//����UIλ��Ϊ����

            switch (policy)
            {
                case AdaptPolicy.TopLeft:
                    pos.x = -(p_middle.x - s_middle.x);
                    pos.y = (p_middle.y - s_middle.y);
                    break;
                case AdaptPolicy.TopCenter:
                    pos.x = 0;
                    pos.y = (p_middle.y - s_middle.y);
                    break;
                case AdaptPolicy.TopRight:
                    pos.x = (p_middle.x - s_middle.x);
                    pos.y = (p_middle.y - s_middle.y);
                    break;
                case AdaptPolicy.MiddleLeft:
                    pos.x = -(p_middle.x - s_middle.x);
                    pos.y = 0;
                    break;
                case AdaptPolicy.MiddleCenter:
                    pos.x = 0;
                    pos.y = 0;
                    break;
                case AdaptPolicy.MiddleRight:
                    pos.x = (p_middle.x - s_middle.x);
                    pos.y = 0;
                    break;
                case AdaptPolicy.BottomLeft:
                    pos.x = -(p_middle.x - s_middle.x);
                    pos.y = -(p_middle.y - s_middle.y);
                    break;
                case AdaptPolicy.BottomCenter:
                    pos.x = 0;
                    pos.y = -(p_middle.y - s_middle.y);
                    break;
                case AdaptPolicy.BottomRight:
                    pos.x = (p_middle.x - s_middle.x);
                    pos.y = -(p_middle.y - s_middle.y);
                    break;
            }
            target.anchoredPosition = pos;
        }

    }
}
