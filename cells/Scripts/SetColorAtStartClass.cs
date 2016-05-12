// Collective Robustness of Cells(2016)
// Yong-Jun Shin 
// Computational and Systems Medicine Lab, University of Connecticut 

using UnityEngine;

public class SetColorAtStartClass : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        // set transparency alpha value to 0.2f
        // alpha = 0 --> completely transparent
        // alpha = 1 --> completely opaque
        if (gameObject.name == "Cell")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0f, 1f);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.2f);
        }

        
	
	}
	

}
