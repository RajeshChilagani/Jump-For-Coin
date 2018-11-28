using UnityEngine;
using System.Collections;

public class coindes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlankSprite_0 (3)")
        {
            Destroy(col.gameObject);
        }
    }
}
