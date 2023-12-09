using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public GameObject player_1; // Reference to Player 1 object
    public Sprite[] cardSprites; // Array to store card sprites
    public int numberOfCards = 13; // Number of cards to deal

    private List<Sprite> shuffledCards = new List<Sprite>(); // List to store shuffled card sprites

    void Start()
    {
        ShuffleCards();
        DealCards(player_1);
    }

    // Shuffle the card sprites using Fisher-Yates algorithm
    void ShuffleCards()
    {
        shuffledCards.AddRange(cardSprites);

        System.Random rng = new System.Random();
        int n = shuffledCards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Sprite value = shuffledCards[k];
            shuffledCards[k] = shuffledCards[n];
            shuffledCards[n] = value;
        }
    }

    // Deal cards to the specified player
    void DealCards(GameObject player)
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned!");
            return;
        }

        // Define an array of positions for each card
        Vector3[] cardPositions = new Vector3[13];
        // Assign specific positions to each card
        cardPositions[0] = new Vector3(1.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);
        cardPositions[1] = new Vector3(2.0f, 0.0f, 0.0f);

        // ... Assign positions for the rest of the cards

        for (int i = 0; i < numberOfCards; i++)
        {
            // Get the card sprite
            Sprite cardSprite = shuffledCards[i];

            // Instantiate a new card object
            GameObject cardObject = new GameObject("Card_" + i);
            cardObject.transform.SetParent(player.transform);

            // Set the card position from the array
            if (i < cardPositions.Length)
            {
                cardObject.transform.position = cardPositions[i];
            }
            else
            {
                Debug.LogWarning("Not enough positions defined for all cards.");
            }


            // Add a SpriteRenderer component to the card object
            SpriteRenderer spriteRenderer = cardObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            // Set the sorting layer and order
            spriteRenderer.sortingLayerName = "Forgrund"; // Change "Cards" to your desired sorting layer name
        }
    }
}
