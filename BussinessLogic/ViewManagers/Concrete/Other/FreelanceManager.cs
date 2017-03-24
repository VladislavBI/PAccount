using BussinessLogic.ViewManagers.Abstract.Investment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using RateScriptorLibrary;
using RateScriptorLibrary.ProgrammModel;

namespace BussinessLogic.ViewManagers.Concrete.Other
{
    public class FreelanceManager : FreelanceManagerBase
    {
        IUnitOfWork _unitOfWork;
        RateScriptor rateScriptor;
        public FreelanceManager()
        {
            rateScriptor = new RateScriptor();
        }
        public override void AddHours(HoursData model)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var hoursModel = _unitOfWork.PersonalAccountantContext.Set<other_SpendHoursPerProject>().FirstOrDefault(x => x.ProjectId == model.ProjectId);
                if (hoursModel != null)
                {
                    hoursModel.SpendHours = model.Hours;
                }
                else
                {
                    _unitOfWork.PersonalAccountantContext.Set<other_SpendHoursPerProject>().Add(new other_SpendHoursPerProject()
                    {
                        SpendHours = model.Hours,
                        ProjectId = model.ProjectId
                    });
                }
                _unitOfWork.Save();
            }
        }

        public override void AddNewProject(ProjectData model)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                _unitOfWork.PersonalAccountantContext.Set<other_Projects>().Add(new other_Projects()
                {
                    CurrencyId = model.CurrencyId,
                    SumPerHour = model.SumPerHour,
                    TotalHours = model.TotalHours,
                    UserId = model.UserId,
                    Name = model.Name
                });
                _unitOfWork.Save();
            }
        }

        public override void AddPayement(PaymentModel model)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                _unitOfWork.PersonalAccountantContext.Set<other_FreelancePayement>().Add(new other_FreelancePayement()
                {
                    CurrencyId = model.CurrencyId,
                    PayDate = new DateTime(),
                    HoursPayed = model.PayedHours,
                    ProjectId = model.ProjectId,
                    SumPayed = model.PayedSum
                });

                _unitOfWork.Save();

            }
        }

        public override void ChangeProjectData(other_Projects model)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var project = _unitOfWork.PersonalAccountantContext.Set<other_Projects>().FirstOrDefault(x => x.Id == model.Id);

                project.SumPerHour = model.SumPerHour;
                project.TotalHours = model.TotalHours;
                project.Name = model.Name;
                _unitOfWork.Save();
            }
        }

        public override List<FreelanceListItem> GetProjects(string userIdParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                int userId = Convert.ToInt32(userIdParam);
                var projects = _unitOfWork.PersonalAccountantContext.Set<other_Projects>().Where(x => x.UserId == userId).Select(x => new FreelanceListItem
                {
                    Name = x.Name,
                    FullHours = x.TotalHours,
                    SumPerHour = x.SumPerHour,
                    PayedHours = x.other_FreelancePayement.Sum(z => z.HoursPayed),
                    UnpayedHours = x.other_SpendHoursPerProject.Sum(z => z.SpendHours),
                    Id = x.Id,
                    IsEnded = x.IsEnded
                }).ToList();
                foreach (var project in projects)
                {
                    project.UnpayedHours -= project.PayedHours;
                    var projectModel = _unitOfWork.PersonalAccountantContext.Set<other_FreelancePayement>().Where(x => x.ProjectId == project.Id).Select(x => new FinanceOperationModel()
                    {
                        CurrencyName = x.Currency.Name,
                        Summ = x.SumPayed
                    }).FirstOrDefault();
                    if (projectModel != null)
                    {
                        project.PayedSum = rateScriptor.ChangeBuyRateForCurrency(projectModel.Summ, projectModel.CurrencyName, "USD");
                    }
                }
                return projects;
            }
        }

        public override void ChangeProjectStatus(int projectId)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var project = _unitOfWork.PersonalAccountantContext.Set<other_Projects>().FirstOrDefault(x => x.Id == projectId);
                project.IsEnded = !project.IsEnded;
                _unitOfWork.Save();
            }
        }
    }
}
