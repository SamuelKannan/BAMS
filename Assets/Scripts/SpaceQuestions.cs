using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpaceQuestions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Question1;
    [SerializeField] TextMeshProUGUI Answer1;
    [SerializeField] TextMeshProUGUI Answer2;
    [SerializeField] TextMeshProUGUI Answer3;
    [SerializeField] TextMeshProUGUI Answer4;

    int randomInt;
    string[] questions = { "What planet is covered by clouds of sulphuric acid?",
        "Which planet is named after the Roman god of war ?",
        "Which planet is closest to the sun ?",
        "What celestial body lost its status as a planet in 2006 ?",
        "What name was given to the invisible material once thought to occupy all space?" };

    private void Update()
    {
        randomInt = Random.Range(0,4);
        Debug.Log(questions[randomInt]);
    }

}
