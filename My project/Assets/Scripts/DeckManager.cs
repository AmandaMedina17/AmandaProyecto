using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    public Button player1DeckButton; // Asigna el botón del mazo Greekgods
    public Button player2DeckButton; // Asigna el botón del mazo Nordicgods
    public GameObject player1HandObject; // Referencia al GameObject de la mano del jugador 1
    public GameObject player2HandObject; // Referencia al GameObject de la mano del jugador 2

    public GameObject GreekLeaderObject;
    public GameObject NordicLeaderObject;
   


    public static List<UnityBaseCard> player1Deck;
    public static List<UnityBaseCard> player2Deck;

    public static UnityBaseCard GreekLeader;
    public static UnityBaseCard NordicLeader;


    private void Start()
    {
        // Inicializa los mazos
        player1Deck = CreateDeck("GreekGods");
        player2Deck = CreateDeck("NordicGods");

        //Inicilizar lideres
        GreekLeader = GetLeader("GreekGods");
        NordicLeader = GetLeader("NordicGods");


           // Reparte 10 cartas a cada jugador
        DealCards(player1Deck, player1HandObject);
        DealCards(player2Deck, player2HandObject);

        DealCardLeader(GreekLeader, GreekLeaderObject);
        DealCardLeader(NordicLeader, NordicLeaderObject);

        // Asigna la acción de clic a los botones
        player1DeckButton.onClick.AddListener(() => ShowDeck(player1Deck));
        player2DeckButton.onClick.AddListener(() => ShowDeck(player2Deck));
    }

    private List<UnityBaseCard> CreateDeck(string name)
    {
        // Lógica para crear el mazo basado en el nombre
        return name == "GreekGods" ? DeckScript.CreateDeck("GreekGods") : DeckScript.CreateDeck("NordicGods");
    }

    private UnityBaseCard GetLeader(string name)
    {
        return name == "GreekGods" ? DeckScript.GetLeader("GreekGods") : DeckScript.GetLeader("NordicGods");
    }

    private void ShowDeck(List<UnityBaseCard> deck)
    {
        // Lógica para mostrar las cartas del mazo (puedes implementar la visualización aquí)
        foreach (var card in deck)
        {
            Debug.Log($"Carta en el mazo: {card.Name}"); // Muestra el nombre de la carta en la consola
        }
    }

    private void DealCards(List<UnityBaseCard> deck, GameObject handObject)
    {
        // Asegúrate de que el mazo tenga suficientes cartas
        if (deck.Count < 10)
        {
            Debug.LogError("No hay suficientes cartas en el mazo.");
            return;
        }

        // Baraja el mazo
        List<UnityBaseCard> shuffledDeck = deck.OrderBy(x => Random.value).ToList();

        // Obtén el script de la mano del GameObject
        ScriptZone hand = handObject.GetComponent<ScriptZone>();

        // Agrega las primeras 10 cartas a la lista de la mano
        for (int i = 0; i < 10; i++)
        {
            hand.Cards.Add(shuffledDeck[i]);
        }

        hand.UpdateList();

        // Elimina las cartas repartidas del mazo
        deck.RemoveRange(0, 10);
    }

    private void DealCardLeader(UnityBaseCard leader, GameObject leaderobject)
    {
        ScriptZone leaderobj = leaderobject.GetComponent<ScriptZone>();

        leaderobj.Cards.Add(leader);

        leaderobj.UpdateList();

    }

    
}