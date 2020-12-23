using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
	WaveConfig waveConfig;
	List<Transform> waypoints;

	int waypointIndex = 0;

	void Start()
	{
		waypoints = waveConfig.GetWayPoints();
		//Vector3 start = new Vector3(-5.0f, 0.5f, -4.0f);
		//transform.position = waypoints[waypointIndex].transform.position;
		//transform.position = start;
		transform.position = waypoints[waypointIndex].transform.position;
	}

	void Update()
	{
		Move();
	}

	public void SetWaveConfig(WaveConfig waveConfig)
    {
		this.waveConfig = waveConfig;
    }

	//void Move()
	//{
	//	transform.position = Vector2.MoveTowards(transform.position,
	//											waypoints[waypointIndex].transform.position,
	//											waveConfig.GetMoveSpeed() * Time.deltaTime);
	//	//Debug.Log("transform: " + transform.position);
	//	//Debug.Log("waypoint: " + waypoints[waypointIndex].transform.position);
	//	if (transform.position == waypoints[waypointIndex].transform.position)
	//	{
	//		waypointIndex = waypointIndex % waypoints.Count;
	//		Debug.Log("WaypointIndex: " + waypointIndex);
	//	}

	//	if (waypointIndex == waypoints.Count)
	//		Destroy(gameObject);
	//}

	private void Move()
	{
		if (waypointIndex <= waypoints.Count - 1)
		{
			var targetPosition = waypoints[waypointIndex].transform.position;
			var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
			transform.position = Vector2.MoveTowards
				(transform.position, targetPosition, movementThisFrame);

			if (transform.position == targetPosition)
			{
				waypointIndex++;
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
