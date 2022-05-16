using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RedPanda
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private SOGameManager _manager;
        [SerializeField] private GameObject[] _canvases;

        private void Update()
        {
            if (!_manager.setCanvas)
            {
                return;
            }

            Set(_manager.CanvasIndex);

            _manager.setCanvas = false;
        }
        public void Set(int index)
        {
            for (int i = 0; i < _canvases.Length; i++)
            {
                _canvases[i].SetActive(index == i);
            }
        }
    }
}