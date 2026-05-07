using PaginationTest.Database.AppDbContextModels;

namespace PaginationTest.Models
{
    // Partial View အတွက် သီးသန့် Model
    public class PaginationModel
    {
        public int PageNo { get; set; }
        public int PageCount { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; } // Optional
        public Dictionary<string, string> RouteValues { get; set; } // Optional for other parameters
    }

    // မူလ Data List အတွက် Model
    public class CustomerListResponseModel
    {
        public List<Customer> Data { get; set; }
        public int PageNo { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}