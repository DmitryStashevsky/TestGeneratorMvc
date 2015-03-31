using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        List<Tag> GetTagsForText(List<string> tagsInText);

        void CreateTagsWhichNotExists(List<string> tagsInText);
    }
}
