using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private PlayerManager _playerManager;
        private PlayerStats _playerStats;

        [SerializeField] private Transform startPoint;
        [SerializeField] private GameObject playerPrefab;

        private GameObject _player;

        private void Awake()
        {
            _player = GameObject.FindWithTag(TagManager.Player);

            if (_player == null)
            {
                _player =  Instantiate(playerPrefab, startPoint);
            }
            Instantiate();
        }

        private void Instantiate()
        {
            _playerStats = FindObjectOfType<PlayerStats>();
            _playerManager = FindObjectOfType<PlayerManager>();
            Subscribe();
        }
        
        private void FinishReached()
        {
            Debug.Log("I reached finish!!");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void RestartLevel()
        {
            UnSubscribe();
            Destroy(_player);
            _player = Instantiate(playerPrefab, startPoint);
            Instantiate();
        }
        
        
        
        private void Subscribe()
        {
            _playerManager.onFinishReached += FinishReached;
            _playerStats.onPlayerDeath += RestartLevel;
        }

        private void UnSubscribe()
        { 
            _playerManager.onFinishReached -= FinishReached;
            _playerStats.onPlayerDeath -= RestartLevel;
        }
    }
}
