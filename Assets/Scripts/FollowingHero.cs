using UnityEngine;
using System.Collections;

public class FollowingHero : MonoBehaviour
{

    public GameObject hero; //zmienna hero naszego bohatera
    public float smooth; //czas płynnej kamery
    private Vector3 currVelocity; //informacja na temat prędkości
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = new Vector3 (hero.transform.position.x, transform.position.y, transform.position.z); //nowy wektor pozycji naszego bohatera oraz kamery

        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currVelocity, smooth); // nowa pozycja kamery
    }
}
