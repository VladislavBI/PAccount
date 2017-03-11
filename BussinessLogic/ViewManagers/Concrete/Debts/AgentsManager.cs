using BussinessLogic.ViewManagers.Abstract.Debts;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;

namespace BussinessLogic.ViewManagers.Concrete.Debts
{
    public class AgentsManager : IAgentsManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperManager;
        public AgentsManager(IMapperHelper mapperHelperParam)
        {
            _mapperManager = mapperHelperParam;
        }
        public debt_DebtAgent CreateNewInstance(string nameParam)
        {
            _unitOfWork.PersonalAccountantContext.Set<debt_DebtAgent>().Add(new debt_DebtAgent() { Name = nameParam });
            _unitOfWork.Save();
            return _unitOfWork.PersonalAccountantContext.Set<debt_DebtAgent>().FirstOrDefault(x => x.Name.ToUpper() == nameParam.ToUpper());
        }

        public NameIdClassModel GetAgentWithCurrentName(string nameParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                debt_DebtAgent contextAgent = _unitOfWork.PersonalAccountantContext.Set<debt_DebtAgent>().FirstOrDefault(x => x.Name.ToUpper() == nameParam.ToUpper());
                if (contextAgent == null)
                {
                    int Id = 0;
                    contextAgent = Int32.TryParse(nameParam, out Id) ?
                        _unitOfWork.PersonalAccountantContext.Set<debt_DebtAgent>().FirstOrDefault(x => x.Id == Id) :
                        CreateNewInstance(nameParam);
                }

                return _mapperManager.MapModel<debt_DebtAgent, NameIdClassModel>(contextAgent);
            }
        }

        public dynamic GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<debt_DebtAgent>().Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
    }
}
