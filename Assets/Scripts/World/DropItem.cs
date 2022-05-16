using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RedPanda.Randoming;

namespace RedPanda
{
    public class DropItem : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Road"))
            {
                Explode();
                this.gameObject.SetActive(false);
            }
        }

        private void Explode()
        {
            int _amount = RandomInt(1, 10);

            for (int i = 0; i < _amount; i++)
            {
                GameObject go = Instantiate(_prefab);
                go.transform.position = new Vector3(this.transform.position.x + RandomFloat(0.25f), RandomFloat(0.5f), this.transform.position.z + RandomFloat(0.25f));
            }
        }
    }
}