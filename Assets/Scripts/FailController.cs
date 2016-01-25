using UnityEngine;
using System.Collections;

public class FailController : MonoBehaviour {
  
   
	// Use this for initialization
	void Start () {
	}
        void OnTriggerEnter2D (Collider2D other) //Do tej metody zostanie dodany obiekt, który skolidował z kaktusem
        {
            if (other.gameObject.tag == "Player") //Jeżeli obiekt kolidujący to nasz bohater
            {
                other.gameObject.GetComponent<Animator>().SetTrigger("fail");//Włącz wybraną animację
                
            }
        }
	}
	
