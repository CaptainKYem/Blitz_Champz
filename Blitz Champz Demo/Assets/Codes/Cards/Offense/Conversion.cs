using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversion : Offensive_Card
{
    //Sets the points it can give and its ability
    void Start()
    {
        value = 2;
		pass = true;
		run = true;
    }

    //Shows the card
    public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/conversion");
    }
    void Update()
    {
        
    }
}
