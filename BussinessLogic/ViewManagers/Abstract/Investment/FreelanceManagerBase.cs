using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract.Investment
{
    public abstract class FreelanceManagerBase
    {
        public abstract void AddNewProject(ProjectData model);
        public abstract void AddHours(HoursData model);
        public abstract void ChangeProjectData(other_Projects model);
        public abstract void AddPayement(PaymentModel model);
        public abstract List<FreelanceListItem> GetProjects(string userId);
        public abstract void ChangeProjectStatus(int projectId);
    }
}
