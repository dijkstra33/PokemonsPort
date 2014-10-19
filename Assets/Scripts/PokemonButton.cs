using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PokemonButton: MonoBehaviour
    {
        public event Action<PokemonButton> PokemonButtonPressed;

        public Button Button;
        public Image Image;

        public PokemonType PokemonType;

        private bool isPressed = false;

        public bool IsPressed
        {
            get { return this.isPressed; }
            set
            {
                if (value == true)
                {
                    StartCoroutine(FadeOut());    
                }
                else
                {
                    StartCoroutine(FadeIn());
                }
                
                isPressed = value;

                if (PokemonButtonPressed != null)
                    PokemonButtonPressed(this);
            }
        }

        public void Pressed()
        {
            this.IsPressed = !this.IsPressed;
        }

        public IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(this.Button.colors.fadeDuration);
            this.Image.color = this.Button.colors.highlightedColor;
        }

        public IEnumerator FadeIn()
        {
            yield return new WaitForSeconds(this.Button.colors.fadeDuration);
            this.Image.color = Color.white;
        }
    }
}
