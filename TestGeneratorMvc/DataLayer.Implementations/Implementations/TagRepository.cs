using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Implementations.Implementations
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context)
            : base(context)
        {
        }
    }
}
