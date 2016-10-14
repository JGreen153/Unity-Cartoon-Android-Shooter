using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    //enums that represent the different ships the player can choose
    public enum SHIP
    {
        FIRST,
        SECOND,
        THIRD
    };

    //initialise the ship variable as the first ship
    private SHIP ship = SHIP.FIRST;

    //the amount of medals required to unlock the "smile" ship and the "fish" ship, respectively
    [SerializeField]
    private float medalsForSmileShip, medalsForFishShip;

    //three sprites that show the ship that's currently selected
    [SerializeField]
    private Sprite firstShip, secondShip, thirdShip;

    //text that says whether or not a ship is unlocked
    [SerializeField]
    private Text lockedText;

    //text saying the amount of medals required to unlock a ship
    [SerializeField]
    private Text medalAmountText;

    //used to determine which character was selected and instantiate at runtime
    public static int characterSelected; 

    void Start()
    {
        characterSelected = 0;

        lockedText.text = "";
        medalAmountText.text = "x0";
    }

    //moves to the ship that's on the left of the one currently selected
    public void ChangeToLeftCharacter()
    {
        Sprite playerShip = GetComponent<SpriteRenderer>().sprite;

        switch (ship)
        {
            //if we're on the second ship...
            case SHIP.SECOND:

                //...change the text to say it isn't locked...
                lockedText.text = "";
                //...and the medalAmountText to say there's no medals required
                medalAmountText.text = "x0";
                //static int is set to 0 to indicate the first ship has been chosen
                characterSelected = 0;

                //change the currently displayed sprite to the first ship
                playerShip = firstShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;

                //move to a different part of the switch statement
                ship = SHIP.FIRST;
                break;
            case SHIP.THIRD:

                //change the text to say locked to indicate that the ship hasn't been unlocked...
                lockedText.text = "Locked";
                //...and show the amount of medals required to unlock the ship
                medalAmountText.text = "x" + medalsForSmileShip;

                //if the player has the required amount of trophies then change the int characterSelected to ship selected
                //and remove the locked text over the ship 
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

    //moves to the ship that's on the right of the one currently selected
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