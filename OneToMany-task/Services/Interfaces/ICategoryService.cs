﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneToMany_task.Models;
using OneToMany_task.ViewModels.Categories;

namespace OneToMany_task.Services.Interfaces
{
	public interface ICategoryService
	{
        Task<List<Category>> GetAllAsync();
        Task<List<CategoryVM>> GetAllOrderByDescAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(CategoryCreateVM category);
        Task<Category> GetWithProductAsync(int id);
        Task DeleteAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task EditAsync(Category category, CategoryEditVM categoryEdit);
        Task<SelectList> GetAllBySelectAsync();
    }
}

