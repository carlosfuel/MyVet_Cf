using MyVet_Cf.Prism.Interfaces;
using MyVet_Cf.Prism.Resources;
using Xamarin.Forms;

namespace MyVet_Cf.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept => Resource.Accept;

        public static string Error => Resource.Error;

        public static string EmailError => Resource.EmailError;
    }

}
