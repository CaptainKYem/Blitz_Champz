using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_Completion : Continuation_Card
{
    //Speed for card movement
    public float speed = 0.5f;

    //Location of card start and its end
    private Vector3 target;
    

   

    void Start() {
        target = new Vector3(-1.45f, 0f, 0f);
        
    }
    protected override void Play() {
        StartCoroutine(MoveTo());
        owner.Draw();
        AdvanceTurn();

    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/pass_completion");
    }

   
    void Update() {
        
    }


    //Code to move the card from point A to B.  Taking the code inside the while l
    //oop and placing it into the Update will execute perfectly fine
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
                speed * Time.deltaTime);
            // Wait a frame and move again.
            yield return null;
        }
    }

}