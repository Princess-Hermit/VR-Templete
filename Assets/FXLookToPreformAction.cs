using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXLookToPreformAction : MonoBehaviour
{
	public GameObject selectableObject;
	public GameObject effect;
	public long activateTimeSec;

	private int itemSelected = 0;
	private int timer = 0;

	// Use this for initialization
	void Start ()
	{
		;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Get the positions from the objects
		Vector3 player_vector = this.transform.position;
		Vector3 object_vector = selectableObject.transform.position;

		//Create the two raycasts and get the objects they hit
		RaycastHit headset_hit;
		Physics.Raycast(player_vector, this.transform.forward, out headset_hit);//headset_point_vector - player_vector

		//Calculate time sence 1970
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

		try
		{
			if (headset_hit.collider.gameObject == selectableObject)
			{
				if(timer == 0)
				{
					timer = cur_time;
				}
			}
			else
			{
				timer = 0;
			}
		}
		catch(System.Exception e)
		{
			timer = 0;
		}

		if(timer != 0 && cur_time - timer == activateTimeSec)
		{
			print("Preform Action");
			effect.SetActive (true);
			effect.GetComponent<AudioSource> ().Play();
			effect.GetComponent<ParticleSystem> ().Play ();

		}
		
	}
}