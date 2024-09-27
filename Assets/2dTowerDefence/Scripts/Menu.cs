using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TDF
{
    public class Menu : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI currencyUI;
        [SerializeField] Animator anim;

        private bool isMenuOpen = true;

        public void ToggleMenu()
        {
            isMenuOpen = !isMenuOpen; //reverse everytime it's called
            anim.SetBool("MenuOpen", isMenuOpen);
        }

        private void OnGUI()
        {
            currencyUI.text = LevelManager.main.currency.ToString();
        }

  /*   public void SetSelected()
        {

        }*/
    }
}
