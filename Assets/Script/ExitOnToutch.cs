using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnToutch : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Maestro")
        {

            Debug.Log("Someone is in");
            Application.Quit();
        }
    }
}
