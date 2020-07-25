using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerEffect : Singleton<SoundManagerEffect>
{
    public AudioClip[] audioClips;
    public Dictionary<string, AudioSource> SoundDic;
    //
    void Awake()
    {

        SoundDic = new Dictionary<string, AudioSource>();

        int Len = audioClips.Length;

        for(int i = 0; i < Len; i++)
        {
            this.gameObject.AddComponent<AudioSource>();
        }

        AudioSource[] _as = this.GetComponentsInChildren<AudioSource>();

        for(int i = 0; i < Len; i++)
        {
            _as[i].clip = audioClips[i];
            _as[i].playOnAwake = false;
            SoundDic.Add(_as[i].clip.name, _as[i]);
        }
    }

    public void Play(string name,bool loop = false,float volume=1)
    {
        if(SoundDic.ContainsKey(name))
        {
            AudioSource aS = SoundDic[name];
            aS.loop = loop;
            aS.volume = volume;
            aS.Play();
            Debug.Log("Play");
        }
    }

    public void PlayOneShot(string name)
    {
        if (SoundDic.ContainsKey(name))
        {
            AudioSource aS = SoundDic[name];
            aS.PlayOneShot(aS.clip);
        }
    }

    public void Stop(string name)
    {
        if (SoundDic.ContainsKey(name))
        {
            AudioSource aS = SoundDic[name];
            aS.Stop();
        }
    }

    public bool isPlay(string name)
    {
        if (SoundDic.ContainsKey(name))
        {
            AudioSource aS = SoundDic[name];
            return aS.isPlaying;
        }
        return false;
    }

    public void Mute(bool isMute)
    {
        AudioSource[] AS = SoundManagerEffect.Inst.GetComponentsInChildren<AudioSource>();
        for (int i = 0; i < AS.Length; i++)
        {
            AS[i].mute = isMute;
        }
    }
}

// 사운드매니저 어떻게 하면 편하게 사용할수 있다가 생각하다가?
// 스크립트 하나만 컴포넌트 하면 다 해결할수 있는 방향으로 생각하다가
// 등록한 사운드 클립만큽 오디오소스를 컴포넌트 해서 관리!!
