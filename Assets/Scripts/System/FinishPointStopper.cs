using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public class FinishPointStopper : MonoBehaviour
    {
        [SerializeField] private SOGameManager _manager;
        [SerializeField] private CanvasManager _canvasManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<SwerveSystem>().ForwardSpeed = 0;

                Invoke(nameof(LoseCheck), 2f);
            }
        }

        private void LoseCheck()
        {
            if (!_manager.IsWin)
            {
                _canvasManager.Set(3);
            }
        }
    }
}
