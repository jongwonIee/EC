using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class GunFire : MonoBehaviour {
    public AudioClip fireSfx;
    private Animation gunanim;
    private AudioSource _audio;

    public float Range = 50.0f;
    public Transform firePos;
    public float TargetDistance;

    public InGameUI gameUI;
    public GameMgr gameMgr;
    private Image fireButton;

    void Start() 
    {   
        _audio = GetComponent<AudioSource>();
        gunanim = GetComponent<Animation>();
        gameUI = GameObject.Find ("InGameUI").GetComponent<InGameUI> ();
        gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
        fireButton = GameObject.Find("Fire").GetComponent<Image>();
    }

	void Update () {
        RaycastHit hit;

        if (CnControls.CnInputManager.GetButtonDown("Fire1"))
        {
            if (gameMgr.ultiOn == false)
            {
                Fire();

                if (Physics.Raycast(firePos.position, firePos.TransformDirection(Vector3.forward), out hit, Range, 1 << 10 | 1 << 11))
                {
                    if (hit.collider.tag == "HEAD")
                    {
                        object[] _params = new object[2];
               
                        _params[0] = hit.point;
                        _params[1] = true;
                        hit.collider.gameObject.SendMessageUpwards("OnDamage"
                                                            , _params
                                                            , SendMessageOptions.DontRequireReceiver);
                        Debug.Log("HEADSHOT");
                        gameMgr.headShotCount += 1;
                    }
                    else
                    {
                        object[] _params = new object[2];
                        _params[0] = hit.point;
                        _params[1] = false;
                        hit.collider.gameObject.SendMessage("OnDamage"
                                                            , _params
                                                            , SendMessageOptions.DontRequireReceiver);
                    }
                

                }
                else
                {
                    gameUI.DispUlti(-10);
                }
            }
            else
            {
                //ulti
                UltiFire();
                fireButton.color = Color.white;
                gameMgr.ultiOn = false;
                gameUI.DispUlti(-100);
            }
                //gunfire delay
                EnableScript();
        }
	}

    void Fire()
    {
        gunanim.Play();
        _audio.PlayOneShot(fireSfx, 1.0f);
        gameUI.aimPoint.color = Color.white;
        gameUI.aimPointCenter.color = Color.white; 
        this.GetComponent<GunFire>().enabled=false;
        gameUI.enabled = false;
    }

    void UltiFire()
    {   
        Debug.Log("ulti fired!");
        gunanim.Play();
        _audio.PlayOneShot(fireSfx, 1.0f);
        gameUI.aimPoint.color = Color.white;
        gameUI.aimPointCenter.color = Color.white; 
        this.GetComponent<GunFire>().enabled=false;
        gameUI.enabled = false;
    }

    void EnableScript()
    {   
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(1);
        this.GetComponent<GunFire>().enabled=true;
        gameUI.enabled = true;
    }

}
