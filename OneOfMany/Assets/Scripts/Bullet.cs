﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70;
    public float explosionRadius = 0;
    public GameObject impactEffect;
    public int damage = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    void HitTarget() {
        GameObject effectPrefab =Instantiate(impactEffect, transform.position, transform.rotation);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else {
            Damage(target);
        }

        Destroy(effectPrefab, 2f);
        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        EnemyProperties e = enemy.GetComponent<EnemyProperties>();
        if(e != null)
            e.TakeDamage(damage);

    }

    public void Seek(Transform _target) //damage etc
    {
        target = _target;
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
