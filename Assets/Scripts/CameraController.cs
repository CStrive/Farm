using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetZ = 8f;
    public float smoothing = 2f;
    private Transform playerPos;

    private void Start()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;

    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(playerPos.position.x
            , transform.position.y,
            playerPos.position.z - offsetZ);
        //transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    }
}
