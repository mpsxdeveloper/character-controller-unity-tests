using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("characterMedium").GetComponent<Player>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        
        switch(gameObject.name) {
            case "Right":
                player.SetRight(true);            
            break;
            case "Left":
                player.SetLeft(true);            
            break;
            case "Down":
                player.SetDown(true);            
            break;
            case "Up":
                player.SetUp(true);            
            break;
            case "A":
                player.SetJump(true);            
            break;
        }		

	}

	public void OnPointerUp(PointerEventData eventData) {

        switch(gameObject.name) {
            case "Right":
                player.SetRight(false);         
            break;
            case "Left":
                player.SetLeft(false);            
            break;
            case "Down":
                player.SetDown(false);            
            break;
            case "Up":
                player.SetUp(false);
            break;
        }

	}

}