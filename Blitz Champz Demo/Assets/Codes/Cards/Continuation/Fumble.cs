using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fumble : Continuation_Card
{
    //Get the AudioSource for each Offensive card
	private AudioSource source;
    //animation
    public float speed = .5f;
    private Vector3 target;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        //gives variables its coordinates to go from its current position from hand to its target discard pile
        target = new Vector3(-1.45f, 0f, 0f);
        position = gameObject.transform.position;
    }

    //When card is played, activate the animation and use the skip method
    protected override void Play() {
        StartCoroutine(MoveTo());
        owner.table.Skip();
        //When the card is played, play the sound attached to it
		source = GetComponent<AudioSource>();
		source.Play();
        AdvanceTurn();
    }


	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/fumble");
    }


    void Update()
    {
        
    }


    //Animation code to move from hand to target position
     IEnumerator MoveTo()
    {
       

        // This looks unsafe, but Unity uses
        // en epsilon when comparing vectors.
        while (transform.position != target)
        {
            Debug.Log("Got to 4 loop");
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed);
            // Wait a frame and move again.
            yield return null;
        }
    }
}
