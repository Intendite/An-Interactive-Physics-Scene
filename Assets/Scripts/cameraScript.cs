using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject player;

    // The offset of the camera position
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Set the offset to the current camera position
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Update the camera position to follow the player
        transform.position = player.transform.position + offset;
    }
}