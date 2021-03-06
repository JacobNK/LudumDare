﻿using UnityEngine;
using System.Collections;
using System;

public class Parasite : BaseShip {
	
	// Use this for initialization
	public override void overrideStart () {
		this.HP = 3;
		this.Shield = 0;
		this.Speed = .18f;
		this.AttachPoint = new Vector2(0, 3);
		this.isParasite = true;
		this.source = this.GetComponent<AudioSource>();
	}

	void Infect(GameObject ship, ShipInterface enem)
	{
		//remove the AI controller on the ship
		Destroy (ship.GetComponent (typeof(AI)));
		//Flip the ship 180
		ship.transform.rotation = this.transform.rotation;
		ship.GetComponent<BoxCollider2D> ().isTrigger = false;
		//Set the player to control this new ship now.
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<PlayerScript>().SetNewShip(ship);
		BaseShip bs = ship.GetComponent ((typeof(BaseShip))) as BaseShip;
		bs.SetParasite (true);
		bs.AttatchParasite ();
		//Delete your current ship, the infection guy.
        //this.transform.SetParent(ship.transform);
        //this.transform.localPosition = (ship.GetComponent((typeof(BaseShip))) as BaseShip).getAttachPoint();
        //this.tag = "Untagged";
        //this.GetComponent<BoxCollider2D>().enabled = false;
		//this.enabled = false;
		Destroy (this.gameObject);
	}
	
	public override void OnTriggerEnter2D(Collider2D coll)
	{
		if (String.Equals (coll.gameObject.tag, "Enemy")) {
			ShipInterface enem = coll.gameObject.GetComponent (typeof(ShipInterface)) as ShipInterface;
			if (enem.getShields() > 0) {
				this.OnDeath();
			}
			else {
				this.Infect(coll.gameObject, enem);
			}
		}
	}
}
