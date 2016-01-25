using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float heroSpeed; // ustalanie prędkości poruszania
    public float jumpForce; // siła skoku
    public Transform groundTester; //punkt sprawdzenia gruntu
    public LayerMask layerMask;
    public Transform startPointHero;
    public AudioClip jumpSoundFX;
    public AudioClip footStepSoundFX;
    Animator anim; //Definiowanie zmiennej (anim) dla komponentu (Animator);
    Rigidbody2D rgdBody;
    bool dirToRight = true; //zmienna która wskazuje czy jesteśmy obróceni w prawo
    private bool onTheGround; //zmienna sprawdzająca czy jesteśmy na gruncie
    private float radius = 0.1f;



	void Start () {
        
        anim = GetComponent<Animator>(); //Do zmiennej (anim) przyporządkowywujemy za pomocą GetComponent komponent (Animator),
        //od tego momentu mamy dostęp w zmiennej anim do komponentu Animator.
        rgdBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        if (anim.GetCurrentAnimatorStateInfo (0).IsName ("FailContact"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }
        onTheGround = Physics2D.OverlapCircle (groundTester.position, radius, layerMask); //przypisujemy zmiennej pozycje gruntu oraz promień kolizji
        float horizontalMove = Input.GetAxis("Horizontal"); //zmienna horizontalMove zczytuje wartość strzałki(-1 i 1 w zależności od naciśnięcia)
        //za pomocą input.GetAxis a w nawiasie oś poizomą.
        rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y); //Do prędkości velocity dopisujemy wartość x i y
        anim.SetFloat ("speed", Mathf.Abs (horizontalMove)); // po nacisnieciu strzalki do paramateru speed wpisz wartosc horizontalMove
        
        if (Input.GetKeyDown(KeyCode.UpArrow)&& onTheGround) // Jeżeli naciśniemy spację i jesteśmy na gruncie
        {
            rgdBody.AddForce (new Vector2(0f, jumpForce)); //Do naszego obiektu zostanie dołożona siła
            anim.SetTrigger("jump");
            AudioSource.PlayClipAtPoint(jumpSoundFX, transform.position);

        }
       
        if (horizontalMove < 0 && dirToRight) { //obrócenie w prawo
            Flip();
           
        }
        if (horizontalMove > 0 && !dirToRight) //obrócenie w lewo
        {
            Flip();
           
        }
	}

    void Flip()
    {

            dirToRight = !dirToRight; // zmiana wartości zmiennej bool
        Vector3 heroScale = gameObject.transform.localScale; //przypisywanie zmiennej aktualnej skali
        heroScale.x *= -1; //odwracamy skalę na osi X
        gameObject.transform.localScale = heroScale; //przypisujemy odwróconą wartość
    }
    public void ResetHero()
    {
      
        gameObject.transform.position = startPointHero.position; //resetowanie bohatera do wybranek startPoint
            
    }

    }
   
        
    

