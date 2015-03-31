using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace BusinessLayer.Services
{
    public class TagService : ITagService
    {
        private IUnitOfWork m_UnitOfWork;
        private ITagRepository m_TagRepository;

        public TagService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TagRepository = m_UnitOfWork.GetRepository<ITagRepository>();
        }

        public List<Tag> GetTagsFromString(string tags)
        {
            List<string> tagsInText = tags.Split(' ').ToList();
            return m_TagRepository.GetTagsForText(tagsInText);
        }

        public string GetTagsToString(List<Tag> tags)
        {
            return string.Join(" ", tags.Select(e => e.Text).ToList());
        }
    }
}
