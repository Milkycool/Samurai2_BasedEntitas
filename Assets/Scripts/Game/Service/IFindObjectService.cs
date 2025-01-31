using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// 查找场景内物体服务接口
    /// </summary>
    public interface IFindObjectService : IInitService
    {
        T[] FindAllType<T>() where T : Object;
        IView[] FindAllView();
    }
}
