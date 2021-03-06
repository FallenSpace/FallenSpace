﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHasAttack : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0;
	private float attackCd = 0.3f;

	public Collider2D hasAttackTrigger;

	void Awake()
	{
		hasAttackTrigger.enabled = false;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift) && !attacking)
		{
			attacking = true;
			attackTimer = attackCd;

			hasAttackTrigger.enabled = true;

			Debug.Log ("attack");
		}

		if (attacking) 
		{
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				hasAttackTrigger.enabled = false;
			}

		}

	}
}
