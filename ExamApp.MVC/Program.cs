using AutoMapper;
using ExamApp.Service.Abstract.Repository;
using ExamApp.Service.Abstract.Service;
using ExamApp.Service.Concrete.Repository;
using ExamApp.Service.Concrete.Service;
using ExamApp.Service.Helpers;
using ExamApp.Service.ViewModels.Exam;
using ExamApp.Service.ViewModels.Lesson;
using ExamApp.Service.ViewModels.Student;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidation();

var mapconfig = new MapperConfiguration(mc =>
    mc.AddProfile<MappingProfile>()
);
IMapper mapper = mapconfig.CreateMapper();
builder.Services.AddSingleton(mapper);


#region Repos
builder.Services.AddScoped(typeof(IDbFactory<>), typeof(DbFactory<>));
builder.Services.AddScoped(typeof(IUnitofWork<>), typeof(UnitOfWork<>));
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
#endregion
#region Services
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IExamService, ExamService>();
#endregion
#region Validators
builder.Services.AddTransient<IValidator<LessonViewModel>, LessonViewModelValidator>();
builder.Services.AddTransient<IValidator<StudentViewModel>, StudentViewModelValidator>();
builder.Services.AddTransient<IValidator<ExamViewModel>, ExamViewModelValidator>();
builder.Services.AddTransient<IValidator<CreateExamViewModel>, CreateExamViewModelValidator>();
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
