
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonMovement : TouchMenager {
    public enum type { LeftButton, RightButton, jumpButton };
    public type buttonType;
    public float jumpHeight = 0.0f, moveSpeed = 0.0f;
    public GameObject playerObject = null;
    public GUITexture buttonTexture = null;
    Rigidbody2D playerRigidbody = null;

    //public float heroSpeed; // ustalanie prędkości poruszania
    //public float jumpForce; // siła skoku
    public Transform groundTester; //punkt sprawdzenia gruntu
    public LayerMask layerMask;
    //public Transform startPointHero;
    public AudioClip jumpSoundFX;
    public AudioClip footStepSoundFX;
    Animator anim; //Definiowanie zmiennej (anim) dla komponentu (Animator);
    //Rigidbody2D rgdBody;
    bool dirToRight = true; //zmienna która wskazuje czy jesteśmy obróceni w prawo
    private bool onTheGround; //zmienna sprawdzająca czy jesteśmy na gruncie
    private float radius = 0.1f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
    void Update()
    {

        touchInput(buttonTexture);
        onTheGround = Physics2D.OverlapCircle(groundTester.position, radius, layerMask);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FailContact"))
        {
            playerRigidbody.velocity = Vector2.zero;
            return;
        }
    }
   
  
    void OnFirstTouchBegan()
    {
        if (onTheGround) {
            switch (buttonType)
            {
                case type.jumpButton:
                    //playerRigidbody.AddForce(new Vector2(0f, jumpHeight, ForceMode2D.Impulse));
                    playerRigidbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    anim.SetTrigger("jump");
                    AudioSource.PlayClipAtPoint(jumpSoundFX, transform.position);
                    break;
            }
    }
    }
    void OnSecondTouchBegan()
    {
        if (onTheGround)
        {
            switch (buttonType)
            {
                case type.jumpButton:
                    //playerRigidbody.AddForce(new Vector2(0f, jumpHeight));
                    playerRigidbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    anim.SetTrigger("jump");
                    AudioSource.PlayClipAtPoint(jumpSoundFX, transform.position);
                    break;
            }
        }
    }
    void OnFirstTouch()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        switch (buttonType)
        {
            case type.LeftButton:
                
               
                playerObject.transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
                  anim.SetFloat ("speed", Mathf.Abs (horizontalMove)); // po nacisnieciu strzalki do paramateru speed wpisz wartosc horizontalMove
        
       
        if (horizontalMove < 0 && dirToRight) { //obrócenie w prawo
            Flip();
           
        }
        if (horizontalMove > 0 && !dirToRight) //obrócenie w lewo
        {
            Flip();
           
        }
                break;
            case type.RightButton:
                // float horizontalMove = Input.GetAxis("Horizontal");
                playerObject.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                  anim.SetFloat ("speed", Mathf.Abs (horizontalMove)); // po nacisnieciu strzalki do paramateru speed wpisz wartosc horizontalMove
        
       
        if (horizontalMove < 0 && dirToRight) { //obrócenie w prawo
            Flip();
           
        }
        if (horizontalMove > 0 && !dirToRight) //obrócenie w lewo
        {
            Flip();
           
        }
                break;
        }
    }
    void OnSecondTouch()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        switch (buttonType)
        {
            case type.LeftButton:
                 
                playerObject.transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
               // rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y);
                  anim.SetFloat ("speed", Mathf.Abs (horizontalMove)); // po nacisnieciu strzalki do paramateru speed wpisz wartosc horizontalMove
        
       
        if (horizontalMove < 0 && dirToRight) { //obrócenie w prawo
            Flip();
           
        }
        if (horizontalMove > 0 && !dirToRight) //obrócenie w lewo
        {
            Flip();
           
        }
                break;
            case type.RightButton:
                // float horizontalMove = Input.GetAxis("Horizontal");
                playerObject.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                  anim.SetFloat ("speed", Mathf.Abs (horizontalMove)); // po nacisnieciu strzalki do paramateru speed wpisz wartosc horizontalMove
        
       
        if (horizontalMove < 0 && dirToRight) { //obrócenie w prawo
            Flip();
           
        }
        if (horizontalMove > 0 && !dirToRight) //obrócenie w lewo
        {
            Flip();
           
        }
                break;
        }
    }
    void Flip()
    {

        dirToRight = !dirToRight; // zmiana wartości zmiennej bool
        Vector3 heroScale = gameObject.transform.localScale; //przypisywanie zmiennej aktualnej skali
        heroScale.x *= -1; //odwracamy skalę na osi X
        gameObject.transform.localScale = heroScale; //przypisujemy odwróconą wartość
    }
}

  