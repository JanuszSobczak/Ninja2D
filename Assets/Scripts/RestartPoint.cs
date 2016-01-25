using UnityEngine;
using System.Collections;

public class RestartPoint : MonoBehaviour {

    RestartPointManager restartPointMenager;
    SpriteRenderer sprRenderer;
	// Use this for initialization
	void Start () {

        restartPointMenager = GameObject.Find("Manager").GetComponent<RestartPointManager>();
        if (restartPointMenager == null)
        {
            Debug.LogError("restartPointMenager nie został znaleziony");
        }
        sprRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            restartPointMenager.UpdateStartPoint(this.gameObject.transform);
            sprRenderer.color = new Color(0.3f, 0.8f, 0.6f);
        }	
	}
}
