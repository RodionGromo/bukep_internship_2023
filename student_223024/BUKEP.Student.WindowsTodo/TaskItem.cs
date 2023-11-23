﻿using System;
using System.Linq;

namespace BUKEP.Student.WindowsTodo
{
	/// <summary>
	/// Класс TaskItem, содержит в себе название задачи Name и её описание Description
	/// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string? Name { get; set;}
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string? Description { get; set; }
    }
}
