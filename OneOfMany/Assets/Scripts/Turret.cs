using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private EnemyProperties targetEnemy;
    [Header ("Attirbutes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 1;
    private float fireCD = 0f;
    [Header ("Laser stuff")]
    public bool useLaser = false;
    public int laserDot = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    public float slowAmount = 0.5f;

    [Header ("Script Dependacies")]
    public string enemyTag = "Enemy";
    public Transform rotatePart;
    public GameObject bulletPrefab;
    public Transform firePoint;


    
    // Use this for initialization
	void Start () {

    }
	

	void Update () {
        if (target == null)
        {
            if (useLaser && lineRenderer.enabled) {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
            UpdateTarget();
        }
        else if (OutOfRange())// of enemy is dead
        {
            target = null;
        }
        if(target !=null)
        {
            LockOnTarget();

            if (useLaser)
            {
                Laser();
            }
            else {
                if (fireCD <= 0)
                {
                    Shoot();
                    fireCD = 1 / fireRate;
                }
                fireCD -= Time.deltaTime;
            }
        }



	}

    void LockOnTarget() {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    void Laser() {

        targetEnemy.TakeDamage(laserDot*Time.deltaTime);
        targetEnemy.Slow(slowAmount);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position +dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);


    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bullet != null)
            bulletScript.Seek(target);
    }

    void UpdateTarget()
    {
        //TODO remove find to reduce searches
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distToEnemy < shortestDist) {
                nearestEnemy = enemy;
                shortestDist = distToEnemy;
            }
        }

        if (nearestEnemy != null && shortestDist <= range)
        {
            if (useLaser && targetEnemy != null)
                targetEnemy.speed = targetEnemy.startSpeed;

            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyProperties>();
        }
        else {
            target = null;
        }
    }

    bool OutOfRange() {
        return Vector3.Distance(transform.position, target.transform.position) > range;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}
