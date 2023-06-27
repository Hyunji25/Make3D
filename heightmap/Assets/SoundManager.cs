using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInfo
{
    public AudioClip clip;
    public string key;
}

//[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager Instance = null;

    public static SoundManager GetInstance
    {
        get
        {
            if (!Instance)
            {
                GameObject obj = new GameObject("SoundManager");
                Instance = obj.AddComponent(typeof(SoundManager)) as SoundManager;
            }
            return Instance;
        }
    }

    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

    public Dictionary<string, List<AudioInfo>> SoundList = new Dictionary<string, List<AudioInfo>>();
    //public List<AudioClip> SoundList = new List<AudioClip>();
    public string[] filePath = { "" };

    private void Start()
    {
        foreach(string path in filePath)
        {
            object[] Objects = Resources.LoadAll("" + path);

            for (int i = 0; i < Objects.Length; ++i)
            {
                AudioInfo obj = new AudioInfo();
            }
            sounds.Add(Objects[i] as AudioClip);
        }

        
    }

    /*
    void PlaySound() // юс╫ц©К
    {
        AudioSource source = new AudioSource();
        source.clip = SoundList[0];

        source.Play();
        source.Stop();
    }
    */
}
