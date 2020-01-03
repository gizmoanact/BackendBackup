using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MonsterAPI.Model.Interface;
using MonsterAPI.Model.Model_EF;

namespace MonsterAPI.Controllers
{
    [Route("api/[controller]")]
    public class LiedjesController:ControllerBase
    {

        private ILiedjeRepository _liedjeRepository;
        public LiedjesController(ILiedjeRepository liedjeRepository)
        {
            _liedjeRepository = liedjeRepository;
        }

        [HttpPost]
        public IActionResult createAlbum(Liedje liedje)
        { //Geef AterlierDTO en controleer de HTTPPut
            _liedjeRepository.Add(liedje);
            _liedjeRepository.saveChanges();
            return Ok();
        }
        [Route("{id}")]
        [HttpDelete]
        public ActionResult<Liedje> DeleteAlbum(int id)
        {
            try
            {
                Liedje l = _liedjeRepository.GetById(id);

                if (l == null)
                {
                    return null;
                }

                _liedjeRepository.Remove(l);
                _liedjeRepository.saveChanges();

                return l;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Liedje>> GeefalleLiedjes()
        {
            try
            {
                return _liedjeRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                //return null;
            }
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Liedje> GetById(long id)
        {
            return _liedjeRepository.GetById(id);
        }

        [Route("{liedje}")]
        [HttpPut]
        public IActionResult UpdateMenu(Liedje liedje)
        {
            _liedjeRepository.Update(liedje);
            return Ok();
        }


        [Route("geefVoorstel/{idLied}")]
        [HttpGet]
        public ActionResult<IEnumerable<Liedje>> geefVoorstel(long idLied)
        {
            try
            {
                return _liedjeRepository.GeefById(idLied).ToList();
            } 
            catch (Exception )
            {
               return _liedjeRepository.GetAll().ToList();


    }
}


        [Route("geeByTitle/{title}")]
        [HttpGet]
        public ActionResult<IEnumerable<Liedje>> geeByTitle(string title)
        {
            
            IEnumerable<Liedje> p = _liedjeRepository.GeefById(_liedjeRepository.geeByTitle(title)).ToList();

            Console.WriteLine(p.ToString());
            return _liedjeRepository.GeefById(_liedjeRepository.geeByTitle(title)).ToList();




        }
    }
}

