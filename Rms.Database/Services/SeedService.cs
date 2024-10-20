using Rms.Database.Database;
using Rms.Models.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Rms.Database.Services
{
    public class SeedService
    {
        private readonly ApplicationDbContext _context;

        public SeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedCpanel()
        {
            // Check if Cpanel data already exists
            if (!_context.CpanelSeeds.Any())
            {
                // Seed initial data
                var complexes = new List<CpanelSeed>
                {
                new CpanelSeed { 
                    Name = "Sunset Apartment",
                    Address = "123 Main St",
                    Phone = "01771179790" 
                }

            };
                _context.CpanelSeeds.AddRange(complexes);
                _context.SaveChanges();
            }
            else
            {
                var complex = _context.CpanelSeeds.FirstOrDefault();
                if (complex != null)
                {
                    complex.Name = "Michael Johnsons"; 
                    complex.Phone = "222-333-4444"; 
                    _context.SaveChanges();
                }
            }
        }
    }
}
