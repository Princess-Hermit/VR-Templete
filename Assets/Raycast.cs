using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Beat_Puzzle_Raycast : MonoBehaviour
{
    public GameObject hidden_player_point;
    public GameObject hidden_object_point;
    public GameObject Exit;

    public AudioSource completion_music;
    public Light completion_light;

    private bool raycast_triggered = false;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the positions from the objects
        Vector3 player_vector = this.transform.position;
        Vector3 headset_point_vector = hidden_player_point.transform.position;
        Vector3 object_point_vector = hidden_object_point.transform.position;

        //Create the two raycasts and get the objects they hit
        RaycastHit headset_hit;
        RaycastHit object_hit;

        Physics.Raycast(player_vector, this.transform.forward, out headset_hit);//headset_point_vector - player_vector
        Physics.Raycast(player_vector, object_point_vector - player_vector, out object_hit);

        //See if the player has solved the puzzle.
        if ((headset_hit.collider.gameObject == hidden_player_point) && (object_hit.collider.gameObject == hidden_player_point))
        {
            if (raycast_triggered == false)
            {
                //Play the puzzle finished music
                completion_music.Play();

                //Play the light animation
                completion_light.GetComponent<Animation>().Play();

                //Make portal visible
                Exit.SetActive(true);

                //Make sure the play can't trigger the music and animation again
                raycast_triggered = true;
            }
            Debug.Log("Raycast has triggered. Go to Next Scene");
        }


    }
}
