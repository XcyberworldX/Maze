using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveTo : MonoBehaviour {
    public GameObject spawnpoint;
    public GameObject waypoints;
    private List<Transform> waypointList = new List<Transform>();
    private Transform goal;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	    foreach(Transform item in waypoints.transform)
        {
            waypointList.Add(item);
        }

        ChooseWayPoint(waypointList);
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(agent.remainingDistance < 0.5f)
        {
            ChooseWayPoint(waypointList);
            agent.SetDestination(goal.transform.position);
        }
	}

    public void ChooseWayPoint(List<Transform> list)
    {
        System.Random rnd = new System.Random();
        int numb = rnd.Next(0, list.Count);

        goal = list[numb];
    }
}
