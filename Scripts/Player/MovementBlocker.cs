using System;
using UnityEngine;

namespace Player
{
    public class MovementBlocker : MonoBehaviour
    {
        private const string PLAYER = "Player";
        [SerializeField] private SiteType siteType;

        private void OnTriggerEnter(Collider col)
        {
            HandleCollision(col, true);
        }

        private void OnTriggerExit(Collider col)
        {
            HandleCollision(col, false);
        }

        private void HandleCollision(Collider col, bool isBlocked)
        {
            if (col.name == PLAYER)
            {
                var playerController = col.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    if (siteType == SiteType.Left)
                        playerController.IsBlockedLeft = isBlocked;
                    else
                        playerController.IsBlockedRight = isBlocked;
                }
            }
        }
    }
}