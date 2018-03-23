/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: GameObjectPool
 * Date    : 2018/03/21
 * Version : v1.0
 * Describe: 
 */

using UnityEngine;

namespace GEngine
{
    /// <summary>
    /// GameObject �����
    /// </summary>
    public class GameObjectPool
    {
        #region Members
        private ObjectPool<GameObject> m_pool; 
        private string m_name;
        private GameObject m_prefab;
        private int m_maxSize;
        private Transform m_root;
        private bool m_createdRoot;
        #endregion

        #region Public Methods
        /// <summary>
        /// ���캯����GameObject�����
        /// </summary>
        /// <param name="name">���������</param>
        /// <param name="prefab">Ԥ���壬��Ϊĸ�帴��</param>
        /// <param name="maxSize">�����������</param>
        /// <param name="root">������ڵ�</param>
        public GameObjectPool(string name, GameObject prefab, int maxSize = int.MaxValue, Transform root = null)
        {
            m_pool = new ObjectPool<GameObject>(Creater, Getter, Releaser, Clearer);
            m_name = name;
            m_prefab = prefab;
            m_maxSize = maxSize;
            CreateRoot();
        }

        /// <summary>
        /// ��ȡ
        /// </summary>
        /// <returns></returns>
        public GameObject Get()
        {
            if (m_pool.countAll >= m_maxSize && m_pool.countInactive <= 0)
            {
                GLog.E(string.Format("{0} Pool has reached the Maximum.", m_name));
                return null;
            }

            if (m_pool.countInactive > 0)
            {
                return m_pool.Get();
            }


            if (m_prefab == null)
            {
                GLog.E(string.Format("{0} Pool 's prefab has been destroyed.", m_name));
                return null;
            }

            return m_pool.Get();
        }
        /// <summary>
        /// �ͷ�
        /// </summary>
        /// <param name="name">���������</param>
        /// <param name="obj">����</param>
        public void Release(string name, GameObject obj)
        {
            if (!m_name.Equals(name))
            {
                GLog.E(string.Format("Release Error: Name {0} is not equal to the pool 's name."));
                return;
            }
            m_pool.Release(obj);
        }
        /// <summary>
        /// ��ջ����
        /// </summary>
        public void Clear()
        {
            m_pool.Clear();
            if(m_createdRoot)
                GameObject.Destroy(m_root);
        }
        #endregion

        #region Accessors
        public string name { get { return m_name;} }
        public int countAll { get { return m_pool.countAll; } }
        public int countActive { get { return m_pool.countActive; } }
        public int countInactive { get { return m_pool.countInactive; } }
        public int maxSize { get { return m_maxSize; } set { m_maxSize = value; } }
        public GameObject prefab { get { return m_prefab; } set { m_prefab = value; } }
        #endregion

        #region Private ObjectPool Methods
        private GameObject Creater()
        {
            var obj = GameObject.Instantiate(m_prefab);
            if(m_root == null)
                CreateRoot();
            obj.transform.SetParent(m_root);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
            return obj;
        }

        private void Getter(GameObject obj)
        {
            obj.SetActive(true);
        }

        private void Releaser(GameObject obj)
        {
            if(m_root == null)
                CreateRoot();
            obj.transform.SetParent(m_root);
            obj.SetActive(false);
        }

        private void Clearer(GameObject obj)
        {
            GameObject.Destroy(obj);
        }
        private void CreateRoot()
        {
            if (m_root == null)
            {
                GameObject obj = new GameObject(m_name + "_Pool");
                m_root = obj.transform;
                m_createdRoot = true;
            }
        }
        #endregion

    }
}
