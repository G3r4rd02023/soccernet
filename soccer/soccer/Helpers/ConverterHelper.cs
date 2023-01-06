using soccer.Data.Entities;
using soccer.Models;

namespace soccer.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Team ToTeam(TeamViewModel model, string path, bool isNew)
        {
            return new Team
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                LogoPath = team.LogoPath,
                Name = team.Name
            };
        }
    }
}
