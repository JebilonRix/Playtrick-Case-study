using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public class FinishBallCounter : MonoBehaviour
    {
        [SerializeField] private SOGameManager _gameManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ScoreBall"))
            {
                _gameManager.ScoreCounter();

                Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

                otherRigidbody.velocity = Vector3.zero;

                otherRigidbody.useGravity = false;
            }
        }
    }
}
