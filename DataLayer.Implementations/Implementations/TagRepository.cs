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

        public List<Tag> GetTagsForText(List<string> tagsInText)
        {
            return m_Context.Set<Tag>().Where(e => tagsInText.Contains(e.Text)).ToList();
        }

        public void CreateTagsWhichNotExists(List<string> tagsInText)
        {
            List<Tag> tagInDatabase = GetTagsForText(tagsInText);
            List<string> tagsWhichNotExists = tagsInText.Except(tagInDatabase.Select(e => e.Text).ToList()).ToList();
            if (tagInDatabase.Count != tagsInText.Count)
            {
                foreach (var tag in tagsWhichNotExists)
                {
                    Create(new Tag { Text = tag });
                };
                m_Context.SaveChanges();
            }
        }
    }
}
