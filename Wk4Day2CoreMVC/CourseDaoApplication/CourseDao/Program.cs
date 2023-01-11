using CourseDaoApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICourseDAO, CourseDAO>();
builder.Services.AddScoped<ICourseDAO, CourseDAO>();

builder.Services.AddSqlServer<MyDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add CourseDAO service
builder.Services.AddScoped<CourseDAO>();
//builder.Services.AddSingleton<IConfiguration>(Configuration);





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
