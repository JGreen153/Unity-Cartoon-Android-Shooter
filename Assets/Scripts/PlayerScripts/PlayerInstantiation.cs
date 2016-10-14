using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerInstantiation : MonoBehaviour {

    //an array of ships/characters
    [SerializeField]
    private GameObject[] characters;

    void OnEnable()
    {
        //when the scene is changed call the method InstantiatePlayer
        SceneManager.activeSceneChanged += InstantiatePlayer;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= InstantiatePlayer;
    }

    void InstantiatePlayer(Scene prev, Scene next)
    {
                for (int i = 0; i < characters.Length; i++)
                {
                    //loop through all the characters and see if characterSelected is equal to their position in the array...
                    if (CharacterSelection.characterSelected == i)
                    {
                        //...then instantiate the character whose position equaled characterSelected
                        Instantiate(characters[i], Vector2.left * 5, Quaternion.identity);
                        break;
                    }
                }
    }

}