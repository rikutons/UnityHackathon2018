using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioKind
{
    BGM, SE
}

public class AudioPlayer : MonoBehaviour
{
    public GameObject[] BGMObjects;
    public GameObject[] SEObjects;

    private AudioSource[] bgmAudioSources = new AudioSource[10];
    private AudioSource[] seAudioSources = new AudioSource[10];
    void Start()
    {
        SetAudioSource(BGMObjects, bgmAudioSources);
        SetAudioSource(SEObjects, seAudioSources);
    }

    void SetAudioSource(GameObject[] audioObjects, AudioSource[] audioSources)
    {
        int count = 0;
        foreach (var audioObject in audioObjects)
        {
            audioSources[count] = audioObject.GetComponent<AudioSource>();
            count++;
        }
    }

    public void Play(int audioId, AudioKind kind)
    {
        if (kind == AudioKind.BGM)
        {
            StopBGM();
            bgmAudioSources[audioId].Play();
        }
        else
        {
            seAudioSources[audioId].Play();
        }
    }

    void StopBGM()
    {
        foreach (var bgmAudioSource in bgmAudioSources)
        {
            if (bgmAudioSource == null) continue;
            if (bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Stop();
            }
        }
    }
}
