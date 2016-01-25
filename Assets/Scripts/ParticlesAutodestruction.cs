using UnityEngine;
using System.Collections;

public class ParticlesAutodestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Autodestruction", 5f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Autodestruction ()
    {
        Destroy(this.gameObject);
    }
}
