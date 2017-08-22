using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]public IEventDispatcher dispatcher { get; set; }
    [Inject]public AudioManger audioManger { get; set; }

    private Text scoreTxt;

    public void Init()
    {
        scoreTxt = GetComponentInChildren<Text>();
    }

    void Update()
    {
//        this.transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2))*0.2f);
        if (Input.GetMouseButtonDown(0))
        {
            PoolManger.Instance.GetInstance("Bullet");
        }
    }

    void OnMouseDown()
    {
        dispatcher.Dispatch(Demo1MediatorEvent.OnClickDown);
        audioManger.Play("DM-CGS-02");
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
}
