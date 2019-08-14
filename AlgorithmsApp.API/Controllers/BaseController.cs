using AlgorithmsApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsApp.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public DataManager dataManager {get; set;}
        public BaseController(DataContext context): base()
        {
            dataManager = new DataManager(context);
        }
    }
}