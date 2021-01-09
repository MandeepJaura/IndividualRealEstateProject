using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GropProject3.Models
{
    public class HomeListingOperations : IHomeListingRepository
    {
        private RealEstateDBContext context;
        public HomeListingOperations(RealEstateDBContext context)
        {
            this.context = context;
        }
        public void Add(HomeListing homeListing)
        {
            context.homes.Add(homeListing);
            context.SaveChanges();
        }

        public void Delete(HomeListing homeListing)
        {
            context.homes.Remove(homeListing);
            context.SaveChanges();
        }

        public HomeListing GetAHomeListing(int id)
        {
            return context.homes.Find(id);
        }

        public IEnumerable<HomeListing> GetHomeListings()
        {
            return context.homes.ToList();
        }

        public IEnumerable<HomeListing> GetHomeListingsByAgentBy(int id)
        {
            return context.homes.Where(h => h.AgentId == id).ToList();
        }

        public void Update(HomeListing changeHome)
        {
            var item = context.homes.Attach(changeHome);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
