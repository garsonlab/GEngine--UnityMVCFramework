/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: VersionMediator
 * Date    : 2018/03/16
 * Version : v1.0
 * Describe: 
 */

using GEngine.Patterns;

namespace GEngine.Modules
{
    public class VersionMediator : Mediator
    {
        public new const string NAME = "VersionMediator";

        public VersionMediator() : base(NAME) { }



        internal void ShowNewVersion(Callback_0 downloadNewVersion)
        {
            //չʾ�Ի�������, ��ʾnetwork�е�wifi״̬
            downloadNewVersion();
        }

        internal void ShowNewResources(Callback_0 DownloadNewResources)
        {
            //��������Դ
        }

        internal void ShowNetBreak(Callback_1<MessageArgs> CheckVeison)
        {
            //��ʾ���粻����
            CheckVeison(null);
        }
    }
}