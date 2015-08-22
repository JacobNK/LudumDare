﻿using UnityEngine;
using System.Collections;

public class StarShip : MonoBehaviour, ShipInterface
{
    //Hull Points
    private int HP;
    //Shield
    private int Shield;
    //Ship Speed
    private float Speed;
    //Damage the ship can do
    private int Damage;
    private bool Shooting;
    public GameObject Bullet;
    //Position on the ship the parastite shows up on (0,0) is upper left
    private Vector2 AttachPoint;

    // Use this for initialization
    void Start()
    {
        this.HP = 3;
        this.Shield = 1;
        this.Speed = .05f;
        //this.Damage = 2;
        this.AttachPoint = new Vector2(0, 3);
        this.Shooting = false;
    }

    public void Shoot()
    {
        ;
    }

    public void Move(Vector2 Direction)
    {
        //Takes the direction, multiplies by speed
        this.transform.position += (float)this.Speed * (Vector3)Direction;
    }

    public bool TakeDamage(int val)
    {
        if (this.Shield <= 0)
        {
            this.Shield = 0;
            if (this.HP > 0)
            {
                this.HP -= val;
            }
        }
        else
        {
            this.Shield -= val;
        }

        if (this.Shield <= 0)
        {
            OnDeath();
            return true;
        }
        return false;
    }

    public void OnDeath()
    {
        //Change Animation to EXPLOSION!!!!
        this.HP = 0;
    }

    public void Infect()
    {
    }

    public void Upgrade()
    {
    }

    public int getShields()
    {
        return this.Shield;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("TESt");
    }
}