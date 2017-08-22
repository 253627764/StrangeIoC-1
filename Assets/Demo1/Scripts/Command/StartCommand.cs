using UnityEngine;
using strange.extensions.command.impl;

public class StartCommand : Command //开始命令
{
    [Inject]public AudioManger audioManger { get; set; }
    
    public override void Execute()
    {
        Debug.Log("start command execute");
        PoolManger.Instance.Init();
        audioManger.Init();
    }
}
