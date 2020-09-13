using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject Ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var newObject = Instantiate(Ball);
            var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            newObject.transform.position = ray.origin + ray.direction.normalized * 2f;
            newObject.GetComponent<Rigidbody>().velocity = ray.direction.normalized * 60f;
        }
	}
}
