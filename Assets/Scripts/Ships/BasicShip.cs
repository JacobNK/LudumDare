﻿using UnityEngine;
using System.Collections;

public class BasicShip : BaseShip {

    private bool Shooting;
    public GameObject Bullet;
    float cooldown = .6f;

    // Use this for initialization
    public override void overrideStart()
    {
        this.HP = 2;
        this.Shield = 0;
        this.Speed = .075f;
        //this.Damage = 2;
        this.AttachPoint = new Vector3(-.4f, -.05f, -1);
        this.source = this.GetComponent<AudioSource>();
        Shooting = false;
        this.transform.Rotate(Vector3.forward * 180);
		this.tier = 1;
    }

    public override void Shoot()
    {
        if (!this.Shooting)
        {
            this.Shooting = true;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            BaseBullet BI = clone.GetComponent(typeof(BaseBullet)) as BaseBullet;
            BI.OnShoot(transform.right, this.tag);
            this.Shooting = false;
        }
    }

    public override void overrideOnTriggerEnter2D(Collider2D coll)
    {

    }

    public override float getCooldown()
    {
        return cooldown;
    }
}
