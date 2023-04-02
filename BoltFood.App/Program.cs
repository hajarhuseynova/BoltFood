
using BoltFood.Service.Services.Implementations;
using BoltFood.Service.Services.Interfaces;

IMenuService MenuService = new MenuService();

await MenuService.ShowMenuAsync();
