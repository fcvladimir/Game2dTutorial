using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {

        public GameObject finishCanvas;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
                finishCanvas.SetActive(true);
            }
            UnlockNextLevel();
        }

        private void UnlockNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            switch (currentSceneIndex)
            {
                case 1:
                    GamePreferences.LevelAccess2 = true;
                    break;
                case 2:
                    GamePreferences.LevelAccess3 = true;
                    break;
                case 3:
                    GamePreferences.LevelAccess4 = true;
                    break;
                case 4:
                    GamePreferences.LevelAccess5 = true;
                    break;
                case 5:
                    GamePreferences.LevelAccess6 = true;
                    break;
                case 6:
                    GamePreferences.LevelAccess7 = true;
                    break;
                case 7:
                    GamePreferences.LevelAccess8 = true;
                    break;
                case 8:
                    GamePreferences.LevelAccess9 = true;
                    break;
                case 9:
                    GamePreferences.LevelAccess10 = true;
                    break;
            }
        }
    }
}