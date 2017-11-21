using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource[] audiosources;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        audiosources = GetComponents<AudioSource>();

        foreach (AudioSource audiosource in audiosources)
        {
            if (!audiosource.isPlaying)
            {
                Destroy(audiosource);
            }
        }
	}
}
