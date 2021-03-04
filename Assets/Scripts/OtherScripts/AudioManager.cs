using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour

{
    public static AudioManager instance;

    public Sound[] clips;

    // Start is called before the first frame update
    void Awake ()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in clips) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.vol;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start() {
        //Play("BGM");
    }

    public void Play (string name) {

        Sound s = Array.Find(clips, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Error, sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name) {
        Sound s = Array.Find(clips, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Error, sound " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void Unpause(string name) {
        Sound s = Array.Find(clips, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Error, sound " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }
}
