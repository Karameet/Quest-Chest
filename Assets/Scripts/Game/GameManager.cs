using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameDataManager gameDataManager;
    [SerializeField] private Notification notification;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);

        gameDataManager.Init();
        uiManager.Init();
        soundManager.Init();
    }

    public void SandNotification(string message)
    {
        notification.SetMessage(message);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            soundManager.PlayerAudioWith(SoundType.UIButton);
    }
}
