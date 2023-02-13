using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DesignPattern.Proxy
{
    public class ImgDownloader : IDownloader
    {

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="id">图片id</param>
        /// <returns></returns>
        public bool DownloadImg(int id)
        {
            //把id发给后端，等后端把文件流传回来，再把文件流写入相册
            return true;
        }


    }
}