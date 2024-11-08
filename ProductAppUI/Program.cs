var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://your-allowed-origin.com")

               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.MapRazorPages();
app.UseAuthorization();


app.MapGet("/", context =>
{
    context.Response.Redirect("/Index");
    return Task.CompletedTask;
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();



