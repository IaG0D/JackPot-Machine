using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue; //Random
    private float timeInterval; // Tempo para trocar os itens

    public bool rowStopped; //Verificar se o slot parou
    public string stoppedSlot;
    // Start is called before the first frame update
    void Start() {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
    }
    private void StartRotating() {
        stoppedSlot = "";
        StartCoroutine("Rotate");

    }
    private IEnumerator Rotate() {
        rowStopped = false;
        timeInterval = 0.025f;
        randomValue = Random.Range(60, 100);
        for (int i = 0; i < randomValue; i++) {
            if (transform.position.y <= -3.5f) {
                transform.position = new Vector2(transform.position.x, 1.75f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            if (i > Mathf.RoundToInt(randomValue * 0.25f)) timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f)) timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f)) timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f)) timeInterval = 0.2f;
            yield return new WaitForSeconds(timeInterval);
        }
        switch (transform.position.y) {
            case -3.5f:
                stoppedSlot = "Diamond";
                break;
            case -2.75f:
                stoppedSlot = "Crow";
                break;
            case -2f:
                stoppedSlot = "Melon";
                break;
            case -1.25f:
                stoppedSlot = "Bar";
                break;
            case 0.5f:
                stoppedSlot = "Seven";
                break;
            case 0.25f:
                stoppedSlot = "Cherry";
                break;
            case 1f:
                stoppedSlot = "Dfilitto";
                break;
            case 1.25f:
                stoppedSlot = "Diamond";
                break;
            default:
                stoppedSlot = "";
                break;
        }
        rowStopped = true;
    }
    private void OnDestroy() {

        GameControl.HandlePulled -= StartRotating;

    }
}
