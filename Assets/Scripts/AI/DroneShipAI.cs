﻿using UnityEngine;
using System.Collections;

public class DroneShipAI : AI {

    float cooldown = 1f;
    float cooldownTotal = 1f;
		
    // Update is called once per frame
	public override void overrideUpdate()
    {
		AdjustPosition ();
		if (cooldown <= 0) {
			currentShip.Shoot ();
			setCooldown ();
		}
		cooldown -= Time.deltaTime;
	}

    public void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
    }

    private void setCooldown()
    {
        cooldown = 10f;
    }

    public float getCoolDown()
    {
        return cooldownTotal;
    }

    public void Infect()
    {
        //do nothing
    }
}
