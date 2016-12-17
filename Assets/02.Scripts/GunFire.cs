using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunFire : MonoBehaviour {
    public AudioClip fireSfx;
    private Animation gunanim;
    private AudioSource _audio;

    public float Range = 50.0f;
    public Transform firePos;
    public int GunDamage = 5;
    public int GunHeadDamage = 15;
    public float TargetDistance;

    public InGameUI inGameUI;

    void Start() 
    {   
        _audio = GetComponent<AudioSource>();
        gunanim = GetComponent<Animation>();
    }

	void Update () {
        RaycastHit hit;

        if (CnControls.CnInputManager.GetButtonDown("Fire1"))
        {
            Fire();

            if (Physics.Raycast(firePos.position, firePos.TransformDirection(Vector3.forward), out hit, Range, 1<<10 | 1<<11))
            {
                if (hit.collider.tag == "HEAD")
                {
                    object[] _params = new object[2];
                    _params[0] = hit.point;
                    _params[1] = GunHeadDamage;
                    hit.collider.gameObject.SendMessageUpwards("OnDamage"
                                                        , _params
                                                        , SendMessageOptions.DontRequireReceiver);
                    Debug.Log("HEADSHOT");
                }
                else
                {
                    object[] _params = new object[2];
                    _params[0] = hit.point;
                    _params[1] = GunDamage;
                    hit.collider.gameObject.SendMessage("OnDamage"
                                                        , _params
                                                        , SendMessageOptions.DontRequireReceiver);
            
                }
            }

            EnableScript();
        }
	}

    void Fire()
    {
        gunanim.Play();
        _audio.PlayOneShot(fireSfx, 1.0f);
        inGameUI.aimPoint.color = Color.white;
        inGameUI.aimPointCenter.color = Color.white; 
        this.GetComponent<GunFire>().enabled=false;
        inGameUI.enabled = false;
    }

    void EnableScript()
    {   
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(1);
        this.GetComponent<GunFire>().enabled=true;
        inGameUI.enabled = true;
    }

}
