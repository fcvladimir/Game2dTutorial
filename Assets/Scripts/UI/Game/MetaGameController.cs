using Platformer.Mechanics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high level
    /// contexts of the application, eg the Main Menu and Gameplay systems.
    /// </summary>
    public class MetaGameController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which used for the menu.
        /// </summary>
        public GameObject uiCanvas;
        public GameObject anyPlaceCheckPointButton;
        public GameObject halfwayCheckPoint;
        private GameObject newSpawnPoint;
        public Button pauseButton;

        private readonly int totalSceneCount = 10;

        /// <summary>
        /// The game controller.
        /// </summary>
        public GameController gameController;

        private bool showMainCanvas = false;

        void Awake()
        {
            gameController.model.player.UpdateColor();
            GameKeys.DifficultyMode mode = (GameKeys.DifficultyMode)GamePreferences.DifficultyMode;
            switch (mode)
            {
                case GameKeys.DifficultyMode.Easy:
                    InitAnyPlaceCheckPoint();
                    break;

                case GameKeys.DifficultyMode.Medium:
                    InitHalfwayCheckPoint();
                    break;

                case GameKeys.DifficultyMode.Hard:
                    // do nothing. "Hard" - default mode
                    break;
            }
        }

        void Start()
        {
            InitHeroNameHint();
        }

        private void OnEnable()
        {
            _ToggleMainMenu(showMainCanvas);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (showMainCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        private void _ToggleMainMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            uiCanvas.SetActive(show);
            pauseButton.interactable = !show;
            showMainCanvas = show;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                ToggleMainMenu(show: !showMainCanvas);
            }
        }

        public void StartLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        public void NextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == totalSceneCount)
            {
                StartLevel(1);
            }
            else
            {
                StartLevel(currentSceneIndex + 1);
            }
        }

        private void InitHeroNameHint()
        {
            GameObject heroNameHint = GameObject.Find("HeroNameText");
            if (heroNameHint != null)
            {
                var name = GamePreferences.SelectedHero == 0 ? GameKeys.LEFT_HERO_NAME : GameKeys.RIGHT_HERO_NAME;
                heroNameHint.GetComponent<TextMeshProUGUI>().text = "Go, " + name + "!";
                Color spriteRendererColor;
                if (GamePreferences.SelectedHero == 0)
                {
                    spriteRendererColor = new Color(0f, 0.4990942f, 1f, 1f);
                }
                else
                {
                    spriteRendererColor = new Color(0f, 0.63869f, 1f, 1f);
                }
                heroNameHint.GetComponent<TextMeshProUGUI>().color = spriteRendererColor;
            }
        }

        private void InitAnyPlaceCheckPoint()
        {
            anyPlaceCheckPointButton.SetActive(true);
        }

        private void InitHalfwayCheckPoint()
        {
            halfwayCheckPoint.SetActive(true);
            GameObject edew = halfwayCheckPoint.GetComponent<GameObject>();
        }

        public void SetNewSpawnPosition()
        {
            gameController.model.spawnPoint.position = gameController.model.player.transform.position;
            if (newSpawnPoint == null)
            {
                newSpawnPoint = new GameObject("CrystalSpawnPoint");

                SpriteRenderer img = newSpawnPoint.AddComponent<SpriteRenderer>();
                img.sprite = Resources.Load<Sprite>("Props/Crystal");

                Vector2 spriteSize = img.sprite.bounds.size;
                Vector3 desiredSize = new(0.5f, 0.5f, 1f);

                newSpawnPoint.transform.localScale = new Vector3(
                    desiredSize.x / spriteSize.x,
                    desiredSize.y / spriteSize.y,
                    1f
                );
            }
            newSpawnPoint.transform.position = gameController.model.spawnPoint.position;
        }
    }
}
