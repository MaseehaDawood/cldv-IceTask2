using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using AzureTableMvc.Models;

namespace AzureTableMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly TableServiceClient _tableService;
        private const string TableName = "People";

        public HomeController(TableServiceClient tableService)
        {
            _tableService = tableService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonEntity model)
        {
            if (!ModelState.IsValid) return View("Index", model);

            var tableClient = _tableService.GetTableClient(TableName);
            await tableClient.CreateIfNotExistsAsync();

            model.PartitionKey = "PeoplePartition";
            model.RowKey = Guid.NewGuid().ToString();

            await tableClient.AddEntityAsync(model);

            ViewBag.Message = "Person saved to Azure Table Storage.";
            return View("Index");
        }
    }
}
