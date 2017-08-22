using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class RequestScoreCommand : EventCommand
{
    [Inject]public IScoreService scoreService { get; set; }
    [Inject]public ScoreModel scoreModel { get; set; }

    //dispatcher通过事件触发时调用
    public override void Execute()
    {
        Retain();

        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);//登记回调函数
        scoreService.RequestScore("https://www.xxxxx.com");
    }

    private void OnComplete(IEvent evt)
    {
        Debug.Log("request score complete :"+evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);//移除回调

        scoreModel.Score = (int) evt.data;//更新缓存
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange,evt.data);//触发mediator回调，更新view分数

        Release();
    }
}
