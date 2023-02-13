using System.Collections.Generic;
namespace WenQu.DesignPattern.Proxy
{
    public class DownloadCacher : IDownloader
    {
        private Dictionary<int, bool> _cache;
        private ImgDownloader _imgDownloader;
        public DownloadCacher()
        {
            _imgDownloader = new ImgDownloader();
            _cache = new Dictionary<int, bool>();
        }

        public bool DownloadImg(int id)
        {
            bool downloaded = false;
            _cache.TryGetValue(id, out downloaded);
            if (!downloaded)
            {
                return _imgDownloader.DownloadImg(id);
            }
            else
            {
                return false;
            }
        }
    }
}