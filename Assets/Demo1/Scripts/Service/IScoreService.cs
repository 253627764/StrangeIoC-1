using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

public interface IScoreService
{
    void RequestScore(string url);
    void OnReceiveScore();
    void UpdateScore(string url, int score);

    IEventDispatcher dispatcher { get; set; }
}
