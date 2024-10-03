namespace SchoolProject.Data.Common
{
    public class GenericStudentLocalizableEntity
    {
        public string GetLocalizedName(string inputAr, string inputEn)
        {
            var culture = Thread.CurrentThread.CurrentCulture;

            if (culture.TwoLetterISOLanguageName.ToLower() == "ar")
            {
                return inputAr;
            }
            return inputEn;
        }
    }
}
