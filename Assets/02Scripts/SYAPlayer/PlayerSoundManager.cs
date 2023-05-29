using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager Instance;


    AudioSource SkillGet;
    AudioSource StarGet;
    public AudioSource Jump;
    AudioSource ReSpawn;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SkillGet = GameObject.Find("SkillGetSound").GetComponent<AudioSource>();
        Soundsetting(SkillGet);

        StarGet = GameObject.Find("StarGetSound").GetComponent<AudioSource>();
        Soundsetting(StarGet);
        Jump = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        Soundsetting(Jump);
        ReSpawn = GameObject.Find("ReSpawnSound").GetComponent<AudioSource>();
        Soundsetting(ReSpawn);
    }
   

    public void Soundsetting(AudioSource audio)
    {
        // 오디오 소스 생성해서 추가
        // 뮤트: true일 경우 소리가 나지 않음
        audio.mute = false;
        // 루핑: true일 경우 반복 재생
        audio.loop = false;
        // 자동 재생: true일 경우 자동 재생
        audio.playOnAwake = false;
    }

    public void SkillGetSoundOn()
    {
        SkillGet.Play();
    }
    public void StarGetSoundOn()
    {
        StarGet.Play();
    }
    public void StarGetSoundOff()
    {
        StarGet.Stop();
    }
    public void JumpSoundOn()
    {
        Jump.Play();
    }

    public void ReSpawnSoundOn()
    {
        ReSpawn.Play();
    }
    
}
