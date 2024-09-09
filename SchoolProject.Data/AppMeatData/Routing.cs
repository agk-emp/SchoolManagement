namespace SchoolProject.Data.AppMeatData
{
    public static class Routing
    {
        public const string singleRoute = "{id}";
        public const string root = "Api";
        public const string versionOne = "v1";

        public const string rootVersionOne = root+"/"+ versionOne;

        public static class StudentRouting
        {
            public const string prefix = "Student";
            public const string studentVersionOneRoute=rootVersionOne+"/"+ prefix+"/";

            public const string GetAll=studentVersionOneRoute+"GetAllStudents";
            public const string GetById = studentVersionOneRoute + singleRoute;
            public const string Create = studentVersionOneRoute + "Create";
        }
    }
}
