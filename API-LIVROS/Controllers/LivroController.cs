using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_LIVROS.Domain;
using API_LIVROS.Interface;
using API_LIVROS.Model;
using API_LIVROS.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_LIVROS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
   
        private readonly IMapper _mapper;
        public IBaseRepository<Livro> _Repository { get; set; }
        public LivroController(IBaseRepository<Livro> repository,IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
            
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var entity = await _Repository.GetAll();
            var results = _mapper.Map<LivroModel[]>(entity);
            return Ok(results);
        }

           [HttpGet ("{LivroId}")]
        public async Task<IActionResult>GetById(string LivroId)
        {
            var entity = await _Repository.GetById(LivroId);
            var results = _mapper.Map<LivroModel>(entity);
            return Ok(entity);
        }


       [HttpPost]
        public async Task<IActionResult> Post(LivroModel livro)
        {

            var livro1 = _mapper.Map<Livro>(livro);
           

            _Repository.Add(livro1);

            if (await _Repository.Save())
                return Created($"api/Livro/{livro.Id}", livro);
            return BadRequest();
        }

         [HttpDelete("{Id}")]
         public async Task<IActionResult>Delete(string Id) 
         {
            var entity = await _Repository.GetById(Id);

            if (entity == null) return NotFound();
            _Repository.Delete(entity);

            if (await _Repository.Save())
            return Ok();
            return BadRequest();   
         }

         [HttpPut("{Id}")]
         public async Task<IActionResult> Put(string Id, LivroModel model)
         {
            var entity = await _Repository.GetById(Id);

            if (entity == null) return NotFound();
            _mapper.Map(model, entity);
            _Repository.Update(entity);

            if(await _Repository.Save())
          
            return Created($"api/Livro/{model.Id}", _mapper.Map<LivroModel>(entity));
            return BadRequest();
         }  
    }
}