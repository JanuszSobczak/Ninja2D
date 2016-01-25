using UnityEngine;
using System.Collections;

public class MovingCactus : MonoBehaviour {

    public Transform navStartPoint;
    public Transform navEndPoint;
    public float speed; //prędkość poruszanie się platformy

    private Vector2 startPoint; //Punkt startowy platformy
    private Vector2 endPoint; //Punkt końcowy platformy

    private Vector2 currentPlatformPosition; //Bierząca pozycja platformy
    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);



    }

    // Update is called once per frame
    void Update()
    {
        //  transform.Translate(speed, 0, 0);
        currentPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1)); //Metod Lerp wyznacza nam wektor pomiędzy punktami start i end na podstawie wskazówki 0 i 1.
        // Nasza wartość zadana t będzie krążyła pomiędzy tymi punktami i wykorzystamy do tego celu metodę PingPong
        //Metoda PingPong odlicza czas od uruchomienia aplikacji i zwraca wartość 
        //do momemntu uzyskania wyznaczonej długości podanej przez nas. Gdy przekroczy podaną długość cofa się licznik.

        transform.position = currentPlatformPosition;
    }





}