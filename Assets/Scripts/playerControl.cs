using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed;

    // The prefab of the cube to instantiate
    public GameObject PickUp;

    // A dictionary to store the original positions of the pickup objects, indexed by their unique identifier
    Dictionary<int, Vector3> pickupPositions = new Dictionary<int, Vector3>();

    // Update is called once per frame
    void Update()
    {
        // Get the player's input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the player's Rigidbody component
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with a pickup object
        if (other.gameObject.tag == "PickUp")
        {
            // Get the pickup object's unique identifier
            int id = other.gameObject.GetInstanceID();

            // Save the cube's original position
            pickupPositions[id] = other.gameObject.transform.position;

            // Deactivate the pickup object
            other.gameObject.SetActive(false);

            // Spawn the cube after 3 seconds
            SpawnCube(id);

            // Add point for the player
            ScoreManager.instance.addPoint();
        }
    }

    // Method to instantiate a new cube
    void SpawnCube(int id)
    {
        // Get the original position of the pickup object
        Vector3 originalPosition = pickupPositions[id];

        // Start a timer that will spawn the cube after 3 seconds
        StartCoroutine(WaitAndSpawn(3.0f, originalPosition));
    }

    IEnumerator WaitAndSpawn(float waitTime, Vector3 originalPosition)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Instantiate a new cube at the original position of the pickup object
        GameObject newCube = Instantiate(PickUp, originalPosition, Quaternion.identity);
    }
}
