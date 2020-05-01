using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour {
	public Player owner;
	protected bool valid = true;
	protected bool win_played = false;


    //sets the owner and it's rotation
	public void SetOwner(Player own) {
		this.owner = own;
		if (owner.up) {
			//180f = 0f
            //Changing the values will affect the rotation of the top cards.
			gameObject.transform.rotation = Quaternion.Euler(0,0,0f);
		}
	}

    //Checks if the card is valid
	public virtual bool CheckValid() {
		return valid;
	}


	void Start () {
	}


    //Deals with the continuation card going into the discard pile
	public void Discard () {
		if (this.owner != null) {
			for (int i = 0; i < owner.hand.Count; i++) {
				owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
			}
			owner.table.last_card = null;
			//This moves card to discard pile, commented out to make animations work *OBSELETE*
			//gameObject.GetComponent<Transform>().position = new Vector3(-1.45f, 0f, 0f);
			gameObject.transform.rotation = Quaternion.Euler(0,0,0f);
			owner.table.Discard(gameObject);
			owner.Remove(gameObject);
			this.owner = null;
			Destroy(GetComponent<BoxCollider>());
			Show();
		}
	}

    //Deals with hiding the cards of the other players when they are not active
	public void Hide() {
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/back");
	}


	public virtual void Show() {
	}


    //Advances the turn to the next person
	public void AdvanceTurn() {
		owner.table.AdvanceTurn();
	}


    //Will move continuation cards other than blitz into the discard pile when clicked, will execute the discard method
	private void OnMouseUpAsButton() {
        if (owner != null && owner.table.current_player == owner)
        {
            this.Play();
            //Look in to adding a check for cards to play sound here. Either during Play() or during the Discard() function
            this.Discard();
        }
    }

    //This relates to the cards in your hand. When hovering over the hand, it'll move up 
	void OnMouseEnter() {
		if (owner != null && owner == owner.table.current_player) {
			if (owner.hand.Contains(gameObject)) {
				gameObject.transform.position += Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
				gameObject.GetComponent<SpriteRenderer>().sortingOrder +=20;
				for (int i = 0; i < owner.hand.Count; i++) {
					if (owner.hand[i] != gameObject) {
						if (owner.hand[i].GetComponent<Card>().win_played) {
							gameObject.GetComponent<SpriteRenderer>().color = Color.white;
						} else {
						owner.hand[i].GetComponent<SpriteRenderer>().color = Color.gray;
						}
					}
				}
			} else {
				foreach(Player a in owner.table.order) {
					if (owner != a && a.field.Contains(gameObject)) {
						foreach(Player b in owner.table.order) {
							if (b != a) {
								for (int i = 0; i < b.field.Count; i++) {
									if (b.field[i] != gameObject) {
										b.field[i].GetComponent<SpriteRenderer>().color = Color.gray;
									}
								}
							}
						}
						gameObject.GetComponent<SpriteRenderer>().sortingOrder +=20;
						for (int i = 0; i < a.field.Count; i++) {
							if (a.field[i] != gameObject) {
								a.field[i].GetComponent<SpriteRenderer>().color = Color.gray;
							}
						}
					}
				}
			}
		}
	}

	//This relates to the cards in your hand.  Focuses on moving the cards back down when no longer hovering over them
	void OnMouseExit() {
		if (owner != null && owner == owner.table.current_player) {
			if (owner.hand.Contains(gameObject)) {
				gameObject.transform.position -= Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
				gameObject.GetComponent<SpriteRenderer>().sortingOrder -=20;
				if (!win_played){
					for (int i = 0; i < owner.hand.Count; i++) {
						owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
					}
				} else {
					gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				}
			} else {
				foreach(Player a in owner.table.order) {
					if (owner != a && a.field.Contains(gameObject)) {
						foreach(Player b in owner.table.order) {
							if (b != a) {
								for (int i = 0; i < b.field.Count; i++) {
									if (b.field[i] != gameObject) {
										b.field[i].GetComponent<SpriteRenderer>().color = Color.white;
									}
								}
							}
						}
						gameObject.GetComponent<SpriteRenderer>().sortingOrder -=20;
						for (int i = 0; i < a.field.Count; i++) {
							a.field[i].GetComponent<SpriteRenderer>().color = Color.white;
						}
					}
				}
			}
		}
	}


	protected virtual void Play () {
	}


	void Update () {
		
	}
}