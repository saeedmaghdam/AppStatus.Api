namespace AppStatus.Api.Controllers.Application.InputModels
{
    public class CreateAndUpdateToDoInputModel
    {
        public string Title
        {
            get;
            set;
        }

        public string[] ToDoIds
        {
            get;
            set;
        }
    }
}
