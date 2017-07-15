using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnToutch : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter()
    {
        Application.Quit();
    }
}
