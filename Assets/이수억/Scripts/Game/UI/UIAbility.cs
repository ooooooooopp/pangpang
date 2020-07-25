using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIAbility : MonoBehaviour
    {
        public Button button;
        public Image image;
        public Text txtName;

        AbilityKind kind;
        Character c;

        public void Init(AbilityKind kind, Character c)
        {
            this.kind = kind;
            this.c = c;
            txtName.text = kind.ToString();
        }

        public void OnGetAbility()
        {
            c.abilityCon.AddAbility( kind );
            button.interactable = false;
            image.color = Color.green;
        }
    }
}
