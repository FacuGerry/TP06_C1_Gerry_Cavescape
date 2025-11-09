using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameCompleted : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleted;

    [Header("Buttons")]
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnMainMenu;

    [Header("Data")]
    [SerializeField] private CoinsDataSo coinsData;
    [SerializeField] private PlayerPrefsSo playerPrefs;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI maxCoinsText;
    [SerializeField] private TextMeshProUGUI gamesPlayedText;
    [SerializeField] private TextMeshProUGUI gamesWonText;

    private void Start()
    {
        btnReplay.onClick.AddListener(ReplayClicked);
        btnMainMenu.onClick.AddListener(MainMenuClicked);
    }

    private void OnEnable()
    {
        DoorController.onDoorCollisioned += OnDoorCollisioned_LevelCompleteUiAppear;
    }

    private void OnDisable()
    {
        DoorController.onDoorCollisioned -= OnDoorCollisioned_LevelCompleteUiAppear;
    }

    private void OnDestroy()
    {
        btnReplay.onClick.RemoveAllListeners();
        btnMainMenu.onClick.RemoveAllListeners();
    }

    public void OnDoorCollisioned_LevelCompleteUiAppear(DoorController doorController)
    {
        Time.timeScale = 0f;
        if (coinsData.coins > playerPrefs.maxCoinsCollected)
            playerPrefs.maxCoinsCollected = coinsData.coins;
        maxCoinsText.text = playerPrefs.maxCoinsCollected.ToString("0");
        gamesPlayedText.text = playerPrefs.gamesPlayed.ToString("0");
        playerPrefs.gamesWon++;
        gamesWonText.text = playerPrefs.gamesWon.ToString("0");
        levelCompleted.SetActive(true);
    }

    public void ReplayClicked()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1f;
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
