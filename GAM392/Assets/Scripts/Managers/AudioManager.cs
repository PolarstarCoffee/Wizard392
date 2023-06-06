using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds; //Array of sounds

    public static AudioManager instance;  //Create a static instance of this manager so it persists between scenes 

    // Start is called before the first frame update
    void Awake() {

       
        foreach (Sound s in sounds) //iteration through sound array
        {
            s.source = gameObject.AddComponent<AudioSource>(); //add audio to gameobject
            s.source.clip = s.clip;

            s.source.volume = s.volume; 
            s.source.pitch = s.pitch; 
            s.source.loop = s.loop; 
        }
        
    }


    public void Play (string name) //sound playback functionality 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;  
        }
        s.source.Play(); //Plays audio
       
    }
}
