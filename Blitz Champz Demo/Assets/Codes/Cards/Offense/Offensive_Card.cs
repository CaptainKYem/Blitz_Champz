using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offensive_Card : Card {
	protected int value;
	protected bool kick = false;
	protected bool pass = false;
	protected bool run = false;
	//Get the AudioSource for each Offensive card
	private AudioSource source;

	//Animation parameters
	public float speed = 1f;
    private Vector3 target;
    private Vector3 position;

	private Vector3 tableTarget;

	public List<GameObject> field;
	public bool right = false;
	public bool up = false;
	public bool valid = true;



	void Start() {
	}
	public bool GetKick() {
		return kick;
	}
	public bool GetPass() {
		return pass;
	}
	public bool GetRun() {
		return run;
	}
	protected override void Play() {

		//possible transformation here
		//target = gameObject.transform.position;
		target = new Vector3(-5.45f, 0f, 0f);
		


		owner.field.Add(gameObject);
		StartCoroutine(moveTo());
		owner.hand.Remove(gameObject);
		//When the card is played, play the sound attached to it
		//Currently, this sound plays again when it is stolen with a Blitz card
		source = GetComponent<AudioSource>();
		source.Play();
		owner.table.last_card = this;
		for (int i = 0; i < owner.hand.Count; i++) {
			owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
		gameObject.GetComponent<BoxCollider>().enabled = false;
		Show();
		AdvanceTurn();
	}
	public int GetValue() {
		return value;
	}
	public void Remove() { //remove card from the field and discard it thus removing points from that player
		owner.UpdateScore();
		//Animation for discard
		target = new Vector3(-1.45f, 0f, 0f);
        position = gameObject.transform.position;
		StartCoroutine(discardTo());
		Discard();
	}
	private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner) {
			this.Play();
		}
	}

	//Deals with where the players cards go once they leave the hand
	public void OrderField()
	{
		for (int i = 0; i < field.Count; i++)
		{
			field[i].transform.position = gameObject.transform.position;
            
			field[i].GetComponent<SpriteRenderer>().color = Color.white;
			if (right)
			{
				field[i].GetComponent<SpriteRenderer>().sortingOrder = i;
				Vector3 adjustment = new Vector3(-1.75f + -1 * 0.25f * i, 0, 2 * (field.Count - i));
				//This determines the card's final position on the board
				
				field[i].transform.position = transform.position + adjustment + Vector3.Scale(transform.up, new Vector3(0, 2.5f, 0));
                
				field[i].transform.rotation = Quaternion.Euler(0, 0, -90f);
                
			}
			else
			{
				field[i].GetComponent<SpriteRenderer>().sortingOrder = i;
				//ThIS determines the stack of the offensive cards
				Vector3 adjustment = new Vector3(1.75f + 0.25f * i, 0, 2 * (field.Count - i));

				//This determines the card's final position on the board
				
				field[i].transform.position = transform.position + adjustment + Vector3.Scale(transform.up, new Vector3(0, 2.5f, 0));
				field[i].transform.rotation = Quaternion.Euler(0, 0, 90f);

			}
		}
	}


	void Update () {
	}

	 IEnumerator discardTo()
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


	IEnumerator moveTo()
	{


		// This looks unsafe, but Unity uses
		// en epsilon when comparing vectors.
		while (transform.position != tableTarget)
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