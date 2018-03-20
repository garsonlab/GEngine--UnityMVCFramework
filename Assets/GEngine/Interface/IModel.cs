/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: IModel
 * Date    : 2018/01/04
 * Version : v1.0
 * Describe: 
 */

using GEngine.Patterns;

namespace GEngine.Interface
{
    public interface IModel
    {
        /// <summary>
        /// ע��Proxy
        /// </summary>
        /// <param name="proxy"></param>
        void RegisterProxy(Proxy proxy);
        /// <summary>
        /// ��ȡProxy
        /// </summary>
        /// <param name="proxyName">����</param>
        /// <returns></returns>
        T RetrieveProxy<T>(string proxyName) where T : Proxy;
        /// <summary>
        /// �Ƴ�
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        T RemoveProxy<T>(string proxyName) where T : Proxy;
        /// <summary>
        /// �Ƿ��Ѵ���
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        bool HasProxy(string proxyName);
    }
}
