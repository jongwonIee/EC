using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
	private float h = 0.0f;
	private float v = 0.0f;

	private Transform playerTr;
    public Transform cameraTr;
    public Transform weaponTr;
	public float moveSpeed = 100.0f;
	public float rotSpeed = 1.0f;

	void Start(){
		playerTr = GetComponent<Transform> ();
    }

	void Update(){
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        playerTr.Translate (moveDir * moveSpeed * Time.deltaTime);
        playerTr.Rotate(Vector3.up * rotSpeed * Input.GetAxis("Mouse X"));
        weaponTr.Rotate(Vector3.right * rotSpeed * Input.GetAxis("Mouse Y"));
        cameraTr.Rotate(-1*Vector3.right * rotSpeed * Input.GetAxis("Mouse Y"));
    }
}
