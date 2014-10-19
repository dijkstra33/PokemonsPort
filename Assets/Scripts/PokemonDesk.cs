using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PokemonDesk : MonoBehaviour
    {
        public SpriteManager SpriteManager;
        public Canvas Canvas;

        public PokemonButton[,] Pokemons;

        public int PokemonsInRow = 4;
        public int PokemonsInCol = 5;
        
        public RectTransform PokemonButtonPrefab;

        private float screenWidth;
        private float screenHeight;

        private const float spriteWidth = 500f;
        private const float spriteHeight = 601f;

        private List<PokemonButton> activeButtons = new List<PokemonButton>(); 

        private System.Random random = new System.Random();

        private void Start ()
        {
            if ((this.PokemonsInRow * this.PokemonsInCol) % 2 != 0)
                throw new Exception("Incorrect number of pokemons!");

            this.Pokemons = new PokemonButton[this.PokemonsInCol, this.PokemonsInRow];

            screenWidth = Screen.width;
            screenHeight = Screen.height;

            float xCoef = this.screenWidth/spriteWidth/(PokemonsInRow);
            float yCoef = this.screenHeight/spriteHeight/(PokemonsInCol);

            float coef = Mathf.Min(xCoef, yCoef);

            float pokemonWidth = spriteWidth*coef;
            float pokemonHeight = spriteHeight * coef;

            float cellWidth = screenWidth / PokemonsInRow;
            float cellHeight = screenHeight /(float) PokemonsInCol;

            bool newPokemon = false;
            int pokemonNumber = 0;

            var indexes = new List<IntPair>();
            for (int i = 1; i < PokemonsInRow - 1; i++)
                for (int j = 2; j < PokemonsInCol - 2; j++)
                    indexes.Add(new IntPair{ I = i, J = j});

            for (int i = 0; i < PokemonsInRow*PokemonsInCol*5; i++)
            {
                int r1 = random.Next(PokemonsInCol);
                int r2 = random.Next(PokemonsInRow);

                SwapIndexes(indexes, r1, r2);
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                newPokemon = !newPokemon;
                if (newPokemon)
                    pokemonNumber = random.Next(SpriteManager.ImageList.Count);

                NewPokemon(indexes[i].I, indexes[i].J, cellWidth, pokemonWidth, cellHeight, pokemonHeight, coef, pokemonNumber);
            }
        }

        private static void SwapIndexes(List<IntPair> indexes, int r1, int r2)
        {
            int i0 = indexes[r1].I;
            int j0 = indexes[r1].J;

            indexes[r1].I = indexes[r2].I;
            indexes[r1].J = indexes[r2].J;

            indexes[r2].I = i0;
            indexes[r2].J = j0;
        }

        private void NewPokemon(int i, int j, float cellWidth, float pokemonWidth, float cellHeight, float pokemonHeight,
            float coef, int pokemonNumber)
        {
            float xCenterPos = (i/(float) PokemonsInRow)*screenWidth - (screenWidth/2f) + cellWidth/2f - pokemonWidth/2;
            float yCenterPos = -(j/(float) PokemonsInCol)*screenHeight + (screenHeight/2f) - cellHeight/2f + pokemonHeight/2;

            var pokemonButton = (RectTransform) Instantiate(PokemonButtonPrefab);
            pokemonButton.transform.SetParent(Canvas.transform);
            pokemonButton.localPosition = new Vector3(xCenterPos, yCenterPos, 0);
            pokemonButton.localScale = new Vector3(coef*0.99f, coef*0.98f, 1);


            pokemonButton.gameObject.GetComponent<Image>().sprite = SpriteManager.ImageList[pokemonNumber];

            Pokemons[i - 1, j - 2] = pokemonButton.gameObject.GetComponent<PokemonButton>();
            Pokemons[i - 1, j - 2].PokemonType = SpriteManager.PokemonTypeList[pokemonNumber];
            Pokemons[i - 1, j - 2].PokemonButtonPressed += PokemonButtonPressed;
        }

        private void PokemonButtonPressed(PokemonButton pokemonButton)
        {
            if (pokemonButton.IsPressed)
            {
                this.activeButtons.Add(pokemonButton);
                if (activeButtons.Count > 2)
                {
                    activeButtons[0].IsPressed = false;
                    activeButtons[1].IsPressed = false;

                    activeButtons.RemoveAt(0);
                    activeButtons.RemoveAt(0);
                }
            }
            else
            {
                this.activeButtons.Remove(pokemonButton);
            }
        }

        internal class IntPair
        {
            public int I;
            public int J;
        }
    }
}
