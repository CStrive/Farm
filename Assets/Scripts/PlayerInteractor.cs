using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    PlayerController playercontroller;

    Land selectedland = null;

    private void Start()
    {
        playercontroller = transform.parent.GetComponent<PlayerController>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit,1))
        {
            OnInteractableHit(hit);
        }
    }

    private void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;
        if (other.CompareTag("Land"))
        {
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }
        
        if (selectedland != null)
        {
            selectedland.Select(false);
            selectedland = null;
        }

    }

    private void SelectLand(Land land)
    {
        if (selectedland != null)
        {
            selectedland.Select(false);
        }
        selectedland = land;
        land.Select(true);
    }

}
