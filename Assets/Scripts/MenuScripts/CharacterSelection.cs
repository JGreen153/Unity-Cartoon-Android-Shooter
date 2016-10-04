using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public enum SHIP
    {
        FIRST,
        SECOND,
        THIRD
    };

    private SHIP ship = SHIP.FIRST;

    [SerializeField]
    private float medalsForSmileShip, medalsForFishShip;

    [SerializeField]
    private Sprite firstShip, secondShip, thirdShip;

    [SerializeField]
    private Button leftButton, rightButton;

    [SerializeField]
    private Text lockedText;

    [SerializeField]
    private Text medalAmountText;

    public static int characterSelected; 

    void Start()
    {
        characterSelected = 0;

        lockedText.text = "";
        medalAmountText.text = "x0";
    }

    public void ChangeToLeftCharacter()
    {
        Sprite playerShip = GetComponent<SpriteRenderer>().sprite;

        switch (ship)
        {
            case SHIP.SECOND:

                lockedText.text = "";
                medalAmountText.text = "x0";

                characterSelected = 0;

                playerShip = firstShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;

                ship = SHIP.FIRST;
                break;
            case SHIP.THIRD:

                lockedText.text = "Locked";
                medalAmountText.text = "x" + medalsForSmileShip;

                if (TrophyCount.trophyCount >= medalsForSmileShip)
                {
                    characterSelected = 1;
                    lockedText.text = "";
                }

                playerShip = secondShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;

                ship = SHIP.SECOND;
                break;
        }
    }

    public void ChangeToRightCharacter()
    {
        Sprite playerShip = GetComponent<SpriteRenderer>().sprite;

        switch (ship)
        {
            case SHIP.FIRST:

                lockedText.text = "Locked";
                medalAmountText.text = "x" + medalsForSmileShip;

                if (TrophyCount.trophyCount >= medalsForSmileShip)
                {
                    characterSelected = 1;
                    lockedText.text = "";
                }
                    playerShip = secondShip;
                    GetComponent<SpriteRenderer>().sprite = playerShip;

                    ship = SHIP.SECOND;
                break;
            case SHIP.SECOND:

                lockedText.text = "Locked";
                medalAmountText.text = "x" + medalsForFishShip;

                if (TrophyCount.trophyCount >= medalsForFishShip)
                {
                    characterSelected = 2;
                    lockedText.text = "";
                }
                    playerShip = thirdShip;
                    GetComponent<SpriteRenderer>().sprite = playerShip;

                    ship = SHIP.THIRD;
                break;
        }
    }

}