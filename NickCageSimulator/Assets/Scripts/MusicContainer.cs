using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContainer : MonoBehaviour
{

    /* singleton */
    public static MusicContainer MC;

    AudioSource[] sources;

    private void Awake()
    {
        MC = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
    }


    public void playSound(int i)
    {
        sources[i].Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
