using System.Threading.Tasks;

namespace MyVet_Cf.Web.Helpers
{
    public interface IAgendaHelper
    {
        Task AddDaysAsync(int days);
    }

}
