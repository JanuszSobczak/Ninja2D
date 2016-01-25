using UnityEngine;
using System.Collections;

public class RestartPointManager : MonoBehaviour {
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
	
	}

    public void UpdateStartPoint(Transform newTransform) //Ta metoda zmienia wartość miejsca startowego u naszego bohatera
{
    playerController.startPointHero = newTransform; //Przypisuje wartość tego obiektu z którym skolidował bohater
}
    
}
