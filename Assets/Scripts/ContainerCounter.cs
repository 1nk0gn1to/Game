using Entities;
using UnityEngine;

public class ContainerCounter : Counter
{
    public override void Interact()
    {
        Debug.Log("Clear Interact");
    }
}