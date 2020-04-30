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
    public Vector3 target;
    public Vector3 position;

	private Vector3 tableTarget;
	private Vector3 adjuster;
	

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

    //Gets called for the offensive called from the onMouseButtonClicked()
	protected override void Play() {
		
		
		owner.field.Add(gameObject);
		owner.hand.Remove(gameObject);
		
		
		for (int i = 0; i < field.Count; i++)
		{
			field[i].transform.position = gameObject.transform.position;
			field[i].GetComponent<SpriteRenderer>().color = Color.white;
			if (right)
			{
				field[i].GetComponent<SpriteRenderer>().sortingOrder = i;
				adjuster = new Vector3(-1.75f + -1 * 0.25f * i, 0, 2 * (field.Count - i));
				//Handles the orientation of the card
				field[i].transform.rotation = Quaternion.Euler(0, 0, -90f);
                
                
			}
			else
			{
				field[i].GetComponent<SpriteRenderer>().sortingOrder = i;
				adjuster = new Vector3(1.75f + 0.25f * i, 0, 2 * (field.Count - i));
				//Handles the orientation of the card
				field[i].transform.rotation = Quaternion.Euler(0, 0, 90f);

			}
		}
        //Gets used for the moveTo() to place into position from hand
		tableTarget = gameObject.transform.position + adjuster + Vector3.Scale(transform.up, new Vector3(0, 2.5f, 0));
		StartCoroutine(moveTo());

        //Deals with sound
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


	//Returns the specific value from the card that is played
	public int GetValue()
	{
		return value;
	}



	//remove card from the field and discard it thus removing points from that player
	public void Remove()
	{
		owner.UpdateScore();
		//Animation for discard
		target = new Vector3(-1.45f, 0f, 0f);
		position = gameObject.transform.position;
		StartCoroutine(discardTo());
		Discard();
	}



	//When the offensive card is clicked by the mouse, it will execute the play()
	private void OnMouseUpAsButton()
	{
		if (owner != null && owner.table.current_player == owner)
		{
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
				//Handles the orientation of the card
				field[i].transform.rotation = Quaternion.Euler(0, 0, -90f);

			}
			else
			{
				field[i].GetComponent<SpriteRenderer>().sortingOrder = i;
				//ThIS determines the stack of the offensive cards
				Vector3 adjustment = new Vector3(1.75f + 0.25f * i, 0, 2 * (field.Count - i));

				//This determines the card's final position on the board
				field[i].transform.position = transform.position + adjustment + Vector3.Scale(transform.up, new Vector3(0, 2.5f, 0));
				//Handles the orientation of the card
				field[i].transform.rotation = Quaternion.Euler(0, 0, 90f);

			}
		}
	}



	void Update () {
	}

	//This handles the movement from the current position to the the discard pile
	IEnumerator discardTo()
	{
		//While our object hasn't reach the target from its current position
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



	//This handles the movement from the offensive card, to the table and its location
	IEnumerator moveTo()
	{
		//While our object hasn't reach the target from its current position
		while (transform.position != tableTarget)
		{
			Debug.Log("Got to 4 loop");
			transform.position = Vector3.MoveTowards(
				transform.position,
				tableTarget,
				speed);
			// Wait a frame and move again.
			yield return null;
		}
		owner.OrderField();
	}

}