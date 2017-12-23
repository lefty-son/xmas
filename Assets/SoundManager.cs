using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    private AudioSource _audio;
    public AudioClip alert, gratz, drag, bgm;

	// Use this for initialization
	void Awake () {
        if (instance == null) instance = this;
        _audio = GetComponent<AudioSource>();

        StartCoroutine(BGM());
	}

    IEnumerator BGM(){
        while(true){
            yield return new WaitForSeconds(100f);
            _audio.PlayOneShot(bgm);
        }
    }

    public void Alert(){
        _audio.PlayOneShot(alert);
    }

    public void Gratz(){
        _audio.PlayOneShot(alert);
    }

    public void Drag(){
        _audio.PlayOneShot(drag);
    }
}
