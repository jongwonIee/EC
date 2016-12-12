using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour {
    
    public float hp = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDamage(object[] _params)
    {
        Debug.Log("Hit!");
        hp -= (int) _params[1];
        if (hp <= 0.0f)
        {
//            MonsterDie();
            Debug.Log("Dead!");
        }      
    }
}
