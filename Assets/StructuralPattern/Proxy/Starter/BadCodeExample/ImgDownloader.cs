using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DesignPattern.BadCode.Proxy
{
    public class ImgDownloader
    {
        private Dictionary<int, bool> downloadCache;
        private ImgDownloader()
        {
            downloadCache = new Dictionary<int, bool>();
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="id">图片id</param>
        /// <returns></returns>
        public bool DownLoadImg(int id)
        {
            bool downloaded = false;
            downloadCache.TryGetValue(id, out downloaded);
            if (downloaded)
            {
                // 已经下载过，无需重复下载
                return false;
            }
            //把id发给后端，等后端把文件流传回来，再把文件流写入相册
            return true;
        }
    }
}