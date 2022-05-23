using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private PlayerManager _playerManager;

        [SerializeField] private Transform startPoint;
        [SerializeField] private GameObject playerPrefab;

        private void Awake()
        {
            _playerManager = FindObjectOfType<PlayerManager>(); 
            if (_playerManager == null)
            {
                Instantiate(playerPrefab, startPoint);
                _playerManager = FindObjectOfType<PlayerManager>();
            }
        }

        private void FinishReached()
        {
            Debug.Log("I reached finish!!");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        private void OnEnable()
        { 
           
            _playerManager.onFinishReached += FinishReached;
        }

        private void OnDisable()
        { 
            _playerManager.onFinishReached -= FinishReached;
        }
    }
}
