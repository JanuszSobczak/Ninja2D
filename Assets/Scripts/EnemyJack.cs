using UnityEngine;
using System.Collections;

public class EnemyJack : MonoBehaviour
{
    public Transform navStartPoint;
    public Transform navEndPoint;
    public float velocity = 1f; //prędkość poruszanie się platformy
    public bool colliding;
   public LayerMask detectWhat;
    Rigidbody2D rgdBody;
    void Start()
    {

        rgdBody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
    rgdBody.velocity = new Vector2 (velocity, rgdBody.velocity.y);
        colliding = Physics2D.Linecast(navStartPoint.position, navEndPoint.position, detectWhat);
        if (colliding)
        {
            transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
            velocity*= -1;
        }
    }
   


 
}


