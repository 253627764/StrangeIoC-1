using UnityEngine;
using System.Collections.Generic;

public class AudioManger
{
    private Dictionary<string, AudioClip> audioDict=new Dictionary<string, AudioClip>();

    private static readonly string audioPathPre = Application.dataPath + "\\Framework\\Resources\\";
    private static readonly string audioPathMid =  "audio";
    private static readonly string audioPathPost = ".txt";

    public static string AudioPath
    {
        get { return audioPathPre + audioPathMid+audioPathPost; }
    }

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        audioDict.Clear();
        TextAsset ta = Resources.Load<TextAsset>(audioPathMid);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue = line.Split(',');
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioDict.Add(key,value);
        }
    }

    public void Play(string name)
    {
        AudioClip ac;
        audioDict.TryGetValue(name, out ac);
        if (ac == null) return;
        Debug.Log("播放声音");
        AudioSource.PlayClipAtPoint(ac,Vector3.zero);
    }    
    
    public void Play(string name,Vector3 pos)
    {
        AudioClip ac;
        audioDict.TryGetValue(name, out ac);
        AudioSource.PlayClipAtPoint(ac, pos);
    }
}
