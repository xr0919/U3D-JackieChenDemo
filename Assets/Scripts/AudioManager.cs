using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;//Ҫ�ദ���� �õ�������������Ŀ���õ���������Ϸ����е���Ϣȥ��
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
        //ͨ����Ч����ȡ����ЧƬ��
        //�������Resources �е����ļ��AudioClip clip = Resources.Load<AudioClip>(��Audio/�� + name); //ƴ��·��
        AudioClip clip = Resources.Load<AudioClip>(name);//��resources�ļ����м��� �����ļ�������ڸ�Ŀ¼�£����ֲ������
        //������Ч
        player.PlayOneShot(clip);

    }
    //ֹͣ����
    public void StopSound()
    {
        player.Stop();

    }
}
