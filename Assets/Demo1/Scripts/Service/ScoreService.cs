using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;

public class ScoreService : IScoreService
{
    //请求数据
    public void RequestScore(string url)
    {
        Debug.Log("Request score from url :"+url);
        OnReceiveScore();
    }

    //接收数据
    public void OnReceiveScore()
    {
        int score = Random.Range(0, 100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);//触发回调函数
    }

    //更新服务器数据
    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update score to url :" + url+"new score :"+score);       
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }//分发器
}
