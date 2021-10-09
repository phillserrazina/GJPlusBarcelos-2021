using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.UI
{
    public class MenuManager : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private Animator[] menus;
        private Animator currentMenu = null;

        public static MenuManager Instance { get; private set; }

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            Instance = this;
        }

        // METHODS
        public void SetMenuActive(string menuName)
        {
            if (menuName == null)
            {
                currentMenu.Play("OnExit");
                currentMenu = null;
                return;
            }

            if (currentMenu != null)
            {
                currentMenu.Play("OnExit");
            }

            currentMenu = GetMenu(menuName);
            currentMenu.gameObject.SetActive(true);
            currentMenu.Play("OnEnter");
        }

        private Animator GetMenu(string menuName)
        {
            foreach (var menu in menus)
            {
                if (menu.name == menuName)
                {
                    return menu;
                }
            }

            Debug.LogError($"MenuManager::GetMenu() --- No menu called {menuName} found.");
            return null;
        }
    }
}
