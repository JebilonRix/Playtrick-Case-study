using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedPanda
{
    [CreateAssetMenu(menuName = "GameManager")]
    public class SOGameManager : ScriptableObject
    {
        [SerializeField] private int _goal = 5;
        [SerializeField] private int _canvasIndex;
        private int _score;
        internal bool setCanvas;
        private bool _isWin = false;

        public int CanvasIndex { get => _canvasIndex; set => _canvasIndex = value; }
        public bool IsWin { get => _isWin; private set => _isWin = value; }

        private void OnDisable()
        {
            ResetManager();
        }
        private void OnEnable()
        {
            SetScore(SceneManager.GetActiveScene().name);
            ResetManager();
        }

        public void Button_Restart() => Button_LoadLevel(SceneManager.GetActiveScene().name);
        public void Button_LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
            SetScore(levelName);
            ResetManager();
        }
        public void SetActiveCanvas()
        {
            setCanvas = true;
        }
        public void Button_StartStop(bool _isPreesed)
        {
            if (_isPreesed)
            {
                SetTimeScale(GameIs.Start);
            }
            else
            {
                SetTimeScale(GameIs.Stop);
            }
        }
        public void ScoreCounter()
        {
            _score++;

            if (_goal >= _score)
            {
                CanvasIndex = 2;
                SetActiveCanvas();
                IsWin = true;
            }
        }

        private void ResetManager()
        {
            _score = 0;
            IsWin = false;
            CanvasIndex = 0;
            SetActiveCanvas();
            SetTimeScale(GameIs.Stop);
        }
        private void SetTimeScale(GameIs _gameIs)
        {
            switch (_gameIs)
            {
                case GameIs.Stop:

                    Time.timeScale = 0;
                    break;

                case GameIs.Start:

                    Time.timeScale = 1;
                    break;
            }
        }
        private void SetScore(string sceneName)
        {
            if (sceneName == "Level1")
            {
                _goal = 5;
            }
            else if (sceneName == "Level2")
            {
                _goal = 10;
            }
        }
        private enum GameIs
        {
            Stop,
            Start
        }
    }
}