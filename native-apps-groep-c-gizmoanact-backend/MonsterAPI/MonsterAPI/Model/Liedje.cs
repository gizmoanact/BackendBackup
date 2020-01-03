using System;
namespace MonsterAPI.Model.Model_EF
{
    public class Liedje
    {
        public long ID { get; set; }

        public String title { get; set; }
        public Artist artist { get; set; }

     

        public Decimal bass { get; set; }
        public Decimal mood { get; set; }
        public Decimal hard { get; set; }
        public String genre { get; set; }
        public String taal { get; set; }
       // public String link { get; set; }
    }

    
}
