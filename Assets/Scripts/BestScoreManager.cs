using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public string playerName;
    public int points;

    public void Start()
    {
        LoadBestScore();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class BestScore
    {
        public string playerName;
        public int points;
    }

    public void UpdateBestScore(string newPlayerName, int newPoints)
    {
        playerName = newPlayerName;
        points = newPoints;
    }

    public void SaveBestScore()
    {
        BestScore data = new BestScore();
        data.playerName = playerName;
        data.points = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);

            BestScore data = JsonUtility.FromJson<BestScore>(json);
            playerName = data.playerName;
            points = data.points;
        }
    }
}
