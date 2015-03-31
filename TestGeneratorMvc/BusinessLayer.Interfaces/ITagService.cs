using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ApiModel;
using DataLayer.Model;

namespace BusinessLayer.Interfaces
{
    public interface ITagService
    {
        List<Tag> GetTagsFromString(string tags);

        string GetTagsToString(List<Tag> tags);
    }
}
