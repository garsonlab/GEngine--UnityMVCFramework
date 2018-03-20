/*
 * GEngine Framework for Unity By Garson(https://github.com/garsonlab)
 * -------------------------------------------------------------------
 * FileName: WebRequestAgent
 * Date    : 2018/03/15
 * Version : v1.0
 * Describe: ʹ��HttpЭ�飬֧�ֶϵ����������Ƿ������bundle��С�Ļ�����
 *              ������һ���������Ѷϵ�������Ϊbundle��������������ֻҪ���bundle
 *              û������ʹ������0�ֽڿ�ʼ��Ҳ���˷��������ܸ��õİ汾���ơ�
 *              �ֽڵĶϵ�������Ҫ�ļ�ͬ�������ð汾���ƣ���Ҫ��һ���ļ���¼���ơ�
 *              
 * ���ڿ��Կ��� WWW �� WebClient
 */

using System;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;

namespace GEngine.Managers
{
    /// <summary>
    /// HTTP�����������
    /// </summary>
    public class WebRequestAgent
    {

        public Callback_0 onDownloadSuccess;
        public Callback_0 onDownloadFailed;

        private long m_downLength;
        private long m_totalLength;
        private byte[] m_buffer;
        private bool m_isDone;

        public long Downloaded {get{return m_downLength;} }
        public string DownloadedStr { get { return FileManager.ByteConvert(m_downLength); } }
        public long Total { get { return m_totalLength; } }
        public string TotalStr { get; private set; }
        public float Progress { 
            get 
            { 
                if (m_totalLength == 0) 
                    return 0;
                return m_downLength*0.1f/m_totalLength;
            } 
        }
        public bool IsDone { get { return m_isDone;} }


        public WebRequestAgent()
        {
            m_buffer = new byte[1024*32];
        }
       
        public IEnumerator Download(string url, string savePath, long length)
        {
            m_totalLength = length;
            TotalStr = FileManager.ByteConvert(length);
            m_downLength = 0;
            m_isDone = false;
            
            string folder = savePath.Replace(Path.GetFileName(savePath), "");
            if (Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write);
            m_downLength = fileStream.Length;
            fileStream.Seek(m_downLength, SeekOrigin.Begin);

            HttpWebRequest request = HttpWebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.Timeout = 5*1000;
            request.ReadWriteTimeout = 3*1000;
            request.AddRange((int)m_downLength);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            int readLen = stream.Read(m_buffer, 0, m_buffer.Length);
            while (readLen > 0)
            {
                fileStream.Write(m_buffer, 0, readLen);
                m_downLength += readLen;
                //if(m_downLength > 0)
                //    break;
                readLen = stream.Read(m_buffer, 0, m_buffer.Length);
                yield return false;
            }
            
            response.Close();
            stream.Close();
            fileStream.Close();

            if (m_downLength >= m_totalLength)
            {
                m_isDone = true;
                if (onDownloadSuccess != null)
                    onDownloadSuccess();
            }
            else
            {
                if (onDownloadFailed != null)
                    onDownloadFailed();
            }
        }

        public long GetLength(string url)
        {
            HttpWebRequest requet = HttpWebRequest.Create(url) as HttpWebRequest;
            requet.Method = "HEAD";
            HttpWebResponse response = requet.GetResponse() as HttpWebResponse;
            return response.ContentLength;
        }


        public IEnumerator WWWDownload(string url, Callback_1<byte[]> onSuccess)
        {
            WWW www = new WWW(url);
            yield return www;
            if (www.isDone)
            {
                if (onSuccess != null)
                    onSuccess(www.bytes);
            }
            else
            {
                if (onSuccess != null)
                    onSuccess(null);
            }
            www.Dispose();
        }
    }
}