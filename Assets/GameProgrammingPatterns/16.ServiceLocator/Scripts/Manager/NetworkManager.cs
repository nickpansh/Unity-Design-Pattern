using UnityEngine;

namespace WenQu.ServiceLocator
{
    public class NetworkManager : IManager
    {
        public virtual void SendData(string data)
        {
            Debug.Log("SendData:" + data);
        }
        public virtual void ReceiveData(string data)
        {
            Debug.Log("ReceiveData:" + data);
        }
    }
    // 空管理器
    // q:为什么它继承自AudioManager而不是声明IAudioManager后NullAudioManager和AudioManager都实现IAudioManager呢？
    // a:希望Locator在AddManager<T>()时，传的是AudioManager而不是IAudioManager,所以NullAudioManager必须继承自AudioManager
    // 否则 return nullMgr as T;会返回空。比起空Manager持有变量占用内存的缺点而言，更看重Locator调用时方便易懂。
    public class NullNetworkManager : NetworkManager
    {
        public override void SendData(string data)
        {
            // Do nothing
            Debug.Log("Do nothing:");
        }
        public override void ReceiveData(string data)
        {
            // Do nothing
            Debug.Log("Do nothing:");
        }
    }
}