using System;
using System.Collections;
using UnityEngine;

namespace Game.Mechanics.PLayer
{
    public class PlayerDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private float timeToRestartLevel;
        public Action playerKilled;
        public void GetDamage()
        {
            StartCoroutine(CorpseRemovalTimer());
        }

        IEnumerator CorpseRemovalTimer()
        { 
            playerKilled?.Invoke();
            yield return new WaitForSeconds(timeToRestartLevel);
            GameManager.LevelEnd(true);
            Destroy(gameObject);
        }
    }
}
