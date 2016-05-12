using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(1f,1f,1f, 0f);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
