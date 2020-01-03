using MonsterAPI.Data;
using MonsterAPI.Model.Model_EF;
using MonsterAPI.Model;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MonsterAPI.Data
{
    public class DataInit{
        private readonly ApplicationDBContext _context;

        private readonly string _jsonName = "/Data/Seeding/data.json";
     
       

        private ICollection<Liedje> _liedjes;
        //private ICollection<Album> _albums;
        private ICollection<Artist> _artists;
      

        public DataInit(ApplicationDBContext context){
            _context = context;
           
        }

        public void SeedData() {
          
           // _artists = MakeArtists();
           // _albums = MakeAlbums();
            _liedjes = MakeLiedjes();
            
            

            AddDataToDB();
        }
        //private ICollection<Album> MakeAlbums()
        //{
        //    JsonTextReader reader = new JsonTextReader(
        //       new StreamReader($"{Directory.GetCurrentDirectory()}{_jsonName}"));
        //    using (reader)
        //    {
        //        JObject obj = (JObject)JToken.ReadFrom(reader);

        //        List<Album> albums = new List<Album>();


        //        JArray albumslezer = ((JArray)obj.GetValue("albums"));
        //        foreach (String s in albumslezer)
        //        {
        //            Album alb = new Album();
        //            alb.naam = s;
        //            alb.jaar = 2016;
        //            albums.Add(alb);
        //        }


        //        return albums;


        //    }
       // }

        private ICollection<Artist> MakeArtists()
        {
            JsonTextReader reader = new JsonTextReader(
               new StreamReader($"{Directory.GetCurrentDirectory()}{_jsonName}"));
            using (reader)
            {
                JObject obj = (JObject)JToken.ReadFrom(reader);

                List<Artist> artisten = new List<Artist>();


                JArray artistenlezer = ((JArray)obj.GetValue("artisten"));
                foreach (String s in artistenlezer)
                {
                    Artist art = new Artist();
                    art.naam = s;
                    art.groep = "false";
                    artisten.Add(art);
                }


                return artisten;


            }
        }

        private ICollection<Liedje> MakeLiedjes()
        {
            JsonTextReader reader = new JsonTextReader(
               new StreamReader($"{Directory.GetCurrentDirectory()}{_jsonName}"));
            using (reader)
            {
                JObject obj = (JObject)JToken.ReadFrom(reader);

                List<Liedje> liedjesList = new List<Liedje>();
                List<String> edList = new List<String>();

                 Artist lomepal = new Artist();
                lomepal.naam = "Lomepal";
                lomepal.groep = "false";

                Artist ed = new Artist();
                ed.naam = "Ed Sheeran";
                ed.groep = "false";

                JArray edx = ((JArray)obj.GetValue("x"));
                foreach (String s in edx)
                {
                    Liedje edsong = new Liedje();
                    edsong.taal = "English";
                    edsong.genre = "Sloft";
                    edsong.title = s;
                    edsong.artist = ed;
                    liedjesList.Add(edsong);
                }
                JArray lomepalamina = ((JArray)obj.GetValue("amina"));
                foreach (String s in lomepalamina)
                {
                    Liedje lomepaleSong = new Liedje();
                    lomepaleSong.taal = "French";
                    lomepaleSong.genre = "Rap";
                    lomepaleSong.title = s;
                    lomepaleSong.artist = lomepal;
                    liedjesList.Add(lomepaleSong);
                }


                return liedjesList;


            } }

        private void AddDataToDB()
        {
            using (_context)
            {
                //_context.Albums.AddRange(_albums);
                //_context.Artisten.AddRange(_artists);
                _context.Liedjes.AddRange(_liedjes);
                _context.SaveChanges();
            }
        }
    }
}

       
