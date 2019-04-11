﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Tasks;

namespace TaskManager.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly TaskManager.Models.TaskManagerContext _context;

        public DetailsModel(TaskManager.Models.TaskManagerContext context)
        {
            _context = context;
        }

        public TaskEntity TaskEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskEntity = await _context.TaskEntity.FirstOrDefaultAsync(m => m.Id == id);

            if (TaskEntity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
