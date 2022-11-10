using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text prizeText;

    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform handle;

    private int prizeValue;
    private bool resultsChecked = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped) {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped) {
            //CheckResults()
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;
        }
    }
}
