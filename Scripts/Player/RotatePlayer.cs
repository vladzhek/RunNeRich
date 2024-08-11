using System;
using Player;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private const string PLAYER = "Player";
    [SerializeField] private SiteType siteType;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.name is PLAYER)
        {
            if(siteType is SiteType.Left)
                col.gameObject.GetComponent<PlayerController>().TurnLeft();
            else
                col.gameObject.GetComponent<PlayerController>().TurnRight();
            
            Destroy(this);
        }
    }
}



