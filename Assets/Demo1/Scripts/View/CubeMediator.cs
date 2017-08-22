using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class CubeMediator : EventMediator
{
    [Inject]public CubeView cubeView { get; set; }
    [Inject]public AudioManger audioManger { get; set; }

    //madiatorbing完成后调用,用于初始化view
    public override void OnRegister()
    {
        cubeView.Init();

        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange,OnScoreChange);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.OnClickDown,OnUpdateScore);

        //通过dispatcher发起请求分数的命令       
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);      
    }

    //view销毁后调用
    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.OnClickDown, OnUpdateScore);
    }

    //更新view分数
    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }

    //鼠标点击
    public void OnUpdateScore()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
