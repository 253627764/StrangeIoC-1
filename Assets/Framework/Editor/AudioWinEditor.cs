using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;

public class AudioWinEditor : EditorWindow 
{
    [MenuItem("Manager/AudioManger")]
    static void CreatWin()
    {
        #region GetWinWithRect
        //        Rect rect = new Rect(400, 400, 300, 400);
        //        AudioWinEditor win=EditorWindow.GetWindowWithRect(typeof(AudioWinEditor),rect) as AudioWinEditor;    
        #endregion

        GetWindow<AudioWinEditor>("音效管理");
    }

    void Awake()
    {
        LoadAudioList();
    }

    void OnProjectChange()
    {
        LoadAudioList();
    }    
    
    private string _audioName;
    private string _audioPath;
    private readonly Dictionary<string, string> _audioDict = new Dictionary<string, string>();

    void OnGUI()
    {
        //标题
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("音效路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();

        //内容
        foreach (string key in _audioDict.Keys)
        {
            string path = _audioDict[key];

            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(path);
            if (GUILayout.Button("删除")){ _audioDict.Remove(key);SaveAudio();return;}           
            GUILayout.EndHorizontal();
        }

        //添加
        _audioName= EditorGUILayout.TextField("音效名称", _audioName);
        _audioPath= EditorGUILayout.TextField("音效路径", _audioPath);
        if (GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(_audioPath);
            if (o==null)
            {
                Debug.LogError("音效不存在");
            }
            else
            {
                if (_audioDict.ContainsKey(_audioName))
                {
                    Debug.LogError("音效已存在");
                }
                else
                {
                    _audioDict.Add(_audioName,_audioPath);
                    SaveAudio();
                }
            }
        }
    }

    //保存到txt文件
    void SaveAudio()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string key in _audioDict.Keys)
        {
            string path = _audioDict[key];
            sb.Append(key + "," + path+"\n");
        }

        File.WriteAllText(AudioManger.AudioPath, sb.ToString());
    }

    //加载txt文件内容到UI
    void LoadAudioList()
    {
        _audioDict.Clear();
        if (File.Exists(AudioManger.AudioPath) == false) return;

        string[] lines = File.ReadAllLines(AudioManger.AudioPath);
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue = line.Split(',');
            _audioDict.Add(keyvalue[0],keyvalue[1]);
        }
    }
}
