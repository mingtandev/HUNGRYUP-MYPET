﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public static float volumeSound = 1f;
    public static float volumeMusic = 1f;

    public static SoundManager instance;
    private void Awake() {
        MakeSingleton();
        CreateSoundManagerInspector();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeSingleton(){
         if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }

    void CreateSoundManagerInspector(){
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }


     public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found ");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
       

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found ");
            return;
        }

        s.source.Stop();
    }
}
