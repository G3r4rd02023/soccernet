using soccer.Data.Entities;
using soccer.Models;

namespace soccer.Helpers
{
    public interface IConverterHelper
    {
        Team ToTeam(TeamViewModel model, string path, bool isNew);

        TeamViewModel ToTeamViewModel(Team team);

    }
}
