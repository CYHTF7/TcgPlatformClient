using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLoadDTO 
{
    public int deckId { get; set; }
    public string deckName { get; set; }
    public int playerId { get; set; }
    public int order { get; set; }

    public List<DeckCardLoadDTO> cards { get; set; }
}
