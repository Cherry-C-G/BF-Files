var builder = WebApplication.CreateBuilder(args);

//Add / register sign in authentication handler
builder.Services.AddAuthentication("MyCookie").AddCookie("MyCookie", options =>
{
    options.Cookie.Name = "MyCookie";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    //options.ExpireTimeSpan = TimeSpan.FromSeconds(100); //set the cookie expiriation time
});


# region Add Authorization
builder.Services.AddAuthorization(options =>
{
    //Add a policy called HROnly, so the page 
    options.AddPolicy("HROnly", policy => policy.RequireClaim("Department", "HR"));
});
#endregion


// Add services to the container.
builder.Services.AddControllersWithViews();


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
//Add Authentication to the pipeline, order matters, Authentication -> Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
