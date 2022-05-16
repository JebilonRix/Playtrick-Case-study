using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda
{
    public class LevelCount : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _roadEndPoint;
        [SerializeField] private Text _text;
        [SerializeField] private Image _image;
        private float _levelCount;

        private void Update()
        {
            _levelCount = _player.transform.position.z / _roadEndPoint.transform.position.z;
            _text.text = "%" + ((int)(_levelCount * 100)).ToString();
            _image.fillAmount = _levelCount;
        }
    }
}