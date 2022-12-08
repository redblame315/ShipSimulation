using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectSound { CheckNavPoint }

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioClip[] effectAudioClipArray;
    public AudioClip[] backgroundAudioClipArray;

    AudioSource[] effectAudioSourceArray;
    AudioSource[] backgroundAudioSourceArray;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        effectAudioSourceArray = new AudioSource[effectAudioClipArray.Length];
        for (int i = 0; i < effectAudioClipArray.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = effectAudioClipArray[i];
            audioSource.loop = false;
            audioSource.playOnAwake = false;

            effectAudioSourceArray[i] = audioSource;
        }

        backgroundAudioSourceArray = new AudioSource[backgroundAudioClipArray.Length];
        for (int i = 0; i < backgroundAudioClipArray.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundAudioClipArray[i];
            audioSource.loop = false;
            audioSource.playOnAwake = false;

            backgroundAudioSourceArray[i] = audioSource;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffectSound(EffectSound effectSound)
    {
        effectAudioSourceArray[(int)effectSound].Play();
    }
}
