using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rushing_TD : Offensive_Card
{
    //Sets the points it can give and its ability
    void Start()
    {
        value = 6;
		kick = false;
		pass = false;
		run = true; 
    }

    //shows the card
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/rushing_td");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
