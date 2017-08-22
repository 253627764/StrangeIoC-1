using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//继承自ScriptableObject表示PoolList类变成可以自定义资源配置文件
public class PoolList : ScriptableObject 
{
    public List<GameObjectPool> poolList=new List<GameObjectPool>();
}
