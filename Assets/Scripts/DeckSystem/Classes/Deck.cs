using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public class Deck 
{
    public int DeckId { get; set; }   
    public string DeckName { get; set; }
    public int PlayerId { get; set; }

    public List<DeckCard> Cards { get; set; }
}
