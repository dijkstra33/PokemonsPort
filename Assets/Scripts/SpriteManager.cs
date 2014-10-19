using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteManager: MonoBehaviour
    {
        public List<Sprite> ImageList;

        public List<PokemonType> PokemonTypeList = new List<PokemonType>
        {
            PokemonType.Bulbasaur001,
            PokemonType.Ivysaur002,
            PokemonType.Venusaur003,
            PokemonType.Charmander004,
            PokemonType.Charmeleon005,
            PokemonType.Charizard006,
            PokemonType.Squirtle007,
            PokemonType.Wartortle008,
            PokemonType.Blastoise009,
            PokemonType.Caterpie010,
            PokemonType.Metapod011,
            PokemonType.Butterfree012,
            PokemonType.Weedle013,
            PokemonType.Kakuna014,
            PokemonType.Beedrill015,
            PokemonType.Pidgey016,
            PokemonType.Pidgeotto017,
            PokemonType.Pidgeot018,
            PokemonType.Rattata019,
            PokemonType.Raticate020,
            PokemonType.Fearow022,
            PokemonType.Ekans023
        };
    }
}
