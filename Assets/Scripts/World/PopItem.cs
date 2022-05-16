using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RedPanda.Randoming;

namespace RedPanda
{
    [RequireComponent(typeof(Rigidbody))]
    public class PopItem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _body;
        private Vector3 popForce;
        private bool _forceEnabled = false;

        private void Start()
        {
            if (_body == null)
            {
                _body = GetComponent<Rigidbody>();
            }

            int randomColor = RandomInt(6);

            if (randomColor == 0)
            {
                GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            else if (randomColor == 1)
            {
                GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (randomColor == 2)
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (randomColor == 3)
            {
                GetComponent<MeshRenderer>().material.color = Color.magenta;
            }
            else if (randomColor == 4)
            {
                GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else if (randomColor == 5)
            {
                GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }
        private void FixedUpdate()
        {
            if (!_forceEnabled)
            {
                _body.AddForce(new Vector3(0, RandomFloat(1), 0), ForceMode.Impulse);
                _forceEnabled = true;
            }
        }
    }
}