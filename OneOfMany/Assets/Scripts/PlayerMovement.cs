using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerMovement : MonoBehaviour {

    Vector3 joystickDirection;
    public float actionRadius = 1f;
    public int playerNum = 2;
    string leftHorAxis = "LeftJoystickHorizontal";
    string leftVerAxis = "LeftJoystickVertical";
    string xBut = "XButton";
    // Use this for initialization
    void Start () {
        if (playerNum > 1) {
            leftHorAxis += "_p" + playerNum.ToString();
            leftVerAxis += "_p" + playerNum.ToString();
            xBut += "_p" + playerNum.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
       
        //MOVEMENT
        Vector3 moveDirection = new Vector3(Input.GetAxis(leftHorAxis), 0, -Input.GetAxis(leftVerAxis));

        moveDirection.x = Input.GetAxis(leftHorAxis);
        moveDirection.z = Input.GetAxis(leftVerAxis);
        Debug.Log("x: "+moveDirection.x+ "       y: " + moveDirection.z);

        //if (Input.GetAxis(leftHorAxis) != 1 && Input.GetAxis(leftHorAxis) != -1)
        //    moveDirection.x = 0;

        //if (Input.GetAxis(leftVerAxis) != 1 && Input.GetAxis(leftVerAxis) != -1)
        //    moveDirection.z = 0;

        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            Vector3 dir = moveDirection.normalized;
            transform.forward = dir;
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
        //END MOVEMENT

        //INTERACTION
        if (Input.GetButton(xBut)) {
            Debug.Log(xBut);
            FindNearestNode();
        }


    }

    void FindNearestNode() {

        float shortestDist = Mathf.Infinity;
        GameObject nearestNode = null;

        foreach (Transform node in GameManager.instance.nodes)
        {
            float distToEnemy = Vector3.Distance(transform.position, node.transform.position);
            if (distToEnemy < shortestDist)
            {
                nearestNode = node.gameObject;
                shortestDist = distToEnemy;
            }
        }

        if (nearestNode != null && Math.Round(shortestDist,1) <= actionRadius)
        {
            nearestNode.GetComponent<Node>().Test();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, actionRadius);
    }
}
