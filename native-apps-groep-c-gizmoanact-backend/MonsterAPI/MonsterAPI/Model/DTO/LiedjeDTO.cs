using System;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Model.DTO
{
    public class LiedjeDTO
    {
        public long ID {get; set;}
        public String title { get; set; }
        public ArtistDTO artist { get; set; }

      //  public AlbumDTO album { get; set; }

        public Decimal bass { get; set; }
        public Decimal mood { get; set; }
        public Decimal hard { get; set; }
        public String genre { get; set; }
        public String taal { get; set; }
       // public String link { get; set; }
    }
    //public LiedjeDTO(Artist artist, Album album)
    //{
    //    Personen = personen.Select(p => new PersoonDTO(p)).ToArray();
    //    ActiviteitNaam = at.Naam;

    //}
}