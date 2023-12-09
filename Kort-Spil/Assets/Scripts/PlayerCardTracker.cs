using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardTracker : MonoBehaviour
{
    public GameObject Player_1; // Reference to the Player object

    private List<string> playerCards = new List<string>(); // List to store player's card names

    void Start()
    {
        // Assuming cards have been dealt already by CardDealer script
        // You can call this function when you need to update the player's card information
        UpdatePlayerCards();
        ShowPlayerCards();
    }

    // Add a card to the player's card list
    public void AddCard(string cardName)
    {
        playerCards.Add(cardName);
    }

    // Update the player's card list (you may need to customize this based on your game logic)
    void UpdatePlayerCards()
    {
        playerCards.Clear(); // Clear the existing card list

        foreach (Transform cardTransform in Player_1.transform)
        {
            // Assuming the card names are stored as GameObject names (e.g., "Card_1")
            string cardName = cardTransform.gameObject.name.Replace("Card_", "");
            playerCards.Add(cardName);
        }
    }

    // Display player's cards in the console (you can modify this based on your UI or game logic)
    void ShowPlayerCards()
    {
        Debug.Log("Player's Cards:");
        foreach (string card in playerCards)
        {
            Debug.Log(card);
        }
    }
}
