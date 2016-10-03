using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerInstantiation : MonoBehaviour {

    [SerializeField]
    private GameObject[] characters;

    void OnEnable()
    {
        SceneManager.activeSceneChanged += InstantiatePlayer;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= InstantiatePlayer;
    }

    void InstantiatePlayer(Scene prev, Scene next)
    {
        int characterNumber = CharacterSelection.characterSelected;

        switch (next.buildIndex)
        {
            case 1:
            case 2:
            case 3:
                for (int i = 0; i < characters.Length; i++)
                {
                    if (characterNumber == i)
                    {
                        Instantiate(characters[i], Vector2.left * 5, Quaternion.identity);
                        break;
                    }
                }
                break;
        }
    }

}