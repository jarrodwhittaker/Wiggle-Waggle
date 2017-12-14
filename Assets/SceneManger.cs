using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManger : MonoBehaviour {

    public static SceneManger Instance;

    private int indexId;
    private string levelToLoadName = "";
    public List<string> levelNames = new List<string>();


    //private AssetBundle myLoadedAssetBundles;
    //private string[] scenePaths;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        //myLoadedAssetBundles = AssetBundle.LoadFromFile("Assets/Scenes/MiniGames");
        //scenePaths = myLoadedAssetBundles.GetAllScenePaths();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RandomGame()
    {
        //SceneManager.LoadScene(scenePaths[Random.Range(0, scenePaths.Length)], LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
        indexId = Random.Range(0, levelNames.Count);

        levelToLoadName = levelNames[indexId];
        SceneManager.LoadScene(levelToLoadName, LoadSceneMode.Additive);
    }
}
