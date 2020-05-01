using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocked_Kick : Defensive_Card
{
    //gives defensive card blocked_kick its property
    void Start()
    {
        kick = true;
        //Animation parameters
		target = new Vector3(-1.45f, 0f, 0f);
        position = gameObject.transform.position;
    }

    //Shows the card
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/blocked_kick");
    }


    void Update()
    {
        
    }
}
