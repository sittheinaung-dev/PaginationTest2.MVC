using Microsoft.AspNetCore.Mvc;
using PaginationTest.Models;
using PaginationTest.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

public class CustomerController : Controller
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Customer/Index
    public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
    {
        // Response Model တစ်ခု ပြင်ဆင်ထားပါတယ်
        var model = new CustomerListResponseModel();

        // Database ထဲက Customer data တွေကို IQueryable အဖြစ် ကြေညာထားပါတယ်
        // ဒီအဆင့်မှာ data ကို ဆွဲမထုတ်သေးပါဘူး
        var query = _context.Customers.AsQueryable();

        // 1. စုစုပေါင်း Data အရေအတွက်ကို ရယူခြင်း
        var rowCount = await query.CountAsync();

        // 2. Page အရေအတွက် တွက်ချက်ခြင်း
        var pageCount = (int)Math.Ceiling((double)rowCount / pageSize);
        // အကြွင်းကို စစ်စရာမလိုဘဲ Math.Ceiling နဲ့ အလွယ်တကူ တွက်နိုင်ပါတယ်

        // 3. လိုအပ်သော Data ကိုသာ Skip & Take ဖြင့် ရွေးထုတ်ခြင်း
        var customers = await query
            .Skip((pageNo - 1) * pageSize) // ရှေ့ page မှ data များကို ကျော်သွားပါမယ်
            .Take(pageSize)               // လက်ရှိ page အတွက် data ကို ယူပါမယ်
            .ToListAsync();

        // 4. Response Model ထဲသို့ Data များ ထည့်သွင်းခြင်း
        model.Data = customers;
        model.PageCount = pageCount;
        model.PageNo = pageNo;
        model.PageSize = pageSize;

        // 5. Model ကို View သို့ ပို့ပေးခြင်း
        return View(model);
    }
}