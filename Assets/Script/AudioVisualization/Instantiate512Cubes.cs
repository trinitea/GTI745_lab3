using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {
	public GameObject sampleCubePrefab;
	GameObject[] sampleCubes = new GameObject[512];
	public float maxScale; 

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 512; ++i) {
			GameObject sampleCubeInstance = (GameObject)Instantiate (sampleCubePrefab);
			sampleCubeInstance.transform.position = this.transform.position;
			sampleCubeInstance.transform.parent = this.transform;
			sampleCubeInstance.name = "SampleCube" + i;
			this.transform.eulerAngles = new Vector3 (0, -0.703125f * i, 0);
			sampleCubeInstance.transform.position = Vector3.forward * 100;
			sampleCubes [i] = sampleCubeInstance;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 512; i++) {
			if (sampleCubes != null) {
				sampleCubes [i].transform.localScale = new Vector3 (10, (AudioVisualizer.audioSamples[i]*maxScale) + 2, 10);
			} 
		}
		
	}
}
