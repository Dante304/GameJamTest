using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWherToStay : MonoBehaviour
{
	public float maxX;
	public float maxY;
	public Vector3 PointAroundTarget(Vector3 targetPosition)
	{
		Debug.Log($@"Target position: {targetPosition}");
		targetPosition.x = targetPosition.x + Random.Range(-maxX, maxX);
		targetPosition.y = targetPosition.y + Random.Range(-maxY, maxY );

		return targetPosition;
	}
}
