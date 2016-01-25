using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {
    public Transform cameraTransform; //bierząca pozycja kamery
    public float paralaxFactor; // Współczynnik pralaksy
    private Vector3 previousCameraPosition; // Poprzednia pozycja kamery
    private Vector3 deltaCameraPosition; //Różnica pomiędzy obecna a poprzednią pozycją kamery

    


	void Start () {

        previousCameraPosition = cameraTransform.position; // ustaiwnie poprzedniej pozycji kamery na bierzącą, żeby nie była pusta
      
    
    
    }
	
	// Update is called once per frame
	void Update () {
        
        deltaCameraPosition = cameraTransform.position - previousCameraPosition; // obliczanie róźnicy
        Vector3 parallaxPosition = new Vector3 (transform.position.x + (deltaCameraPosition.x * paralaxFactor), transform.position.y, transform.position.z);   //nowa pozycja dla naszego obiektu do którego podeptniemy nowy skrypt
        transform.position = parallaxPosition; //przypisanie nowej pozycji obiektu
        previousCameraPosition = cameraTransform.position; //przypisanie obecnej pozycji kamery do poprzedniej



	}
}
