using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    public Sound[] clips;

    // Start is called before the first frame update
    void Awake ()
    {
        foreach (Sound s in clips) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.vol;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
