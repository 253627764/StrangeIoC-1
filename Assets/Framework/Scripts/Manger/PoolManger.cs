using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManger
{
    private static PoolManger _instance;

    public static PoolManger Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance=new PoolManger();
            }
            return _instance;
        }
    }

    private readonly Dictionary<string, GameObjectPool> _poolDict;

    //私有构造，完成dict的赋值
    private PoolManger()
    {
        PoolList poolList = Resources.Load<PoolList>("PoolList");//读取序列化文件

        _poolDict=new Dictionary<string, GameObjectPool>();

        foreach (var pool in poolList.poolList)
        {
            _poolDict.Add(pool.poolName, pool);
        }
    }

    public void Init()
    {
        
    }

    /// <summary>
    /// 从对象池获取对象
    /// </summary>
    /// <param name="poolName">对象池名称</param>
    /// <returns></returns>
    public GameObject GetInstance(string poolName)
    {
        GameObjectPool pool;
        if (_poolDict.TryGetValue(poolName,out pool))
        {
            return pool.GetInstance();//从对象池获取对象
        }
        Debug.LogError("pool is not exits!!!");
        return null;
    }
}
