using Core1.Data;
using Core1.Models;
using Microsoft.EntityFrameworkCore;

namespace Core1.Repository
{
    public class LanguageRepository
    {
        private AppDbContext _context;
        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            // return (IEnumerable<LanguageModel>) await _context.Languages.ToListAsync();
            return await _context.Languages.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

    }
}
