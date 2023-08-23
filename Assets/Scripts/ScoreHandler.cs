using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        private int StartScorintValue = 1;
        void Start()
        {
            textMeshPro.text = StartScorintValue.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if(!GameManager.Instance.IsGameOver)
            {
                textMeshPro.text = (++StartScorintValue).ToString();
                Console.WriteLine((StartScorintValue).ToString());
            }
        }
    }
}