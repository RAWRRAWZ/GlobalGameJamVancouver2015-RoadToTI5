using UnityEngine;
using System.Collections;

public class SwordImpactDelay : MonoBehaviour {


private float nextUsage;
private float delay=0.5f;//two seconds delay.

void Start()
{
	nextUsage = Time.time + delay;
}

void Update()
{
	if (Time.time > nextUsage)
	{
		nextUsage = Time.time + delay;
			SoundManager.instance.Play ("SliceImpact"); }	
	}}