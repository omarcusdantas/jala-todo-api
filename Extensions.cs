using JalaTodoApi.Contracts;
using JalaTodoApi.Repositories;
using JalaTodoApi.Services;

namespace JalaTodoApi;

public static class Extensions
{
    public static IServiceCollection AddTodoServices(this IServiceCollection services)
        => services
            .AddScoped<IGetTodo, GetTodo>()
            .AddScoped<IGetAllTodos, GetAllTodos>()
            .AddScoped<ICreateTodo, CreateTodo>()
            .AddScoped<ITodoRepository, TodoRepository>();
}
