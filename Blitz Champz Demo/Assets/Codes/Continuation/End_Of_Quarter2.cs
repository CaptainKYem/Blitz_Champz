﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Of_Quarter2 : Continuation_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/end_of_quarter2");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
