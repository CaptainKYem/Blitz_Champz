using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Goal : Offensive_Card 
{
	//Sets the points it can give and its ability
	void Start () 
	{
		value = 3;
		kick = true;
		pass = false;
		run = false;
	}

    //Shows the card
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/field_goal");
    }
	void Update () {
	
	}
}
