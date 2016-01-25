using UnityEngine;
using System.Collections;

public class PickUpBox : MonoBehaviour {
    CounterController counterController;
    public AudioClip pickUpBoxSoundFX;
    public GameObject particlePrefab;
	// Use this for initialization
	void Start () {

        counterController = GameObject.Find("Manager").GetComponent<CounterController>(); //szukanie obiektu Manager a następnie w nim CounterController
        if (counterController == null) //jeśli nie ma countercontroller
        {
            Debug.LogError("CounterController nie został znaleziony."); // wypisz błąd
        }
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) //Do tej metody zostanie dodany obiekt, który skolidował ze skrznką
    {
        if (other.gameObject.tag == "Player") //Jeżeli obiekt kolidujący to nasz bohater
        {
            AudioSource.PlayClipAtPoint(pickUpBoxSoundFX, transform.position);
            Destroy(this.gameObject);//Usuń wybrany obiekt
            counterController.IncrementCounter();//wywołanie metody IncrementController
            Instantiate(particlePrefab, transform.position, transform.rotation);
        }
    }
}
