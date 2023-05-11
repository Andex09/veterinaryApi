using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly VeterinaryDbContext _context;

        public PetRepository(VeterinaryDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Add(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task DeletePet(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<Pet> GetPet(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<List<Pet>> GetPetList()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task UpdatePet(Pet pet)
        {
            var petItem = _context.Pets.FirstOrDefault(p => p.Id == pet.Id);

            if (petItem != null)
            {
                petItem.Name = pet.Name;
                petItem.Breet = pet.Breet;
                petItem.Age = pet.Age;
                petItem.Weight = pet.Weight;
                petItem.Color = pet.Color;

                await _context.SaveChangesAsync();
            }

        }
    }
}
