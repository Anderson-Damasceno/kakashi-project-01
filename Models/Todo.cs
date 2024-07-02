﻿using TodoList.Enums;

namespace TodoList.Models;

public class Todo
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public TodoPriority Priority { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDate { get; set; }
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}