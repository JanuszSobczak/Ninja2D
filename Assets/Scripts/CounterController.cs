using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CounterController : MonoBehaviour {
    int numberOfBoxes; //Liczba skrzynek
    public Text counterView; //Widok licznika
   
        
	// Use this for initialization
	void Start () {
        ResetCounter();
	}
	
	// Update is called once per frame
    public void IncrementCounter() // Licznik
{
    numberOfBoxes++;
    counterView.text = numberOfBoxes.ToString();
}
    public void ResetCounter() // Resetowanie licznika
    {
        numberOfBoxes = 0;
        counterView.text = numberOfBoxes.ToString();
    }

}
