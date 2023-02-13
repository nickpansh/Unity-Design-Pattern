using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DesignPattern.Proxy
{
    public class ProxyStarter : MonoBehaviour
    {

        void Start()
        {
            // 示例代码
            IDownloader downloader = new DownloadCacher();
            downloader.DownloadImg(1);
        }
    }
}