using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;//要多处调用 用单例，正常做项目少用单例，用游戏框架中的消息去做
    private AudioSource player;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string name)
    {
        //通过音效名称取得音效片段
        //如果放在Resources 中的子文件里，AudioClip clip = Resources.Load<AudioClip>(“Audio/” + name); //拼接路径
        AudioClip clip = Resources.Load<AudioClip>(name);//从resources文件夹中加载 所以文件必须放在该目录下，名字不能起错
        //播放音效
        player.PlayOneShot(clip);

    }
    //停止播放
    public void StopSound()
    {
        player.Stop();

    }
}
