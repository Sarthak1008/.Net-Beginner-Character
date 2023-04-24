global using crud.Model;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController:Controller
    {
        public DataContext context;
        public CharacterController(DataContext context)
        {
            this.context = context;

        }
        private static List<Character> characters=new List<Character>{
            new Character(),
            new Character{Name="hello"}
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){
                 
                return Ok(context.Characters.ToList());
        }
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
                context.Characters.Add(newCharacter);

            // _context.Characters.Add(character);
                context.SaveChanges();
                // context.SaveChanges();
            return Ok(context.Characters.ToList());
        }
        [HttpPut]
        public ActionResult<Character> UpdateCharacter(Character updatedCharacter)
        {
                var data = context.Characters.FirstOrDefault(x => x.Id == updatedCharacter.Id);
                    data.Name = updatedCharacter.Name;
                    data.HitPoints = updatedCharacter.HitPoints;
                    data.Strength = updatedCharacter.Strength;
                    data.Defense = updatedCharacter.Defense;
                    data.Intelligence=updatedCharacter.Intelligence;
                    context.SaveChanges();
                    return Ok(context.Characters.ToList());
            
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Character>> DeleteCharacter(int id)
        {
            
                var data = context.Characters.FirstOrDefault(x => x.Id == id);
                    context.Characters.Remove(data);
                    context.SaveChanges();
                return Ok(context.Characters.ToList());
            
        }
    }
}