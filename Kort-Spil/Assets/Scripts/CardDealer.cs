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
        cardPositions[0] = new Vector3(-2.5f, -4.0f, 0.0f);
        cardPositions[1] = new Vector3(-1.5f, -4.0f, 0.0f);
        cardPositions[2] = new Vector3(-0.5f, -4.0f, 0.0f);
        cardPositions[3] = new Vector3(0.5f, -4.0f, 0.0f);
        cardPositions[4] = new Vector3(1.5f, -4.0f, 0.0f);
        cardPositions[5] = new Vector3(2.5f, -4.0f, 0.0f);
        cardPositions[6] = new Vector3(3.5f, -4.0f, 0.0f);
        cardPositions[7] = new Vector3(4.5f, -4.0f, 0.0f);
        cardPositions[8] = new Vector3(5.5f, -4.0f, 0.0f);
        cardPositions[9] = new Vector3(6.5f, -4.0f, 0.0f);
        cardPositions[10] = new Vector3(7.5f, -4.0f, 0.0f);
        cardPositions[11] = new Vector3(8.5f, -4.0f, 0.0f);
        cardPositions[12] = new Vector3(9.5f, -4.0f, 0.0f);

        // Define card names based on ranks and suits
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
        List<string> cardNames = new List<string>();

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                string cardName = rank + "_" + suit;
                cardNames.Add(cardName);
            }
        }

        for (int i = 0; i < numberOfCards; i++)
        {
            // Get the card sprite
            Sprite cardSprite = shuffledCards[i];

            // Get the card name
            string cardName = cardNames[i];

            // Instantiate a new card object with the card name
            GameObject cardObject = new GameObject(cardName);
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

            cardObject.transform.localScale = new Vector3(0.37f, 2.984342f, 1.0f);


            // Set the sorting layer and order
            spriteRenderer.sortingLayerName = "Forgrund"; // Change "Cards" to your desired sorting layer name
        }
    }
}
