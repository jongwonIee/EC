using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunFire : MonoBehaviour {
    public AudioClip fireSfx;
    private Animation gunanim;
    private AudioSource _audio;

    void Start() 
    {   
        _audio = GetComponent<AudioSource>();
        gunanim = GetComponent<Animation>();
    }

	void Update () {
        if (CnControls.CnInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }
	}

    void Fire()
    {
        _audio.PlayOneShot(fireSfx, 1.0f);
        gunanim.Play("GunShot");
    }
}
