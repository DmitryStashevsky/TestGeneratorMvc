using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using DataLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork m_UnitOfWork;
        private IUserRepository m_UserRepository;

        public UserService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_UserRepository = m_UnitOfWork.GetRepository<IUserRepository>();
        }

        public ApiViewUser GetUserWithRole()
        {
            throw new NotImplementedException();
        }

        public List<ApiViewUserWithInfo> GetUsersWithInfo()
        {
            return Mapper.Map<List<ApiViewUserWithInfo>>(m_UserRepository.GetAllWithInfo());
        }

        public int GetUsersCount()
        {
            return m_UserRepository.Count;
        }

        public string CnahgeUserRole(Guid userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}
