using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maestro : MonoBehaviour {

    public float speed = 10.0f;

    private bool cursorVisible;

    private MaestroCameraController maestroEyes;

	// Use this for initialization
	void Start () {
        maestroEyes = GetComponent<MaestroCameraController>();
    }

	void FixedUpdate()
    {
        // Movement
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        //
    }

	// Update is called once per frame
	void Update () {
        
        
    }
}
