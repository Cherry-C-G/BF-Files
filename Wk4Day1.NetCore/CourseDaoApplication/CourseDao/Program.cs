using CourseDaoApplication;
using CourseDaoMVC.Services;
using CourseDaoMVC.Services.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICourseDAO, CourseDaoMVC.Services.CourseDAO>();
builder.Services.AddScoped<ICourseDAO, CourseDaoMVC.Services.CourseDAO>();
builder.Services.AddTransient<IProfessorDAO, ProfessorDAO>();
builder.Services.AddScoped<IProfessorDAO, ProfessorDAO>();
builder.Services.AddTransient<IStudentDAO, StudentDAO>();
builder.Services.AddScoped<IStudentDAO, StudentDAO>();
//builder.Services.AddTransient<IStudent_CourseDAO, Student_CourseDAO>();
//builder.Services.AddScoped<IStudent_CourseDAO, Student_CourseDAO>();

builder.Services.AddSqlServer<MyDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

//// Add CourseDAO service
//builder.Services.AddScoped<CourseDAO>();
//builder.Services.AddSingleton<IConfiguration>(Configuration);

builder.Services.AddAuthentication("MyLogin").AddCookie("MyLogin", options =>
{
    options.Cookie.Name = "MyLogin";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
